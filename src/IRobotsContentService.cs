namespace POSSIBLE.RobotsTxtHandler
{
    public interface IRobotsContentService
    {
        string GetRobotsContent();
        string GetRobotsContent(string robotsKey);
        void SaveRobotsContent(string robotsContent);
        void SaveRobotsContent(string robotsContent, string robotsKey);
        string GetSiteKey(string siteId, string siteHost);
    }
}