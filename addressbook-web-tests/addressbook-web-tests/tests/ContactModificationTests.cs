using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAdressbookTests;

namespace WebAddressbookTests.tests
{
	[TestFixture]

	public class ContactModificationTests : ContactTestBase
	{
		[Test]
		public void ContactModificationTest()
		{
			ContactData newData = new ContactData("zzz", "gfrsgf");
			newData.Middlename = "nnn";
			newData.Lastname = "zzz";
			newData.Nickname = "ddd";
			newData.Title = "ppp";
			newData.Company = "mmm";
			newData.Address = "lll";
			newData.Home = "hhh";
			newData.Mobile = "eee";
			newData.Work = "fff";
			newData.Fax = "uuu";
			newData.Email = "yyy";
			newData.Email2 = "ttt";
			newData.Email3 = "rrr";
			newData.Homepage = "qqq";
			newData.Address2 = "ooo";
			newData.Phone2 = "bbb";
			newData.Notes = "vvv";

			app.Contacts.IsModifyContact();

			List<ContactData> oldContacts = ContactData.GetAll();
			ContactData oldContactData = oldContacts[0];

			ContactData newContactData = null;
			app.Contacts.ModifyContact(oldContactData, newContactData);

			List<ContactData> newContacts = ContactData.GetAll();
			oldContacts[0].Firstname = newData.Firstname;
			oldContacts[0].Lastname = newData.Lastname;
			oldContacts.Sort();
			newContacts.Sort();
			Assert.AreEqual(oldContacts, newContacts);

			foreach (ContactData contact in newContacts)
			{
				if (contact.Id == oldContactData.Id)
				{
					Assert.AreEqual(contact.Id, oldContactData.Id);
				}
			}
		}
	}
}
