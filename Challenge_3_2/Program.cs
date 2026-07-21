Console.WriteLine("Challenge_3_2: Sum digits in string \n");

//  2.Sum digits in string
//
//  Given a string, write a method which returns sum of all digits in that string. Assume that string contains only single digits.
//  Expected input and output
//  SumDigitsInString("1q2w3e") → 6 SumDigitsInString("L0r3m.1p5um") → 9
//  SumDigitsInString("") → 0




while (true)
{

    // method 1: collect string from user
    Console.Write("Step 1. Enter the string: ");
    string inputString = Console.ReadLine();

    // method 2: assign string to begin with for testing purposes
    //string inputString = "1q2w3e";
    //Console.WriteLine($"Step 1. String is '{inputString}'");

    Console.WriteLine($"SumDigitsInString({inputString}) --> {SumDigitsInString(inputString, showVerboseComments: true)}\n");






    Console.Write("Enter Q to quit or press ENTER to continue.");
    bool userWantsToQuit = (Console.ReadLine().Trim().Equals("q", StringComparison.OrdinalIgnoreCase) == true); // if user enters 'q' or 'Q'
    if (userWantsToQuit == true)
    {
        break; // exit from main program loop
    }
    Console.WriteLine("-----------------------------------------------------");
}
Console.WriteLine();




//===================================================================
int SumDigitsInString (string testString, bool showVerboseComments = false)
{
    int sum = 0;
    foreach (char c in testString)
    {
        if (char.IsNumber(c))
        {
            int number = Convert.ToInt32(Char.GetNumericValue(c));
            sum += number;
            if (showVerboseComments) // shows the work
                Console.WriteLine($"     '{c}' is a number... sum is now {sum}");
        }
    }
    return sum;
}