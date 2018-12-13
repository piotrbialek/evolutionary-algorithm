using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Mutation
    {
        private static Random rnd = new Random();

        public double[,] mutate(double[,] data)
        {
            double[,] mutationArray = new double[data.GetLength(0), data.GetLength(1)];
            mutationArray = data;
            double alfa = 2;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                int mutationChance = rnd.Next(0, 100);

                if (mutationChance < alfa)
                {
                    int genMutationChance;
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        
                        genMutationChance = rnd.Next(0, 100);
                        if (genMutationChance < 50)
                        {
                            mutationArray[i, j] = rnd.Next(0, 500);
                        }
                    }
                }
            }
            return mutationArray;
        }
    }
}
