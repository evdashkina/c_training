using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Reflection;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
       

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
            this.driver = manager.Driver;
        }

        public ContactHelper CreateContact(DataContact group1) 
        {
            NewAdd();
            FillFormContact(group1);
            Enter();
            return this;
        }

        public ContactHelper Removal(DataContact newData)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(newData);
            ModifyContact();
            RemoveContact();
            ReturnHomePage();
            return this;
        }

        public ContactHelper ContactModify(DataContact newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(newData);
            FillFormContact(newData);
            SubmitContactModification();
            ReturnHomePage();
            return this;
        }

        public ContactHelper NewAdd()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper Enter()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[20]")).Click();
            return this;
        }

        public ContactHelper FillFormContact(DataContact groupcontact)
        {
            Type(By.Name("firstname"), groupcontact.Firstname);
            Type(By.Name("middlename"), groupcontact.Middlename);
            return this;
        }

        public ContactHelper SelectContact(DataContact newData)
        {
            if (IsElementPresent(By.Name("entry")))
            {
                driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            }
            else 
            {
                CreateContact(newData);
                ReturnHomePage();
                driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            }
            return this;
        }
        public ContactHelper ModifyContact() 
        {
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper RemoveContact() 
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            return this;
        }

        public ContactHelper ReturnHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(DataContact newData)
        {
            if (IsElementPresent(By.Name("entry")))
            {
                driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            }
            else
            {
                CreateContact(newData);
                ReturnHomePage();
                driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            }
            
            return this;
        }

    }
}
