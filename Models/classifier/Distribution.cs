using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveAPIRest.Models.classifier
{
    public class Distribution
    {
        private readonly Dictionary<string, double> distribution;
        public string best { get; private set; }
        public double minDistance { get; private set; }

        public Distribution()
        {
            distribution = new Dictionary<string, double>();
            minDistance = double.MaxValue;
        }


        public void addEntry(string tag, double distance)
        {
            if (!distribution.ContainsKey(tag) || distance < distribution[tag])
            {
                distribution.Add(tag, distance);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    best = tag;
                }
            }
        }

        public int size()
        {
            return distribution.Count;
        }

    }
}
