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
    public partial class frmCadSala : Form
    {
        public bool salvo = true;       // identifica alteração em cada textBox do formulário
        public bool alterar = false;    // Identifica se o formulario foi preenchido ou importado para edição
        public string id = "0";         // Guarda o IdSala referente a linha das informações carregadas nos TextBox

        public frmCadSala()
        {
            InitializeComponent();
        }
        //*************EVENTO LOAD DO FORM CADSALA****************************************************************

        private void frmCadSala_Load(object sender, EventArgs e)
        {       // CARREGA O DATA GRID COM OS DADOS DA TABELA TBLSALA.///////////////////////////////////////////////
            SqlConnection conexao = new SqlConnection(Conexao.Con); // Instancia a string e conexão
            try                                             //Tenta executar o que estiver abaixo
            {
                conexao.Open();             // abre a conexão com o banco   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message); //Se ocorer algum erro será informado em um msgbox
                throw;
            }
            finally
            {
                string SqlString = "SELECT tblsala.IdSala, tblSala.NSala, tblSala.TipoRecurso, tblSala.Capacidade FROM tblSala"; // seleciona a tabela e os campo
                SqlCommand cmd = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                cmd.ExecuteNonQuery();      // executa cmd instanciado acima
                                            //Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, 
                                            //agora os passos seguintes irão exibir as informações para que o usuário possa vê-las
                SqlDataAdapter da = new SqlDataAdapter(); // da, adapta o banco de dados ao nosso projeto 
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;     // adapta cmd ao projeto
                da.Fill(ds);                // preenche todas as informações dentro do DataSet                                          
                dataGridView1.DataSource = ds;                      //Datagridview recebe ds já preenchido
                dataGridView1.DataMember = ds.Tables[0].TableName;      //Agora Datagridview exibe o banco de dados
                this.dataGridView1.Columns["IdSala"].Visible = false;   // Oculta o campo IdSala no Datagridview
                DataGridViewColumn column1 = dataGridView1.Columns[1];  // Instancias as colunas do Datagrid
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                DataGridViewColumn column3 = dataGridView1.Columns[3];
                column1.Width = 75;     // limitamos o tamanho da coluna 1 do datagrid
                column2.Width = 149;    // ...
                conexao.Close(); // Se tudo ocorrer bem fecha a conexão com o banco da dados, sempre é bom fechar a conexão após executar até o final o que nos interessa, isso pode evitar problemas futuros
            }
        }
        //*****************************************************************************************************************
        private void buttonGravar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Conexao.Con); // Instancia a string e conexão
            try
            {
                con.Open();             // abre a conexão com o banco
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha no autocompletar" + ex.ToString());
            }
            finally
            {
                SqlCommand cm = new SqlCommand("SELECT * FROM tblSala", con);
                SqlDataReader drd = cm.ExecuteReader();
                while (drd.Read())
                {
                    if (textBoxNumero.Text == drd["NSala"].ToString() && textBoxRecurso.Text == drd["TipoRecurso"].ToString() && textBoxCapacidade.Text == drd["Capacidade"].ToString())
                    {
                        MessageBox.Show("Sala Já Cadastrada! Por favor, selecione na lista abaixo para alterar.");
                        textBoxNumero.Text = "";
                        textBoxRecurso.Text = ""; //
                        textBoxCapacidade.Text = "";
                        salvo = true;
                    }
                }
                drd.Close();
                con.Close();
            }

            if (salvo == false) // se ouve alteração no formulario então salva
            {
                if (alterar == true)
                {
                    buttonExcluir_Click(sender, e); // apaga
                }
                SqlConnection conexao = new SqlConnection(Conexao.Con);
                SqlCommand cmd = new SqlCommand("INSERT INTO tblSala(NSala, TipoRecurso, Capacidade) VALUES('" + textBoxNumero.Text + "','" + textBoxRecurso.Text + "','" + textBoxCapacidade.Text + "')", conexao);
                try
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro " + ex.Message);
                    throw;
                }
                finally
                {
                    conexao.Close();
                }
                salvo = true;
                frmCadSala_Load(sender, e); // Atualiza o DataGrid
                if (alterar == false)
                {
                    textBoxNumero.Text = "";
                    textBoxRecurso.Text = ""; //
                    textBoxCapacidade.Text = "";
                }
                else alterar = false;
            }
        }

        private void textBoxNumero_KeyUp(object sender, KeyEventArgs e)
        {
            salvo = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxNumero.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxRecurso.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //
            textBoxCapacidade.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            alterar = true;
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con);
            SqlCommand cmd = new SqlCommand(("DELETE FROM tblSala WHERE IdSala= '" + id + "'"), conexao);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // deleta valores do banco de dados
                frmCadSala_Load(sender, e); // Atualiza o DataGrid
                if (alterar == false)
                {
                    textBoxNumero.Text = "";
                    textBoxRecurso.Text = ""; //
                    textBoxCapacidade.Text = "";
                }
                else alterar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        private void textBoxNumero_Enter(object sender, EventArgs e)
        {
            Conexao c = new Conexao();
            c.autocompletar(textBoxNumero, "tblSala", "NSala");
        }

        private void textBoxRecurso_Enter(object sender, EventArgs e)
        {
            Conexao c = new Conexao();
            c.autocompletar(textBoxRecurso, "tblSala", "TipoRecurso");
        }

        private void textBoxNumero_Leave(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
            try											// tenta executar
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)					// Se não conectou
            {
                MessageBox.Show("Erro " + ex.Message);
                throw;
            }
            finally									//Se conectou então finaliza
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblSala", conexao); // executa a busca no bd
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    if (textBoxNumero.Text == drd["NSala"].ToString())
                    {
                        textBoxRecurso.Text = drd["TipoRecurso"].ToString();
                        textBoxCapacidade.Text = drd["Capacidade"].ToString();
                        salvo = true;
                    }
                }
                drd.Close();
                conexao.Close();
            }
        }

        private void textBoxRecurso_Leave(object sender, EventArgs e)
        {
            
                SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
                try                                         // tenta executar
                {
                    conexao.Open();                     // Abre a conexão
                }
                catch (Exception ex)                    // Se não conectou
                {
                    MessageBox.Show("Erro " + ex.Message);
                    throw;
                }
                finally                                 //Se conectou então finaliza
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblSala", conexao); // executa a busca no bd
                    SqlDataReader drd = cmd.ExecuteReader();
                    while (drd.Read())
                    {
                        if (textBoxRecurso.Text == drd["TipoRecurso"].ToString())
                        {
                            textBoxNumero.Text = drd["NSala"].ToString();
                            textBoxCapacidade.Text = drd["Capacidade"].ToString();
                            salvo = true;
                        }
                    }
                    drd.Close();
                    conexao.Close();
                }
            
        }
    }
}
