using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.Fwk.TestAutomation.Helpers
{
    public class PageFactoryHelper
    {
        public static T InitElements<T>() where T : PageBase, new()
        {
            T page = new T();
            //Browser.Initializes(true);
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }
    }
}
