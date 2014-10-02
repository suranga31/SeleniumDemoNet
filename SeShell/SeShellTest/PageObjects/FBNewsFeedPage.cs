using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeShell.Test.Resources;

namespace SeShell.Test.PageObjects
{
    public class FBNewsFeedPage
    {
        public static string UpdateStatusTextArea()
        {
            return FBNewsFeedResources.UpdateStatusTextAreaXPath;
        }

        public static string UpdateStatusLink()
        {
            return FBNewsFeedResources.UpdateStatusLinkXPath;
        }

        public static string PostButton()
        {
            return FBNewsFeedResources.PostButtonXPath;
        }
    }
}
