using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Tests.Drivers;

namespace UI.Tests.Support
{
    class Navigate
    {

        private bool page;
        private WebDriver _webDriver;

        public Navigate(bool page, WebDriver webDriver)
        {
            this.page = page;
            _webDriver = webDriver;
        }


        public string _ToHomePage(string page)
        {

            //Opens page to test
            string pageSwitched = "";

            var driver = _webDriver.Current;
            driver.Manage().Window.Maximize();


            string baseUrl = ConfigurationManager.AppSettings["seleniumBaseUrl"];

            if ( page == "/" )
            {
                driver.Navigate().GoToUrl(string.Format("{0}", baseUrl));
            }
            else
            {
                driver.Navigate().GoToUrl(string.Format("{0}{1}", baseUrl, page));
            }



            return pageSwitched;
        }


        
        public string ToHomePage(string homepage)
        {

            //Opens page to test

            var driver = _webDriver.Current;
            driver.Manage().Window.Maximize();


            string baseUrl = ConfigurationManager.AppSettings["seleniumBaseUrl"];

            driver.Navigate().GoToUrl(string.Format("{0}", baseUrl));



            return homepage;
        }


    

    }
}
