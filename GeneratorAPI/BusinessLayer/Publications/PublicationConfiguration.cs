using System;
using System.Collections.Generic;

namespace GeneratorAPI.BusinessLayer.Publications
{
    public class PublicationConfiguration
    {

        public List<string> CompaniesList { get; set; } = new List<string>
        {
            "Google", "Apple", "Microsoft", "Amazon", "HP"
        };

        public List<DateTime> DatesList { get; set; } = GetDateTimeList();

        public double ValueMin { get; set; } = 0;
        public double ValueMax { get; set; } = 100;

        public double DropMin { get; set; } = 0;
        public double DropMax { get; set; } = 100;

        public double VariationMin { get; set; } = 0;
        public double VariationMax { get; set; } = 100;

        private static List<DateTime> GetDateTimeList()
        {

            return new List<DateTime>
            {
                new DateTime(1990, 12, 5),
                new DateTime(1994, 3, 10),
                new DateTime(2001, 10, 10),
                new DateTime(2003, 12, 12),
                new DateTime(2008, 5, 10),
                new DateTime(2010, 3, 3),
                new DateTime(2014, 10, 10),
                new DateTime(2015, 6, 6),
                new DateTime(2016, 3,12),
                new DateTime(2018, 4, 26)
            };
        }

    }
}
