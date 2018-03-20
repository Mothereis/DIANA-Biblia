using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIANA_Biblia
{
    public class AbrirPrograma
    {
        public static void Start(string url)
        {
            string dir = url;
            string[] res = dir.Split('\\');
            string valor = "";

            for (int i = 1; i < res.Length; i++)
            {
                valor += "\\" + res[i];
            }

            System.Diagnostics.Process.Start(res[0] + valor);
        }
        public static void Starturl(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }

}
