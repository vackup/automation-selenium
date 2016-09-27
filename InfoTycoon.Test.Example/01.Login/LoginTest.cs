﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using InfoTycoon.ProjectToTest;
using System.Threading;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using InfoTycoon.Fwk.TestAutomation;
using System.Drawing.Imaging;
using System.Configuration;
using System;

namespace InfoTycoon.Test.Example._01.Login
{
    [TestClass]
    public class LoginTest
    {
        //El TestContext almacena toda la info de las pruebas y luego se pasa como parametro para llamar a reportHelper
        //public TestContext TestContext { get; set; }
        //private ReportHelper reportHelper = new ReportHelper();
        static string name;
        static string pass;
        static string fullname;
        static string wrongname;
        static string wrongpass;
        static string errortitle;
        static string errornamemsg;
        static string errorpassmsg;
        DateTime dt = DateTime.Now;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            name = ConfigurationManager.AppSettings["User"];
            pass = ConfigurationManager.AppSettings["Pass"];
            fullname = ConfigurationManager.AppSettings["FullName"];
            wrongname = ConfigurationManager.AppSettings["WrongUser"];
            wrongpass = ConfigurationManager.AppSettings["WrongPass"];
            errortitle = ConfigurationManager.AppSettings["ErrorTitle"];
            errornamemsg = ConfigurationManager.AppSettings["ErrorNameMsg"];
            errorpassmsg = ConfigurationManager.AppSettings["ErrorPassMsg"];
        }

        [TestInitialize]
        public void Initialize()
        {
            //Pages.Login.Initializes();
            //PageBase.Initializes();
            //PageBase.Initializes(maximized);
            //Browser.Initializes(maximized);
        }

        [TestMethod]
        public void UserLogin() 
        {
            Pages.Login.GoTo();
            Pages.Login.SingIn(name, pass);
            Thread.Sleep(5000);
            //Assert.AreEqual(fullname, Pages.LandingPage.LabelUserName);
            //Pages.Login.PrintScreen("UserLogin Test " + dt.ToShortDateString() + " " + dt.Hour.ToString() + " " + dt.Minute.ToString() + " " + dt.Second.ToString(), ImageFormat.Jpeg);
        }

        [TestMethod]
        public void LoginWrongUser()
        {
            Pages.Login.GoTo();
            Pages.Login.SingIn(wrongname, pass);
            Assert.AreEqual(errortitle, Pages.Login.ErrorTitle);
            Assert.AreEqual(errornamemsg, Pages.Login.ErrorMsg);
            Pages.Login.PrintScreen("LoginWrongUser Test " + dt.ToShortDateString() + " " + dt.Hour.ToString() + " " + dt.Minute.ToString() + " " + dt.Second.ToString(), ImageFormat.Jpeg);
        }

        [TestMethod]
        public void LoginWrongPass()
        {
            Pages.Login.GoTo();
            Pages.Login.SingIn(name, wrongpass);
            Assert.AreEqual(errortitle, Pages.Login.ErrorTitle);
            Assert.AreEqual(errorpassmsg, Pages.Login.ErrorMsg);
            Pages.Login.PrintScreen("LoginWrongPass Test " + dt.ToShortDateString() + " " + dt.Hour.ToString() + " " + dt.Minute.ToString() + " " + dt.Second.ToString(), ImageFormat.Jpeg);
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
