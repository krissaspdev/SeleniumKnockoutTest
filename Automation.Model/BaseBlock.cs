using Bumblebee.Implementation;
using Bumblebee.Setup;
using OpenQA.Selenium;

namespace Automation.Model
{
	public class BaseBlock : Block
	{
		public BaseBlock(Session session) : base(session)
		{
			Tag = Session.Driver.FindElement(By.TagName("body"));
		}
	}
}
