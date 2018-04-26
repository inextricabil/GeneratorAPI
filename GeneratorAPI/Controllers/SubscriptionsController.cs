using System.Collections.Generic;
using System.Web.Http;
using Terminator.BusinessLayer.Subscription;

namespace Terminator.Controllers
{
    public class SubscriptionsController : ApiController
    {
        [HttpGet]
        public List<Subscription> Index()
        {
            var publicationsConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();
            return generator.Generate(publicationsConfiguration, 30000);
        }

        [HttpGet]
        public List<Subscription> Index(int id)
        {
            var publicationsConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();
            return generator.Generate(publicationsConfiguration, id);
        }
    }
}