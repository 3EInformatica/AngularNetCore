using Microsoft.Data.SqlClient;
using SQLEsempio.Models;
using SQLEsempio.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SQLEsempio.Services
{
    internal class DBServices
    {
        public static List<Customer> CaricaClientidaDB()
        {
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

        public static List<Customer> CaricaClientidaDBFiltrato(string letteraIniziale)
        {
            List<Customer> elenco = new List<Customer>();
            //collegare al DB
            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();
                //var stato = conn.State;
                //eseguire la query
                //string sql = "select CustomerID,CompanyName,ContactName from Customers";
                //sql += $" WHERE CompanyName LIKE '{letteraIniziale}%'";
                //sql += " ORDER BY CompanyName";

                string sql = @$"select CustomerID,CompanyName,ContactName from Customers
                             WHERE CompanyName LIKE '{letteraIniziale}%'
                            ORDER BY CompanyName";

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


            //return elenco.Where(s=>s.CompanyName.StartsWith(letteraIniziale)).ToList();
            return elenco;
        }



        public static bool InserisiCorriere(string CompanyName, string Phone)
        {
            var risultato = false;
            //collegare al DB
            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();

                string sql = @$"INSERT INTO Shippers (CompanyName,Phone) 
                            VALUES ('{CompanyName}','{Phone}')";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var numerorighe = cmd.ExecuteNonQuery();
                    if(numerorighe > 0) 
                        risultato = true;
                }
                conn.Close();
            }


            return risultato;
        }
    }
}
