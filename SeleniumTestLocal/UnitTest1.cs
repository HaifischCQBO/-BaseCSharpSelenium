using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest_Alpha.Pages;
using TestProject.SDK;

namespace SeleniumTestLocal;

[TestClass]
public class UnitTest1 : BaseClass
{

    [TestMethod]
    public void TestMethod1()
    {
        LoginPage loginPage = new LoginPage(driver);
        loginPage.PerformLogin("admin", "admin");

        
    }
}