using Microsoft.Data.SqlClient;
using MovieDB.Controllers;
using MovieDB.Services;
using MovieDB.UI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Repositories
{
    internal class MovieRepository
    {
        private static readonly string _connectionString =
            "Server=localhost;Database=MovieDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public static void DeleteMovie(int movieIdToDelete)
        {



            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string sql = "DELETE FROM Movie WHERE Movie_id = @Id";

            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Id", movieIdToDelete)
            };

            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddRange(parameters);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"Movie with ID: {movieIdToDelete} has been removed.");
            }
            else
            {
                Console.WriteLine($"Could not find a move with ID: {movieIdToDelete}.");
            }

        }
        public static void ShowAllMovies()
        {

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string sql = "SELECT m.MovieTitle, m.MovieReleaseYear, g.GenreName FROM Movie m INNER JOIN Genre g ON m.Genre_id = g.Genre_id";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("Could not find any movies.");
                return;
            }
            var i = 1;
            while (reader.Read())
            {
                string movieTitle = reader.GetString(reader.GetOrdinal("MovieTitle"));
                int movieYear = reader.GetInt32(reader.GetOrdinal("MovieReleaseYear"));
                string movieGenre = reader.GetString(reader.GetOrdinal("GenreName"));
                Console.WriteLine($"{i++}.{movieTitle} ({movieYear}) - {movieGenre} ");
            }
        }
        public static void ShowAllMoviesWithId()
        {
           
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT m.Movie_id, m.MovieTitle, m.MovieReleaseYear, g.GenreName " +
                         "FROM Movie m INNER JOIN Genre g ON m.Genre_id = g.Genre_id;";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("Could not find any movies.");
                return;
            }
            var i = 1;
            while (reader.Read())
            {
                int movieId = reader.GetInt32(reader.GetOrdinal("Movie_id"));
                string movieTitle = reader.GetString(reader.GetOrdinal("MovieTitle"));
                int movieYear = reader.GetInt32(reader.GetOrdinal("MovieReleaseYear"));
                string movieGenre = reader.GetString(reader.GetOrdinal("GenreName"));

                Console.WriteLine($"{i++}. Film ID: {movieId} {movieTitle} ({movieYear}) - {movieGenre} ");
            }
            AnsiConsole.MarkupLine("Select ID to delete a movie");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                MovieController.DeleteMovie(id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Wrong format on ID");
            }

        }
        public static void GetGenreWithId()
        {
        
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string sql = "SELECT * FROM Genre";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("Could not find any genres.");
                return;
            }
           
            while (reader.Read())
            {
                int genreId = reader.GetInt32(reader.GetOrdinal("Genre_id"));
                string genreName = reader.GetString(reader.GetOrdinal("GenreName"));

                Console.WriteLine($"Genre ID: {genreId} {genreName}");
            }
        }
        public static void AddMovie(string movieTitle, int movieYear, int genreId)
        {


            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string sql = "Insert into Movie (MovieTitle, MovieReleaseYear, Genre_id) Values (@Title, @Year, @GenreId);";


            SqlParameter[] parameters = new SqlParameter[]
            {
                    new SqlParameter("@Title", movieTitle),
                    new SqlParameter("@Year", movieYear),
                    new SqlParameter("@GenreId", genreId)
            };

            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddRange(parameters);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine($"Movie '{movieTitle}' has been added to the database.");
            }
            else
            {
                Console.WriteLine($"Could not add new movie");
            }
        }
        public static void SearchMovieAfterGenre(int genreId)
        {

            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string sql = "SELECT MovieTitle, MovieReleaseYear FROM Movie WHERE Genre_id = @GenreId";
            SqlParameter[] parameters = new SqlParameter[]
           {
                    new SqlParameter("@GenreId", genreId)
           };
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddRange(parameters);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("Could not find any movies in this genre.");
                return;
            }
            var i = 1;
            while (reader.Read())
            {
                string movieTitle = reader.GetString(0);
                int movieYear = reader.GetInt32(1);

                Console.WriteLine($"{i++}. {movieTitle} ({movieYear})");
            }
        }
        public static bool IsThereGenresInTheDatabase()
        {
          
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            string sql = "SELECT * FROM Genre";
            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                Console.WriteLine("There are no genres");
                return false;
            }
            else return true;
        }
        public static void SeedData()
        {

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT COUNT(*) FROM Genre";
            using var command = new SqlCommand(sql, connection);

            int count = (int)command.ExecuteScalar();

            if (count == 0)
            {
                string addGenres = "INSERT INTO Genre(GenreName) VALUES ('Comedy'),('Horror'),('Action'),('Fantasy'),('Satire'),('Sci-Fi'),('Thriller'),('Romance'),('Drama'),('Family');";
                using var cmdGenres = new SqlCommand(addGenres, connection);
                cmdGenres.ExecuteNonQuery();
            }
            string checkMoviesSql = "SELECT COUNT(*) FROM Movie";
            using var command2 = new SqlCommand(checkMoviesSql, connection);
            int movieCount = (int)command2.ExecuteScalar();

            if (movieCount == 0)
            {
                string addMoviesSql = @"
            INSERT INTO Movie (MovieTitle, MovieReleaseYear, Genre_id)
            SELECT 'Bruce Almighty', 2003, Genre_id FROM Genre WHERE GenreName = 'Comedy'
            UNION ALL
            SELECT 'Jaws', 1975, Genre_id FROM Genre WHERE GenreName = 'Horror'
            UNION ALL
            SELECT 'Interstellar', 2014, Genre_id FROM Genre WHERE GenreName = 'Sci-Fi'
            UNION ALL
            SELECT 'The Wizard of Oz', 1939, Genre_id FROM Genre WHERE GenreName = 'Fantasy'
            UNION ALL
            SELECT 'Titanic', 1997, Genre_id FROM Genre WHERE GenreName = 'Drama';";

                using var cmdMovies = new SqlCommand(addMoviesSql, connection);
                int rowsAffected = cmdMovies.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} filmer har lagts till i databasen!");
            }
        }


    }
}
