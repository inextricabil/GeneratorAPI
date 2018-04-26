using System;
using System.Collections.Generic;
using GeneratorAPI.BusinessLayer.Publications;

namespace Terminator.BusinessLayer.Publications
{
    public  class PublicationGenerator
    {
        private  List<Publication> _publications;
        private  readonly Random _rnd = new Random();


        public  List<Publication> Generate(PublicationConfiguration publicationConfiguration, int noOfMessages)
        {
            _publications = new List<Publication>();
            for (var i = 0; i < noOfMessages; i++)
            {
                var publication = new Publication
                {
                    CompanyName = publicationConfiguration.CompaniesList[_rnd.Next(publicationConfiguration.CompaniesList.Count)],
                    Date = publicationConfiguration.DatesList[_rnd.Next(publicationConfiguration.DatesList.Count)],
                    Value = GetRandomInRange(publicationConfiguration.ValueMin, publicationConfiguration.ValueMax),
                    Drop = GetRandomInRange(publicationConfiguration.DropMin, publicationConfiguration.DropMax),
                    Variation = GetRandomInRange(publicationConfiguration.VariationMin, publicationConfiguration.VariationMax)
                };

                _publications.Add(publication);
            }

            return _publications;
        }

        private double GetRandomInRange(double min, double max)
        {
            return Math.Round(_rnd.NextDouble() * (max - min) + min, 2);
        }

    }
}