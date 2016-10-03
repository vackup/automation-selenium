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
        [FindsBy(How = How.XPath, Using = "//*[@id='profile']/h5")]
        private IWebElement lblName;

        [FindsBy(How = How.ClassName, Using = "content-header")]
        private IWebElement pageHeader;

        [FindsBy(How = How.LinkText, Using = "Create New")]
        private IWebElement btnCreate;

        [FindsBy(How = How.XPath, Using = "//*[@id='modal']/div/div/div[1]/h3")]
        private IWebElement mdlHeader;

        [FindsBy(How = How.XPath, Using = "//tbody[1]")]
        private IWebElement grid;
        #endregion

        #region Methods
        public void CreateNew()
        {
            ExplicitWait(10, grid);
            this.btnCreate.Click();
        }
        #endregion

        #region Properties
        public string LabelUserName
        {
            get
            {
                ExplicitWait(10, lblName);
                return this.lblName.Text;
            }
        }

        public string PageHeader
        {
            get
            {
                ExplicitWait(10, pageHeader);
                return this.pageHeader.Text;
            }
        }

        public string CreateButton
        {
            get
            {
                ExplicitWait(10, btnCreate);
                return this.btnCreate.Text;
            }
        }

        public string ModalHeader
        {
            get
            {
                ExplicitWait(10, mdlHeader);
                return this.mdlHeader.Text;
            }
        }
        #endregion
    }
}