﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
	public class HelperBase
	{
		protected IWebDriver driver;
		protected ApplicationManager manager;

		public HelperBase (ApplicationManager manager)
		{
			this.manager = manager;
			driver = manager.Driver;
		}

		public void Type(By locator, string text)
		{
			if (text != null)
			{
				driver.FindElement(locator).Clear();
				driver.FindElement(locator).SendKeys(text);
			}
		}

		public bool IsElementPresent(By by)
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

			public bool HasElementsWithProperty(By by)
        {
            try
            {
                var elements = driver.FindElements(by);

                return elements.Count > 0;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

		}
	}
}