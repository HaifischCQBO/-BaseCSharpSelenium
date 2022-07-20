using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumTest_Alpha.Pages;
using SeleniumTest_Alpha.Pages.Common;
using SeleniumTest_Alpha.Pages.RiskProfiles;
using SeleniumTest_Alpha.Pages.Solutions.EM;

namespace SeleniumTestLocal;

[TestFixture]
[AllureNUnit]
[AllureSuite("Smoke Test")]
[AllureDisplayIgnored]
public class ElasticSearchSmokeTest : BaseClass
{
    //[Ignore("Debug/Omitted")]
    [Test(Description = "Validation of Elastic Search Service")]
    [AllureTag("ElasticSearch")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("NA")]
    [AllureTms("NA")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Elastic Search")]
    public void MainPage_SearchBarTesting()
    {
        var agent = "Toluene";
        var damage = "Autism";
        var industry = "Merchant Wholesalers, Durable Goods";
        var company = "CP KELCO U.S., INC.";
        var scenario = "Sugar";
        var theme = "Toxic trio";
        
        var profileSearch = new ProfileSearch(_driver);
        /*SEARCH AND VALIDATE RESULTS FROM LITIGATION AGENT*/
        profileSearch.SearchAndValidateResultsFromLitigationAgent(agent.ToUpper());
        Assert.True(new LigationAgentsPage(_driver).GetLigitationTitle().Contains(agent.ToUpper()));

        /*GO TO MAIN PAGE TO SEARCH AGAIN*/
        profileSearch.GoToMainPage();

        /*SEARCH AND VALIDATE RESULTS FROM DAMAGES*/
        profileSearch.SearchAndValidateResultsFromDamages(damage.ToUpper());
        Assert.True(new DamagesPage(_driver).GetDamageTitle().Contains(damage.ToUpper()));
        
        /*GO TO MAIN PAGE TO SEARCH AGAIN*/
        profileSearch.GoToMainPage();

        /*SEARCH AND VALIDATE RESULTS FROM INDUSTRIES*/
        profileSearch.SearchAndValidateResultsFromIndustries(industry.ToUpper());
        Assert.True(new IndustriesPage(_driver).GetIndustryTitle().Contains(industry.ToUpper()));
        
        /*GO TO MAIN PAGE TO SEARCH AGAIN*/
        profileSearch.GoToMainPage();
        
        /*SEARCH AND VALIDATE RESULTS FROM COMPANIES*/
        profileSearch.SearchAndValidateResultsFromCompanies(company.ToUpper());
        Assert.True(new CompaniesPage(_driver).GetCompanyTitle().Contains(company.ToUpper()));
        
        /*GO TO MAIN PAGE TO SEARCH AGAIN*/
        profileSearch.GoToMainPage();
        
        /*SEARCH AND VALIDATE RESULTS FROM SCENARIOS*/
        profileSearch.SearchAndValidateResultsFromScenarios(scenario.ToUpper());
        Assert.True(new ScenariosPage(_driver).GetScenarioTitle().Contains(scenario.ToUpper()));
      
        /*GO TO MAIN PAGE TO SEARCH AGAIN*/
        profileSearch.GoToMainPage();
        
        /*SEARCH AND VALIDATE RESULTS FROM SCENARIOS*/
        profileSearch.SearchAndValidateResultsFromThemes(theme.ToUpper());
        Assert.True(new ThemesPage(_driver).GetThemeTitle().Contains(theme.ToUpper()));
    }
}