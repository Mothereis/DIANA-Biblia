namespace DIANA_Biblia
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btn_Menu = new System.Windows.Forms.Button();
            this.btn_Voice = new System.Windows.Forms.Button();
            this.btn_Info = new System.Windows.Forms.Button();
            this.btn_Sair = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.btn_alarme = new System.Windows.Forms.Button();
            this.btn_Agenda = new System.Windows.Forms.Button();
            this.Ler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.progressBar1.Location = new System.Drawing.Point(269, 239);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(111, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Minimizado";
            this.notifyIcon1.Visible = true;
            // 
            // btn_Menu
            // 
            this.btn_Menu.BackColor = System.Drawing.Color.Transparent;
            this.btn_Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Menu.BackgroundImage")));
            this.btn_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Menu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Menu.FlatAppearance.BorderSize = 0;
            this.btn_Menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Menu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Menu.Location = new System.Drawing.Point(200, 317);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(50, 28);
            this.btn_Menu.TabIndex = 3;
            this.btn_Menu.Text = "MENU";
            this.btn_Menu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_Menu.UseVisualStyleBackColor = false;
            this.btn_Menu.Click += new System.EventHandler(this.btn_Menu_Click);
            // 
            // btn_Voice
            // 
            this.btn_Voice.BackColor = System.Drawing.Color.Transparent;
            this.btn_Voice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Voice.BackgroundImage")));
            this.btn_Voice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Voice.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Voice.FlatAppearance.BorderSize = 0;
            this.btn_Voice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Voice.Location = new System.Drawing.Point(266, 338);
            this.btn_Voice.Name = "btn_Voice";
            this.btn_Voice.Size = new System.Drawing.Size(50, 28);
            this.btn_Voice.TabIndex = 4;
            this.btn_Voice.Text = "VOICE";
            this.btn_Voice.UseVisualStyleBackColor = false;
            this.btn_Voice.Click += new System.EventHandler(this.btn_Voice_Click);
            // 
            // btn_Info
            // 
            this.btn_Info.BackColor = System.Drawing.Color.Transparent;
            this.btn_Info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Info.BackgroundImage")));
            this.btn_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Info.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Info.FlatAppearance.BorderSize = 0;
            this.btn_Info.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Info.Location = new System.Drawing.Point(330, 338);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(50, 28);
            this.btn_Info.TabIndex = 5;
            this.btn_Info.Text = "INFO";
            this.btn_Info.UseVisualStyleBackColor = false;
            this.btn_Info.Click += new System.EventHandler(this.btn_Info_Click);
            // 
            // btn_Sair
            // 
            this.btn_Sair.BackColor = System.Drawing.Color.Transparent;
            this.btn_Sair.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Sair.BackgroundImage")));
            this.btn_Sair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Sair.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_Sair.FlatAppearance.BorderSize = 0;
            this.btn_Sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Sair.Location = new System.Drawing.Point(397, 317);
            this.btn_Sair.Name = "btn_Sair";
            this.btn_Sair.Size = new System.Drawing.Size(50, 28);
            this.btn_Sair.TabIndex = 6;
            this.btn_Sair.Text = "SAIR";
            this.btn_Sair.UseVisualStyleBackColor = false;
            this.btn_Sair.Click += new System.EventHandler(this.btn_Sair_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // btn_alarme
            // 
            this.btn_alarme.Location = new System.Drawing.Point(153, 228);
            this.btn_alarme.Name = "btn_alarme";
            this.btn_alarme.Size = new System.Drawing.Size(75, 23);
            this.btn_alarme.TabIndex = 7;
            this.btn_alarme.Text = "Alarme";
            this.btn_alarme.UseVisualStyleBackColor = true;
            this.btn_alarme.Click += new System.EventHandler(this.btn_alarme_Click);
            // 
            // btn_Agenda
            // 
            this.btn_Agenda.Location = new System.Drawing.Point(427, 228);
            this.btn_Agenda.Name = "btn_Agenda";
            this.btn_Agenda.Size = new System.Drawing.Size(75, 23);
            this.btn_Agenda.TabIndex = 8;
            this.btn_Agenda.Text = "Agenda";
            this.btn_Agenda.UseVisualStyleBackColor = true;
            this.btn_Agenda.Click += new System.EventHandler(this.btn_Agenda_Click);
            // 
            // Ler
            // 
            this.Ler.Location = new System.Drawing.Point(288, 201);
            this.Ler.Name = "Ler";
            this.Ler.Size = new System.Drawing.Size(75, 23);
            this.Ler.TabIndex = 9;
            this.Ler.Text = "Ler";
            this.Ler.UseVisualStyleBackColor = true;
            this.Ler.Click += new System.EventHandler(this.Ler_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(649, 414);
            this.Controls.Add(this.Ler);
            this.Controls.Add(this.btn_Agenda);
            this.Controls.Add(this.btn_alarme);
            this.Controls.Add(this.btn_Sair);
            this.Controls.Add(this.btn_Info);
            this.Controls.Add(this.btn_Voice);
            this.Controls.Add(this.btn_Menu);
            this.Controls.Add(this.progressBar1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(649, 414);
            this.MinimumSize = new System.Drawing.Size(649, 414);
            this.Name = "TelaPrincipal";
            this.Opacity = 0.9D;
            this.Text = "DIANA_Biblia";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btn_Menu;
        private System.Windows.Forms.Button btn_Voice;
        private System.Windows.Forms.Button btn_Info;
        private System.Windows.Forms.Button btn_Sair;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btn_alarme;
        private System.Windows.Forms.Button btn_Agenda;
        private System.Windows.Forms.Button Ler;
    }
}

