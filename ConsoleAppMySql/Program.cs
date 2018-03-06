using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "sakila";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "select * from customer limit 20";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(2);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                dbCon.Close();
            }
        }
    }
}
