using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveAPIRest.Models.classifier.featureExtraction
{
    public interface IFeatureExtractorConstCount : IFeatureExtractor
    {
        // this interface should be used for FeatureExtractor which always deliver a
        // fix number of sampled values
    };
}
