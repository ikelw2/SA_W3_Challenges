//using System.Collections.Generic; 
using System.Runtime.InteropServices.Marshalling;
using Spectre.Console;

Console.WriteLine("Challenge_3_4: return shortest length after replace exhaustive pairs in string \n");

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

    // some test cases ABFCACDBD

    // can brute force it in ex 4, or can use a stack... // leetcode 2696
    // it doesn't matter which AB or CD type is... all that matters is the particular index we replace each time...


    string input = "ABFCACDBAB";
    input = GenRandomABCDTestString();


    string patternAB = "AB";
    string patternCD = "CD";
    string workingString = input; // only make edits to workingString
    Console.WriteLine($"Initial String: '{workingString}'");
    bool stillSearching = true;

    // 1. loop until no more replacements possible
    while (stillSearching)
    { 
        // 2. check for AB
        int foundPatternAB = workingString.IndexOf(patternAB);

        // 3. remove AB
        if (foundPatternAB != -1)
        {
            PrintHighlighted(foundPatternAB, patternAB, workingString);
            workingString = workingString.Remove(foundPatternAB, 2);
            //Console.WriteLine($"                '{workingString}'");
        }

        // 4. check for CD
        int foundPatternCD = workingString.IndexOf(patternCD);

        // 5. remove CD
        if (foundPatternCD != -1)
        {
            PrintHighlighted(foundPatternCD, patternCD, workingString);
            workingString = workingString.Remove(foundPatternCD, 2);
            //Console.WriteLine($"                '{workingString}'");
        }

        if ((foundPatternAB == -1) && (foundPatternCD == -1))
        {
            stillSearching = false;
        }
    }
    Console.WriteLine($"Updated String: '{workingString}'   Length: {workingString.Length}");



    


    /*
    Stack < Node> history = new Stack<Node>(); // use stack to keep track of our traversals
    history.Push(new Node(input, -1)); // starting point
    
    List<int> bestSequenceSoFar = new List<int>(); // update this when we find a better option

    while (history.Count > 0 ) // 
    { 
        List<int> curSequenceTesting... // if not already in history?
        // for each option, push to progress a step of replacement, and save indices to internal list

        // if no more replacements, save progress to 

    }
    */

    //List<int> Options = GetListOfRemainingPatterns(input);
    //    foreach (int option in Options)
    //    {
    //        i.Push(option);
    //        workingString = s.Peek()
    //    }
    //}

    /*
    List<int> GetListOfRemainingPatterns(string text)
    {
        List<int> result = new List<int>();
        for (int i = 0; i < (len - 1); i++)
        {
            if ((text.IndexOf("AB") == i) || (text.IndexOf("CD") == i))
            {
                result.Add(i);
            }
        }
        return result;
    }
    */


    //         'abcdefab'  -->  there are three options -->   [0] [2] and [6] out of highest index of 7
    // Console.WriteLine($"findqtr('ABCDA') = {FindQtyPatterns("ABCDAS")}"); // 2
    // go one by one through those options, save indexed replacements to stack for easy recall, and save resulting length of string to integer (for comparison with other solutions)
    // try each option fully, saveing all branch options for comparison to figure out which resulted in the least remaining characters

    //for (int i = 0; i < input.Length; i++)
    //{
    //    if (input.IndexOf("PA", StringComparison.OrdinalIgnoreCase);
    //    if (input.IndexOf(AB)
    //}









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
        .Select(_ => (char)random.Next('A', 'F' + 1))
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
        AnsiConsole.Markup($"                [gray]'{working}'[/]");
        return;
    }
    
    // 1. print start of string in gray
    if (index > 0) // if not at start index of string
    {
        string firstPart = working.Substring(0, index);
        AnsiConsole.Markup($"                [gray]'{firstPart}[/]");
    }
    else
    {
        AnsiConsole.Markup($"                [gray]'[/]");
    }
    
    // 2. print found pattern in red
    AnsiConsole.Markup($"[red]{pattern}[/]");
    
    // 3. print last part of string in gray
    if (index < (working.Length - 1) - 2) // if not at last-1 (-2 for pattern) index of string
    {
        string lastPart = working.Substring(index+2);
        AnsiConsole.Markup($"[gray]{lastPart}'[/]");
    }
    else
    {
        AnsiConsole.Markup($"[gray]'[/]");
    }

    Console.WriteLine();
    // meant to replace this line
    // Console.WriteLine($"                '{workingString}'");
}
// ------------------------------

//=============================================================================
//
// this solution object will require saving WHICH INDEX **of the optional replacements** WE REPLACE (subtracting two chars from a linear array of characters/string each time)
//   .. we are essentially navigating along a linear string
//         'abcdefab'  -->  there are three options -->   [0] [2] and [6] out of highest index of 7
// in order to traverse/test each option, we will need to create a new object at each of those junctures, and continue processing from that status point...
//
// so it should save in object (starting state to begin with)
// -array of already replaced indices (starts at [] for initial string)
// -current string before replacement
// -array of optional replacements at this juncture
//
// each time before we do a replacement, we push the current juncture, so we can traverse the entire string in depth, and return to our original string, but with the best option saved separately...
// two part procedure: traverse, and if results are better than previous, save the pathway to get there.

public struct Node
{
    public string CurString { get; set; }
    public int LastIndex { get; set; }

    public Node(string curString, int lastIndex)
    {
        CurString = curString;
        LastIndex = lastIndex;
    }
}

//public struct Node
//{
//    List<int> History { get; set; }
//    public string CurString { get; set; }
//    public int Count { get; set; }
//    List<int> Options { get; set; }
//    public Node(string history, string curString, int count)
//    {
//        PrevReplaceIndex = new List<int>();
//        Options = new List<int>();
//        CurrentString = newString;
//        Options = GetRemainingPatterns();

//    }


//    private int[] GetRemainingPatterns()
//    {
//        int qty = 0;
//        int len = CurrentString.Length;
//        for (int i = 0; i < (len - 1); i++) // check each character in string to determine if possible to replace it
//        {
//            if ((CurrentString.IndexOf("AB") == i) || (CurrentString.IndexOf("CD") == i))
//            {
//                qty++; // first count a tally to determine size of array to return
//            }
//        }
//        int[] result = new int[qty];

//        return result;
//    }
//}


////////////////////////////////////////////////////////////////////////////////////////////////////
// useful code chunks to have on easy recall

// Random random = new();
// int firstIndex = random.Next(x); // returns from 0 to x inclusive

// string input = "search string for pattern";
// bool found = input.Contains("fo"); // found == true
// int index = input.IndexOf("fo"); // index = 14

// int index = input.IndexOf("PA", StringComparison.OrdinalIgnoreCase); // index = 18