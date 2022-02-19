using OpenQA.Selenium;


namespace Addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(IWebDriver driver) : base(driver) { }
        
        public void Login(AccountData user)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(user.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
