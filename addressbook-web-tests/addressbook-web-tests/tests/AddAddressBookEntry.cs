using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	[TestFixture]
	public class AddAddressBookEntry : AuthTestBase
	{
 
	[Test]
	public void EditAddressBookEntry()
		{
			ContactData contact = new ContactData("aaa");
			contact.Middlename = "bbb";
			contact.Lastname = "ccc";
			contact.Nickname = "ddd";
			contact.Title = "eee";
			contact.Company = "fff";
			contact.Address = "ggg";
			contact.Home = "hhh";
			contact.Mobile = "iii";
			contact.Work = "jjj";
			contact.Fax = "kkk";
			contact.Email = "lll";
			contact.Email2 = "mmm";
			contact.Email3 = "nnn";
			contact.Homepage = "qqq";
			contact.Address2 = "rrr";
			contact.Phone2 = "sss";
			contact.Notes = "ttt";

			List<ContactData> oldContacts = app.Contacts.GetContactList();

			app.Contacts.Create(contact);

			List<ContactData> newContacts = app.Contacts.GetContactList();
			oldContacts.Add(contact);
			oldContacts.Sort();
			newContacts.Sort();
			Assert.AreEqual(oldContacts, newContacts);
		}
	}
}
