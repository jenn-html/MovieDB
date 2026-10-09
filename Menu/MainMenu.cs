using MovieDB.Controllers;
using MovieDB.UI;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MovieDB.Menu
{
    public class MainMenu
    {
        public void ShowMainMenu()
        {
            string[] options = new[] {
                "[DeepPink2]Show all movies[/]",
                "[DeepPink2]Search movie after genre[/]",
                "[DeepPink2]Add new movie[/]",
                "[DeepPink2]Delete movie[/]",
                "[yellow]Exit[/]"
            };
            while (true)
            {
                Console.Clear();
                Banner.MovieDBBanner();

                // Use Spectre.Console SelectionPrompt for keyboard navigation + Enter selection
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[DeepPink2]---Select an option---[/]")
                        .PageSize(5)
                        .AddChoices(options)
                        .WrapAround()
                );

                int selected = Array.IndexOf(options, choice);

                Console.Clear();
                switch (selected)
                {
                    case 0:
                        MovieController.ShowAllMovies();

                        break;
                    case 1:
                        MovieController.SearchMovieAfterGenre();

                        break;
                    case 2:
                        AddMovieMenu.AddMovie();

                        break;
                    case 3:
                        DeleteMovieMenu.DeleteMovie();
                        break;
                    case 4:
                        AnsiConsole.MarkupLine($"[green]Exiting...[/]");
                        Environment.Exit(0);
                        break;
                    default:
                        AnsiConsole.MarkupLine($"[red]Invalid option.[/]");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey(true);
            }
        }
    }
}
