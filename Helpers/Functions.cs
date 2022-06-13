using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.DefaultWaitHelpers;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTest_Alpha.Helpers;

public class Functions
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private int seconds = 40;

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
        IWebElement element = _wait.Until(ExpectedConditions.ElementToBeClickable(by));
        // ----------------------------------------------------
        element.Click();
        Print("Perform Click in Element:" + by);
    }

    public void SendText(By by, string text)
    {
        IWebElement element = _wait.Until(ExpectedConditions.ElementExists(by));
        element.SendKeys(text);
        Print("Sends Text: " + text + " to Element:" + by);
    }

    public Boolean ElementExist(By by)
    {
        var element = new WebDriverWait(_driver, TimeSpan.FromSeconds(120)).Until(ExpectedConditions.ElementExists(by));
        if (element != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Boolean ElementDoNotExist(By by)
    {
        if (new WebDriverWait(_driver, TimeSpan.FromSeconds(120)).Until(
                ExpectedConditions.InvisibilityOfElementLocated(by)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetUrl(string url)
    {
        Print("Se ingresa a la URL:" + url);
        _driver.Url = url;
    }

    public string getXMLParameter(string key) {
        return ConfigurationManager.AppSettings[key];

    }
}