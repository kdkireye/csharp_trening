﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class NavigationHelper : HelperBase
	{
		private string baseURL;

		public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
		{
			this.baseURL = baseURL;
		}

		public void GoToHomePage()
		{
			if (driver.Url == baseURL + "addressbook/")
			{
				return;
			}
			driver.Navigate().GoToUrl(baseURL + "/addressbook");
		}

		public void GoToGroupsPage()
		{
			if (driver.Url == baseURL + "addressbook/group.php"
				&& IsElementPresent(By.Name("new")))
			{
				return;
			}
			driver.FindElement(By.LinkText("groups")).Click();
		}

		public void GoToContactPage()
		{
			if (driver.Url == baseURL + "/addressbook"
				&& IsElementPresent(By.LinkText("Last name")))
			{
				return;
			}

			driver.Navigate().GoToUrl(baseURL + "/addressbook");
		}

		public void GoToAddNewPage()
		{
			if (driver.Url == baseURL + "/addressbook/edit.php"
				&& IsElementPresent(By.Name("submit")))
			{
				return;
			}

			driver.FindElement(By.LinkText("add new")).Click();
		}

		public void ReturnToContactPage()
		{
			if (driver.Url == baseURL + "/addressbook")
			{
				return;
			}
			driver.FindElement(By.LinkText("home")).Click();
		}

	}
}


