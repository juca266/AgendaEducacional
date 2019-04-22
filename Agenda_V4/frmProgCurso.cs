using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda_V4
{
    public partial class frmProgCurso : Form
    {
        SqlDataReader drCurso;
        SqlDataReader drSala;
        SqlDataReader drDisciplina;
        SqlDataReader drInstrutor;
        SqlDataReader drbuscaBanco;
        public int IdCurso = 0;
        public int IdDisciplina = 0;
        public int IdInstrutor = 0;
        public int IdSala = 0;
        public int Idprogramacao = 0;
        public bool gravado = false;
        public int Id = 0;

        public frmProgCurso()
        {
            InitializeComponent();
        }
       
        public void GravaProgramacao()
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
            try                                         // tenta executar
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)                    // Se não conectou
            {
                MessageBox.Show("Erro ao gravar a programação" + ex.Message);
                throw;
            }
            finally                                 //Se conectou então finaliza
            {
                if(textBoxLocal.Text == "")
                {
                    textBoxLocal.Text = "Null";
                }
                if(textBoxEndereço.Text == "")
                {
                    textBoxEndereço.Text = "Null";
                }
                SqlCommand cmd = new SqlCommand
                ("INSERT INTO tblProgramacao(NTurma, IdCurso, Turno, CargaHorarioCurso, DataInicioCurso, DataFimCurso,  LocalCurso, EnderecoCurso, InternoExterno )" +
                 "VALUES('" + textBoxTurma.Text + "','" + IdCurso + "','" + comboBoxTurno.Text + "','" + textBoxCargaHoraria.Text + "','" + dateTimePickerDataInicio.Value + 
                 "','" + dateTimePickerDataFim.Text.ToString() + "','"  + textBoxLocal.Text + "','" + textBoxEndereço.Text + "','" + radioButtonInterno.Checked +
                 "') SELECT SCOPE_IDENTITY()", conexao);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = conexao;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Idprogramacao = int.Parse(reader[0].ToString());
                conexao.Close(); // Encerra a Conexão com o banco
            }
        }

        public void gravaSala()
        {
            string campo = comboBoxSala.Text;
            SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
            try                                         // tenta executar
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)                    // Se não conectou
            {
                MessageBox.Show("Erro ao Gravar a Sala " + ex.Message);
                throw;
            }
            finally                                 //Se conectou então finaliza
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblSalaProgramacao(IdProgramacao, IdSala) VALUES('" + Idprogramacao + "','" + IdSala +"')", conexao);
                cmd.ExecuteNonQuery();
                conexao.Close(); // Encerra a Conexão com o banco
            }
        }

        public void gravaDisciplina()
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
            try                                         // tenta executar
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)                    // Se não conectou
            {
                MessageBox.Show("Erro ao gravar a Disciplina " + ex.Message);
                throw;
            }
            finally                                 //Se conectou então finaliza
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblProgramacaoDisciplina(IdDisciplina, IdProgramacao, DataInicio, DataTermino, Segunda, Terca, Quarta, Quinta, Sexta, Sabado, Domingo)" +
                    "VALUES('" + IdDisciplina + "','" + Idprogramacao + "','"+ dateTimePickerInicioDisciplina.Text + "','" + dateTimePickerTerminoDisciplina.Text + "','" +
                    checkBoxSDisciplina.Checked + "','" + checkBoxtDisciplina.Checked + "','" + checkBoxQDisciplina.Checked + "','" + checkBoxQiDisciplina.Checked+ "','" +
                    checkBoxSDisciplina.Checked + "','" + checkBoxSaDisciplina.Checked + "','" +checkBoxDDisciplina.Checked +"')", conexao);
                cmd.ExecuteNonQuery();
                conexao.Close(); // Encerra a Conexão com o banco
                gravaDuracaoDisciplina();
            }
        }

        public void gravaDuracaoDisciplina()
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
            try                                         // tenta executar
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)                    // Se não conectou
            {
                MessageBox.Show("Erro ao gravar a Disciplina " + ex.Message);
                throw;
            }
            finally                                 //Se conectou então finaliza
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblDuracaoDisciplina(IdDisciplina, IdProgramacao, Duracao)" +
                    "VALUES('" + IdDisciplina + "','" + Idprogramacao + "','" + textBoxDuracaoDisciplina.Text + "')", conexao);
                cmd.ExecuteNonQuery();
                conexao.Close(); // Encerra a Conexão com o banco
            }
        }

        public void gravaInstrutor()
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
            try                                         // tenta executar
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)                    // Se não conectou
            {
                MessageBox.Show("Erro ao gravar a Disciplina " + ex.Message);
                throw;
            }
            finally                                 //Se conectou então finaliza
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblProgramacaoInstrutor(IdUsuario, IdProgramacao, DataInicio, DataTermino, Segunda, Terca, Quarta, Quinta, Sexta, Sabado, Domingo)" +
                    "VALUES('" + IdInstrutor + "','" + Idprogramacao + "','" + dateTimePickerInicioInstrutor.Text.ToString() + "','" + dateTimePickerTerminoInstrutor.Text.ToString() + "','" 
                    + checkBoxSInstrutor.Checked + "','" + checkBoxTInstrutor.Checked + "','" + checkBoxQInstrutor.Checked + "','" + checkBoxQiInstrutor.Checked + "','" 
                    + checkBoxSInstrutor.Checked + "','" + checkBoxSaInstrutor.Checked + "','" + checkBoxDInstrutor.Checked + "')", conexao);
                cmd.ExecuteNonQuery();
                conexao.Close(); // Encerra a Conexão com o banco
                gravaDuracaoInstrutor();
            }
        }

        public void gravaDuracaoInstrutor()
        {
            SqlConnection conexao = new SqlConnection(Conexao.Con); // string de Conexão
            try                                         // tenta executar
            {
                conexao.Open();                     // Abre a conexão
            }
            catch (Exception ex)                    // Se não conectou
            {
                MessageBox.Show("Erro ao gravar a Disciplina " + ex.Message);
                throw;
            }
            finally                                 //Se conectou então finaliza
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblDuracaoInstrutor(IdUsuario, IdProgramacao, Duracao)" +
                    "VALUES('" + IdInstrutor + "','" + Idprogramacao + "','" + textBoxDuracaoInstrutor.Text + "')", conexao);
                cmd.ExecuteNonQuery();
                conexao.Close(); // Encerra a Conexão com o banco
            }
        }

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
            string SqlString = "SELECT tblProgramacao.IdProgramacao, tblProgramacao.NTurma, tblProgramacao.CargaHorarioCurso, tblProgramacao.DataInicioCurso, tblProgramacao.DataFimCurso, " +
                         "tblProgramacao.HoraFimCurso, tblProgramacao.InternoExterno, tblProgramacao.LocalCurso, tblProgramacao.EnderecoCurso, tblProgramacao.IdCurso, " +
                         "tblProgramacao.Turno, tblProgramacaoInstrutor.IdProgramacaoInstrutor, tblProgramacaoInstrutor.IdProgramacao, tblProgramacaoInstrutor.IdUsuario, " +
                         "tblProgramacaoInstrutor.DataInicio, tblProgramacaoInstrutor.DataTermino, tblProgramacaoInstrutor.Segunda, tblProgramacaoInstrutor.Terca, " +
                         "tblProgramacaoInstrutor.Quarta, tblProgramacaoInstrutor.Quinta, tblProgramacaoInstrutor.Sexta, tblProgramacaoInstrutor.Sabado, tblProgramacaoInstrutor.Domingo, " +
                         "tblUsuario.Nome, tblUsuario.IdUsuario, tblDisciplina.Disciplina, tblDisciplina.Cor_R, tblDisciplina.Cor_G, tblDisciplina.Cor_B, tblDisciplina.IdDisciplina, " +
                         "tblDisciplina.CodDisciplina " +
            "FROM tblProgramacao INNER JOIN " +
                         "tblProgramacaoInstrutor ON tblProgramacao.IdProgramacao = tblProgramacaoInstrutor.IdProgramacao INNER JOIN " +
                         "tblUsuario ON tblProgramacaoInstrutor.IdUsuario = tblUsuario.IdUsuario CROSS JOIN " +
                         "tblDisciplina "+
            "WHERE(tblProgramacao.IdProgramacao = " + Idprogramacao + ")";
                
                
                /*"SELECT tblProgramacao.IdProgramacao, tblProgramacao.NTurma, tblProgramacao.CargaHorarioCurso, tblProgramacao.DataInicioCurso, tblProgramacao.DataFimCurso," +
                         "tblProgramacao.HoraFimCurso, tblProgramacao.InternoExterno, tblProgramacao.LocalCurso, tblProgramacao.EnderecoCurso, tblProgramacao.IdCurso," +
                         "tblProgramacaoInstrutor.IdUsuario, tblProgramacaoInstrutor.DataInicio, tblProgramacaoInstrutor.DataTermino, tblProgramacaoInstrutor.Segunda," +
                         "tblProgramacaoInstrutor.Terca, tblProgramacaoInstrutor.Quarta, tblProgramacaoInstrutor.Quinta, tblProgramacaoInstrutor.Sexta, tblProgramacaoInstrutor.Sabado," +
                         "tblProgramacaoInstrutor.Domingo, tblUsuario.Nome, tblProgramacaoDisciplina.IdDisciplina," +
                         "tblProgramacaoDisciplina.IdProgramacaoDisciplina, tblProgramacaoDisciplina.IdProgramacao, tblProgramacaoDisciplina.DataInicio, " +
                         "tblProgramacaoDisciplina.DataTermino, tblProgramacaoDisciplina.Segunda, tblProgramacaoDisciplina.Terca, tblProgramacaoDisciplina.Quarta, " +
                         "tblProgramacaoDisciplina.Quinta, tblProgramacaoDisciplina.Sexta, tblProgramacaoDisciplina.Sabado, tblProgramacaoDisciplina.Domingo, tblDisciplina.IdDisciplina, " +
                         "tblDisciplina.CodDisciplina, tblDisciplina.Cor_R, tblDisciplina.Cor_G, tblDisciplina.Disciplina, tblDisciplina.Cor_B " +
                        "FROM tblProgramacao INNER JOIN tblProgramacaoInstrutor ON tblProgramacao.IdProgramacao = tblProgramacaoInstrutor.IdProgramacao INNER JOIN " +
                         "tblUsuario ON tblProgramacaoInstrutor.IdUsuario = tblUsuario.IdUsuario INNER JOIN " +
                         "tblProgramacaoDisciplina ON tblProgramacao.IdProgramacao = tblProgramacaoDisciplina.IdProgramacao INNER JOIN " +
                         "tblDisciplina ON tblProgramacaoDisciplina.IdDisciplina = tblDisciplina.IdDisciplina " +
                        "WHERE(tblProgramacao.IdProgramacao = "+ Idprogramacao + ") ORDER BY tblProgramacao.IdProgramacao";*/


            SqlCommand cmd3 = new SqlCommand(SqlString, conexao); //instancia cmd que possui mais de um parâmetro,
                                                                  //SqlDataReader dr = cmd.ExecuteReader();

            SqlDataAdapter da = new SqlDataAdapter();   // da, adapta o banco de dados ao nosso projeto 
            DataSet dsDados = new DataSet();
            dsDados.Clear();
            dataGridView1.Update();
            da.SelectCommand = cmd3;                    // adapta cmd ao projeto

            da.Fill(dsDados);                           // preenche todas as informações dentro do DataSet                                          

            dataGridView1.DataSource = dsDados;                             //Datagridview recebe ds já preenchido
            dataGridView1.DataMember = dsDados.Tables[0].TableName;         //Agora Datagridview exibe o banco de dados

            dataGridView1.Update();
            conexao.Close();                                                 // Encerra a Conexão com o banco
        }

        private void buscaBanco(string tabela)
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM " + tabela, conexao); // executa a busca no bd
                drbuscaBanco = cmd.ExecuteReader();
                while (drbuscaBanco.Read())
                {
                    if (textBoxTurma.Text == drbuscaBanco["NTurma"].ToString())  // se encontrou a linha correspondente no banco
                    {
                        textBoxTurma.Text = drbuscaBanco["NTurma"].ToString();
                        Idprogramacao = int.Parse(drbuscaBanco["IdProgramacao"].ToString());
                        gravado = true;
                    }
                }
                conexao.Close();
                drbuscaBanco.Close();
            }
        }

        private void limpaForm()
        {
            textBoxTurma.Text = "";
            textBoxCodCurso.Text = "";
            comboBoxSelecioneCurso.Text = "";
            comboBoxTurno.Text = "";
            textBoxCargaHoraria.Text = "";
            radioButtonInterno.Checked = true;
            comboBoxSala.Text = "";
            textBoxLocal.Text = "";
            textBoxEndereço.Text = "";
            textBoxCodDisciplina.Text = "";
            comboBoxDiscipllina.Text = "";
            textBoxDuracaoDisciplina.Text = "";
            checkBoxSDisciplina.Checked = false;
            checkBoxtDisciplina.Checked = false;
            checkBoxQDisciplina.Checked = false;
            checkBoxQiDisciplina.Checked = false;
            checkBoxSxDisciplina.Checked = false;
            checkBoxSaDisciplina.Checked = false;
            checkBoxDDisciplina.Checked = false;
            textBoxInstrutor.Text = "";
            comboBoxCracha.Text = "";
            textBoxDuracaoInstrutor.Text = "";
            checkBoxSInstrutor.Checked = false;
            checkBoxTInstrutor.Checked = false;
            checkBoxQiInstrutor.Checked = false;
            checkBoxQiInstrutor.Checked = false;
            checkBoxSInstrutor.Checked = false;
            checkBoxSxInstrutor.Checked = false;
            checkBoxDInstrutor.Checked = false;
            IdCurso = 0;
            IdDisciplina = 0;
            IdInstrutor = 0;
            IdSala = 0;
            Idprogramacao = 0;
            CarregaDataGrid();
        }

        private void radioButtonInterno_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonInterno.Checked == true)
            {
                labelSala.Enabled = true;
                comboBoxSala.Enabled = true;
                labelEndereço.Enabled = false;
                textBoxEndereço.Enabled = false;
                labelInformeLocal.Enabled = false;
                textBoxLocal.Enabled = false;
            }
            else
            {
                labelSala.Enabled = false;
                comboBoxSala.Enabled = false;
                labelEndereço.Enabled = true;
                textBoxEndereço.Enabled = true;
                labelInformeLocal.Enabled = true;
                textBoxLocal.Enabled = true;
            }
        }

        private void frmProgCurso_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;      // impede a autogeração de colunas do DataGridView1
            radioButtonInterno.Checked = true;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblCurso", conexao);
                drCurso = cmd.ExecuteReader();     // Le e carrega todos os valores para dr
                DataTable dt = new DataTable();         // Instancia uma copia da tabela
                dt.Load(drCurso);                  // Carrega os valores instanciado acima     
                comboBoxSelecioneCurso.DisplayMember = "Curso"; // Seleciona apenas o campo disciplina
                comboBoxSelecioneCurso.DataSource = dt;     // Mosta a lista de disciplinas no comboBox
                comboBoxSelecioneCurso.Refresh();           // Atualiza o comboBox
                comboBoxSelecioneCurso.Text = "";           //    
                conexao.Close();

                conexao.Open();
                SqlCommand cmds = new SqlCommand("SELECT * FROM tblSala", conexao);
                drSala = cmds.ExecuteReader();     // Le e carrega todos os valores para dr
                DataTable dts = new DataTable();         // Instancia uma copia da tabela
                dts.Load(drSala);                  // Carrega os valores instanciado acima     
                comboBoxSala.DisplayMember = "NSala"; // Seleciona apenas o campo disciplina
                comboBoxSala.DataSource = dts;     // Mosta a lista de disciplinas no comboBox
                comboBoxSala.Refresh();           // Atualiza o comboBox
                comboBoxSala.Text = "";           //    
                conexao.Close();

                conexao.Open();
                SqlCommand cmdd = new SqlCommand("SELECT * FROM tblDisciplina", conexao);
                drDisciplina = cmdd.ExecuteReader();     // Le e carrega todos os valores para dr
                DataTable dtd = new DataTable();         // Instancia uma copia da tabela
                dtd.Load(drDisciplina);                  // Carrega os valores instanciado acima     
                comboBoxDiscipllina.DisplayMember = "Disciplina"; // Seleciona apenas o campo disciplina
                comboBoxDiscipllina.DataSource = dtd;     // Mosta a lista de disciplinas no comboBox
                comboBoxDiscipllina.Refresh();           // Atualiza o comboBox
                comboBoxDiscipllina.Text = "";           //    
                conexao.Close();

                conexao.Open();
                SqlCommand cmdi = new SqlCommand("SELECT * FROM tblUsuario WHERE(DtDemissao IS NULL) AND (EInstrutor = 1)", conexao); // 

                drInstrutor = cmdi.ExecuteReader();     // Le e carrega todos os valores para dr
                DataTable dti = new DataTable();         // Instancia uma copia da tabela
                dti.Load(drInstrutor);                  // Carrega os valores instanciado acima     
                comboBoxCracha.DisplayMember = "Cracha"; // Seleciona apenas o campo disciplina
                comboBoxCracha.DataSource = dti;     // Mosta a lista de disciplinas no comboBox
                comboBoxCracha.Refresh();           // Atualiza o comboBox
                comboBoxCracha.Text = "";           //    
                conexao.Close();
            }
            limpaForm(); // limpa o formulario
        }

        private void comboBoxSelecioneCurso_SelectedIndexChanged(object sender, EventArgs e)
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
                SqlCommand cmdc = new SqlCommand("SELECT * FROM tblCurso", conexao); // executa a busca no bd
                SqlDataReader drc = cmdc.ExecuteReader();
                while (drc.Read())
                {
                    if (comboBoxSelecioneCurso.Text == drc["Curso"].ToString())  // se encontrou a linha correspondente no banco
                    {
                        textBoxCodCurso.Text = drc["CodCurso"].ToString();
                        IdCurso = int.Parse(drc["IdCurso"].ToString());
                    }
                }
                drc.Close();
                conexao.Close();
            }
        }

        private void comboBoxDiscipllina_SelectedIndexChanged(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblDisciplina", conexao); // executa a busca no bd
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    if (comboBoxDiscipllina.Text == drd["Disciplina"].ToString())  // se encontrou a linha correspondente no banco
                    {
                        textBoxCodDisciplina.Text = drd["CodDisciplina"].ToString();
                        IdDisciplina = int.Parse(drd["IdDisciplina"].ToString());
                    }
                }
                drd.Close();
                conexao.Close();
            }
        }

        private void comboBoxSala_SelectedIndexChanged(object sender, EventArgs e)
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
                SqlCommand cmds = new SqlCommand("SELECT * FROM tblSala", conexao); // executa a busca no bd
                SqlDataReader drs = cmds.ExecuteReader();
                while (drs.Read())
                {
                    if (comboBoxSala.Text == drs["NSala"].ToString())  // se encontrou a linha correspondente no banco
                    {
                        IdSala = int.Parse(drs["IdSala"].ToString());
                    }
                }
                drs.Close();
                conexao.Close();
            }
        }

        private void buttonNovaTurma_Click(object sender, EventArgs e)
        {
            limpaForm();

        }

        private void comboBoxCracha_SelectedIndexChanged(object sender, EventArgs e)
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
                SqlCommand cmdi = new SqlCommand("SELECT * FROM tblUsuario", conexao); // executa a busca no bd
                SqlDataReader dri = cmdi.ExecuteReader();
                while (dri.Read())
                {
                    if (comboBoxCracha.Text == dri["Cracha"].ToString())  // se encontrou a linha correspondente no banco
                    {
                        textBoxInstrutor.Text = dri["Nome"].ToString();
                        IdInstrutor = int.Parse(dri["IdUsuario"].ToString());
                    }
                }
                dri.Close();
                conexao.Close();
            }
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            buscaBanco("tblProgramacao");
            if (textBoxCodCurso.Text == "" || comboBoxSelecioneCurso.Text == "" || comboBoxTurno.Text == "" || textBoxCargaHoraria.Text == "" ||
                comboBoxDiscipllina.Text == "" || textBoxDuracaoDisciplina.Text == "" || comboBoxCracha.Text == "")
            {
                MessageBox.Show("Por favor preencha todos os campo!");
            }
            else
            {
                if (Idprogramacao == 0)
                {
                    GravaProgramacao();
                    if (radioButtonInterno.Checked == true)
                    {
                        gravaSala();
                    }
                    gravaDisciplina();
                    gravaInstrutor();
                    CarregaDataGrid();
                }
                else
                {
                    gravaDisciplina();
                    gravaInstrutor();
                    CarregaDataGrid();
                }
            }
        }

        private void textBoxTurma_Enter(object sender, EventArgs e)
        {
            Conexao c = new Conexao();
            c.autocompletar(textBoxTurma, "tblProgramacao", "NTurma");
        }

        private void textBoxTurma_Leave(object sender, EventArgs e)
        {
            if(textBoxCodCurso.Text == "")
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
                    string SqlString = "SELECT tblProgramacao.IdProgramacao, tblProgramacao.NTurma, tblProgramacao.CargaHorarioCurso, " +
                         "tblProgramacao.DataInicioCurso, tblProgramacao.DataFimCurso, tblProgramacao.Turno, tblProgramacao.HoraFimCurso, " +
                         "tblProgramacao.InternoExterno, tblProgramacao.LocalCurso, tblProgramacao.EnderecoCurso, tblProgramacao.IdCurso, " +
                         "tblSalaProgramacao.IdProgramacao, tblSalaProgramacao.IdSala, tblSala.NSala, tblSala.TipoRecurso, tblSala.IdSala, " +
                         "tblSala.Capacidade, tblDuracaoInstrutor.IdProgramacao, tblDuracaoInstrutor.IdUsuario, " +
                         "tblDuracaoInstrutor.Duracao, tblDuracaoInstrutor.IdDuracaoInstrutor, tblDuracaoDisciplina.IdProgramacao, " +
                         "tblDuracaoDisciplina.IdDisciplina, tblDuracaoDisciplina.Duracao, tblDuracaoDisciplina.IdDuracaoDisciplina, " +
                         "tblProgramacaoDisciplina.IdProgramacaoDisciplina, tblProgramacaoDisciplina.IdProgramacao, " +
                         "tblProgramacaoDisciplina.IdDisciplina, tblProgramacaoDisciplina.DataInicio, tblProgramacaoDisciplina.DataTermino, " +
                         "tblProgramacaoDisciplina.Segunda, tblProgramacaoDisciplina.Terca, tblProgramacaoDisciplina.Quarta, " +
                         "tblProgramacaoDisciplina.Quinta, tblProgramacaoDisciplina.Sexta, tblProgramacaoDisciplina.Sabado, " +
                         "tblProgramacaoDisciplina.Domingo, tblProgramacaoInstrutor.IdProgramacaoInstrutor, tblProgramacaoInstrutor.IdProgramacao, " +
                         "tblProgramacaoInstrutor.IdUsuario, tblProgramacaoInstrutor.DataInicio, tblProgramacaoInstrutor.DataTermino, " +
                         "tblProgramacaoInstrutor.Segunda, tblProgramacaoInstrutor.Terca, tblProgramacaoInstrutor.Quarta, " +
                         "tblProgramacaoInstrutor.Quinta, tblProgramacaoInstrutor.Sexta, tblProgramacaoInstrutor.Sabado, " +
                         "tblProgramacaoInstrutor.Domingo, tblUsuario.IdUsuario, tblUsuario.Cracha, tblUsuario.Nome, tblUsuario.DtNascimento, " +
                         "tblUsuario.DtAdmissao, tblUsuario.DtDemissao, tblUsuario.DtAtualizacao, tblUsuario.Email_1, tblUsuario.Email_2, tblUsuario.Fone_1, tblUsuario.Fone_2, " +
                         "tblUsuario.Observacao, tblUsuario.EInstrutor, tblUsuario.EUsuario, tblUsuario.EAdministrador, tblUsuario.Usuario, tblUsuario.Senha, tblUsuario.Cor_R, " +
                         "tblUsuario.Cor_G, tblUsuario.Cor_B, tblDisciplina.IdDisciplina, tblDisciplina.CodDisciplina, tblDisciplina.Disciplina, tblDisciplina.Cor_R, " +
                         "tblDisciplina.Cor_G, tblDisciplina.Cor_B, tblCurso.IdCurso, tblCurso.CodCurso, tblCurso.Curso " +
                    "FROM tblProgramacao INNER JOIN " +
                         "tblSalaProgramacao ON tblProgramacao.IdProgramacao = tblSalaProgramacao.IdProgramacao INNER JOIN " +
                         "tblSala ON tblSalaProgramacao.IdSala = tblSala.IdSala INNER JOIN " +
                         "tblDuracaoInstrutor ON tblProgramacao.IdProgramacao = tblDuracaoInstrutor.IdProgramacao INNER JOIN " +
                         "tblDuracaoDisciplina ON tblProgramacao.IdProgramacao = tblDuracaoDisciplina.IdProgramacao INNER JOIN " +
                         "tblProgramacaoDisciplina ON tblProgramacao.IdProgramacao = tblProgramacaoDisciplina.IdProgramacao INNER JOIN " +
                         "tblProgramacaoInstrutor ON tblProgramacao.IdProgramacao = tblProgramacaoInstrutor.IdProgramacao INNER JOIN " +
                         "tblUsuario ON tblDuracaoInstrutor.IdUsuario = tblUsuario.IdUsuario INNER JOIN " +
                         "tblDisciplina ON tblDuracaoDisciplina.IdDisciplina = tblDisciplina.IdDisciplina INNER JOIN " +
                         "tblCurso ON tblProgramacao.IdCurso = tblCurso.IdCurso " +
                    "WHERE(tblProgramacao.NTurma = " + textBoxTurma.Text + ")";

                    SqlCommand cmd = new SqlCommand(SqlString, conexao); // executa a busca no bd
                    SqlDataReader drd = cmd.ExecuteReader();
                    while (drd.Read())
                     {
                         if (textBoxTurma.Text == drd["NTurma"].ToString())  // se encontrou a linha correspondente no banco
                         {
                            Idprogramacao = int.Parse(drd["IdProgramacao"].ToString());
                            textBoxTurma.Text = drd["NTurma"].ToString();
                            textBoxCodCurso.Text = drd["CodCurso"].ToString();
                            comboBoxSelecioneCurso.Text = drd["Curso"].ToString();
                            comboBoxTurno.Text = drd["Turno"].ToString();
                            dateTimePickerDataFim.Text = Convert.ToString(drd["DataInicioCurso"]);
                            dateTimePickerDataInicio.Text = Convert.ToString(drd["DataFimCurso"]);
                            textBoxCargaHoraria.Text = drd["CargaHorarioCurso"].ToString();
                            radioButtonInterno.Checked = Convert.ToBoolean(drd["InternoExterno"]);
                            comboBoxSala.Text = drd["NSala"].ToString();
                            textBoxLocal.Text = drd["LocalCurso"].ToString();
                            textBoxEndereço.Text = drd["EnderecoCurso"].ToString();
                            IdCurso = int.Parse(drd["IdCurso"].ToString());
                            IdSala = int.Parse(drd["IdSala"].ToString());
                        }
                    }
                    CarregaDataGrid();
                }
            }
        }
    }
}
