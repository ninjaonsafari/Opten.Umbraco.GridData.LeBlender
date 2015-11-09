using Opten.Umbraco.GridData.Converters;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;

namespace Opten.Baswa.Web.Events
{
	public class RegisterGridConverter : ApplicationEventHandler
	{
		protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
		{
			GridContext.Current.Converters.Add(new LeBlenderGridConverter());
		}
	}
}
