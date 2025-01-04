using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<DataContact> oldList = group.GetContacts();
            DataContact contact = DataContact.GetAll().Except(oldList).First();

            app.Contacts.AddContactToGroup(contact, group);


            List<DataContact> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort(); 
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
