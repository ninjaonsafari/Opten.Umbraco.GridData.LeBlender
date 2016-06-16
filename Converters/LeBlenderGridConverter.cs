using Lecoati.LeBlender.Extension.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Opten.Umbraco.GridData.Values;
using Skybrud.Umbraco.GridData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skybrud.Umbraco.GridData.Extensions.Json;
using Skybrud.Umbraco.GridData;
using Skybrud.Umbraco.GridData.Rendering;
using Opten.Umbraco.GridData.Config;

namespace Opten.Umbraco.GridData.Converters
{
	public class LeBlenderGridConverter : IGridConverter
	{
		public bool ConvertControlValue(GridControl control, Newtonsoft.Json.Linq.JToken token, out IGridControlValue value)
		{
			value = null;
            
            if (control.Editor.View == "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html")
            {
                value = GridControlLeBlenderValue.Parse(control, token);
            }
            
			return value != null;
		}

		public bool ConvertEditorConfig(GridEditor editor, Newtonsoft.Json.Linq.JToken token, out IGridEditorConfig config)
		{
            config = null;

            if (editor.View == "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html")
            {
                config = GridEditorLeBlenderConfig.Parse(editor, token as JObject);
            }

            return config != null;
		}

		public bool GetControlWrapper(GridControl control, out GridControlWrapper wrapper)
		{
            wrapper = null;
            
            if (control.Editor.View == "/App_Plugins/LeBlender/editors/leblendereditor/LeBlendereditor.html")
            {
                if (control.Editor.Render == "/App_Plugins/LeBlender/editors/leblendereditor/views/Base.cshtml")
                {
                    //need to do this as we cant modify private properties of leblender editor
                    JObject obj = JObject.FromObject(control);
                    //overriding render view as default view won't know how to handle typed grid control
                    obj["editor"]["render"] = "leblender";
                    // need to do this because skybrud grid data has a Skybrud.Umbraco.GridData.Howdy class which always returns the original render view unless we change the alias to something it can't find
                    obj["editor"]["alias"] = "wrapperconverted_" + obj["editor"]["alias"];

                    JObject objCopy = JObject.FromObject(obj);
                    control = GridControl.Parse(control.Area, objCopy);
                }
                wrapper = control.GetControlWrapper<GridControlLeBlenderValue>();
            }

            return wrapper != null;
		}
	}
}
