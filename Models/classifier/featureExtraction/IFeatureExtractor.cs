using SalveAPIRest.Models.recorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveAPIRest.Models.classifier.featureExtraction
{
    public interface IFeatureExtractor
    {
         Gesture sampleSignal(Gesture signal);
    }
}
