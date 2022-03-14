using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge
{
    public class JsonPropertiesAccumulator
    {
        private readonly Dictionary<string, JValue> properties;

        public JsonPropertiesAccumulator(JToken token)
        {
            properties = new Dictionary<string, JValue>();
            TakeProperties(token);
        }

        private void TakeProperties(JToken jToken)
        {
            if (jToken.Type == JTokenType.Object)
            {
                foreach (var child in jToken.Children<JProperty>())
                    TakeProperties(child);
            }
            else if (jToken.Type == JTokenType.Property)
            {
                
                TakeProperties(((JProperty)jToken).Value);
            }
            else
            {
                properties.Add(jToken.Path, (JValue)jToken);
            }
            
        }

        public IEnumerable<KeyValuePair<string, JValue>> GetAllProperties()
        {
            return properties;
        }
            
    }
}
