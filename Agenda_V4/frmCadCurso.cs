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
    public partial class frmCadCurso : Form
    {
       SqlDataReader drDisciplina;

        public string Cor_R, Cor_G, Cor_B;
        public bool salvo = true;       // identifica alteração em cada textBox do formulário
        public bool grava_Curso = false;
        public bool alterar = false;    // Identifica se o formulario foi preenchido ou importado para edição
        public bool Cadastrado = false;
        public int idDisciplina = 0;         // Guarda o IdSala referente a linha das informações carregadas nos TextBox
        public int IdCurso = 0;

        public frmCadCurso()
        {
            InitializeComponent();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
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
                //DELETE FROM tblCursoDisciplina WHERE(IdCurso = IdCurso)
                SqlCommand cmd = new SqlCommand("DELETE FROM tblCurso WHERE (IdCurso= '" + IdCurso + "')", conexao);
                cmd.ExecuteNonQuery();              // deleta valores do banco de dados
                conexao.Close();
                conexao.Open();
                SqlCommand cmd1 = new SqlCommand("DELETE FROM tblCursoDisciplina WHERE(IdCurso ='" + IdCurso + "')", conexao);
                cmd1.ExecuteNonQuery();
                textBoxCodCurso.Text = "";
                textBoxCurso.Text = ""; //
                textBoxCodDisciplina.Text = "";
                comboBoxDisciplina.Text = "";
                salvo = true;       // identifica alteração em cada textBox do formulário
                grava_Curso = false;
                alterar = false;    // Identifica se o formulario foi preenchido ou importado para edição
                Cadastrado = false;
                idDisciplina = 0;         // Guarda o IdSala referente a linha das informações carregadas nos TextBox
                IdCurso = 0;
                conexao.Close();
                // Atualiza o Data Greed
                frmCadCurso_Load(sender, e);
                textBoxCurso_Leave(sender, e); // Atualiza o DataGrid
            }
        }

        private void buttonMais_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // Instancia a string e conexão
            try                                             //Tenta executar o que estiver abaixo
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
                conexao.Close();
                if (grava_Curso == false) // se o curso ainda não foi gravado
                {
                    if (textBoxCodCurso.Text == "" || textBoxCurso.Text == "" || textBoxCodDisciplina.Text == "") // verifica se todos os campos referente ao curso estão preenchidos.
                    {
                        MessageBox.Show("Por favor prencha todos os campos"); // se não preenchidos informa o usuario...
                        conexao.Close();
                    }
                    else // caso ok grava no banco
                    {
                        conexao.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCurso", conexao); // executa a busca no bd
                        SqlDataReader drd = cmd.ExecuteReader();
                        while (drd.Read())
                        {
                            if (textBoxCodCurso.Text == drd["CodCurso"].ToString())
                            {
                                Cadastrado = true;
                            }
                        }
                        drd.Close();
                        conexao.Close();
                        if (Cadastrado == true)
                        {
                            MessageBox.Show("Curso Já Cadastado!"); // se não preenchidos informa o usuario... 
                            Cadastrado = false;
                        }
                        else
                        {  
                            conexao.Open();
                            SqlCommand cmd0 = new SqlCommand
                                ("INSERT INTO tblCurso(CodCurso, Curso) VALUES('" + textBoxCodCurso.Text +
                                "','" + textBoxCurso.Text + "') SELECT SCOPE_IDENTITY();", conexao);
                            cmd0.CommandType = System.Data.CommandType.Text;
                            cmd0.Connection = conexao;
                            SqlDataReader reader = cmd0.ExecuteReader();
                            reader.Read();
                            IdCurso = int.Parse(reader[0].ToString());
                            conexao.Close(); // Encerra a Conexão com o banco

                            conexao.Open();
                            SqlCommand cmd1 = new SqlCommand
                               ("INSERT INTO tblCursoDisciplina(IdCurso, IdDisciplina) VALUES('" + IdCurso +
                               "','" + idDisciplina + "')", conexao);
                            cmd1.ExecuteNonQuery();
                            conexao.Close();
                            conexao.Open();
                            string SqlString = "SELECT tblDisciplina.IdDisciplina, tblDisciplina.CodDisciplina, tblDisciplina.Disciplina, tblDisciplina.Cor_R, tblDisciplina.Cor_G, tblDisciplina.Cor_B";
                            SqlString = SqlString + " FROM tblCursoDisciplina";
                            SqlString = SqlString + " INNER JOIN tblCurso ON tblCursoDisciplina.IdCurso = tblCurso.IdCurso";
                            SqlString = SqlString + " INNER JOIN tblDisciplina ON tblCursoDisciplina.IdDisciplina = tblDisciplina.IdDisciplina";
                            SqlString = SqlString + " WHERE(tblCursoDisciplina.IdCurso = " + IdCurso + ")";
                            SqlString = SqlString + " ORDER BY tblCursoDisciplina.IdCurso";

                            SqlCommand cmd3 = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                            cmd3.ExecuteNonQuery();      // executa cmd instanciado acima
                                                         //Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, 
                                                         //agora os passos seguintes irão exibir as informações para que o usuário possa vê-las
                            SqlDataAdapter da = new SqlDataAdapter(); // da, adapta o banco de dados ao nosso projeto 
                            DataSet ds = new DataSet();
                            da.SelectCommand = cmd3;     // adapta cmd ao projeto
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
                            column2.Width = 380;    // ...
                            grava_Curso = true;
                            //IdCurso = 0;
                        }
                    }
                }
                else // Se o curso ja foi gravado
                {
                    //Valida a disciplina
                    conexao.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblCursoDisciplina", conexao); // executa a busca no bd
                    SqlDataReader drd = cmd.ExecuteReader();

                    while (drd.Read())
                    {
                        if (IdCurso == int.Parse(drd["IdCurso"].ToString()) && idDisciplina == int.Parse(drd["IdDisciplina"].ToString()))
                        {
                            Cadastrado = true;
                        }
                    }
                    drd.Close();
                    conexao.Close();
                    if (Cadastrado == true || textBoxCodDisciplina.Text == "")
                    {
                        MessageBox.Show("Disciplina Já Cadastado ou ausente para este curso!"); // se não preenchidos informa o usuario... 
                        Cadastrado = false;
                    }
                    else // Se a disciplina não foi cadastrada
                    {
                        if (IdCurso > 0 && idDisciplina > 0)
                        {
                            conexao.Open();
                            SqlCommand cmd2 = new SqlCommand
                                ("INSERT INTO tblCursoDisciplina(IdCurso, IdDisciplina) VALUES('" + IdCurso + "','" + idDisciplina + "')", conexao);
                            cmd2.ExecuteNonQuery();
                            conexao.Close();
                            conexao.Open();
                            string SqlString = "SELECT tblDisciplina.IdDisciplina, tblDisciplina.CodDisciplina, tblDisciplina.Disciplina, tblDisciplina.Cor_R, tblDisciplina.Cor_G, tblDisciplina.Cor_B";
                            SqlString = SqlString + " FROM tblCursoDisciplina";
                            SqlString = SqlString + " INNER JOIN tblCurso ON tblCursoDisciplina.IdCurso = tblCurso.IdCurso";
                            SqlString = SqlString + " INNER JOIN tblDisciplina ON tblCursoDisciplina.IdDisciplina = tblDisciplina.IdDisciplina";
                            SqlString = SqlString + " WHERE(tblCursoDisciplina.IdCurso = " + IdCurso + ")";
                            SqlString = SqlString + " ORDER BY tblCursoDisciplina.IdCurso";

                            SqlCommand cmd3 = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                            cmd3.ExecuteNonQuery();      // executa cmd instanciado acima
                                                         //Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, 
                                                         //agora os passos seguintes irão exibir as informações para que o usuário possa vê-las
                            SqlDataAdapter da = new SqlDataAdapter(); // da, adapta o banco de dados ao nosso projeto 
                            DataSet ds = new DataSet();
                            da.SelectCommand = cmd3;     // adapta cmd ao projeto
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
                            column2.Width = 380;    // ...
                            grava_Curso = true;
                            //IdCurso = 0;
                            conexao.Close(); // Encerra a Conexão com o banco 

                        }
                        else // Valida preenchimento dos campos
                        {
                        MessageBox.Show("Dados não preenchidos");
                        conexao.Close();
                        } 
                    }  
                }
            }
            textBoxCodDisciplina.Text = "";
            comboBoxDisciplina.Text = "";
        }

        private void textBoxCodCurso_Enter(object sender, EventArgs e)
        {
            Conexao c = new Conexao();
            c.autocompletar(textBoxCodCurso, "tblCurso", "CodCurso");
        }

        private void textBoxCurso_Enter(object sender, EventArgs e)
        {
            Conexao c = new Conexao();
            c.autocompletar(textBoxCurso, "tblCurso", "Curso");
        }

        private void textBoxCodCurso_Leave(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCurso", conexao); // executa a busca no bd
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    if (textBoxCodCurso.Text == drd["CodCurso"].ToString())  // se encontrou a linha correspondente no banco
                    {
                        textBoxCurso.Text = drd["Curso"].ToString();
                        IdCurso = int.Parse(drd["IdCurso"].ToString());
                        salvo = true;
                        grava_Curso = true;
                    }
                }
                drd.Close();
                conexao.Close();
                conexao.Open();
                //string SqlString = "SELECT tblCursoDisciplina FROM tblCursoDisciplina"; // seleciona a tabela e os campo
                string SqlString = "SELECT tblDisciplina.IdDisciplina, tblDisciplina.CodDisciplina, tblDisciplina.Disciplina, tblDisciplina.Cor_R, tblDisciplina.Cor_G, tblDisciplina.Cor_B";
                SqlString = SqlString + " FROM tblCursoDisciplina";
                SqlString = SqlString + " INNER JOIN tblCurso ON tblCursoDisciplina.IdCurso = tblCurso.IdCurso";
                SqlString = SqlString + " INNER JOIN tblDisciplina ON tblCursoDisciplina.IdDisciplina = tblDisciplina.IdDisciplina";
                SqlString = SqlString + " WHERE(tblCursoDisciplina.IdCurso = " + IdCurso + ")";
                SqlString = SqlString + " ORDER BY tblCursoDisciplina.IdCurso";

                SqlCommand cmd3 = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                cmd3.ExecuteNonQuery();      // executa cmd instanciado acima
                                             //Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, 
                                             //agora os passos seguintes irão exibir as informações para que o usuário possa vê-las
                SqlDataAdapter da = new SqlDataAdapter(); // da, adapta o banco de dados ao nosso projeto 
                DataSet ds = new DataSet();
                da.SelectCommand = cmd3;     // adapta cmd ao projeto
                da.Fill(ds);                // preenche todas as informações dentro do DataSet                                          
                dataGridView1.DataSource = ds;                      //Datagridview recebe ds já preenchido
                dataGridView1.DataMember = ds.Tables[0].TableName;      //Agora Datagridview exibe o banco de dados

                this.dataGridView1.Columns["IdDisciplina"].Visible = false;   // Oculta o campo IdSala no Datagridview
                this.dataGridView1.Columns["Cor_R"].Visible = false;
                this.dataGridView1.Columns["Cor_G"].Visible = false;
                this.dataGridView1.Columns["Cor_B"].Visible = false;
                DataGridViewColumn column1 = dataGridView1.Columns[1];  // Instancias as colunas do Datagrid
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                column1.Name = "CÓDIGO";
                column1.Width = 75;     // limitamos o tamanho da coluna 1 do datagrid
                column2.Width = 380;    // ...
                conexao.Close(); // Encerra a Conexão com o banco
            }
        }

        private void textBoxCurso_Leave(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCurso", conexao); // executa a busca no bd
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    if (textBoxCurso.Text == drd["Curso"].ToString())  // se encontrou a linha correspondente no banco
                    {
                        textBoxCodCurso.Text = drd["CodCurso"].ToString();
                        IdCurso = int.Parse(drd["IdCurso"].ToString());
                        salvo = true;
                        grava_Curso = true;
                    }
                }
                drd.Close();
                conexao.Close();
                conexao.Open();
                string SqlString = "SELECT tblDisciplina.IdDisciplina, tblDisciplina.CodDisciplina, tblDisciplina.Disciplina, tblDisciplina.Cor_R, tblDisciplina.Cor_G, tblDisciplina.Cor_B";
                SqlString = SqlString + " FROM tblCursoDisciplina";
                SqlString = SqlString + " INNER JOIN tblCurso ON tblCursoDisciplina.IdCurso = tblCurso.IdCurso";
                SqlString = SqlString + " INNER JOIN tblDisciplina ON tblCursoDisciplina.IdDisciplina = tblDisciplina.IdDisciplina";
                SqlString = SqlString + " WHERE(tblCursoDisciplina.IdCurso = " + IdCurso + ")";
                SqlString = SqlString + " ORDER BY tblCursoDisciplina.IdCurso";

                SqlCommand cmd3 = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                cmd3.ExecuteNonQuery();      // executa cmd instanciado acima
                                             //Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, 
                                             //agora os passos seguintes irão exibir as informações para que o usuário possa vê-las
                SqlDataAdapter da = new SqlDataAdapter(); // da, adapta o banco de dados ao nosso projeto 
                DataSet ds = new DataSet();
                da.SelectCommand = cmd3;     // adapta cmd ao projeto
                da.Fill(ds);                // preenche todas as informações dentro do DataSet                                          
                dataGridView1.DataSource = ds;                      //Datagridview recebe ds já preenchido
                dataGridView1.DataMember = ds.Tables[0].TableName;      //Agora Datagridview exibe o banco de dados

                this.dataGridView1.Columns["IdDisciplina"].Visible = false;   // Oculta o campo IdSala no Datagridview
                this.dataGridView1.Columns["Cor_R"].Visible = false;
                this.dataGridView1.Columns["Cor_G"].Visible = false;
                this.dataGridView1.Columns["Cor_B"].Visible = false;
                DataGridViewColumn column1 = dataGridView1.Columns[1];  // Instancias as colunas do Datagrid
                DataGridViewColumn column2 = dataGridView1.Columns[2];
                column1.Name = "CÓDIGO";
                column1.Width = 75;     // limitamos o tamanho da coluna 1 do datagrid
                column2.Width = 380;    // ...
                conexao.Close(); // Encerra a Conexão com o banco
            }
        }

        private void frmCadCurso_Load(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblDisciplina", conexao);
            try
            {
                conexao.Open();                         // Abre a conexão
                drDisciplina = cmd.ExecuteReader();     // Le e carrega todos os valores para dr
                DataTable dt = new DataTable();         // Instancia uma copia da tabela
                dt.Load(drDisciplina);                  // Carrega os valores instanciado acima     
                comboBoxDisciplina.DisplayMember = "Disciplina"; // Seleciona apenas o campo disciplina
                comboBoxDisciplina.DataSource = dt;     // Mosta a lista de disciplinas no comboBox
                comboBoxDisciplina.Refresh();           // Atualiza o comboBox
                comboBoxDisciplina.Text = "";           //    
                textBoxCodDisciplina.Text = "";         //

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idDisciplina = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBoxCodDisciplina.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBoxDisciplina.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); //
            Cor_R = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            Cor_G = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            Cor_B = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            if (Cor_R == "")
            {
                Cor_R = "0";
                Cor_G = "0";
                Cor_B = "0";
            }
            alterar = true;
        }

        private void buttonMenos_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con);
            //DELETE FROM tblCursoDisciplina WHERE(IdCurso = 23) AND(IdDisciplina = 23)
            SqlCommand cmd = new SqlCommand(("DELETE FROM tblCursoDisciplina WHERE IdCurso= '" + IdCurso + "' AND IdDisciplina ='" + idDisciplina + "'"), conexao);
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
                cmd.ExecuteNonQuery(); // deleta valores do banco de dados
                textBoxCurso_Leave(sender, e); // Atualiza o DataGrid
                textBoxCodDisciplina.Text = "";
                comboBoxDisciplina.Text = ""; //
                alterar = false;
                conexao.Close();
            }

        }

        private void buttonGravar_Click_1(object sender, EventArgs e)
        {
            textBoxCodCurso.Text = "";
            textBoxCodDisciplina.Text = "";
            textBoxCurso.Text = "";
            comboBoxDisciplina.Text = "";

            //LIMPAR GRID
            dataGridView1.DataSource = null;    //Remove todas as tabelas
            dataGridView1.Refresh();            // atualiza
            dataGridView1.Rows.Clear();         // limpa todos os campo
            dataGridView1.Refresh();            // Atualiza

            salvo = true;       // identifica alteração em cada textBox do formulário
            grava_Curso = false;
            alterar = false;    // Identifica se o formulario foi preenchido ou importado para edição
            Cadastrado = false;
            idDisciplina = 0;         // Guarda o IdSala referente a linha das informações carregadas nos TextBox
            IdCurso = 0;
    }

        //***************************************************************************
        private void comboBoxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con);
            try
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message);
                throw;
            }
            finally
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDisciplina", conexao);
                DataRowView drw = ((DataRowView)comboBoxDisciplina.SelectedItem);
                textBoxCodDisciplina.Text = drw["CodDisciplina"].ToString();
                idDisciplina = int.Parse(drw["IdDisciplina"].ToString());

                conexao.Close();
            }
        }
        //********************************************************************************* 
    }
}
