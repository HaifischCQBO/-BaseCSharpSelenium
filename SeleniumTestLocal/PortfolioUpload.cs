using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using SeleniumTest_Alpha.Helpers;
using SeleniumTest_Alpha.Pages;
using SeleniumTest_Alpha.Pages.Solutions.EM;
using SeleniumTest_Alpha.Pages.Utilities;

namespace SeleniumTestLocal;

[TestFixture]
[AllureNUnit]
[AllureSuite("Portfolio Upload Regression Testing")]
[AllureDisplayIgnored]
public class PuPortfolioUploadSuite : BaseClass
{
    //[Ignore("Debug/Omitted")]
    [Test(Description = "The user must be able to upload a portfolio correctly")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-50]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Upload")]
    [AllureSubSuite("Portfolio Upload")]
    public void PU_01_Upload_Portfolio()
    {
        /* NAME OF THE POLICY CONTAINED AND THE FILE USED */
        var portfolioName = "AUTOMATED_PORFOLIO_1";
        var portfolioFile = "AUT_PORFOLIO_NORMAL.xlsx";

        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* UPLOAD A VALID AND SIMPLE PORFOLIO WITH A POLICY NAMED AS portfolioName variable */
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.uploadPortfolio(portfolioFile);

        /* VALIDATE THAT PORTFOLIO IS CORRECTLY UPLOADED AND VALIDATED */
        portfolioUpload.RefreshAndAssess(portfolioName, portfolioFile);

        /* RETURN TO MAIN PAGE AND EXPOSURE MANAGEMENT */
        portfolioUpload.GoToMainPage();
        pageIndex.GoToExposureManagement();

        /* GO TO EXPOSURE MANAGEMENT AND VERIFY THAT PORTFOLIO IT'S CORRECTLY UPLOADED */
        pageEm.SearchAndSelectPortfolio(portfolioName);
        Assert.True(pageEm.checkPortfolioNameEM(portfolioName));
    }


