using SalveAPIRest.Models;
using SalveAPIRest.Models.classifier;
using SalveAPIRest.Models.classifier.featureExtraction;
using SalveAPIRest.Models.preferences;
using SalveAPIRest.Models.recorder;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SalveAPIRest.Controllers
{
    [RoutePrefix("api/v1")]
    public class GestureController : ApiController
    {
        [Route("SayMyName")]
        [HttpGet]
        public string echoName()
        {
            return "My name is xx";
        }
        [Route("Post")]
        [HttpPost]
        public void postVoid([FromBody] Human x)
        {
            
            Console.WriteLine(x.Name );
        }
        [Route("RecognizeGesture")]
        [HttpPost]
        public Distribution recognizeGesture([FromBody] List<float[]> values)
        {
            Debug.WriteLine("In method");
            GestureClassifier classifier = new GestureClassifier(new NormedGridExtractor());
            if (values != null)
            {
                Distribution distribution = classifier.classifySignal(SalvePreferences.DEFAULT_GESTURE, new Gesture(values, null));
                if (distribution != null && distribution.size() > 0)
                {
                    Console.WriteLine(string.Format("%s: %f", distribution.best, distribution.minDistance));
                    Console.WriteLine("GESTURE was recognized");

                }
                return distribution;
            }

            return null;
            
        }
        [Route("GetDefaultGesture")]
        [HttpGet]
        public List<float[]> getDefaultGesture()
        {
            DefaultGesture gesture = new DefaultGesture();
            return DefaultGesture.getDefaultValues().ElementAt(0).values;
        }


    }
}
