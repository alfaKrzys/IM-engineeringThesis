﻿namespace IM
{
    partial class d_f_archiwum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(d_f_archiwum));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.f_lb_uzytkownik = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.f_lb_data = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.f_wb_rozmowa = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.f_lb_uzytkownik);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 276);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Użytkownik";
            // 
            // f_lb_uzytkownik
            // 
            this.f_lb_uzytkownik.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.f_lb_uzytkownik.FormattingEnabled = true;
            this.f_lb_uzytkownik.Location = new System.Drawing.Point(7, 16);
            this.f_lb_uzytkownik.Name = "f_lb_uzytkownik";
            this.f_lb_uzytkownik.Size = new System.Drawing.Size(156, 251);
            this.f_lb_uzytkownik.TabIndex = 0;
            this.f_lb_uzytkownik.SelectedIndexChanged += new System.EventHandler(this.f_lb_uzytkownik_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.f_lb_data);
            this.groupBox2.Location = new System.Drawing.Point(189, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(169, 276);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data rozmowy";
            // 
            // f_lb_data
            // 
            this.f_lb_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.f_lb_data.Enabled = false;
            this.f_lb_data.FormattingEnabled = true;
            this.f_lb_data.Location = new System.Drawing.Point(7, 16);
            this.f_lb_data.Name = "f_lb_data";
            this.f_lb_data.Size = new System.Drawing.Size(156, 251);
            this.f_lb_data.TabIndex = 0;
            this.f_lb_data.SelectedIndexChanged += new System.EventHandler(this.f_lb_data_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.f_wb_rozmowa);
            this.groupBox3.Location = new System.Drawing.Point(365, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 276);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rozmowa";
            // 
            // f_wb_rozmowa
            // 
            this.f_wb_rozmowa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.f_wb_rozmowa.IsWebBrowserContextMenuEnabled = false;
            this.f_wb_rozmowa.Location = new System.Drawing.Point(6, 16);
            this.f_wb_rozmowa.MinimumSize = new System.Drawing.Size(20, 20);
            this.f_wb_rozmowa.Name = "f_wb_rozmowa";
            this.f_wb_rozmowa.Size = new System.Drawing.Size(285, 252);
            this.f_wb_rozmowa.TabIndex = 0;
            this.f_wb_rozmowa.Url = new System.Uri("about:blank", System.UriKind.Absolute);
            this.f_wb_rozmowa.WebBrowserShortcutsEnabled = false;
            // 
            // d_f_archiwum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 301);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "d_f_archiwum";
            this.Text = "Archiwum rozmów";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox f_lb_uzytkownik;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox f_lb_data;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.WebBrowser f_wb_rozmowa;
    }
}