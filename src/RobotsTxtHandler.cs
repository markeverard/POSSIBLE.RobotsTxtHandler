using System.Web;

namespace POSSIBLE.RobotsTxtHandler
{
    /// <summary>
    /// Simple handler for returning robots.txt content. Used in conjunction to 
    /// hooks into the friendly URL rewriter to return the robots.txt content
    /// </summary>
    public class RobotsTxtHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}