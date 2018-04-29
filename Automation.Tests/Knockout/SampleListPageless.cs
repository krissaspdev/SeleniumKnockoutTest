using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace Automation.Tests.Knockout
{
	[TestClass]
	public class SampleListPageless
	{
		private IWebDriver _webDriver;

		[TestInitialize]
		public void Initalize()
		{
			_webDriver = new ChromeDriver();
			_webDriver.Url = "http://knockoutjs.com/examples/simpleList.html";
		}

		[TestMethod]
		public void Add_NewItem_OnList()
		{
			// Arrange
			var listContainer = _webDriver.FindElement(By.ClassName("liveExample"));
			var itemsList = listContainer.FindElement(By.TagName("select"));
			var items = itemsList.FindElements(By.TagName("option"));
			var addButton = listContainer.FindElement(By.TagName("button"));
			var textBox = listContainer.FindElement(By.TagName("input"));

			var itemsCount = items.Count();
			var value = "SomeNewValue";

			//Act
			textBox.SendKeys(value);
			addButton.Click();

			// Assert
			var currentItems = itemsList.FindElements(By.TagName("option"));	

			Assert.AreEqual(itemsCount + 1, currentItems.Count());
			Assert.AreEqual(value, currentItems.Last().Text);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_webDriver.Close();
		}
	}
}
