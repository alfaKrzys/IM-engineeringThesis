namespace IM
{
    partial class d_f_klient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(d_f_klient));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.d_sm_polacz = new System.Windows.Forms.ToolStripMenuItem();
            this.d_ms_konfiguracja = new System.Windows.Forms.ToolStripMenuItem();
            this.d_ms_polacz = new System.Windows.Forms.ToolStripMenuItem();
            this.d_ms_rozlacz = new System.Windows.Forms.ToolStripMenuItem();
            this.d_ms_haslo = new System.Windows.Forms.ToolStripMenuItem();
            this.d_ms_archiwum = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.d_ss_status = new System.Windows.Forms.ToolStripStatusLabel();
            this.d_bw_komunikacja = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.d_lb_komunikaty = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.d_lb_uzytkownicy = new System.Windows.Forms.ListBox();
            this.d_t_timer = new System.Windows.Forms.Timer(this.components);
            this.d_ni_tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d_sm_polacz});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(291, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // d_sm_polacz
            // 
            this.d_sm_polacz.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d_ms_konfiguracja,
            this.d_ms_polacz,
            this.d_ms_rozlacz,
            this.d_ms_haslo,
            this.d_ms_archiwum});
            this.d_sm_polacz.Name = "d_sm_polacz";
            this.d_sm_polacz.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.d_sm_polacz.Size = new System.Drawing.Size(50, 20);
            this.d_sm_polacz.Text = "Menu";
            this.d_sm_polacz.ToolTipText = "Łączy z serwerem IM.";
            // 
            // d_ms_konfiguracja
            // 
            this.d_ms_konfiguracja.Name = "d_ms_konfiguracja";
            this.d_ms_konfiguracja.ShortcutKeyDisplayString = "";
            this.d_ms_konfiguracja.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.d_ms_konfiguracja.Size = new System.Drawing.Size(191, 22);
            this.d_ms_konfiguracja.Text = "Konfiguracja...";
            this.d_ms_konfiguracja.ToolTipText = "Koniguruje klienta";
            this.d_ms_konfiguracja.Click += new System.EventHandler(this.d_ms_konfiguracja_Click);
            // 
            // d_ms_polacz
            // 
            this.d_ms_polacz.Name = "d_ms_polacz";
            this.d_ms_polacz.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.d_ms_polacz.Size = new System.Drawing.Size(191, 22);
            this.d_ms_polacz.Text = "Połącz...";
            this.d_ms_polacz.ToolTipText = "Nawiązuje połączenie z serwerem";
            this.d_ms_polacz.Click += new System.EventHandler(this.d_ms_polacz_Click);
            // 
            // d_ms_rozlacz
            // 
            this.d_ms_rozlacz.Enabled = false;
            this.d_ms_rozlacz.Name = "d_ms_rozlacz";
            this.d_ms_rozlacz.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.d_ms_rozlacz.Size = new System.Drawing.Size(191, 22);
            this.d_ms_rozlacz.Text = "Rozłącz";
            this.d_ms_rozlacz.ToolTipText = "Przerywa połączenie z serwerem IM";
            this.d_ms_rozlacz.Click += new System.EventHandler(this.d_ms_rozlacz_Click);
            // 
            // d_ms_haslo
            // 
            this.d_ms_haslo.Enabled = false;
            this.d_ms_haslo.Name = "d_ms_haslo";
            this.d_ms_haslo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.d_ms_haslo.Size = new System.Drawing.Size(191, 22);
            this.d_ms_haslo.Text = "Zmień hasło...";
            this.d_ms_haslo.ToolTipText = "Otwiera okno zmiany hasła";
            this.d_ms_haslo.Click += new System.EventHandler(this.d_ms_haslo_Click);
            // 
            // d_ms_archiwum
            // 
            this.d_ms_archiwum.Enabled = false;
            this.d_ms_archiwum.Name = "d_ms_archiwum";
            this.d_ms_archiwum.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.d_ms_archiwum.Size = new System.Drawing.Size(191, 22);
            this.d_ms_archiwum.Text = "Archiwum...";
            this.d_ms_archiwum.ToolTipText = "Otwiera archiwum rozmów";
            this.d_ms_archiwum.Click += new System.EventHandler(this.d_ms_archiwum_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.d_ss_status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(291, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // d_ss_status
            // 
            this.d_ss_status.Image = global::IM.Properties.Resources.circle_red;
            this.d_ss_status.Name = "d_ss_status";
            this.d_ss_status.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.d_ss_status.Size = new System.Drawing.Size(82, 17);
            this.d_ss_status.Text = "Rozłączony";
            // 
            // d_bw_komunikacja
            // 
            this.d_bw_komunikacja.DoWork += new System.ComponentModel.DoWorkEventHandler(this.d_bw_komunikacja_DoWork);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.d_lb_komunikaty);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Komunikaty";
            // 
            // d_lb_komunikaty
            // 
            this.d_lb_komunikaty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_lb_komunikaty.FormattingEnabled = true;
            this.d_lb_komunikaty.Location = new System.Drawing.Point(7, 20);
            this.d_lb_komunikaty.Name = "d_lb_komunikaty";
            this.d_lb_komunikaty.Size = new System.Drawing.Size(253, 69);
            this.d_lb_komunikaty.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.d_lb_uzytkownicy);
            this.groupBox2.Location = new System.Drawing.Point(13, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 304);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lista użytkowników";
            // 
            // d_lb_uzytkownicy
            // 
            this.d_lb_uzytkownicy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_lb_uzytkownicy.FormattingEnabled = true;
            this.d_lb_uzytkownicy.Location = new System.Drawing.Point(7, 20);
            this.d_lb_uzytkownicy.Name = "d_lb_uzytkownicy";
            this.d_lb_uzytkownicy.Size = new System.Drawing.Size(253, 264);
            this.d_lb_uzytkownicy.TabIndex = 0;
            this.d_lb_uzytkownicy.DoubleClick += new System.EventHandler(this.d_lb_uzytkownicy_DoubleClick);
            // 
            // d_t_timer
            // 
            this.d_t_timer.Interval = 4000;
            this.d_t_timer.Tick += new System.EventHandler(this.d_t_timer_Tick);
            // 
            // d_ni_tray
            // 
            this.d_ni_tray.Icon = ((System.Drawing.Icon)(resources.GetObject("d_ni_tray.Icon")));
            this.d_ni_tray.Text = "IM";
            this.d_ni_tray.Visible = true;
            this.d_ni_tray.DoubleClick += new System.EventHandler(this.d_ni_tray_DoubleClick);
            // 
            // d_f_klient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(245, 410);
            this.Name = "d_f_klient";
            this.Text = "IM";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.d_f_klient_FormClosed);
            this.Resize += new System.EventHandler(this.d_f_klient_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem d_sm_polacz;
        private System.Windows.Forms.ToolStripMenuItem d_ms_konfiguracja;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel d_ss_status;
        private System.Windows.Forms.ToolStripMenuItem d_ms_polacz;
        private System.Windows.Forms.ToolStripMenuItem d_ms_rozlacz;
        private System.ComponentModel.BackgroundWorker d_bw_komunikacja;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox d_lb_komunikaty;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox d_lb_uzytkownicy;
        private System.Windows.Forms.Timer d_t_timer;
        private System.Windows.Forms.ToolStripMenuItem d_ms_haslo;
        private System.Windows.Forms.ToolStripMenuItem d_ms_archiwum;
        private System.Windows.Forms.NotifyIcon d_ni_tray;
    }
}

