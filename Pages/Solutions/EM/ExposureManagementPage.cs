using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.Solutions.EM;

public class ExposureManagementPage
{
    private IWebDriver _driver;
    private Functions _function;

    public ExposureManagementPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT
    private By _portfolioUploadButton = By.XPath("//button[text()='Go to Portfolio Upload']");
    private By _pageTitle = By.XPath("//div[contains(@class, 'title_')]");


    /**LOGO TO RETURN TO MAINPAGE*/
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Go to Exposure Management")]
    public void GoToPortfolioUpload()
    {
        _function.Click(_portfolioUploadButton);
    }
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