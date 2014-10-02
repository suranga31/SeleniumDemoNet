using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeShell.Test.Core;
using OpenQA.Selenium;
using SeShell.Test.PageObjects;
using SeShell.Test.Enums;

namespace SeShell.Test.Flows
{
    public class FBLoginPageFlow:BaseClass
    {
         public FBLoginPageFlow(IWebDriver driver)
        {
            base.SetWebDriverInstance(driver);
            NavigateTo(string.Empty);
        }

        public FBLandingPageFlow NavigateToLoginPage(string userName, string password)
        {
            // on navigation to the base page. wait for the landing login button to be loaded
            // on load of that button click and get navigated to the actual login page
            try
            {
                this.LoginAs(userName, password);
                ThreadWait.StandardSleep(1);
                IWebElement mainLoginButton = Utilities.FindElement(this.Driver, HtmlElementBy.Id, FBLoginPage.LoginButton());
                mainLoginButton.Click();

                ThreadWait.StandardSleep(2);

                return new FBLandingPageFlow(base.Driver);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

      

        public bool HasUserLoggedIn(string userDisplayName)
        {
            try
            {
                IWebElement mainLoginButton = Utilities.FindElement(this.Driver, HtmlElementBy.XPath, FBLoginPage.LoginSuccessfulUserDisplay());

                if (mainLoginButton.Text == userDisplayName)
                {
                    return true;
                }
            }
            catch (System.Exception)
            {

                return false;
            }

            return false;
        }

        public void LoginAs(string username, string password)
        {
            var userNameElement = Utilities.FindElement(this.Driver, HtmlElementBy.XPath, FBLoginPage.UserNameElement());
            var passwordElement = Utilities.FindElement(this.Driver, HtmlElementBy.XPath, FBLoginPage.PasswordElement());

            Utilities.ClearElements(new IWebElement[] { userNameElement, passwordElement });

            userNameElement.SendKeys(username);
            passwordElement.SendKeys(password);
        }
    }
}
