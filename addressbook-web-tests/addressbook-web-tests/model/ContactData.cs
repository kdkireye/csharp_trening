﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;


namespace WebAddressbookTests
{
	[Table(Name="addressbook")]
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
	{
		public ContactData()
		{
		}

		private string allPhones;
		private string allEmails;
		private string fullName;

		//private string firstname;
		//private string middlename = "";
		//private string lastname;
		//private string nickname = "";
		//private string title = "";
		//private string company = "";
		//private string address = "";
		//private string home = "";
		//private string mobile = "";
		//private string work = "";
		//private string fax = "";
		//private string email = "";
		//private string email2 = "";
		//private string email3 = "";
		//private string homepage = "";
		//private string address2 = "";
		//private string phone2 = "";
		//private string notes = "";

		public ContactData(string lastname, string firstname)
		{
			Firstname = firstname;
			Lastname = lastname;
		}


		public ContactData(string fullName)
		{

		}

		public bool Equals(ContactData other)

		{
			if (Object.ReferenceEquals(other, null))
			{
				return false;
			}
			if (Object.ReferenceEquals(this, other))
			{
				return true;
			}

			return Firstname == other.Firstname && Lastname == other.Lastname;
		}

		
		public override int GetHashCode()
		{
			return (Firstname + Lastname).GetHashCode();
		}
		
		public override string ToString()
		{
			return ("firstname=" + Firstname + "\nlastname=" + Lastname + "\nmiddlename=" + Middlename + "\nnickname=" + Nickname + "\ntitle=" + Title +
				"\ncompany=" + Company + "\naddress=" + Address + "\nhome=" + Home + "\nmobile=" + Mobile + "\nwork=" + Work + "\nfax=" + Fax + "\nemail=" + Email + "" +
				"\nemail2=" + Email2 + "\nemail3=" + Email3 + "\nhomepage=" + Homepage + "\naddress2=" + Address2 + "\nphone2=" + Phone2);
	}

		public int CompareTo(ContactData other)
		{
			if (Object.ReferenceEquals(other, null))
			{
				return 1;
			}

			int compareResultL = Lastname.CompareTo(other.Lastname);

			if (compareResultL == 0)
			{
				return Firstname.CompareTo(other.Firstname);
				
			}
			else
			{
				return compareResultL;
			}
		}

		[Column(Name = "id"), PrimaryKey, Identity]
		public string Id { get; set; }

		[Column(Name = "deprecated")]
		public string Deprecated { get; set; }

		[Column(Name = "firstname")]
		public string Firstname	{get;set;}

		[Column(Name = "middlename")]
		public string Middlename{get;set;}

		[Column(Name = "lastname")]
		public string Lastname { get; set;}

		[Column(Name = "nickname")]
		public string Nickname {get;set;}

		[Column(Name = "title")]
		public string Title {get;set;}

		[Column(Name = "company")]
		public string Company { get; set;}

		[Column(Name = "address")]
		public string Address	{get;set;}

		[Column(Name = "home")]
		public string Home	{get;set;}

		[Column(Name = "mobile")]
		public string Mobile {get;set;}

		[Column(Name = "work")]
		public string Work { get; set;}

		public string AllPhones
		{
			get
			{
				if (allPhones != null)
				{
					return allPhones;
				}
				else
				{
					return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work)).Trim();
				}
			}
			set
			{
				allPhones = value;
			}
		}

		private string CleanUp(string phone)
		{
			if (phone == null || phone == "")
			{
				return "";
			}
			return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace("H:", "").Replace("M:", "").Replace("W:", "") + "\r\n";
		}

		[Column(Name = "fax")]
		public string Fax { get; set;}

		[Column(Name = "email")]
		public string Email { get; set;}

		[Column(Name = "email2")]
		public string Email2 { get; set;}

		[Column(Name = "email3")]
		public string Email3 { get; set;}

		public string FullName { get; set; }

		
		public string AllEmails
		{
			get
			{
				if (allEmails != null)
				{
					return allEmails;
				}
				else
				{
					return CleanUpEmail(Email) + CleanUp(Email2) + CleanUp(Email3) + "\r\n".Trim();
				}
			}
			set
			{
				allEmails = value;
			}
		}
			   
		public string FullName

		{
			get
			{
				if (fullName != null)
				{
					return fullName.Trim();
				}
				else
				{
					return (Firstname.Trim() + " " + Lastname.Trim());
				}
			}
			set
			{
				fullName = value;
			}
		}

		private string CleanUpEmail(string email)
		{
			if (email == null || email =="")
			{
				return "";
			}
			return email;
		}

		[Column(Name = "homepage")]
		public string Homepage { get; set;}

		[Column(Name = "address2")]
		public string Address2 { get; set;}

		[Column(Name = "phone2")]
		public string Phone2 { get; set;}

		[Column(Name = "notes")]
		public string Notes { get; set;}

		
		public string allDetailsForm;

	
		public string AllDetailsForm
		{
			get
			{
				if (allDetailsForm != null)
				{
					return AllDetailsForm;
				}
				else
				{
					return (Lastname) + (Firstname) + (Address + AllPhones + AllEmails).Trim();
				}
			}
			set
			{
				allDetailsForm = value;
			}
		}
		private string CleanDetailFormUp(string detailsForm)
		{
			if (detailsForm == null || detailsForm == "")
			{
				return "";
			}
			return Regex.Replace(detailsForm, "[ -()'\r?\n\r?\n']", "");
			//	//+ "\r\n";
		}

		public static List<ContactData> GetAll()
		{
			using (AddressBookDB db = new AddressBookDB())
			{
				return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
			}
		}


		//public string allDetails;

		//public string AllDetails
		//{
		//	get
		//	{
		//		if (allDetails != null)
		//		{
		//			return AllDetails;
		//		}
		//		else
		//		{
		//			return (CleanDetailUp(Firstname) + CleanDetailUp(Lastname)).Trim() + (Address + AllEmails + AllPhones).Trim();
		//		}
		//	}
		//	set
		//	{
		//		AllDetails = value;
		//	}
		//}
		//private string CleanDetailUp(string details)
		//{
		//	if (details == null || details == "")
		//	{
		//		return "";
		//	}
		//	return Regex.Replace(details, "[ -()]", "") + "\r\n";
		//}
	}
}


