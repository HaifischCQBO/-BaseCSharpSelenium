/*using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumTest_Alpha.Pages;
using SeleniumTest_Alpha.Pages.Common;
using SeleniumTest_Alpha.Pages.RiskProfiles;
using SeleniumTest_Alpha.Pages.Solutions;
using SeleniumTest_Alpha.Pages.Solutions.EM;
using SeleniumTest_Alpha.Pages.Utilities;

namespace SeleniumTestLocal;

[TestFixture]
[AllureNUnit]
[AllureSuite("Smoke Test")]
[AllureDisplayIgnored]
public class StructureSmokeTest : BaseClass
{
    //[Ignore("Debug/Omitted")]
    [Test(Description = "Validation of Structure")]
    [AllureTag("Sanity Check")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("NA")]
    [AllureTms("NA")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Sanity Check - Cometa Content")]
    public void Underwriting_Search()
    {

        var indexPage = new IndexPage(_driver);
        /*SOLUTIONS#1#
        var exposureManagementPage = new ExposureManagementPage(_driver);
        var underwritingPage = new UnderwritingPage(_driver);
        var litigationTrackingPage = new LitigationTrackingPage(_driver);
        /*RISK PROFILES#1#
        var litigationAgentsPage = new LigationAgentsPage(_driver);
        var companiesPage = new CompaniesPage(_driver);
        var industriesPage = new IndustriesPage(_driver);
        var damagesPage = new DamagesPage(_driver);
        var scenariosPage = new ScenariosPage(_driver);
        var themePage = new ThemesPage(_driver);
        var insightPage = new InsightsPage(_driver);
        /*UTILITIES#1#
        var portfolioUploadPage = new PorftolioUploadPage(_driver);
        var reportPage = new ReportPage(_driver);

        indexPage.GoToExposureManagement();
        Assert.True(exposureManagementPage.GetPageTitle().Contains("EXPOSURE MANAGEMENT"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.GoToUnderwriting();
        Assert.True(underwritingPage.GetPageTitle().Contains("UNDERWRITING"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.GoToLitigationTracking();
        Assert.True(litigationTrackingPage.GetPageTitle().Contains("LITIGATION TRACKING"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.GoToLitagionAgents();
        Assert.True(litigationAgentsPage.GetDefaultTitle().Contains("LITAGION PROFILES"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToCompanies();
        Assert.True(companiesPage.GetDefaultTitle().Contains("COMPANY PROFILES"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToIndustries();
        Assert.True(industriesPage.GetDefaultTitle().Contains("INDUSTRY PROFILES"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToDamages();
        Assert.True(damagesPage.GetDefaultTitle().Contains("DAMAGE PROFILES"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToScenarios();
        Assert.True(scenariosPage.GetDefaultTitle().Contains("SCENARIOS"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToThemes();
        Assert.True(themePage.GetDefaultTitle().Contains("THEMES"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToInsights();
        Assert.True(insightPage.GetDefaultTitle().Contains("INSIGHTS"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToPortfolioUpload();
        Assert.True(portfolioUploadPage.GetPageTitle().Contains("PORTFOLIO UPLOAD"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        
        indexPage.goToReport();
        Assert.True(reportPage.GetPageTitle().Contains("REPORTS"), "Title don't match");
        exposureManagementPage.GoToMainPage();
        

    }
}*/