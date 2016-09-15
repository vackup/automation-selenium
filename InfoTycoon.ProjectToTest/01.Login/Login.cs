using InfoTycoon.Fwk.TestAutomation;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;

namespace InfoTycoon.ProjectToTest
{
    public class Login : PageBase
    {
        public Login() : base("PageTitleToDefine", "https://dev-my.infotycoon.com/#/account/login/")
        {
        }

        #region Objects
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement txtUserName;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "SubmitButton")]
        private IWebElement btnLogin;

        [FindsBy(How = How.ClassName, Using = "toast-title")]
        private IWebElement errTitle;

        [FindsBy(How = How.ClassName, Using = "toast-message")]
        private IWebElement errMsg;

        #endregion

        #region Methods
        public void SingIn(string name, string pass)
        {
            ImplicitlyWait(10);
            this.txtUserName.SendKeys(name);
            this.txtPassword.SendKeys(pass);
            this.btnLogin.Click();
        }
        #endregion

        #region Properties
        public string ErrorTitle
        {
            get
            {
                return this.errTitle.Text;
            }
        }
        public string ErrorMsg
        {
            get
            {
                return this.errMsg.Text;
            }
        }

        #endregion
    }
}
