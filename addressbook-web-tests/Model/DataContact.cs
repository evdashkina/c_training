using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class DataContact : IEquatable<DataContact>, IComparable<DataContact>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
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

        public DataContact(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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

        public string IdContact
        { get; set; }

        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }

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

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
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
                return CleanUpA(address);
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
                return CleanUpB(homephone);
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
                return CleanUpB(mobilephone);
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
                return CleanUpB(workphone);
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

        private string CleanUpB(string phone)
        {
            if (phone == null || phone == "")
            { return ""; }
            return phone.Replace(" ", "").Replace("H:", "").Replace("M:", "").Replace("W:", "").Replace("\r", "") + "\r\n";
            //return Regex.Replace(phone, "[ -()]", "") +"\r\n";
        }

        private string CleanUpA(string phone)
        {
            if (phone == null || phone == "")
            { return ""; }
            return phone.Replace("\r", "");
            //return Regex.Replace(phone, "[ -()]", "") +"\r\n";
        }

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


