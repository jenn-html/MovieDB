using MovieDB.Services;
using MovieDB.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Controllers
{
    public class MovieController
    {
        public static void ShowAllMovies()
        {
            Banner.MovieDBBanner();
            MovieService.ShowAllMovies();
        }
        public static void ShowAllMoviesWithId()
        {

            MovieService.ShowAllMoviesWithId();
        }
        public static void SearchMovieAfterGenre()
        {
            Console.Clear();
            Banner.MovieDBBanner();
            MovieService.GetGenreWithId();
            try
            {
                Console.WriteLine("Select genre from ID:");
                var genreId = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Banner.MovieDBBanner();
                MovieService.SearchMovieAfterGenre(genreId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong format");
            }
        }
        public static void AddMovie(string movieTitle, int movieYear, int genreId)
        {
            MovieService.AddMovie(movieTitle, movieYear, genreId);
        }
        public static void DeleteMovie(int id)
        {
            MovieService.DeleteMovie(id);
        }
        public static void GetGenresWithId()
        {
            MovieService.GetGenreWithId();
        }

    }
}
