using System;
using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UI.Tests.Drivers;

namespace TestApplication.UiTests.Support
{
    [Binding]
    class ScreenShots
    {
        private readonly WebDriver _webDriver;

        public ScreenShots(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [AfterStep()]
        public void MakeScreenshotAfterStep()
        {
            string savePath = ConfigurationManager.AppSettings["screenSavePath"];

            var takesScreenshot = _webDriver.Current as ITakesScreenshot;
            if (takesScreenshot != null)
            {
                var screenshot = takesScreenshot.GetScreenshot();

                //var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                var tempFileName = Path.Combine(savePath, Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                
                screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Jpeg);

                Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
            }
        }
    }
}
