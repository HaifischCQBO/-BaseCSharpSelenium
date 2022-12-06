using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.Utilities;

public class PorftolioUploadPage
{
    private IWebDriver _driver;
    private Functions _function;


    public PorftolioUploadPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT
    private By _portfolioUploadButton = By.XPath("//button[text()='Go to Portfolio Upload']");
    private By _pageTitle = By.XPath("//div[contains(@class, 'title_')]");
    private By _uploadPortfolioFileInput = By.XPath("//input[@type='file']");
    private By _submitPortfolioButton = By.XPath("//button[text()='SUBMIT']");
    private By _submittedMessageDiv = By.XPath("//div[starts-with(@class, 'message')]");
    private By _refreshButton = By.XPath("//button[starts-with(@class, 'refresh')]");
    private By _portfolioSearchBar = By.XPath("//input[starts-with(@class, 'filter-text-input')]");
    private By _portfolioSearchBar_2 = By.XPath("(//input[starts-with(@class, 'filter-text-input')])[4]");
    private By _portfolioResultStatus = By.XPath("//*[starts-with(@class, 'portfolio-status_')]");
    private By _portfolioResultLinks = By.XPath("//a[starts-with(@class, 'portfolio-status__')]");
    private By _portfolioDeleteButton = By.XPath("//button[starts-with(@class, 'btn-delete_')]");
    private By _portfolioDeleteButtonModal = By.XPath("//button[starts-with(@class, 'message-button-red_')]");
    private By _portfolioTemplateDownload = By.XPath("//button[starts-with(@class, 'download-button_')]");
    private By _portfolioReviewErrorOption = By.XPath("//button[starts-with(@class, 'download-button_')]");
    private By _portfolioErrorModal = By.XPath("//div[starts-with(@class, 'message-content__')]");


    /**LOGO TO RETURN TO MAINPAGE*/
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");

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


