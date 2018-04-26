using System;
using System.Collections.Generic;
using System.Linq;
using GeneratorAPI.BusinessLayer.Publications;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Terminator.BusinessLayer.Publications;

namespace GeneratorAPI.Controllers
{
    [Route("api/publications")]
    public class PublicationsController : Controller
    {
        // GET:  api/publications/{numberOfMessages}
        [HttpGet("{numberOfMessages}")]
        public JObject GetPublicationsByNumberOfMessages(int numberOfMessages)
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();

            return ConvertPublicationsListToJOBject(generator.Generate(publicationsConfiguration, numberOfMessages));
        }

        // GET:  api/publications
        [HttpGet]
        public JObject GetPublications()
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();

            return ConvertPublicationsListToJOBject(generator.Generate(publicationsConfiguration, 1000));
        }

        private static JObject ConvertPublicationsListToJOBject(List<Publication> publications)
        {
            throw new NotImplementedException();
        }
    }
}
