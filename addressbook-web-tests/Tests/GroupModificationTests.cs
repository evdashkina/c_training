using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.GroupAvailab() == false)
            {
                GroupData newGroup = new GroupData("aaa");
                newGroup.Header = "ttt";
                newGroup.Footer = "rrr";
                app.Groups.Create(newGroup);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
