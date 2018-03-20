using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Runtime.InteropServices;
using WMPLib;

namespace DIANA_Biblia
{

    public partial class TelaPrincipal : Form
    {

        WindowsMediaPlayer son;
        private static SpeechSynthesizer sp = new SpeechSynthesizer();
        private SelecVoz selectVoz = null;
        private INFO info = null;
        private Alarme alarme = null;
        private Agenda agenda = null;
        private ComandSocial comandsSocial = null;
        private SpeechRecognitionEngine engine;
        int t;
        private bool isDianaListening = true;
        private bool opp = false;
        int X = 0;
        int Y = 0;

        List<string> listaDeAlarmes = new List<string>();
        private bool despertar = true;
        private string horaagora;
        private bool despertou = false;

        public TelaPrincipal()
        {

            InitializeComponent();

            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        private void LoadSpeech()
        {

            try
            {

                engine = new SpeechRecognitionEngine();
                engine.SetInputToDefaultAudioDevice();

                Choices c_number = new Choices();
                Choices c_commandsOfBibliaVerciculo = new Choices();
                Choices c_commandsOfBibliaCapitulo = new Choices();

                for (int i = 0; i <= 100; i++)
                {
                    c_number.Add(i.ToString());
                    c_commandsOfBibliaCapitulo.Add(i.ToString());
                    c_commandsOfBibliaVerciculo.Add(i.ToString());
                }

                Choices c_commandsOfSystem = new Choices();
                c_commandsOfSystem.Add(GrammaRules.WhatTimeIs.ToArray());
                c_commandsOfSystem.Add(GrammaRules.WhatDateIs.ToArray());
                c_commandsOfSystem.Add(GrammaRules.DianaStartListening.ToArray());
                c_commandsOfSystem.Add(GrammaRules.DianaStopListening.ToArray());
                c_commandsOfSystem.Add(GrammaRules.MinimizeWindowns.ToArray());
                c_commandsOfSystem.Add(GrammaRules.NormalizeWindowns.ToArray());
                c_commandsOfSystem.Add(GrammaRules.ChangeVoice.ToArray());
                c_commandsOfSystem.Add(GrammaRules.AtualiziComando.ToArray());
                c_commandsOfSystem.Add(GrammaRules.PossoDesligar.ToArray());
                c_commandsOfSystem.Add(GrammaRules.EnterComand.ToArray());
                c_commandsOfSystem.Add(GrammaRules.MostrarMenu.ToArray());
                c_commandsOfSystem.Add(GrammaRules.Agendar.ToArray());
                c_commandsOfSystem.Add(GrammaRules.MostrarAgenda.ToArray());
                c_commandsOfSystem.Add(GrammaRules.Mostrarcomandos.ToArray());
                
                Choices c_commandsOfBiblia = new Choices();
                c_commandsOfBiblia.Add(GrammaRules.lerVerciculo.ToArray());

                GrammarBuilder gb_commandsOfSystem = new GrammarBuilder();
                gb_commandsOfSystem.Append(c_commandsOfSystem);

                GrammarBuilder gb_commandsOfBiblia = new GrammarBuilder();
                gb_commandsOfBiblia.Append(c_commandsOfBiblia);
                gb_commandsOfBiblia.Append(new Choices(" Capitulo "));
                gb_commandsOfBiblia.Append(c_commandsOfBibliaCapitulo);
                gb_commandsOfBiblia.Append(new Choices(" Versículo "));
                gb_commandsOfBiblia.Append(c_commandsOfBibliaVerciculo);

                Grammar g_commandsOfSystem = new Grammar(gb_commandsOfSystem);
                g_commandsOfSystem.Name = "sys";

                Grammar g_commandsOfBiblia = new Grammar(gb_commandsOfBiblia);
                g_commandsOfBiblia.Name = "Bib";

                GrammarBuilder gb_number = new GrammarBuilder();
                gb_number.Append(c_number);
                gb_number.Append(new Choices("$Vezes$", "$Mais$", "$Dividido por$", "$Menos$", "$Porcento de$"));
                gb_number.Append(c_number);

                Grammar g_number = new Grammar(gb_number);
                g_number.Name = "calc";

                engine.LoadGrammar(g_commandsOfSystem);
                engine.LoadGrammar(g_number);
                engine.LoadGrammar(g_commandsOfBiblia);

                ComandosEditaveis();

                engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec);
                engine.AudioLevelUpdated += new EventHandler<AudioLevelUpdatedEventArgs>(audioLevel);
                engine.SpeechRecognitionRejected += new EventHandler<SpeechRecognitionRejectedEventArgs>(rej);

                engine.RecognizeAsync(RecognizeMode.Multiple);
                VamosDespertr();
                timer1.Start();
                Speaker.Speak("Estou Carregando os Arquivos");

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Ocorreu um erro no LoadSpeech:" + ex.Message);
            }
        }

