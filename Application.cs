using Microsoft.Data.SqlClient;
using MovieDB.Menu;
using MovieDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    internal class Application
    {
        public void Run()
        {
            //        string connectionString =
            //"Server=localhost;Database=MovieDB;" +
            //"Trusted_Connection=True;TrustServerCertificate=True;";
            //        using var connection = new SqlConnection(connectionString);
            //        connection.Open();
            MovieRepository.SeedData();
            var mainMenu = new MainMenu();
            mainMenu.ShowMainMenu();
        }
    }
}
