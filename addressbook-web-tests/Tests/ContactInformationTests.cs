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
            DataContact fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            DataContact fromShort = app.Contacts.GetContactInformationFromShort(0);
            Assert.AreEqual(fromForm, fromShort);
           Assert.AreEqual(fromForm.Address, fromShort.Address);
           Assert.AreEqual(fromShort.Homephone, fromForm.Homephone);
           Assert.AreEqual(fromShort.Mobilephone, fromForm.Mobilephone);
           Assert.AreEqual(fromShort.Workphone, fromForm.Workphone);
        }
    }
}
