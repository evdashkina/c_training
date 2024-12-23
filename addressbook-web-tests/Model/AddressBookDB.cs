﻿using LinqToDB;
using OpenQA.Selenium.DevTools.V127.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base(ProviderName.MySql, @"server=localhost; database=addressbook; port=3306; Uid=root; Pwd=; charset=utf8; Allow Zero Datetime=true")
        { }
        public ITable<GroupData> Groups { get { return this.GetTable<GroupData>(); } }

        public ITable<DataContact> Contacs { get { return this.GetTable<DataContact>(); } }
    }
}
