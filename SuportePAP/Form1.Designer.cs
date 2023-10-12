namespace SuportePAP
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btt_eliminar = new System.Windows.Forms.Button();
            this.bttProcurar = new System.Windows.Forms.Button();
            this.cbProcurar = new System.Windows.Forms.ComboBox();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(751, 352);
            this.dataGridView1.TabIndex = 0;
            // 
            // btt_eliminar
            // 
            this.btt_eliminar.Location = new System.Drawing.Point(600, 15);
            this.btt_eliminar.Name = "btt_eliminar";
            this.btt_eliminar.Size = new System.Drawing.Size(71, 24);
            this.btt_eliminar.TabIndex = 1;
            this.btt_eliminar.Text = "Eliminar";
            this.btt_eliminar.UseVisualStyleBackColor = true;
            this.btt_eliminar.Click += new System.EventHandler(this.btt_eliminar_Click);
            // 
            // bttProcurar
            // 
            this.bttProcurar.Location = new System.Drawing.Point(527, 15);
            this.bttProcurar.Name = "bttProcurar";
            this.bttProcurar.Size = new System.Drawing.Size(67, 24);
            this.bttProcurar.TabIndex = 2;
            this.bttProcurar.Text = "Procurar";
            this.bttProcurar.UseVisualStyleBackColor = true;
            this.bttProcurar.Click += new System.EventHandler(this.bttProcurar_Click);
            // 
            // cbProcurar
            // 
            this.cbProcurar.AllowDrop = true;
            this.cbProcurar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProcurar.FormattingEnabled = true;
            this.cbProcurar.Items.AddRange(new object[] {
            "ID do Post",
            "ID do Utilizador",
            "Titulo"});
            this.cbProcurar.Location = new System.Drawing.Point(86, 15);
            this.cbProcurar.Name = "cbProcurar";
            this.cbProcurar.Size = new System.Drawing.Size(121, 21);
            this.cbProcurar.TabIndex = 3;
            // 
            // txtProcurar
            // 
            this.txtProcurar.Location = new System.Drawing.Point(213, 16);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(308, 20);
            this.txtProcurar.TabIndex = 4;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(12, 18);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(68, 13);
            this.lbl1.TabIndex = 5;
            this.lbl1.Text = "Procurar por:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 426);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.cbProcurar);
            this.Controls.Add(this.bttProcurar);
            this.Controls.Add(this.btt_eliminar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Suporte FastWork";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btt_eliminar;
        private System.Windows.Forms.Button bttProcurar;
        private System.Windows.Forms.ComboBox cbProcurar;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.Label lbl1;
    }
}

