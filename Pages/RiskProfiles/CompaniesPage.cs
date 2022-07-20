using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.RiskProfiles;

public class CompaniesPage
{
    private IWebDriver _driver;
    private Functions _function;

    public CompaniesPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    private By customTitleCompany_div = By.XPath("//div[contains(@class, 'company-name__')]");
    private By _pageTitle = By.XPath("//h1[contains(@class, 'page-title')]");
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Get Company Title for verification")]
    public string GetCompanyTitle()
    {
        return _function.GetText(customTitleCompany_div).ToUpper();;
    }
    [AllureStep("Go to Main Page")]
    public void GoToMainPage()
    {
        _function.Click(CometaLogo_link);
    }
    [AllureStep("Get default Title for verification")]
    public string GetDefaultTitle()
    {
        return _function.GetText(_pageTitle).ToUpper();;
    }   
}