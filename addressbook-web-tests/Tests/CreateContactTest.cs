using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests 
{
    [TestFixture]
    public class CreateContactTest : TestBase
    {
        [Test]
        public void CreateContactTest1()
        {
            
            DataContact group1 = new DataContact("Lisa", "Mur");
            app.Contacts.CreateContact(group1);
                
        }
    }
}