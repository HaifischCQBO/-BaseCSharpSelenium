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
    private By _profileSearchBarDamages = By.XPath("//div[@id='react-select-2-option-1']");
    private By _profileSearchBarIndustries = By.XPath("//div[@id='react-select-2-option-2']");
    private By _profileSearchBarCompanies = By.XPath("//div[@id='react-select-2-option-3']");
    private By _profileSearchBarScenarios = By.XPath("//div[@id='react-select-2-option-4']");
    private By _profileSearchBarThemes = By.XPath("//div[@id='react-select-2-option-5']");
    private By _profileSearchBarPlaceholderDiv = By.XPath("//div[contains(@class, 'custom-select__placeholder')]");

    private By _profileMainSearchBarInput = By.Id("react-select-3-input");
    private By _profileOptionsBarInput = By.Id("react-select-4-input");
    
    
    private By _profileSelectionButtonDivDiv = By.XPath("//div[contains(@class, 'custom-select__single-value')]");

    /**LOGO TO RETURN TO MAINPAGE*/
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");


    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 

    public void SelectProfile(string profile)
    {
        _function.Click(_profileSelectionButtonDivDiv);
        _function.Pause(3);

        switch (profile)
        {
            case "damages":
                _function.Click(_profileSearchBarDamages);
                break;
            case "industries":
                _function.Click(_profileSearchBarIndustries);
                break;
            case "companies":
                _function.Click(_profileSearchBarCompanies);
                break;
            case "scenarios":
                _function.Click(_profileSearchBarScenarios);
                break;
            case "themes":
                _function.Click(_profileSearchBarThemes);
                break;
        }

        if (profile.Equals("damages"))
        {
        }
    }

    [AllureStep("Go to Main Page")]
    public void GoToMainPage()
    {
        _function.Click(CometaLogo_link);
    }

    [AllureStep("Search and validate results from Litigation Profile")]
    public void SearchAndValidateResultsFromLitigationAgent(string agent)
    {
        _function.Click(_profileSelectionButtonDivDiv);
        _function.Click(_profileSearchBarControlDiv);
        _function.Click(_profileSearchBarPlaceholderDiv);
        _function.SendText(_profileMainSearchBarInput, agent);
        _function.Pause(3);
        _function.Enter(_profileMainSearchBarInput);
    }

    [AllureStep("Search and validate results from Damages")]
    public void SearchAndValidateResultsFromDamages(string damage)
    {
        SelectProfile("damages");
        _function.SendText(_profileOptionsBarInput, damage);
        _function.Pause(3);
        _function.Enter(_profileOptionsBarInput);
    }

    [AllureStep("Search and validate results from Industries")]
    public void SearchAndValidateResultsFromIndustries(string industry)
    {
        SelectProfile("industries");
        _function.SendText(_profileOptionsBarInput, industry);
        _function.Pause(3);
        _function.Enter(_profileOptionsBarInput);
    }
    [AllureStep("Search and validate results from Companies")]
    public void SearchAndValidateResultsFromCompanies(string company)
    {
        SelectProfile("companies");
        _function.SendText(_profileOptionsBarInput, company);
        _function.Pause(3);
        _function.Enter(_profileOptionsBarInput);
    }
    [AllureStep("Search and validate results from Scenarios")]
    public void SearchAndValidateResultsFromScenarios(string scenarios)
    {
        SelectProfile("scenarios");
        _function.SendText(_profileOptionsBarInput, scenarios);
        _function.Pause(3);
        _function.Enter(_profileOptionsBarInput);
    }
    [AllureStep("Search and validate results from Themes")]
    public void SearchAndValidateResultsFromThemes(string themes)
    {
        SelectProfile("themes");
        _function.SendText(_profileOptionsBarInput, themes);
        _function.Pause(5);
        _function.Enter(_profileOptionsBarInput);
        _function.Pause(5);
    }
}