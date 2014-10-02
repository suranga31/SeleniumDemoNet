using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeShell.Test.Core;
using SeShell.Test.Enums;
using SeShell.Test.Flows;
using SeShell.Test.PageObjects;
using SeShell.Test.TestData.Data;

namespace SeShell.Test.TestCases
{
    public class FBLoginTest:AbstractTest
    {
        /// <summary>
        /// Test for successful login
        /// </summary>
        [Test]
        [Category("Smoke")]
        public void FBLoginSuccessful()
        {
            string currentExecutingMethod = Utilities.GetCurrentMethod();
            var resultsWriter = new ResultsWriter(Constants.ParameterizedTest, currentExecutingMethod, true);
            var loginTestData = FBLoginData.GetLoginTestCases();

            Parallel.ForEach(WebDrivers, (driver, loopState) =>
            {
                var testAsserter = new TestCaseAsserts();
                string currentWebBrowserString = Utilities.GetWebBrowser(driver);
                FBLoginData data = Utilities.GetBrowserBasedLoginCredentials(driver);

                if (data != null)
                {
                    var testResultReport = new ResultReport();
                    string testFixtureName = Utilities.GenerateTestFixtureName(this.GetType(), currentExecutingMethod,
                    currentWebBrowserString);
                    testResultReport.StartMethodTimerAndInitiateCurrentTestCase(testFixtureName, true);
                    try
                    {
                        FBLoginPageFlow loginPageflow = new FBLoginPageFlow(driver);
                        loginPageflow.NavigateToLoginPage(data.UserName, data.Password);
                        bool assertionFlag = loginPageflow.HasUserLoggedIn(data.ExpectedResult);
                        testAsserter.AddBooleanAssert(new Action<bool, string>(Assert.IsTrue), loginPageflow.Driver.PageSource.Contains(data.ExpectedResult),
                        Utilities.CombineTestOutcomeString(Constants.SuccessfulUserLogin, data.UserName));
                        testResultReport.SetCurrentTestCaseOutcome(true, testAsserter.AssertionCount.ToString());
                    }
                    catch (Exception e)
                    {
                        ScreenShotImage.CaptureScreenShot(driver, Utilities.CombineTestOutcomeString(Constants.ScreenshotError, data.UserName));
                        testResultReport.SetCurrentTestCaseOutcome(false, testAsserter.AssertionCount.ToString(), e.Message, e.StackTrace);
                    }
                    finally
                    {
                        testResultReport.StopMethodTimerAndFinishCurrentTestCase();
                        base.TestCases.Add(testResultReport.currentTestCase);
                    }
                }
            });

            resultsWriter.WriteResultsToFile(this.GetType().Name, TestCases);
        }

    }
}
