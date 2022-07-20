using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.RiskProfiles;

public class ScenariosPage
{
    private IWebDriver _driver;
    private Functions _function;

    public ScenariosPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    private By customTitleScenario_div = By.XPath("//div[contains(@class, 'custom-select__single-value')]");
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");
    private By _pageTitle = By.XPath("//div[contains(@class, 'title_')]");
    
    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Get Scenario Title for verification")]
    public string GetScenarioTitle()
    {
        return _function.GetText(customTitleScenario_div).ToUpper();;
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