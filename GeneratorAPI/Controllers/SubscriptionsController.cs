using System;
using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Subscription;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GeneratorAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/subscriptions")]
    public class SubscriptionsController : Controller
    {
        private const string Path = @"c:\temp\Subscriptions.txt";

        // GET:  api/subscriptions/{numberOfMessages}
        [HttpGet("{numberOfMessages}")]
        public string GetSubscriptionsByNumberOfMessages(int numberOfMessages)
        {
            var publicationsConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();

            return ConvertSubscriptionsListToString(generator.Generate(publicationsConfiguration, numberOfMessages));

        }

        // GET:  api/subscriptions
        [HttpGet]
        public string GetSubscriptions()
        {
            var subscriptionConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();

            return ConvertSubscriptionsListToString(generator.Generate(subscriptionConfiguration, 10000));
        }

        //{(company,=,"Google");(value,>=,90);(variation,<,0.8)}
        private static string ConvertSubscriptionsListToString(IEnumerable<Subscription> subscriptions)
        {
            var result = string.Empty;

            foreach (var subscription in subscriptions)
            {
                result += "{";
                if (!string.IsNullOrWhiteSpace(subscription.CompanyName.Value))
                {
                    result += "(company," + subscription.CompanyName.Op + "," + subscription.CompanyName.Value + ");";
                }

                if (!string.IsNullOrWhiteSpace(subscription.Value.Value))
                {
                    result += "(value," + subscription.Value.Op + "," + subscription.Value.Value + ");";
                }

                if (!string.IsNullOrWhiteSpace(subscription.Drop.Value))
                {
                    result += "(drop," + subscription.Drop.Op + "," + subscription.Drop.Value + ");";
                }

                if (!string.IsNullOrWhiteSpace(subscription.Variation.Value))
                {
                    result += "(variation," + subscription.Variation.Op + "," + subscription.Variation.Value + ");";
                }

                if (!string.IsNullOrWhiteSpace(subscription.Date.Value))
                {
                    result += "(date," + subscription.Date.Op + "," + subscription.Date.Value + ");";
                }

                result += "}" + Environment.NewLine;
            }

            if (!System.IO.File.Exists(Path))
            {
                System.IO.File.WriteAllText(Path, result);
            }

            return result;
        }

    }
}