using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoDisneyBlog.ViewModels
{
    public class CardContentsViewModel
    {
        public string? paraOne { get; set; }
        public string? paraTwo { get; set; }
        public string? paraThree { get; set; }
        public string? paraFour { get; set; }

        public CardContentsViewModel? GetCardContentsViewModel { get; set; }
    }
}
