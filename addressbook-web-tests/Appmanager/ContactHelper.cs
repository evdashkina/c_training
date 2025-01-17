﻿using System;
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

        public ContactHelper Removal(int i)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(i);
           // ModifyContact();
            RemoveContact1();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Removal(DataContact contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact1(contact.IdContact);
            //ModifyContact();
            RemoveContact1();
            ReturnHomePage();
            return this;
        }

        public ContactHelper ContactModify(DataContact newData, DataContact i)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification1(i.IdContact);
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
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillFormContact(DataContact groupcontact)
        {
            Type(By.Name("firstname"), groupcontact.Firstname);
            Type(By.Name("lastname"), groupcontact.Lastname);
            Type(By.Name("middlename"), groupcontact.Middlename);
            Type(By.Name("address"), groupcontact.Address);
            Type(By.Name("home"), groupcontact.Homephone);
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper SelectContact1(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
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

        public ContactHelper RemoveContact1()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
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

        public ContactHelper InitContactModification1(String id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=" + id + "']")).Click();
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

        public string GetContactInformationFromShort()
        {
            manager.Navigator.GoToHomePage();
            InitContactShort();
            
            
            string cells = driver.FindElement(By.CssSelector("div#content")).Text;
            //p = cells.Replace(" ", "").Replace("\n", "").Replace("H:", "").Replace("M:", "").Replace("W:", "").Replace("\r", "");
           
            return cells;
        }

        public string GetContactInformationFromForm()
        {
            manager.Navigator.GoToHomePage();
            InitContactModification();

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            if (firstName != "" && (lastName != "" || middleName != "")) 
            {
                firstName = firstName + " ";
            }

            if (middleName != "" && lastName != "")
              {
                middleName = middleName + " ";
              }

            string nameFull = firstName + middleName + lastName;

            string address = driver.FindElement(By.CssSelector("div#content textarea")).Text;
            if (address != "")
            {
                address = "\r\n" + address;
            }


            string homePhone =driver.FindElement(By.Name("home")).GetAttribute("value");
            if (homePhone != "")
            {
                homePhone = "H: " + homePhone;
            }
           
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            if (mobilePhone != "")
            {
                mobilePhone = "M: " + mobilePhone;
            }
            
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            if (workPhone != "")
            {
                workPhone = "W: " + workPhone;
            }

            string phoneFull = homePhone + mobilePhone + workPhone;
            if (phoneFull != "")
            {
                phoneFull = "\r\n\r\n" + phoneFull;
            }


            string eMail = driver.FindElement(By.Name("email")).GetAttribute("value");
            if (eMail != "" && (nameFull !="" || address != "" || phoneFull !=""))
            {
                eMail = "\r\n\r\n" + eMail;

            }

            return nameFull + address + phoneFull + eMail;

        }

        public void AddContactToGroup(DataContact contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.IdContact);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void SelectContact(string idContact)
        {
            driver.FindElement(By.Id(idContact)).Click();
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }


        public void DeleteContactToGroup(DataContact contact, string id) 
        {
            manager.Navigator.GoToHomePage();
            SelectGroupFilter(id);
            SelectContact1(contact.IdContact);
            DeleteContact();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        private void SelectGroupFilter(string id)
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByValue(id);
        }

        private void DeleteContact()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

    }
}
