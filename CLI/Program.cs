using System.Diagnostics;
using System.Drawing;

internal class Program
{


    private static void WelcomeScreen()
    {

        Console.Clear();
        string text = @"
       _   _ _          
      /_\ | (_) ___ ___ 
     //_\\| | |/ __/ _ \
    /  _  \ | | (_|  __/
    \_/ \_/_|_|\___\___|
                 ,-----.,--.   ,--. 
                '  .--./|  |   |  | 
                |  |    |  |   |  | 
                '  '--'\|  '--.|  | 
                 `-----'`-----'`--' 

────────────────────────────────────────
    ";

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.DarkGray;

    }


    private static void Main(string[] args)
    {
        bool isSuccess = true;

        bool isDebug = false;
        bool isUpdate = false;

        // required both
        string serviceModpack = string.Empty;
        // defaults to curseforge if service is empty
        string appidModpack = string.Empty;

        WelcomeScreen();

        foreach (var @params in args)
        {
            if (@params == "--debug")
                isDebug = true;
            if (@params == "--update")
                isUpdate = true;
            if(@params.Contains("--service:"))
            {
                if (@params.Contains("--appid:"))
                {
                    appidModpack = @params.Replace("--appid:", "");
                    serviceModpack = @params.Replace("--service:", "");
                }
                else
                {
                    Console.WriteLine("Couldn't fetch '--appid' parameter");
                }
            } else
            {
                if (@params.Contains("--appid:"))
                {
                    appidModpack = @params.Replace("--appid:", "");
                    serviceModpack = "curseforge";
                }
            }
        }

        Console.Write(" Login: ");
        var user = Console.ReadLine();

        Console.Write(" Password: ");

        // https://stackoverflow.com/questions/3404421/password-masking-console-application
        var pass = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        if (isSuccess)
        {
            DisplayMenu();
        }
        else
        {
            // strips the update args
            Main(args.Select(x=>x.Replace("--update", "")).ToArray());
        }

    }
    
    private static void DisplayMenu()
    {

        ConsoleKeyInfo cKey;
        int index = 0;

        do
        {
            WelcomeScreen();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" Logged in as: ");
            Console.WriteLine("");

            string[] options = { "Play", "Host", "Service", "Modpack", "Options" };
            for (int i = 0; i < options.Length; i++)
            {
                if(index == i)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" →{options[i]}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"  {options[i]}");
                }
            }

            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" ♥ Discord: discord.alicelauncher.gg");
            Console.WriteLine(" ♥ Website: alicelauncher.gg");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine(" Version: 0.1");
            Console.WriteLine(" - with love, Project Alice...");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Press X or ESC to exit.");

            cKey = Console.ReadKey();

            if(index != 0)
            {
                if (cKey.Key == ConsoleKey.UpArrow || cKey.Key == ConsoleKey.W)
                    index--;
            }

            if(index != options.Length - 1)
            {
                if (cKey.Key == ConsoleKey.DownArrow || cKey.Key == ConsoleKey.S)
                    index++;
            }

            if (cKey.Key == ConsoleKey.RightArrow || cKey.Key == ConsoleKey.Enter || cKey.Key == ConsoleKey.D)
            {

            }

        } while (cKey.Key != ConsoleKey.Escape && cKey.Key != ConsoleKey.X);

    }

    // check on updates from github
    private static void Update()
    {
        
    }
}