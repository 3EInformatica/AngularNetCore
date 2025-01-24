using Microsoft.Data.SqlClient;
using SQLEsempio.Models;
using SQLEsempio.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEsempio.Services
{
    internal class DBServices
    {
        public static List<Customer> CaricaClientidaDB() {
            List<Customer> elenco = new List<Customer>();
            //collegare al DB
            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                //var stato = conn.State;
                //eseguire la query
                string sql = "select CustomerID,CompanyName,ContactName from Customers ORDER BY CompanyName";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var dr = cmd.ExecuteReader();
                    //caricare in elenco il risultato della query
                    while (dr.Read())
                    {
                        Customer c = new Customer();
                        c.CustomerID = dr["CustomerID"].ToString();
                        c.CompanyName = dr["CompanyName"].ToString();
                        c.ContactName = dr["ContactName"].ToString();
                        elenco.Add(c);
                    }
                    dr.Close();
                }
                conn.Close();
            }
           

            return elenco;
        }
    }
}
