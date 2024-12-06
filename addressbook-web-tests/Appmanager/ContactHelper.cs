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
using OpenQA.Selenium.DevTools.V127.DOMSnapshot;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

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
            //driver.FindElements(By.Name("entry"))[index]
            //.FindElements(By.TagName("td"))[7]
            //.FindElement(By.TagName("a")).Click();

            return this;
        }

        public ContactHelper InitContactShort()
        {
            driver.FindElement(By.XPath("//img[@alt='Details']")).Click();
            //driver.FindElements(By.Name("entry"))[index]
            //.FindElements(By.TagName("td"))[7]
            //.FindElement(By.TagName("a")).Click();

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

        public DataContact GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
           string address = cells[3].Text;
           string allPhones = cells[5].Text;

            return new DataContact(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones

            };
        }

        public DataContact GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value"); 
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new DataContact(firstName, lastName)
            {
                Address = address,
                Homephone = homePhone,
                Mobilephone = mobilePhone,
                Workphone = workPhone

            };  
        }
        public int GetNumberOfSearchResult()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public DataContact GetContactInformationFromShort(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactShort();
            string allNames = driver.FindElement(By.CssSelector("div#content b")).Text;
            string[] N = allNames.Split(' ');
            string firstName = N[0];
            string middleName = N[1];
            string lastName = N[2];
            

             string cells = driver.FindElement(By.CssSelector("div#content")).Text;
             string[] mems = cells.Split('\n');
             string address = mems[1];
             string homePhone = mems[3];
             string mobilePhone = mems[4];
             string workPhone = mems[5];

            return new DataContact(firstName, lastName)
           {
                Middlename = middleName,
                Address = address,
                Homephone = homePhone,
                Mobilephone = mobilePhone,
                Workphone = workPhone

           };
        }
    }
}
