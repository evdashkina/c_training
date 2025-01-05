using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeleteContatcfromGroup : AuthTestBase
    {
        [Test]
        public void TestDeleteContact()
        {
            GroupData group = GroupData.GetAll()[0];
            List<DataContact> oldList = group.GetContacts();
            DataContact contact = oldList[0];
           

            
            app.Contacts.DeleteContactToGroup(contact, group.Id);


            List<DataContact> newList = group.GetContacts();
            newList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
