using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;

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

        public ContactHelper Removal()
        {
            manager.Navigator.GoToHomePage();
            SelectContact();
            ModifyContact();
            RemoveContact();
            ReturnHomePage();
            return this;
        }

        public ContactHelper ContactModify(DataContact newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();
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
            contactCache = null;
            return this;
        }

        public ContactHelper FillFormContact(DataContact groupcontact)
        {
            Type(By.Name("firstname"), groupcontact.Firstname);
            Type(By.Name("lastname"), groupcontact.Lastname);
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            return this;
        }
        public bool ContactAvailab()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public ContactHelper ModifyContact() 
        {
            driver.FindElement(By.Name("modifiy")).Click();
            return this;
        }

        public ContactHelper RemoveContact() 
        {
            driver.FindElement(By.XPath("//div[@id='content']/form[2]/input[2]")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            
            return this;
        }

        private List<DataContact> contactCache = null;

        public List<DataContact> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<DataContact>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("[name=entry]"));

                foreach (IWebElement element in elements)
                {
                   
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new DataContact(cells[2].Text, cells[1].Text));
                }
                
            }
            return new List<DataContact>(contactCache);
        }

        public DataContact GetContactInformationFromTable()
        {
            throw new NotImplementedException();
        }

        public DataContact GetContactInformationFromEditForm()
        {
            throw new NotImplementedException();
        }
    }
}
