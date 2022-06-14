using System;
using System.Data.SqlClient;
using System.Data;

namespace TesteEngegraph_Console.Database
{
    public class BD_Connection
    {
        public string ConnectionBD;
        public SqlConnection Connection;

        public BD_Connection()
        {
            try
            {
                ConnectionBD = "Data Source=midnightserversql.ddns.net;" +
                    "Initial Catalog=DB_Engegraph;Persist Security Info=True;" +
                    "User ID=sa;Password=Beta2209";
                Connection = new SqlConnection(ConnectionBD);
                Connection.Open();
            } 
            catch (SqlException e)
            {
               Console.WriteLine("Error: " + e.Message);
            }
        }

        public void Close()
        {
            Connection.Close();
        }

    }
}
