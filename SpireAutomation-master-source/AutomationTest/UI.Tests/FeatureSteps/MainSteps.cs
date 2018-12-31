using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UI.Tests.FeatureSteps;
using UI.Tests.Support;

namespace UI.Tests.Drivers.Steps
{
    [Binding]
    public class MainSteps : IDisposable
    {

        private readonly WebDriver _webDriver;
        private string homeUrl;
        private object count;
        //private bool click;


        public MainSteps(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"I navigated to (.*) (.*)")]
        [Scope(Tag = "Central")]
        public void GivenINavigatedTo(string page, string area)
        {

            MainPage switchPage = new MainPage(true, _webDriver);

            switchPage.LoadPage(page);
            homeUrl = area;
        }


        [When(@"I count the number of links")]
        [Scope(Tag = "Central")]
        public void WhenICountTheNumberOfLinks(Table table)
        {
            int number; int index;
            var tableObject = table.CreateInstance<DataTable>();

            //Select page to count links
            PageLinks links = new PageLinks(true, _webDriver);

            for (index = 0; index < table.RowCount; index++)
            {
                tableObject.Page = table.Rows[index]["Page"];
                tableObject.Menu = table.Rows[index]["Menu"];
                tableObject.Count = table.Rows[index]["Count"];
                tableObject.Find = table.Rows[index]["Find"];
                tableObject.TestCaseNo = table.Rows[index]["TestCase"];
                tableObject.Click = table.Rows[index]["Click"];

                string topSubMenu = tableObject.Menu;
                var cnt = int.TryParse(tableObject.Count, out number);
                string find = tableObject.Find;

                bool click = bool.Parse(tableObject.Click);

                if (tableObject.TestCaseNo == "skip")
                { //do nothing
                }
                else
                {
                    var testCaseNo = int.TryParse(tableObject.TestCaseNo, out number);

                    count = links.TopSubMenu(topSubMenu, find, click, number);

                    count.Should().Be(cnt);

                    /** HERE ****/
                    //MoveTo moveTo = new MoveTo();

                    //Console.WriteLine();
                }
            }

            //Console.WriteLine();
        }

        /*
        [AfterScenario()]
        public void CloseBrowserAfterTest()
        {
            _webDriver.Quit();
        }
        */

        public void Dispose()
        {
            try
            {
                _webDriver.Quit();
            }
            catch (Exception e)
            { Console.WriteLine("chrome exception ..." + e); }
        }
    }
}

