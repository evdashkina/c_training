using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests1 : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }
        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {

           return  JsonConvert.DeserializeObject<List<GroupData>>(
               File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]

        public void GroupCreationTest(GroupData group)
        {
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.getGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity() 
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Groups.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
            start = DateTime.Now;
            AddressBookDB db = new AddressBookDB();
            List<GroupData> fromDb = (from g in db.Groups select g).ToList();
            db.Close();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
