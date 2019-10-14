﻿using System;
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

		public ContactHelper Modify(int v, ContactData newData)
		{
			manager.Navigator.GoToContactPage();

			SelectContact(1);
			InitContactModification();
			FillContactForm(newData);
			SubmitContactModification();
			ReturnToContactPage();
			return this;
		}

		public ContactHelper Remove(int v)
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
			driver.FindElement(By.Name("firstname")).Clear();
			driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
			driver.FindElement(By.Name("middlename")).Click();
			driver.FindElement(By.Name("middlename")).Clear();
			driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
			driver.FindElement(By.Name("lastname")).Click();
			driver.FindElement(By.Name("lastname")).Clear();
			driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
			driver.FindElement(By.Name("nickname")).Click();
			driver.FindElement(By.Name("nickname")).Clear();
			driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
			driver.FindElement(By.Name("title")).Click();
			driver.FindElement(By.Name("title")).Click();
			driver.FindElement(By.Name("title")).Clear();
			driver.FindElement(By.Name("title")).SendKeys(contact.Title);
			driver.FindElement(By.Name("company")).Click();
			driver.FindElement(By.Name("company")).Clear();
			driver.FindElement(By.Name("company")).SendKeys(contact.Company);
			driver.FindElement(By.Name("address")).Click();
			driver.FindElement(By.Name("address")).Clear();
			driver.FindElement(By.Name("address")).SendKeys(contact.Address);
			driver.FindElement(By.Name("home")).Click();
			driver.FindElement(By.Name("home")).Clear();
			driver.FindElement(By.Name("home")).SendKeys(contact.Home);
			driver.FindElement(By.Name("mobile")).Click();
			driver.FindElement(By.Name("mobile")).Clear();
			driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
			driver.FindElement(By.Name("work")).Click();
			driver.FindElement(By.Name("work")).Clear();
			driver.FindElement(By.Name("work")).SendKeys(contact.Work);
			driver.FindElement(By.Name("fax")).Click();
			driver.FindElement(By.Name("fax")).Clear();
			driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
			driver.FindElement(By.Name("email")).Click();
			driver.FindElement(By.Name("email")).Clear();
			driver.FindElement(By.Name("email")).SendKeys(contact.Email);
			driver.FindElement(By.Name("email2")).Clear();
			driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
			driver.FindElement(By.Name("email3")).Click();
			driver.FindElement(By.Name("email3")).Clear();
			driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
			driver.FindElement(By.Name("bday")).Click();
			new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("2");
			driver.FindElement(By.XPath("//option[@value='2']")).Click();
			driver.FindElement(By.Name("bmonth")).Click();
			new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("March");
			driver.FindElement(By.XPath("//option[@value='March']")).Click();
			driver.FindElement(By.Name("byear")).Click();
			driver.FindElement(By.Name("byear")).Clear();
			driver.FindElement(By.Name("byear")).SendKeys("1993");
			driver.FindElement(By.Name("aday")).Click();
			new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("2");
			driver.FindElement(By.XPath("(//option[@value='2'])[2]")).Click();
			driver.FindElement(By.Name("amonth")).Click();
			new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("March");
			driver.FindElement(By.XPath("(//option[@value='March'])[2]")).Click();
			driver.FindElement(By.Name("ayear")).Click();
			driver.FindElement(By.Name("ayear")).Clear();
			driver.FindElement(By.Name("ayear")).SendKeys("2023");
			driver.FindElement(By.Name("homepage")).Click();
			driver.FindElement(By.Name("homepage")).Clear();
			driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
			driver.FindElement(By.Name("address2")).Click();
			driver.FindElement(By.Name("address2")).Clear();
			driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
			driver.FindElement(By.Name("phone2")).Click();
			driver.FindElement(By.Name("phone2")).Clear();
			driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
			driver.FindElement(By.Name("notes")).Click();
			driver.FindElement(By.Name("notes")).Clear();
			driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
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
