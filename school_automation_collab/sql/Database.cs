using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace School_Automation_Collab.sql
{
    public class Database
    {
        public List<List<string>> select(string table, string cols="*",  string condidition="1")
        {
            List<List<string>> all = new List<List<string>>();
            
            var dbCon =new DBConnection();
            dbCon.DatabaseName = "toros_database";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = $"SELECT {cols} FROM {table} where {condidition}";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<string> results = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results.Add(reader.GetString(i));
                        //MessageBox.Show(reader.GetString(i));
                    }
                    all.Add(results);
                        
                    
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                //test
                dbCon.Close();
                
            }
            return all;
        }

    }
}
