using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIANA_Biblia
{
    public partial class Agenda : Form
    {
        int X = 0;
        int Y = 0;
        private string selected, diasDaSemana;

        public Agenda()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(Agenda_MouseDown);
            this.MouseMove += new MouseEventHandler(Agenda_MouseMove);
            this.listAlarm.View = View.Details;
            this.listAlarm.FullRowSelect = true;

            this.listAlarm.Columns.Add("Titulo", 100);
            this.listAlarm.Columns.Add("Data", 80);
            this.listAlarm.Columns.Add("Hora", 50);
            this.listAlarm.Columns.Add("mensagem", 100);
            this.listAlarm.Columns.Add("Som", 200);

        }
        private void Agenda_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        private void Agenda_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }
        private void Agenda_Load(object sender, EventArgs e)
        {
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
                            string[] item = doc.Split('&');

                            if (item.Length > 0)
                            {
                                string[] datelist = item[1].ToString().Split('|');

                                switch (datelist.Length)
                                {
                                    case 3:
                                        {
                                            item.SetValue(datelist[0] + "/" + datelist[1] + "/" + datelist[2], 1);
                                        }
                                        break;
                                    case 7:
                                        {
                                            diasDaSemana = "";
                                            string[] meusDias = { "Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab" };
                                            List<string> nomesDias = new List<string>();

                                            for (int q = 0; q < datelist.Length; q++)
                                            {
                                                if (datelist[q] == "True")
                                                {

                                                    diasDaSemana += meusDias[q] + ", ";
                                                }
                                            }
                                            item.SetValue(diasDaSemana, 1);
                                        }
                                        break;
                                }

                                string[] horalist = item[2].ToString().Split('|');
                                item.SetValue(horalist[0] + ": " + horalist[1], 2);

                                List<string> lis = item.ToList<string>();
                                lis.RemoveAt(4);



                                string[] com = lis.ToArray();

                                ListViewItem liseContener = new ListViewItem(com);

                                this.listAlarm.Items.Add(liseContener);
                            }
                        }
                    }
                }
            }
        }

        private void Exite_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Delet(string local, string reference)
        {
            string line = null;
            string line_to_delete = selected;

            using (StreamReader reader = new StreamReader(local))
            {
                using (StreamWriter writer = new StreamWriter(reference))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] item = line.Split('&');

                        if (item[0] == line_to_delete)
                            continue;

                        writer.WriteLine(line);
                    }
                }
            }
                this.listAlarm.SelectedItems[0].Remove();

            File.Replace(reference, local, null);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delet(@"log\Alarm.ini", @"log\AlarmBek.ini");
        }

        private void listAlarm_MouseClick(object sender, MouseEventArgs e)
        {
            selected = listAlarm.SelectedItems[0].SubItems[0].Text;
        }
    }
}
