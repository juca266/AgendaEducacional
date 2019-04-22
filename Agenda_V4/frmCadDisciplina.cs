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
    public partial class frmCadDisciplina : Form
    {
        //SqlDataReader dr;
        public string Cor_R, Cor_G, Cor_B;
        public bool salvo = true;       // identifica alteração em cada textBox do formulário
        public bool alterar = false;    // Identifica se o formulario foi preenchido ou importado para edição
        public string id = "0";         // Guarda o IdSala referente a linha das informações carregadas nos TextBox

        public frmCadDisciplina()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e) // Gravar
        {
            if (salvo == false) // se ouve alteração no formulario então salva
            {
                if (Cor_R == "")
                {
                    Cor_R = "0";
                    Cor_G = "0";
                    Cor_B = "0";
                }
            SqlConnection conexao = new SqlConnection(Conexao.Con);
            try
            {
                    conexao.Open();
            }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro " + ex.Message);
                    throw;
                }
                finally
                {
                    if (alterar == true)
                    {
                        //conexao.Open();
                        SqlCommand cmd1 = new SqlCommand("UPDATE tblDisciplina SET CodDisciplina = '" + textBoxCodDisciplina.Text + "', Disciplina = '"
                           + textBoxDisciplina.Text + "',Cor_R = '" + int.Parse(Cor_R) + "', Cor_G = '" + int.Parse(Cor_G) + "', Cor_B = '" +
                           int.Parse(Cor_B) + "'WHERE(IdDisciplina = '" + id + "')",conexao);

                        cmd1.ExecuteNonQuery();
                        conexao.Close();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO tblDisciplina(CodDisciplina, Disciplina, Cor_R, Cor_G, Cor_B) VALUES('" + textBoxCodDisciplina.Text + "','" + textBoxDisciplina.Text + "','" + Cor_R + "', '" + Cor_G + "', '" + Cor_B + "')", conexao);
                        cmd.ExecuteNonQuery();
                        conexao.Close();
                    }
                }
                salvo = true;
                frmCadDisciplina_Load(sender, e);       // Atualiza o DataGrid

                if (alterar == false)
                {
                    textBoxCodDisciplina.Text = "";
                    textBoxDisciplina.Text = "";        //
                    pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
                }
                else alterar = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) // btn Excluir
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con);
            SqlCommand cmd = new SqlCommand(("DELETE FROM tblDisciplina WHERE IdDisciplina= '" + id + "'"), conexao);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // deleta valores do banco de dados
                frmCadDisciplina_Load(sender, e); // Atualiza o DataGrid
                if (alterar == false)
                {
                    textBoxCodDisciplina.Text = "";
                    textBoxDisciplina.Text = ""; //
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

        private void textBoxCodDisciplina_KeyUp(object sender, KeyEventArgs e)
        {
            salvo = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxCodDisciplina.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxDisciplina.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //
            Cor_R = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Cor_G = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Cor_B = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (Cor_R == "")
            {
                Cor_R = "0";
                Cor_G = "0";
                Cor_B = "0";
            }
            pictureBox1.BackColor = Color.FromArgb(int.Parse(Cor_R), int.Parse(Cor_G), int.Parse(Cor_B));
            // Carregar a cor do BD Para o pictureBox
            alterar = true;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            salvo = false;
        }

        private void textBoxCodDisciplina_Enter(object sender, EventArgs e)
        {
                Conexao c = new Conexao();
                c.autocompletar(textBoxCodDisciplina, "tblDisciplina", "CodDisciplina");
        }

        private void textBoxCodDisciplina_Leave(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDisciplina", conexao); // executa a busca no bd
                SqlDataReader drd = cmd.ExecuteReader();               
                while (drd.Read())
                {
                    if (textBoxCodDisciplina.Text == drd["CodDisciplina"].ToString())
                    {
                        textBoxDisciplina.Text = drd["Disciplina"].ToString();
                        pictureBox1.BackColor = Color.FromArgb(int.Parse(drd["Cor_R"].ToString()),
                            int.Parse(drd["Cor_G"].ToString()), int.Parse(drd["Cor_B"].ToString()));
                        salvo = true;
                    } 
                }
                drd.Close();
                conexao.Close();
            }
        }

        private void textBoxDisciplina_Enter(object sender, EventArgs e)
        {
            Conexao c = new Conexao();
            c.autocompletar(textBoxDisciplina, "tblDisciplina", "Disciplina");
        }

        private void textBoxDisciplina_Leave(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDisciplina", conexao); // executa a busca no bd
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    if (textBoxDisciplina.Text == drd["Disciplina"].ToString())
                    {
                        textBoxCodDisciplina.Text = drd["CodDisciplina"].ToString();
                        pictureBox1.BackColor = Color.FromArgb(int.Parse(drd["Cor_R"].ToString()),
                            int.Parse(drd["Cor_G"].ToString()), int.Parse(drd["Cor_B"].ToString()));
                        salvo = true;
                    }
                }
                drd.Close();
                conexao.Close();
            }
        }

        private void frmCadDisciplina_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // Instancia a string e conexão
            string SqlString = "SELECT * FROM tblDisciplina"; // seleciona a tabela e os campo
            SqlCommand cmd = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
            try                                             //Tenta executar o que estiver abaixo
            {
                conexao.Open();             // abre a conexão com o banco   
                cmd.ExecuteNonQuery();      // executa cmd instanciado acima
                                            //Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, 
                                            //agora os passos seguintes irão exibir as informações para que o usuário possa vê-las
                SqlDataAdapter da = new SqlDataAdapter(); // da, adapta o banco de dados ao nosso projeto 
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;     // adapta cmd ao projeto
                da.Fill(ds);                // preenche todas as informações dentro do DataSet                                          
                dataGridView1.DataSource = ds;                      //Datagridview recebe ds já preenchido
                dataGridView1.DataMember = ds.Tables[0].TableName;      //Agora Datagridview exibe o banco de dados
                this.dataGridView1.Columns["IdDisciplina"].Visible = false;   // Oculta o campo IdSala no Datagridview
                this.dataGridView1.Columns["Cor_R"].Visible = false;
                this.dataGridView1.Columns["Cor_G"].Visible = false;
                this.dataGridView1.Columns["Cor_B"].Visible = false;
                DataGridViewColumn column1 = dataGridView1.Columns[1];  // Instancias as colunas do Datagrid
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                column1.Width = 75;     // limitamos o tamanho da coluna 1 do datagrid
                column2.Width = 186;    // ...
                pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message); //Se ocorer algum erro será informado em um msgbox
                throw;
            }
            finally
            {
                conexao.Close(); // Se tudo ocorrer bem fecha a conexão com o banco da dados, sempre é bom fechar a conexão após executar até o final o que nos interessa, isso pode evitar problemas futuros
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = pictureBox1.BackColor; // Carrega a cor atual para colorDialog1
            colorDialog1.ShowDialog();                  // Abre o colorDailig
            pictureBox1.BackColor = colorDialog1.Color; // Tranfere a cor para o pictureBox
            Cor_R = colorDialog1.Color.R.ToString();    // Carrega o valor R
            Cor_G = colorDialog1.Color.G.ToString();    // ...G
            Cor_B = colorDialog1.Color.B.ToString();    // E B da cor
            
        }
    }
}
