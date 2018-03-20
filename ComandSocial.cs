using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DIANA_Biblia
{
    public partial class ComandSocial : Form
    {
        private string subsText1, subsText2, subsText3, selected, pagina;
        int X = 0;
        int Y = 0;

        public ComandSocial()
        {
            InitializeComponent();
            Tabelaformat();

            this.MouseDown += new MouseEventHandler(commandSocial_MouseDown);
            this.MouseMove += new MouseEventHandler(commandSocial_MouseMove);
        }

        void Tabelaformat()
        {

            list_Comandos.View = View.Details;
            list_Comandos.FullRowSelect = true;

            list_Comandos.Columns.Add("Comando", 320);
            list_Comandos.Columns.Add("Respostas", 320);

            list_ComandProgram.View = View.Details;
            list_ComandProgram.FullRowSelect = true;

            list_ComandProgram.Columns.Add("Comando", 200);
            list_ComandProgram.Columns.Add("Respostas", 200);
            list_ComandProgram.Columns.Add("Diretorio", 200);

            list_ComandoWeb.View = View.Details;
            list_ComandoWeb.FullRowSelect = true;

            list_ComandoWeb.Columns.Add("Comando", 200);
            list_ComandoWeb.Columns.Add("Respostas", 200);
            list_ComandoWeb.Columns.Add("URL", 200);
        }

        private void commandSocial_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void commandSocial_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }


        private void ComandSocial_Load(object sender, EventArgs e)
        {
            //Carrega os arquivos gavados no sistema!
            Carregar("social", @"log\ComandsSocial.txt");
            Carregar("programa", @"log\ComandsProgram.txt");
            Carregar("web", @"log\ComandsWeb.txt");
        }

        //Funçao que adiciona um novo comando
        private void Add(string funcion, string Comando, string Resposta, string programa)
        {
            switch (funcion)
            {
                case "social":
                    {
                        string[] com = { Comando, Resposta };

                        ListViewItem item = new ListViewItem(com);

                        list_Comandos.Items.Add(item);
                    }
                    break;
                case "programa":
                    {
                        string[] com = { Comando, Resposta, programa };

                        ListViewItem item = new ListViewItem(com);

                        list_ComandProgram.Items.Add(item);
                    }
                    break;
                case "web":
                    {
                        string[] com = { Comando, Resposta, programa };

                        ListViewItem item = new ListViewItem(com);

                        list_ComandoWeb.Items.Add(item);
                    }
                    break;
            }

        }

        //Funçao para atualizar um comando especifico na lista
        private void atualise(string function)
        {
            switch (function)
            {

                case "social":
                    list_Comandos.SelectedItems[0].SubItems[0].Text = this.text_Comando.Text;
                    list_Comandos.SelectedItems[0].SubItems[1].Text = this.text_Resposta.Text;

                    regravar("social", subsText1, subsText2, null, this.text_Comando.Text, this.text_Resposta.Text, null);

                    this.text_Comando.Text = "";
                    this.text_Resposta.Text = "";
                    subsText1 = "";
                    subsText2 = "";
                    break;
                case "programa":

                    string dir = this.text_DiretoreProgram.Text;
                    string[] res = dir.Split('\\');
                    string valor = "";

                    for (int i = 1; i < res.Length; i++)
                    {
                        valor += "\\" + res[i];
                    }



                    list_ComandProgram.SelectedItems[0].SubItems[0].Text = this.text_ComandAcesseProgram.Text;
                    list_ComandProgram.SelectedItems[0].SubItems[1].Text = this.text_RespostaCompiuter.Text;
                    list_ComandProgram.SelectedItems[0].SubItems[2].Text = res[0] + valor;

                    regravar("programa", subsText1, subsText2, subsText3, this.text_ComandAcesseProgram.Text, this.text_RespostaCompiuter.Text, res[0] + valor);

                    this.text_ComandAcesseProgram.Text = "";
                    this.text_RespostaCompiuter.Text = "";
                    this.text_DiretoreProgram.Text = "";
                    subsText1 = "";
                    subsText2 = "";
                    subsText3 = "";
                    break;
                case "web":

                    list_ComandoWeb.SelectedItems[0].SubItems[0].Text = this.text_ComandoWeb.Text;
                    list_ComandoWeb.SelectedItems[0].SubItems[1].Text = this.text_RespostaWeb.Text;
                    list_ComandoWeb.SelectedItems[0].SubItems[2].Text = this.text_Url.Text;

                    regravar("web", subsText1, subsText2, subsText3, this.text_ComandoWeb.Text, this.text_RespostaWeb.Text, this.text_Url.Text);

                    this.text_ComandoWeb.Text = "";
                    this.text_RespostaWeb.Text = "";
                    this.text_Url.Text = "";
                    subsText1 = "";
                    subsText2 = "";
                    subsText3 = "";
                    break;
            }

        }

        //Funão que deleta um elemento da lista
        private void Delet(string function, string local, string reference)
        {
            string line = null;
            string line_to_delete = selected;

            using (StreamReader reader = new StreamReader(local))
            {
                using (StreamWriter writer = new StreamWriter(reference))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Compare(line, line_to_delete) == 0)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }


            switch (function)
            {
                case "social":
                    this.list_Comandos.SelectedItems[0].Remove();
                    File.Replace(reference, local, null);
                    this.text_Comando.Text = "";
                    this.text_Resposta.Text = "";
                    break;
                case "programa":
                    this.list_ComandProgram.SelectedItems[0].Remove();
                    File.Replace(reference, local, null);
                    this.text_ComandAcesseProgram.Text = "";
                    this.text_RespostaCompiuter.Text = "";
                    this.text_DiretoreProgram.Text = "";
                    break;
                case "web":
                    this.list_ComandoWeb.SelectedItems[0].Remove();
                    File.Replace(reference, local, null);
                    this.text_ComandoWeb.Text = "";
                    this.text_RespostaWeb.Text = "";
                    this.text_Url.Text = "";
                    break;
            }



            selected = "";
        }

        //Funçaõ eue carrega as informações gravada no sistema!
        private void Carregar(string function, string local)
        {

            switch (function)
            {
                case "social":
                    if (File.Exists(local))
                    {
                        using (StreamReader reader = new StreamReader(local, Encoding.UTF8))
                        {

                            while (!reader.EndOfStream)
                            {
                                string linha = reader.ReadLine();
                                string[] item = linha.Split('&');
                                Add("social", item[0], item[1], null);
                            }
                            //reader.Close();
                        }
                    }
                    break;
                case "programa":
                    if (File.Exists(local))
                    {
                        using (StreamReader reader = new StreamReader(local, Encoding.UTF8))
                        {

                            while (!reader.EndOfStream)
                            {
                                string linha = reader.ReadLine();
                                string[] item = linha.Split('&');
                                Add("programa", item[0], item[1], item[2]);
                            }
                            //reader.Close();
                        }
                    }
                    break;
                case "web":
                    if (File.Exists(local))
                    {
                        using (StreamReader reader = new StreamReader(local, Encoding.UTF8))
                        {

                            while (!reader.EndOfStream)
                            {
                                string linha = reader.ReadLine();
                                string[] item = linha.Split('&');
                                Add("web", item[0], item[1], item[2]);
                            }
                            //reader.Close();
                        }
                    }
                    break;
            }

        }

        //Função que grava os comandos em um arquivo .txt
        public void gravar(string function, string Comando, string Resposta, string Diretrio, string local)
        {
            string log_fileName = local;

            StreamWriter sw = File.AppendText(log_fileName);
            switch (function)
            {

                case "social":
                    if (File.Exists(log_fileName))
                    {
                        sw.WriteLine(Comando + "&" + Resposta);
                    }
                    else
                    {
                        sw.WriteLine(Comando + "&" + Resposta);
                    }
                    break;
                case "programa":
                    if (File.Exists(log_fileName))
                    {
                        sw.WriteLine(Comando + "&" + Resposta + "&" + Diretrio);
                    }
                    else
                    {
                        sw.WriteLine(Comando + "&" + Resposta + "&" + Diretrio);
                    }
                    break;
                case "web":
                    if (File.Exists(log_fileName))
                    {
                        sw.WriteLine(Comando + "&" + Resposta + "&" + Diretrio);
                    }
                    else
                    {
                        sw.WriteLine(Comando + "&" + Resposta + "&" + Diretrio);
                    }
                    break;

            }

            sw.Close();
            Speaker.Speak("Novo Comando adicionado, Diga Atualizar Comandos para concluir o processo!");
        }

        //Botão para sair
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Botão para ADD comando
        private void btn_Add_Click_2(object sender, EventArgs e)
        {
            if (this.text_Comando.Text != "" && this.text_Resposta.Text != "")
            {
                Add("social", this.text_Comando.Text, this.text_Resposta.Text, null);
                gravar("social", this.text_Comando.Text, this.text_Resposta.Text, null, @"log\ComandsSocial.txt");

                this.text_Comando.Text = "";
                this.text_Resposta.Text = "";
            }
        }

        //Botão para atualizar os comandos
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.text_Comando.Text != "" && this.text_Resposta.Text != "")
            {
                atualise("social");
            }
        }

        private void btn_NavegateArquivo_Click(object sender, EventArgs e)
        {
            string filtroTipoArquivo = "arquivos exe (*.exe)|*.exe";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = filtroTipoArquivo;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Pegar o caminho do arquivo que ele criou
                this.text_DiretoreProgram.Text = openFileDialog1.FileName;
            }
        }

        private void btn_AddProgram_Click(object sender, EventArgs e)
        {
            if (this.text_ComandAcesseProgram.Text != "" && this.text_RespostaCompiuter.Text != "" && this.text_DiretoreProgram.Text != "")
            {
                Add("programa", this.text_ComandAcesseProgram.Text, this.text_RespostaCompiuter.Text, this.text_DiretoreProgram.Text);
                gravar("programa", this.text_ComandAcesseProgram.Text, this.text_RespostaCompiuter.Text, this.text_DiretoreProgram.Text, @"log\ComandsProgram.txt");
            }
        }

        //Seleciona para edição o comando clicado
        private void list_Comandos_MouseClick(object sender, MouseEventArgs e)
        {
            this.text_Comando.Text = list_Comandos.SelectedItems[0].SubItems[0].Text;
            this.text_Resposta.Text = list_Comandos.SelectedItems[0].SubItems[1].Text;
            selected = list_Comandos.SelectedItems[0].SubItems[0].Text + "&" +
                       list_Comandos.SelectedItems[0].SubItems[1].Text;

            subsText1 = list_Comandos.SelectedItems[0].SubItems[0].Text;
            subsText2 = list_Comandos.SelectedItems[0].SubItems[1].Text;


        }

        private void list_ComandProgram_MouseClick(object sender, MouseEventArgs e)
        {
            this.text_ComandAcesseProgram.Text = list_ComandProgram.SelectedItems[0].SubItems[0].Text;
            this.text_RespostaCompiuter.Text = list_ComandProgram.SelectedItems[0].SubItems[1].Text;
            this.text_DiretoreProgram.Text = list_ComandProgram.SelectedItems[0].SubItems[2].Text;


            selected = list_ComandProgram.SelectedItems[0].SubItems[0].Text + "&" +
                       list_ComandProgram.SelectedItems[0].SubItems[1].Text + "&" +
                       list_ComandProgram.SelectedItems[0].SubItems[2].Text;

            subsText1 = list_ComandProgram.SelectedItems[0].SubItems[0].Text;
            subsText2 = list_ComandProgram.SelectedItems[0].SubItems[1].Text;
            subsText3 = list_ComandProgram.SelectedItems[0].SubItems[2].Text;


        }

        private void btn_UpdatecomandProgram_Click(object sender, EventArgs e)
        {
            if (this.text_ComandAcesseProgram.Text != "" && this.text_RespostaCompiuter.Text != "" && this.text_DiretoreProgram.Text != "")
            {
                atualise("programa");
            }
        }

        private void btn_DeleteComandWeb_Click(object sender, EventArgs e)
        {
            Delet("web", @"log\ComandsWeb.txt", @"log\ComandsWebReference.txt");
        }

        private void btn_UpdatecomandWeb_Click(object sender, EventArgs e)
        {
            if (this.text_ComandoWeb.Text != "" && this.text_RespostaWeb.Text != "" && this.text_Url.Text != "")
            {
                atualise("web");
            }
        }

        private void list_ComandoWeb_MouseClick(object sender, MouseEventArgs e)
        {
            this.text_ComandoWeb.Text = list_ComandoWeb.SelectedItems[0].SubItems[0].Text;
            this.text_RespostaWeb.Text = list_ComandoWeb.SelectedItems[0].SubItems[1].Text;
            this.text_Url.Text = list_ComandoWeb.SelectedItems[0].SubItems[2].Text;


            selected = list_ComandoWeb.SelectedItems[0].SubItems[0].Text + "&" +
                       list_ComandoWeb.SelectedItems[0].SubItems[1].Text + "&" +
                       list_ComandoWeb.SelectedItems[0].SubItems[2].Text;

            subsText1 = list_ComandoWeb.SelectedItems[0].SubItems[0].Text;
            subsText2 = list_ComandoWeb.SelectedItems[0].SubItems[1].Text;
            subsText3 = list_ComandoWeb.SelectedItems[0].SubItems[2].Text;
        }

        private void tab_social_Click(object sender, EventArgs e)
        {

        }

        private void btn_AddComandWeb_Click(object sender, EventArgs e)
        {
            if (this.text_ComandoWeb.Text != "" && this.text_RespostaWeb.Text != "" && this.text_Url.Text != "")
            {
                Add("web", this.text_ComandoWeb.Text, this.text_RespostaWeb.Text, this.text_Url.Text);
                gravar("web", this.text_ComandoWeb.Text, this.text_RespostaWeb.Text, this.text_Url.Text, @"log\ComandsWeb.txt");

            }
        }

        private void btn_DeleteComandProgram_Click(object sender, EventArgs e)
        {
            Delet("programa", @"log\ComandsProgram.txt", @"log\ComandsProgramReference.txt");
        }

        //Botão para deletar os comandos
        private void button2_Click_1(object sender, EventArgs e)
        {
            Delet("social", @"log\ComandsSocial.txt", @"log\ComandsSocialReference.txt");
        }

        //Fun~ção para atualizar as informações de arquivo txt;
        void regravar(string function, string load1, string load2, string load3, string newLoad1, string newload2, string newload3)
        {
            switch (function)
            {
                case "social":
                    {

                        if (File.Exists(@"log\ComandsSocial.txt"))
                        {
                            //File.Replace()
                            using (StreamReader reader = new StreamReader(@"log\ComandsSocial.txt", Encoding.UTF8))
                            {
                                GrammaRules.MemoriaRespostas.Clear();
                                GrammaRules.MemoriaComandos.Clear();

                                while (!reader.EndOfStream)
                                {
                                    string linha = reader.ReadLine();
                                    string[] item = linha.Split('&');
                                    GrammaRules.MemoriaComandos.Add(item[0]);
                                    GrammaRules.MemoriaRespostas.Add(item[1]);
                                }
                            }
                        }

                        File.Delete(@"log\ComandsSocial.txt");

                        for (int i = 0; i < GrammaRules.MemoriaComandos.Count; i++)
                        {
                            if (GrammaRules.MemoriaComandos[i].ToString() == load1)
                            {
                                GrammaRules.MemoriaComandos.RemoveAt(i);
                                GrammaRules.MemoriaComandos.Insert(i, newLoad1);
                            }
                        }
                        for (int i = 0; i < GrammaRules.MemoriaRespostas.Count; i++)
                        {
                            if (GrammaRules.MemoriaRespostas[i].ToString() == load2)
                            {
                                GrammaRules.MemoriaRespostas.RemoveAt(i);
                                GrammaRules.MemoriaRespostas.Insert(i, newload2);

                            }

                        }

                        for (int i = 0; i < GrammaRules.MemoriaComandos.Count; i++)
                        {
                            gravar("social", GrammaRules.MemoriaComandos[i].ToString(), GrammaRules.MemoriaRespostas[i].ToString(), null, @"log\ComandsSocial.txt");

                        }
                    }
                    break;
                case "programa":
                    {
                        if (File.Exists(@"log\ComandsProgram.txt"))
                        {
                            using (StreamReader reader = new StreamReader(@"log\ComandsProgram.txt", Encoding.UTF8))
                            {
                                GrammaRules.MemoriaRespostasPrograma.Clear();
                                GrammaRules.MemoriaComandosPrograma.Clear();
                                GrammaRules.MemoriaDiretorioPrograma.Clear();
                                while (!reader.EndOfStream)
                                {
                                    string linha = reader.ReadLine();
                                    string[] item = linha.Split('&');
                                    GrammaRules.MemoriaComandosPrograma.Add(item[0]);
                                    GrammaRules.MemoriaRespostasPrograma.Add(item[1]);
                                    string dir = item[2];
                                    string[] res = dir.Split('\\');
                                    string valor = "";

                                    for (int i = 1; i < res.Length; i++)
                                    {
                                        valor += "\\" + res[i];
                                    }
                                    GrammaRules.MemoriaDiretorioPrograma.Add(res[0] + valor);

                                }
                            }
                        }

                        File.Delete(@"log\ComandsProgram.txt");

                        for (int i = 0; i < GrammaRules.MemoriaComandosPrograma.Count; i++)
                        {
                            if (GrammaRules.MemoriaComandosPrograma[i].ToString() == load1)
                            {
                                GrammaRules.MemoriaComandosPrograma.RemoveAt(i);
                                GrammaRules.MemoriaComandosPrograma.Insert(i, newLoad1);
                            }
                        }
                        for (int i = 0; i < GrammaRules.MemoriaRespostasPrograma.Count; i++)
                        {
                            if (GrammaRules.MemoriaRespostasPrograma[i].ToString() == load2)
                            {
                                GrammaRules.MemoriaRespostasPrograma.RemoveAt(i);
                                GrammaRules.MemoriaRespostasPrograma.Insert(i, newload2);

                            }

                        }
                        for (int i = 0; i < GrammaRules.MemoriaDiretorioPrograma.Count; i++)
                        {
                            if (GrammaRules.MemoriaDiretorioPrograma[i].ToString() == load3)
                            {
                                GrammaRules.MemoriaDiretorioPrograma.RemoveAt(i);
                                string dir = newload3;
                                string[] res = dir.Split('\\');
                                string valor = "";

                                for (int j = 1; j < res.Length; j++)
                                {
                                    valor += "\\" + res[j];
                                }
                                GrammaRules.MemoriaDiretorioPrograma.Insert(i, res[0] + valor);

                            }

                        }
                        for (int i = 0; i < GrammaRules.MemoriaComandosPrograma.Count; i++)
                        {
                            gravar("programa", GrammaRules.MemoriaComandosPrograma[i].ToString(), GrammaRules.MemoriaRespostasPrograma[i].ToString(), GrammaRules.MemoriaDiretorioPrograma[i].ToString(), @"log\ComandsProgram.txt");

                        }
                    }
                    break;
                case "web":
                    {
                        if (File.Exists(@"log\ComandsWeb.txt"))
                        {
                            using (StreamReader reader = new StreamReader(@"log\ComandsWeb.txt", Encoding.UTF8))
                            {
                                GrammaRules.MemoriaRespostasWeb.Clear();
                                GrammaRules.MemoriaComandosWeb.Clear();
                                GrammaRules.MemoriaUrl.Clear();
                                while (!reader.EndOfStream)
                                {
                                    string linha = reader.ReadLine();
                                    string[] item = linha.Split('&');
                                    GrammaRules.MemoriaComandosWeb.Add(item[0]);
                                    GrammaRules.MemoriaRespostasWeb.Add(item[1]);
                                    string dir = item[2];
                                    string[] res = dir.Split('\\');
                                    string valor = "";

                                    for (int i = 1; i < res.Length; i++)
                                    {
                                        valor += "\\" + res[i];
                                    }
                                    GrammaRules.MemoriaUrl.Add(res[0] + valor);

                                }
                            }
                        }

                        File.Delete(@"log\ComandsWeb.txt");

                        for (int i = 0; i < GrammaRules.MemoriaComandosWeb.Count; i++)
                        {
                            if (GrammaRules.MemoriaComandosWeb[i].ToString() == load1)
                            {
                                GrammaRules.MemoriaComandosWeb.RemoveAt(i);
                                GrammaRules.MemoriaComandosWeb.Insert(i, newLoad1);
                            }
                        }
                        for (int i = 0; i < GrammaRules.MemoriaRespostasWeb.Count; i++)
                        {
                            if (GrammaRules.MemoriaRespostasWeb[i].ToString() == load2)
                            {
                                GrammaRules.MemoriaRespostasWeb.RemoveAt(i);
                                GrammaRules.MemoriaRespostasWeb.Insert(i, newload2);

                            }

                        }
                        for (int i = 0; i < GrammaRules.MemoriaUrl.Count; i++)
                        {
                            if (GrammaRules.MemoriaUrl[i].ToString() == load3)
                            {
                                GrammaRules.MemoriaUrl.RemoveAt(i);
                                string dir = newload3;
                                string[] res = dir.Split('\\');
                                string valor = "";

                                for (int j = 1; j < res.Length; j++)
                                {
                                    valor += "\\" + res[j];
                                }
                                GrammaRules.MemoriaUrl.Insert(i, res[0] + valor);

                            }

                        }
                        for (int i = 0; i < GrammaRules.MemoriaComandosWeb.Count; i++)
                        {
                            gravar("web", GrammaRules.MemoriaComandosWeb[i].ToString(), GrammaRules.MemoriaRespostasWeb[i].ToString(), GrammaRules.MemoriaUrl[i].ToString(), @"log\ComandsWeb.txt");

                        }
                    }
                    break;
            }
        }
    }
}
