using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace WF.Test.AutomationFramework.Helpers
{
    public class JSONHelpers
    {

        public JSONHelpers()
        {
        }

        /// <summary>
        /// Verify if the JSON is in schemaJson format
        /// </summary>
        public static void JSONSchemaValidation(string schemaJson, string json, string jsonNameForReporting)
        {
            JsonSchema schema = JsonSchema.Parse(schemaJson);

            JObject jsonObject = JObject.Parse(json);

            if (jsonObject.IsValid(schema)) {
                Reporter.LogPass(jsonNameForReporting + " matches the schema");
            } else
            {
                Reporter.LogFail(jsonNameForReporting + " does not match the schema <br/> " +
                    "Schema : " + schemaJson + "<br/>" +
                    "JSON : " + json );
            }
        }

        
    }
}
