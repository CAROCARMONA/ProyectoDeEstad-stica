using System;

namespace APPEstadistica11
{
    class Program
    {

        static void Main(string[] args)
        {
            double[] SalesXthree = { 600, 1550, 1500, 1500, 2400, 3100, 2600, 2900, 3800, 4500, 4000, 4900 };
            FunRegreLin f = new FunRegreLin(SalesXthree);

            double[] PRO = f.Regresionlineal();
            
            for (int i = 0; i < SalesXthree.Length; i++)
            {
                //opcional quitar la parte decimal
                Console.WriteLine("Pronostico " +Math.Round( PRO[i]) + " trimestre " +(i+1));
                Console.WriteLine("regre" + f.Regresion[i]);
                Console.WriteLine("ventas" + f.VERsales[i]);
            }
            
           

        }
    }
}
