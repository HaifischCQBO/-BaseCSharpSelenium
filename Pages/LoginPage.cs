using OpenQA.Selenium;

namespace SeleniumTest_Alpha.Pages;

public class LoginPage
{
    private IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public By txtUserName => By.Name("UserName");
    public By txtPassword => By.Name("Password");
    public By btnLogin => By.Name("Login");


    public void PerformLogin(string userName, string password)
    {
        _driver.FindElement(txtUserName).SendKeys(userName);
        _driver.FindElement(txtPassword).SendKeys(password);
        _driver.FindElement(btnLogin).Submit();
    } 
    public void PerformLogin_bad(string userName, string password)
    {
        _driver.FindElement(By.Id("d")).SendKeys(userName);
        _driver.FindElement(txtPassword).SendKeys(password);
        _driver.FindElement(btnLogin).Submit();
    }
}