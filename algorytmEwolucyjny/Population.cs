using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Population
    {
        private int populationSize;
        private static Random rand = new Random();

        public Population(int size)
        {
            populationSize = size;
        }

        // method responsible for drawing without repetition
        public IEnumerable<int> randomNumbers(int bound)
        {
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < populationSize; i++)
            {
                do
                {
                    number = rand.Next(0, bound);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
            return listNumbers;
        }

        public double[,] createPopulationNoReps(double[,] data)
        {
            double[,] populationArray = new double[populationSize, 2];
            int[] randomArray = randomNumbers(data.GetLength(0)).ToArray();
            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    populationArray[i, j] = data[randomArray[i], j];
                }
            }

            return populationArray;
        }

        public double[,] createPopulation(double[,] data)
        {
            double[,] populationArray = new double[populationSize, 2];
            Random random = new Random();
            for (int i = 0; i < populationSize; i++)
            {
                int r = random.Next(0, populationSize);
                for (int j = 0; j < 2; j++)
                {

                    populationArray[i, j] = data[r, j];

                }
            }
            return populationArray;
        }

        public double[,] createRandomPopulation(int x)
        {
            double[,] populationArray = new double[populationSize, 2];
            Random random = new Random();
            for (int i = 0; i < populationSize; i++)
            {

                for (int j = 0; j < 2; j++)
                {

                    populationArray[i, j] = random.Next(0, x);

                }
            }
            return populationArray;
        }

        public double[,] getSelectedPopulation(int[] ratesIds, double[,] population)
        {
            double[,] selectedPopulation = new double[populationSize, 2];

            for (int i = 0; i < populationSize; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    selectedPopulation[i, j] = population[ratesIds[i], j];
                }
            }
            return selectedPopulation;
        }

        public double[] ratePopulationSinCos(double[,] data)
        {
            return Rate.getSinCosRate(data);
        }

        public double[] ratePopulationRastrigin(double[,] data)
        {
            return Rate.getRastriginRate(data);
        }

        public double[] ratePopulationSchwefel(double[,] data)
        {
            return Rate.getSchwefelRate(data);
        }

        public double[] ratePopulationDeJong(double[,] data)
        {
            return Rate.getDeJongRate(data);
        }

        public double[] ratingPopulation(int choice, double[,] data)
        {
            double[] ratings = new double[data.GetLength(0)];
            switch (choice)
            {
                case 1:
                    ratings = Rate.getDeJongRate(data);
                    break;
                case 2:
                    ratings = Rate.getSchwefelRate(data);
                    break;
                case 3:
                    ratings = Rate.getSinCosRate(data);
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
            return ratings;
        }
    }
}
