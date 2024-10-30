using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests1 : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            
            
            GroupData group = new GroupData("aaa");
            group.Header = "qqq";
            group.Footer = "zzz";
            app.Groups.Create(group);

        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            app.Groups.Create(group);
                
        }
    }
}
