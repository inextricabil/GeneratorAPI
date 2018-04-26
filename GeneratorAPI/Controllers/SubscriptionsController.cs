using System;
using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Subscription;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GeneratorAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/subscriptions")]
    public class SubscriptionsController : Controller
    {
        // GET:  api/subscriptions/{numberOfMessages}
        [HttpGet("{numberOfMessages}")]
        public string GetSubscriptionsByNumberOfMessages(int numberOfMessages)
        {
            var publicationsConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new SubscriptionConverter() },
                DateFormatString = "d.MM.yyyy",
                Formatting = Formatting.Indented
        };

            var json = JsonConvert.SerializeObject(generator.Generate(publicationsConfiguration, numberOfMessages));

            return json;
        }

        // GET:  api/subscriptions
        [HttpGet]
        public string GetSubscriptions()
        {
            var subscriptionConfiguration = new SubscriptionConfiguration();
            var generator = new SubscriptionGenerator();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new SubscriptionConverter() },
                DateFormatString = "d.MM.yyyy",
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(generator.Generate(subscriptionConfiguration, 100000));

            return json;
        }
    }

    public class SubscriptionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(object) == typeof(List<Subscription>);
        }
    }
}