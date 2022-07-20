using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.Solutions;

public class UnderwritingPage
{
    private IWebDriver _driver;
    private Functions _function;


    public UnderwritingPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

   
    private By _profileSearchBarControlDiv = By.XPath("//div[contains(@class, 'custom-select__control')]");
    private By _pageTitle = By.XPath("//div[contains(@class, 'title_')]");

    private By _profileSearchBarCustomInputDiv = By.XPath("//div[contains(@class, 'custom-select__input')]");
    private By _profileSearchBarContainerDiv = By.XPath("//div[contains(@class, 'custom-select__value-container')]");
    private By _profileSearchBarPlaceholderDiv = By.XPath("//div[contains(@class, 'custom-select__placeholder')]");
    private By _profileOptionsBarInput = By.Id("react-select-6-input");

    /**LOGO TO RETURN TO MAINPAGE*/
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("Search and Validate Company Name")]
    public void Underwriting_SearchCompanyName(string CompanyName)
    {
        _function.Click(_profileSearchBarControlDiv);
        _function.Pause(5);
        _function.SendText(_profileSearchBarControlDiv, CompanyName);
        //_function.Enter(_profileOptionsBarInput);
        
    }
    [AllureStep("Go to Main Page")]
    public void GoToMainPage()
    {
        _function.Click(CometaLogo_link);
    }
    [AllureStep("Get Page Title for verification")]
    public string GetPageTitle()
    {
        return _function.GetText(_pageTitle).ToUpper();
    }
}