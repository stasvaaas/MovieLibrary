namespace MovieLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieLibrary movieLibrary = new MovieLibrary();
            foreach (var movie in movieLibrary)
            {
                Console.WriteLine(movie);
            }
            Console.WriteLine(movieLibrary[1]);
            string name = movieLibrary.GetMovie(0);
            Console.WriteLine(name);
        }
    }
}