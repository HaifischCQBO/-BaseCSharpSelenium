using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTest_Alpha.Helpers;

namespace SeleniumTest_Alpha.Pages;

public class PageLogin
{

    private IWebDriver _driver;
    private Functions _function;

    public PageLogin(IWebDriver driver)
    {
        _driver = driver;
        _function = new Functions(driver);
    }

    // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT // WEB ELEMENT

    private By _usernameInput = By.Id("ContentPlaceHolder1_userName");
    private By _passwordInput = By.Id("ContentPlaceHolder1_password");
    private By _signinLink = By.Id("ContentPlaceHolder1_lnkLogin");

    // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS // FUNCTIONS 
    
    [AllureStep("Login with user and password credentials from configuration files")]
    
    public void MakeLogin(){
        _function.SendText(_usernameInput, _function.getXMLParameter("username"));
        _function.SendText(_passwordInput, _function.getXMLParameter("password"));
        _function.Click(_signinLink);
    }
    [AllureStep("Login with user and password credentials from parameteres")]

    public void MakeLogin(string username, string password){
        _function.SendText(_usernameInput, username);
        _function.SendText(_passwordInput, password);
        _function.Click(_signinLink);
    } 
   
}