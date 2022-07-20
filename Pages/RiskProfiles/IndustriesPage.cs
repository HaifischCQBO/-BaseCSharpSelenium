using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.RiskProfiles;

public class IndustriesPage
{
    private IWebDriver _driver;
    private Functions _function;

    public IndustriesPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT
    private By _pageTitle = By.XPath("//h1[contains(@class, 'page-title')]");
    private By TitleH2 = By.Id("ContentPlaceHolder1_h2Id");
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Get Industry Title for verification")]
    public string GetIndustryTitle()
    {
        return _function.GetText(TitleH2).ToUpper();;
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