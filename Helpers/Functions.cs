using System.Configuration;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject.Common.Extensions;
using static System.Console;
using static System.Diagnostics.Debug;
using static System.Diagnostics.Trace;

namespace SeleniumTest_Alpha.Helpers;

public class Functions
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private readonly int seconds = 40;

    public Functions(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
    }

    public Functions()
    {
    }

    public void Print(string text)
    {
        Out.Write(text + "\r\n");
        Debug.Print(text + "\r\n");
        Trace.Write(text + "\r\n");
        Debug.Write(text + "\r\n");
        Console.Write(text + "\r\n");
    }

    public void Click(By by)
    {
        // Dynamic Wait
        var element = _wait.Until(ExpectedConditions.ElementToBeClickable(by));
        // ----------------------------------------------------
        element.Click();
        Print("Perform Click in Element:" + by);
    }

    public void SendText(By by, string text)
    {
        var element = _wait.Until(ExpectedConditions.ElementExists(by));
        element.Clear();
        element.SendKeys(text);
        Print("Sends Text: " + text + " to Element:" + by);
    }

    public void SendFile(By by, string text)
    {
        var element = _wait.Until(ExpectedConditions.ElementExists(by));
        element.SendKeys(text);
        Print("Sends File: " + text + " to Element:" + by);
    }

    public void SendTextByJS(By by, string text)
    {
        var element = _wait.Until(ExpectedConditions.ElementExists(by));

        IJavaScriptExecutor jse = (IJavaScriptExecutor)_driver;
        jse.ExecuteScript("arguments[0].value='" + text + "';", element);
        jse.ExecuteScript("document.getElementById('" + element + "').value='" + text + "'");
        Print("Sends Text: " + text + " to Element:" + by);
    }

    public bool CheckFileDownloaded(string filename)
    {
        Print("Check that File Download Exists" + filename);
        bool exist = false;
        //string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
        var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
        var startupPath = currentDirectory.Parent.Parent.Parent.FullName;
        var destinationPath = startupPath + "\\resources\\portfolios\\downloads";

        string[] filePaths = Directory.GetFiles(destinationPath);
        foreach (var p in filePaths)
        {
            if (p.Contains(filename))
            {
                FileInfo thisFile = new FileInfo(p);
                //Check the file that are downloaded in the last 3 minutes
                if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    exist = true;
                //File.Delete(p);
                break;
            }
        }

        return exist;
    }

    public bool ElementExist(By by)
    {
        Print("Check that Element Exists" + by);
        try
        {
            _wait.Until(ExpectedConditions.ElementExists(by));
        }
        catch (Exception nse)
        {
            return false;
        }

        return true;
    }


    public bool ElementDoNotExist(By by)
    {
        Print("Check that Element doesn't Exists" + by);

        if (new WebDriverWait(_driver, TimeSpan.FromSeconds(30)).Until(
                ExpectedConditions.InvisibilityOfElementLocated(by)))
            return true;
        return false;
    }


    public void GetUrl(string url)
    {
        Print("Se ingresa a la URL:" + url);
        _driver.Url = url;
    }

    static void ReadAllSettings()
    {
        try
        {
            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings.Count == 0)
            {
                Console.WriteLine("AppSettings is empty.");
            }
            else
            {
                foreach (var key in appSettings.AllKeys)
                {
                    WriteLine("Key: {0} Value: {1}", key, appSettings[key]);
                }
            }
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading app settings");
        }
    }

    public IConfigurationRoot Configuration { get; set; }

    public string getXMLParameter(string key)
    {
        var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        var startupPath = currentDirectory.Parent.Parent.Parent.FullName;

        /* var browser = new ConfigurationBuilder().AddJsonFile(startupPath + "\\appsettings.json").Build();
        var headless = new ConfigurationBuilder().AddJsonFile(startupPath + "\\appsettings.json").Build().GetSection("AppSettings")["headless"];
        var url = new ConfigurationBuilder().AddJsonFile(startupPath + "\\appsettings.json").Build().GetSection("AppSettings")["url"];
        var username = new ConfigurationBuilder().AddJsonFile(startupPath + "\\appsettings.json").Build().GetSection("AppSettings")["username"];
        var password = new ConfigurationBuilder().AddJsonFile(startupPath + "\\appsettings.json").Build().GetSection("AppSettings")["password"];*/

        var config = new ConfigurationBuilder().AddJsonFile(startupPath + "\\appsettings.json").Build();

        Out.WriteLine(config["AppSettings:" + key]);
        return config["AppSettings:" + key];
    }

    public void Pause(int seconds)
    {
         Print("Pausing "+ seconds + " secs");

        Thread.Sleep(seconds * 1000);
    }

    public void WaitUntilElementToBeClickable(By by)
    {
        _wait.Until(ExpectedConditions.ElementToBeClickable(by));
    }
    public void WaitForElementIsVisible(By by)
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(by));
    }


    public void DownArrow(By by)
    {
        var element = _wait.Until(ExpectedConditions.ElementExists(by));
        element.SendKeys(Keys.ArrowDown);
        Print("Sends Arrow Down Key to Element:" + by);
    }

    public void Enter(By by)
    {
        var element = _wait.Until(ExpectedConditions.ElementExists(by));
        element.SendKeys(Keys.Enter);
        Print("Sends Enter Key to Element:" + by);
    }

    public string GetText(By by)
    {
        var text = _wait.Until(ExpectedConditions.ElementIsVisible(by)).Text;
        Print("Got Text: " + text + " from element: " + by);
        return text;
    }
}