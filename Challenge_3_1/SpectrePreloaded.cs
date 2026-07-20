using Spectre.Console;

namespace SpectrePreloadedNamespace;

internal static class SpectrePreloaded
{
    public static void StartupPanel(string shortTitle, string description)
    {
        AnsiConsole.Write(new Panel($"[gray]{shortTitle}: [/]{description}").BorderColor(Color.MediumVioletRed));
    }

    public static void HighlightMethod(string shortTitle, string description, int linesFollowing = 1)
    {
        AnsiConsole.MarkupLine($"\n\n[red on white]{shortTitle}: {description}[/]");
        for (int i = 0; i < linesFollowing; i++) 
        {
            Console.WriteLine();
        }
    }
    public static bool DoesUserWantToQuit()
    {
        Console.Write($"\nEnter Q to quit or press ENTER to continue.");
        string userInput = Console.ReadLine();
        bool result = (userInput.Trim().Equals("q", StringComparison.OrdinalIgnoreCase) == true);
        Console.WriteLine("---------------------------------------------------------------------------");
        return result;
    }
    public static void ShutdownTasks(bool doReadline = false, bool doClear = false)
    {
        if (doReadline)
            Console.ReadLine();
        if (doClear)
            Console.Clear();
    }

    public static string AskUserForString()
    {
        string inputString = AnsiConsole.Prompt(
            new TextPrompt<string>("Please input a string: ")
            );
        return inputString;
    }
}
