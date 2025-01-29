using System.Data.SqlClient;
using WebApplication2.Models.DTO;
using WebApplication2.Models.Entities;
using WebApplication2.Models.Requests;
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

        internal static bool Delete(Guid guidUtente)
        {
            var r = false;
            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                string sql = @$"DELETE FROM utenti WHERE guid='{guidUtente}'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0) r = true;
                }
                conn.Close();
            }
            return r;
        }

        internal static List<Utenti> GetAll()
        {
            List<Utenti> listaUtenti = new List<Utenti>();

            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                string sql = @$"select Guid, Nome, Cognome,DataUltimoAccesso , Username from Utenti";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var dr = cmd.ExecuteReader();
                    //caricare in elenco il risultato della query
                    while (dr.Read())
                    {
                        var u = new Utenti();
                        u.Guid = Guid.Parse(dr["Guid"].ToString());
                        u.Nome = dr["Nome"].ToString();
                        u.Cognome = dr["Cognome"].ToString();
                        u.Username = dr["Username"].ToString();
                        u.DataUltimoAccesso = (dr["DataUltimoAccesso"] == DBNull.Value) ? null : Convert.ToDateTime(dr["DataUltimoAccesso"]);
                        listaUtenti.Add(u);
                    }
                    dr.Close();
                }
                conn.Close();
            }

            return listaUtenti;
        }

        internal static Utenti GetByGuid(Guid guidUtente)
        {
            Utenti u = null;
            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                string sql = @$"select Guid, Nome, Cognome,DataUltimoAccesso , Username from Utenti
                            WHERE Guid='{guidUtente}' ";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var dr = cmd.ExecuteReader();
                    //caricare in elenco il risultato della query
                    while (dr.Read())
                    {
                        u = new Utenti();
                        u.Guid = Guid.Parse(dr["Guid"].ToString());
                        u.Nome = dr["Nome"].ToString();
                        u.Cognome = dr["Cognome"].ToString();
                        u.Username = dr["Username"].ToString();
                        u.DataUltimoAccesso = (dr["DataUltimoAccesso"] == DBNull.Value) ? null : Convert.ToDateTime(dr["DataUltimoAccesso"]);
                    }
                    dr.Close();
                }
                conn.Close();
            }
            return u;
        }

        internal static bool Insert(UtenteNewRequest utente)
        {
            var r = false;
            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(utente.Password);
                var passCript = Convert.ToBase64String(plainTextBytes);
                string sql = @$"INSERT INTO Utenti (nome, cognome, username, password) VALUES
                                ('{utente.Nome.Replace("'", "''")}',
                                '{utente.Cognome.Replace("'", "''")}',
                                '{utente.Username.Replace("'", "''")}',
                                '{passCript.Replace("'", "''")}')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0) r = true;
                }
                conn.Close();
            }
            return r;
        }

        internal static bool Update(UtenteEditRequest utente)
        {
            var r = false;
            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(utente.Password);
                var passCript = Convert.ToBase64String(plainTextBytes);
                string sql = @$"UPDATE utenti SET 
                    nome='{utente.Nome.Replace("'","''")}',
                    cognome='{utente.Cognome.Replace("'", "''")}',
                    username='{utente.Username.Replace("'", "''")}',
                    password='{passCript.Replace("'", "''")}'
                    WHERE GUID='{utente.GuidUtente}'";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0) r = true;
                }
                conn.Close();
            }
            return r;
        }
    }
}
