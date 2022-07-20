using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages;

public class ReportPage
{
    private IWebDriver _driver;
    private Functions _function;


    public ReportPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT
    private By _pageTitle = By.XPath("//div[contains(@class, 'page-title_')]");

    /**LOGO TO RETURN TO MAINPAGE*/
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Go to Main Page")]
    public void GoToMainPage()
    {
        _function.Click(CometaLogo_link);
    }
    [AllureStep("Get Page Title for verification")]
    public string GetPageTitle()
    {
        return _function.GetText(_pageTitle).ToUpper();;
    }
}