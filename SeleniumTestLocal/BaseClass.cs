using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestLocal;

[TestFixture]
public class BaseClass
{
    protected IWebDriver Driver = null!;

    private string dirpath = @"D:\Users\victo\Documents\GitHub\BaseCSharpSelenium\SeleniumTestLocal\Screenshots";

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();
        Driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
    }


    [TearDown]
    public void TestCleanup()
    {
        
        if (TestContext.CurrentContext.Result.Outcome == ResultState.Error)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var filename = "FAILED_"+ TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
            var completePath = Path.Combine(dirpath +@"\"+ filename);
            screenshot.SaveAsFile(completePath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(completePath);
            Console.Out.Write(completePath);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", completePath);

        }else if(TestContext.CurrentContext.Result.Outcome == ResultState.Success)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            var filename = "SUCCESS_"+ TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
            var completePath = Path.Combine(dirpath +@"\"+ filename);
            screenshot.SaveAsFile(completePath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(completePath);
            Console.Out.Write(completePath);
            AllureLifecycle.Instance.AddAttachment(filename, "image/png", completePath);

        }
        Driver.Close();
        Driver.Quit();
    }
}