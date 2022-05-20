using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPEstadistica11
{
    class Program
    {

        static void Main(string[] args)
        {
            double[] SalesXthree = { 600, 1550, 1500, 1500, 2400, 3100, 2600, 2900, 3800, 4500, 4000, 4900 };

            int[] Trimesters = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            FunRegreLin f = new FunRegreLin(SalesXthree, Trimesters);

            double[] PRO = f.Regresionlineal();
            Console.Write("Pronostico");
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine("Pronostico" +Math.Round( PRO[i]) + " mes" + Trimesters[i]);

            }


        }
    }
}
