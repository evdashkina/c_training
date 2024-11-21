using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private string address = "";
        private string telephonehome = "";
        private string telephonemobile = "";
        private string telephonework = "";
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
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

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

        public string Telephonehome
        {
            get
            {
                return telephonehome;
            }
            set
            {
                telephonehome = value;
            }
        }

        public string Telephonemobile
        {
            get
            {
                return telephonemobile;
            }
            set
            {
                telephonemobile = value;
            }
        }

        public string Telephonework
        {
            get
            {
                return telephonework;
            }
            set
            {
                telephonework = value;
            }
        }

        public string Telephonefax
        {
            get
            {
                return telephonefax;
            }
            set
            {
                telephonefax = value;
            }
        }


        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        public string Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }

        public string Anniversary
        {
            get
            {
                return anniversary;
            }
            set
            {
                anniversary = value;
            }
        }


        public string Group1
        {
            get
            {
                return group1;
            }
            set
            {
                group1 = value;
            }
        }
    }

}
