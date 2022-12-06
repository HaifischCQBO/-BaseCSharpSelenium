using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V101.CSS;
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

    private By _portfolioInput = By.Id("react-select-2-input");
    private By _portfolioSelection = By.XPath("//div[starts-with(@class, 'custom-select_')]");

    /* Probabilistic loss elements*/
    private By _portfolioPL_LitigationAgents_div = By.XPath("//div[starts-with(@class, 'litagion-agent-value__')]");
    private By _portfolioPL_LT_ELValue_div = By.XPath("//div[starts-with(@class, 'statistic-label__') and text()='EL']/following-sibling::div");
    private By _portfolioPL_LT_TVaRValue_div = By.XPath("//div[starts-with(@class, 'statistic-label__') and text()='TVaR(5)']/following-sibling::div");
    private By _portfolioPL_LT_PML5Value_div = By.XPath("//div[starts-with(@class, 'statistic-label__') and text()='PML(5)']/following-sibling::div");
    private By _portfolioPL_LT_PML1Value_div = By.XPath("//div[starts-with(@class, 'statistic-label__') and text()='PML(1)']/following-sibling::div");
    
    private By _portfolioPL_PolicyCount_div = By.XPath("//div[starts-with(@class, 'portfolio-statistic__')]/div[contains(text(),'Policy count')]/following-sibling::div");
    private By _portfolioPL_SumOfLimits_div = By.XPath("//div[starts-with(@class, 'portfolio-statistic__')]/div[contains(text(),'Sum of limits')]/following-sibling::div");



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
        return _function.GetText(_pageTitle).ToUpper();
    }    
    [AllureStep("Search and Select Porfolio")]
    public void SearchAndSelectPortfolio(string portfolioName)
    {
        _function.SendText(_portfolioInput, portfolioName);
        _function.Pause(5);
        _function.Enter(_portfolioInput);
        _function.Pause(10);
    }
    [AllureStep("Check page selection name")]
    public bool checkPortfolioNameEM(string portfolioName)
    {
        return _function.GetText(_portfolioSelection).Equals(portfolioName);
    }
    [AllureStep("Validation of Probabilistic loss - Litigation Agent Counts")]
    public void ValidatePortfolioPL_LitigationAgents(string litigationAgents, string message)
    {
        Assert.AreEqual(_function.GetText(_portfolioPL_LitigationAgents_div), litigationAgents, message);

    }    
    [AllureStep("Validation of Probabilistic loss - EL Value")]
    public void ValidatePortfolioPL_LT_ELValue(string el, string message)
    {
        Assert.AreEqual(_function.GetText(_portfolioPL_LT_ELValue_div), el, message);

    } 
    
    [AllureStep("Validation of Probabilistic loss - TVaR(5)")]
    public void ValidatePortfolioPL_LT_TVaRValue_div(string tvar5, string message)
    {
        Assert.AreEqual(_function.GetText(_portfolioPL_LT_TVaRValue_div), tvar5, message);

    } 
    
    
    [AllureStep("Validation of Probabilistic loss - PML5 Value")]
    public void ValidatePortfolioPL_LT_PML5Value(string pml5, string message)
    {
        Assert.AreEqual(_function.GetText(_portfolioPL_LT_PML5Value_div), pml5, message);

    }
    
    
    [AllureStep("Validation of Probabilistic loss - PML1 Value")]
    public void ValidatePortfolioPL_LT_PML1Value(string pml1, string message)
    {
        Assert.AreEqual(_function.GetText(_portfolioPL_LT_PML1Value_div), pml1, message);

    }
    
    
    [AllureStep("Validation of Probabilistic loss - Policy Count")]
    public void ValidatePortfolioPL_PolicyCount(string pc, string message)
    {
        Assert.AreEqual(_function.GetText(_portfolioPL_PolicyCount_div), pc, message);

    }
    
    
    [AllureStep("Validation of Probabilistic loss - Sum of limits")]
    public void ValidatePortfolioPL_SumOfLimits(string sol, string message)
    {
        Assert.AreEqual(_function.GetText(_portfolioPL_SumOfLimits_div), sol, message);

    }
    
    
}