        for (var x = 1; x <= 10; x++)
        {
            var file = startupPath + "\\resources\\portfolios\\Portfolio_" + x + ".xlsx";
            _function.SendText(_uploadPortfolioFileInput, file);
            _function.WaitUntilElementToBeClickable(_submitPortfolioButton);
            submitPortfolio();
            waitForElementToBeProcessed();
        }
    }

    [AllureStep("Upload and submit a valid portfolio")]
    public void uploadPortfolio(string portfolioFile)
    {
        var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        var startupPath = currentDirectory.Parent.Parent.Parent.FullName;


        var file = startupPath + "\\resources\\portfolios\\" + portfolioFile;
        _function.SendFile(_uploadPortfolioFileInput, file);
        _function.WaitUntilElementToBeClickable(_submitPortfolioButton);
        _function.Pause(5);
        submitPortfolio();
        waitForElementToBeProcessed();
    }

    [AllureStep("Upload and submit a invalid portfolio")]
    public void uploadInvalidPortfolio(string portfolioFile)
    {
        var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        var startupPath = currentDirectory.Parent.Parent.Parent.FullName;


        var file = startupPath + "\\resources\\portfolios\\" + portfolioFile;
        _function.Print(file);
        _function.SendFile(_uploadPortfolioFileInput, file);
        _function.Pause(5);
        submitPortfolio();
    }


    [AllureStep("Search and Click Delete Button")]
    public void deletePortfolio(string portfolioName, string portfolioFile)
    {
        _function.SendText(_portfolioSearchBar, portfolioName);
        By _portfolioResultName = By.XPath("//a[@title='" + portfolioFile + "']");

        while (!(_function.ElementExist(_portfolioResultName)))
        {
            _function.Pause(2);
            _function.Click(_refreshButton);
        }

        _function.Click(_portfolioDeleteButton);
    }

    [AllureStep("Handling deletion modal")]
    public void deletionModal()
    {
        _function.Pause(5);
        _function.Print("Delete Modal Text:" + GetModalMessage());
        _function.Click(_portfolioDeleteButtonModal);
        waitForElementToBeProcessed();
    }

    [AllureStep("Click on Submit Portfolio")]
    public void submitPortfolio()
    {
        _function.Click(_submitPortfolioButton);
    }

    [AllureStep("Download Porfolio Template")]
    public void downloadPortfolio()
    {
        _function.Pause(5);
        _function.Click(_portfolioTemplateDownload);
        _function.Pause(10);
    }

    [AllureStep("Download an specific Porfolio ")]
    public void downloadPortfolio(string portfolioName, string portfolioFile)
    {
        _function.SendText(_portfolioSearchBar, portfolioName);

        while (!(_function.ElementExist(By.XPath("//a[@title='" + portfolioFile + "']"))))
        {
            _function.Pause(5);
            _function.Click(_refreshButton);
        }

        _function.Click(By.XPath("//a[@title='" + portfolioFile + "']"));
        _function.Pause(10);
    }

    [AllureStep("Check Modal Existence")]
    public void AssertExistence(By by)
    {
        Assert.True(_function.ElementExist(by));
    }

    [AllureStep("Get modal message")]
    public string GetModalMessage()
    {
        _function.WaitUntilElementToBeClickable(_portfolioErrorModal);
        return _function.GetText(_portfolioErrorModal);
    }

    [AllureStep("Get modal message")]
    public bool validateErrorModal_portfolioNameValidation()
    {
        if (GetModalMessage().Equals("The portfolio template file name exceeds 1001 characters"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [AllureStep("Get modal message")]
    public bool validateErrorModal_portfolioFileValidation()
    {
        if (GetModalMessage().Equals("The portfolio template must be an Excel (.xlsx) file"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    [AllureStep("Validates that submitted was correct and waits for modal to disappear")]
    public Boolean waitForElementToBeProcessed()
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


    [AllureStep("Validates that the file its correcly downloaded")]
    public Boolean waitForFileToBeDownloaded(string filename)
    {
        while (_function.CheckFileDownloaded(filename))
        {
            return true;
        }

        return false;
    }

    [AllureStep("Go to Main Page")]
    public void GoToMainPage()
    {
        _function.Click(CometaLogo_link);
    }

    [AllureStep("Refresh portfolio status history until portfolio it's validated")]
    public void RefreshAndAssess(string portfolioName,  string portfolioFile)
    {
        _function.SendText(_portfolioSearchBar, portfolioName);
        
        By _portfolioResultName = By.XPath("//a[@title='" + portfolioFile + "']");
        
        while (!(_function.ElementExist(_portfolioResultName)))
        {
            _function.Pause(10);
            _function.Click(_refreshButton);
        }

        while (_function.GetText(_portfolioResultStatus).Equals("Calculating"))
        {
            _function.Pause(10);
            _function.Click(_refreshButton);
        }
    }

    [AllureStep("Refresh portfolio status history until portfolio it's validated")]
    public void RefreshAndAssessEM(string portfolioName, string portfolioFile)
    {
        _function.SendText(_portfolioSearchBar, portfolioName);

        By _portfolioResultName = By.XPath("//a[@title='" + portfolioFile + "']");

        while (!(_function.ElementExist(_portfolioResultName)))
        {
            _function.Pause(5);
            _function.Click(_refreshButton);
        }

        while (_function.GetText(_portfolioResultStatus).Equals("Calculating"))
        {
            _function.Pause(5);
            _function.Click(_refreshButton);
        }
    }

    [AllureStep("Search for errors and select overwriting option")]
    public void SearchAndOverwrite(string portfolioName, string portfolioFile)
    {
        _function.SendText(_portfolioSearchBar, portfolioName);

        By _portfolioResultName = By.XPath("//a[@title='" + portfolioFile + "']");

        
        while (!(_function.ElementExist(_portfolioResultName)))
        {
            _function.Pause(5);
            _function.Click(_refreshButton);
        }


        while (_function.GetText(_portfolioResultStatus).Equals("Calculating"))
        {
            _function.Pause(5);
            _function.Click(_refreshButton);
        }

        while (_function.GetText(_portfolioResultLinks).Equals("Review errors"))
        {
            _function.Pause(5);
            _function.Click(_refreshButton);
        }

        _function.Click(_portfolioResultLinks);
        _function.Click(_portfolioReviewErrorOption);

        while (_function.GetText(_portfolioResultStatus).Equals("Calculating"))
        {
            _function.Pause(5);
            _function.Click(_refreshButton);
        }
    }

    [AllureStep("Refresh portfolio status history until portfolio it's deleted")]
    public void RefreshAndAssessDeletion(string portfolioName, string portfolioFile)
    {
        _function.SendText(_portfolioSearchBar, portfolioName);

        By _portfolioResultName = By.XPath("//a[@title='" + portfolioFile + "']");

        while (_function.ElementExist(_portfolioResultName))
        {
            _function.Click(_refreshButton);
            Assert.Equals(_function.GetText(_portfolioResultStatus), "Deleting");
            _function.Pause(1);
        }
    }

    [AllureStep("Get Page Title for verification")]
    public string GetPageTitle()
    {
        return _function.GetText(_pageTitle).ToUpper();
    }

    [AllureStep("Cleanup service for Uploaded portfolios")]
    public void PortfolioCleanup(string portfolioName, string porfolioFile)
    {
        /*SELECT DELETION BUTTON*/
        deletePortfolio(portfolioName, porfolioFile);
        /*SELECT DELETION BUTTON*/
        deletionModal();
        RefreshAndAssessDeletion(portfolioName, porfolioFile);
    }
}