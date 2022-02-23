using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Addressbook_web_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";            
            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public LoginHelper LoginHelper 
        { get{return loginHelper;} }

        public NavigationHelper NavigationHelper 
        { get{return navigationHelper;} }

        public GroupHelper GroupHelper 
        { get{return groupHelper;} }

        public ContactHelper ContactHelper
        { get{return contactHelper;} }

        public void StopTest()
        {
            driver.Quit();       
        }
    }
}
