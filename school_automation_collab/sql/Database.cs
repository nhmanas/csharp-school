using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace School_Automation_Collab.sql
{
    public class cmdParameterType
    {

        public cmdParameterType(string _parameterName, object _objParam)
        {
            parameterName = _parameterName;
            objParam = _objParam;
        }

        public string parameterName = "";
        public object objParam;
    }
    public class Database
    {
        public DataTable query(string query, List<cmdParameterType> lstParameters)
        {            
            var dbCon =new DBConnection();
            dbCon.DatabaseName = "toros_database";
            var dtTable = new DataTable();
            if (dbCon.IsConnect())
            {
                using (dbCon.Connection)
                {
                    using (MySqlCommand command = new MySqlCommand(query, dbCon.Connection))
                    {
                        foreach (var vrPerParameter in lstParameters)
                        {
                            command.Parameters.AddWithValue(vrPerParameter.parameterName, vrPerParameter.objParam);
                        }
                        try
                        {
                            dbCon.Connection.Open();
                            dtTable.Load(command.ExecuteReader());
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            return null;
                        }
                        
                        
                    }
                }
                dbCon.Close();
                return dtTable;
            }
            else
            {
                return null;
            }
            
        }

    }
}
