using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Tests.Globals
{
    class Constants
    {
        private const string XpathToFind = ".//([A-Z])\\w+";
        private const string XpathToFind2 = "<a [^>]*>(.*?)</a>";

        //private const string xpathToFind3 = "//*[contains(concat( " ", @class, " " ), concat( " ", "site-header__locations__list", " " ))]//a"
    }
}
