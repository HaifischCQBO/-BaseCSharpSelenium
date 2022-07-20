using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.RiskProfiles;

public class ThemesPage
{
    private IWebDriver _driver;
    private Functions _function;

    public ThemesPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    private By ContentPlaceHolder1_h1PageTitle = By.Id("ContentPlaceHolder1_h1PageTitle");
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");
    private By _pageTitle = By.XPath("//h1[contains(@class, 'page-title')]");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Get Theme Title for verification")]
    public string GetThemeTitle()
    {
        return _function.GetText(ContentPlaceHolder1_h1PageTitle).ToUpper();
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