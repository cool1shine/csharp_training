using OpenQA.Selenium;


namespace Addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }
        
        public LoginHelper Login(AccountData user)
        {
            Type(By.Name("user"), user.Username);
            Type(By.Name("pass"), user.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }

        public LoginHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
