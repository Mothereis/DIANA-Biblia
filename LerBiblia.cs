using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIANA_Biblia
{
    class LerBiblia
    {
        public static void Buscar(string expression)
        {
            string[] partes = expression.Split(' ');
            
            string livro = partes[1];
            int capitulo = int.Parse(partes[3]);
            int verciculo = int.Parse(partes[5]);

            Onde(livro, capitulo, verciculo);

        }

            public static void Onde(string Livro, int Capitulo, int Verciculo)
        {
            List<string> cont = new List<string>();
            List<string> verci = new List<string>();
            if (File.Exists(@"Biblia\" + Livro + "\\" + Capitulo.ToString() +".txt"))
            {
                cont.Clear();
                verci.Clear();
                //Speaker.Speak(@"Biblia\" + Livro + @"\" + Capitulo.ToString());
                using (StreamReader reader = new StreamReader("Biblia\\" + Livro +"\\" + Capitulo.ToString() + ".txt", Encoding.Default))
                {
                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine();
                        string[] item = linha.Split('=');
                        cont.Add(item[0]);
                        verci.Add(item[1]);
                    }
                }

                for (int i = 0; i < cont.ToArray().Length; i++)
                {
                    if (cont.Contains(Verciculo.ToString()))
                    {
                        if(cont.ToArray()[i] == Verciculo.ToString())
                            Speaker.Speak(verci.ToArray()[i]);
                    }
                    else
                    {
                        Speaker.Speak("Esse Verciculo não existe");
                    }
                }
            }
        }
    }
}
