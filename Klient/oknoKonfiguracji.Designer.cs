namespace IM
{
    partial class d_f_oknoKonfiguracji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(d_f_oknoKonfiguracji));
            this.label2 = new System.Windows.Forms.Label();
            this.d_nud_port = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.d_b_zapisz = new System.Windows.Forms.Button();
            this.d_tb_adresIP = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.d_nud_port)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // d_nud_port
            // 
            this.d_nud_port.Location = new System.Drawing.Point(82, 33);
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
            this.d_nud_port.TabIndex = 1;
            this.toolTip1.SetToolTip(this.d_nud_port, "Wartość całkowita z zakresu od 0 do 65535.");
            this.d_nud_port.Value = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.d_nud_port.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_nud_port_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Adres IP:";
            // 
            // d_b_zapisz
            // 
            this.d_b_zapisz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.d_b_zapisz.Location = new System.Drawing.Point(73, 64);
            this.d_b_zapisz.Name = "d_b_zapisz";
            this.d_b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.d_b_zapisz.TabIndex = 2;
            this.d_b_zapisz.Text = "Zapisz";
            this.toolTip1.SetToolTip(this.d_b_zapisz, "Zapisuje konfigurację.");
            this.d_b_zapisz.UseVisualStyleBackColor = true;
            this.d_b_zapisz.Click += new System.EventHandler(this.d_b_zapisz_Click);
            // 
            // d_tb_adresIP
            // 
            this.d_tb_adresIP.Location = new System.Drawing.Point(82, 9);
            this.d_tb_adresIP.Name = "d_tb_adresIP";
            this.d_tb_adresIP.Size = new System.Drawing.Size(120, 20);
            this.d_tb_adresIP.TabIndex = 0;
            this.d_tb_adresIP.Text = "127.0.0.1";
            this.toolTip1.SetToolTip(this.d_tb_adresIP, "Format adresu np.: 192.168.2.2");
            this.d_tb_adresIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_tb_adresIP_KeyDown);
            this.d_tb_adresIP.Validating += new System.ComponentModel.CancelEventHandler(this.d_tb_adresIP_Validating);
            // 
            // d_f_oknoKonfiguracji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 102);
            this.Controls.Add(this.d_tb_adresIP);
            this.Controls.Add(this.d_b_zapisz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.d_nud_port);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(236, 140);
            this.MinimumSize = new System.Drawing.Size(236, 140);
            this.Name = "d_f_oknoKonfiguracji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Konfiguracja";
            ((System.ComponentModel.ISupportInitialize)(this.d_nud_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown d_nud_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button d_b_zapisz;
        private System.Windows.Forms.TextBox d_tb_adresIP;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}