﻿using OpenQA.Selenium;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public GroupHelper CreateGroup(GroupData groupData)
        {
            manager.NavigationHelper.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(groupData);
            SubmitGroupCreation();
            manager.NavigationHelper.GoToGroupsPage();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();            

            manager.NavigationHelper.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }

        public GroupHelper ModifyGroup(int p, GroupData friends)
        {
            manager.NavigationHelper.GoToGroupsPage();

            if (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (p+1) + "]/input")))
            {
                ModifySelectedGroup(p, friends);
                return this;
            }

            while (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (p+1) + "]/input")) == false)
            {
                GroupData modTest = new GroupData("Modifcation test");
                CreateGroup(modTest);
            }

            ModifySelectedGroup(p, friends);
            return this;
        }

        public GroupHelper ModifySelectedGroup(int p, GroupData friends)
        {
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(friends);
            SubmitGroupModification();
            manager.NavigationHelper.GoToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int v)
        {
            manager.NavigationHelper.GoToGroupsPage();

            if (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (v + 1) + "]/input")))
            {
                RemoveSelectedGroup(v);                
                return this;
            }

            while (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (v + 1) + "]/input")) == false)
            {
                GroupData removalTest = new GroupData("Removal test");
                CreateGroup(removalTest);
            }

            RemoveSelectedGroup(v);
            return this;

        }

        public GroupHelper RemoveSelectedGroup(int v)
        {
            SelectGroup(v);
            RemoveGroup();
            manager.NavigationHelper.GoToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {

                Type(By.Name("group_name"), groupData.Groupname);
                Type(By.Name("group_header"), groupData.Header);
                Type(By.Name("group_footer"), groupData.Footer);
                return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
