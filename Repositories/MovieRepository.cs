using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Repositories
{
    internal class MovieRepository
    {

        public static void DeleteMovie(int movieIdToDelete)
        {
            
                string connectionString =
                    "Server=localhost;Database=MovieDB;" +
                    "Trusted_Connection=True;TrustServerCertificate=True;";

                using var connection = new SqlConnection(connectionString);
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
  string connectionString =
   "Server=localhost;Database=MovieDB;" +
   "Trusted_Connection=True;TrustServerCertificate=True;";
            using var connection = new SqlConnection(connectionString);
    connection.Open();
            string sql ="SELECT m.MovieTitle, m.MovieReleaseYear, g.GenreName FROM Movie m INNER JOIN Genre g ON m.Genre_id = g.Genre_id";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
            var i = 1;
            while (reader.Read())
            {
                string movieTitle = reader.GetString(0);
                int movieYear = reader.GetInt32(1);
                string movieGenre = reader.GetString(2);
                Console.WriteLine($"{i++}.{movieTitle} ({movieYear}) - {movieGenre} ");   
            }
        }
        public static void ShowAllMoviesWithId()
        {
            string connectionString =
             "Server=localhost;Database=MovieDB;" +
             "Trusted_Connection=True;TrustServerCertificate=True;";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "SELECT m.Movie_id, m.MovieTitle, m.MovieReleaseYear, g.GenreName FROM Movie m INNER JOIN Genre g ON m.Genre_id = g.Genre_id";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();
          
            while (reader.Read())
            {
                int movieId = reader.GetInt32(0);
                string movieTitle = reader.GetString(1);
                int movieYear = reader.GetInt32(2);
                string movieGenre = reader.GetString(3);
                Console.WriteLine($"Movie ID: {movieId} {movieTitle} ({movieYear}) - {movieGenre} ");
            }
        }
        public static void GetGenreWithId()
        {
            string connectionString =
            "Server=localhost;Database=MovieDB;" +
            "Trusted_Connection=True;TrustServerCertificate=True;";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            string sql = "SELECT * FROM Genre";

            using var command = new SqlCommand(sql, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int genreId = reader.GetInt32(0);
                string genreName = reader.GetString(1);
               
                Console.WriteLine($"Genre ID: {genreId} {genreName}");
            }
        }
        public static void AddMovie(string movieTitle, int movieYear, int genreId)
        {

            string connectionString =
                "Server=localhost;Database=MovieDB;" +
                "Trusted_Connection=True;TrustServerCertificate=True;";

            using var connection = new SqlConnection(connectionString);
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

            string connectionString =
             "Server=localhost;Database=MovieDB;" +
             "Trusted_Connection=True;TrustServerCertificate=True;";
            using var connection = new SqlConnection(connectionString);
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
    }
}
