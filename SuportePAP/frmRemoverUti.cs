using System;
using System.Data;
using System.Windows.Forms;

namespace SuportePAP
{
    public partial class frmRemoverUti : Form
    {
        private BD_DAL bdDal = new BD_DAL();
        private Timer timer;
        private string pesquisaSelecionada;

        public frmRemoverUti()
        {
            InitializeComponent();
            SetupTimer();
            LigarBaseDeDados();

            dataGridView1.DoubleClick += DataGridView_DoubleClick;
        }

        private void frmRemoverUti_Load(object sender, EventArgs e)
        {

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LigarBaseDeDados();
        }

        private void SetupTimer()
        {
            timer = new Timer();
            timer.Interval = 30000; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void LigarBaseDeDados()
        {
            string sqlQuery = "SELECT id, nome, apelido, utilizador, email, numero FROM utilizador ORDER BY id DESC";
            DataTable dataTable = bdDal.ExecuteQuery(sqlQuery);
            dataGridView1.DataSource = dataTable;
        }

        public void AtualizarDataGridView(string query)
        {
            DataTable dataTable = bdDal.ExecuteQuery(query);
            dataGridView1.DataSource = dataTable;
        }

        private void bttProcurar_Click(object sender, EventArgs e)
        {
            pesquisaSelecionada = cbProcurar.SelectedItem.ToString();
            string query;

            if (pesquisaSelecionada == "ID do Utilizador")
            {
                query = $"SELECT * FROM utilizador WHERE id = '{txtProcurar.Text}'";
            }
            else if (pesquisaSelecionada == "Nome")
            {
                query = $"SELECT * FROM utilizador WHERE nome LIKE '%{txtProcurar.Text}%'";
            }
            else if (pesquisaSelecionada == "Email")
            {
                query = $"SELECT * FROM utilizador WHERE email LIKE '%{txtProcurar.Text}%'";
            }
            else
            {
                return;
            }

            AtualizarDataGridView(query);
        }

        private void DataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Obter os dados do utilizador da linha selecionada
                string id = selectedRow.Cells["id"].Value.ToString();
                string nome = selectedRow.Cells["nome"].Value.ToString();
                string email = selectedRow.Cells["email"].Value.ToString();
                
                string mensagem = $"ID: {id}\nNome: {nome}\nEmail: {email}\n";
                

                MessageBox.Show(mensagem, "Detalhes do Utilizador", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btt_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string id = selectedRow.Cells["id"].Value.ToString();

                DialogResult result = MessageBox.Show("Tem certeza que deseja eliminar este utilizador?", "Eliminar Utilizador", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string query = $"DELETE FROM utilizador WHERE id = '{id}'";
                        bdDal.ExecuteNonQuery(query);

                        LigarBaseDeDados();

                        MessageBox.Show("Utilizador eliminado com sucesso.", "Eliminar Utilizador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao eliminar utilizador: " + ex.Message, "Eliminar Utilizador", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um utilizador para eliminar.", "Eliminar Utilizador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btt_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
