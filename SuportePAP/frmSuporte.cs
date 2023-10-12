using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace SuportePAP
{
    public partial class frmSuporte : Form
    {
        private BD_DAL bdDal = new BD_DAL();
        private DataTable dataTable;

        public frmSuporte()
        {
            InitializeComponent();
        }


        private void RefreshDataGridView()
        {
                string sqlQuery = "SELECT * FROM suporte ORDER BY id DESC";
                dataTable = bdDal.ExecuteQuery(sqlQuery);
                dataGridView1.DataSource = dataTable;
        }


        private void frmSuporte_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void bttResponder_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                string email = dataGridView1.Rows[rowIndex].Cells["email"].Value.ToString();
                string titulo = txtTitulo.Text;
                string descricao = txtDescricao.Text;

                if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrWhiteSpace(descricao))
                {
                    MessageBox.Show("Por favor, preencha o título e a descrição antes de enviar o e-mail.");
                    return;
                }

                string assunto = "Resposta ao suporte: " + titulo;
                string mensagem = "Caro(a) utilizador da FastWork, agradecemos pelo seu contato e enviamos esta mensagem em resposta ao seu pedido suporte.\n\n";
                mensagem +=  descricao + "\n\n";
                mensagem += "Atenciosamente,\nEquipa de Suporte";

                EnviarEmail(email, assunto, mensagem);
            }
        }


        private void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            try
            {
                string remetente = "************";//Ocultado por seguranca
                string senha = "***********";//Ocultado por seguranca

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(remetente, senha);
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage(remetente, destinatario, assunto, mensagem);
                mailMessage.IsBodyHtml = false;

                smtpClient.Send(mailMessage);

                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao enviar o e-mail: " + ex.Message);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                string mensagem = "";
                foreach (DataGridViewCell cell in dataGridView1.Rows[rowIndex].Cells)
                {
                    mensagem += cell.OwningColumn.HeaderText + ": " + cell.Value + "\n";
                }

                MessageBox.Show(mensagem);
            }
        }

        private void btt_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btt_atualizar_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
    }
}
