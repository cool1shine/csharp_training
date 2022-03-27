using OpenQA.Selenium;

namespace Addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }
        
        public LoginHelper Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                //if (IsLoggedIn(user))
                //{
                //    return this;
                //}
                Logout();
            }

            Type(By.Name("user"), user.Username);
            Type(By.Name("pass"), user.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            return this;
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                == "(" + account.Username + ")";
        }

        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                //driver.FindElement(By.Name("user"));
            }
            return this;
        }
    }
}
