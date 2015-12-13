using SalveAPIRest.Models.classifier.featureExtraction;
using SalveAPIRest.Models.preferences;
using SalveAPIRest.Models.recorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveAPIRest.Models.classifier
{
    public class GestureClassifier
    {

        private readonly String TAG = "GestureClassifier";

        protected List<Gesture> trainingSet;
        protected IFeatureExtractor featureExtractor;
        protected String activeTrainingSet = "";


        public GestureClassifier(IFeatureExtractor fE)
        {
            trainingSet = new List<Gesture>();
            featureExtractor = fE;

        }

        public Distribution classifySignal(String trainingSetName, Gesture signal)
        {
            if (trainingSetName == null)
            {
                Console.WriteLine(TAG, "No Training Set Name specified");
                trainingSetName = "default";
            }

            Distribution distribution = new Distribution();
            Gesture sampledSignal = featureExtractor.sampleSignal(signal);

            if (trainingSetName.Equals(SalvePreferences.DEFAULT_GESTURE))
            {
                trainingSet = DefaultGesture.getDefaultValues();
            }

            foreach (Gesture s in trainingSet)
            {
                Console.WriteLine(TAG, s.ToString());
                double dist = DTWAlgorithm.calcDistance(s, sampledSignal);
                distribution.addEntry(s.label, dist);
            }
            if (trainingSet.Any())
            {
                Console.WriteLine(TAG, "No training data for trainingSet %s available.\n", trainingSetName);
            }

            return distribution;
        }

    }


}
