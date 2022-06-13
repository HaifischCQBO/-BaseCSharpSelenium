using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.EM;

public class PagePorftolioUpload
{
    private IWebDriver _driver;
    private Functions _function;


    public PagePorftolioUpload(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT
    private By _portfolioUploadButton = By.XPath("//button[text()='Go to Portfolio Upload']");

    private By _uploadPortfolioFileInput = By.XPath("//input[@type='file']");
    private By _submitPortfolioButton = By.XPath("//button[text()='SUBMIT']");
    private By _submittedMessageDiv = By.XPath("//div[starts-with(@class, 'message')]");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Go to Exposure Management")]
    public void goToPortfolioUpload()
    {
        _function.Click(_portfolioUploadButton);
    }

    [AllureStep("Upload and submitted several portfolios")]
    public void uploadPortfolios()
    {
        var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        var startupPath = currentDirectory.Parent.Parent.Parent.FullName;


        for (var x = 1; x <= 2; x++)
        {
            var file = startupPath + "\\resources\\portfolios\\Portfolio_" + x + ".xlsx";
            _function.SendText(_uploadPortfolioFileInput, file);
            //helpers.Pause(10);
            submitPortfolio();
            waitForElementToUpload();
        }
    }

    [AllureStep("Click on Submit Portfolio")]
    public void submitPortfolio()
    {
        _function.Click(_submitPortfolioButton);
    }

    [AllureStep("Validates that submitted was correct and waits for modal to disappear")]
    public Boolean waitForElementToUpload()
    {
        if (_function.ElementExist(_submittedMessageDiv))
        {
            if (_function.ElementDoNotExist(_submittedMessageDiv))
            {
                return true;
            }
        }

        return false;
    }
}