using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UI.Tests.Drivers;

namespace UI.Tests.Support
{
    class Move
    {

        private bool page;
        private WebDriver driver;

        public IList<IWebElement> Lists { get; set; }

        public Move(bool page, WebDriver webDriver)
        {
            this.page = page;
            driver = webDriver;
        }



        public void MoveTo(string moveToLink, bool click)
        {


            var driver = this.driver.Current;

            //Locate link on main page wait until found
            IWebElement element = driver.FindElement(By.LinkText(moveToLink));
            Actions action = new Actions(driver);

            action.MoveToElement(element);

            //Highlight element
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].setAttribute('style', 'background: green; border: 2px solid red;')", element);

            action.MoveToElement(element).Click().Perform();    

            //var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(100));
            //var _element = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(moveToLink)));

            //Thread.Sleep(10000);

            //moveToLink = "";

            //return moveToLink;
        }
    }

}
