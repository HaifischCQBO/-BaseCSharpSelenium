using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages;

public class IndexPage
{
    private IWebDriver _driver;
    private Functions _function;


    public IndexPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    //SOLUTIONS
    private By _exposureManagementLink = By.Id("exposure-management-link");
    private By _underwritingLink = By.Id("company-risk-score-link");
    private By _litigationTrackingLink = By.Id("emerging-litigation-link");

    //RISK PROFILES
    private By _litigationAgentsLink = By.Id("litagion-section-link");
    private By _companiesLink = By.Id("companies-section-link");
    private By _industriesLink = By.Id("industries-section-link");
    private By _damagesLink = By.Id("damages-section-link");
    private By _scenariosLink = By.Id("scenarios-section-link");
    private By _themesLink = By.Id("themes-section-link");
    private By _insightsLink = By.Id("blog-section-link");

    //UTILITIES
    private By _portfolioUploadLink = By.Id("portfolio-upload-link");
    private By _reportsLink = By.Id("reports-section-link");

    
    /**LOGO TO RETURN TO MAINPAGE*/
    private By CometaLogo_link = By.XPath("//a[@class='cometa-logo']");

    
    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    
    //SOLUTIONS
    [AllureStep("Go to Exposure Management")]
    public void GoToExposureManagement()
    {
        _function.Click(_exposureManagementLink);
    }

    [AllureStep("Go To Underwriting")]
    public void GoToUnderwriting()
    {
        _function.Click(_underwritingLink);
    }

    [AllureStep("Go to Litigation Tracking")]
    public void GoToLitigationTracking()
    {
        _function.Click(_litigationTrackingLink);
    }
    
    //RISK PROFILES
    [AllureStep("Go to Litagion Agents")]
    public void GoToLitagionAgents()
    {
        _function.Click(_litigationAgentsLink);
    }

    [AllureStep("Go to Companies")]
    public void goToCompanies()
    {
        _function.Click(_companiesLink);
    }

    [AllureStep("Go to Industries")]
    public void goToIndustries()
    {
        _function.Click(_industriesLink);
    }

    [AllureStep("Go to Damages")]
    public void goToDamages()
    {
        _function.Click(_damagesLink);
    }

    [AllureStep("Go to Scenarios")]
    public void goToScenarios()
    {
        _function.Click(_scenariosLink);
    }

    [AllureStep("Go to Themes")]
    public void goToThemes()
    {
        _function.Click(_themesLink);
    }

    [AllureStep("Go to Insights")]
    public void goToInsights()
    {
        _function.Click(_insightsLink);
    }
    
    //UTILITIES
    [AllureStep("Go to Portfolio Upload")]
    public void goToPortfolioUpload()
    {
        _function.Click(_portfolioUploadLink);
    } 
    [AllureStep("Go to Report")]
    public void goToReport()
    {
        _function.Click(_reportsLink);
    }
}