using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveAPIRest.Models.recorder
{

    public class Gesture
    {


        public string label { get; set; }
        public List<float[]> values { get; set; }

        public Gesture(List<float[]> values, string label)
        {
            this.label = label;
            this.values = values;
        }



        public float getValue(int index, int dim)
        {
            return values.ElementAt(index)[dim];
        }

        public void setValue(int index, int dim, float f)
        {
            values.ElementAt(index)[dim] = f;

        }

        public int length()
        {
            return values.Count;
        }


        public override string ToString()
        {
            string valuesString = "";
            for (int i = 0; i < values.Count; i++)
            {
                string list = "sensorValues[counter++] = new float[]{";
                for (int j = 0; j < values.ElementAt(i).Length - 1; j++)
                {
                    list += values.ElementAt(i)[j] + "f, ";
                }
                list += values.ElementAt(i)[values.ElementAt(i).Length - 1] + "f};\n";
                valuesString += list;
            }
            return this.label + ": " + " Values = " + valuesString;
        }
    }

}
