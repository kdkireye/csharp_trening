using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.tests
{
	[TestFixture]

	public class GroupModificationTests : GroupTestBase
	{
		[Test]
		public void GroupModificationTest()
		{
			GroupData newData = new GroupData("zzz");
			newData.Header = "jhfglub";
			newData.Footer = "hgfhgbhlkljk;";

			app.Groups.IsModifyGroup();

			List<GroupData> oldGroups = GroupData.GetAll();
			GroupData oldData = oldGroups[0];
			
			app.Groups.Modify(oldData, newData);

			Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

			List<GroupData> newGroups = GroupData.GetAll();
			oldGroups[0].Name = newData.Name;
			oldGroups.Sort();
			newGroups.Sort();
			Assert.AreEqual(oldGroups, newGroups);

			foreach (GroupData group in newGroups)
			{
				if (group.Id == oldData.Id)
				{
					Assert.AreEqual(newData.Name, group.Name);
				}
			}
		}

		}
}