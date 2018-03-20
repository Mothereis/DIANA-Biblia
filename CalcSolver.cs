using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIANA_Biblia
{
    public class CalcSolver
    {
        public static string Solve(string expression)
        {
            string[] partes = expression.Split('$');

            double X = double.Parse(partes[0]);
            double Y = double.Parse(partes[2]);
            double z = 0.0f;

            switch (partes[1])
            {
                case "Mais":

                    z = X + Y;

                    break;

                case "Menos":

                    z = X - Y;

                    break;

                case "Dividido por":

                    z = X / Y;

                    break;

                case "Vezes":

                    z = X * Y;

                    break;

                case "Porcento de":

                    z = (X * Y) / 100;

                    break;


            }
            return z.ToString();
        }
    }
}
