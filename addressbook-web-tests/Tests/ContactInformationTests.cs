using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    [TestFixture]

    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            DataContact fromTable = app.Contacts.GetContactInformationFromTable(0);
            DataContact fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromForm.Address, fromTable.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

        }

        [Test]
        public void TestContactInformationShort()
        {
            string fromShort = app.Contacts.GetContactInformationFromShort();
            string fromForm = app.Contacts.GetContactInformationFromForm();
            Assert.AreEqual(fromShort, fromForm);
          
        }

    }
}
