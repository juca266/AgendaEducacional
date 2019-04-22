using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Agenda_V4
{
    class Conexao
    {
        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public static string CaminhoBD = @"C:\Users\Jurema\Downloads\Agenda_V4x\Agenda_V4\BancoAgenda_V4.mdf;Integrated Security=True;Connect Timeout=30";
        public static string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jurema\Downloads\Agenda_V4x\Agenda_V4\BancoAgenda_V4.mdf;Integrated Security = True; Connect Timeout = 30";
        public Conexao()
        { 
             try
                {
                    cnn = new SqlConnection(Con);
                    cnn.Open();
                }   
             catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel conectar ao Banco de dados:" + ex.ToString());
                }
        }

        //***********************************************************************************************************************
        // FUNÇÃO AUTOCOMPLETAR
        // RECEBE: O campo da pesquisa (cod), 
        // A tabela a ser pesquisada
        // Os campo de retorno e pesquisa na tabela
        //*************************************************************************************
        public void autocompletar(TextBox Cod, string tabela, string campo)
        {

            try
            {
                cmd = new SqlCommand("SELECT * FROM " + tabela, cnn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cod.AutoCompleteCustomSource.Add(dr[campo.ToString()].ToString());
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha no autocompletar" + ex.ToString());
            }
        }
    }
}