/*using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumTest_Alpha.Pages;
using SeleniumTest_Alpha.Pages.Common;
using SeleniumTest_Alpha.Pages.RiskProfiles;
using SeleniumTest_Alpha.Pages.Solutions;
using SeleniumTest_Alpha.Pages.Solutions.EM;

namespace SeleniumTestLocal;

[TestFixture]
[AllureNUnit]
[AllureSuite("Smoke Test")]
[AllureDisplayIgnored]
public class UnderwritingSearchTest : BaseClass
{
    [Ignore("Debug/Omitted")]
    [Test(Description = "Validation of Elastic Search Service")]
    [AllureTag("ElasticSearch")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("NA")]
    [AllureTms("NA")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Elastic Search")]
    public void Underwriting_Search()
    {
        var companyName = "1-800 CONTACTS, INC.";
        var pageIndex = new IndexPage(_driver);
        /*GO TO UNDERWRITING#1#
        pageIndex.GoToUnderwriting();
        /*GO TO UNDERWRITING#1#
        var underwritingPage = new UnderwritingPage(_driver);
        underwritingPage.Underwriting_SearchCompanyName(companyName);






    }
}*/