using GoDisneyBlog.Data.Entities;
using GoDisneyBlog.Data;
using GoDisneyBlog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.Controllers
{
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {

        private ILogger _logger;
        private SignInManager<StoreUser> _signInManager;
        private UserManager<StoreUser> _userManager;
        private IConfiguration _config;
        private IGoDisneyRepository _repository;

        public AuthController(ILogger<AuthController> logger, SignInManager<StoreUser> signInManager, UserManager<StoreUser> userManager, IConfiguration config, IGoDisneyRepository repository)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _repository = repository;

        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "FallBack");

            }

            return View();
        }

        [HttpPost]
        [Route("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            string uName = model.Username;
            string uPass = model.Password;

            byte[] decName = Convert.FromBase64String(uName);
            byte[] decPass = Convert.FromBase64String(uPass);

            string decodeUser = Encoding.UTF8.GetString(decName);
            string decodedPassword = Encoding.UTF8.GetString(decPass);

            model.Username = decodeUser;
            model.Password = decodedPassword;

            if (ModelState.IsValid)
            {

                var user = await _userManager.FindByNameAsync(model.Username);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        ///create token

                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _config["Tokens:Issuer"],
                            _config["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(300),
                            signingCredentials: creds
                            );
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };
                        return Created("", results);
                    }
                }
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> StoreKey([FromBody] RememberMe model)
        {

            var newKey = model;


            try
            {

                _repository.AddEntity(newKey);
                if (await _repository.SaveAllAsync())
                {

                    return Created($"/Auth/StoreKey/{newKey.Id}", newKey);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new key. {ex}");

            }
            return BadRequest(ModelState);

        }
    }
}
