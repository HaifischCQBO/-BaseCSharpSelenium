using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages.RiskProfiles;

public class LitigationAgentsPage
{
    private IWebDriver _driver;
    private Functions _function;

    public LitigationAgentsPage(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    private By litigationTitleH2 = By.Id("ContentPlaceHolder1_h2Id");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    [AllureStep("STEP")]
    public string GetLigitationTitle()
    {
        return _function.GetText(litigationTitleH2);
    }
}