using Bumblebee.Setup;
using OpenQA.Selenium;
using Bumblebee.Interfaces;
using Bumblebee.Implementation;

namespace Automation.Model.Knockout
{
	public class BetterList : BaseBlock
	{
		public BetterList(Session session) : base(session)
		{
			Tag = FindElement(By.ClassName("liveExample"));
		}

		public ITextField<BetterList> TextField => new TextField<BetterList>(this, By.TagName("input"));

		public IClickable<BetterList> AddButton
		{
			get
			{
				try
				{
					return new Clickable<BetterList>(this, By.XPath(".//form/button"));
				}
				catch (System.Exception)
				{
					return null;
				}
			}
		}

		public IClickable<BetterList> RemoveButton => new Clickable<BetterList>(this, By.XPath(".//div/button[1]"));
		public IClickable<BetterList> SortButton => new Clickable<BetterList>(this, By.XPath(".//div/button[2]"));

		public ISelectBox Items => new SelectBox(this, By.TagName("select"));
	}
}
