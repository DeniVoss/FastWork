using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SuportePAP
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost;user=root;password=;database=pap;";
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            LigarBaseDeDados();
            SetupTimer();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick; // Adiciona o evento ao DataGridView
        }

        public void LigarBaseDeDados()
        {
            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Atualiza o DataGridView com base na consulta SQL
                    AtualizarDataGridView("SELECT * FROM post ORDER BY id DESC");
                }
                catch (MySqlException ex)
                {
                    // Trate possíveis erros de conexão
                    MessageBox.Show($"Erro na conexão com o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fecha a conexão
                    connection.Close();
                }
            }
        }

        private void SetupTimer()
        {
            timer = new Timer();
            timer.Interval = 30000; // 30 segundos
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LigarBaseDeDados();
        }

        private void AtualizarDataGridView(string query)
        {
            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Criação do comando SQL
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Criação do adaptador de dados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    // Criação do DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados do adaptador
                    adapter.Fill(dataTable);

                    // Define o DataTable como a fonte de dados do DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (MySqlException ex)
                {
                    // Trate possíveis erros de conexão
                    MessageBox.Show($"Erro na conexão com o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fecha a conexão
                    connection.Close();
                }
            }
        }

        private void btt_eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idPost = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);

                using (connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Abre a conexão
                        connection.Open();

                        // Criação do comando SQL para eliminar o post
                        string sql = "DELETE FROM post WHERE id = @id";
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@id", idPost);

                        // Executa o comando de eliminação
                        command.ExecuteNonQuery();

                        // Atualiza o DataGridView após eliminar o post
                        AtualizarDataGridView("SELECT * FROM post ORDER BY id DESC");

                        MessageBox.Show("Post eliminado com sucesso.");
                    }
                    catch (MySqlException ex)
                    {
                        // Trate possíveis erros de conexão
                        MessageBox.Show($"Erro na conexão com o banco de dados: {ex.Message}");
                    }
                    finally
                    {
                        // Fecha a conexão
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um post para eliminar.");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Obtém o ID do post da linha clicada
                int idPost = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

                // Consulta os dados completos do post usando o ID
                string query = $"SELECT id, utilizador_id, titulo, empresa, tipoTrabalho, ordenado, tempo, descricao, data_criacao FROM post WHERE id = {idPost}";

                using (connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Abre a conexão
                        connection.Open();

                        // Criação do comando SQL
                        MySqlCommand command = new MySqlCommand(query, connection);

                        // Criação do adaptador de dados
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                        // Criação do DataTable para armazenar os dados do post
                        DataTable dataTable = new DataTable();

                        // Preenche o DataTable com os dados do adaptador
                        adapter.Fill(dataTable);

                        // Verifica se foram encontrados dados para o post
                        if (dataTable.Rows.Count > 0)
                        {
                            // Obtém os dados do post
                            int postId = Convert.ToInt32(dataTable.Rows[0]["id"]);
                            int utilizadorId = Convert.ToInt32(dataTable.Rows[0]["utilizador_id"]);
                            string titulo = dataTable.Rows[0]["titulo"].ToString();
                            string empresa = dataTable.Rows[0]["empresa"].ToString();
                            string tipoTrabalho = dataTable.Rows[0]["tipoTrabalho"].ToString();
                            string ordenado = dataTable.Rows[0]["ordenado"].ToString();
                            string tempo = dataTable.Rows[0]["tempo"].ToString();
                            string descricao = dataTable.Rows[0]["descricao"].ToString();
                            DateTime dataCriacao = Convert.ToDateTime(dataTable.Rows[0]["data_criacao"]);

                            // Exibe a MessageBox com os detalhes do post
                            string mensagem = $"ID: {postId}\nUtilizador ID: {utilizadorId}\nTítulo: {titulo}\nEmpresa: {empresa}\nTipo de Trabalho: {tipoTrabalho}\nOrdenado: {ordenado}\nTempo: {tempo}\nDescrição: {descricao}\nData de Criação: {dataCriacao}";
                            MessageBox.Show(mensagem, "Detalhes do Post", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível encontrar os dados do post selecionado.");
                        }
                    }
                    catch (MySqlException ex)
                    {
                        // Trate possíveis erros de conexão
                        MessageBox.Show($"Erro na conexão com o banco de dados: {ex.Message}");
                    }
                    finally
                    {
                        // Fecha a conexão
                        connection.Close();
                    }
                }
            }
        }

        private void bttProcurar_Click(object sender, EventArgs e)
        {
            string criterio = cbProcurar.SelectedItem.ToString();
            string valor = txtProcurar.Text.Trim();
            if (string.IsNullOrEmpty(valor))
            {
                MessageBox.Show("Digite um valor para procurar.");
                return;
            }

            string query = "";

            switch (criterio)
            {
                case "ID do Post":
                    query = $"SELECT * FROM post WHERE id = {valor}";
                    break;
                case "ID do Utilizador":
                    query = $"SELECT * FROM post WHERE utilizador_id = {valor}";
                    break;
                case "Titulo":
                    query = $"SELECT * FROM post WHERE titulo LIKE '%{valor}%'";
                    break;
                default:
                    MessageBox.Show("Selecione um critério de busca válido.");
                    return;
            }

            using (connection = new MySqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Criação do comando SQL
                    MySqlCommand command = new MySqlCommand(query, connection);

                    // Criação do adaptador de dados
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    // Criação do DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados do adaptador
                    adapter.Fill(dataTable);

                    // Verifica se foram encontrados dados para a busca
                    if (dataTable.Rows.Count > 0)
                    {
                        // Obtém o ID do post pesquisado
                        int postId = Convert.ToInt32(dataTable.Rows[0]["id"]);

                        // Seleciona o post pesquisado no DataGridView
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            int id = Convert.ToInt32(row.Cells["id"].Value);
                            if (id == postId)
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum resultado encontrado.");
                    }
                }
                catch (MySqlException ex)
                {
                    // Trate possíveis erros de conexão
                    MessageBox.Show($"Erro na conexão com o banco de dados: {ex.Message}");
                }
                finally
                {
                    // Fecha a conexão
                    connection.Close();
                }
            }
        }

        private void btt_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
