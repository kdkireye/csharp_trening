using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]

	public class ContactInformationTests : AuthTestBase
	{
		[Test]

		public void TestContactInformation()
		{
			ContactData fromDetailPage = app.Contacts.GetContactInformationFromDetailPage();
			ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

			//verification
			Assert.AreEqual(fromDetailPage.AllInformationFromDetailPage, fromForm.AllInformationFromForm);

			//Assert.AreEqual(fromTable.FullName, fromForm.FullName);
			//Assert.AreEqual(fromTable.Address, fromForm.Address);
			//Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
			//Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

		}

	}
}
