namespace DIANA_Biblia
{
    partial class Agenda
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
            this.Exite = new System.Windows.Forms.Button();
            this.listAlarm = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Exite
            // 
            this.Exite.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold);
            this.Exite.Location = new System.Drawing.Point(474, 1);
            this.Exite.Name = "Exite";
            this.Exite.Size = new System.Drawing.Size(36, 27);
            this.Exite.TabIndex = 1;
            this.Exite.Text = "X";
            this.Exite.UseVisualStyleBackColor = true;
            this.Exite.Click += new System.EventHandler(this.Exite_Click);
            // 
            // listAlarm
            // 
            this.listAlarm.GridLines = true;
            this.listAlarm.Location = new System.Drawing.Point(12, 34);
            this.listAlarm.Name = "listAlarm";
            this.listAlarm.Size = new System.Drawing.Size(488, 296);
            this.listAlarm.TabIndex = 2;
            this.listAlarm.UseCompatibleStateImageBehavior = false;
            this.listAlarm.View = System.Windows.Forms.View.List;
            this.listAlarm.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listAlarm_MouseClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Agenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 371);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listAlarm);
            this.Controls.Add(this.Exite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Agenda";
            this.Text = "Agenda";
            this.Load += new System.EventHandler(this.Agenda_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Exite;
        private System.Windows.Forms.ListView listAlarm;
        private System.Windows.Forms.Button button2;
    }
}