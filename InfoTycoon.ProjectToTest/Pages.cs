using InfoTycoon.Fwk.TestAutomation;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.ProjectToTest
{
    public static class Pages
    {
        private static Login _LoginPage;
        private static LandingPage _LandingPage;

        public static Login Login
        {
            get
            {
                if (_LoginPage == null)
                {
                    _LoginPage = PageFactoryHelper.InitElements<Login>();
                }
                return _LoginPage;
            }
        }

        public static LandingPage LandingPage
        {
            get
            {
                if (_LandingPage == null)
                {
                    return PageFactoryHelper.InitElements<LandingPage>();
                }
                return _LandingPage;
            }
        }

        //public static Login Login
        //{
        //    get
        //    {
        //        var login = new Login();
        //        PageFactory.InitElements(Browser.Driver, login);
        //        return login;
        //    }
        //}

        //public static LandingPage LandingPage
        //{
        //    get
        //    {
        //        var landingpage = new LandingPage();
        //        PageFactory.InitElements(Browser.Driver, landingpage);
        //        return landingpage;
        //    }
        //}
    }
}
