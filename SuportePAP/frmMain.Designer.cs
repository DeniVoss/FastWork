namespace SuportePAP
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btt_Suporte = new System.Windows.Forms.Button();
            this.btt_VerPost = new System.Windows.Forms.Button();
            this.btt_Remover_uti = new System.Windows.Forms.Button();
            this.btt_Princ = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelmdi = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(24)))), ((int)(((byte)(32)))));
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 31);
            this.panel2.TabIndex = 15;
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(6, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(47, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(59, 7);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(110, 19);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Administrador";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(863, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 31);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(170)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.btt_Suporte);
            this.panel1.Controls.Add(this.btt_VerPost);
            this.panel1.Controls.Add(this.btt_Remover_uti);
            this.panel1.Controls.Add(this.btt_Princ);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(107, 465);
            this.panel1.TabIndex = 16;
            // 
            // btt_Suporte
            // 
            this.btt_Suporte.FlatAppearance.BorderSize = 0;
            this.btt_Suporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.btt_Suporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_Suporte.Location = new System.Drawing.Point(0, 166);
            this.btt_Suporte.Name = "btt_Suporte";
            this.btt_Suporte.Size = new System.Drawing.Size(107, 54);
            this.btt_Suporte.TabIndex = 11;
            this.btt_Suporte.Text = "Ver Suporte";
            this.btt_Suporte.UseVisualStyleBackColor = true;
            this.btt_Suporte.Click += new System.EventHandler(this.btt_Suporte_Click);
            // 
            // btt_VerPost
            // 
            this.btt_VerPost.FlatAppearance.BorderSize = 0;
            this.btt_VerPost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.btt_VerPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_VerPost.Location = new System.Drawing.Point(0, 106);
            this.btt_VerPost.Name = "btt_VerPost";
            this.btt_VerPost.Size = new System.Drawing.Size(107, 54);
            this.btt_VerPost.TabIndex = 10;
            this.btt_VerPost.Text = "Ver Posts";
            this.btt_VerPost.UseVisualStyleBackColor = true;
            this.btt_VerPost.Click += new System.EventHandler(this.btt_VerPost_Click);
            // 
            // btt_Remover_uti
            // 
            this.btt_Remover_uti.FlatAppearance.BorderSize = 0;
            this.btt_Remover_uti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.btt_Remover_uti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_Remover_uti.Location = new System.Drawing.Point(0, 46);
            this.btt_Remover_uti.Name = "btt_Remover_uti";
            this.btt_Remover_uti.Size = new System.Drawing.Size(107, 54);
            this.btt_Remover_uti.TabIndex = 9;
            this.btt_Remover_uti.Text = "Remover Utilizador";
            this.btt_Remover_uti.UseVisualStyleBackColor = true;
            this.btt_Remover_uti.Click += new System.EventHandler(this.btt_Remover_uti_Click);
            // 
            // btt_Princ
            // 
            this.btt_Princ.FlatAppearance.BorderSize = 0;
            this.btt_Princ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(153)))), ((int)(((byte)(85)))));
            this.btt_Princ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btt_Princ.Location = new System.Drawing.Point(0, 0);
            this.btt_Princ.Name = "btt_Princ";
            this.btt_Princ.Size = new System.Drawing.Size(107, 54);
            this.btt_Princ.TabIndex = 7;
            this.btt_Princ.Text = "Painel Principal";
            this.btt_Princ.UseVisualStyleBackColor = true;
            this.btt_Princ.Click += new System.EventHandler(this.btt_Princ_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(0, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelmdi
            // 
            this.panelmdi.Location = new System.Drawing.Point(107, 29);
            this.panelmdi.Name = "panelmdi";
            this.panelmdi.Size = new System.Drawing.Size(794, 465);
            this.panelmdi.TabIndex = 2;
            this.panelmdi.Paint += new System.Windows.Forms.PaintEventHandler(this.panelmdi_Paint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 494);
            this.ControlBox = false;
            this.Controls.Add(this.panelmdi);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btt_Remover_uti;
        private System.Windows.Forms.Button btt_Princ;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btt_VerPost;
        private System.Windows.Forms.Button btt_Suporte;
        private System.Windows.Forms.Panel panelmdi;
    }
}