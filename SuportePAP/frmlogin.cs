using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuportePAP
{
    public partial class frmlogin : Form
    {
        private MySqlConnection connection;
        private string server = "localhost";
        private string database = "pap";
        private string uid = "root";
        private string password = "";

        public frmlogin()
        {
            InitializeComponent();
            LigarBaseDeDados();
        }

        public void LigarBaseDeDados()
        {
            string connectionString = $"server={server};user={uid};password={password};database={database};";
            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Erro na conexão com o banco de dados: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string userPassword = txtPass.Text;

            string connectionString = $"server={server};user={uid};password={password};database={database};";
            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT COUNT(*) FROM suporteutilizador WHERE utilizador='{username}' AND password='{userPassword}'";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Login bem-sucedido!");

                        frmMain main = new frmMain();
                        main.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Credenciais inválidas. Tente novamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                button1_Click(sender, e);
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPass.Focus();
                e.Handled = true; 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
