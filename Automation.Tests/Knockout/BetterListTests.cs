using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bumblebee.Setup;
using Automation.Model.Knockout;

namespace Automation.Tests.Knockout
{
	[TestClass]
	public class BetterListTests
	{
		private BetterList _unitUnderTest;

		[TestInitialize]
		public void Initalize()
		{
			_unitUnderTest = Threaded<Session>
			  .With(new Tools.Chrome(TimeSpan.FromSeconds(10)))
			  .NavigateTo<BetterList>("http://knockoutjs.com/examples/betterList.html");
		}


		[TestMethod]
		public void Open_Address_ButtonsPresent()
		{
			Assert.IsNotNull(_unitUnderTest.AddButton);
			Assert.IsNotNull(_unitUnderTest.RemoveButton);
			Assert.IsNotNull(_unitUnderTest.SortButton);
		}

		[TestCleanup]
		public void Cleanup()
		{
			Threaded<Session>.End();
		}
	}
}
