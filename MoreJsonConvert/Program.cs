using Newtonsoft.Json;
using static MoreJsonConvert.Program;

namespace MoreJsonConvert
{
    internal class Program
    {
        public class Product
        {
            public string Name { get; set; }
            public DateTime ExpiryDate { get; set; }
            public decimal Price { get; set; }
            public string[] Sizes { get; set; }

            

        }
        static void Main(string[] args)
        {
            Product apple = new Product();

            //created product using example on https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
            apple.Name = "Apple";
            apple.ExpiryDate = new DateTime(2024, 06, 02);
            apple.Price = 3.99M;
            apple.Sizes = new string[] { "Small", "Medium", "Large" };

            //created a second product
            Product banana = new Product
            {
                Name = "Banana",
                ExpiryDate = new DateTime(2024, 06, 07),
                Price = 2.99M,
                Sizes = new string[] { "Small", "Medium" }
            };

            List<Product> products = new List<Product> { apple, banana };
            List<string> outputs = new List<string>();

            //Serialise and add to a list
            foreach (var item in products)
            {
                string output = JsonConvert.SerializeObject(item, Formatting.Indented);
                outputs.Add(output);
            }

            //Output list and deserialise
            Console.WriteLine("Your products: ");
            foreach (var jsonOutput in outputs)
            {
                Console.WriteLine(jsonOutput);
                Product deserializedProduct = JsonConvert.DeserializeObject<Product>(jsonOutput);
                Console.WriteLine("Deserialised name : {0}", deserializedProduct.Name);
            }
        }
    }
}
