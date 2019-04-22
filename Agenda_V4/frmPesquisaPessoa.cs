using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// acrescentar este
using System.Data.SqlClient;

namespace Agenda_V4
{
    public partial class frmPesquisaPessoa : Form
    {
        public frmPesquisaPessoa()
        {
            InitializeComponent();
        }

        private void frmPesquisaPessoa_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con);
            try
            {
                conexao.Open();                         // Abre a conexão  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
                throw;
            }
            finally
            {
                string SqlString = "SELECT tblUsuario.IdUsuario, tblUsuario.Cracha, tblUsuario.Nome FROM tblUsuario"; // seleciona a tabela e os campo
                SqlCommand cmd = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(); // da, adapta o banco de dados ao nosso projeto 
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;     // adapta cmd ao projeto
                da.Fill(ds);                // preenche todas as informações dentro do DataSet                                          
                dataGridView1.DataSource = ds;                      //Datagridview recebe ds já preenchido
                dataGridView1.DataMember = ds.Tables[0].TableName;
                this.dataGridView1.Columns["IdUsuario"].Visible = false;   // Oculta o campo IdSala no Datagridview
                DataGridViewColumn column1 = dataGridView1.Columns[1];
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                conexao.Close();
                dataGridView1.Rows.Clear(); // Limpa o grid
                dataGridView1.Columns[1].Name = "Nome";
                dataGridView1.Columns[2].Name = "Crachá";
                dataGridView1.Columns[1].Width = 130;
            }
        }
    }
}
