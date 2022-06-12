using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest_Alpha.Pages;
using TestProject.SDK;

namespace SeleniumTestLocal;

[TestFixture]
[AllureNUnit]
[AllureSuite("UnitTest1")]
[AllureDisplayIgnored]
public class UnitTest1 : BaseClass
{

    [Test(Description = "Just a Test for NUNIT Allure")]
    [AllureTag("CI")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("8911")]
    [AllureTms("532")]
    [AllureOwner("Victor")]
    [AllureSubSuite("Add")]
    public void TestMethod1()
    {
        LoginPage loginPage = new LoginPage(Driver);
        loginPage.PerformLogin("admin", "admin");

        
    }    
    [Test(Description = "Just a Test for NUNIT Allure TO FAIL")]
    [AllureTag("CI")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("8911")]
    [AllureTms("532")]
    [AllureOwner("Victor")]
    [AllureSubSuite("Failed")]
    public void TestMethod_fail()
    {
        LoginPage loginPage = new LoginPage(Driver);
        loginPage.PerformLogin("admin", "admin");

        
    }
}