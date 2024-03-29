﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAddressbookTests;

namespace WebAdressbookTests
{
	public class RemoveContactFromGroupTests : AuthTestBase
	{
		[Test]
		public void TestRemovingContactFromGroup()
		{
			GroupData group = GroupData.GetAll()[0];
			List<ContactData> oldList = group.GetContacts();
			ContactData contact = group.GetContacts().First();

			app.Contacts.RemoveContactFromGroup(contact, group);


			List<ContactData> newList = group.GetContacts();
			oldList.Remove(contact);
			newList.Sort();
			oldList.Sort();

			Assert.AreEqual(oldList, newList);
		}
	}
}

//
