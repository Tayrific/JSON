using Newtonsoft.Json;
using System.Xml;

namespace SerialiseAnObject
{
    public class Account
    {
        public string? Email { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<string> Roles { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "User",
                    "Developer",
                    "Admin"
                }
            };

            Account account2 = new Account
            {
                Email = "Tayyiba@example.com",
                Active = true,
                CreatedDate = new DateTime(2015, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
                {
                    "User",
                    "Developer"
                }
            };

            account2.Roles.Add("manager");

            // serialise an object
            string json = JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);

            string tayJson = JsonConvert.SerializeObject(account2, Newtonsoft.Json.Formatting.None);
            Console.WriteLine(json);
            Console.WriteLine("-----------------------");
            Console.WriteLine(tayJson);
            Console.WriteLine("-----------------------");
            // deserialise an object

            account = JsonConvert.DeserializeObject<Account>(json);
            account2 = JsonConvert.DeserializeObject<Account>(tayJson);

            Console.WriteLine(account.Email);
            Console.WriteLine(account2.Email);
            Console.WriteLine("-----------------------");
            //Print out roles for account
            // write the code here to print out all roles.

            foreach (var role in account.Roles)
            {
                Console.WriteLine(role);

            }
           
            
            Console.ReadLine();
        }
    }
}
