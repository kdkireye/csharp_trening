﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests.tests
{
	[TestFixture]

	public class ContactRemovalTests : AuthTestBase
	{
		[Test]

		public void ContactRemovalTest()
		{
			app.Contacts.IsModifyContact();Pflfybt #8 (bcghfdktyyjt
			app.Contacts.Remove();
		}
	}
}
