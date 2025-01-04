using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            // if (app.Groups.GroupAvailab() == false)
            // {
            //    GroupData newGroup = new GroupData("aaa");
            //    newGroup.Header = "ttt";
            //   newGroup.Footer = "rrr";
            //   app.Groups.Create(newGroup);
            //}
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(newData, 0);

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        
         }

    }
}
