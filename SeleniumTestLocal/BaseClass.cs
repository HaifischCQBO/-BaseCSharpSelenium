using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;

namespace SeleniumTestLocal;


public class BaseClass
{
    public IWebDriver driver;
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void Setup()
    {
        this.driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
    }


    [TestCleanup]
    public void TestCleanup()
    {
        Console.Out.Write(Directory.GetCurrentDirectory());
        if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
        {

            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            string saveLocation  = $"C:\\Users\\victo\\RiderProjects\\SeleniumTest_Alpha\\SeleniumTestLocal\\Screenshots/FAILED_{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png";;
            screenshot.SaveAsFile( saveLocation);
            driver.Quit();
        } 
        if (TestContext.CurrentTestOutcome == UnitTestOutcome.Passed)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            string saveLocation  = $"C:\\Users\\victo\\RiderProjects\\SeleniumTest_Alpha\\SeleniumTestLocal\\Screenshots/PASSED_{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png";;
            screenshot.SaveAsFile( saveLocation);
            driver.Quit();
        }
        
    }
}