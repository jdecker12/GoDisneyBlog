using GoDisneyBlog.Data.Entities;
using Microsoft.AspNetCore.Identity;

using IWebHostingEnvironment = Microsoft.AspNetCore.Hosting.IWebHostEnvironment;

namespace GoDisneyBlog.Data
{
    public class GoDisneySeeder
    {

        private readonly GoDisneyContext _ctx;
        private readonly IWebHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public GoDisneySeeder(GoDisneyContext ctx, IWebHostingEnvironment hosting, UserManager<StoreUser> userManager)
        {
            _ctx = ctx;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _ctx.Database.EnsureCreated();

            StoreUser user = await _userManager.FindByEmailAsync("jeremydecker1@me.com");
            if (user == null)
            {


                user = new StoreUser()
                {
                    FName = "Jeremy",
                    LName = "Decker",
                    Email = "jeremydecker1@me.com",
                    UserName = "jdecker69"
                };



                var result = await _userManager.CreateAsync(user, "P@ssw0rd");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder.");
                }
                _ctx.SaveChanges();
            }

            //if (_ctx.Cards.Any())
            //{
            //    var card = _ctx.Cards
            //           .Where(c => c.Id == 4)
            //           .FirstOrDefault();

            //    card.User = user;
            //}

            //_ctx.SaveChanges();
        }
    }
}

