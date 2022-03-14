using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;
using System.IO;


namespace CodingChallenge
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string input = String.Empty;

            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192))); 
            while (Console.In.Peek() != -1)
            {
                input = Console.In.ReadLine();
            }

            JObject jObject = JObject.Parse(File.ReadAllText(input));


            var propertyAccumulator = new JsonPropertiesAccumulator(jObject);
            var properties = propertyAccumulator.GetAllProperties();

            var flattenedJsonString = JsonConvert.SerializeObject(properties, Formatting.Indented);
            Console.WriteLine(flattenedJsonString);

        }

    }
}
