using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;
using System.Diagnostics.Contracts;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string data = args[3];

            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }

            List<DataContact> contacts = new List<DataContact>();
            for (int i = 0; i < count; i++) 
            {
                contacts.Add(new DataContact(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
                {
                    Middlename = TestBase.GenerateRandomString(10),
                    Address = TestBase.GenerateRandomString(10),
                    Homephone = TestBase.GenerateRandomString(10)
                });
            }
           
            if (format == "csv" && data == "group")
            {
                writeGroupsToCsvFile(groups, writer);
            }
            else if (format == "xml" && data == "group")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else if (format == "json" && data == "group")
            {
                writeGroupsToJsonFile(groups, writer);
            }
            else if (format == "xml" && data == "contact")
            {
                writeContactsToXmlFile(contacts, writer);
            }
            else if (format == "json" && data == "contact")
            {
                writeContactsToJsonFile(contacts, writer);
            }
            else 
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
            
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static void writeContactsToXmlFile(List<DataContact> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<DataContact>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<DataContact> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

    }
}
