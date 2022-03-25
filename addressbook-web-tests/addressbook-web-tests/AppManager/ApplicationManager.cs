using System;
using System.Threading;
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

        private static ThreadLocal<ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            baseURL = "http://localhost/addressbook/";            
            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        ~ApplicationManager()
        {
            driver.Quit();
        }

        public static ApplicationManager GetInstance()
        {
            if ( ! applicationManager.IsValueCreated)
            { 
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.NavigationHelper.OpenHomePage();
                applicationManager.Value = newInstance;                
            }
            return applicationManager.Value;
        }

        public IWebDriver Driver
        { get{return driver; } }

        public LoginHelper LoginHelper 
        { get{return loginHelper;} }

        public NavigationHelper NavigationHelper 
        { get{return navigationHelper;} }

        public GroupHelper GroupHelper 
        { get{return groupHelper;} }

        public ContactHelper ContactHelper
        { get{return contactHelper;} }


    }
}
