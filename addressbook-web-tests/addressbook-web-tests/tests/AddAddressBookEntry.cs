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
 

	public static IEnumerable<ContactData> RandomContactDataProvider()
		{
			List<ContactData> contacts = new List<ContactData>();
			for (int i = 0; i < 5; i ++)
			{
				contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
				{
					Lastname = GenerateRandomString(20),
					Firstname = GenerateRandomString(20),
					Middlename = GenerateRandomString(20),
					Nickname = GenerateRandomString(20),
					Title = GenerateRandomString(20),
					Company = GenerateRandomString(20),
					Address = GenerateRandomString(100),
					Home = GenerateRandomString(20),
					Mobile = GenerateRandomString(20),
					Work = GenerateRandomString(20),
					Fax = GenerateRandomString(20),
					Email = GenerateRandomString(20),
					Email2 = GenerateRandomString(20),
					Email3 = GenerateRandomString(20),
					Homepage = GenerateRandomString(20),
					Address2 = GenerateRandomString(20),
					Phone2 = GenerateRandomString(20)
				});
			}
			return contacts;
		}

	[Test, TestCaseSource("RandomContactDataProvider")]
	public void EditAddressBookEntry(ContactData contact)
		{
			//ContactData contact = new ContactData("ccc", "juyhrfyuh");
			//contact.Middlename = "bbb";
			//contact.Lastname = "aaa";
			//contact.Nickname = "ddd";
			//contact.Title = "eee";
			//contact.Company = "fff";
			//contact.Address = "ggg";
			//contact.Home = "hhh";
			//contact.Mobile = "iii";
			//contact.Work = "jjj";
			//contact.Fax = "kkk";
			//contact.Email = "lll";
			//contact.Email2 = "mmm";
			//contact.Email3 = "nnn";
			//contact.Homepage = "qqq";
			//contact.Address2 = "rrr";
			//contact.Phone2 = "sss";
			//contact.Notes = "ttt";

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
