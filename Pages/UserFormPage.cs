using OpenQA.Selenium;

namespace SeleniumTest_Alpha.Pages;

public class UserFormPage
{
    private IWebDriver _driver;

    public UserFormPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public By txtInitial => By.Id("Initial");
    public By txtFirstName=> By.Id("FirstName");
    public By txtMiddleName=> By.Id("MiddleName");
    public By chklanguageHindi=> By.Name("Hindi");

    public void EnterUserForm(string initial, string firstName, string middleName, string language)
    {
        _driver.FindElement(txtInitial).SendKeys(initial);
        _driver.FindElement(txtFirstName).SendKeys(firstName);
        _driver.FindElement(txtMiddleName).SendKeys(middleName);
        _driver.FindElement(chklanguageHindi).Click();
    }
}