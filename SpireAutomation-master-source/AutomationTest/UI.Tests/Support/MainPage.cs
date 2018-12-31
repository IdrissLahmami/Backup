using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Tests.Drivers;

namespace UI.Tests.Support
{
    class MainPage
    {

        private bool page;
        private WebDriver _webDriver;

        public MainPage(bool page, WebDriver webDriver)
        {
            this.page = page;
            _webDriver = webDriver;
        }


        public string LoadPage(string page)
        {

            var driver = _webDriver.Current;
            driver.Manage().Window.Maximize();

            string baseUrl = ConfigurationManager.AppSettings["seleniumBaseUrl"];

            driver.Navigate().GoToUrl(string.Format("{0}", baseUrl));


            return page;
        }

        public string LoadPage(string page, string hospPage)
        {

            //Opens page to test
            string pageSwitched ="";

            var driver = _webDriver.Current;
            driver.Manage().Window.Maximize();


            string baseUrl = ConfigurationManager.AppSettings["seleniumBaseUrl"];

            driver.Navigate().GoToUrl(string.Format("{0}{1}", baseUrl, hospPage));
          


            return pageSwitched;
        }




    }
}
