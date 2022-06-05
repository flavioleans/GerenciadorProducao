using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BancoDeDados
{
    public class Buscar
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();
        public string msg = ""; //erro ou sucess
        MySqlDataReader reader;
        private int resultado;

        public int Consulta()
        {
            //comando sql
            cmd.Connection = conexao.Conectar();

            cmd.CommandText ="SELECT count(*) as t FROM bolinha where dia = @dia and mes = @mes and ano = @ano";
            cmd.Parameters.AddWithValue("@dia", DateTime.Now.Day);
            cmd.Parameters.AddWithValue("@mes", DateTime.Now.Month);
            cmd.Parameters.AddWithValue("@ano", DateTime.Now.Year);
            //cmd.Parameters.AddWithValue("@hora", DateTime.Now.Hour);
            //cmd.Parameters.AddWithValue("@min", DateTime.Now.Minute);

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    resultado = Convert.ToInt32(reader["t"]);
                }
            }


            return resultado;
            cmd.ExecuteNonQuery();
           // var resultdo = cmd.ExecuteScalar();

           
            
                 
            conexao.Desconectar();

            

        }
    }
}
