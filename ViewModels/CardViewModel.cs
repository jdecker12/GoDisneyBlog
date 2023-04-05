using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.ViewModels
{
    public class CardViewModel
    {
        public string cardCategory { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string cardTitle { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(30, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string cardImg { get; set; }
        [StringLength(30, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string cardImg3 { get; set; }
        [StringLength(35, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string cardLink { get; set; }
        [StringLength(20, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string cardLinkName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(10, ErrorMessage = "{0} length is between {2} and {1}", MinimumLength = 2)]
        public string cardIcon { get; set; }

        public ICollection<CardContentsViewModel> cardContents { get; set; }
    }
}
