using System;
using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Publications;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Terminator.BusinessLayer.Publications;

namespace GeneratorAPI.Controllers
{
    [Route("api/publications")]
    public class PublicationsController : Controller
    {
        // GET:  api/publications/{numberOfMessages}
        [HttpGet("{numberOfMessages}")]
        public string GetPublicationsByNumberOfMessages(int numberOfMessages)
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new PublicationConverter() },
                DateFormatString = "d.MM.yyyy",
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(generator.Generate(publicationsConfiguration, numberOfMessages));

            return json;
        }
    
        // GET:  api/publications
        [HttpGet]
        public string GetPublications()
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new PublicationConverter() },
                DateFormatString = "d.MM.yyyy",
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(generator.Generate(publicationsConfiguration, 1000));

            return json;
        }
    }

    public class PublicationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(object) == typeof(List<Publication>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
