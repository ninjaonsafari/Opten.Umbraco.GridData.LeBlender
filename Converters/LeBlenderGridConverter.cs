using Lecoati.LeBlender.Extension.Models;
using Newtonsoft.Json;
using Opten.Umbraco.GridData.Values;
using Skybrud.Umbraco.GridData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opten.Umbraco.GridData.Converters
{
	public class LeBlenderGridConverter : IGridConverter
	{
		public bool ConvertControlValue(Skybrud.Umbraco.GridData.GridControl control, Newtonsoft.Json.Linq.JToken token, out IGridControlValue value)
		{
			value = null;

			value = GridControlLeBlenderValue.Parse(control, token);

			return value != null;
		}

		public bool ConvertEditorConfig(Skybrud.Umbraco.GridData.GridEditor editor, Newtonsoft.Json.Linq.JToken token, out IGridEditorConfig config)
		{
			throw new NotImplementedException();
		}

		public bool GetControlWrapper(Skybrud.Umbraco.GridData.GridControl control, out Skybrud.Umbraco.GridData.Rendering.GridControlWrapper wrapper)
		{
			throw new NotImplementedException();
		}
	}
}
