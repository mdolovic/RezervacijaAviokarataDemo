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



    }
}
