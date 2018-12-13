using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Rate
    {
        public static double[] getSinCosRate(double[,] data)
        {
            double[] results = new double[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                results[i] += Math.Sin(data[i, 0]) * Math.Cos(data[i, 1]);
            }
            return results;
            //Console.WriteLine("sin({0}) * cos({1})= {2}", x.ToString("00"),y.ToString("00"),Math.Sin(x) * Math.Cos(y));
            //return Math.Sin(x) * Math.Cos(y);
        }

        public static double rastriginSum(double n)
        {
            return (Math.Pow(n, 2) - 10 * Math.Cos(2 * Math.PI * n));
        }

        public static double[] getRastriginRate(double[,] data)
        {
            /*
            data[48, 0] = 5; //just for testing purpose
            data[48, 1] = 5;
            data[49, 0] = 0; //just for testing purpose, result about 0 (minimum)
            data[49, 1] = 0;
            */
            double[] results = new double[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                results[i] = 10 * data.GetLength(1);
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    results[i] += rastriginSum(data[i, j]);
                }
                //Console.WriteLine("Rastrigin: " + results[i]);
            }
            return results;
        }

        public static double schwefelSum(double n)
        {
            return n * Math.Sin(Math.Sqrt(Math.Abs(n)));
        }

        public static double[] getSchwefelRate(double[,] data)
        {
            /*
            data[48, 0] = 420.9687; //just for testing purpose, result about 0
            data[48, 1] = 420.9687;
            data[49, 0] = 500; // result about 800
            data[49, 1] = -500;
            */
            double[] results = new double[data.GetLength(0)];
            double[] sum = new double[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    sum[i] += schwefelSum(data[i, j]);
                }
                results[i] = (418.9829 * data.GetLength(1)) - sum[i];
                //Console.WriteLine("Schwefel: " + results[i]);
            }
            return results;
        }

        public static double[] getDeJongRate(double[,] data)
        {
            /*
            data[48, 0] = 0; //just for testing purpose, result about 0
            data[48, 1] = 0;
            data[49, 0] = 10; // result about 200
            data[49, 1] = 10;
            */

            double[] results = new double[data.GetLength(0)];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    results[i] += Math.Pow(data[i, j], 2);
                }
                //Console.WriteLine("De Jong: " + results[i]);
            }
            return results;
        }
    }
}
