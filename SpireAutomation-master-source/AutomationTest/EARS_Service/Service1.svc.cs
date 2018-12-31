using EARS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EARS_Service
{
    /// <summary>
    /// Main Service class which is consumed by the EAFramwork or any custom framework
    /// </summary>
    public class Service1 : IServices
    {
        public Service1()
        {
            //Connection string
            Settings.ReportingConnString = ConfigurationManager.ConnectionStrings["EARS_DBConnectionString"].ConnectionString;
            //Connecting DB
            Settings.ReportingConn = Settings.ReportingConn.DBConnect(Settings.ReportingConnString);

        }

        public void CreateTestCycle(string testName, string expectedResult, string actualResult, string result, string buildNo, DateTime dateOfExecution, int testType, string executionTime)
        {
            try
            {
                //DateTime parsedDate = DateTime.Parse(dateOfExecution);
              

                Hashtable table = new Hashtable();
                table.Add("TestName", testName);
                table.Add("Expected", expectedResult);
                table.Add("Actual", actualResult);
                table.Add("Result", result);
                table.Add("BuildNo", buildNo);
                table.Add("DateOfExecution", dateOfExecution);
                //table.Add("MachineName", Environment.MachineName);         
                table.Add("TestType", testType);
                table.Add("ExecutionTime", executionTime);
                //ToDo: Room for extending it !!!
                //table.Add("TestType", 1);

                Settings.ReportingConn.ExecuteProcWithParamsDT("sp_CreateTestCycleID", table);

                Console.WriteLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void WriteTestResult(string featureName, string scenarioName, string stepName, string exception, string result)
        {
            try
            {
                Hashtable table = new Hashtable();
                table.Add("FeatureName", featureName);
                table.Add("ScenarioName", scenarioName);
                table.Add("StepName", stepName);
                table.Add("Exception", exception);
                table.Add("Result", result);

                Settings.ReportingConn.ExecuteProcWithParamsDT("sp_InsertResult", table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
