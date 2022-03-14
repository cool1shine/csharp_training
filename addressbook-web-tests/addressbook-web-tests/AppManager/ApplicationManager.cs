using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected string baseURL;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> applicationManager = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
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

        public WebDriverWait Wait
        { get { return wait; } }

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
