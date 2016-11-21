namespace IM
{
    partial class d_f_polacz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(d_f_polacz));
            this.d_tb_login = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.d_tb_haslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.d_b_polacz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // d_tb_login
            // 
            this.d_tb_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_tb_login.Location = new System.Drawing.Point(81, 12);
            this.d_tb_login.Name = "d_tb_login";
            this.d_tb_login.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.d_tb_login.Size = new System.Drawing.Size(120, 20);
            this.d_tb_login.TabIndex = 0;
            this.d_tb_login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_tb_login_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login:";
            // 
            // d_tb_haslo
            // 
            this.d_tb_haslo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_tb_haslo.Location = new System.Drawing.Point(81, 38);
            this.d_tb_haslo.Name = "d_tb_haslo";
            this.d_tb_haslo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.d_tb_haslo.Size = new System.Drawing.Size(120, 20);
            this.d_tb_haslo.TabIndex = 1;
            this.d_tb_haslo.UseSystemPasswordChar = true;
            this.d_tb_haslo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_tb_haslo_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(10, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasło:";
            // 
            // d_b_polacz
            // 
            this.d_b_polacz.Location = new System.Drawing.Point(69, 65);
            this.d_b_polacz.Name = "d_b_polacz";
            this.d_b_polacz.Size = new System.Drawing.Size(75, 23);
            this.d_b_polacz.TabIndex = 2;
            this.d_b_polacz.Text = "Połącz";
            this.d_b_polacz.UseVisualStyleBackColor = true;
            this.d_b_polacz.Click += new System.EventHandler(this.d_b_polacz_Click);
            // 
            // d_f_polacz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 106);
            this.Controls.Add(this.d_b_polacz);
            this.Controls.Add(this.d_tb_haslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.d_tb_login);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(229, 144);
            this.Name = "d_f_polacz";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Połącz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox d_tb_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox d_tb_haslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button d_b_polacz;
    }
}