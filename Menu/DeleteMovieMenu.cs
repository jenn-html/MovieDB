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

                Console.Clear();
                Banner.MovieDBBanner();

                MovieController.ShowAllMoviesWithId();


        }
    }
}
