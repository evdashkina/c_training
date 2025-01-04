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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest() 
        {
           // if (app.Contacts.ContactAvailab() == false) 
           // {
           //     DataContact newData = new DataContact("Lisa", "Mur");
           //     app.Contacts.CreateContact(newData);
            //}
            List<DataContact> oldGroups1 = DataContact.GetAll();
            DataContact toBeRemoved = oldGroups1[0];


            app.Contacts.Removal(toBeRemoved);
            List<DataContact> newGroups1 = DataContact.GetAll();
            oldGroups1.RemoveAt(0);
            //oldGroups1.Sort();
            //newGroups1.Sort();

            foreach (DataContact contact in newGroups1)
            {
                Assert.AreNotEqual(contact.IdContact, toBeRemoved.IdContact);
            }


            //Assert.AreEqual(oldGroups1, newGroups1);
        }
    }
}
