using MovieDB.Controllers;
using MovieDB.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Menu
{
    internal class AddMovieMenu
    {
        public static void AddMovie()
        {
            Console.Clear();
            Banner.MovieDBBanner();
            try
            {
                Console.WriteLine("Enter movie title:");
                var movieTitle = Console.ReadLine();
                Console.WriteLine("Year of release:");
                var movieYear = Convert.ToInt32(Console.ReadLine());
                MovieController.GetGenresWithId();
                Console.WriteLine("Select genre with ID:");
                var genreId = Convert.ToInt32(Console.ReadLine());

                MovieController.AddMovie(movieTitle, movieYear, genreId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong format");
            }
        }
    }
}
