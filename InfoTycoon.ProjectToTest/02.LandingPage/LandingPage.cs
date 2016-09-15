using InfoTycoon.Fwk.TestAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace InfoTycoon.ProjectToTest
{
    public class LandingPage : PageBase
    {
        public LandingPage() : base("PageTitleToDefine", "https://dev-my.infotycoon.com/#/admindashboard/companies/")
        {
        }

        #region Objects
        [FindsBy(How = How.ClassName, Using = "ng-binding")]
        private IWebElement lblName;

        [FindsBy(How = How.ClassName, Using = "content-header")]
        private IWebElement pageHeader;

        [FindsBy(How = How.LinkText, Using = "Create New")]
        private IWebElement btnCreate;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal']/div/div/div[1]/h3")]
        private IWebElement mdlHeader;
        #endregion

        #region Methods
        public void CreateNew()
        {
            //ImplicitlyWait(10);
            //ExplicitWait(10);
            this.btnCreate.Click();
        }
        #endregion

        #region Properties
        public string LabelUserName
        {
            get
            {
                return this.lblName.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                return this.pageHeader.Text;
            }
        }

        public string CreateButton
        {
            get
            {
                return this.btnCreate.Text;
            }
        }

        public string ModalHeader
        {
            get
            {
                return this.mdlHeader.Text;
            }
        }
        #endregion
    }
}