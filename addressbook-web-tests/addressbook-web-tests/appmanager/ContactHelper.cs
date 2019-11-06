using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;



namespace WebAddressbookTests
{
	public class ContactHelper : HelperBase
	{
		public bool acceptNextAlert { get; private set; }

		public ContactHelper(ApplicationManager manager) : base(manager)
		{
		}

		public ContactHelper Create(ContactData contact)
		{
			manager.Navigator.GoToContactPage();

			GoToAddNewPage();
			InitNewContactCreation();
			FillContactForm(contact);
			SubmitContactCreation();
			ReturnToContactPage();
			return this;
		}

		public ContactHelper GoToAddNewPage()
		{
			driver.FindElement(By.LinkText("add new")).Click();
			return this;
		}

		public ContactHelper SubmitContactCreation()
		{
			driver.FindElement(By.XPath("//input[21]")).Click();
			contactCache = null;
			return this;
		}


		public ContactHelper ReturnToContactPage()
		{
			driver.FindElement(By.LinkText("home")).Click();
			return this;
		}

		public ContactHelper Modify(ContactData newData)
		{
			manager.Navigator.GoToContactPage();


			SelectContact(0);
			InitContactModification(0);
			FillContactForm(newData);
			SubmitContactModification();
			ReturnToContactPage();
			return this;
		}


		public void IsModifyContact()
		{
			if (IsElementPresent(By.ClassName("center")))
			{
				return;
			}

			ContactData newData = new ContactData("cvbgfh", "ljhkjb");
			Create(new ContactData("Kristina", "gdsxgf"));
		}

		public ContactHelper Remove(int n)
		{
			manager.Navigator.GoToHomePage();


			SelectContact(0);
			acceptNextAlert = true;
			RemoveContact();
			Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
			driver.FindElement(By.CssSelector("div.msgbox"));
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
			ReturnToContactPage();
			return this;
		}

		private void chooseOkOnNextConfirmation()
		{
			throw new NotImplementedException();
		}

		public ContactHelper FillContactForm(ContactData contact)
		{
			Type(By.Name("firstname"), contact.Firstname);
			Type(By.Name("middlename"), contact.Middlename);
			Type(By.Name("lastname"), contact.Lastname);
			Type(By.Name("nickname"), contact.Nickname);
			Type(By.Name("title"), contact.Title);
			Type(By.Name("company"), contact.Company);
			Type(By.Name("address"), contact.Address);
			Type(By.Name("home"), contact.Home);
			Type(By.Name("mobile"), contact.Mobile);
			Type(By.Name("work"), contact.Work);
			Type(By.Name("fax"), contact.Fax);
			Type(By.Name("email"), contact.Email);
			Type(By.Name("email2"), contact.Email2);
			Type(By.Name("email3"), contact.Email3);
			new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("2");
			driver.FindElement(By.XPath("//option[@value='2']")).Click();
			new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("March");
			driver.FindElement(By.XPath("//option[@value='March']")).Click();
			Type(By.Name("byear"), "1993");
			new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("2");
			driver.FindElement(By.XPath("(//option[@value='2'])[2]")).Click();
			new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("March");
			driver.FindElement(By.XPath("(//option[@value='March'])")).Click();
			Type(By.Name("ayear"), "2023");
			Type(By.Name("homepage"), contact.Homepage);
			Type(By.Name("address2"), contact.Address2);
			//Type(By.Name("phone2"), contact.Phone2);
			Type(By.Name("notes"), contact.Notes);
			return this;

		}
		public ContactHelper InitNewContactCreation()
		{
			driver.FindElement(By.Name("firstname")).Click();
			return this;

		}

		public ContactHelper SelectContact(int index)
		{
			driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
			return this;
		}


		public ContactHelper SubmitContactModification()
		{
			driver.FindElement(By.Name("update")).Click();
			contactCache = null;
			return this;
		}

		public ContactHelper InitContactModification(int index)
		{
			driver.FindElements(By.Name("entry"))[index]
				.FindElements(By.TagName("td"))[7]
				.FindElement(By.TagName("a")).Click();
			return this;
		}

