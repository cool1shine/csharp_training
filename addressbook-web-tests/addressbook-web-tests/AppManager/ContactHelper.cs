﻿using OpenQA.Selenium;
using System;

namespace Addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager) { }

        public ContactHelper CreateNewContact(ContactData contact)
        {
            InitContactCreation();
            FillContactData(contact);
            SubmitContactCreation();
            manager.NavigationHelper.GoToHomePage();
            return this;
        }

        public ContactHelper RemoveContact(int pos)
        {
            pos++;

            if (IsElementPresent(By.XPath("//tr[" + pos + "]/td/input")))
            {
                DeleteSelectedContact(--pos);
                return this;
            }

            while (IsElementPresent(By.XPath("//tr[" + pos + "]/td/input")) == false)
            {
                ContactData contactRemovalTest = new ContactData("Test", "Removal");
                CreateNewContact(contactRemovalTest);
            }

            DeleteSelectedContact(--pos);
            return this;
        }

        public ContactHelper ModifyContact(int pos, ContactData modContact)
        {
            pos++;

            if (IsElementPresent(By.XPath("//tr[" + pos + "]/td/input")))
            {
                ModifySelectedContact(--pos, modContact);
                return this;
            }

            while (IsElementPresent(By.XPath("//tr[" + pos + "]/td/input")) == false)
            {
                ContactData contactModTest = new ContactData("Test", "Modification");
                CreateNewContact(contactModTest);
            }

            ModifySelectedContact(--pos, modContact);
            return this;
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
            manager.NavigationHelper.GoToHomePage();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int pos)
        {
            pos++;            
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + pos + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SelectContact(int pos)
        {
            pos++;
            driver.FindElement(By.XPath("//tr[" + pos + "]/td/input")).Click();
            return this;
        }

        public ContactHelper SelectAllContacts()
        {
            driver.FindElement(By.Id("MassCB")).Click();
            return this;
        }

        public ContactHelper DeleteContacts()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
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
