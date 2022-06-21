using System.Configuration;
using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest_Alpha.Helpers;
using SeleniumTest_Alpha.Pages;

namespace SeleniumTestLocal;

[TestFixture]
public class BaseClass
{
    public IWebDriver _driver = null!;
    public Functions _functions;

    private string dirpath = @"D:\Users\victo\Documents\GitHub\BaseCSharpSelenium\SeleniumTestLocal\Screenshots";

    [SetUp]
    public void Setup()
    {
        var browserConfig = new BrowserConfig();
        _driver = browserConfig.SetUpBrowser(new Functions().getXMLParameter("browser"));
        _functions = new Functions(_driver);
        _functions.GetUrl(_functions.getXMLParameter("url"));
        var pageLogin = new PageLogin(_driver);
        pageLogin.MakeLogin();
    }
    
    [TearDown]
    public void TestCleanup()
    {
        if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var filename = "FAILED_" + TestContext.CurrentContext.Test.MethodName + "_screenshot_" +
                           DateTime.Now.Ticks + ".png";
            var completePath = Path.Combine(dirpath + @"\" + filename);
            screenshot.SaveAsFile(completePath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(completePath);
            Console.Out.Write(completePath);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", completePath);
        }
        else if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            var filename = "SUCCESS_" + TestContext.CurrentContext.Test.MethodName + "_screenshot_" +
                           DateTime.Now.Ticks + ".png";
            var completePath = Path.Combine(dirpath + @"\" + filename);
            screenshot.SaveAsFile(completePath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(completePath);
            Console.Out.Write(completePath);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", completePath);
        }

        _driver.Close();
        _driver.Quit();
    }
}