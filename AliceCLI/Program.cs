global using static AliceCLI.Helper;
using AliceCLI;
using AliceCLI.Authentication.Microsoft.Minecraft.OAuth2;
using AliceCLI.Interfaces;
using AliceCLI.Java;
using AliceCLI.Modloader.Vanilla;
using CmlLib.Core.Auth;

internal class Program
{
    private static ConsoleKeyInfo cKey;
    private static MSession session;

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

    private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Goodbye.");
    }

    private static bool isRegistered = false;

    static ConsoleMenu mode = ConsoleMenu.Login;

    private static async Task Main(string[] args)
    {
        while (true)
        {
            switch (mode)
            {
                case ConsoleMenu.Login:

                    if (!isRegistered)
                    {
                        AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                        isRegistered = true;
                    }

                    bool isDebug = false;
                    bool isUpdate = false;


                    // required both
                    string serviceModpack = string.Empty;
                    // defaults to curseforge if service is empty
                    string appidModpack = string.Empty;

                    int indexLogin = 0;

                    do
                    {
                        WelcomeScreen();
                        string[] options = { "Device Code (Microsoft) (CLI Recommended)", "Authorization Code (Microsoft)", "Email & Password (Mojang)", "Offline Login (Local)" };
                        for (int i = 0; i < options.Length; i++)
                        {
                            if (indexLogin == i)
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

                        cKey = Console.ReadKey();
                        if (indexLogin != 0)
                        {
                            if (cKey.Key == ConsoleKey.UpArrow || cKey.Key == ConsoleKey.W)
                                indexLogin--;
                        }

                        if (indexLogin != options.Length - 1)
                        {
                            if (cKey.Key == ConsoleKey.DownArrow || cKey.Key == ConsoleKey.S)
                                indexLogin++;
                        }

                        if (cKey.Key == ConsoleKey.RightArrow || cKey.Key == ConsoleKey.Enter || cKey.Key == ConsoleKey.D)
                        {
                            Console.WriteLine("");

                            switch (indexLogin)
                            {
                                case 0:
                                    Console.ForegroundColor = ConsoleColor.White;

                                    session = await new DeviceCodeFlow("88f0a056-60d0-4005-a159-d94ddb768e79").Create();

                                    //await new User().Execute(AliceCLI.HttpMethods.POST, new Authenticate(session.AccessToken));

                                    break;

                                case 2:
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

                                    //session = "hi";

                                    break;

                                case 3:
                                    Console.Write(" Username: ");
                                    var username = Console.ReadLine();

                                    //token = "hi";
                                    break;
                            }

                            if (session.CheckIsValid())
                            {
                                await new Java().Exists();
                                mode = ConsoleMenu.MainMenu;
                                break;
                            }
                            else
                            {
                                // strips the update args
                                await Main(args.Select(x => x.Replace("--update", "")).ToArray());
                            }
                        }
                    } while (cKey.Key != ConsoleKey.Escape && cKey.Key != ConsoleKey.X);

                    Console.WriteLine("");


                    break;
                case ConsoleMenu.MainMenu:

                    int indexMainMenu = 0;

                    do
                    {
                        WelcomeScreen();

                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine($" Logged in as: {session.Username}");
                        Console.WriteLine("");

                        string[] options = { "Play", "Host", "Instances", "Options", "Sign Out" };
                        for (int i = 0; i < options.Length; i++)
                        {
                            if (indexMainMenu == i)
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
                        Console.WriteLine(" ♥ Discord: discord.alicelauncher.com");
                        Console.WriteLine(" ♥ Website: alicelauncher.com");

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                        Console.WriteLine(" Version: 0.1");
                        Console.WriteLine(" - with love, Project Alice...");
                        Console.WriteLine("");

                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Press X or ESC to exit.");

                        cKey = Console.ReadKey();
                        Console.WriteLine("");

                        if (indexMainMenu != 0)
                        {
                            if (cKey.Key == ConsoleKey.UpArrow || cKey.Key == ConsoleKey.W)
                                indexMainMenu--;
                        }

                        if (indexMainMenu != options.Length - 1)
                        {
                            if (cKey.Key == ConsoleKey.DownArrow || cKey.Key == ConsoleKey.S)
                                indexMainMenu++;
                        }

                        if (cKey.Key == ConsoleKey.RightArrow || cKey.Key == ConsoleKey.Enter || cKey.Key == ConsoleKey.D)
                        {
                            switch (indexMainMenu)
                            {
                                case 0:

                                    var modloader = new VanillaModloader();
                                    await modloader.Download();
                                    modloader.Play(session);

                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    Console.WriteLine("Signing out.");

                                    Environment.Exit(0);
                                    break;
                            }
                        }
                    } while (cKey.Key != ConsoleKey.Escape && cKey.Key != ConsoleKey.X);

                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                case ConsoleMenu.Instance:
                    break;
                case ConsoleMenu.Settings:
                    break;
                case ConsoleMenu.Host:
                    break;
                default:
                    break;
            }
        }
    }

    // check on updates from github
    private static void Update()
    {
        // Stable (stable)
        // PTB (test builds)
        // Canary (clones the directory and builds)
    }
}