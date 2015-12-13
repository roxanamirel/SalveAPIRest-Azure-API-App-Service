using SalveAPIRest.Models.recorder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalveAPIRest.Models.classifier
{
    public class DTWAlgorithm
    {

        static double OFFSET_PENALTY = .5f;

        static private double pnorm(List<double> vector, int p)
        {
            double result = 0, sum;
            foreach (double b in vector)
            {
                sum = 1;
                for (int i = 0; i < p; ++i)
                {
                    sum *= b;
                }
                result += sum;
            }
            return (double)Math.Pow(result, 1.0 / p);
        }

        static public double calcDistance(Gesture a, Gesture b)
        {
            int signalDimensions = a.values.ElementAt(0).Length;
            int signal1Length = a.length();
            int signal2Length = b.length();

            // initialize matrices
            double[][] distMatrix;
            double[][] costMatrix;

            distMatrix = new double[signal1Length][];
            costMatrix = new double[signal1Length][];

            for (int i = 0; i < signal1Length; ++i)
            {
                distMatrix[i] = new double[signal2Length];
                costMatrix[i] = new double[signal2Length];
            }

            List<double> vec;

            // calculate distances
            for (int i = 0; i < signal1Length; ++i)
            {
                for (int j = 0; j < signal2Length; ++j)
                {
                    vec = new List<double>();
                    for (int k = 0; k < signalDimensions; ++k)
                    {
                        vec.Add((double)(a.getValue(i, k) - b.getValue(j, k)));
                    }
                    distMatrix[i][j] = pnorm(vec, 2);
                }
            }

            for (int i = 0; i < signal1Length; ++i)
            {
                costMatrix[i][0] = distMatrix[i][0];
            }

            for (int j = 1; j < signal2Length; ++j)
            {
                for (int i = 0; i < signal1Length; ++i)
                {
                    if (i == 0)
                    {
                        costMatrix[i][j] = costMatrix[i][j - 1] + distMatrix[i][j];
                    }
                    else
                    {
                        double minCost, cost;
                        // i-1, j-1
                        minCost = costMatrix[i - 1][j - 1] + distMatrix[i][j];
                        // i-1, j
                        if ((cost = costMatrix[i - 1][j] + distMatrix[i][j]) < minCost)
                        {
                            minCost = cost + OFFSET_PENALTY;
                        }
                        // i, j-1
                        if ((cost = costMatrix[i][j - 1] + distMatrix[i][j]) < minCost)
                        {
                            minCost = cost + OFFSET_PENALTY;
                        }
                        costMatrix[i][j] = minCost;
                    }
                }
            }
            return costMatrix[signal1Length - 1][signal2Length - 1];
        }

    }

}
