using Newtonsoft.Json;
namespace SerialiseDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> points = new Dictionary<string, int>
            {
                { "James", 9001 },
                { "Jo", 3474 },
                { "Jess", 11926 }
            };

            string json = JsonConvert.SerializeObject(points, Formatting.Indented);
            Console.WriteLine("Serialised: ");
            Console.WriteLine(json);

            Console.WriteLine("---------------------");

            points = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            Console.WriteLine("Deserialised: ");
            foreach (var person in points)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("---------------------");

            points.Add("tay", 9866);
            points.Add("george", 3468);

            Console.WriteLine("Serialised with added values: ");
            json = JsonConvert.SerializeObject(points, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
