using Bumblebee.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation.Tests.Tools
{
	internal class Chrome : IDriverEnvironment 
	{
		private TimeSpan _timeToWait;

		public Chrome(TimeSpan timeToWait)
		{
			_timeToWait = timeToWait;
		}

		public virtual IWebDriver CreateWebDriver()
		{
			var options = new ChromeOptions();
			options.AddArgument("--incognito");
			options.AddArgument("--no-sandbox");
			options.AddArgument("start-maximized");
			options.AddArgument("--verbose");
			options.SetLoggingPreference(LogType.Driver, LogLevel.All);

			ChromeDriver driver = new ChromeDriver(options);
			driver.Manage().Timeouts().ImplicitWait = _timeToWait;
			return driver;
		}
	}
}
