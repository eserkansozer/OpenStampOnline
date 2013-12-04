using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StampOnline.Domain
{
    public static class Constants
    {
        public const string STAMP_SESSION_KEY =  "DraftStamp";

        public static List<SelectListItem> Fonts
        {
            get{ 
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "Calibri", Value = "Calibri"},
                    new SelectListItem(){Text = "Droid Serif Pro", Value = "Droid Serif Pro"},
                    new SelectListItem(){Text = "Segoe Print", Value = "Segoe Print"}
                };
            }
        }

        public static List<SelectListItem> FontSizes
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "5pt", Value = "5"},
                    new SelectListItem(){Text = "6pt", Value = "6"},
                    new SelectListItem(){Text = "7pt", Value = "7"},
                    new SelectListItem(){Text = "8pt", Value = "8"},
                    new SelectListItem(){Text = "9pt", Value = "9"},
                    new SelectListItem(){Text = "10pt", Value = "10"},
                    new SelectListItem(){Text = "11pt", Value = "11"},
                    new SelectListItem(){Text = "12pt", Value = "12"},
                    new SelectListItem(){Text = "13pt", Value = "13"},
                    new SelectListItem(){Text = "14pt", Value = "14"},
                    new SelectListItem(){Text = "15pt", Value = "15"},
                    new SelectListItem(){Text = "18pt", Value = "18"},
                    new SelectListItem(){Text = "20pt", Value = "20"},
                    new SelectListItem(){Text = "22pt", Value = "22"},
                    new SelectListItem(){Text = "24pt", Value = "24"},
                    new SelectListItem(){Text = "28pt", Value = "28"},
                    new SelectListItem(){Text = "32pt", Value = "32"},
                    new SelectListItem(){Text = "40pt", Value = "40"},
                    new SelectListItem(){Text = "48pt", Value = "48"},
                    new SelectListItem(){Text = "56pt", Value = "56"},
                    new SelectListItem(){Text = "64pt", Value = "64"}
                };
            }
        }
    }
}