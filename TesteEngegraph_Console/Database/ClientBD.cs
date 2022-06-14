using System;
using System.Data;
using System.Data.SqlClient;

namespace TesteEngegraph_Console.Database
{
    public class ClientBD
    {
        public string Mensage;
        public bool Status;
        public string Table;
        public BD_Connection Db;

        public ClientBD(string table)
        {
            Status = true;
            try
            {
                Db = new BD_Connection();
                Table = table;
                Mensage = "Conexão com a Tabela criada com sucesso";
            }
            catch (Exception e)
            {
                Status = false;
                Mensage = "Erro da onexão com a Tabela " + e.Message;
            }
        }

        public DataTable CreateTable(string sql)
        {
            try
            {
                BD_Connection db = new BD_Connection();
                SqlCommand sqlCommand = new SqlCommand(sql, db.Connection);
                sqlCommand.ExecuteNonQuery();
                Status = true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao criar tabela: " + e.Message);
                Status = false;
            }

            return null;
        }

        public int Count(string sql)
        {
            int count = 0;

            DataTable dt = new DataTable();
            try
            {
                SqlCommand myCommand = new SqlCommand(sql, Db.Connection);
                myCommand.CommandTimeout = 0;
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    var dados = myReader["Id"];
                    if (dados != null)
                    {
                        count++;
                    }
                }
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return count;
        }


        public DataTable Find(string Sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand myCommand = new SqlCommand(Sql, Db.Connection);
                myCommand.CommandTimeout = 0;
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Console.WriteLine($"ID do Contato: {myReader["Id"]}, Data Modificacao: {myReader["DataModificacao"]}, Acao: {myReader["Acao"]}");
                }
                myReader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return dt;
        }
    }
}
