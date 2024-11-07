using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        

        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData = new GroupData("qqq");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Remove(newData);
            
        }
    }
}
