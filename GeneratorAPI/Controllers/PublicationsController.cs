using System;
using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Publications;
using Microsoft.AspNetCore.Mvc;
using Terminator.BusinessLayer.Publications;

namespace GeneratorAPI.Controllers
{
    [Route("api/publications")]
    public class PublicationsController : Controller
    {

        private const string Path = @"c:\temp\Publications.txt";


        // GET:  api/publications/{numberOfMessages}
        [HttpGet("{numberOfMessages}")]
        public string GetPublicationsByNumberOfMessages(int numberOfMessages)
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();

            return ConvertPublicationsListToString(generator.Generate(publicationsConfiguration, numberOfMessages));
        }

        // GET:  api/publications
        [HttpGet]
        public string GetPublications()
        {
            var publicationsConfiguration = new PublicationConfiguration();
            var generator = new PublicationGenerator();

            return ConvertPublicationsListToString(generator.Generate(publicationsConfiguration, 10000));
        }

        //{(company,"Google");(value,90.0);(drop,10.0);(variation,0.73);(date,2.02.2022)} 
        private static string ConvertPublicationsListToString(IEnumerable<Publication> publications)
        {
            var result = string.Empty;
            foreach (var publication in publications)
            {
                result += "{(company," + publication.CompanyName +");(value," + publication.Value + ");(drop," + publication.Drop +
                    ");(variation," + publication.Variation + "),(date," + publication.Date.ToString("d.MM.yyyy") + "})}" + System.Environment.NewLine;
            }

            if (!System.IO.File.Exists(Path))
            {
                System.IO.File.WriteAllText(Path, result);
            }

            return result;
        }
    }
}
