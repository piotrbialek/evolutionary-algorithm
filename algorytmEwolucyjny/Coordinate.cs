using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Coordinate
    {
        public void showCoordinates(int[,] data)
        {
            if (data.GetLength(1) != 2)
            {
                Console.WriteLine(data.GetLength(1));
                throw new ArgumentOutOfRangeException("should only have 2 arguments");
            }
            System.Console.SetBufferSize(120, 120);
            const int a = 100;// Convert.ToInt32(getMax(data)*50)+1;
            int offset = 3;
            int bottomAxisNumberPosition;

            for (int i = 0; i <= a; i++)
            {
                Console.SetCursorPosition(offset, i);
                Console.WriteLine("|");
            }

            Console.SetCursorPosition(0, a + 1);
            for (int i = 0; i <= a; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(offset, 0);
            Console.Write("^");
            Console.SetCursorPosition(a + 1, a + 1);
            Console.Write(">");
            Console.SetCursorPosition(offset, a + offset);
            Console.Write("0");
            Console.SetCursorPosition(0, a + 1);
            Console.Write("0");

            String[] colorNames = ConsoleColor.GetNames(typeof(ConsoleColor));
            int numColors = colorNames.Length;
            Random rand = new Random();

            for (int i = 0; i < data.GetLength(0); i++)
            {
                int x = data[i, 0];
                int y = data[i, 1];
                bottomAxisNumberPosition = a + offset;

                string colorName = colorNames[rand.Next(numColors)];
                ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);

                Console.ForegroundColor = color;

                Console.SetCursorPosition(0, a - y + offset);
                Console.Write(y);
                Console.SetCursorPosition(x, a - y + offset);
                //Console.Write("[" + x + "," + y + "]"); // how it'll be displayed 
                Console.Write("*");

                if (x % 2 == 0)
                {
                    bottomAxisNumberPosition += 1;
                }
                Console.SetCursorPosition(x, bottomAxisNumberPosition);
                Console.Write(x);
            }
        }
    }
}
