using SalveAPIRest.Models.recorder;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveAPIRest.Models.classifier.featureExtraction
{
    public class NormedGridExtractor : IFeatureExtractorConstCount
    {

        public Gesture sampleSignal(Gesture signal)
        {
            Gesture s = new GridExtractor().sampleSignal(signal);
            return new NormExtractor().sampleSignal(s);
        }
    }
}