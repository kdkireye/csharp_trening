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
	[TestFixture]

	public class LoginTests : TestBase
	{


		[Test]
		public void LoginWithCredentials()
		{
			//prepare (Подготовка)
			app.Auth.Logout();

			// action (действие)
			AccountData account = new AccountData("admin", "secret");
			app.Auth.Login(account);

			//verification (проверка)
			Assert.IsTrue(app.Auth.IsLoggedIn(account));
		}

		[Test]
		public void LoginWithInvalidCredentials()
		{

			//prepare (Подготовка)
			app.Auth.Logout();

		
			// action (действие)
			AccountData account = new AccountData("admin", "123456");
			app.Auth.Login(account);

			//verification (проверка)
			Assert.IsFalse(app.Auth.IsLoggedIn(account));
		}
	}
}
