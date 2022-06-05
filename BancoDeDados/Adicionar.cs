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
    public class Db
    {
        Conexao conexao = new Conexao();
        MySqlCommand cmd = new MySqlCommand();
        public string msg = ""; //erro ou sucess

        public void Adicionar(double peso)
        {
            //comando sql

            cmd.CommandText = ConfigurationManager.AppSettings["query"];
            cmd.Parameters.AddWithValue("@dia", DateTime.Now.Day);
            cmd.Parameters.AddWithValue("@mes", DateTime.Now.Month);
            cmd.Parameters.AddWithValue("@ano", DateTime.Now.Year);
            cmd.Parameters.AddWithValue("@hora", DateTime.Now.Hour);
            cmd.Parameters.AddWithValue("@min", DateTime.Now.Minute);
            cmd.Parameters.AddWithValue("@peso", peso);

            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine(" ERRO AO SE CONECTAR NO BANDO DE DADOS AS" + DateTime.Now.ToString());

            cmd.Connection = conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
            this.msg = " ADICIONADO AO BANDO DE DADOS AS" + DateTime.Now.ToString();

           
        }
    }
}
