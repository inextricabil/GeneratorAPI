using System;
using System.Collections.Generic;
using System.Globalization;

namespace GeneratorAPI.BusinessLayer.Subscription
{
    public class SubscriptionGenerator
    {
        private List<Subscription> _subscriptions;

        private static List<string> _operators { get; set; }

        private NumberOfNulls _maxNulls { get; set; }
        private NumberOfNulls _currentNulls { get; set; }

        private static readonly Random _rnd = new Random();

        public SubscriptionGenerator()
        {
            _operators = new List<string> {"=", "<", "<=", ">", ">="};

        }

        private const string stringOperator = "=";

        public List<Subscription> Generate(SubscriptionConfiguration subscriptionConfiguration, int noOfMessages)
        {
            CalculatePosibleNumbersOfNulls(subscriptionConfiguration);
            _subscriptions = new List<Subscription>();

            for (var i = 0; i < noOfMessages; i++)
            {
                var subscription = new Subscription
                {
                    CompanyName = new Option
                    {
                        Field = "CompanyName",
                        Op = stringOperator,
                        Value = subscriptionConfiguration.CompaniesList[_rnd.Next(subscriptionConfiguration.CompaniesList.Count)]
                    },
                    Value = new Option
                    {
                        Field = "Value",
                        Op = _operators[_rnd.Next(_operators.Count)],
                        Value = GenerateValueDoubleFromRange("Value", subscriptionConfiguration.ValueMin,
                            subscriptionConfiguration.ValueMax).ToString()
                    },
                    Drop = new Option
                    {
                        Field = "Drop",
                        Op = _operators[_rnd.Next(_operators.Count)],
                        Value = GenerateValueDoubleFromRange("Drop", subscriptionConfiguration.DropMin,
                            subscriptionConfiguration.DropMax).ToString()
                    },
                    Variation = new Option
                    {
                        Field = "Variation",
                        Op = _operators[_rnd.Next(_operators.Count)],
                        Value = GenerateValueDoubleFromRange("Variation", subscriptionConfiguration.ValueMin,
                            subscriptionConfiguration.VariationMax).ToString()
                    },
                    Date = new Option
                    {
                        Field = "Date",
                        Op = _operators[_rnd.Next(_operators.Count)],
                        Value = subscriptionConfiguration.DatesList[_rnd.Next(subscriptionConfiguration.DatesList.Count)].ToString("d.MM.yyyy")
                    },
                };

                _subscriptions.Add(subscription);
            }


            return _subscriptions;
        }

        private double? GenerateValueDoubleFromRange(string propertyName, double min, double max)
        {
            var actualNullValue = (int)_currentNulls.GetType().GetProperty(propertyName).GetValue(_currentNulls);
            var maxNullValue = (int)_maxNulls.GetType().GetProperty(propertyName).GetValue(_maxNulls);

            if (actualNullValue >= maxNullValue)
                return RandomDouble(min, max);

            if (_rnd.Next(0, 2) == 0)
                return RandomDouble(min, max);

            _currentNulls.GetType().GetProperty(propertyName).SetValue(_currentNulls, actualNullValue + 1);
            return null;
        }


        private void CalculatePosibleNumbersOfNulls(SubscriptionConfiguration subscriptionConfiguration)
        {
            _maxNulls = new NumberOfNulls
            {
                CompanyName = 
                    subscriptionConfiguration.NumberOfMessages -
                    subscriptionConfiguration.NumberOfMessages * subscriptionConfiguration.CompanyNameFrequency / 100,
                Value = 
                    subscriptionConfiguration.NumberOfMessages -
                    subscriptionConfiguration.NumberOfMessages * subscriptionConfiguration.ValueFrequency / 100,
                Drop = 
                    subscriptionConfiguration.NumberOfMessages -
                    subscriptionConfiguration.NumberOfMessages * subscriptionConfiguration.DropFrequency / 100,
                Variation = subscriptionConfiguration.NumberOfMessages -
                            subscriptionConfiguration.NumberOfMessages * subscriptionConfiguration.VariationFrequency / 100,
                Date = subscriptionConfiguration.NumberOfMessages -
                    subscriptionConfiguration.NumberOfMessages * subscriptionConfiguration.DateFrequency / 100,

            };

            _currentNulls = new NumberOfNulls
            {
                CompanyName = 0,
                Drop = 0,
                Variation = 0,
                Date = 0,
                Value = 0
            };
        }


        private static double RandomDouble(double min, double max)
        {
            return Math.Round(_rnd.NextDouble() * (max - min) + min, 2);
        }
    }
}