using System.Web.Mvc;

namespace POSSIBLE.RobotsTxtHandler.UI.Controllers
{
    public class RobotsTxtController : Controller
    {
        protected IRobotsContentService RobotsService { get; set; }

        public RobotsTxtController()
         {
             RobotsService = new RobotsContentService();
         }

        public ActionResult Index()
        {
            return Content(RobotsService.GetRobotsContent(), "text/plain");
        }
    }
}