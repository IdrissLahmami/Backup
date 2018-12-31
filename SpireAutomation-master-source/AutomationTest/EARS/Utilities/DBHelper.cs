using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EARS.Utilities
{
    public static class DBHelper
    {
        public static void ConnectReportingServer()
        {
            //Connection string
            Settings.ReportingConnString = ConfigurationManager.ConnectionStrings["EARS_DBConnectionString"].ConnectionString;
            //Connecting DB
            Settings.ReportingConn = Settings.ReportingConn.DBConnect(Settings.ReportingConnString);
        }

        //Open the connection
        public static SqlConnection DBConnect(this SqlConnection sqlConnection, string connectionString)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR :: " + e.Message);
            }

            return null;
        }



        //Closing the connection 
        public static void DBClose(this SqlConnection sqlConnection)
        {
            try
            {
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR :: " + e.Message);
            }
        }


        //Execution
        public static DataTable ExecuteQuery(this SqlConnection sqlConnection, string queryString)
        {

            DataSet dataset;
            try
            {
                //Checking the state of the connection
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed ||
                    sqlConnection.State == ConnectionState.Broken))))
                    sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];
            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
                Console.WriteLine("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }


        }

        public static DataTable ExecuteProcWithParamsDT(this SqlConnection Conn, string procname, Hashtable parameters)
        {

            string tableName;

            switch (procname)
            {
                case "sp_CreateTestCycleID":
                    tableName = "table1";
                    break;
                case "sp_InsertResult":
                    tableName = "table2";
                    break;
                default:
                    tableName = "ht";
                    break;
            }


            try
            {
                //SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                SqlDataAdapter dataAdaptor = new SqlDataAdapter(procname, Conn);
                dataAdaptor.ReturnProviderSpecificTypes = true;

                dataAdaptor.SelectCommand = new SqlCommand(procname, Conn);
                dataAdaptor.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (parameters != null)

                   

                foreach (DictionaryEntry de in parameters)
                    {
                        SqlParameter sp = new SqlParameter(de.Key.ToString(), de.Value.ToString());

                        Console.WriteLine(sp.Value);    
                        Console.WriteLine(sp.ParameterName);
                        Console.WriteLine(sp.DbType);

                        if (sp.ParameterName == "DateOfExecution")
                        {
                            var dt = Convert.ToDateTime(sp.Value);
                            dataAdaptor.SelectCommand.Parameters.AddWithValue(sp.ParameterName, dt);

                        }
                        else
                        {
                            dataAdaptor.SelectCommand.Parameters.AddWithValue(sp.ParameterName, sp.Value);
                        }
                  

                        sp.SqlDbType = SqlDbType.Structured;
                       
                    }


                DataSet ds = new DataSet();
                dataAdaptor.Fill(ds, tableName);

                Conn.Close();
                return ds.Tables[tableName];
            }
            catch (Exception e)
            {
                //dataSet = null;

                Conn.Close();
                Console.WriteLine("ERROR :: " + e.Message);
                return null;
            }
            finally
            {
                Conn.Close();
                //dataSet = null;
            }

        }


        //I am sure there is a more elegant way of doing this.
        private static DataTable ConvertToDataTable(Dictionary<string, int> dict)
        {
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("OrderNumber", typeof(Int32));
            foreach (var pair in dict)
            {
                var row = dt.NewRow();
                row["ID"] = pair.Key;
                row["OrderNumber"] = pair.Value;
                dt.Rows.Add(row);
            }
            return dt;
        }


        /* 
         foreach (DictionaryEntry de in parameters)
         {
             SqlParameter sp = new SqlParameter(de.Key.ToString(), de.Value.ToString());
             //SqlParameter parameter = dataAdaptor.Parameters.Add("@CategoryID", SqlDbType.Int);
             //dataAdaptor.SelectCommand.Parameters.Add(sp);
             dataAdaptor.SelectCommand.Parameters.AddWithValue("@TestName", SqlDbType.NVarChar);
             dataAdaptor.SelectCommand.Parameters.AddWithValue("@DateOfExecution", SqlDbType.DateTime);

         }

     DataSet ds = new DataSet();

     //dataAdaptor.MissingSchemaAction = MissingSchemaAction.Add;
     dataAdaptor.AcceptChangesDuringFill = true;
     dataAdaptor.Fill(ds,"table");
     Conn.Close();
     return ds.Tables["table"];


     /*
     DataSet ds = new DataSet();
     dataAdaptor.Fill(ds, "table");

     for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
     {
         Console.WriteLine(ds.Tables[0].Rows[i][0]);
     }

     Console.WriteLine(ds.ToString());
     Conn.Close();
     return ds.Tables["table"];
     */







    }  
}