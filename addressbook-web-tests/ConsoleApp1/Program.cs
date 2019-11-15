﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = Convert.ToInt32(args[1]);
			string filename = args[2];
			//StreamWriter writer = new StreamWriter(args[1]);
			string format = args[3];
			string type = args[0];
	

			StreamWriter writer = new StreamWriter(filename);

			if (type == "group")
			{
				List<GroupData> groups = GetGroups(count);

				if (format == "xml")
				{
					writeGroupsToXmlFile(groups, writer);
				}
				else if (format=="json")
				{
					writeGroupsToJsonFile(groups, writer);
				}
			}
			else if (type == "contact")
				{
				List<ContactData> contacts = GetContacts(count);

				if (format == "xml")
				{
					writeContactsToXmlFile(contacts, writer);
				}
				else if (format == "json")
				{
					writeContactsToJsonFile(contacts, writer);
				}

			}
			writer.Close();


			//if (format == "excel")
			//{
			//	writeGroupsToExcelFile(groups, filename);
			//	//Console.Write("test");
			//}
			//else
			//{


			//	if (format == "csv")
			//	{
			//		writeGroupsToCsvFile(groups, writer);
			//	}
			////else if (format == "xml")
			//{
			//	writeGroupsToXmlFile(groups, writer);
			//}
			//else if (format == "json")
			//{
			//	writeGroupsToJsonFile(groups, writer);
			//}
			//else
			//{
			//	System.Console.Out.Write("Unrecognized format" + format);
			//}

			//		writer.Close();
			//	}
		}

		static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
		{
			string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
			File.Delete(fullPath);
			Excel.Application app = new Excel.Application();
			app.Visible = true;
			Excel.Workbook wb = app.Workbooks.Add();
			Excel.Worksheet sheet = wb.ActiveSheet;

			int row = 1;
			foreach (GroupData group in groups)
			{
				sheet.Cells[row, 1] = group.Name;
				sheet.Cells[row, 2] = group.Header;
				sheet.Cells[row, 3] = group.Footer;
				row++;
			}


			wb.SaveAs(fullPath);

			wb.Close();
			app.Visible = false;
			app.Quit();
		}

		static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
		{
			foreach (GroupData group in groups)
			{
				writer.WriteLine(String.Format("${0},${1},${2}",
					group.Name, group.Header, group.Footer));
			}
		}

		static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
		{
			new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
		}

		static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
		{
			writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
		}


		public static List<GroupData> GetGroups(int count)
		{
			List<GroupData> groups = new List<GroupData>();
			for (int i = 0; i < count; i++)
			{
				groups.Add(new GroupData(TestBase.GenerateRandomString(10))
				{
					Header = TestBase.GenerateRandomString(100),
					Footer = TestBase.GenerateRandomString(100)
				});

			}
			return groups;
		}

		public static List<ContactData> GetContacts(int count)
		{
			List<ContactData> contacts = new List<ContactData>();
			for (int i = 0; i < count; i++)
			{
				contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10))
				{
					Firstname = TestBase.GenerateRandomString(100),
					Lastname = TestBase.GenerateRandomString(100),
					Middlename = TestBase.GenerateRandomString(100),
					Nickname = TestBase.GenerateRandomString(100),
					Title = TestBase.GenerateRandomString(100),
					Company = TestBase.GenerateRandomString(100),
					Address = TestBase.GenerateRandomString(100),
					Home = TestBase.GenerateRandomString(100),
					Mobile = TestBase.GenerateRandomString(100),
					Work = TestBase.GenerateRandomString(100),
					Fax = TestBase.GenerateRandomString(100),
					Email = TestBase.GenerateRandomString(100),
					Email2 = TestBase.GenerateRandomString(100),
					Email3 = TestBase.GenerateRandomString(100),
					Homepage = TestBase.GenerateRandomString(100),
					Address2 = TestBase.GenerateRandomString(100),
					Phone2 = TestBase.GenerateRandomString(100)
				});

			}
			return contacts;
		}

		static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
		{
			new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
		}

		static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
		{
			writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
		}

	}
}
