using System;
using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Subscription;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeneratorAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/subscriptions")]
    public class SubscriptionsController : Controller
    {
        // GET:  api/subscriptions/{numberOfMessages}
        [HttpGet("{numberOfMessages}")]
        public JObject GetSubscriptionsByNumberOfMessages(int numberOfMessages)
        {
            var publicationsConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();

            return ConvertSubscriptionsListToJOBject(generator.Generate(publicationsConfiguration, numberOfMessages));

        }

        // GET:  api/subscriptions
        [HttpGet]
        public JObject GetSubscriptions()
        {
            var subscriptionConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();

            return ConvertSubscriptionsListToJOBject(generator.Generate(subscriptionConfiguration, 100000));
        }

        private static JObject ConvertSubscriptionsListToJOBject(List<Subscription> subscriptions)
        {
            throw new NotImplementedException();
        }

    }
}