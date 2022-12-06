using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumTest_Alpha.Helpers;

public class BrowserConfig
{
    private IWebDriver driver;
    Functions _functions = new Functions();

    public IWebDriver SetUpBrowser(String browserString)
    {
        var headlessMode = _functions.getXMLParameter("headless");
        if (browserString.Equals("chrome"))
        {
            //FOLDER CONFIGURATION FOR DOWNLOADS
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            var startupPath = currentDirectory.Parent.Parent.Parent.FullName;
            var destinationPath = startupPath + "\\resources\\portfolios\\downloads";
            
            
            var chromeOptions = new ChromeOptions();
            if (headlessMode.Equals("true"))
            {
                chromeOptions.AddArgument("--headless");
            }

            chromeOptions.AddArguments("--no-sandbox");
            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArguments("--test-type=ui");
            chromeOptions.AddArguments("--disable-gpu-sandbox");
            chromeOptions.AddArguments("--disable-dev-shm-usage");
            chromeOptions.AddUserProfilePreference("download.default_directory", destinationPath);
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            //driver.manage().window().setSize(new Dimension(1920, 1080));
            return driver;
        }
        else if (browserString.Equals("firefox"))
        {
            //TODO implement execution on Firefox
            /* WebDriverManager.firefoxdriver().setup();
             FirefoxOptions firefoxoptions = new FirefoxOptions();
             if(headlessMode.equals("true")) {
                 firefoxoptions.setHeadless(true);
                 firefoxoptions.addArguments("--headless");
             }
             firefoxoptions.addArguments("--no-sandbox");
             driver = new FirefoxDriver(firefoxoptions);
             driver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
             driver.manage().window().maximize();
             driver.manage().window().setSize(new Dimension(1920, 1080));
             return driver;*/
            return null!;
        }

        return null!;
    }
}