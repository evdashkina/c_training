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
        public static IEnumerable<DataContact> RandomContactDataProvider()
        {
            List<DataContact> groups = new List<DataContact>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new DataContact(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(100),
                    Address = GenerateRandomString(100),
                    Homephone = GenerateRandomString(100),
                    Mobilephone = GenerateRandomString(100),
                    Workphone = GenerateRandomString(100),
                    Email = GenerateRandomString(100)
                });
            }
            return groups;
        }



        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreateContactTest1(DataContact group1)
        {
          
            List<DataContact> oldGroups1 = app.Contacts.GetContactList();
            app.Contacts.CreateContact(group1);
            List<DataContact> newGroups1 = app.Contacts.GetContactList();
            oldGroups1.Add(group1);
            oldGroups1.Sort();
            newGroups1.Sort();
            Assert.AreEqual(oldGroups1, newGroups1);

        }

    }
}