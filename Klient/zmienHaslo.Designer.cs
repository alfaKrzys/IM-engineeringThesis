namespace IM
{
    partial class zmienHaslo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(zmienHaslo));
            this.d_b_zmien = new System.Windows.Forms.Button();
            this.d_tb_noweHaslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.d_tb_strHaslo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.d_tb_noweHaslo2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // d_b_zmien
            // 
            this.d_b_zmien.Location = new System.Drawing.Point(83, 90);
            this.d_b_zmien.MaximumSize = new System.Drawing.Size(75, 23);
            this.d_b_zmien.MinimumSize = new System.Drawing.Size(75, 23);
            this.d_b_zmien.Name = "d_b_zmien";
            this.d_b_zmien.Size = new System.Drawing.Size(75, 23);
            this.d_b_zmien.TabIndex = 3;
            this.d_b_zmien.Text = "Zmień";
            this.d_b_zmien.UseVisualStyleBackColor = true;
            this.d_b_zmien.Click += new System.EventHandler(this.d_b_zmien_Click);
            // 
            // d_tb_noweHaslo
            // 
            this.d_tb_noweHaslo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_tb_noweHaslo.Location = new System.Drawing.Point(109, 38);
            this.d_tb_noweHaslo.Name = "d_tb_noweHaslo";
            this.d_tb_noweHaslo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.d_tb_noweHaslo.Size = new System.Drawing.Size(120, 20);
            this.d_tb_noweHaslo.TabIndex = 1;
            this.d_tb_noweHaslo.UseSystemPasswordChar = true;
            this.d_tb_noweHaslo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_tb_noweHaslo_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nowe hasło:";
            // 
            // d_tb_strHaslo
            // 
            this.d_tb_strHaslo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_tb_strHaslo.Location = new System.Drawing.Point(109, 12);
            this.d_tb_strHaslo.Name = "d_tb_strHaslo";
            this.d_tb_strHaslo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.d_tb_strHaslo.Size = new System.Drawing.Size(120, 20);
            this.d_tb_strHaslo.TabIndex = 0;
            this.d_tb_strHaslo.UseSystemPasswordChar = true;
            this.d_tb_strHaslo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_tb_strHaslo_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stare hasło:";
            // 
            // d_tb_noweHaslo2
            // 
            this.d_tb_noweHaslo2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_tb_noweHaslo2.Location = new System.Drawing.Point(109, 64);
            this.d_tb_noweHaslo2.Name = "d_tb_noweHaslo2";
            this.d_tb_noweHaslo2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.d_tb_noweHaslo2.Size = new System.Drawing.Size(120, 20);
            this.d_tb_noweHaslo2.TabIndex = 2;
            this.d_tb_noweHaslo2.UseSystemPasswordChar = true;
            this.d_tb_noweHaslo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_tb_noweHaslo2_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nowe hasło:";
            // 
            // zmienHaslo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 125);
            this.Controls.Add(this.d_tb_noweHaslo2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.d_b_zmien);
            this.Controls.Add(this.d_tb_noweHaslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.d_tb_strHaslo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(257, 163);
            this.Name = "zmienHaslo";
            this.Text = "Zmień hasło";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button d_b_zmien;
        private System.Windows.Forms.TextBox d_tb_noweHaslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox d_tb_strHaslo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox d_tb_noweHaslo2;
        private System.Windows.Forms.Label label3;
    }
}