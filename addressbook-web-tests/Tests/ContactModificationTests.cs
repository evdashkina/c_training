using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            DataContact newData = new DataContact("Tatana", "Eva");
            //newData.Firstname = "Tatana";
           // newData.Middlename = "Eva";
            app.Contacts.ContactModify(newData);
        }

    }
}
