using System;
using System.Collections.Generic;
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

                List<GroupData> oldGroups = app.Groups.GetGroupList();

                app.Groups.Remove();

                List<GroupData> newGroups = app.Groups.GetGroupList();
                GroupData toBeRemoved = oldGroups[0];
                oldGroups.RemoveAt(0);
                //oldGroups.Sort();
                //newGroups.Sort();
                Assert.AreEqual(oldGroups, newGroups);

                foreach (GroupData group in newGroups)
                {
                    Assert.AreNotEqual(group.Id, toBeRemoved.Id);
                }
            }
        }
    }
}
