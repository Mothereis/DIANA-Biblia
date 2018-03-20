namespace DIANA_Biblia
{
    partial class Alarme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataConteiner = new System.Windows.Forms.DateTimePicker();
            this.HBox = new System.Windows.Forms.ComboBox();
            this.MBox = new System.Windows.Forms.ComboBox();
            this.TituloBox = new System.Windows.Forms.TextBox();
            this.MSGBox = new System.Windows.Forms.TextBox();
            this.ADDButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PodeTocar = new System.Windows.Forms.CheckBox();
            this.AudioBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.DiaSelect = new System.Windows.Forms.CheckedListBox();
            this.podeRepetir = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // DataConteiner
            // 
            this.DataConteiner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataConteiner.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DataConteiner.Location = new System.Drawing.Point(12, 37);
            this.DataConteiner.Name = "DataConteiner";
            this.DataConteiner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DataConteiner.Size = new System.Drawing.Size(114, 26);
            this.DataConteiner.TabIndex = 1;
            // 
            // HBox
            // 
            this.HBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HBox.FormattingEnabled = true;
            this.HBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.HBox.Location = new System.Drawing.Point(132, 39);
            this.HBox.Name = "HBox";
            this.HBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HBox.Size = new System.Drawing.Size(45, 28);
            this.HBox.TabIndex = 2;
            this.HBox.Text = "0";
            // 
            // MBox
            // 
            this.MBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MBox.FormattingEnabled = true;
            this.MBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.MBox.Location = new System.Drawing.Point(205, 39);
            this.MBox.Name = "MBox";
            this.MBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MBox.Size = new System.Drawing.Size(41, 28);
            this.MBox.TabIndex = 3;
            this.MBox.Text = "0";
            // 
            // TituloBox
            // 
            this.TituloBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloBox.Location = new System.Drawing.Point(12, 5);
            this.TituloBox.Name = "TituloBox";
            this.TituloBox.Size = new System.Drawing.Size(325, 26);
            this.TituloBox.TabIndex = 5;
            this.TituloBox.Text = "Sem Titulo";
            // 
            // MSGBox
            // 
            this.MSGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MSGBox.Location = new System.Drawing.Point(103, 73);
            this.MSGBox.MaxLength = 300;
            this.MSGBox.Multiline = true;
            this.MSGBox.Name = "MSGBox";
            this.MSGBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MSGBox.Size = new System.Drawing.Size(237, 67);
            this.MSGBox.TabIndex = 6;
            // 
            // ADDButton
            // 
            this.ADDButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADDButton.Location = new System.Drawing.Point(12, 173);
            this.ADDButton.Name = "ADDButton";
            this.ADDButton.Size = new System.Drawing.Size(114, 35);
            this.ADDButton.TabIndex = 7;
            this.ADDButton.Text = "ADD";
            this.ADDButton.UseVisualStyleBackColor = true;
            this.ADDButton.Click += new System.EventHandler(this.ADDButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(223, 173);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(114, 35);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = ":";
            // 
            // PodeTocar
            // 
            this.PodeTocar.AutoSize = true;
            this.PodeTocar.Location = new System.Drawing.Point(14, 149);
            this.PodeTocar.Name = "PodeTocar";
            this.PodeTocar.Size = new System.Drawing.Size(54, 17);
            this.PodeTocar.TabIndex = 10;
            this.PodeTocar.Text = "Tocar";
            this.PodeTocar.UseVisualStyleBackColor = true;
            // 
            // AudioBox
            // 
            this.AudioBox.Location = new System.Drawing.Point(68, 147);
            this.AudioBox.Name = "AudioBox";
            this.AudioBox.Size = new System.Drawing.Size(228, 20);
            this.AudioBox.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(302, 148);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 20);
            this.button3.TabIndex = 12;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DiaSelect
            // 
            this.DiaSelect.Enabled = false;
            this.DiaSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiaSelect.FormattingEnabled = true;
            this.DiaSelect.Items.AddRange(new object[] {
            "Dom",
            "Seg",
            "Ter",
            "Qua",
            "Qui",
            "Sex",
            "Sab"});
            this.DiaSelect.Location = new System.Drawing.Point(12, 73);
            this.DiaSelect.Name = "DiaSelect";
            this.DiaSelect.Size = new System.Drawing.Size(85, 61);
            this.DiaSelect.TabIndex = 14;
            // 
            // podeRepetir
            // 
            this.podeRepetir.AutoSize = true;
            this.podeRepetir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.podeRepetir.Location = new System.Drawing.Point(260, 41);
            this.podeRepetir.Name = "podeRepetir";
            this.podeRepetir.Size = new System.Drawing.Size(80, 24);
            this.podeRepetir.TabIndex = 15;
            this.podeRepetir.Text = "Repetir";
            this.podeRepetir.UseVisualStyleBackColor = true;
            this.podeRepetir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.podeRepetir_MouseClick);
            // 
            // Alarme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 216);
            this.Controls.Add(this.podeRepetir);
            this.Controls.Add(this.DiaSelect);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AudioBox);
            this.Controls.Add(this.PodeTocar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ADDButton);
            this.Controls.Add(this.MSGBox);
            this.Controls.Add(this.TituloBox);
            this.Controls.Add(this.MBox);
            this.Controls.Add(this.HBox);
            this.Controls.Add(this.DataConteiner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alarme";
            this.Opacity = 0.95D;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Alarme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DataConteiner;
        private System.Windows.Forms.ComboBox HBox;
        private System.Windows.Forms.ComboBox MBox;
        private System.Windows.Forms.TextBox TituloBox;
        private System.Windows.Forms.TextBox MSGBox;
        private System.Windows.Forms.Button ADDButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox PodeTocar;
        private System.Windows.Forms.TextBox AudioBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox DiaSelect;
        private System.Windows.Forms.CheckBox podeRepetir;
    }
}