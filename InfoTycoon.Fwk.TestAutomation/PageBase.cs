using System;
using System.Drawing.Imaging;
using InfoTycoon.Fwk.TestAutomation.Helpers;
using OpenQA.Selenium;
using System.Threading;

namespace InfoTycoon.Fwk.TestAutomation
{
    public class PageBase
    {
        public String Title { get; set; }
        public String Page { get; set; }

        public PageBase(String title, String page)
        {
            Title = title;
            Page = page;
        }

        public virtual void Initializes(bool maximized = true)
        {
            Browser.Initializes(maximized);
        }

        public virtual void GoTo()
        {
            //ImplicitlyWait(10);
            Browser.GoTo(Page);
        }

        public virtual void Quit()
        {
            Browser.Quit();
        }

        public virtual void PrintScreen(string fileName, ImageFormat imageFormat, string path = null)
        {
            Browser.PrintScreen(fileName, imageFormat, path);
        }

        public virtual void ImplicitlyWait(int sec)
        {
            Browser.ImplicitlyWait(sec);
        }

        public virtual void ExplicitWait(int sec)
        {
            Browser.ExplicitWait(sec);
        }
    }
}
