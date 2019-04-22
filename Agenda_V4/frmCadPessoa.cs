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
    public partial class frmCadPessoa : Form
    {
        SqlDataReader drDisciplina;
        public string Cor_R, Cor_G, Cor_B;
        public bool grava_Pessoa = false;
        public bool Cadastrado = false;
        public int IdUsuario = 0;
        public int idDisciplina = 0;
        public int IdCurso = 0;
        public bool Valido = true;
        public string erro;
        // Para o dataGrid
        DataTable tblDados = new DataTable();
        DataSet dsDados = new DataSet();
        public bool UsuarioGravado = false;

        public frmCadPessoa()
        {
            InitializeComponent();
        }
        // ok
       
        private void CarregaDataGrid()
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
            string SqlString = "SELECT tblDisciplina.IdDisciplina, tblDisciplina.Disciplina, tblDisciplina.CodDisciplina, tblDisciplina.Cor_R, tblDisciplina.Cor_G, tblDisciplina.Cor_B"; //
            SqlString = SqlString + " FROM tblDisciplinaUsuario";
            SqlString = SqlString + " INNER JOIN tblUsuario ON tblDisciplinaUsuario.IdUsuario = tblUsuario.IdUsuario"; //INNER JOIN tblUsuario ON tblDisciplinaUsuario.IdUsuario = tblUsuario.IdUsuario";
            SqlString = SqlString + " INNER JOIN tblDisciplina ON tblDisciplinaUsuario.IdDisciplina = tblDisciplina.IdDisciplina";//INNER JOIN tblDisciplina ON tblDisciplinaUsuario.IdDisciplina = tblDisciplina.IdDisciplina";
            SqlString = SqlString + " WHERE(tblDisciplinaUsuario.IdUsuario = " + IdUsuario + ")";//WHERE(tblDisciplinaUsuario.IdUsuario = " + IdUsuario + ")";
            SqlString = SqlString + " ORDER BY tblDisciplinaUsuario.IdUsuario";

            SqlCommand cmd3 = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                                                                  //SqlDataReader dr = cmd.ExecuteReader();

            cmd3.ExecuteNonQuery();      // executa cmd instanciado acima
                                         //Pronto após o cmd.ExecuteNonQuery(); selecionamos tudo o que tinha dentro do banco, 
                                         //agora os passos seguintes irão exibir as informações para que o usuário possa vê-las
            SqlDataAdapter da = new SqlDataAdapter();   // da, adapta o banco de dados ao nosso projeto 
            dsDados.Clear();
            //dataGridView1.Rows.Clear();
            da.SelectCommand = cmd3;                    // adapta cmd ao projeto
            da.Fill(dsDados);                           // preenche todas as informações dentro do DataSet                                          

            dataGridView1.DataSource = dsDados;                             //Datagridview recebe ds já preenchido
            dataGridView1.DataMember = dsDados.Tables[0].TableName;         //Agora Datagridview exibe o banco de dados
            dataGridView1.Update();
            
            conexao.Close();                                                 // Encerra a Conexão com o banco
        }
        
        private void checkBoxUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUsuario.Checked == true)
            {
                textBoxUsuario.Enabled = true;
                textBoxSenha.Enabled = true;
                checkBoxAdministrador.Enabled = true;
                labelUsuario.Enabled = true;
                labelSenha.Enabled = true;
            }
            else
            {
                textBoxUsuario.Enabled = false;
                textBoxSenha.Enabled = false;
                checkBoxAdministrador.Enabled = false;
                labelUsuario.Enabled = false;
                labelSenha.Enabled = false;
            }
        }

        private void frmCadPessoa_Load(object sender, EventArgs e)
        {
            checkBoxUsuario.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;      // impede a autogeração de colunas do DataGridView1
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDisciplina", conexao);
                drDisciplina = cmd.ExecuteReader();     // Le e carrega todos os valores para dr
                DataTable dt = new DataTable();         // Instancia uma copia da tabela
                dt.Load(drDisciplina);                  // Carrega os valores instanciado acima     
                comboBoxDisciplina.DisplayMember = "Disciplina"; // Seleciona apenas o campo disciplina
                comboBoxDisciplina.DataSource = dt;     // Mosta a lista de disciplinas no comboBox
                comboBoxDisciplina.Refresh();           // Atualiza o comboBox
                comboBoxDisciplina.Text = "";           //    
                pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
                conexao.Close();
            }
        }

        private void buttonMais_Click(object sender, EventArgs e)
        {
            Valido = true;
            erro = "";
           string Disciplina = "";
            if (comboBoxDisciplina.Text == "")
            {
                Valido = false;
                erro = "Selecione uma discicplina!";
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    DataGridViewCell cell = this.dataGridView1.Rows[i].Cells[0];
                    Disciplina = cell.Value.ToString();
                    if (Disciplina == comboBoxDisciplina.Text)
                    {
                        Valido = false;
                        erro = "Disciplina Já cadastradas para o Educador!";
                    }
                }
                if (Valido == false)
                {
                    MessageBox.Show(erro);
                }
                else
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
                        SqlCommand cmd = new SqlCommand("SELECT * FROM tblDisciplina", conexao); // executa a busca no b
                        SqlDataReader drd = cmd.ExecuteReader();
                        while (drd.Read())
                        {
                            if (comboBoxDisciplina.Text == drd["Disciplina"].ToString())  // se encontrou a linha correspondente no banco
                            {
                                idDisciplina = int.Parse(drd["IdDisciplina"].ToString());
                            }
                        }
                        drd.Close();
                        conexao.Close();
                        conexao.Open();
                        SqlCommand cmdi = new SqlCommand("SELECT * FROM tblUsuario", conexao); // executa a busca no b
                        SqlDataReader dri = cmdi.ExecuteReader();
                        while (dri.Read())
                        {
                            if (textBoxCracha.Text == dri["Cracha"].ToString())  // se encontrou a linha correspondente no banco
                            {
                                IdUsuario = int.Parse(dri["IdUsuario"].ToString());
                            }
                            else
                            {
                                IdUsuario = 0;
                            }
                        }
                        dri.Close(); 
                        if (IdUsuario == 0)
                        {
                            conexao.Close();
                            Valido = true;
                            UsuarioGravado = false;
                            buttonGravar_Click(sender, e); // grava o usuario
                            conexao.Open();
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO tblDisciplinaUsuario(IdUsuario, IdDisciplina) VALUES('" + IdUsuario + "','" + idDisciplina + "')", conexao);
                            cmd1.ExecuteNonQuery();
                            UsuarioGravado = true;
                        }
                        else
                        {
                            conexao.Close();
                            conexao.Open();
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO tblDisciplinaUsuario(IdUsuario, IdDisciplina) VALUES('" + IdUsuario + "','" + idDisciplina + "')", conexao);
                            cmd1.ExecuteNonQuery();
                            UsuarioGravado = true;
                        }
                        comboBoxDisciplina.Text = "";
                        CarregaDataGrid();
                    }
                }
            }
        }

        private void buttonGravar_Click(object sender, EventArgs e)
        {
            if (UsuarioGravado == true)
            {
                MessageBox.Show("Dados Gravados com sucesso");
                UsuarioGravado = false;
            }
            else
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsuario", conexao); // executa a busca no bd
                    SqlDataReader drd = cmd.ExecuteReader();
                    while (drd.Read())
                    {
                        if (textBoxCracha.Text == drd["Cracha"].ToString())
                        {

                            Valido = false;
                            erro = " Usuario já Cadastrado!";
                        }
                    }
                    drd.Close();
                    conexao.Close();
                }

                if ((textBoxNome.Text == "" || textBoxCracha.Text == "" || maskedTextBoxTelPrincipal.Text == ""
                        || textBoxEmailPrincipal.Text == "") && Valido == true)
                {
                    Valido = false;
                    erro = "Por Favor preencha todos os campo!";
                }
                else
                {
                    if (checkBoxUsuario.Checked == true)
                    {
                        if (textBoxUsuario.Text == "" || textBoxSenha.Text == "")
                        {
                            Valido = false;
                            erro = "Usuario ou senha não preenchido!";
                        }
                    }
                }
                if (Valido == false)
                {
                    MessageBox.Show(erro);
                }
                else //se todos os campo estão validos então grava
                {
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
                        SqlCommand cmd0 = new SqlCommand
                            ("INSERT INTO tblUsuario(Cracha, Nome, DtNascimento, DtAdmissao, Email_1, Email_2, Fone_1, Fone_2, Observacao, EInstrutor, EUsuario, EAdministrador, Usuario,  Cor_R, Cor_G, Cor_B) VALUES('"
                            + textBoxCracha.Text + "','" + textBoxNome.Text + "','" + dateTimePickerNascimento.Text.ToString() + "','" + dateTimePickerAdmissao.Text.ToString() + "','" + textBoxEmailPrincipal.Text + "','" + textBoxEmailSecundario.Text + "','" + maskedTextBoxTelPrincipal.Text +
                            "','" + maskedTextBoxTelSecundario.Text + "',Null ,'" + checkBoxInstrutor.Checked + "','" + checkBoxUsuario.Checked + "','" + checkBoxAdministrador.Checked + "','" + textBoxUsuario.Text + "','" + Cor_R + "','" + Cor_G + "','"
                            + Cor_B + "')", conexao);
                        cmd0.ExecuteNonQuery();

                        conexao.Close(); // Encerra a Conexão com o banco
                        conexao.Open();
                        SqlCommand cmdi = new SqlCommand("SELECT * FROM tblUsuario", conexao); // executa a busca no b
                        SqlDataReader dri = cmdi.ExecuteReader();
                        while (dri.Read())
                        {
                            if (textBoxCracha.Text == dri["Cracha"].ToString())  // se encontrou a linha correspondente no banco
                            {
                                IdUsuario = int.Parse(dri["IdUsuario"].ToString());
                            }
                            else
                            {
                                IdUsuario = 0;
                            }
                        }
                        dri.Close();
                        MessageBox.Show("Dados gravados com sucesso!");
                        Valido = true;
                    }
                }
            }
       }

        private void textBoxNome_Enter(object sender, EventArgs e)
        {
            Conexao c = new Conexao();
            c.autocompletar(textBoxNome, "tblUsuario", "Nome");
        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxNome.Text = "";
            textBoxCracha.Text = "";
            dateTimePickerNascimento.Text = "";
            dateTimePickerAdmissao.Text = "";
            maskedTextBoxTelPrincipal.Text = "";
            maskedTextBoxTelSecundario.Text = "";
            textBoxEmailPrincipal.Text = "";
            textBoxEmailSecundario.Text = "";
            checkBoxUsuario.Checked = false;
            checkBoxInstrutor.Checked = false;
            checkBoxAdministrador.Checked = false;
            checkBoxUsuarioDesativado.Checked = false;
            textBoxUsuario.Text = "";
            textBoxSenha.Text = "";
            comboBoxDisciplina.Text = "";
            grava_Pessoa = false;
            Cadastrado = false;
            IdUsuario = 0;
            idDisciplina = 0;
            IdCurso = 0;
            Valido = true;

            if (Cor_R != "0" || Cor_G != "0" || Cor_B != "0")
            {
                Cor_R = "0";
                Cor_G = "0";
                Cor_B = "0";
            }
            pictureBox1.BackColor = Color.FromArgb(int.Parse(Cor_R), int.Parse(Cor_G), int.Parse(Cor_B));
            IdUsuario = 0;
            CarregaDataGrid();
        }

        private void textBoxCracha_Leave(object sender, EventArgs e)
        {
            if (maskedTextBoxTelPrincipal.Text != "")
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblUsuario", conexao); // executa a busca no bd
                    SqlDataReader drd = cmd.ExecuteReader();
                    while (drd.Read())
                    {
                        if (textBoxCracha.Text == drd["Cracha"].ToString())  // se encontrou a linha correspondente no banco
                        {
                            IdUsuario = int.Parse(drd["IdUsuario"].ToString());
                            textBoxNome.Text = drd["Nome"].ToString();
                            dateTimePickerAdmissao.Text = Convert.ToString(drd["DtAdmissao"]);
                            dateTimePickerNascimento.Text = Convert.ToString(drd["DtNascimento"]);
                            maskedTextBoxTelPrincipal.Text = drd["Fone_1"].ToString();
                            maskedTextBoxTelSecundario.Text = drd["Fone_2"].ToString();
                            textBoxEmailPrincipal.Text = drd["Email_1"].ToString();
                            textBoxEmailSecundario.Text = drd["Email_2"].ToString();
                            pictureBox1.BackColor = Color.FromArgb(int.Parse(drd["Cor_R"].ToString()), int.Parse(drd["Cor_G"].ToString()), int.Parse(drd["Cor_B"].ToString()));
                            checkBoxAdministrador.Checked = Convert.ToBoolean(drd["EAdministrador"]);
                            checkBoxInstrutor.Checked = Convert.ToBoolean(drd["EInstrutor"]);
                            checkBoxUsuario.Checked = Convert.ToBoolean(drd["EUsuario"]);
                            textBoxUsuario.Text = drd["Usuario"].ToString();
                            textBoxSenha.Text = drd["Senha"].ToString();
                            UsuarioGravado = true;
                        }
                    }
                    CarregaDataGrid();
                }
            }
        }

        private void textBoxCracha_Enter(object sender, EventArgs e)
        {
           Conexao c = new Conexao();
           c.autocompletar(textBoxCracha, "tblUsuario", "Cracha");
        }

        private void buttonMenos_Click(object sender, EventArgs e)
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
               SqlCommand cmd = new SqlCommand("DELETE FROM tblDisciplinaUsuario WHERE(IdUsuario = '" + IdUsuario + "')  AND(IdDisciplina = '" + idDisciplina + "')", conexao);
                cmd.ExecuteNonQuery();      // executa cmd instanciado acima
            }
            comboBoxDisciplina.Text = "";
            Valido = true;
            CarregaDataGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBoxDisciplina.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            idDisciplina = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());

        }

        private void checkBoxUsuarioDesativado_CheckedChanged(object sender, EventArgs e)
        {
          if (checkBoxUsuarioDesativado.Checked == true)
           {

               textBoxUsuario.Enabled = false;
               textBoxSenha.Enabled = false;
               checkBoxAdministrador.Enabled = false;
               pictureBox1.Enabled = false;
               textBoxEmailPrincipal.Enabled = false;
               textBoxEmailSecundario.Enabled = false;
               maskedTextBoxTelPrincipal.Enabled = false;
               maskedTextBoxTelSecundario.Enabled = false;
                dateTimePickerAdmissao.Enabled = false;
                dateTimePickerNascimento.Enabled = false;
               textBoxCracha.Enabled = false;
               textBoxNome.Enabled = false;
               checkBoxInstrutor.Enabled = false;
               checkBoxUsuario.Enabled = false;
               buttonMais.Enabled = false;
               buttonMenos.Enabled = false;
                buttonCor.Enabled = false;
                comboBoxDisciplina.Enabled = false;
           }
           else
           {
               textBoxUsuario.Enabled = true;
               textBoxSenha.Enabled = true;
               pictureBox1.Enabled = true;
               textBoxEmailPrincipal.Enabled = true;
               textBoxEmailSecundario.Enabled = true;
               maskedTextBoxTelPrincipal.Enabled = true;
               maskedTextBoxTelSecundario.Enabled = true;
               dateTimePickerAdmissao.Enabled = true;
               dateTimePickerNascimento.Enabled = true;
               textBoxCracha.Enabled = true;
               textBoxNome.Enabled = true;
               checkBoxInstrutor.Enabled = true;
               checkBoxUsuario.Enabled = true;
               buttonMais.Enabled = true;
               buttonMenos.Enabled = true;
                buttonCor.Enabled = true; ;
                comboBoxDisciplina.Enabled = true;
            }
        }

        private void checkBoxInstrutor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInstrutor.Checked == true)
            {
                labelCorInstrutor.Enabled = true;
                buttonCor.Enabled = true;
                pictureBox1.Enabled = true;
                labelDisciplina.Enabled = true;
                comboBoxDisciplina.Enabled = true;
                dataGridView1.Enabled = true;
                buttonMais.Enabled = true;
                buttonMenos.Enabled = true;
            }
            else
            {
                labelCorInstrutor.Enabled = false;
                buttonCor.Enabled = false;
                pictureBox1.Enabled = false;
                labelDisciplina.Enabled = false;
                comboBoxDisciplina.Enabled = false;
                dataGridView1.Enabled = false;
                buttonMais.Enabled = false;
                buttonMenos.Enabled = false;
            }
       
        }

        private void buttonCor_Click_1(object sender, EventArgs e)
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
