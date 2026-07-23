using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Challenge_3_3: return array indices of numbers adding to target value \n");

while (true)
{
    // 3. Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    //
    // You may assume that each input would have exactly one solution, and you may not use the same element twice.
    //
    // Input: nums = [2,7,11,15], target = 9
    // Output: [0,1]
    //
    // Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    //
    // leetcode problem #1
    

          // ****** // solution notes from peers:
                    // always start inner loop with j= i+1


    // define test case, rather than soliciting user for input
    //int[] array = new int[4] { 2, 7, 11, 15 };
    //int target = 9;

    // define randomized test case using larger array, rather than soliciting user for input
    int[] array = new int[11] { 1, 2, 4, 7, 11, 15, 24, 26, 31, 43, 54 };
    Random random = new();
    int firstIndex = random.Next(11);
    int secondIndex = random.Next(11);
    while (firstIndex == secondIndex)
    {
        secondIndex = random.Next(11);
    }
    int target = array[firstIndex] + array[secondIndex];
    string spacer = (target > 9) ? "  " : " ";


    // do the work and print the results
    string resultString = string.Join(", ", findTwoIndices(array, target, showVerboseComments: false));
    Console.WriteLine($"{spacer}                          [0, 1, 2, 3,  4,  5,  6,  7,  8,  9, 10]");
    Console.WriteLine($"Target {target}:   findTwoIndices([{string.Join(", ", array)}], {target}) --> {resultString}\n");

    
    // loop or quit if user wants to
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
int[] findTwoIndices(int[] arr, int tar, bool showVerboseComments = true)
{
    // brute force first, likely O = (n^2) or higher complexity, despite extra conditional statements
    for (int i = 0; i < arr.Length; i++)
    {
        //if (arr[i] < tar) // *** works if array is arranged in ascending order, otherwise remove the if
        //{
            //for (int j = 0; j < arr.Length; j++) // commented out because not as efficient as the for loop below
            //{
            //    if (i == j)
            //    {
            //        continue; // skip condition where i is same as j, per instructions
            //    }
            for (int j = i + 1; j < arr.Length; j++)
            { 
                if (showVerboseComments) Console.Write($"     seeing if {arr[i]} + {arr[j]} == {tar}   ");
                if (arr[i] + arr[j] == tar)
                {
                    if (showVerboseComments) Console.WriteLine($"YES, returning [{i},{j}]");
                    int[] answer = new int[2] { i, j };
                    return answer;
                }
                else
                {
                    if (showVerboseComments) Console.WriteLine($"NO...");
                }

            }
        //}
    }
    return [-1, -1]; // if no match found earlier, return this as error code

    // NOTE: programmer is assuming that the numbers in the array must be arranged from smallest to largest, in ascending order... 
    // develop "better" solution later...?
}


