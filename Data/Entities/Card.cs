using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.Data.Entities
{
    public class Card: ICard
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? CardTitle { get; set; }
        public string? CardImg { get; set; }
        public string? CardImg3 { get; set; }
        public string? CardLink { get; set; }
        public string? CardLinkName { get; set; }
        public string? CardIcon { get; set; }
        public virtual ICollection<CardContent>? CardContents { get; set; }
        public StoreUser? User { get; set; }
    }
}
