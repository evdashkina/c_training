﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<DataContact> fromUI = app.Contacts.GetContactList();
                List<DataContact> fromDB = DataContact.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }

        }
    }
}
