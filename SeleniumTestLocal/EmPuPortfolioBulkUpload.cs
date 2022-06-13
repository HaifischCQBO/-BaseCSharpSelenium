using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumTest_Alpha.Pages;
using SeleniumTest_Alpha.Pages.EM;

namespace SeleniumTestLocal;

[TestFixture]
[AllureNUnit]
[AllureSuite("UnitTest1")]
[AllureDisplayIgnored]
public class EmPuPortfolioBulkUpload : BaseClass
{

    [Test(Description = "Upload multiples portfolios and validates the process")]
    [AllureTag("ExposureManagement")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("NA")]
    [AllureTms("NA")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Exposure Management/Portfolio Upload")]
    [AllureSuite("Exposure Management")]
    [AllureSubSuite("Portfolio Upload")]
    public void EM_PU_Upload_Portfolio_Base_Portfolio()
    {
      /*  var pageIndex = new PageIndex(_driver); 
        pageIndex.goToExposureManagement();
        var pageEm = new PageEm(_driver);
        pageEm.goToPortfolioUpload();
        var portfolioUpload = new PagePorftolioUpload(_driver);
        portfolioUpload.uploadPortfolios();*/

        
    }    
    
}