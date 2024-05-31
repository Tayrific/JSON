using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SerialiseWithJsonConverters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<StringComparison> stringComparisons = new List<StringComparison>
            {
                StringComparison.CurrentCulture,
                StringComparison.Ordinal
            };

            //output
            foreach (StringComparison stringComparison in stringComparisons)
            {
                Console.Write(stringComparison + " ");
            }
            Console.WriteLine("\n------------------------");

            //Serialise without converter
            string jsonWithoutConverter = JsonConvert.SerializeObject(stringComparisons);
            Console.WriteLine(jsonWithoutConverter);
            Console.WriteLine("------------------------");

            //Serialise with converter
            string jsonWithConverter = JsonConvert.SerializeObject(stringComparisons, new StringEnumConverter());
            Console.WriteLine(jsonWithConverter);
            Console.WriteLine("------------------------");

            //Deserialise
            List<StringComparison> newStringComparsions = JsonConvert.DeserializeObject<List<StringComparison>>(jsonWithConverter, new StringEnumConverter());
            Console.WriteLine(string.Join(", ", newStringComparsions.Select(c => c.ToString()).ToArray()));
        }
    }
}
