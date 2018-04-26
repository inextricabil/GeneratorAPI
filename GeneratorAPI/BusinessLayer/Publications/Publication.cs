using System;

namespace GeneratorAPI.BusinessLayer.Publications
{
    public class Publication
    {
        public string CompanyName  { get; set; }

        public double Value { get; set; }

        public double Drop { get; set; }

        public double Variation { get; set; }

        public DateTime Date { get; set; }
    }
}