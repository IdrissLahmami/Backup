using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using UI.Tests.Drivers;

namespace UI.Tests.Support
{
    class MoveTo
    {

        public IList<IWebElement> Lists { get; set; }

        private WebDriver _webDriver;
        IList<IWebElement> elements;

        public MoveTo(bool page, WebDriver webDriver)
        {   
            _webDriver = webDriver;
        }
        public string To(string findElement)
        {

            //initialize          
            IList<IWebElement> elements;
      
            var driver = _webDriver.Current;

            //Locate link on main page wait until found
            IWebElement element = driver.FindElement(By.LinkText(findElement));
            Actions action = new Actions(driver);

            action.MoveToElement(element).Click().Perform();

            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(500));
            element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(findElement)));


            //Find all treatments links from drop down box on the page using <a href tag> search
            elements = driver.FindElements(By.CssSelector(findElement));

            return "";
        }

        }
    }
