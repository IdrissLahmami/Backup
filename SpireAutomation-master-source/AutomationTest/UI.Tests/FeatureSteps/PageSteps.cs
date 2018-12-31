using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using UI.Tests.FeatureSteps;
using UI.Tests.Support;

namespace UI.Tests.Drivers.Steps
{
    [Binding]
    public class PageSteps : IDisposable
    {

        private readonly WebDriver _webDriver;
        private string Url;
        private object count;
      

        public PageSteps(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"I navigated to (.*) (.*)")]
        [Scope(Tag = "Hosp")]
        public void GivenINavigatedTo(string page, string hospital)
        {

            MainPage switchPage = new MainPage(true, _webDriver);

            switchPage.LoadPage(page, hospital);

            Url = page;
        }


        [When(@"I count the number of links")]
        [Scope(Tag = "Hosp")]
        public void WhenICountTheNumberOfLinks(Table table)
        {
            int number; int index; 
            var tableObject = table.CreateInstance<DataTable>();

            //Select page to count links
            PageLinks links = new PageLinks(true, _webDriver);

            for (index = 0; index < table.RowCount; index++)
            {
                tableObject.Menu = table.Rows[index]["Menu"];
                tableObject.Count = table.Rows[index]["Count"];
                tableObject.Find = table.Rows[index]["Find"];
                tableObject.TestCaseNo = table.Rows[index]["TestCase"];

                string topSubMenu = tableObject.Menu;
                var cnt = int.TryParse(tableObject.Count, out number);
                string find = tableObject.Find;

                var testCaseNo = int.TryParse(tableObject.TestCaseNo, out number);

                Console.WriteLine();

                count = links.TopSubMenu(topSubMenu, find, false, number);


                //Links >1 found 
                if (count.ToString() != "0")
                {
                    count.Should().Be(cnt);
                }      
                else if (count.ToString() == "1")
                {
                  //1 main link present
                  count.Should().Be(cnt);
                }
                else
                {   //Link not found should fail
                    count.Should().Be(cnt);
                }


                Console.WriteLine();
            }

            Console.WriteLine();
        }

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

