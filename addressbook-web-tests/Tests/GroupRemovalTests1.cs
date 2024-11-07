using System;
using System.ComponentModel;
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
    public class GroupRemovalTests : AuthTestBase
    {
       

        [Test]
        public void GroupRemovalTest()
        {
            {
                if (app.Groups.GroupAvailab() == false) 
                {
                    GroupData newGroup = new GroupData("aaa");
                    newGroup.Header = "ttt";
                    newGroup.Footer = "rrr";
                    app.Groups.Create(newGroup);
                }
                app.Groups.Remove();
            }
        }
    }
}
