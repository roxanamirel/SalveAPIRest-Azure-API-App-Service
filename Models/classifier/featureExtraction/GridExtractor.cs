using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalveAPIRest.Models.recorder;

namespace SalveAPIRest.Models.classifier.featureExtraction
{
    public class GridExtractor : IFeatureExtractorConstCount
    {
        readonly static int SAMPLE_STEPS = 32;

        public Gesture sampleSignal(Gesture signal)
        {

            List<float[]> sampledValues = new List<float[]>();
            Gesture sampledSignal = new Gesture(sampledValues, signal.label);
            float findex;

            for (int j = 0; j < SAMPLE_STEPS; ++j)
            {
                sampledValues.Add(new float[3]);
                for (int i = 0; i < 3; ++i)
                {
                    findex = (float)(signal.length() - 1) * j / (SAMPLE_STEPS - 1);
                    float res = findex - (int)findex;
                    sampledSignal.setValue(j, i,
                            (1 - res) * signal.getValue((int)findex, i) + ((int)findex + 1 < signal.length() - 1 ?
                                    res * signal.getValue((int)findex + 1, i) : 0));
                }
            }

            return sampledSignal;
        }


    }

}
