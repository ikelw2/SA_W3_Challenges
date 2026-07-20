using Spectre.Console;
using SpectrePreloadedNamespace;
using static System.Runtime.InteropServices.JavaScript.JSType;

SpectrePreloaded.StartupPanel("Challenge 3.1", "Determine if string is a Palindrome");

SpectrePreloaded.HighlightMethod("Method 1", "TBD");

// 
// 1.Given a string, write a method that checks if it is a palindrome (is read the same backward as forward). Assume that string may consist only of lower-case letters.
// 
// Expected input and output
// 
// IsPalindrome("eye") → true
// 
// IsPalindrome("home") → false
// 


while (true)
{
    string testString = SpectrePreloaded.AskUserForString();

    Console.WriteLine("\n0123456789-123456789");
    Console.WriteLine(testString);

    bool result = isPalindrome(testString, verboseComments: false);
    Console.WriteLine($"IsPalindrome(\"{testString}\") --> {result}");
    
    if (SpectrePreloaded.DoesUserWantToQuit())
    {
        break;
    }
}



bool isPalindrome(string stringToTest, bool verboseComments = true) 
{
    // to test is palindrome, need to compare first element with last element, until halfway...
    int length = stringToTest.Length;
    
    int halfway;
    if (stringToTest.Length % 2 == 0) 
        halfway = stringToTest.Length / 2; // if 4 chars need to test 1-4 and 2-3, so 2 cases
    else
        halfway = (stringToTest.Length - 1) / 2; // if 3 chars [odd] just need to test 1 and 3 (1 case)


    for (int i = 0; i < halfway; i++)
    {
        if (verboseComments)
            AnsiConsole.MarkupLine($"     [gray]Testing string[[{i}]] != string[[{(length - 1 - i)}]] - [/]");

        if (stringToTest[i] != stringToTest[(length - 1 - i)])
        {
            if (verboseComments)
                AnsiConsole.MarkupLine("     [red]false - not palindrome, exiting early[/]");
            return false;
        }
        else
        {
            if (verboseComments) 
                AnsiConsole.MarkupLine("     [green]ok thus far - could be palindrome[/]");
        }
    }
    if (verboseComments)
        AnsiConsole.MarkupLine("     [green]Is Palidrome[/]");
    return true;
}




SpectrePreloaded.ShutdownTasks(doReadline: false, doClear: false);