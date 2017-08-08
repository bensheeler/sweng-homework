using System;
using System.Collections.Generic;
using System.Linq;

namespace SwEngHomework.DescriptiveStatistics
{
    public class Stats
    {
        public double Average { get; set; }
        public double Median { get; set; }
        public double Range { get; set; }

        public Stats() { }

        public Stats(IEnumerable<double> dataSet)
        {
            Average = Math.Round(dataSet.Average(), 2, MidpointRounding.AwayFromZero);
            Median = Math.Round(CalculateMedian(dataSet), 2, MidpointRounding.AwayFromZero);
            Range = Math.Round(dataSet.Max() - dataSet.Min(), 2, MidpointRounding.AwayFromZero);
        }

        private double CalculateMedian(IEnumerable<double> dataSet)
        {
            var orderedDataSet = dataSet.OrderBy(i => i);
            var count = orderedDataSet.Count();
            var halfIndex = count / 2;

            if (orderedDataSet.Count() % 2 == 0)
            {
                return (orderedDataSet.ElementAt(halfIndex) 
                    + orderedDataSet.ElementAt(halfIndex - 1)) 
                    / 2;
            }

            return orderedDataSet.ElementAt(halfIndex);
        }
    }
}
