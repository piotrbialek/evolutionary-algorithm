using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Crossing
    {
        public double[,] cross(double[,] data)
        {
            double[,] crossingArray = new double[data.GetLength(0), data.GetLength(1)];
            double alfa = 0.3;
            for (int i = 0; i < data.GetLength(0); i = i + 2)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    crossingArray[i, j] = alfa * data[i, j] + (1 - alfa) * data[i + 1, j];
                    crossingArray[i + 1, j] = alfa * data[i + 1, j] + (1 - alfa) * data[i, j];
                }
            }
            return crossingArray;
        }
    }
}
