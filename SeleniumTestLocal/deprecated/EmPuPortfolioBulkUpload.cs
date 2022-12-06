/*using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumTest_Alpha.Pages;
using SeleniumTest_Alpha.Pages.Solutions.EM;
using SeleniumTest_Alpha.Pages.Utilities;

namespace SeleniumTestLocal;

[TestFixture]
[AllureNUnit]
[AllureSuite("Exposure Management")]
[AllureDisplayIgnored]
public class EmPuPortfolioBulkUpload : BaseClass
{
    //[Ignore("Debug/Omitted")]
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
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.uploadPortfolios();
    }

}*/