using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
	[TestFixture]

	public class TestForExample12Tests : AuthTestBase
	{
		[Test]

		public void TestForExample12()
		{
			string fromForm = app.Contacts.GetContactInformationFromEditForm1(0);
			string fromDetails = app.Contacts.GetContactInformationFromDetailPage().FullName;

			//verification
			Assert.AreEqual(fromForm, fromDetails);


		}
	}
}
