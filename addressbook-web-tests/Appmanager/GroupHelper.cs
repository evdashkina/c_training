﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
       
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group) 
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnGroupsPage();
            return this;
        }


        public GroupHelper Modify(GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(newData);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnGroupsPage();
            return this;
        }

        public GroupHelper Remove(GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(newData);
            RemoveGroup();
            ReturnGroupsPage();
            return this;
        }


        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;    
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public GroupHelper ReturnGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[5]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(GroupData newData)
        {
            if (IsElementPresent(By.Name("selected")))
            {
                driver.FindElement(By.Name("selected[]")).Click();
            }
            else
            {
                Create(newData);
                ReturnGroupsPage();
                driver.FindElement(By.Name("selected[]")).Click();
            }
            
            return this;
        }


        public GroupHelper SubmitGroupModification()
        {

            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
