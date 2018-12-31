using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UI.Tests.Drivers;
using UI.Tests.Globals;

namespace UI.Tests.SitePages
{


    public class HomePage
    {


        public void DebugOutput(List<string> items, string filename)
        {
            // Set a variable to the My Documents path for debugging
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // DEBUG: Write all items found to file for debugging 

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, filename)))
            {
                foreach (string item in items)
                    outputFile.WriteLine(item.ToString());

            }

        }


        public void DebugOutput2(IList<IWebElement> elements, string filename)
        {
            // Set a variable to the My Documents path for debugging
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // DEBUG: Write all items found to file for debugging 

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, filename)))
            {
                foreach (IWebElement element in elements)
                    outputFile.WriteLine(element.Text);

            }

        }
    }


}