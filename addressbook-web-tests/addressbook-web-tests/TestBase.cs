﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class TestBase
	{
		protected IWebDriver driver;
		private StringBuilder verificationErrors;
		protected string baseURL;
		private bool acceptNextAlert = true;

		[SetUp]
		public void SetupTest()
		{
			driver = new FirefoxDriver();
			baseURL = "https://Localhost:8080/addressbook/";
			verificationErrors = new StringBuilder();
		}

		[TearDown]
		protected void TeardownTest()
		{
			try
			{
				driver.Quit();
			}
			catch (Exception)
			{
				// Ignore errors if unable to close the browser
			}
			Assert.AreEqual("", verificationErrors.ToString());
		}
		protected void GoToHomePage()
		{
			driver.Navigate().GoToUrl("http://localhost:8080/addressbook/");
		}
		protected void Login(AccountData account)
		{
			driver.FindElement(By.Name("user")).Click();
			driver.FindElement(By.Name("user")).Clear();
			driver.FindElement(By.Name("user")).SendKeys(account.Username);
			driver.FindElement(By.Name("pass")).Click();
			driver.FindElement(By.Name("pass")).Clear();
			driver.FindElement(By.Name("pass")).SendKeys(account.Password);
			driver.FindElement(By.XPath("//input[@value='Login']")).Click();
		}
		protected void GoToGroupsPage()
		{
			driver.FindElement(By.LinkText("groups")).Click();
		}
		protected void InitGroupCreation()
		{
			driver.FindElement(By.Name("new")).Click();
		}
		protected void FillGroupForm(GroupData group)
		{
			driver.FindElement(By.Name("group_name")).Click();
			driver.FindElement(By.Name("group_name")).Clear();
			driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
			driver.FindElement(By.Name("group_header")).Click();
			driver.FindElement(By.Name("group_header")).Clear();
			driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
			driver.FindElement(By.Name("group_footer")).Click();
			driver.FindElement(By.Name("group_footer")).Clear();
			driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
		}
		protected void SubmitGroupCreation()
		{
			driver.FindElement(By.Name("submit")).Click();
		}
		protected void ReturnToGroupsPage()
		{
			driver.FindElement(By.LinkText("group page")).Click();
		}

		protected void SelectGroup(int index)
		{
			driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
		}
		protected void RemoveGroup()
		{
			driver.FindElement(By.Name("delete")).Click();
		}
		protected void ReturToContactPage()
		{
			driver.FindElement(By.LinkText("home page")).Click();
		}
		protected void SubmitContactCreation()
		{
			driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
		}
		protected void FillContactForm(ContactData contact)
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
		}
		protected void InitNewContactCreation()
		{
			driver.FindElement(By.Name("firstname")).Click();
		}
		protected void GoToAddNewPage()
		{
			driver.FindElement(By.LinkText("add new")).Click();
		}
	}
}
