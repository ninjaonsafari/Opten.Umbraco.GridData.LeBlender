using Lecoati.LeBlender.Extension.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opten.Umbraco.GridData.Values
{
	[JsonConverter(typeof(LeBlenderModelMatchingConverter))]
	public class GridControlLeBlenderValue : IGridControlValue
	{
		#region Properties

		/// <summary>
		/// Gets a reference to the parent control.
		/// </summary>
		public GridControl Control { get; private set; }

		/// <summary>
		/// Gets a reference to the underlying instance of <code>JToken</code>.
		/// </summary>
		[JsonIgnore]
		public JToken JToken { get; private set; }

		/// <summary>
		/// Gets a string representing the value.
		/// </summary>
		[JsonProperty("value")]
		public LeBlenderValue Value;

		#endregion

		#region Constructors

		protected GridControlLeBlenderValue(GridControl control, JToken token)
		{
			Control = control;
			JToken = token;
			Value = token.Value<LeBlenderValue>();
			
		}

		#endregion

		#region Static methods

		/// <summary>
		/// Gets a text value from the specified <code>JToken</code>.
		/// </summary>
		/// <param name="control">The parent control.</param>
		/// <param name="token">The instance of <code>JToken</code> to be parsed.</param>
		public static GridControlLeBlenderValue Parse(GridControl control, JToken token)
		{
			if (token == null) return null;
			return new GridControlLeBlenderValue(control, token);
		}
		
		#endregion
	}
}
