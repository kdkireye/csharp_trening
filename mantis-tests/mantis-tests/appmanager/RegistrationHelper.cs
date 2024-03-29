﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
	public class RegistrationHelper:HelperBase
	{
		public RegistrationHelper(ApplicationManager manager) : base(manager)
		{

		}

		public void Register(AccountData account)
		{
			OpenMainPage();
			OpenRegistrationForm();
			FillRegistrationForm(account);
			SubmitRegistration();
		}

		private void OpenRegistrationForm()
		{
			driver.FindElement(By.CssSelector("a.back-to-login-link.pull-left")).Click();
		}

		private void SubmitRegistration()
		{
			driver.FindElement(By.CssSelector("input.button")).Click();
			
		}

		private void FillRegistrationForm(AccountData account)
		{
			driver.FindElement(By.Name("username")).SendKeys(account.Name);
			driver.FindElement(By.Name("email")).SendKeys(account.Email);

		}

		private void OpenMainPage()
		{
			manager.Driver.Url = "http://localhost:8080/mantisbt-2.22.1/login_page.php";

		}
	}
}
