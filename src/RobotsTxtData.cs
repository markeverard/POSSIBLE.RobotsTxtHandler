using EPiServer.Data.Dynamic;

namespace POSSIBLE.RobotsTxtHandler
{
    [EPiServerDataStore(AutomaticallyCreateStore = true)]
    public class RobotsTxtData
    {
        [EPiServerDataIndex]
        public string Key { get; set; }

        public string RobotsTxtContent { get; set; }
    }
}
