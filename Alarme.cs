using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace DIANA_Biblia
{
    public partial class Alarme : Form
    {

        int X = 0;
        int Y = 0;
        bool podeAdd, repetir;
        WindowsMediaPlayer son;
        private string titulo, data, hora, Resposta, tocar, sonPlay, repetirAlarme;


        public Alarme(TelaPrincipal form)
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Alarm_MouseDown);
            this.MouseMove += new MouseEventHandler(Alarm_MouseMove);
            this.HBox.Text = DateTime.Now.Hour.ToString();
            this.MBox.Text = DateTime.Now.Minute.ToString();

        }

        private void Alarme_Load(object sender, EventArgs e)
        {

        }

        private void podeRepetir_MouseClick(object sender, MouseEventArgs e)
        {
            this.DiaSelect.Enabled = !this.DiaSelect.Enabled;
            repetir = this.DiaSelect.Enabled;
            this.DataConteiner.Enabled = this.DiaSelect.Enabled;
        }

        private void Alarm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void Alarm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            if (son != null)
            {
                son.controls.stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filtroTipoArquivo = "arquivos de audio (*.mp3)|*.mp3";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = filtroTipoArquivo;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Pegar o caminho do arquivo que ele criou
                this.AudioBox.Text = openFileDialog1.FileName;
                try
                {


                    if (son == null)
                    {
                        son = new WindowsMediaPlayer();
                        string dir = this.AudioBox.Text;
                        string[] res = dir.Split('\\');
                        string valor = "";

                        for (int i = 1; i < res.Length; i++)
                        {
                            valor += "\\" + res[i];
                        }
                        son.URL = res[0] + valor;
                        son.controls.play();
                    }
                    else
                    {
                        son.controls.stop();
                        son = new WindowsMediaPlayer();
                        string dir = this.AudioBox.Text;
                        string[] res = dir.Split('\\');
                        string valor = "";

                        for (int i = 1; i < res.Length; i++)
                        {
                            valor += "\\" + res[i];
                        }
                        son.URL = res[0] + valor;
                        son.controls.play();
                    }
                }
                catch { Speaker.Speak("erro de reprodução"); }

            }
        }

        private void ADDButton_Click(object sender, EventArgs e)
        {
            if (this.PodeTocar.Checked)
            {

                son.controls.stop();
                if (this.TituloBox.Text != "" && this.MSGBox.Text != "" && this.AudioBox.Text != "")
                {
                    podeAdd = true;
                    List<string> itemSelect = new List<string>();

                    titulo = this.TituloBox.Text;

                    if (!repetir)
                    {

                        data = this.DataConteiner.Value.Day.ToString() + "|" +
                               this.DataConteiner.Value.Month.ToString() + "|" +
                               this.DataConteiner.Value.Year.ToString();
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            if (i != 6)
                                data += this.DiaSelect.GetItemChecked(i).ToString() + "|";
                            if (i == 6)
                                data += this.DiaSelect.GetItemChecked(i).ToString();
                        }


                    }
                    hora = this.HBox.SelectedItem.ToString() + "|" + this.MBox.SelectedItem.ToString();
                    Resposta = this.MSGBox.Text;
                    sonPlay = this.AudioBox.Text;
                    tocar = this.PodeTocar.Checked.ToString();


                    string comando = titulo + "&" + data + "&" + hora + "&" + Resposta + "&" + tocar + "&" + sonPlay + "&" + repetirAlarme;



                    List<string> linhas = File.ReadAllLines(@"log\Alarm.ini").ToList();
                    if (File.Exists(@"log\Alarm.ini"))
                    {
                        using (StreamReader reader = new StreamReader(@"log\Alarm.ini", Encoding.UTF8))
                        {

                            while (!reader.EndOfStream)
                            {
                                string doc = reader.ReadLine();
                                string[] item = doc.Split('&');

                                if (item[0] == titulo)
                                {
                                    podeAdd = false;
                                    Speaker.Speak("Já existe um alarme com esse nome");
                                }
                            }
                        }

                        if (podeAdd)
                        {
                            linhas.Add(comando);
                            File.WriteAllLines(@"log\Alarm.ini", linhas);
                        }
                    }

                    this.Close();
                }
                else if (this.TituloBox.Text == "" || this.MSGBox.Text == "" || this.AudioBox.Text == "")
                {
                    Speaker.Speak("Complete todos os campos para que eu possa ser mais eficiente em te lemprar de seu compromiço");
                }
            }
            else
            {

                if (this.TituloBox.Text != "" && this.MSGBox.Text != "")
                {
                    podeAdd = true;
                    List<string> itemSelect = new List<string>();

                    titulo = this.TituloBox.Text;

                    if (!repetir)
                    {

                        data = this.DataConteiner.Value.Day.ToString() + "|" +
                               this.DataConteiner.Value.Month.ToString() + "|" +
                               this.DataConteiner.Value.Year.ToString();
                    }
                    else
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            if (i != 6)
                                data += this.DiaSelect.GetItemChecked(i).ToString() + "|";
                            if (i == 6)
                                data += this.DiaSelect.GetItemChecked(i).ToString();
                        }


                    }
                    hora = this.HBox.SelectedItem.ToString() + "|" + this.MBox.SelectedItem.ToString();
                    Resposta = this.MSGBox.Text;
                    sonPlay = "false";
                    tocar = this.PodeTocar.Checked.ToString();
                    repetirAlarme = this.podeRepetir.Checked.ToString();


                    string comando = titulo + "&" + data + "&" + hora + "&" + Resposta + "&" + tocar + "&" + sonPlay + "&" + repetirAlarme;



                    if (File.Exists(@"log\Alarm.ini"))
                    {
                        List<string> linhas = File.ReadAllLines(@"log\Alarm.ini").ToList();

                        using (StreamReader reader = new StreamReader(@"log\Alarm.ini", Encoding.UTF8))
                        {

                            while (!reader.EndOfStream)
                            {
                                string doc = reader.ReadLine();
                                string[] item = doc.Split('&');

                                if (item[0] == titulo)
                                {
                                    podeAdd = false;
                                    Speaker.Speak("Já existe um alarme com esse nome");
                                }
                            }
                        }

                        if (podeAdd)
                        {
                            linhas.Add(comando);
                            File.WriteAllLines(@"log\Alarm.ini", linhas);
                            this.Close();
                        }
                    }


                }
                else if (this.TituloBox.Text == "" || this.MSGBox.Text == "")
                {
                    Speaker.Speak("Complete todos os campos para que eu possa ser mais eficiente em te lemprar de seu compromiço");
                }
            }
            TelaPrincipal form = new TelaPrincipal();
            form.VamosDespertr();
        }


    }
}
