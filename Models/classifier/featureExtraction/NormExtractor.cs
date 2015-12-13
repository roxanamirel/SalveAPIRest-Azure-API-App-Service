using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalveAPIRest.Models.recorder;

namespace SalveAPIRest.Models.classifier.featureExtraction
{
    public class NormExtractor : IFeatureExtractor
    {

        public Gesture sampleSignal(Gesture signal)
        {
            List<float[]> sampledValues = new List<float[]>(signal.length());
            Gesture sampledSignal = new Gesture(sampledValues, signal.label);

            float min = float.MaxValue, max = float.MinValue;
            for (int i = 0; i < signal.length(); i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (signal.getValue(i, j) > max)
                    {
                        max = signal.getValue(i, j);
                    }
                    if (signal.getValue(i, j) < min)
                    {
                        min = signal.getValue(i, j);
                    }
                }
            }
            for (int i = 0; i < signal.length(); ++i)
            {
                sampledValues.Add(new float[3]);
                for (int j = 0; j < 3; ++j)
                {
                    sampledSignal.setValue(i, j, (signal.getValue(i, j) - min) / (max - min));
                }
            }
            return sampledSignal;
        }
    }

}