        private void ComandosEditaveis()
        {
            if (GrammaRules.SocalComands.Count > 0)
            {
                Choices c_commandsOfSociale = new Choices();
                c_commandsOfSociale.Add(GrammaRules.SocalComands.ToArray());

                GrammarBuilder gb_commandsOfSociale = new GrammarBuilder();
                gb_commandsOfSociale.Append(c_commandsOfSociale);

                Grammar g_commandsOfSociale = new Grammar(gb_commandsOfSociale);
                g_commandsOfSociale.Name = "sociComands";

                engine.LoadGrammar(g_commandsOfSociale);
            }

            if (GrammaRules.MemoriaComandosPrograma.Count > 0)
            {
                Choices c_MemoriaComandosPrograma = new Choices();
                c_MemoriaComandosPrograma.Add(GrammaRules.MemoriaComandosPrograma.ToArray());

                GrammarBuilder gb_MemoriaComandosPrograma = new GrammarBuilder();
                gb_MemoriaComandosPrograma.Append(c_MemoriaComandosPrograma);

                Grammar g_ComandosComandosPrograma = new Grammar(gb_MemoriaComandosPrograma);
                g_ComandosComandosPrograma.Name = "programComands";

                engine.LoadGrammar(g_ComandosComandosPrograma);
            }
            if (GrammaRules.MemoriaComandosWeb.Count > 0)
            {
                Choices c_MemoriaComandosWeb = new Choices();
                c_MemoriaComandosWeb.Add(GrammaRules.MemoriaComandosWeb.ToArray());

                GrammarBuilder gb_MemoriaComandosWeb = new GrammarBuilder();
                gb_MemoriaComandosWeb.Append(c_MemoriaComandosWeb);

                Grammar g_ComandosComandosWeb = new Grammar(gb_MemoriaComandosWeb);
                g_ComandosComandosWeb.Name = "WebComand";

                engine.LoadGrammar(g_ComandosComandosWeb);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSpeech();
            
            Speaker.Speak("Arquivos Carregados!");

        }
        private void rec(object s, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            float conf = e.Result.Confidence;

            string Data = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            if (conf > 0.8f)
            {

                if (GrammaRules.DianaStopListening.Any(X => X == speech) && isDianaListening == true)
                {
                    isDianaListening = false;
                    Speaker.Speak("Ficarei aguardando, Quando precisar de mim é só chamar");
                }
                else if (GrammaRules.DianaStartListening.Any(X => X == speech))
                {
                    isDianaListening = true;
                    Speaker.Speak("Etou aqui, em que posso ajudar?");
                }
                else if (GrammaRules.ChangeVoice.Any(X => X == speech))
                {
                    if (selectVoz == null || selectVoz.IsDisposed == true)
                        selectVoz = new SelecVoz();

                    selectVoz.Show();
                }

                if (isDianaListening == true)
                {
                    switch (e.Result.Grammar.Name)
                    {
                        case "sys":

                            if (GrammaRules.WhatTimeIs.Any(X => X == speech))
                            {
                                Runner.WhatTimeIs();
                            }
                            else if (GrammaRules.WhatDateIs.Any(X => X == speech))
                            {
                                Runner.WhatDateIs();
                            }
                            else if (GrammaRules.MinimizeWindowns.Any(X => X == speech))
                            {
                                MinimuizeWindown();
                            }
                            else if (GrammaRules.NormalizeWindowns.Any(X => X == speech))
                            {

                                NormalWindowns();
                            }
                            else if (GrammaRules.AtualiziComando.Any(X => X == speech))
                            {
                                Speaker.Speak("Atualizando Comandos", "Só um momento", "Como Desejar", "Os Comandos serão atualizados");
                                CarregarArquivos();
                                ComandosEditaveis();
                                Speaker.Speak("Os comandos forão atualizados", "Operação realizada com sucesso", "Novo comando adicionado");
                            }
                            else if (GrammaRules.EnterComand.Any(X => X == speech))
                            {
                                if (opp == true)
                                {
                                    Speaker.Speak("OK", "Confirmando");

                                    Thread.Sleep(2000);
                                    this.Close();
                                }

                            }
                            else if (GrammaRules.MostrarMenu.Any(X => X == speech))
                            {
                                if (comandsSocial == null || comandsSocial.IsDisposed == true)
                                    comandsSocial = new ComandSocial();
                                comandsSocial.Show();
                                comandsSocial.TopMost = true;
                            }
                            else if (GrammaRules.PossoDesligar.Any(X => X == speech))
                            {

                                Speaker.Speak("Tem sertesa", "Devo desativar meu sistema", "Você Confirma o desligamento do sistema", "Irei desligar o meu systema");
                                opp = true;
                            }
                            else if (GrammaRules.Agendar.Any(X => X == speech))
                            {


                                if (alarme == null || alarme.IsDisposed == true)
                                    alarme = new Alarme(this);
                                alarme.Show();
                                alarme.TopMost = true;

                            }
                            else if (GrammaRules.MostrarAgenda.Any(X => X == speech))
                            {
                                if (agenda == null || agenda.IsDisposed == true)
                                    agenda = new Agenda();
                                agenda.Show();
                                agenda.TopMost = true;

                            }
                            else if (GrammaRules.Mostrarcomandos.Any(X => X == speech))
                            {
                                if (info == null || info.IsDisposed == true)
                                    info = new INFO();
                                info.Show();
                                info.TopMost = true;

                            }break;

                        case "calc":

                            Speaker.Speak(CalcSolver.Solve(speech));
                            break;

                        case "sociComands":
                            bool contem = GrammaRules.SocalComands.Contains(speech);

                            if (contem == true)
                            {
                                int indce = GrammaRules.SocalComands.IndexOf(speech);
                                Speaker.Speak(GrammaRules.SocalRespostas[indce]);
                            }
                            break;
                        case "programComands":
                            bool contemItem = GrammaRules.MemoriaComandosPrograma.Contains(speech);

                            if (contemItem == true)
                            {
                                int itemIndce = GrammaRules.MemoriaComandosPrograma.IndexOf(speech);
                                Speaker.Speak(GrammaRules.MemoriaRespostasPrograma[itemIndce]);
                                AbrirPrograma.Start(GrammaRules.MemoriaDiretorioPrograma[itemIndce]);
                            }
                            break;
                        case "WebComand":
                            bool contemItemWeb = GrammaRules.MemoriaComandosWeb.Contains(speech);
                            if (contemItemWeb == true)
                            {
                                int itemIndceWeb = GrammaRules.MemoriaComandosWeb.IndexOf(speech);
                                Speaker.Speak(GrammaRules.MemoriaRespostasWeb[itemIndceWeb]);
                                System.Diagnostics.Process.Start(GrammaRules.MemoriaUrl[itemIndceWeb]);
                            }
                            break;

                        case "Bib":

                            LerBiblia.Buscar(speech);

                            break;
                            
                    }
                }
            }

        }

        private void audioLevel(object s, AudioLevelUpdatedEventArgs e)
        {
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = e.AudioLevel;
        }

        private void rej(object s, SpeechRecognitionRejectedEventArgs e)
        {
            //this.label1.BackColor = Color.DarkRed;
            //this.label1.ForeColor = Color.Red;
        }

        private void MinimuizeWindown()
        {
            if (this.WindowState == FormWindowState.Normal || this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Minimized;
                Hide();
                notifyIcon1.Visible = true;

                Speaker.Speak("Minimizando a janela", "Como Quiser", "Tudo Bem");
            }
            else
            {
                Speaker.Speak("Já Está minimizada", "Não estou em sua Frente", "A janela já está minimizada", "Já fiz isso");
            }
        }

        private void NormalWindowns()
        {
            if (this.WindowState == FormWindowState.Minimized || this.WindowState == FormWindowState.Maximized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;

                notifyIcon1.Visible = false;
                Activate();
                Speaker.Speak("Como Quiser", "Como queira", "Estou aqui");
            }
            else
            {
                Speaker.Speak("Já etsou aqui", "Já fiz isso", "Já execultei este comando", "Estou em sua frente");
            }
        }

        public void CarregarArquivos()
        {

            GrammaRules.SocalComands.Clear();
            GrammaRules.SocalRespostas.Clear();
            GrammaRules.MemoriaComandosPrograma.Clear();
            GrammaRules.MemoriaRespostasPrograma.Clear();
            GrammaRules.MemoriaDiretorioPrograma.Clear();
            GrammaRules.MemoriaComandosWeb.Clear();
            GrammaRules.MemoriaRespostasWeb.Clear();
            GrammaRules.MemoriaUrl.Clear();


            if (File.Exists(@"log\ComandsSocial.txt"))
            {
                using (StreamReader reader = new StreamReader(@"log\ComandsSocial.txt", Encoding.UTF8))
                {

                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine();
                        string[] item = linha.Split('&');
                        GrammaRules.SocalComands.Add(item[0]);
                        GrammaRules.SocalRespostas.Add(item[1]);
                    }

                }
            }
            if (File.Exists(@"log\ComandsProgram.txt"))
            {
                using (StreamReader reader = new StreamReader(@"log\ComandsProgram.txt", Encoding.UTF8))
                {

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
            if (File.Exists(@"log\ComandsWeb.txt"))
            {
                using (StreamReader reader = new StreamReader(@"log\ComandsWeb.txt", Encoding.UTF8))
                {

                    while (!reader.EndOfStream)
                    {
                        string linha = reader.ReadLine();
                        string[] item = linha.Split('&');
                        GrammaRules.MemoriaComandosWeb.Add(item[0]);
                        GrammaRules.MemoriaRespostasWeb.Add(item[1]);
                        GrammaRules.MemoriaUrl.Add(item[2]);
                    }

                }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            if (comandsSocial == null || comandsSocial.IsDisposed == true)
                comandsSocial = new ComandSocial();
            comandsSocial.Show();
            comandsSocial.TopMost = true;
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Voice_Click(object sender, EventArgs e)
        {
            if (selectVoz == null || selectVoz.IsDisposed == true)
                selectVoz = new SelecVoz();

            selectVoz.Show();
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            if (info == null || info.IsDisposed == true)
                info = new INFO();

            info.Show();
        }

        public void VamosDespertr()
        {
            listaDeAlarmes.Clear();
            if (File.Exists(@"log\Alarm.ini"))
            {
                List<string> linhas = File.ReadAllLines(@"log\Alarm.ini").ToList();
                if (File.Exists(@"log\Alarm.ini"))
                {
                    using (StreamReader reader = new StreamReader(@"log\Alarm.ini", Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            string doc = reader.ReadLine();
                            listaDeAlarmes.Add(doc);

                        }
                    }
                }
            }
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string[] alarmes = listaDeAlarmes.ToArray();

            if (!despertar && !despertou)
            {
                despertou = true;
                if (MessageBox.Show("Alarme", "Soneca", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    son.controls.stop();
                }
            }
            for (int i = 0; i < alarmes.Length; i++)
            {
                string[] al = alarmes[i].Split('&');
                string[] dataCont = al[1].Split('|');
                List<string> diaCont = new List<string>();
                diaCont.Clear();
                string[] dias = { "Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab" };

                for (int f = 0; f < dataCont.Length; f++)
                {
                    if (dataCont[f] == "True")
                    {
                        diaCont.Add(dias[f]);
                    }
                }


                switch (dataCont.Length)
                {
                    case 3:
                        {
                            //Speaker.Speak("Olá");
                            if (dataCont[0] == DateTime.Now.Day.ToString() && dataCont[1] == DateTime.Now.Month.ToString() && dataCont[2] == DateTime.Now.Year.ToString())
                            {
                                //Speaker.Speak("Olá");
                                string[] horaCont = al[2].Split('|');
                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                {
                                    //Speaker.Speak("Olá");
                                    if (al[4] == "True")
                                    {
                                        //Speaker.Speak("Olá");
                                        if (despertar)
                                        {
                                            try
                                            {

                                                if (son == null)
                                                {
                                                    son = new WindowsMediaPlayer();
                                                    string dir = al[5];
                                                    string[] res = dir.Split('\\');
                                                    string valor = "";

                                                    for (int n = 1; n < res.Length; n++)
                                                    {
                                                        valor += "\\" + res[n];
                                                    }
                                                    son.URL = res[0] + valor;
                                                    son.controls.play();
                                                }
                                                else
                                                {
                                                    son.controls.stop();
                                                    son = new WindowsMediaPlayer();
                                                    string dir = al[5];
                                                    string[] res = dir.Split('\\');
                                                    string valor = "";

                                                    for (int n = 1; n < res.Length; n++)
                                                    {
                                                        valor += "\\" + res[n];
                                                    }
                                                    son.URL = res[0] + valor;
                                                    son.controls.play();
                                                }
                                            }
                                            catch
                                            {
                                                Speaker.Speak("erro de reprodução");

                                            }
                                            despertar = false;
                                        }

                                    }
                                    else
                                    {
                                        Speaker.Speak(al[3]);

                                        timer2.Enabled = true;
                                        horaagora = DateTime.Now.Minute.ToString();
                                        timer1.Enabled = false;
                                    }
                                }
                            }
                        }
                        break;
                    case 7:
                        {

                            if (al[6] == "True")
                            {
                                switch (DateTime.Now.DayOfWeek.ToString())
                                {
                                    case "Sunday":
                                        {
                                            if (diaCont.Contains("Dom"))
                                            {
                                                string[] horaCont = al[2].Split('|');
                                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                                {
                                                    if (al[4] == "True")
                                                    {
                                                        //Speaker.Speak("Olá");
                                                        if (despertar)
                                                        {
                                                            try
                                                            {

                                                                if (son == null)
                                                                {
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                                else
                                                                {
                                                                    son.controls.stop();
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Speaker.Speak("erro de reprodução");

                                                            }
                                                            despertar = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Speaker.Speak(al[3]);

                                                        timer2.Enabled = true;
                                                        horaagora = DateTime.Now.Minute.ToString();
                                                        timer1.Enabled = false;
                                                    }
                                                }
                                            }

                                        }
                                        break;
                                    case "Monday":
                                        {
                                            if (diaCont.Contains("Seg"))
                                            {
                                                string[] horaCont = al[2].Split('|');
                                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                                {
                                                    if (al[4] == "True")
                                                    {
                                                        //Speaker.Speak("Olá");
                                                        if (despertar)
                                                        {
                                                            try
                                                            {

                                                                if (son == null)
                                                                {
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                                else
                                                                {
                                                                    son.controls.stop();
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Speaker.Speak("erro de reprodução");

                                                            }
                                                            despertar = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Speaker.Speak(al[3]);

                                                        timer2.Enabled = true;
                                                        horaagora = DateTime.Now.Minute.ToString();
                                                        timer1.Enabled = false;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Tuesday":
                                        {
                                            if (diaCont.Contains("Ter"))
                                            {
                                                string[] horaCont = al[2].Split('|');
                                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                                {
                                                    if (al[4] == "True")
                                                    {
                                                        //Speaker.Speak("Olá");
                                                        if (despertar)
                                                        {
                                                            try
                                                            {

                                                                if (son == null)
                                                                {
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                                else
                                                                {
                                                                    son.controls.stop();
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Speaker.Speak("erro de reprodução");

                                                            }
                                                            despertar = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Speaker.Speak(al[3]);

                                                        timer2.Enabled = true;
                                                        horaagora = DateTime.Now.Minute.ToString();
                                                        timer1.Enabled = false;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Wednesday":
                                        {
                                            if (diaCont.Contains("Quar"))
                                            {
                                                string[] horaCont = al[2].Split('|');
                                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                                {
                                                    if (al[4] == "True")
                                                    {
                                                        //Speaker.Speak("Olá");
                                                        if (despertar)
                                                        {
                                                            try
                                                            {

                                                                if (son == null)
                                                                {
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                                else
                                                                {
                                                                    son.controls.stop();
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Speaker.Speak("erro de reprodução");

                                                            }
                                                            despertar = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Speaker.Speak(al[3]);

                                                        timer2.Enabled = true;
                                                        horaagora = DateTime.Now.Minute.ToString();
                                                        timer1.Enabled = false;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Thursday":
                                        {
                                            if (diaCont.Contains("Qui"))
                                            {
                                                string[] horaCont = al[2].Split('|');
                                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                                {
                                                    if (al[4] == "True")
                                                    {
                                                        //Speaker.Speak("Olá");
                                                        if (despertar)
                                                        {
                                                            try
                                                            {

                                                                if (son == null)
                                                                {
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                                else
                                                                {
                                                                    son.controls.stop();
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Speaker.Speak("erro de reprodução");

                                                            }
                                                            despertar = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Speaker.Speak(al[3]);

                                                        timer2.Enabled = true;
                                                        horaagora = DateTime.Now.Minute.ToString();
                                                        timer1.Enabled = false;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Friday":
                                        {
                                            if (diaCont.Contains("Sex"))
                                            {
                                                string[] horaCont = al[2].Split('|');
                                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                                {
                                                    if (al[4] == "True")
                                                    {
                                                        //Speaker.Speak("Olá");
                                                        if (despertar)
                                                        {
                                                            try
                                                            {

                                                                if (son == null)
                                                                {
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                                else
                                                                {
                                                                    son.controls.stop();
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Speaker.Speak("erro de reprodução");

                                                            }
                                                            despertar = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Speaker.Speak(al[3]);

                                                        timer2.Enabled = true;
                                                        horaagora = DateTime.Now.Minute.ToString();
                                                        timer1.Enabled = false;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "Saturday":
                                        {
                                            if (diaCont.Contains("Sab"))
                                            {
                                                string[] horaCont = al[2].Split('|');
                                                if (horaCont[0] == DateTime.Now.Hour.ToString() && horaCont[1] == DateTime.Now.Minute.ToString())
                                                {
                                                    if (al[4] == "True")
                                                    {
                                                        //Speaker.Speak("Olá");
                                                        if (despertar)
                                                        {
                                                            try
                                                            {

                                                                if (son == null)
                                                                {
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                                else
                                                                {
                                                                    son.controls.stop();
                                                                    son = new WindowsMediaPlayer();
                                                                    string dir = al[5];
                                                                    string[] res = dir.Split('\\');
                                                                    string valor = "";

                                                                    for (int n = 1; n < res.Length; n++)
                                                                    {
                                                                        valor += "\\" + res[n];
                                                                    }
                                                                    son.URL = res[0] + valor;
                                                                    son.controls.play();
                                                                }
                                                            }
                                                            catch
                                                            {
                                                                Speaker.Speak("erro de reprodução");

                                                            }
                                                            despertar = false;
                                                        }

                                                    }
                                                    else
                                                    {
                                                        Speaker.Speak(al[3]);

                                                        timer2.Enabled = true;
                                                        horaagora = DateTime.Now.Minute.ToString();
                                                        timer1.Enabled = false;
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                }
                            }

                        }
                        break;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (int.Parse(horaagora) + 1 == DateTime.Now.Minute)
            {
                despertar = true;
                timer2.Enabled = false;
                timer1.Enabled = true;
            }
        }

        private void btn_Agenda_Click(object sender, EventArgs e)
        {
            if (agenda == null || agenda.IsDisposed == true)
                agenda = new Agenda();
            agenda.Show();
            agenda.TopMost = true;
        }

        private void btn_alarme_Click(object sender, EventArgs e)
        {

            if (alarme == null || alarme.IsDisposed == true)
                alarme = new Alarme(this);
            alarme.Show();
            alarme.TopMost = true;
        }

        private void Ler_Click(object sender, EventArgs e)
        {
            LerBiblia.Onde("Genesis", 1, 32);
        }
    }


}
