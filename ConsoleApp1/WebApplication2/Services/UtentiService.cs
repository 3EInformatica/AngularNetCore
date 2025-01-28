using System.Data.SqlClient;
using WebApplication2.Models.Entities;
using WebApplication2.Settings;

namespace WebApplication2.Services
{
    public class UtentiService
    {

        public static Utenti Login(string username, string password)
        {
            Utenti u = null;

            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
                var passCript = Convert.ToBase64String(plainTextBytes);
                string sql = @$"select Guid, Nome, Cognome,DataUltimoAccesso from Utenti
                                 WHERE username ='{username.Replace("'", "''")}' collate sql_latin1_general_cp1_cs_as
                                AND password ='{passCript.Replace("'", "''")}' collate sql_latin1_general_cp1_cs_as";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var dr = cmd.ExecuteReader();
                    //caricare in elenco il risultato della query
                    if (dr.Read())
                    {
                        u = new Utenti();
                        u.Guid = Guid.Parse(dr["Guid"].ToString());
                        u.Nome = dr["Nome"].ToString();
                        u.Cognome = dr["Cognome"].ToString();
                        u.DataUltimoAccesso = (dr["DataUltimoAccesso"] == DBNull.Value) ? null : Convert.ToDateTime(dr["DataUltimoAccesso"]);
                    }

                    dr.Close();
                }
                conn.Close();
            }

            return u;
        }
    }
}
