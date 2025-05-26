using Domen;
using System;
using Microsoft.Data.SqlClient;

namespace BrokerBazePodataka
{
    public class Broker
    {
        private SqlConnection conn;
        private SqlTransaction transaction;

        public void Connect()
        {
            conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RezervacijaAvioKarata;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            conn.Open();
        }

        public void Disconnect()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public void BeginTransaction()
        {
            transaction = conn.BeginTransaction();
        }

        public void CommitTransaction()
        {
            transaction?.Commit();
            transaction = null;
        }

        public void RollbackTransaction()
        {
            transaction?.Rollback();
            transaction = null;
        }

        public SqlCommand CreateCommand(string query)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            if (transaction != null)
                cmd.Transaction = transaction;
            return cmd;
        }

        //SK8: Prijavi aviokompaniju

        public Aviokompanija PrijaviAviokompanija(string korisnickoIme, string sifra)
        {
            try
            {
                string upit = "SELECT * FROM Aviokompanija WHERE korisnickoIme = @user AND sifra = @pass";
                using SqlCommand cmd = new SqlCommand(upit, conn);
                cmd.Parameters.AddWithValue("@user", korisnickoIme);
                cmd.Parameters.AddWithValue("@pass", sifra);

                using SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Aviokompanija a = new Aviokompanija()
                    {
                        idAviokompanija = (long)reader["idAviokompanija"],
                        Naziv = reader["Naziv"].ToString(),
                        Email = reader["Email"].ToString(),
                        korisnickoIme = reader["korisnickoIme"].ToString(),
                        sifra = reader["sifra"].ToString()
                    };

                    return a;
                }

                else
                {
                    throw new Exception("Korisnicko ime i sifra nisu ispravni.");
                }
            }

            catch (SqlException ex)
            {
                Console.WriteLine("Greska pri radu sa bazom!");
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}
