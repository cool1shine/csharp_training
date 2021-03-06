using OpenQA.Selenium;
using System;

namespace Addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }
        
        public LoginHelper Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user))
                {
                    return this;
                }
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
            return IsLoggedIn() && GetLoggedUserName() == account.Username;
                //driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                //== System.String.Format($"({account.Username})");
        }

        private string GetLoggedUserName()
        {
            string rawUsername = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            string username = rawUsername.Substring(1, rawUsername.Length - 2);
            return username;
        }

        public LoginHelper Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("LoginForm"));
            }
            return this;
        }
    }
}
