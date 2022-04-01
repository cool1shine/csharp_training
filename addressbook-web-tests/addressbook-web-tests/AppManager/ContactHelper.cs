using System;
using System.Collections.Generic;
using OpenQA.Selenium;


namespace Addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        private List<ContactData> contactCache = null;

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("selected[]")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.NavigationHelper.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                                             .FindElements(By.TagName("td"));
            string firstname = cells[2].Text;
            string lastname = cells[1].Text;
            string address = cells[3].Text;
            string phones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {
                Address = address,
                Phones = phones
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.NavigationHelper.GoToHomePage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");
            return new ContactData(firstname, lastname)
            {
                Address = address, 
                Home = home,
                Mobile = mobile,
                Work = work,
            };            
        }

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name=entry]"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> row = element.FindElements(By.CssSelector("td"));
                    string lastname = row[1].Text;
                    string firstname = row[2].Text;
                    contactCache.Add(new ContactData(firstname, lastname));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper CreateNewContact(ContactData contact)
        {
            InitContactCreation();
            FillContactData(contact);
            SubmitContactCreation();
            manager.NavigationHelper.GoToHomePage();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact(int pos)
        {
            DeleteSelectedContact(pos);            
            return this;
        }

        public ContactHelper ModifyContact(int pos, ContactData modContact)
        {
            ModifySelectedContact(pos, modContact);
            manager.NavigationHelper.GoToHomePage();
            return this;
        }

        public bool IsSelectedContactPresented(int pos)
        {
            if (IsElementPresent(By.XPath("//tr[" + (pos + 2) + "]/td/input")))
            {
                return true;
            }
            return false;
        }

        public ContactHelper DeleteSelectedContact(int pos)
        {
            SelectContact(pos);
            DeleteContacts();
            return this;
        }

        public ContactHelper RemoveAllContacts()
        {
            SelectAllContacts();
            DeleteContacts();
            return this;
        }

        public ContactHelper ModifySelectedContact(int pos, ContactData modContact)
        {
            InitContactModification(pos);
            FillContactData(modContact);
            SubmitContactModification();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int pos)
        {
            driver.FindElements(By.Name("entry"))[pos]
                  .FindElements(By.TagName("td"))[7]
                  .FindElement(By.TagName("a"))
                  .Click();
            return this;
        }

        public ContactHelper SelectContact(int pos)
        {
            driver.FindElement(By.XPath("//tr[" + (pos + 2) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper SelectAllContacts()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper DeleteContacts()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            //driver.FindElement(By.CssSelector("div.msgbox"));
            System.Threading.Thread.Sleep(4000);
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactData(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);

            //Не получается сделать загрузку фото
            //driver.FindElement(By.Name("photo")).Click();
            //driver.FindElement(By.Name("photo")).Clear();
            //driver.FindElement(By.Name("photo")).SendKeys("C:\\fakepath\\photo.png");

            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);

            //Не получается сделать выбор даты
            //driver.FindElement(By.Name("bday")).Click();
            //new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            //driver.FindElement(By.XPath("//option[@value='11']")).Click();
            //driver.FindElement(By.Name("bmonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            //driver.FindElement(By.XPath("//option[@value='October']")).Click();
            //driver.FindElement(By.Name("byear")).Click();
            //driver.FindElement(By.Name("byear")).Clear();
            //driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            //driver.FindElement(By.Name("aday")).Click();
            //new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[3]/option[15]")).Click();
            //driver.FindElement(By.Name("amonth")).Click();
            //new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            //driver.FindElement(By.XPath("//div[@id='content']/form/select[4]/option[12]")).Click();
            //driver.FindElement(By.Name("ayear")).Click();
            //driver.FindElement(By.Name("ayear")).Clear();
            //driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);

            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            
            return this;
        }
    }
}
