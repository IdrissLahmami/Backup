using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Tests.Drivers;
using UI.Tests.SitePages;

namespace UI.Tests.Support
{
    class FindElements : HomePage
    {

        private bool page;
        private WebDriver driver;

        public IList<IWebElement> Lists { get; set; }

        public FindElements(bool page, WebDriver webDriver)
        {
            this.page = page;
            driver = webDriver;
        }

        public int FindLinks(string currentPage, string findElements, string[] expected, bool click, bool runonce, bool runonce2)
        {

            //initialize 
            int count = 0;
            IList<IWebElement> elements;

            var driver = this.driver.Current;

            //Locate link on main page wait until found
            IWebElement element = driver.FindElement(By.LinkText(currentPage));
            Actions action = new Actions(driver);

            action.MoveToElement(element).Perform();

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(500));
            element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(currentPage)));

            //Find all treatments links from drop down box on the page using <a href tag> search
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
                        _action.MoveToElement(_element).Build().Perform();

                        //Highlight element
                        IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                        js.ExecuteScript("arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;')", _element);

                        //Wait until element link is found on site page
                        var wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
                        element = wait2.Until(ExpectedConditions.ElementIsVisible(By.LinkText(found.Text)));
                        Console.WriteLine();
                    }
                    else
                    {
                        //DEBUG: NOT FOUND

                        //Find  a[href*=treatments] doesnt find Elstree, web link is in a[href*=find-us] so using array to locate it on the page
                        if ((expected[i].ToString() == "Elstree Cancer Centre") || (expected[i].ToString() == "Spire Bushey Diagnostic Centre"))
                        {

                            if (!runonce || !runonce2)
                            {
                                IWebElement _element = driver.FindElement(By.LinkText(expected[i]));
                                Actions _action = new Actions(driver);
                                _action.MoveToElement(_element).Build().Perform();

                                //Highlight element
                                IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                                js.ExecuteScript("arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;')", _element);

                                //Wait until element link is found on site page
                                var wait2 = new WebDriverWait(driver, TimeSpan.FromMilliseconds(500));
                                element = wait2.Until(ExpectedConditions.ElementIsVisible(By.LinkText(found.Text)));


                                if (expected[i].ToString() == "Elstree Cancer Centre") { runonce = true; }
                                if (expected[i].ToString() == "Spire Bushey Diagnostic Centre") { runonce2 = true; }

                                count++;
                            }
                        }


                    }

                }
            }

            //DEBUG: write to file uncomment to debug                    
            //  DebugOutput(matched, "MatchedLinksFound.txt");


            return count;
        }


    }
}
