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
[AllureSuite("Exposure Management")]
[AllureDisplayIgnored]
public class ElasticSearchSmokeTest : BaseClass
{
   [Test(Description = "Validation of Elastic Search Service through different profile searches ")]
    [AllureTag("ElasticSearch")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("NA")]
    [AllureTms("NA")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Elastic Search/Profile Searching")]
    public void MainPage_SearchBarTesting()
    {
        var pageIndex = new PageIndex(_driver);
        var agent = "Toluene";
        var damage = "Autism";
        var profileSearch = new ProfileSearch(_driver);
        profileSearch.SelectProfile("");
        /*profileSearch.SearchAndValidateResultsFromLitigationAgent(agent);
        Assert.True(new LitigationAgentsPage(_driver).GetLigitationTitle().Contains(agent));
        _functions.GetUrl(_functions.getXMLParameter("url"));
        profileSearch.SearchAndValidateResultsFromDamages(damage);*/

    }
   
}