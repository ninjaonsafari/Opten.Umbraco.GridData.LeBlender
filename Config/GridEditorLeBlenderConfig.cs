using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Extensions.Json;
using Skybrud.Umbraco.GridData.Interfaces;
using Skybrud.Umbraco.GridData.Json;

namespace Opten.Umbraco.GridData.Config
{
    public class GridEditorLeBlenderConfig : GridJsonObject, IGridEditorConfig
	{
		#region Properties


        [JsonProperty("renderInGrid", NullValueHandling = NullValueHandling.Ignore)]
        public string RenderInGrid { get; private set; }


		[JsonProperty("frontView", NullValueHandling = NullValueHandling.Ignore)]
        public string FrontView { get; private set; }

        public GridEditor Editor { get; private set; }

        public string Guid { get; private set; }


		#endregion

		#region Constructors

        private GridEditorLeBlenderConfig(GridEditor editor, JObject obj)
            : base(obj)
        {
            Editor = editor;
            JToken guidJToken;
            if ((guidJToken = editor.Control.JObject.GetValue("guid")) != null)
            {
                Guid = guidJToken.Value<string>();
            }
            
        }

		#endregion

		#region Static methods


        public static GridEditorLeBlenderConfig Parse(GridEditor editor, JObject obj)
		{
            if (obj == null) return null;
            return new GridEditorLeBlenderConfig(editor, obj)
            {
                FrontView = obj.GetString("frontView"),
                RenderInGrid = obj.GetString("renderInGrid")
            };
		}
		
		#endregion
	}
}
