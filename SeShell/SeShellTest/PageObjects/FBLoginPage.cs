using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeShell.Test.Resources;

namespace SeShell.Test.PageObjects
{
    public class FBLoginPage
    {
        public static string UserNameElement()
        {
            return FBLoginResources.FbLoginUserNameInputXPath;
        }

        public static string PasswordElement()
        {
            return FBLoginResources.FbLoginPasswordInputXPath;
        }

        public static string LoginButton()
        {
            return FBLoginResources.FBLoginButtonId;
        }

        public static string LoginSuccessfulUserDisplay()
        {
            return FBLoginResources.FBLoginSuccessfulDesiplayLinkXPath;
        }
    }
}
