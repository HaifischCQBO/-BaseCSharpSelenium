using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.Solutions.EM;

public class PageEm
{
    private IWebDriver _driver;
    private Functions _function;

    public PageEm(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT
    private By _portfolioUploadButton = By.XPath("//button[text()='Go to Portfolio Upload']");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Go to Exposure Management")]
    public void goToPortfolioUpload()
    {
        _function.Click(_portfolioUploadButton);
    }
}