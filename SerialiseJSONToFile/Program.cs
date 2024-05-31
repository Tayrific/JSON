using Newtonsoft.Json;

namespace SerialiseJSONToFile
{
    internal class Program
    {
        public class Movie
        {
            public string Name { get; set; }
            public int Year { get; set; }
        }
        static void Main(string[] args)
        {
            Movie movie = new Movie
            {
                Name = "Bad Boys",
                Year = 1995
            };
            Movie movie2 = new Movie
            {
                Name = "Super Mario Bros",
                Year = 1993
            };


            File.WriteAllText(@"movie.json", JsonConvert.SerializeObject(movie) + JsonConvert.SerializeObject(movie2));
            
        }
    }
}
