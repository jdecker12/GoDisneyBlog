using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.Data.Entities
{
    public class CardContent
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? ParaOne { get; set; }
        public string? ParaTwo { get; set; }
        public string? ParaThree { get; set; }
        public string? ParaFour { get; set; }
        public Card? Card { get; set; }
    }
}
