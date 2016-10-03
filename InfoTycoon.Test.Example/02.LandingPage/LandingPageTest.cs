using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using InfoTycoon.Fwk.TestAutomation;
using System.Threading;
using System.Configuration;
using System.Drawing.Imaging;

namespace InfoTycoon.Test.Example._02.LandingPage
{
    [TestClass]
    public class LandingPageTest
    {
        static string name;
        static string pass;
        static string fullname;
        static string header;
        static string createbutton;
        static string createmodalheader;
        DateTime dt = DateTime.Now;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            name = ConfigurationManager.AppSettings["User"];
            pass = ConfigurationManager.AppSettings["Pass"];
            fullname = ConfigurationManager.AppSettings["FullName"];
            header = ConfigurationManager.AppSettings["LandingHeader"]; 
            createbutton = ConfigurationManager.AppSettings["LandingCreateButton"];
            createmodalheader = ConfigurationManager.AppSettings["CreateNewCompanyModalHeader"];
        }

        [TestInitialize]
        public void Initialize()
        {
            Browser.Initializes(true);
        }

        [TestMethod]
        public void LandingPageUI()
        {
            var loginPage = Pages.Login;
            var landingPage = Pages.LandingPage;

            loginPage.GoTo();
            loginPage.SingIn(name, pass);
            Assert.AreEqual(fullname, landingPage.LabelUserName);
            Assert.AreEqual(header, landingPage.PageHeader);
            Assert.AreEqual(createbutton, landingPage.CreateButton);
            landingPage.PrintScreen("LandingPageUI Test " + dt.ToShortDateString() + " " + dt.Hour.ToString() + " " + dt.Minute.ToString() + " " + dt.Second.ToString(), ImageFormat.Jpeg);
        }

        [TestMethod]
        public void CreateNewPopUp()
        {
            var loginPage = Pages.Login;
            var landingPage = Pages.LandingPage;

            loginPage.GoTo();
            loginPage.SingIn(name, pass);
            landingPage.CreateNew();
            Assert.AreEqual(createmodalheader, landingPage.ModalHeader);
            landingPage.PrintScreen("CreateNewPopUp Test " + dt.ToShortDateString() + " " + dt.Hour.ToString() + " " + dt.Minute.ToString() + " " + dt.Second.ToString(), ImageFormat.Jpeg);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //reportHelper.GenerateReport(TestContext);
            Browser.Quit();
        }
    }
}
