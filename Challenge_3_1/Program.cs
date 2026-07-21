using Spectre.Console;
using SpectrePreloadedNamespace;
using System.Text;

SpectrePreloaded.StartupPanel("Challenge 3.1", "Determine if string is a Palindrome");

SpectrePreloaded.HighlightMethod("Method 1", "primitive equality checking by index, checking up to half of entire array");

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
    bool showComments = SpectrePreloaded.AskUserYesOrNoQuestion("\nDo you wish to see verbose comments?");
    
    
    string givenString = SpectrePreloaded.AskUserForString();
    string testString = cleanString(givenString);


    bool result = isPalindrome(testString, verboseComments: showComments);
    Console.WriteLine($"\nIsPalindrome(\"{testString}\") --> {result}");
    
    if (SpectrePreloaded.AskUserToContinue() == false)
    {
        break;
    }
}



//----------------------------------------
bool isPalindrome(string stringToTest, bool verboseComments = true) 
{
    if (verboseComments)
        AnsiConsole.MarkupLine("\n     [gray]0123456789-123456789-123456789-123456789[/]");
    if (verboseComments)
        Console.WriteLine("     " + stringToTest);

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
            AnsiConsole.Markup($"     [gray]Evaluating (string[[{i}]] == string[[{(length - 1 - i)}]]) - [/]");

        if (stringToTest[i] != stringToTest[(length - 1 - i)])
        {
            if (verboseComments)
                AnsiConsole.MarkupLine("[red]false[/][gray] - not palindrome, exiting early[/]");
            return false;
        }
        else
        {
            if (verboseComments) 
                AnsiConsole.MarkupLine("[green]true[/][gray] - could be a palindrome[/]");
        }
    }
    if (verboseComments)
        AnsiConsole.MarkupLine("     [green]Is Palidrome[/]");
    return true;
}
//----------------------------------------



string cleanString(string inputString)
{
    StringBuilder sb = new StringBuilder();
    foreach (char c in inputString)
    {
        // if character is not punctuation and not whitespace 
        if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c))
        {
            // convert to lowercase and append
            sb.Append(char.ToLower(c));
        }
    }
    return sb.ToString();
}
//----------------------------------------




SpectrePreloaded.ShutdownTasks(doReadline: false, doClear: false);