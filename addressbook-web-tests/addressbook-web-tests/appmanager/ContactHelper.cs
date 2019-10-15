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


namespace WebAddressbookTests
{
	public class ContactHelper : HelperBase
	{
		public bool acceptNextAlert { get; private set; }

		public ContactHelper(ApplicationManager manager) : base(manager)
		{
		}
		public ContactHelper SubmitContactCreation()
		{
			driver.FindElement(By.XPath("//input[21]")).Click();
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

			SelectContact(1);
			InitContactModification();
			FillContactForm(newData);
			SubmitContactModification();
			ReturnToContactPage();
			return this;
		}

		public ContactHelper Remove()
		{
			manager.Navigator.GoToHomePage();

			SelectContact(1);
			acceptNextAlert = true;
			RemoveContact();
			Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
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
			driver.FindElement(By.XPath("(//option[@value='March'])[2]")).Click();
			Type(By.Name("ayear"), "2023");
			Type(By.Name("homepage"), contact.Homepage);
			Type(By.Name("address2"), contact.Address2);
			Type(By.Name("phone2"), contact.Phone2);
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
			driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
			return this;
		}



		public ContactHelper SubmitContactModification()
		{
			driver.FindElement(By.Name("update")).Click();
			return this;
		}

		public ContactHelper InitContactModification()
		{
			driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
			return this;
		}

		public ContactHelper RemoveContact()
		{
			driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
			return this;
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
	}
}
