using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelevantCodes.ExtentReports;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;
using System.Drawing.Imaging;

namespace InfoTycoon.Fwk.TestAutomation.Helpers
{
    public class ReportHelper
    {
        private static String filePath = ConfigurationManager.AppSettings["DefaultReportPath"];
        private static String fileName = String.Format("Report_{0}.html", DateTime.Now.ToString("yyyyMMdd_HHmm"));
        private static readonly ExtentReports _instance = new ExtentReports(filePath + fileName, DisplayOrder.OldestFirst);
        public TestContext TestContext { get; set; }

        protected ExtentReports ExtentReport
        {
            get 
            {
                return _instance; 
            }
        }

        protected ExtentTest test;

        public void GenerateReport(TestContext testContext)
        {
            var status = testContext.CurrentTestOutcome;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");

            LogStatus logstatus;

            switch (status)
            {
                case UnitTestOutcome.Failed:
                    logstatus = LogStatus.Fail;
                    break;
                case UnitTestOutcome.Inconclusive:
                    logstatus = LogStatus.Warning;
                    break;
                default:
                    logstatus = LogStatus.Pass;
                    break;
            }

            test = ExtentReport.StartTest(testContext.TestName);
            var testClassName = testContext.FullyQualifiedTestClassName.Split('.').Last();
            test.AssignCategory(testClassName);
            test.Log(logstatus, "Test ended with " + logstatus);
            if (logstatus == LogStatus.Fail)
            {
                try
                {
                    var fileName = String.Format("errorTest_{0}_{1}", testContext.TestName, DateTime.Now.ToString("yyyyMMdd_HHmm"));
                    Browser.PrintScreen(fileName, ImageFormat.Jpeg);
                    var file = ConfigurationManager.AppSettings["DefaultImagePath"] + fileName + "." + ImageFormat.Jpeg;
                    test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(file));
                }
                catch (Exception ex)
                {
                }
            }
            ExtentReport.EndTest(test);
            ExtentReport.Flush();
        }

        [TestInitialize]
        public void Initialize()
        {
            Browser.Initializes();
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.GenerateReport(TestContext);
            Browser.Quit();
        }
    }
}
