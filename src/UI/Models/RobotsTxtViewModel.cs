using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace POSSIBLE.RobotsTxtHandler.UI.Models
{
    public class RobotsTxtViewModel
    {
        [DisplayName("Site Id")]
        public string SiteId { get; set; }
        public IEnumerable<SelectListItem> SiteList { get; set; }
        
        public string RobotsContent { get; set; }

        public string SuccessMessage { get; set; }
        public bool HasSaved { get { return !string.IsNullOrEmpty(SuccessMessage); }}
        
        public string KeyActionPath { get; set; }
    }
}