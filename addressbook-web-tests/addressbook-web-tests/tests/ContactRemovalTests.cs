using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using WebAdressbookTests;

namespace WebAddressbookTests.tests
{
	[TestFixture]

	public class ContactRemovalTests : ContactTestBase
	{
		[Test]

		public void ContactRemovalTest()
		{

			app.Contacts.IsModifyContact();

			List<ContactData> oldContacts = ContactData.GetAll();
			ContactData toBeRemoved = oldContacts[1];
			app.Contacts.Remove(toBeRemoved);
			System.Threading.Thread.Sleep(100);
			List<ContactData> newContacts = ContactData.GetAll();

			oldContacts.RemoveAt(1);

			Assert.AreEqual(oldContacts, newContacts);

			foreach (ContactData contact in newContacts)
			{
				Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
			}
		}
	}
}
