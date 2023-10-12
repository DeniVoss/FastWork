namespace SuportePAP
{
    partial class frmRemoverUti
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.txtProcurar = new System.Windows.Forms.TextBox();
            this.cbProcurar = new System.Windows.Forms.ComboBox();
            this.bttProcurar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btt_eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(26, 32);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(68, 13);
            this.lbl1.TabIndex = 10;
            this.lbl1.Text = "Procurar por:";
            // 
            // txtProcurar
            // 
            this.txtProcurar.Location = new System.Drawing.Point(227, 30);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(273, 20);
            this.txtProcurar.TabIndex = 9;
            // 
            // cbProcurar
            // 
            this.cbProcurar.AllowDrop = true;
            this.cbProcurar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProcurar.FormattingEnabled = true;
            this.cbProcurar.Items.AddRange(new object[] {
            "ID do Utilizador",
            "Nome",
            "Email"});
            this.cbProcurar.Location = new System.Drawing.Point(100, 29);
            this.cbProcurar.Name = "cbProcurar";
            this.cbProcurar.Size = new System.Drawing.Size(121, 21);
            this.cbProcurar.TabIndex = 8;
            // 
            // bttProcurar
            // 
            this.bttProcurar.Location = new System.Drawing.Point(506, 31);
            this.bttProcurar.Name = "bttProcurar";
            this.bttProcurar.Size = new System.Drawing.Size(86, 22);
            this.bttProcurar.TabIndex = 7;
            this.bttProcurar.Text = "Procurar";
            this.bttProcurar.UseVisualStyleBackColor = true;
            this.bttProcurar.Click += new System.EventHandler(this.bttProcurar_Click);
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
            this.dataGridView1.TabIndex = 6;
            // 
            // btt_eliminar
            // 
            this.btt_eliminar.Location = new System.Drawing.Point(598, 30);
            this.btt_eliminar.Name = "btt_eliminar";
            this.btt_eliminar.Size = new System.Drawing.Size(68, 23);
            this.btt_eliminar.TabIndex = 11;
            this.btt_eliminar.Text = "Eliminar";
            this.btt_eliminar.UseVisualStyleBackColor = true;
            this.btt_eliminar.Click += new System.EventHandler(this.btt_eliminar_Click);
            // 
            // frmRemoverUti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 426);
            this.Controls.Add(this.btt_eliminar);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.txtProcurar);
            this.Controls.Add(this.cbProcurar);
            this.Controls.Add(this.bttProcurar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmRemoverUti";
            this.Text = "Remover Utilizador ";
            this.Load += new System.EventHandler(this.frmRemoverUti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.TextBox txtProcurar;
        private System.Windows.Forms.ComboBox cbProcurar;
        private System.Windows.Forms.Button bttProcurar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btt_eliminar;
    }
}