using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
	public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
	{
		private string allPhones;

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
			return (Firstname + Lastname);
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
		public string Firstname	{get;set;}

		public string Middlename{get;set;}
		

		public string Lastname { get; set;}

		public string Nickname {get;set;}

		public string Title {get;set;}

		public string Company { get; set;}

		public string Address	{get;set;}

		public string Home	{get;set;}

		public string Mobile {get;set;}

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
			return  Regex.Replace(phone, "[ -()]","") + "\r\n";
		}

		public string Fax { get; set;}
		
		public string Email { get; set;}
		
		public string Email2 { get; set;}

		public string Email3 { get; set;}

		public string allEmails;

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
					return CleanUpEmail(Email) + CleanUp(Email2) + CleanUp(Email3).Trim();
				}
			}
			set
			{
				allEmails = value;
			}
		}
		private string CleanUpEmail(string email)
		{
			if (email == null || email =="")
			{
				return "";
			}
			return email.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
		}

					   
		public string Homepage { get; set;}
		
		public string Address2 { get; set;}
		
		public string Phone2 { get; set;}
		
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
				AllDetailsForm = value;
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


