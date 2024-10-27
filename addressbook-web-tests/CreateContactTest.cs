using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class CreateContactTest : TestBase
    {
        [Test]
        public void CreateContactTest1()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            DataContact group1 = new DataContact("Lisa", "Mur");
            FillFormContact(group1);
            Exit();
        }
    }
}