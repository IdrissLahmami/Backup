using System;
using System.Globalization;
using Test_EARS_Service.Service;
namespace Test_EARS_Service
{
   class Program
    {
        static void Main(string[] args)
        {
            //Test WCF Insert

            DateTime now = DateTime.Now;

            string sDate = DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("en-GB"));

            DateTime cDate = Convert.ToDateTime(sDate);

            Console.WriteLine(cDate);

            ServicesClient client = new ServicesClient();

            client.CreateTestCycle("Test Client", "Expected", "Actual", "Passed", "2.0", cDate, 1, "2");

            client.WriteTestResult("New Feature", "New Scenario", "New Step", "", "PASSED");
            client.WriteTestResult("New Feature", "New Scenario1", "New Step2", "", "PASSED");
            client.WriteTestResult("New Feature", "New Scenario2", "New Step3", "", "FAILED");

        }
    }
}


