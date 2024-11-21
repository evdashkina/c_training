using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest() 
        {
            if (app.Contacts.ContactAvailab() == false) 
            {
                DataContact newData = new DataContact("Lisa", "Mur");
                app.Contacts.CreateContact(newData);
            }
            List<DataContact> oldGroups1 = app.Contacts.GetContactList();
            app.Contacts.Removal();
            List<DataContact> newGroups1 = app.Contacts.GetContactList();
            oldGroups1.RemoveAt(0);
            oldGroups1.Sort();
            newGroups1.Sort();
            Assert.AreEqual(oldGroups1, newGroups1);
        }
    }
}
