using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Subscription;
using Microsoft.AspNetCore.Mvc;
using Terminator.BusinessLayer.Subscription;

namespace GeneratorAPI.Controllers
{
    public class SubscriptionsController : Controller
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