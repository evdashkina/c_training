﻿using System;
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
        { get; set; }

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
        { get; set; }

        public string Telephonehome
        { get; set; }

        public string Telephonemobile
        { get; set; }

        public string Telephonework
        { get; set; }

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
