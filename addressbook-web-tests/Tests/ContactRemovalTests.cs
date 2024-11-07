using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            app.Contacts.Removal();
        }
    }
}
