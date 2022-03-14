using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
            wait = manager.Wait;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