    [Test(Description = "The user must be able to delete a portfolio correctly")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("TBD")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Deletion")]
    [AllureSubSuite("Portfolio Upload")]
    public void PU_02_Delete_Porfolio()
    {
        /* NAME OF THE POLICY CONTAINED AND THE FILE USED */
        var portfolioName = "AUTOMATED_PORFOLIO_1";
        var portfolioFile = "AUT_PORFOLIO_NORMAL.xlsx";

        
        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* DELETE AN EXISTING PORFOLIO */
        var portfolioUpload = new PorftolioUploadPage(_driver);
        /*SELECT DELETION BUTTON*/
        portfolioUpload.deletePortfolio(portfolioName, portfolioFile);
        /*SELECT DELETION BUTTON*/
        portfolioUpload.deletionModal();
        portfolioUpload.RefreshAndAssessDeletion(portfolioName, portfolioFile);
    }

    [Test(Description = "The user must be able to download the current portfolio template")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-42]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Template")]
    [AllureSubSuite("Portfolio Upload")]
    public void PU_03_Download_Portfolio_Template()
    {
        var portfolioFile = "Praedicat - Portfolio data submission template_v1.9_04182022.xlsx";
        //var portfolioName = "sample portfolio 1";

        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* DOWNLOAD PORTFOLIO TEMPLATE AND CHECK FOR IT*/
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.downloadPortfolio();
        Assert.True(portfolioUpload.waitForFileToBeDownloaded(portfolioFile),
            "File was incorrectly downloaded or no available.");
        
        
    }
    [Test(Description = "The user could not be able to upload a portfolio that has a non valid name")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-48]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Upload")]
    [AllureSubSuite("Portfolio Upload")]
    public void PU_04_Invalid_Name_Portfolio_Validation()
    {
        var portfolioFile = "!@#%#$%#$^$%&^()&!@#%#$%#$^$%&^()!@#%#$%#$^$%&^()!@#%#$%#$^$%&^()!@#%#$%#$^$%&^()!@#%#$%#$^$%&^()!@#%#$%#$^$%&^()!@#%#$%#$^$%&^()!@#%#$%#$^$%&^()$%$#%$%.xlsx";

        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* UPLOAD AN INVALID PORTFOLIO*/
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.uploadInvalidPortfolio(portfolioFile);   
        
        /* CHECK THAT ERROR MESSAGE EXIST AND ITS THE EXPECTED ONE*/
        Assert.True(portfolioUpload.validateErrorModal_portfolioNameValidation(), "Modal didn't exist correctly or displayed another error not related to TC");
        
    } 
    [Test(Description = "The user could not be able to upload a portfolio that has a non valid file")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-49]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Upload")]
    [AllureSubSuite("Portfolio Upload")]
    public void PU_05_Invalid_TypeFile_Portfolio_Validation()
    {
        var portfolioFile = "AUT_PORFOLIO_NORMAL.nonvalid";

        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* UPLOAD AN INVALID PORTFOLIO*/
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.uploadInvalidPortfolio(portfolioFile);   
        
        /* CHECK THAT ERROR MESSAGE EXIST AND ITS THE EXPECTED ONE*/
        Assert.True(portfolioUpload.validateErrorModal_portfolioFileValidation(), "Modal didn't exist correctly or displayed another error not related to TC");




    }
    [Test(Description = "The user could not be able to upload a portfolio that has a non valid file")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-XX]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Overwriting")]
    [AllureSubSuite("Portfolio Upload")]
    //[Ignore("Under Construction")]
    public void PU_06_Overwriting_Portfolio_Validation()
    {
        /* NAME OF THE POLICY CONTAINED AND THE FILE USED */
        var portfolioName = "AUTOMATED_PORFOLIO_OVERWRITTING";
        var portfolioFile = "AUT_PORFOLIO_TO_BE_OVERWRITTEN.xlsx";

        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* UPLOAD A VALID AND SIMPLE PORFOLIO WITH A POLICY NAMED AS portfolioName variable */
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.uploadPortfolio(portfolioFile);

        /*SELECT REVIEW ERRORS AND OVERWRITE*/
        portfolioUpload.SearchAndOverwrite(portfolioName, portfolioFile);

        portfolioUpload.PortfolioCleanup(portfolioName, portfolioFile);


    } 
    

    [Test(Description = "It could be able to upload multiples portfolios with differents accounts")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-XX]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Overwriting")]
    [AllureSubSuite("Portfolio Upload")]
    //[Ignore("Failing Credentials")]
    [TestCase("testautomationzurich@praedicat.com", "pass12", "AUT_PORFOLIO_NORMAL_ZURICH.xlsx", "AUT_PORFOLIO_NORMAL_ZURICH")]
    [TestCase("testautomationsompo@praedicat.com", "pass12", "AUT_PORFOLIO_NORMAL_SOMPO.xlsx", "AUT_PORFOLIO_NORMAL_SOMPO")]
    public void PU_07_Multiaccount_Portfolio_Upload(string username, string password, string  portfolioFile, string portfolioName)
    {
        var pageIndex = new IndexPage(_driver);
        pageIndex.LogOut();
        
        var pageLogin = new PageLogin(_driver);
        pageLogin.MakeLogin(username, password);
        
        /* GO TO EXPOSURE MANAGEMENT PAGE */
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* UPLOAD A VALID AND SIMPLE PORFOLIO WITH A POLICY NAMED AS portfolioName variable */
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.uploadPortfolio(portfolioFile);

        /* VALIDATE THAT PORTFOLIO IS CORRECTLY UPLOADED AND VALIDATED */
        portfolioUpload.RefreshAndAssess(portfolioName, portfolioFile);

        /* RETURN TO MAIN PAGE AND EXPOSURE MANAGEMENT */
        portfolioUpload.GoToMainPage();
        pageIndex.GoToExposureManagement();

        /* GO TO EXPOSURE MANAGEMENT AND VERIFY THAT PORTFOLIO IT'S CORRECTLY UPLOADED */
        pageEm.SearchAndSelectPortfolio(portfolioName);
        Assert.True(pageEm.checkPortfolioNameEM(portfolioName));
        

        portfolioUpload.PortfolioCleanup(portfolioName, portfolioFile);


    }
    [Test(Description = "The user must be able to download the current portfolio template")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-42]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Template")]
    [AllureSubSuite("Portfolio Upload")]
    public void PU_08_Upload_and_Download_Portfolio()
    {
        var portfolioFile = "AUT_PORFOLIO_DOWNLOAD.xlsx";
        var portfolioName = "AUTOMATED_PORFOLIO_DOWNLOADABLE";

        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* DOWNLOAD PORTFOLIO TEMPLATE AND CHECK FOR IT*/
        var portfolioUpload = new PorftolioUploadPage(_driver);
        
        portfolioUpload.uploadPortfolio(portfolioFile);

        portfolioUpload.downloadPortfolio(portfolioName, portfolioFile);
        
        Assert.True(portfolioUpload.waitForFileToBeDownloaded(portfolioFile),
            "File was incorrectly downloaded or no available.");
        portfolioUpload.PortfolioCleanup(portfolioName, portfolioFile);
    }
    [Test(Description = "The user must be able to upload a portfolio correctly")]
    [AllureTag("PortfolioUpload")]
    [AllureSeverity(SeverityLevel.critical)]
    [AllureIssue("SP-9484")]
    [AllureTms("[COMETA-50]")]
    [AllureOwner("Victor Briones")]
    [AllureFeature("FEATURE - Portfolio Upload")]
    [AllureSubSuite("Portfolio Upload")]
    [TestCase(
        "AUT_EXP_MAN_CHECK",
        "AUT_EXP_MAN_CHECK.xlsx",
        "58",
        "$21.3 M",
        "$77.7 M",
        "$54.8 M",
        "$83.4 M",
        "3,302",
        "$25,492.5 M")]
    public void PU_09_Data_Integrity_Portfolio_Uploaded(
        string portfolioName,
        string portfolioFile,
        string litigationAgents,
        string el,
        string tvar5,
        string pml5,
        string pml1,
        string policyCount,
        string sumOfLimit
        )
    {

        /* GO TO EXPOSURE MANAGEMENT PAGE */
        var pageIndex = new IndexPage(_driver);
        pageIndex.GoToExposureManagement();

        /* GO TO PORTFOLIO UPLOAD PAGE */
        var pageEm = new ExposureManagementPage(_driver);
        pageEm.GoToPortfolioUpload();

        /* UPLOAD A VALID AND SIMPLE PORFOLIO WITH A POLICY NAMED AS portfolioName variable */
        var portfolioUpload = new PorftolioUploadPage(_driver);
        portfolioUpload.uploadPortfolio(portfolioFile);

        /* VALIDATE THAT PORTFOLIO IS CORRECTLY UPLOADED AND VALIDATED */
        portfolioUpload.RefreshAndAssessEM(portfolioName,portfolioFile);

        /* RETURN TO MAIN PAGE AND EXPOSURE MANAGEMENT */
        portfolioUpload.GoToMainPage();
        pageIndex.GoToExposureManagement();

        /* GO TO EXPOSURE MANAGEMENT AND VERIFY THAT PORTFOLIO IT'S CORRECTLY UPLOADED */
        pageEm.SearchAndSelectPortfolio(portfolioName);
        Assert.True(pageEm.checkPortfolioNameEM(portfolioName));
        
        pageEm.ValidatePortfolioPL_LitigationAgents(litigationAgents, "Litigation Agents value are not correct");
        pageEm.ValidatePortfolioPL_LT_ELValue(el, "PROBABILISTIC LOSS EL value isn't correct");
        pageEm.ValidatePortfolioPL_LT_PML1Value(pml1, "PROBABILISTIC LOSS PML1 value isn't correct");
        pageEm.ValidatePortfolioPL_LT_PML5Value(pml5, "PROBABILISTIC LOSS PML5 value isn't correct");
        pageEm.ValidatePortfolioPL_LT_TVaRValue_div(tvar5, "PROBABILISTIC LOSS TVaR value isn't correct");
        pageEm.ValidatePortfolioPL_PolicyCount(policyCount, "Policy Count value isn't correct");
        pageEm.ValidatePortfolioPL_SumOfLimits(sumOfLimit, "Sum of Limits value isn't correct");
    }
   
}