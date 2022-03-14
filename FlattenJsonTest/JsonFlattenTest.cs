using CodingChallenge;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using Xunit;

namespace FlattenJsonTest
{
    public class JsonFlattenTest
    {

        [Fact]
        public void Test()
        {
            var stringjsonData = "{\"a\":1,\"b\":true,\"c\":{\"d\":3,\"e\":\"test\"}}";

            JObject jObject = JObject.Parse(stringjsonData);


            var propertyAccumulator = new JsonPropertiesAccumulator(jObject);
            var properties = propertyAccumulator.GetAllProperties();

            var flattenedJsonString = JsonConvert.SerializeObject(properties, Formatting.Indented);

            var outputjson = "{\"a\":1,\"b\":true,\"c.d\":3,\"c.e\":\"test\"}";
            JObject jObject2 = JObject.Parse(outputjson);
            var output = JsonConvert.SerializeObject(jObject2, Formatting.Indented);

            Assert.Equal(flattenedJsonString, output);


        }


        //new Dictionary<string, JValue>()
        //    {
        //        { "a", (JValue)1 },
        //        { "b", (JValue)true },
        //        { "c.d", (JValue)3 },
        //        { "e.d", (JValue)"test" }
        //    });
    }
}
