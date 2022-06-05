using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace BancoDeDados
{
   public class Conexao
    {
        MySqlConnection con = new MySqlConnection();

        // Metodo construtor
        public Conexao()
        {
            con.ConnectionString = "Server=mysql741.umbler.com;port=41890;Database=producaobolinha;Uid=lacuca;Pwd=lakuka1010";
        }

        // Metodo Conectar
        public MySqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        // Metodo Desconectar
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
