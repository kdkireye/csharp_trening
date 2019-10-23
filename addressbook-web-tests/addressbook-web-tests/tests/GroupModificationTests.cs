using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
	[TestFixture]

	public class GroupModificationTests : AuthTestBase
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData newData = new GroupData("zzz");
			newData.Header = "jhfglub";
			newData.Footer = "hgfhgbhlkljk;";

			app.Groups.IsModifyGroup();

			List<GroupData> oldGroups = app.Groups.GetGroupList();

			
			app.Groups.Modify(newData);

			List<GroupData> newGroups = app.Groups.GetGroupList();
			oldGroups[0].Name = newData.Name;
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);
		}

		}
}