using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Linq;
using WebAdressbookTests;

namespace WebAddressbookTests
{
	[TestFixture]
	public class AddAddressBookEntry : ContactTestBase
	{
 

	public static IEnumerable<ContactData> RandomContactDataProvider()
		{
			List<ContactData> contacts = new List<ContactData>();
			for (int i = 0; i < 5; i++)
			{
				contacts.Add(new ContactData(GenerateRandomString(20))
				{
					Lastname = GenerateRandomString(20),
				
				});
			}
			return contacts;
		}

		public static IEnumerable<ContactData> ContactDataFromXmlFile()
		{
			return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));

		}

		public static IEnumerable<ContactData> ContactDataFromJsonFile()
		{
			return JsonConvert.DeserializeObject<List<ContactData>>(
				File.ReadAllText(@"contacts.json"));

		}

		[Test, TestCaseSource("ContactDataFromJsonFile")]
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

			List<ContactData> oldContacts = ContactData.GetAll();

			app.Contacts.Create(contact);

			List<ContactData> newContacts = ContactData.GetAll();
			oldContacts.Add(contact);
			oldContacts = oldContacts.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();
			newContacts = newContacts.OrderBy(e => e.Lastname).ThenBy(e => e.Firstname).ToList();
			Assert.AreEqual(oldContacts, newContacts);
		}
	}
}
