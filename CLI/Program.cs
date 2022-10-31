using System.Diagnostics;

internal class Program
{


    private static readonly string WelcomeScreen =
    @"
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

    private static void Main(string[] args)
    {
        bool isDebug = false;
        bool isUpdate = false;

        // required both
        string serviceModpack = string.Empty;
        // defaults to curseforge if service is empty
        string appidModpack = string.Empty;

        Console.WriteLine(WelcomeScreen);

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

        Console.Write("Login: ");
        var user = Console.Read();

        Console.Write("Password: ");

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
    }

    // check on updates from github
    private static void Update()
    {
        
    }
}