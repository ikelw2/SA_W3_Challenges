//using System.Collections.Generic; 
using Spectre.Console;
using System.Collections;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.Marshalling;
using static System.Net.Mime.MediaTypeNames;

Console.WriteLine("Challenge_3_4: return shortest length after replace exhaustive pairs in string \n");

// METHOD ONE - brute force
Console.WriteLine("\nMethod 1: brute force  (while-iterate through string, if patterns found replace, if none found exit)\n");


while (true)
{


    // 4.You are given a string s consisting only of uppercase English letters. You can apply some operations
    // to this string where, in one operation, you can remove any occurrence of one of the substrings "AB" or "CD" from s.
    //    ** Return the minimum possible length of the resulting string that you can obtain. **
    //
    // Note that the string concatenates after removing the substring and could produce new "AB" or "CD" substrings.
    // * *Hint : Use Replace method of string.
    //
    // Example 1:
    // Input: s = "ABFCACDB"
    // Output: 2
    // 
    //     Explanation: We can do the following operations:
    //     - Remove the substring "abFCACDB", so s = "FCACDB".
    //     - Remove the substring "FCAcdB", so s = "FCAB".
    //     - Remove the substring "FCab", so s = "FC".
    //     So the resulting length of the string is 2.
    //     It can be shown that it is the minimum length that we can obtain.
    //
    // Example 2:
    // Input: s = "ACBBD"
    // Output: 5
    // 
    //     Explanation: We cannot do any operations on the string so the length remains the same.
    //

    //
    // can brute force it in ex 4, or can use a stack... // leetcode 2696
    //
    // ... it doesn't matter which AB or CD type is... all that matters is the particular index we replace each time...
    //
    // additional explanation:
    //
    // initially I thought that it mattered which AB or CD index you replaced first. After thinking about it
    // I came to the realization that I think it doens't matter which pathway the program chooses, as long as it 
    // replaces the text, which simplifies the problem greatly - since we are no longer trying to find the 
    // 'best index sequence' to replace found patterns.
    //

    string input = "ABFCACDBAB"; //  "ABCDABCD" tested
    // below line auto-generates test string, comment it out to use the above set string
    input = GenRandomABCDTestString();



    // define variables, print starting string
    string patternAB = "AB";
    string patternCD = "CD";
    string workingString = input; // only make edits to workingString
    //Console.WriteLine($"Initial String: {workingString}  Length: {workingString.Length}");





    // not sure how I used Remove, but I used it for this first solution. It works but it's not how the instructions said to do it
    
    Console.WriteLine($"Initial String: {workingString}  Length: {workingString.Length}");
    // 1. loop until no more replacements possible
    bool stillSearching = true;
    while (stillSearching)
    { 
        // 2. check for AB
        int foundPatternAB = workingString.IndexOf(patternAB);

        // 3. remove AB
        if (foundPatternAB != -1)
        {
            PrintHighlighted(foundPatternAB, patternAB, workingString);
            workingString = workingString.Remove(foundPatternAB, 2);
        }

        // 4. check for CD
        int foundPatternCD = workingString.IndexOf(patternCD);

        // 5. remove CD
        if (foundPatternCD != -1)
        {
            PrintHighlighted(foundPatternCD, patternCD, workingString);
            workingString = workingString.Remove(foundPatternCD, 2);
        }

        // 6. if no patterns found, stop searching   (required to check both vars in this implementation)
        if (((foundPatternAB == -1) && (foundPatternCD == -1)) || (workingString.Length == 0))
        {
            stillSearching = false;
        }
    }

    // 7. show result
    Console.WriteLine($"Updated String: {workingString}   Length: {workingString.Length}");












    //=====================================================================================================
    Console.WriteLine("\n            Method 2: Replace\n");
    workingString = input; 
    Console.WriteLine($"      Initial String: {workingString}  Length: {workingString.Length}");

    // naive approach #2 using correct "replace" function
    int finalLength = 0;
    while (workingString.Length > 0)
    {
        string temp = workingString.Replace("AB", null).Replace("CD", null);
        if (temp.Equals(workingString))
        {
            finalLength = temp.Length;
            break;
        }
        else
        {
            Console.WriteLine($"         temp String: {temp}");
        }
        workingString = temp;
    }
    Console.WriteLine($"      Updated String: {workingString}   Length: {workingString.Length}");







    //=====================================================================================================
    Console.WriteLine("\n            Method 3: Recursion\n");
    workingString = input;
    Console.WriteLine($"      Initial String: {workingString}  Length: {workingString.Length}");
    
    // naive approach #3 using recursive function (need to scroll to bottom to see function, but has been copied to comments below)
    recurseReplace( workingString, workingString.Length );









    //=====================================================================================================
    Console.WriteLine("\n            Method 4: Stack\n");
    workingString = input;
    Console.WriteLine($"      Initial String: {workingString}  Length: {workingString.Length}");
    
    //**
    // methodology, I didn't get it correct myself, I had to check a web-provided summary of answer :(
    //**

    // focus on the scan - using a stack I am essentially checking if two elements are in sequence, as I linearly walk the string char by char
    //
    // gotta remember that when using a stack, it's ideally suited to compare two separate values when going through a linear structure like a string
    // think "I have a dish holder rack, and I'm trying to go through a pile of dishes to determine when I come across two dishes one after the other in a particular pattern 'AB' or 'BC'

    Stack<char> stack = new Stack<char>();
    foreach (char next in workingString) 
    {
        if (stack.Count == 0)
        {
            stack.Push(next);
        }
        else
        {
            char top = stack.Peek();
            if ( (next == 'B' && 'A' == top) || // if previous pushed char is 'A' and next char is 'B' (pattern 1)   OR
                 (next == 'D' && 'C' == top) )  // if previous pushed char is 'C' and next char is 'D' (pattern 2)
            {
                stack.Pop(); // ...remove the last char pushed
            }
            else
            {
                stack.Push(next); // otherwise add next char to stack
            }
        }
    }
    Console.WriteLine($"      Updated String: (skipped)   Length: {stack.Count}");





















    Console.Write("\nEnter Q to quit or press ENTER to continue.");
    bool userWantsToQuit = (Console.ReadLine().Trim().Equals("q", StringComparison.OrdinalIgnoreCase) == true); // if user enters 'q' or 'Q'
    if (userWantsToQuit == true)
    {
        break; // exit from main program loop
    }
    Console.WriteLine("-----------------------------------------------------");
}
Console.WriteLine();







