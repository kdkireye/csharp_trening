using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
	class Class1
	{


		driver = new FirefoxDriver();
		baseURL = "https://Localhost:8080/addressbook/";
			verificationErrors = new StringBuilder();

		loginHelper = new LoginHelper(driver);
		navigationHelper = new NavigationHelper(driver);
		groupHelper = new GroupHelper(driver);
		contactHelper = new ContactHelper(driver);
	}
}
