using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            app.Contacts.ContactModify(newData);
        }

    }
}
