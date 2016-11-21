namespace IM
{
    partial class ManageUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUsers));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.d_dgv_tabela = new System.Windows.Forms.DataGridView();
            this.firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_b_dodaj = new System.Windows.Forms.Button();
            this.d_b_usun = new System.Windows.Forms.Button();
            this.d_b_zapisz = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_dgv_tabela)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.d_dgv_tabela);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(456, 347);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Użytkownicy";
            // 
            // d_dgv_tabela
            // 
            this.d_dgv_tabela.AllowUserToAddRows = false;
            this.d_dgv_tabela.AllowUserToDeleteRows = false;
            this.d_dgv_tabela.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.d_dgv_tabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_dgv_tabela.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstname,
            this.lastname,
            this.login,
            this.pass});
            this.d_dgv_tabela.Location = new System.Drawing.Point(7, 20);
            this.d_dgv_tabela.Name = "d_dgv_tabela";
            this.d_dgv_tabela.Size = new System.Drawing.Size(443, 321);
            this.d_dgv_tabela.TabIndex = 0;
            this.d_dgv_tabela.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.d_dgv_tabela_CellEndEdit);
            this.d_dgv_tabela.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.d_dgv_tabela_CellFormatting);
            this.d_dgv_tabela.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.d_dgv_tabela_CellValueChanged);
            // 
            // firstname
            // 
            this.firstname.HeaderText = "Imię";
            this.firstname.Name = "firstname";
            this.firstname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.firstname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lastname
            // 
            this.lastname.HeaderText = "Nazwisko";
            this.lastname.Name = "lastname";
            // 
            // login
            // 
            this.login.HeaderText = "login";
            this.login.Name = "login";
            // 
            // pass
            // 
            this.pass.HeaderText = "hasło";
            this.pass.Name = "pass";
            this.pass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // d_b_dodaj
            // 
            this.d_b_dodaj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_b_dodaj.Location = new System.Drawing.Point(489, 32);
            this.d_b_dodaj.Name = "d_b_dodaj";
            this.d_b_dodaj.Size = new System.Drawing.Size(75, 23);
            this.d_b_dodaj.TabIndex = 1;
            this.d_b_dodaj.Text = "Dodaj";
            this.d_b_dodaj.UseVisualStyleBackColor = true;
            this.d_b_dodaj.Click += new System.EventHandler(this.d_b_dodaj_Click);
            // 
            // d_b_usun
            // 
            this.d_b_usun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_b_usun.Location = new System.Drawing.Point(489, 62);
            this.d_b_usun.Name = "d_b_usun";
            this.d_b_usun.Size = new System.Drawing.Size(75, 23);
            this.d_b_usun.TabIndex = 2;
            this.d_b_usun.Text = "Usuń";
            this.d_b_usun.UseVisualStyleBackColor = true;
            this.d_b_usun.Click += new System.EventHandler(this.d_b_usun_Click);
            // 
            // d_b_zapisz
            // 
            this.d_b_zapisz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.d_b_zapisz.Location = new System.Drawing.Point(489, 337);
            this.d_b_zapisz.Name = "d_b_zapisz";
            this.d_b_zapisz.Size = new System.Drawing.Size(75, 23);
            this.d_b_zapisz.TabIndex = 3;
            this.d_b_zapisz.Text = "Zapisz";
            this.d_b_zapisz.UseVisualStyleBackColor = true;
            this.d_b_zapisz.Click += new System.EventHandler(this.d_b_zapisz_Click);
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 372);
            this.Controls.Add(this.d_b_zapisz);
            this.Controls.Add(this.d_b_usun);
            this.Controls.Add(this.d_b_dodaj);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageUsers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zarządzaj użytkownikami";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_dgv_tabela)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button d_b_dodaj;
        private System.Windows.Forms.Button d_b_usun;
        private System.Windows.Forms.Button d_b_zapisz;
        private System.Windows.Forms.DataGridView d_dgv_tabela;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn login;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass;
    }
}