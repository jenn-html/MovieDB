using MovieDB.Controllers;
using MovieDB.UI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Menu
{
    internal class DeleteMovieMenu
    {
        public static void DeleteMovie()
        {
            while (true)
            {
                Console.Clear();
                Banner.MovieDBBanner();

                MovieController.ShowAllMoviesWithId();
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
                break;
            }

        }
    }
}
