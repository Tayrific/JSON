using System.Dynamic;
using Newtonsoft.Json;

namespace DynamicExpando
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Dynamic and ExpandoObjects");
            Console.WriteLine("--------------------------");
            dynamic author = new ExpandoObject();
            author.Name = "Xavier Morera";
            author.Courses = new List<string>() { "Solr", "Spark", "Python" };
            author.Happy = true;

            Console.WriteLine("--Serialise--");

            string json = JsonConvert.SerializeObject(author, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("--------------------------");
            Console.WriteLine("--Deserialise--");
            author = JsonConvert.DeserializeObject(json);
            Console.WriteLine(author);

            Console.WriteLine("--------------------------");
            Console.WriteLine("---Output authors name---");
            Console.WriteLine("Name: " + author.Name);

        }
    }
}
