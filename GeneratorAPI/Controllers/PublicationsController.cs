using System.Collections.Generic;
using System.Web.Http;
using Terminator.BusinessLayer.Publications;

namespace Terminator.Controllers
{
    public class PublicationsController : ApiController
    {
        // GET: Publications
        [HttpGet]
        public List<Publication> Index(int id)
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();
           return generator.Generate(publicationsConfiguration, id);
        }


        [HttpGet]
        public List<Publication> Index2( )
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();
           return generator.Generate(publicationsConfiguration, 30000);
        }
    }
}
