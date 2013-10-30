using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;

namespace POSSIBLE.RobotsTxtHandler.Initialization
{
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FeedRoutingInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.MapRoute("RobotsTxtRoute", "robots.txt", new { controller = "RobotsTxt", action = "Index" });
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}