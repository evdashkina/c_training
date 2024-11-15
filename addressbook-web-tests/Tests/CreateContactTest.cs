using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class CreateContactTest : AuthTestBase
    {
        [Test]
        public void CreateContactTest1()
        {
            
            DataContact group1 = new DataContact("Lisa", "Mur");
            List<DataContact> oldGroups1 = app.Contacts.GetContactList();
            app.Contacts.CreateContact(group1);
            List<DataContact> newGroups1 = app.Contacts.GetContactList();
            oldGroups1.Add(group1);
            oldGroups1.Sort();
            newGroups1.Sort();
            Assert.AreEqual(oldGroups1, newGroups1);

        }

        [Test]
        public void CreateEmptyContactTest()
        {

            DataContact group1 = new DataContact("", "");
            app.Contacts.CreateContact(group1);

        }
    }
}