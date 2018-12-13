using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Program
    {
        static int populationSize = 50;
        private static Random rand = new Random();

        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew(); // time counter

            //--------------------------------- getting data from external file and parsing it 
            Data d = new Data();
            string[] lines = d.getData();
            double[,] array = d.getParsedData(lines);
            //d.showData(array);

            //--------------------------------- creating start population 
            Population p = new Population(populationSize);

            // ---creating population from data from external file
            double[,] population = p.createPopulation(array);
            //double[,] population = p.createPopulationNoReps(array);




            Console.WriteLine("Choose function:\n1.     De Jong function\n2.     Schwefel function\n3.     sin(x1) * cos(x2) function");
            int userChoice = Int32.Parse(Console.ReadLine());
            string choosenFunction = "";
            switch (userChoice)
            {
                case 1:
                    choosenFunction = "De Jong function";
                    break;
                case 2:
                    choosenFunction = "Schwefel function";
                    break;
                case 3:
                    choosenFunction = "sin(x1) * cos(x2) function";
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
            Console.WriteLine("Function: "+choosenFunction);
            // ---creating random population
            //double[,] population = p.createRandomPopulation(50);

            double[] rates;// = p.ratingPopulation(userChoice, population);
            double avg,min;


            var csv = new StringBuilder();

            Console.WriteLine("           Iteration                 Avg                 Min");
            // -------------------------------------------------------------------------------------------------------------------- LOOP START
            for (int i = 0; i < 1000000; i++)
            {
                //double[] rates = p.ratePopulationDeJong(population); // range [500,500]
                //double[] rates = p.ratePopulationSchwefel(population); // range [500,500]
                //double[] rates = p.ratePopulationSinCos(population);

                rates = p.ratingPopulation(userChoice, population);

                if (i % 50000 == 0)
                {
                    avg=Math.Round(rates.Average());
                    min = Math.Round(rates.Min(),2);
                    //min = rates.Min();
                    //d.saveData(rates);
                    Console.WriteLine("{0,20}{1,20}{2,20}", i, avg, min);
                    //d.showData(population);
                    //d.showResults(rates);

                    var minResult = min.ToString();
                    var newLine = String.Format("{0}", minResult);
                    csv.AppendLine(newLine);
                }

                //--------------------------------- selection
                Selection s = new Selection();
                int[] selection = s.tournamentSelection(rates);

                double[,] selectedPopulation = p.getSelectedPopulation(selection, population);

                //--------------------------------- crossing
                Crossing c = new Crossing();
                double[,] crossed = c.cross(selectedPopulation);

                //--------------------------------- mutation
                Mutation m = new Mutation();
                double[,] mutated = m.mutate(crossed);

                //--------------------------------- succession

                /* 
                 50% z wynikowej
                 50% ze startowej
                 */
                double[,] succession = new double[populationSize,2];

                for (int j = 0; j < (populationSize / 2); j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        succession[j, k] = selectedPopulation[rand.Next(0, populationSize), k];
                    }
                }

                for (int j = (populationSize / 2); j < populationSize; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        succession[j, k] = mutated[rand.Next(0, populationSize), k];
                    }
                }

                population = mutated;
            }
            // -------------------------------------------------------------------------------------------------------------------- LOOP END


            //-------------------------------- saving data to external file
            //d.saveData(results);

            string filePath = @"C:\Users\Professional\Documents\STUDIA PIOTREK\Informatyka\II Stopień\Semestr 3\Systemy uczące się\aaa.csv";
            //System.IO.File.WriteAllText(filePath, string.Empty);
            File.WriteAllText(filePath, csv.ToString());
            //File.AppendAllText(filePath, csv.ToString());
            //Console.WriteLine();
            //Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>> Final population <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
            //Console.WriteLine();
            //d.showDataRounded(population);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            //Console.SetCursorPosition(50,0);
            Console.WriteLine("Execution time in miliseconds: " + elapsedMs);
            Console.WriteLine("Execution time in seconds: " + elapsedMs/1000);
            Console.ReadKey();
        }
    }
}
