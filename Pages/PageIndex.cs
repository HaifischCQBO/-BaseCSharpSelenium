using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages;

public class PageIndex
{
    private IWebDriver _driver;
    private Functions _function;


    public PageIndex(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    //SOLUTIONS
    private By _exposureManagementLink = By.Id("exposure-management-link");
    private By _underwritingLink = By.Id("exposure-management-link");
    private By _litigationTrackingLink = By.Id("exposure-management-link");

    //RISK PROFILES
    private By _litigationAgentsLink = By.Id("exposure-management-link");
    private By _companiesLink = By.Id("exposure-management-link");


    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Go to Exposure Management")]
    public void goToExposureManagement()
    {
        _function.Click(_exposureManagementLink);
    }
}