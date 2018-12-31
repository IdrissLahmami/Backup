using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace UI.Tests.Drivers
{
    public class WebDriver
    {
        private IWebDriver currentWebDriver;

        public IWebDriver Current
        {
            get
            {
                if (currentWebDriver != null)
                    return currentWebDriver;

                switch (BrowserConfig)
                {
                    case "IE":
                        currentWebDriver = new InternetExplorerDriver(new InternetExplorerOptions() { IgnoreZoomLevel = true }) { Url = SeleniumBaseUrl };
                        break;
                    case "Chrome":
                        currentWebDriver = new ChromeDriver() { Url = SeleniumBaseUrl };
                        break;
                    case "Firefox":
                        currentWebDriver = new FirefoxDriver() { Url = SeleniumBaseUrl };
                        break;
                    default:
                        throw new NotSupportedException($"{BrowserConfig} is not a supported browser");
                }

                return currentWebDriver;
            }
        }

        private WebDriverWait wait;
        public WebDriverWait Wait
        {
            get
            {
                if (wait == null)
                {
                    this.wait = new WebDriverWait(Current, TimeSpan.FromSeconds(5));
                }
                return wait;
            }
        }

        protected string BrowserConfig => ConfigurationManager.AppSettings["browser"];
        protected string SeleniumBaseUrl => ConfigurationManager.AppSettings["seleniumBaseUrl"];

        public void Quit()
        {
            //currentWebDriver?.Quit();
            currentWebDriver.Quit();
            currentWebDriver.Dispose();
            currentWebDriver = null;
        }
    }
}
