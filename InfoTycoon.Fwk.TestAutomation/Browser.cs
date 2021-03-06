﻿using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;
using System.IO;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace InfoTycoon.Fwk.TestAutomation
{
    public static class Browser
    {
        private const String INTERNET_EXPLORER_DRIVER = "internetexplorerdriver";
        private const String CHROME_DRIVER = "chromedriver";
        private const String INTERNET_EXPLORER_DRIVER_SERVER = "iedriverserver";

        private static IWebDriver webDriver { get; set; }

        public static void Initializes(bool maximized = true)
        {
            if (webDriver == null)
            webDriver = DriverHelper.FactoryDriver();

            if (maximized)
                webDriver.Manage().Window.Maximize();
        }

        public static ISearchContext Driver
        {
            get
            {
                return webDriver;
            }
        }
        
        internal static void GoTo(string url)
        {
            webDriver.Url = url;
        }

        public static void PrintScreen(string fileName, ImageFormat imageFormat, string path = null)
        {
            if (String.IsNullOrEmpty(path))
                path = ConfigurationManager.AppSettings["DefaultImagePath"];
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var file = path + fileName + "." + imageFormat.ToString();
            Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
            ss.SaveAsFile(file, imageFormat);
        }

        public static void Quit()
        {
            webDriver.Quit();
            KillDriverProcesses();
        }

        private static void KillDriverProcesses()
        {
            var driverName = webDriver.GetType().Name.ToLower();
            string processName = String.Empty;
            switch (driverName)
            {
                case INTERNET_EXPLORER_DRIVER: processName = INTERNET_EXPLORER_DRIVER_SERVER;
                    break;
                case CHROME_DRIVER: processName = CHROME_DRIVER;
                    break;
            }
            if (!String.IsNullOrEmpty(processName))
            {
                var processes = Process.GetProcesses().Where(p => p.ProcessName.ToLower() == processName);
                foreach (var process in processes)
                {
                    process.Kill();
                }
            }
        }

        public static void ImplicitlyWait(int sec)
        {
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(sec));
        }

        public static void ExplicitWait(int sec, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(sec));
            wait.Until((webDriver => element.Displayed && element.Enabled));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@class='btn btn-primary'][1]")));
        }
    }
}
