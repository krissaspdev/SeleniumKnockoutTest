using Bumblebee.Setup;
using OpenQA.Selenium;
using Bumblebee.Interfaces;
using Bumblebee.Implementation;

namespace Automation.Model.Knockout
{
	public class SampleList : BaseBlock
	{
		public SampleList(Session session) : base(session)
		{
			Tag = FindElement(By.ClassName("liveExample"));
		}

		public ITextField<SampleList> TextField => new TextField<SampleList>(this, By.TagName("input"));

		public IClickable<SampleList> AddButton
		{
			get
			{
				try
				{
					return new Clickable<SampleList>(this, By.XPath(".//form/button"));
				}
				catch (System.Exception)
				{
					return null;
				}
			}
		}

		public ISelectBox Items => new SelectBox(this, By.TagName("select"));
	}
}
