using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeShell.Test.Core;
using OpenQA.Selenium;
using SeShell.Test.Enums;
using SeShell.Test.PageObjects;

namespace SeShell.Test.Flows
{
    public class FBLandingPageFlow :BaseClass
    {
           public FBLandingPageFlow(IWebDriver driver)
        {
            base.SetWebDriverInstance(driver);
        }


        /// <summary>
        /// Performs the navigation.
        /// </summary>
        /// <param name="listItem">The list item.</param>
        /// <param name="subGroups">The sub groups.</param>
        /// <param name="favoritesNavigation"></param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public BaseClass PerformNavigation(Favorites favoritesNavigation, NavigationMode mode)
        {
            BaseClass landingNavigationResult = null;
            string partialNavigationUrl = string.Empty;
            IWebElement element = null;

            switch (favoritesNavigation)
            {
                case Favorites.NewsFeed:
                    partialNavigationUrl = string.Empty;
                    landingNavigationResult = new FBNewsFeedPageFlow(this.Driver);
                    element = Utilities.FindElement(Driver, HtmlElementBy.XPath, FBLandingPage.NewsFeedDiv());
                    break;              
            }

            if (mode == NavigationMode.Click)
            {               
                element.Click();
                ThreadWait.StandardSleep(2);
            }
            else
            {
                base.NavigateTo(partialNavigationUrl);
            }

            return landingNavigationResult;
        }               
    }
}
