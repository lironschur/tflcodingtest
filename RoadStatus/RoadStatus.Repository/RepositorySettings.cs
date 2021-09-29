using System.Configuration;

namespace RoadStatus.Repository
{
    public class RepositorySettings
    {
        public string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];
        public string ApiSubscriptionKey => ConfigurationManager.AppSettings["ApiSubscriptionKey"];
    }
}