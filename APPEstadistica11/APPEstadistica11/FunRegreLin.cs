using System;


namespace APPEstadistica11
{
    class FunRegreLin
    {
        private double[] SALES;
        public double[] Regresion;

        public FunRegreLin (double[]sales)
        {
            this.SALES = sales;
            Regresion = new double[SALES.Length];
        }
        //promedio trimestral de las ventas
        public double[] VERsales { get => SALES; set => SALES =value; }

        public double[] Regresionlineal()
        {
            int[] TRIMESTERS = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            //double[] Regresion = new double[SALES.Length];
            double[] Pronostico = new double[SALES.Length];

            double[] Iestacional = new double[SALES.Length];
            double[] Desestacionalizar=new double[SALES.Length];
            double totalx = 0;//marca de clase
            double totaly = 0;//total de ventas

            double totalDES = 0;//total de y dessestacionalizada

            double[] XX = new double[SALES.Length];
            double[] XY = new double[SALES.Length];
            double totalXX = 0;//total de ventas XX
            double totalXY = 0;//total de ventas XY

          

            for (int i = 0; i < SALES.Length; i++)
            {
                totaly += SALES[i];
                totalx += TRIMESTERS[i];
            }

            double promedioY =totaly / SALES.Length;//promedio de ventas trimestral
           

            for (int i = 0; i < SALES.Length; i=i+4)
            {
                //                 Promedio trimestrales especifico       iestacional
                Iestacional[i] = ((SALES[0] + SALES[4] + SALES[8]) /3) /promedioY;
                Iestacional[i+1] =((SALES[1] + SALES[5] + SALES[9]) /3) /promedioY;
                Iestacional[i+2] =((SALES[2] + SALES[6] + SALES[10]) /3)/ promedioY;
                Iestacional[i+3] = ((SALES[3] + SALES[7] + SALES[11])/3)/ promedioY;

            } 

            for (int i = 0; i < SALES.Length; i++)
            {
                Desestacionalizar[i] = SALES[i] / Iestacional[i];
                totalDES+=Desestacionalizar[i];//sumatoria de todas la y desestacionalizdas

                // x a la 2    y     XY
                XX[i] = TRIMESTERS[i] * TRIMESTERS[i];
                totalXX += XX[i];
                XY[i] = TRIMESTERS[i] * Desestacionalizar[i];
                totalXY += XY[i];
            }
            //regresion ecuacion a y b
            double a =((totalDES*totalXX)-(totalx*totalXY))/((SALES.Length*totalXX)-(totalx*totalx));
            double b = ((SALES.Length * totalXY)-(totalx*totalDES))/ ((SALES.Length * totalXX) - (totalx * totalx));

            // y =a + b X
            for (int i = 0; i < SALES.Length; i++)
            {
                
                Regresion[i] = a + b * TRIMESTERS[i];
                Pronostico[i] = Regresion[i] * Iestacional[i];
            }

          

            return Pronostico;

            
        }


    }
}
