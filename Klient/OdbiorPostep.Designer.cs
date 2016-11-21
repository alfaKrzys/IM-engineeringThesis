namespace IM
{
    partial class d_f_postepPobierania
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(d_f_postepPobierania));
            this.d_pb_postep = new System.Windows.Forms.ProgressBar();
            this.d_l_plik = new System.Windows.Forms.Label();
            this.d_bw_odbieraj = new System.ComponentModel.BackgroundWorker();
            this.d_bw_wysylaj = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // d_pb_postep
            // 
            this.d_pb_postep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_pb_postep.Location = new System.Drawing.Point(12, 12);
            this.d_pb_postep.Name = "d_pb_postep";
            this.d_pb_postep.Size = new System.Drawing.Size(236, 23);
            this.d_pb_postep.TabIndex = 0;
            // 
            // d_l_plik
            // 
            this.d_l_plik.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.d_l_plik.AutoSize = true;
            this.d_l_plik.Location = new System.Drawing.Point(113, 42);
            this.d_l_plik.Name = "d_l_plik";
            this.d_l_plik.Size = new System.Drawing.Size(40, 13);
            this.d_l_plik.TabIndex = 1;
            this.d_l_plik.Text = "Postęp";
            // 
            // d_bw_odbieraj
            // 
            this.d_bw_odbieraj.WorkerSupportsCancellation = true;
            this.d_bw_odbieraj.DoWork += new System.ComponentModel.DoWorkEventHandler(this.d_bw_odbieraj_DoWork);
            // 
            // d_bw_wysylaj
            // 
            this.d_bw_wysylaj.WorkerSupportsCancellation = true;
            this.d_bw_wysylaj.DoWork += new System.ComponentModel.DoWorkEventHandler(this.d_bw_wysylaj_DoWork);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // d_f_postepPobierania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 81);
            this.Controls.Add(this.d_l_plik);
            this.Controls.Add(this.d_pb_postep);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "d_f_postepPobierania";
            this.Text = "Postęp pobierania pliku";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.d_f_postepPobierania_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar d_pb_postep;
        private System.Windows.Forms.Label d_l_plik;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker d_bw_odbieraj;
        private System.ComponentModel.BackgroundWorker d_bw_wysylaj;
    }
}