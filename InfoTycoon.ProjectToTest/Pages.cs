using InfoTycoon.Fwk.TestAutomation;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.ProjectToTest
{
    public static class Pages
    {
        public static Login LoginPage
        {
            get
            {
                return PageFactoryHelper.InitElements<Login>();
            }
        }

        public static LandingPage LandingPage
        {
            get
            {
                return PageFactoryHelper.InitElements<LandingPage>();
            }
        }
    }
}
