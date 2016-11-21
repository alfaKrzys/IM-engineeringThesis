namespace IM
{
    partial class d_f_serwer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(d_f_serwer));
            this.d_b_stop = new System.Windows.Forms.Button();
            this.d_wb_oknorozmowy = new System.Windows.Forms.WebBrowser();
            this.d_lb_listauzytk = new System.Windows.Forms.ListBox();
            this.d_b_start = new System.Windows.Forms.Button();
            this.d_b_wyslij = new System.Windows.Forms.Button();
            this.d_lb_komunikaty = new System.Windows.Forms.ListBox();
            this.d_tb_wyslij = new System.Windows.Forms.TextBox();
            this.d_nud_port = new System.Windows.Forms.NumericUpDown();
            this.d_b_usun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.d_ll_nie = new System.Windows.Forms.LinkLabel();
            this.d_ll_tak = new System.Windows.Forms.LinkLabel();
            this.d_l_odbierz = new System.Windows.Forms.Label();
            this.d_ll_wyslijPlik = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.d_cb_adresIP = new System.Windows.Forms.ComboBox();
            this.d_bw_polaczenia = new System.ComponentModel.BackgroundWorker();
            this.d_bw_statusPol = new System.ComponentModel.BackgroundWorker();
            this.f_ms_menu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d_tsm_zarzadzaj = new System.Windows.Forms.ToolStripMenuItem();
            this.d_ofd_wyslijPlik = new System.Windows.Forms.OpenFileDialog();
            this.d_sfd_zapiszPlik = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.d_nud_port)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.f_ms_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // d_b_stop
            // 
            this.d_b_stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_b_stop.Location = new System.Drawing.Point(170, 164);
            this.d_b_stop.Name = "d_b_stop";
            this.d_b_stop.Size = new System.Drawing.Size(75, 23);
            this.d_b_stop.TabIndex = 1;
            this.d_b_stop.Text = "Stop";
            this.d_b_stop.UseVisualStyleBackColor = true;
            this.d_b_stop.Click += new System.EventHandler(this.d_b_stop_Click);
            // 
            // d_wb_oknorozmowy
            // 
            this.d_wb_oknorozmowy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_wb_oknorozmowy.IsWebBrowserContextMenuEnabled = false;
            this.d_wb_oknorozmowy.Location = new System.Drawing.Point(271, 36);
            this.d_wb_oknorozmowy.MinimumSize = new System.Drawing.Size(20, 20);
            this.d_wb_oknorozmowy.Name = "d_wb_oknorozmowy";
            this.d_wb_oknorozmowy.Size = new System.Drawing.Size(365, 357);
            this.d_wb_oknorozmowy.TabIndex = 9;
            this.d_wb_oknorozmowy.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.d_wb_oknorozmowy.WebBrowserShortcutsEnabled = false;
            // 
            // d_lb_listauzytk
            // 
            this.d_lb_listauzytk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_lb_listauzytk.FormattingEnabled = true;
            this.d_lb_listauzytk.Location = new System.Drawing.Point(7, 20);
            this.d_lb_listauzytk.Name = "d_lb_listauzytk";
            this.d_lb_listauzytk.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.d_lb_listauzytk.Size = new System.Drawing.Size(237, 95);
            this.d_lb_listauzytk.Sorted = true;
            this.d_lb_listauzytk.TabIndex = 1;
            // 
            // d_b_start
            // 
            this.d_b_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_b_start.Location = new System.Drawing.Point(7, 164);
            this.d_b_start.Name = "d_b_start";
            this.d_b_start.Size = new System.Drawing.Size(75, 23);
            this.d_b_start.TabIndex = 0;
            this.d_b_start.Text = "Start";
            this.d_b_start.UseVisualStyleBackColor = true;
            this.d_b_start.Click += new System.EventHandler(this.d_b_start_Click);
            // 
            // d_b_wyslij
            // 
            this.d_b_wyslij.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.d_b_wyslij.Location = new System.Drawing.Point(561, 400);
            this.d_b_wyslij.Name = "d_b_wyslij";
            this.d_b_wyslij.Size = new System.Drawing.Size(75, 23);
            this.d_b_wyslij.TabIndex = 8;
            this.d_b_wyslij.Text = "Wyślij";
            this.d_b_wyslij.UseVisualStyleBackColor = true;
            this.d_b_wyslij.Click += new System.EventHandler(this.d_b_wyslij_Click);
            // 
            // d_lb_komunikaty
            // 
            this.d_lb_komunikaty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_lb_komunikaty.FormattingEnabled = true;
            this.d_lb_komunikaty.Location = new System.Drawing.Point(7, 75);
            this.d_lb_komunikaty.Name = "d_lb_komunikaty";
            this.d_lb_komunikaty.Size = new System.Drawing.Size(237, 82);
            this.d_lb_komunikaty.TabIndex = 4;
            // 
            // d_tb_wyslij
            // 
            this.d_tb_wyslij.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_tb_wyslij.Location = new System.Drawing.Point(13, 400);
            this.d_tb_wyslij.Name = "d_tb_wyslij";
            this.d_tb_wyslij.Size = new System.Drawing.Size(542, 20);
            this.d_tb_wyslij.TabIndex = 7;
            this.d_tb_wyslij.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_tb_wyslij_KeyDown);
            // 
            // d_nud_port
            // 
            this.d_nud_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_nud_port.Location = new System.Drawing.Point(124, 48);
            this.d_nud_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.d_nud_port.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.d_nud_port.Name = "d_nud_port";
            this.d_nud_port.Size = new System.Drawing.Size(120, 20);
            this.d_nud_port.TabIndex = 3;
            this.d_nud_port.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            // 
            // d_b_usun
            // 
            this.d_b_usun.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.d_b_usun.Location = new System.Drawing.Point(194, 121);
            this.d_b_usun.Name = "d_b_usun";
            this.d_b_usun.Size = new System.Drawing.Size(50, 23);
            this.d_b_usun.TabIndex = 0;
            this.d_b_usun.Text = "Usuń";
            this.d_b_usun.UseVisualStyleBackColor = true;
            this.d_b_usun.Click += new System.EventHandler(this.d_b_usun_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(53, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.d_ll_nie);
            this.groupBox2.Controls.Add(this.d_ll_tak);
            this.groupBox2.Controls.Add(this.d_l_odbierz);
            this.groupBox2.Controls.Add(this.d_ll_wyslijPlik);
            this.groupBox2.Controls.Add(this.d_b_usun);
            this.groupBox2.Controls.Add(this.d_lb_listauzytk);
            this.groupBox2.Location = new System.Drawing.Point(13, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 161);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista użytkowników";
            // 
            // d_ll_nie
            // 
            this.d_ll_nie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_ll_nie.AutoSize = true;
            this.d_ll_nie.Enabled = false;
            this.d_ll_nie.Location = new System.Drawing.Point(161, 126);
            this.d_ll_nie.Name = "d_ll_nie";
            this.d_ll_nie.Size = new System.Drawing.Size(25, 13);
            this.d_ll_nie.TabIndex = 27;
            this.d_ll_nie.TabStop = true;
            this.d_ll_nie.Text = "NIE";
            this.d_ll_nie.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.d_ll_nie_LinkClicked);
            // 
            // d_ll_tak
            // 
            this.d_ll_tak.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_ll_tak.AutoSize = true;
            this.d_ll_tak.Enabled = false;
            this.d_ll_tak.Location = new System.Drawing.Point(127, 126);
            this.d_ll_tak.Name = "d_ll_tak";
            this.d_ll_tak.Size = new System.Drawing.Size(28, 13);
            this.d_ll_tak.TabIndex = 26;
            this.d_ll_tak.TabStop = true;
            this.d_ll_tak.Text = "TAK";
            this.d_ll_tak.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.d_ll_tak_LinkClicked);
            // 
            // d_l_odbierz
            // 
            this.d_l_odbierz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_l_odbierz.AutoSize = true;
            this.d_l_odbierz.Enabled = false;
            this.d_l_odbierz.Location = new System.Drawing.Point(75, 126);
            this.d_l_odbierz.Name = "d_l_odbierz";
            this.d_l_odbierz.Size = new System.Drawing.Size(46, 13);
            this.d_l_odbierz.TabIndex = 25;
            this.d_l_odbierz.Text = "Odbierz:";
            // 
            // d_ll_wyslijPlik
            // 
            this.d_ll_wyslijPlik.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_ll_wyslijPlik.AutoSize = true;
            this.d_ll_wyslijPlik.Location = new System.Drawing.Point(7, 126);
            this.d_ll_wyslijPlik.Name = "d_ll_wyslijPlik";
            this.d_ll_wyslijPlik.Size = new System.Drawing.Size(62, 13);
            this.d_ll_wyslijPlik.TabIndex = 24;
            this.d_ll_wyslijPlik.TabStop = true;
            this.d_ll_wyslijPlik.Text = "Wyślij plik...";
            this.d_ll_wyslijPlik.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.d_ll_wyslijPlik_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.d_b_stop);
            this.groupBox1.Controls.Add(this.d_b_start);
            this.groupBox1.Controls.Add(this.d_lb_komunikaty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.d_nud_port);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.d_cb_adresIP);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 196);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Panel administracyjny";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(53, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Adres IP:";
            // 
            // d_cb_adresIP
            // 
            this.d_cb_adresIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_cb_adresIP.FormattingEnabled = true;
            this.d_cb_adresIP.Location = new System.Drawing.Point(124, 20);
            this.d_cb_adresIP.Name = "d_cb_adresIP";
            this.d_cb_adresIP.Size = new System.Drawing.Size(121, 21);
            this.d_cb_adresIP.TabIndex = 2;
            this.d_cb_adresIP.Text = "127.0.0.1";
            // 
            // d_bw_polaczenia
            // 
            this.d_bw_polaczenia.WorkerSupportsCancellation = true;
            this.d_bw_polaczenia.DoWork += new System.ComponentModel.DoWorkEventHandler(this.d_bw_polaczenia_DoWork);
            // 
            // d_bw_statusPol
            // 
            this.d_bw_statusPol.WorkerSupportsCancellation = true;
            this.d_bw_statusPol.DoWork += new System.ComponentModel.DoWorkEventHandler(this.d_bw_statusPol_DoWork);
            // 
            // f_ms_menu
            // 
            this.f_ms_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.f_ms_menu.Location = new System.Drawing.Point(0, 0);
            this.f_ms_menu.Name = "f_ms_menu";
            this.f_ms_menu.Size = new System.Drawing.Size(648, 24);
            this.f_ms_menu.TabIndex = 10;
            this.f_ms_menu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d_tsm_zarzadzaj});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.menuToolStripMenuItem.Text = "Użytkownicy";
            // 
            // d_tsm_zarzadzaj
            // 
            this.d_tsm_zarzadzaj.Name = "d_tsm_zarzadzaj";
            this.d_tsm_zarzadzaj.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.d_tsm_zarzadzaj.Size = new System.Drawing.Size(173, 22);
            this.d_tsm_zarzadzaj.Text = "Zarządzaj...";
            this.d_tsm_zarzadzaj.ToolTipText = "Dodaj i usuń użytkowników";
            this.d_tsm_zarzadzaj.Click += new System.EventHandler(this.d_tsm_zarzadzaj_Click);
            // 
            // d_ofd_wyslijPlik
            // 
            this.d_ofd_wyslijPlik.Title = "Wybierz plik do wysłania";
            // 
            // d_f_serwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 432);
            this.Controls.Add(this.d_wb_oknorozmowy);
            this.Controls.Add(this.d_b_wyslij);
            this.Controls.Add(this.d_tb_wyslij);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.f_ms_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.f_ms_menu;
            this.MinimumSize = new System.Drawing.Size(664, 451);
            this.Name = "d_f_serwer";
            this.Text = "Serwer IM";
            ((System.ComponentModel.ISupportInitialize)(this.d_nud_port)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.f_ms_menu.ResumeLayout(false);
            this.f_ms_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button d_b_stop;
        private System.Windows.Forms.ListBox d_lb_listauzytk;
        private System.Windows.Forms.Button d_b_start;
        private System.Windows.Forms.Button d_b_wyslij;
        private System.Windows.Forms.ListBox d_lb_komunikaty;
        private System.Windows.Forms.TextBox d_tb_wyslij;
        private System.Windows.Forms.Button d_b_usun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker d_bw_polaczenia;
        private System.ComponentModel.BackgroundWorker d_bw_statusPol;
        private System.Windows.Forms.MenuStrip f_ms_menu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d_tsm_zarzadzaj;
        public System.Windows.Forms.LinkLabel d_ll_nie;
        public System.Windows.Forms.LinkLabel d_ll_tak;
        public System.Windows.Forms.Label d_l_odbierz;
        private System.Windows.Forms.LinkLabel d_ll_wyslijPlik;
        private System.Windows.Forms.OpenFileDialog d_ofd_wyslijPlik;
        public System.Windows.Forms.NumericUpDown d_nud_port;
        public System.Windows.Forms.WebBrowser d_wb_oknorozmowy;
        private System.Windows.Forms.SaveFileDialog d_sfd_zapiszPlik;
        public System.Windows.Forms.ComboBox d_cb_adresIP;
    }
}

