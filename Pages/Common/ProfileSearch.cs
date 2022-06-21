using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.Common;

public class ProfileSearch
{
    private IWebDriver _driver;
    private Functions _function;

    public ProfileSearch(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    private By _profileSearchBarControlDiv = By.XPath("//div[contains(@class, 'custom-select__control')]");
    private By _profileSearchBarPlaceholderDiv = By.XPath("//div[contains(@class, 'custom-select__placeholder')]");
    private By _profileSearchBarInputDiv = By.XPath("//div[contains(@class, 'custom-select__input')]");
    private By _profileSearchBarInput = By.Id("react-select-3-input");
    private By _profileSelectionButtonDivDiv = By.XPath("//div[contains(@class, 'custom-select__single-value')]");

    
    

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 

    public void SelectProfile(string profile)
    {
        _function.Click(_profileSelectionButtonDivDiv);

        
        
    }
    
    
    [AllureStep("Search and validate results from Litigation Profile")]
    public void SearchAndValidateResultsFromLitigationAgent(string agent)
    {
        _function.Click(_profileSelectionButtonDivDiv);
        _function.Click(_profileSearchBarControlDiv);
        _function.Click(_profileSearchBarPlaceholderDiv);
        _function.SendText(_profileSearchBarInput, agent);
        _function.Pause(3);
        _function.Enter(_profileSearchBarInput);
    }

    [AllureStep("Search and validate results from Damages")]
    public void SearchAndValidateResultsFromDamages(string damage)
    {
        _function.Click(_profileSelectionButtonDivDiv);
        _function.Click(_profileSearchBarControlDiv);
        _function.Click(_profileSearchBarPlaceholderDiv);
        _function.SendText(_profileSearchBarInput, damage);
        _function.Pause(3);
        _function.Enter(_profileSearchBarInput);
    }
}