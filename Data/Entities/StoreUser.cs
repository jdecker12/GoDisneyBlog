using Microsoft.AspNetCore.Identity;


namespace GoDisneyBlog.Data.Entities
{
    public class StoreUser : IdentityUser
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
    }
}
