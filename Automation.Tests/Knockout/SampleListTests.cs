using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bumblebee.Setup;
using Automation.Model.Knockout;
using Bumblebee.Setup.DriverEnvironments;
using System.Linq;
using System;

namespace Automation.Tests.Knockout
{
	[TestClass]
	public class SampleListTests
	{
		private SampleList _unitUnderTest;

		[TestInitialize]
		public void Initalize()
		{
			_unitUnderTest = Threaded<Session>
			  .With(new Tools.Chrome(TimeSpan.FromSeconds(10)))
			  .NavigateTo<SampleList>("http://knockoutjs.com/examples/simpleList.html");
		}


		[TestMethod]
		public void Add_NonEmptyValue_Added()
		{
			var value = "SomeNewValue";
			var itemsCount = _unitUnderTest.Items.Options.Count();

			_unitUnderTest.TextField.EnterText(value);
			_unitUnderTest.AddButton.Click();

			Assert.AreEqual(itemsCount + 1, _unitUnderTest.Items.Options.Count());
			Assert.AreEqual(value, _unitUnderTest.Items.Options.Last().Text);
		}

		[TestCleanup]
		public void Cleanup()
		{
			Threaded<Session>.End();
		}
	}
}
