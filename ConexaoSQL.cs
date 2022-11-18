using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetoLogin
{
    internal class ConexaoSQL
    {
        MySqlConnection con;

        public void conectarBD()
        {
            try
            {
                con = new MySqlConnection("Persist Security info= false; server = localhost;" +
                    "database=sistema;user=root;pwd=;");
                con.Open();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public void executarcomandos(string sql)
        {
            try
            {
                conectarBD();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
        public string executarconsulta(string sql)
        {
            try
            {
                string resultado;
                conectarBD();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                
                da.Fill(dt);
                try { resultado = dt.Rows[0][0] + ""; }
                catch(Exception) { resultado = ""; }
                
                
                return resultado;
            }
            catch (Exception)
            {
                throw;
                
            }
            finally
            {
                con.Close();
            }
        }
    }
}
