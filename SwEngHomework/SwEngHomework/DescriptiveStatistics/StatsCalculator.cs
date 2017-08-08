using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwEngHomework.DescriptiveStatistics
{
    public class StatsCalculator : IStatsCalculator
    {
        public Stats Calculate(string semicolonDelimitedContributions)
        {
            if (string.IsNullOrWhiteSpace(semicolonDelimitedContributions))
                return new Stats();

            var cleanInput = new StringBuilder(semicolonDelimitedContributions)
                .Replace("$", string.Empty)
                .Replace(" ", string.Empty)
                .ToString();

            var contributions = cleanInput.Split(';');

            if (contributions.Length < 1)
                return new Stats();

            var decimalContributions = new List<double>();

            foreach(var contribution in contributions)
            {
                if (double.TryParse(contribution, out double result))
                    decimalContributions.Add(result);
            }

            if (decimalContributions.Count() < 1)
                return new Stats();

            return new Stats(decimalContributions);
        }
    }
}