		public ContactHelper RemoveContact()
		{
			driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
			contactCache = null;
			return this;
		}

		private List<ContactData> contactCache = null;


		public List<ContactData> GetContactList()
		{
			if (contactCache == null)
			{
				contactCache = new List<ContactData>();
				manager.Navigator.GoToContactPage();

				ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[Name=entry]"));

				foreach (IWebElement element in elements)
				{
					IList<IWebElement> cells = element.FindElements(By.TagName("td"));
					//ContactData contact = new ContactData(cells[1].Text,cells[2].Text);
					contactCache.Add(new ContactData(cells[1].Text, cells[2].Text));
				}
			}

			return new List<ContactData>(contactCache);
		}

		private bool IsElementPresent(By by)
		{
			try
			{
				driver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}

		private bool IsAlertPresent()
		{
			try
			{
				driver.SwitchTo().Alert();
				return true;
			}
			catch (NoAlertPresentException)
			{
				return false;
			}
		}

		private string CloseAlertAndGetItsText()
		{
			try
			{
				IAlert alert = driver.SwitchTo().Alert();
				string alertText = alert.Text;
				if (acceptNextAlert)
				{
					alert.Accept();
				}
				else
				{
					alert.Dismiss();
				}
				return alertText;
			}
			finally
			{
				acceptNextAlert = true;
			}
		}

		public ContactData GetContactInformationFromTable(int index)
		{
			manager.Navigator.GoToHomePage();

			IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
				.FindElements(By.TagName("td"));
			string lastName = cells[1].Text;
			string firstName = cells[2].Text;
			string address = cells[3].Text;
			string allEmails = cells[4].Text;
			string allPhones = cells[5].Text;

			return new ContactData(firstName, lastName)
			{
				Address = address,
				AllEmails = allEmails,
				AllPhones = allPhones,
			};

		}

		public string GetContactInformationFromEditForm1(int index)
		{
			manager.Navigator.GoToHomePage();
			InitContactModification(0);
			string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
			string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
			string address = driver.FindElement(By.Name("address")).GetAttribute("value");

			string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
			string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

			string email = driver.FindElement(By.Name("email")).GetAttribute("value");
			string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
			string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

			var tmp = new ContactData(firstName, lastName)
			{
				Address = address,
				Home = homePhone,
				Mobile = mobilePhone,
				Work = workPhone,
				Email = email,
				Email2 = email2,
				Email3 = email3
			};

			return (string)tmp.AllDetailsForm.Replace("\r\n", "");
		}

		public int GetNumberOfSearchResults()
		{
			manager.Navigator.GoToHomePage();
			string text = driver.FindElement(By.TagName("label")).Text;
			Match m = new Regex(@"\d+").Match(text);
			return Int32.Parse(m.Value);
		}

		public string GetContactInformationFromDetailPage()
		{
			manager.Navigator.GoToHomePage();

			ViewContactDetailsPage(0);

			string text = driver.FindElement(By.Id("content")).Text;

			return text.Replace("\r\n", "").Replace(" ","").Replace("H:","").Replace("M:","").Replace("W:",""); 

			//return new ContactData(details, detailsForm)
			//{
			//AllDetails = allDetails,
			//AllDetailsForm = allDetailsForm
			//};

		}
			
			public void ViewContactDetailsPage(int index)
		{
			driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();
		}

		public ContactData GetContactInformationFromEditForm(int index)
		{
			manager.Navigator.GoToHomePage();
			InitContactModification(0);
			string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
			string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
			string address = driver.FindElement(By.Name("address")).GetAttribute("value");

			string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
			string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
			string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

			string email = driver.FindElement(By.Name("email")).GetAttribute("value");
			string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
			string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

			return new ContactData(firstName, lastName)
			{
				Address = address,
				Home = homePhone,
				Mobile = mobilePhone,
				Work = workPhone,
				Email = email,
				Email2 = email2,
				Email3 = email3
			};

			
		}

	}
}
	

