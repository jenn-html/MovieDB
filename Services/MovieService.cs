using MovieDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Services
{
    public class MovieService
    {
        public static void ShowAllMovies()
        {
            MovieRepository.ShowAllMovies();
        }
        public static void ShowAllMoviesWithId()
        {
            MovieRepository.ShowAllMoviesWithId();
        }
        public static void SearchMovieAfterGenre(int genreId)
        {
            MovieRepository.SearchMovieAfterGenre(genreId);
        }
        public static void AddMovie(string movieTitle, int movieYear, int genreId)
        {
            MovieRepository.AddMovie(movieTitle, movieYear, genreId);
        }
        public static void DeleteMovie(int id)
        {
            MovieRepository.DeleteMovie(id);
        }
        public static void GetGenreWithId()
        {
            MovieRepository.GetGenreWithId();
        }
        public static bool IsThereGenresInTheDatabase()
        {
           return MovieRepository.IsThereGenresInTheDatabase();
        }
    }
}
