using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Publications;
using Microsoft.AspNetCore.Mvc;
using Terminator.BusinessLayer.Publications;

namespace GeneratorAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/publications")]
    public class PublicationsController : Controller
    {
        // GET:  api/publications/{numberOfMessages}
        [HttpGet("{numberOfMessages}")]
        public List<Publication> GetPublicationsByNumberOfMessages(int numberOfMessages)
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();
           return generator.Generate(publicationsConfiguration, numberOfMessages);
        }


        [HttpGet]
        public List<Publication> GetPublications()
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();
           return generator.Generate(publicationsConfiguration, 30000);
        }
    }
}
