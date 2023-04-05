using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.Data.Entities
{
    public class RememberMe
    {
        public int Id { get; set; }
        public string? UserKey { get; set; }
        public StoreUser? User { get; set; }
    }
}