// ------------------------------
string recurseReplace(string s, int size)
{
    string n = s.Replace("AB", null, StringComparison.OrdinalIgnoreCase).Replace("CD", null, StringComparison.OrdinalIgnoreCase);
    if (size != n.Length) // changes made
    {
        //Console.WriteLine($"         temp String: {n}");
        if (size == 0)
        {
            return "";
        }
        return recurseReplace(n, n.Length);
    }
    else // no changes made, all done searching
    {
        Console.WriteLine($"      Updated String: {n}   Length: {n.Length}");
        return n;
    }
}





















// ------------------------------
// used AI to quickly produce this function which creates test cases
string GenRandomABCDTestString() // generate random input string for testing
{
    int minLength = 8;
    int maxLength = 25;
    int minPatterns = 3;
    int maxPatterns = 15; Random random = new Random();
    string output = string.Empty;

    // 1. create 30 char uppercase string with random letters
    char[] charArray = Enumerable.Range(0, random.Next(minLength, maxLength))
        .Select(_ => (char)random.Next('A', 'E' + 1))
        .ToArray();

    // 2. Inject the patterns at random valid index locations
    int count = random.Next(minPatterns, maxPatterns);
    for (int i = 0; i < count; i++)
    {
        // Pick one of the patterns randomly
        string pattern = random.Next(0, 2) == 0 ? "AB" : "CD";

        // Choose a random index ensuring the 2-character pattern fits within 30 characters
        int index = random.Next(0, charArray.Length - 1);

        charArray[index] = pattern[0];
        charArray[index + 1] = pattern[1];
    }

    string result = new string(charArray);
    return result;
}
// ------------------------------
void PrintHighlighted(int index, string pattern, string working)
{
    //Console.WriteLine($"  ** index is {index}"); // if get string overflow error, check this
    
    // if incorrect input just print line in gray
    if (index == -1)
    {
        // print entire string and return
        AnsiConsole.Markup($"                [gray]{working}[/]");
        return;
    }
    

    // 1. print start of string in gray
    if (index > 0) // if not at start index of string
    {
        string firstPart = working.Substring(0, index);
        AnsiConsole.Markup($"                [gray]{firstPart}[/]");
    }
    else
    {
        AnsiConsole.Markup($"                [gray][/]");
    }
    

    // 2. print found pattern in red
    AnsiConsole.Markup($"[red]{pattern}[/]");
    

    // 3. print last part of string in gray
    if (index < (working.Length - 1) - 1) // if not at last-1 (-2 for pattern) index of string
    {
        string lastPart = working.Substring(index+2);
        AnsiConsole.Markup($"[gray]{lastPart}[/]");
    }
    else
    {
        AnsiConsole.Markup($"[gray][/]");
    }

    Console.WriteLine();
    // meant to replace this line
    // Console.WriteLine($"                '{workingString}'");
}
// ------------------------------
