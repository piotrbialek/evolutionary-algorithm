using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Data
    {
        // getting data from external .txt file
        public string[] getData()
        {
            return System.IO.File.ReadAllLines(@"C:\Users\Professional\Documents\STUDIA PIOTREK\Informatyka\II Stopień\Semestr 3\Systemy uczące się\ecoli.data.txt");
        }

        public void saveData(int [] data)
        {
            string[] lines = data.Select(x=>x.ToString()).ToArray();
            System.IO.File.WriteAllLines(@"C:\Users\Professional\Documents\STUDIA PIOTREK\Informatyka\II Stopień\Semestr 3\Systemy uczące się\result.txt", lines);
            System.IO.File.AppendAllText(@"C:\Users\Professional\Documents\STUDIA PIOTREK\Informatyka\II Stopień\Semestr 3\Systemy uczące się\result.txt", "-----" + Environment.NewLine);
            Console.WriteLine("Data saved succesfully");
        }

        public void saveData(double[] data)
        {
            string[] lines = data.Select(x => x.ToString()).ToArray();
            System.IO.File.WriteAllLines(@"C:\Users\Professional\Documents\STUDIA PIOTREK\Informatyka\II Stopień\Semestr 3\Systemy uczące się\result.txt", lines);
            System.IO.File.AppendAllText(@"C:\Users\Professional\Documents\STUDIA PIOTREK\Informatyka\II Stopień\Semestr 3\Systemy uczące się\result.txt", "-----" + Environment.NewLine);
            //Console.WriteLine("Data saved succesfully");
        }

        public double[,] parseData(string[] data)
        {
            double[,] parsedData = new double[data.GetLength(0), getPreparedRow(data, 0).Length];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                var row = getPreparedRow(data, i);

                for (int j = 0; j < getPreparedRow(data, 0).Length; j++)
                {
                    //Console.WriteLine(row[j]);
                    parsedData[i, j] = double.Parse(
                        row[j],
                        System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo
                        );
                }

            }
            return parsedData;
        }

        public double[,] getParsedData(string[] data)
        {
            double[,] integerArray = new double[data.GetLength(0), 2];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                var row = getPreparedRow(data, i);
                for (int j = 0; j < 2; j++)
                {
                    integerArray[i, j] = 
                        //Convert.ToInt32(
                        double.Parse(
                        row[j],
                        System.Globalization.NumberStyles.AllowDecimalPoint,
                        System.Globalization.NumberFormatInfo.InvariantInfo)
                        *100
                        //)
            ;
                }
            }
            return integerArray;
        }

        public string[] getPreparedRow(string[] dataToPrepare, int row)
        {
            var fields = dataToPrepare[row].Split(' ');
            fields = fields.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            fields = fields.Skip(1).ToArray();
            fields = fields.Take(fields.Count() - 1).ToArray();
            return fields;
        }

        // method responsible for displaying data
        public void showData(double[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                Console.Write(i.ToString("D2")+" --> ");
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    //Console.Write(data[i, j].ToString("F") + " "); // #.## format of data
                    Console.Write(data[i, j]+" ");
                }
                Console.WriteLine();
            }
        }

        public void showDataRounded(double[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                Console.Write(i.ToString("D2") + " --> ");
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    //Console.Write(data[i, j].ToString("F") + " "); // #.## format of data
                    Console.Write(Math.Round(data[i, j],2) + " ");
                }
                Console.WriteLine();
            }
        }

        public void showResults(double[] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                //Console.WriteLine(i.ToString("D2") + " = " + data[i].ToString("F") + " "); // #.## format of data
                Console.WriteLine(i.ToString("D2") + " = " + data[i]+" ");
            }
        }
    }
}
