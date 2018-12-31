using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Tests.Drivers;
using UI.Tests.SitePages;
using SeleniumExtras.WaitHelpers;

namespace UI.Tests.Support
{
    class PageLinks : HomePage
    {


        private bool page;
        private WebDriver _webDriver;

        public IList<IWebElement> Lists { get; set; }

        public PageLinks(bool page, WebDriver webDriver)
        {
            this.page = page;
            _webDriver = webDriver;
        }



        public int CountTreatmentLinks(string currentPage, string findElements, bool click)
        {

            //initialize 
            int count = 0;
          
            string[] expected = null;
            IList<IWebElement> elements;


            //Click treatments link

            Expected expectedTreatments = new Expected();
            expected = expectedTreatments.TreatmentLinks();


            var driver = _webDriver.Current;

            //Locate link on main page wait until found
            IWebElement element = driver.FindElement(By.LinkText(currentPage));
            Actions action = new Actions(driver);

            action.MoveToElement(element).Perform();

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(500));
            //element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(currentPage)));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(currentPage)));


            //Find all treatments links from drop down box on the page using <a href tag> search
            elements = driver.FindElements(By.CssSelector(findElements));


            //DEBUG:1 


            //store matched links in list
            List<string> matched = new List<string>();


            foreach (IWebElement found in elements)
            {
                for (int i = 0; i < expected.Length; i++)
                {
                    //Validate found treatments on site page against expected treatments
                    if (found.Text.Equals(expected[i]))
                    {
                        count++;
                        matched.Add(found.Text); //Adding found treatments to list


                        IWebElement _element = driver.FindElement(By.LinkText(expected[i]));
                        Actions _action = new Actions(driver);
                        _action.MoveToElement(_element).Build().Perform();

                        //Highlight element
                        IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                        js.ExecuteScript("arguments[0].setAttribute('style', 'background: black; border: 2px solid red;')", _element);

                        //Wait until element link is found on site page
                        var wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
                        element = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(found.Text)));

                    }
                    else
                    {
                        //DEBUG: NOT FOUND

                    }

                }
            }

            //DEBUG: write to file uncomment to debug                    
            DebugOutput(matched, "TreatmentLinksFound.txt");


            return count;
        }


        /***************************************
        * COUNT HOSPITAL LINKS                 *
        ****************************************/

        public int CountHospitalLinks(string currentPage, string findElements, bool click)
        {

            //initialize 
            int count = 0;
            string[] expected = null;
            IList<IWebElement> elements;


            //Click to select hospital

            Expected expectedHospitals = new Expected();
            expected = expectedHospitals.HospitalLinks();


            var driver = _webDriver.Current;

            //Locate link on main page wait until found
            IWebElement element = driver.FindElement(By.LinkText(currentPage));
            Actions action = new Actions(driver);

            
            action.MoveToElement(element).Click().Perform();


            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromMilliseconds(1000));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(currentPage)));

            //Find all treatments links from drop down box on the page using <a href tag> search
            elements = driver.FindElements(By.CssSelector(findElements));


            //DEBUG:1 


            //store matched links in list
            List<string> matched = new List<string>();

            foreach (IWebElement found in elements)
            {
                for (int i = 0; i < expected.Length; i++)
                {
                    //Check if empty string
                    if (found.Text == "") { continue; }

                    //Match hospital links on site page against expected links
                    if (found.Text.Equals(expected[i]))
                    {

                        count++;
                        matched.Add(found.Text); //Add found to list                  

                        IWebElement _element = driver.FindElement(By.LinkText(expected[i]));
                        Actions _action = new Actions(driver);


                        _action.MoveToElement(_element).Build().Perform();

                        //Highlight element
                        IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                        js.ExecuteScript("arguments[0].setAttribute('style', 'background: green; border: 2px solid red;')", _element);

                        var wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
                        element = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(expected[i])));

                    }
                    else
                    {
                        //DEBUG: NOT FOUND

                    }

                }



            }


            //DEBUG: write to file uncomment to debug        
            DebugOutput(matched, "HospitalLinksFound.txt");

            return count;

        }


        /***************************************
        * COUNT PAGE LINKS                     *
        ****************************************/


        public int TopSubMenu(string currentPage, string findElements, bool click, int subItem)
        {

            //initialize 
            int count = 0;
            int linkFound = 0;

            //Treatments 2 missing fix 
            var runonce = true;
            var runonce2 = true;

            string[] expected = null;
            IList<IWebElement> elements;


            //Click Top Subment link
            Expected expectedLink = new Expected();

            switch (subItem)
            {
                case 0:
                    Console.WriteLine("Case 0");
                    expected = expectedLink.BusheyExpBookanAppointment();


                    break;
                case 1:
                    Console.WriteLine("Case 1");
                    expected = expectedLink.BushyExpTreatmentLinks();
                    runonce = false;
                    runonce2 = false;

                    break;
                case 2:
                    Console.WriteLine("Case 2");
                    expected = expectedLink.BusheyExpConsultantsLinks();

                    break;

                case 3:
                    Console.WriteLine("Case 3");
                    expected = expectedLink.BusheyExpPatientInformation();

                    break;

                case 4:
                    Console.WriteLine("Case 4");
                    expected = expectedLink.BusheyExpFindUs();

                    break;

                case 5:
                    Console.WriteLine("Case 5");
                    expected = expectedLink.BusheyExpGpInfoResources();

                    break;

                case 6:
                    //Central - Prices              
                    Console.WriteLine("Case 6");               
                    break;

                case 16:
                    // Central - Our Locations
                    Console.WriteLine("Case 16");
                    expected = expectedLink.HospitalLinks();
                    break;

                case 17:
                    //Central - Treatments
                    Console.WriteLine("Case 17");
                    expected = expectedLink.TreatmentLinks();
                    break;

                default:
                    Console.WriteLine("Default case");
                    break;
            }

            /*********************************************/
            /* Locate link on main page wait until found */
            /*********************************************/
        
            var driver = _webDriver.Current;

            IWebElement element = driver.FindElement(By.LinkText(currentPage));
            Actions action = new Actions(driver);


            //Main Page
            if ( click )
            {
                action.MoveToElement(element).Click().Perform();
            }
            else
            {
                action.MoveToElement(element).Perform();
            }

            //Highlight element
            IJavaScriptExecutor js0 = driver as IJavaScriptExecutor;
            js0.ExecuteScript("arguments[0].setAttribute('style', 'background: green; border: 2px solid blue;')", element);

            //Check if menu link is found
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
                element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(currentPage)));
                linkFound = 1;
            }
            catch (Exception ex)
            {
                //write exception to the log
                linkFound = 0;
            }
            //Some menu items dont have drop down links return 0 
            //Find all treatments links from drop down box on the page using <a href tag> search
            if (subItem != 6)
            {
                elements = driver.FindElements(By.CssSelector(findElements));

                //DEBUG:1 
                //DEBUG: write to file uncomment to debug                    
                DebugOutput2(elements, "LinksFound.txt");

                //store matched links in list
                List<string> matched = new List<string>();
                List<string> umatched = new List<string>();

                foreach (IWebElement found in elements)
                {
                    for (int i = 0; i < expected.Length; i++)
                    {
                        //Validate found treatments on site page against expected treatments
                        if (found.Text.Equals(expected[i]))
                        {
                            count++;
                            matched.Add(found.Text); //Adding found treatments to list


                            IWebElement _element = driver.FindElement(By.LinkText(expected[i]));
                            Actions _action = new Actions(driver);
                            //_action.MoveToElement(_element).Build().Perform();
                            _action.MoveToElement(_element).Perform();

                            //Highlight element
                            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                            js.ExecuteScript("arguments[0].setAttribute('style', 'background: black; border: 2px solid red;')", _element);

                            //Wait until element link is found on site page
                            var wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(5000));
                            element = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(found.Text)));
                            Console.WriteLine();
                        }
                        else
                        {
                            //DEBUG: NOT FOUND


                            if ((expected[i].ToString() == "Elstree Cancer Centre") || (expected[i].ToString() == "Spire Bushey Diagnostic Centre"))
                            {

                                if (!runonce || !runonce2)
                                {
                                    IWebElement _element = driver.FindElement(By.LinkText(expected[i]));
                                    Actions _action = new Actions(driver);
                                    _action.MoveToElement(_element).Perform();

                                    //Highlight element
                                    IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                                    js.ExecuteScript("arguments[0].setAttribute('style', 'background: black; border: 2px solid red;')", _element);

                                    //Wait until element link is found on site page
                                    var wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(10000));
                                    element = wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(found.Text)));


                                    if (expected[i].ToString() == "Elstree Cancer Centre") { runonce = true; }
                                    if (expected[i].ToString() == "Spire Bushey Diagnostic Centre") { runonce2 = true; }

                                    count++;
                                }
                            }


                        }

                    }
                }

                //DEBUG: write to file uncomment to debug                    
                DebugOutput(matched, "MatchedLinksFound.txt");


                return count;
            }

            return linkFound;

        }

    }
}

