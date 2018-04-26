using System;
using System.Collections.Generic;

namespace GeneratorAPI.BusinessLayer.Subscription
{
    public class SubscriptionConfiguration
    {

      public int NumberOfMessages { get; set; } = 10000;

        public List<string> CompaniesList { get; set; } = new List<string>
        {
            "Google", "Apple", "Microsoft", "Amazon", "HP"
        };

        public List<DateTime> DatesList { get; set; } = GetRandomDateTimeList(10);
        
        public double ValueMin { get; set; } = 0;
        public double ValueMax { get; set; } = 100;

        public double DropMin { get; set; } = 0;
        public double DropMax { get; set; } = 100;

        public double VariationMin { get; set; } = 0;
        public double VariationMax { get; set; } = 100;

        public int CompanyNameFrequency { get; set; } = 90;
        public int ValueFrequency { get; set; } = 90;
        public int DropFrequency { get; set; } = 90;
        public int VariationFrequency { get; set; } = 90;
        public int DateFrequency { get; set; } = 90;



        private static List<DateTime> GetRandomDateTimeList(int numberOfDates)
        {
            var random = new Random();

            var dateTimes = new List<DateTime>();
            for (var i = 0; i < numberOfDates; i++)
            {
                var start = new DateTime(1995, 1, 1);
                var range = (DateTime.Today - start).Days;
                dateTimes.Add(start.AddDays(random.Next(range)));
            }
            return dateTimes;
        }

    }
}