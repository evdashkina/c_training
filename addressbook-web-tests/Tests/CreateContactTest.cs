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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            DataContact group1 = new DataContact("Lisa", "Mur");
            app.Groups.FillFormContact(group1);
            app.Groups.Logout();
        }
    }
}