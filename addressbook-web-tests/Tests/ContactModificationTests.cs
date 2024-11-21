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

    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {

            if (app.Contacts.ContactAvailab() == false)
            {
                DataContact newContact = new DataContact("Lisa", "Mur");
                app.Contacts.CreateContact(newContact);
            }
            DataContact newData = new DataContact("Elena", "Push");
            List<DataContact> oldGroups1 = app.Contacts.GetContactList();
            app.Contacts.ContactModify(newData);
            List<DataContact> newGroups1 = app.Contacts.GetContactList();
            oldGroups1[0] = newData;
            oldGroups1.Sort();
            newGroups1.Sort();
            Assert.AreEqual(oldGroups1, newGroups1);
        }

    }
}
