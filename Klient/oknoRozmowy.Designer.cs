namespace IM
{
    partial class oknoRozmowy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(oknoRozmowy));
            this.f_italic = new System.Windows.Forms.Button();
            this.f_bold = new System.Windows.Forms.Button();
            this.f_b_wyslij = new System.Windows.Forms.Button();
            this.f_tb_wiadomosc = new System.Windows.Forms.TextBox();
            this.f_wb_oknorozmowy = new System.Windows.Forms.WebBrowser();
            this.d_ofd_wyslijPlik = new System.Windows.Forms.OpenFileDialog();
            this.d_ll_wyslijPlik = new System.Windows.Forms.LinkLabel();
            this.d_l_odbierz = new System.Windows.Forms.Label();
            this.d_ll_tak = new System.Windows.Forms.LinkLabel();
            this.d_ll_nie = new System.Windows.Forms.LinkLabel();
            this.d_sfd_zapiszPlik = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // f_italic
            // 
            this.f_italic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_italic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.f_italic.Location = new System.Drawing.Point(52, 225);
            this.f_italic.Name = "f_italic";
            this.f_italic.Size = new System.Drawing.Size(30, 23);
            this.f_italic.TabIndex = 19;
            this.f_italic.Text = "I";
            this.f_italic.UseVisualStyleBackColor = true;
            this.f_italic.Click += new System.EventHandler(this.f_italic_Click);
            // 
            // f_bold
            // 
            this.f_bold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.f_bold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.f_bold.Location = new System.Drawing.Point(16, 225);
            this.f_bold.Name = "f_bold";
            this.f_bold.Size = new System.Drawing.Size(30, 23);
            this.f_bold.TabIndex = 18;
            this.f_bold.Text = "B";
            this.f_bold.UseVisualStyleBackColor = true;
            this.f_bold.Click += new System.EventHandler(this.f_bold_Click);
            // 
            // f_b_wyslij
            // 
            this.f_b_wyslij.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.f_b_wyslij.Location = new System.Drawing.Point(106, 310);
            this.f_b_wyslij.Name = "f_b_wyslij";
            this.f_b_wyslij.Size = new System.Drawing.Size(75, 23);
            this.f_b_wyslij.TabIndex = 17;
            this.f_b_wyslij.Text = "Wyślij";
            this.f_b_wyslij.UseVisualStyleBackColor = true;
            this.f_b_wyslij.Click += new System.EventHandler(this.f_b_wyslij_Click);
            // 
            // f_tb_wiadomosc
            // 
            this.f_tb_wiadomosc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_tb_wiadomosc.Location = new System.Drawing.Point(12, 254);
            this.f_tb_wiadomosc.Multiline = true;
            this.f_tb_wiadomosc.Name = "f_tb_wiadomosc";
            this.f_tb_wiadomosc.Size = new System.Drawing.Size(269, 50);
            this.f_tb_wiadomosc.TabIndex = 15;
            this.f_tb_wiadomosc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.f_tb_wiadomosc_KeyDown);
            this.f_tb_wiadomosc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.f_tb_wiadomosc_KeyUp);
            this.f_tb_wiadomosc.MouseUp += new System.Windows.Forms.MouseEventHandler(this.f_tb_wiadomosc_MouseUp);
            // 
            // f_wb_oknorozmowy
            // 
            this.f_wb_oknorozmowy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_wb_oknorozmowy.IsWebBrowserContextMenuEnabled = false;
            this.f_wb_oknorozmowy.Location = new System.Drawing.Point(12, 12);
            this.f_wb_oknorozmowy.MinimumSize = new System.Drawing.Size(20, 20);
            this.f_wb_oknorozmowy.Name = "f_wb_oknorozmowy";
            this.f_wb_oknorozmowy.Size = new System.Drawing.Size(269, 207);
            this.f_wb_oknorozmowy.TabIndex = 16;
            this.f_wb_oknorozmowy.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.f_wb_oknorozmowy.WebBrowserShortcutsEnabled = false;
            // 
            // d_ofd_wyslijPlik
            // 
            this.d_ofd_wyslijPlik.Title = "Wybierz plik do wysłania";
            // 
            // d_ll_wyslijPlik
            // 
            this.d_ll_wyslijPlik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_ll_wyslijPlik.AutoSize = true;
            this.d_ll_wyslijPlik.Location = new System.Drawing.Point(89, 235);
            this.d_ll_wyslijPlik.Name = "d_ll_wyslijPlik";
            this.d_ll_wyslijPlik.Size = new System.Drawing.Size(62, 13);
            this.d_ll_wyslijPlik.TabIndex = 20;
            this.d_ll_wyslijPlik.TabStop = true;
            this.d_ll_wyslijPlik.Text = "Wyślij plik...";
            this.d_ll_wyslijPlik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.d_ll_wyslijPlik_LinkClicked);
            // 
            // d_l_odbierz
            // 
            this.d_l_odbierz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_l_odbierz.AutoSize = true;
            this.d_l_odbierz.Enabled = false;
            this.d_l_odbierz.Location = new System.Drawing.Point(158, 235);
            this.d_l_odbierz.Name = "d_l_odbierz";
            this.d_l_odbierz.Size = new System.Drawing.Size(46, 13);
            this.d_l_odbierz.TabIndex = 21;
            this.d_l_odbierz.Text = "Odbierz:";
            // 
            // d_ll_tak
            // 
            this.d_ll_tak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_ll_tak.AutoSize = true;
            this.d_ll_tak.Enabled = false;
            this.d_ll_tak.Location = new System.Drawing.Point(211, 235);
            this.d_ll_tak.Name = "d_ll_tak";
            this.d_ll_tak.Size = new System.Drawing.Size(28, 13);
            this.d_ll_tak.TabIndex = 22;
            this.d_ll_tak.TabStop = true;
            this.d_ll_tak.Text = "TAK";
            this.d_ll_tak.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.d_ll_tak_LinkClicked);
            // 
            // d_ll_nie
            // 
            this.d_ll_nie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_ll_nie.AutoSize = true;
            this.d_ll_nie.Enabled = false;
            this.d_ll_nie.Location = new System.Drawing.Point(246, 235);
            this.d_ll_nie.Name = "d_ll_nie";
            this.d_ll_nie.Size = new System.Drawing.Size(25, 13);
            this.d_ll_nie.TabIndex = 23;
            this.d_ll_nie.TabStop = true;
            this.d_ll_nie.Text = "NIE";
            this.d_ll_nie.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.d_ll_nie_LinkClicked);
            // 
            // oknoRozmowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 340);
            this.Controls.Add(this.d_ll_nie);
            this.Controls.Add(this.d_ll_tak);
            this.Controls.Add(this.d_l_odbierz);
            this.Controls.Add(this.d_ll_wyslijPlik);
            this.Controls.Add(this.f_italic);
            this.Controls.Add(this.f_bold);
            this.Controls.Add(this.f_b_wyslij);
            this.Controls.Add(this.f_tb_wiadomosc);
            this.Controls.Add(this.f_wb_oknorozmowy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "oknoRozmowy";
            this.Text = "oknoRozmowy";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.oknoRozmowy_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button f_italic;
        private System.Windows.Forms.Button f_bold;
        public System.Windows.Forms.Button f_b_wyslij;
        public System.Windows.Forms.TextBox f_tb_wiadomosc;
        public System.Windows.Forms.WebBrowser f_wb_oknorozmowy;
        private System.Windows.Forms.OpenFileDialog d_ofd_wyslijPlik;
        public System.Windows.Forms.Label d_l_odbierz;
        public System.Windows.Forms.LinkLabel d_ll_tak;
        public System.Windows.Forms.LinkLabel d_ll_nie;
        private System.Windows.Forms.SaveFileDialog d_sfd_zapiszPlik;
        public System.Windows.Forms.LinkLabel d_ll_wyslijPlik;
    }
}