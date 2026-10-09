using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.UI
{
    internal class Banner
    {
        public static void MovieDBBanner()
        {
            AnsiConsole.MarkupLine("[DodgerBlue1]     _                  _  __                 __  __            _      \r\n    | | ___ _ __  _ __ (_)/ _| ___ _ __ ___  |  \\/  | _____   _(_) ___ \r\n _  | |/ _ \\ '_ \\| '_ \\| | |_ / _ \\ '__/ __| | |\\/| |/ _ \\ \\ / / |/ _ \\\r\n| |_| |  __/ | | | | | | |  _|  __/ |  \\__ \\ | |  | | (_) \\ V /| |  __/\r\n \\___/ \\___|_| |_|_| |_|_|_|  \\___|_|  |___/ |_|  |_|\\___/ \\_/ |_|\\___|\r\n|  _ \\| __ )                                                           \r\n| | | |  _ \\                                                           \r\n| |_| | |_) |                                                          \r\n|____/|____/                                                           [/]");
        }
    }
}
