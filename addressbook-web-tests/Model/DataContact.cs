﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class DataContact : IEquatable<DataContact>, IComparable<DataContact>
    {
       // private string firstname;
        private string middlename = "";
       // private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string allphones;
        private string address = "";
        private string homephone = "";
        private string mobilephone = "";
        private string workphone = "";
        private string telephonefax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string birthday = "";
        private string anniversary = "";
        private string group1 = "";
        private string allnames = "";
        private string cells = "";

        public DataContact()
        { }

        public DataContact(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public bool Equals(DataContact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }


        public override int GetHashCode()
        {
            return 0;
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + " lastname=" + Lastname;
        }

        public int CompareTo(DataContact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Firstname.CompareTo(other.Firstname) == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }
            else
            {
                return Firstname.CompareTo(other.Firstname);
            }

        }
        [Column(Name = "id"), PrimaryKey]
        public string IdContact
        { get; set; }

        [Column(Name = "firstname")]
        public string Firstname
        {
            get;


            set;   

        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        [Column(Name = "lastname")]
        public string Lastname
        {
            get
            ;
            set
            ;
        }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string Allnames
        {
            get
            {
                if (allnames == null)
                {
                    return allnames;
                }
                else
                {
                    return CleanN(allnames);
                }
            }
           set
             {
                allnames = value;
             }
        }

        private string CleanN(string name)
        {
            if (name == null || name == "")
            { return ""; }
            return name.Replace(" ", "").Replace("\r", "").Replace("\n", "");
        }


        private string CleanC(string item)
        {
            if (item == null || item == "")
            { return ""; }
            return item.Replace(" ", "").Replace("\r", "").Replace("\n", "");

        }

        public string Nickname
        { get; set; }

        public string Title
        { get; set; }

        public string Company
        { get; set; }

        public string Address
        {
            get
            {
               return address;
            }
            set
            {
                address = value;
            }
        }


        public string Homephone
        {
            get
            {
                return homephone;
            }
            set
            {
                homephone = value;
            }
        }

        public string Mobilephone
        {
            get
            {
                return mobilephone;
            }
            set
            {
                mobilephone = value;
            }
        }

        public string Workphone
        {
            get
            {
                return workphone;
            }
            set
            {
                workphone = value;
            }
        }

       public string AllPhones
       {
           get
          {
               if (allphones != null)
               {
                   return allphones;
               }
               else
               {
                    return (CleanUp(Homephone) + CleanUp(Mobilephone) + CleanUp(Workphone)).Trim();
                }
            }
           set
            {
                allphones = value;
            }
       }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            { return ""; }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            //return Regex.Replace(phone, "[ -()]", "") +"\r\n";
        }

        public static List<DataContact> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacs select c).ToList();
            }
        }

        //Where(x => x.Deprecated == "0000-00-00 00:00:00")

        public string Telephonefax
        { get; set; }


        public string Email
        { get; set; }

        public string Email2
        { get; set; }

        public string Email3
        { get; set; }

        public string Homepage
        { get; set; }

        public string Birthday
        { get; set; }

        public string Anniversary
        { get; set; }

        public string Group1
        { get; set; }
    }
}


