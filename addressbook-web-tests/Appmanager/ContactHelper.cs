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

        public ContactHelper Removal(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(p);
            ModifyContact();
            RemoveContact();
            ReturnHomePage();
            return this;
        }

        public ContactHelper ContactModify(int v, DataContact newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(v);
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
            
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(groupcontact.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(groupcontact.Middlename);
           
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[7]/a/img")).Click();
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

        public ContactHelper InitContactModification(int v)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ v +"]/td[8]/a/img")).Click();
            return this;
        }

    }
}
