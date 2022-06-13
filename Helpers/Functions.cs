using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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

    private static void Print(string text)
    {
        Console.Out.Write(text + "\r\n");
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
        element.SendKeys(text);
        Print("Sends Text: " + text + " to Element:" + by);
    }

    public bool ElementExist(By by)
    {
        var element = new WebDriverWait(_driver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists(by));
        if (element != null)
            return true;
        return false;
    }

    public bool ElementDoNotExist(By by)
    {
        if (new WebDriverWait(_driver, TimeSpan.FromSeconds(120)).Until(
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
                    Console.WriteLine("Key: {0} Value: {1}", key, appSettings[key]);  
                }  
            }  
        }  
        catch (ConfigurationErrorsException)  
        {  
            Console.WriteLine("Error reading app settings");  
        }  
    }  
    public string getXMLParameter(string key)
    {
        ReadAllSettings();
        return ConfigurationManager.AppSettings[key];
    }
}