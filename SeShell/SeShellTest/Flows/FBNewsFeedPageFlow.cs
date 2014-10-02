using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeShell.Test.Core;
using OpenQA.Selenium;
using SeShell.Test.Core;
using SeShell.Test.Enums;
using SeShell.Test.PageObjects;

namespace SeShell.Test.Flows
{
    public class FBNewsFeedPageFlow:BaseClass
    {
         public FBNewsFeedPageFlow(IWebDriver driver)
        {
            base.SetWebDriverInstance(driver);
        }

        public void SelectAndaddStatusUpdate(string statusUpdate, string [] peopleToTag = null)
        {
            var updateStatusLinkElement = Utilities.FindElement(this.Driver, HtmlElementBy.XPath,
                FBNewsFeedPage.UpdateStatusLink());
            updateStatusLinkElement.Click();

            var updateStatusTextAreaElement = Utilities.FindElement(this.Driver, HtmlElementBy.XPath, 
                FBNewsFeedPage.UpdateStatusTextArea());
            updateStatusTextAreaElement.Click();
            updateStatusTextAreaElement.SendKeys(statusUpdate);

            var postStatusButton = Utilities.FindElement(this.Driver, HtmlElementBy.XPath, FBNewsFeedPage.PostButton());
            postStatusButton.Click();
            ThreadWait.StandardSleep(1);
        }

        public bool HasStatusBeenUpdated(string statusUpdate)
        {
            //TODO: Wrtie the asserion and incrment the assertion counter 
            var userContentList = Utilities.FindElements(this.Driver, HtmlElementBy.ClassName, "userContent");
            return userContentList.Any(x => x.Text == statusUpdate);
        }
    }
}
