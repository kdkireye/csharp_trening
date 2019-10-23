using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
	[TestFixture]

	public class ContactModificationTests : AuthTestBase
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

			List<ContactData> oldContacts = app.Contacts.GetContactList();
						
			app.Contacts.Modify(newData);

			List<ContactData> newContacts = app.Contacts.GetContactList();
			oldContacts[0].Firstname = newData.Firstname;
			oldContacts[0].Lastname = newData.Lastname;
			oldContacts.Sort();
			newContacts.Sort();
			Assert.AreEqual(oldContacts, newContacts);
		}
	}
}
