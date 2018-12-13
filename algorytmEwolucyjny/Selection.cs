using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorytmEwolucyjny
{
    class Selection
    {
        public int[] tournamentSelection(double[] rates)
        {
            int[] tournament = new int[rates.Length];
            int f, g, h;
            //bool blad = false;

            Random r = new Random();

            for (int k = 0; k < rates.Length; k++)
            {
                f = r.Next(0, rates.Length);
                g = r.Next(0, rates.Length);
                h = r.Next(0, rates.Length);

                /*
                 * without individual repetition (8-10 x slower) !!!!!!!!!!!!!!!!!!!!!!
                do
                {
                    blad = false;

                    Random r2 = new Random();
                    g = r2.Next(0, rates.Length);
                    Random r3 = new Random();
                    h = r3.Next(0, rates.Length);

                    if (f == g || f == h || g == h)
                    {
                        blad = true;
                    }

                } while (blad);

                turniej[k] = f;
                */

                if (rates[g] < rates[f] && rates[g] < rates[h])
                {

                    tournament[k] = g;

                }
                else if (rates[h] < rates[f] && rates[h] < rates[g])
                {
                    tournament[k] = h;
                }
                else
                {
                    tournament[k] = f;
                }

                //Console.WriteLine(k + " osobnik 1: {0}, osobnik 2: {1}, osobnik 3: {2}, zwyciezca: {3}",rates[f], rates[g], rates[h], tournament[k]);
            }
            return tournament;
        }
    }
}
