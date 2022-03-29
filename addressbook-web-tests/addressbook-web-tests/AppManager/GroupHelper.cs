using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager) { }

        private List<GroupData> groupCache = null;

        public bool IsSelectedGroupPresented(int pos)
        {
            manager.NavigationHelper.GoToGroupsPage();

            if (IsElementPresent(By.XPath("//div[@id='content']/form/span[" + (pos + 1) + "]/input")))
            {
                return true;
            }
            return false;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.NavigationHelper.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add
                    (
                        new GroupData(element.Text)
                        {
                            Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                        }
                    );
                }

            }
            return new List<GroupData>(groupCache);
        }

        public GroupHelper CreateGroup(GroupData groupData)
        {
            manager.NavigationHelper.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(groupData);
            SubmitGroupCreation();
            manager.NavigationHelper.GoToGroupsPage();
            return this;
        }

        public GroupHelper ModifyGroup(int p, GroupData friends)
        {
            manager.NavigationHelper.GoToGroupsPage();
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
            RemoveSelectedGroup(v);
            manager.NavigationHelper.GoToGroupsPage();
            return this;
        }

        public GroupHelper RemoveSelectedGroup(int v)
        {
            SelectGroup(v);
            RemoveGroup();            
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
            groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
    }
}
