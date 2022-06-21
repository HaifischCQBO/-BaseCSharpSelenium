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
public class EmPuPortfolioBulkUpload : BaseClass
{
    [Ignore("Not able yet to execute")]
    [Test(Description = "Upload multiples portfolios and validates the process")]
    [AllureTag("ExposureManagement")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("NA")]
    [AllureTms("NA")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Exposure Management/Portfolio Upload")]
    [AllureSubSuite("Portfolio Upload")]
    public void EM_PU_Upload_Portfolio_Base_Portfolio()
    {
        var pageIndex = new PageIndex(_driver);
        pageIndex.GoToExposureManagement();
        var pageEm = new PageEm(_driver);
        pageEm.goToPortfolioUpload();
        var portfolioUpload = new PagePorftolioUpload(_driver);
        portfolioUpload.uploadPortfolios();
    }

}