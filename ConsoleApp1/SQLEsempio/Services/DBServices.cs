﻿using Microsoft.Data.SqlClient;
using SQLEsempio.Models;
using SQLEsempio.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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
                            VALUES ('{CompanyName.Replace("'", "''")}','{Phone.Replace("'", "''")}')";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var numerorighe = cmd.ExecuteNonQuery();
                    if (numerorighe > 0)
                        risultato = true;
                }
                conn.Close();
            }


            return risultato;
        }
        public static Utente Login(string UserName, string Password)
        {

            Utente u = new Utente();


            using (SqlConnection conn = new SqlConnection(Costanti.ConnectionSting))
            {
                conn.Open();

                string sql = @$"select Guid, Nome, Cognome,DataUltimoAccesso from Utenti
                             WHERE username ='{UserName.Replace("'", "''")}' collate sql_latin1_general_cp1_cs_as
                            AND password ='{Password.Replace("'", "''")}' collate sql_latin1_general_cp1_cs_as";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    var dr = cmd.ExecuteReader();
                    //caricare in elenco il risultato della query
                    if (dr.Read())
                    {
                        u.id = Guid.Parse(dr["Guid"].ToString());
                        u.Nome = dr["Nome"].ToString();
                        u.Cognome = dr["Cognome"].ToString();
                        u.DataUltimoAccesso = Convert.ToDateTime(dr["DataUltimoAccesso"]);
                    }
                    else
                    {
                        u = null;
                    }
                    dr.Close();
                    //AGGIORNO la data di ultimo accesso
                    if (u != null)
                    {
                        sql = @$"UPDATE Utenti SET DataUltimoAccesso = GETDATE() WHERE Guid = '{u.id}'";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                    var esito = u == null ? 0 : 1;
                    var daDove = GetLocalIPAddress();
                    sql = @$"INSERT INTO Logaccessi (Username,Password,DataTentativo,Esito,Dadove) VALUES 
                            ('{UserName}','{Password}',getdate(),'{esito}','{daDove}')";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return u;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}

