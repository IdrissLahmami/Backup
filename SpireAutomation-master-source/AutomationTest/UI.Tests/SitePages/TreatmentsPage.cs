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
using UI.Tests.Support;

namespace UI.Tests.SitePages
{
    class TreatmentsPage 
     {
        

        private bool page;
        private WebDriver _webDriver;

        public TreatmentsPage(bool page, WebDriver webDriver)
        {
            this.page = page;
            _webDriver = webDriver;
        }

       
    }
}
