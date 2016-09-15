using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using InfoTycoon.Fwk.TestAutomation;
using System.Threading;
using System.Configuration;

namespace InfoTycoon.Test.Example._02.LandingPage
{
    [TestClass]
    public class LadingPageTest
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
            Pages.Login.Initializes();
        }

        [TestMethod]
        public void LandingPageUI()
        {
            Pages.Login.GoTo();
            Pages.Login.SingIn(name, pass);
            Thread.Sleep(5000);
            Assert.AreEqual(fullname, Pages.LandingPage.LabelUserName);
            Assert.AreEqual(header, Pages.LandingPage.PageHeader);
            Assert.AreEqual(createbutton, Pages.LandingPage.CreateButton);
        }

        [TestMethod]
        public void CreateNewPopUp()
        {
            Pages.Login.GoTo();
            Pages.Login.SingIn(name, pass);
            //Thread.Sleep(5000);
            Pages.LandingPage.CreateNew();
            Thread.Sleep(5000);
            Assert.AreEqual(createmodalheader, Pages.LandingPage.ModalHeader);
        }

        [TestCleanup]
        public void CleanUp()
        {
            //reportHelper.GenerateReport(TestContext);
            //Browser.Quit();
            Pages.Login.Quit();
        }
    }
}
