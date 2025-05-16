public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>

    // Part 1: Arrays
    public static double[] MultiplesOf(double start, int count)
    {
        // Step 1: Create an array to hold the multiples
        double[] multiples = new double[count];

        // Step 2: Loop through and populate the array with multiples of 'start'
        for (int i = 0; i < count; i++)
        {
            multiples[i] = start * (i + 1);  // The (i+1)th multiple of 'start'
        }

        // Step 3: Return the populated array
        return multiples;
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    
   public static void RotateListRight(List<int> data, int amount)
{
    //If the list is empty or the amount is zero, no rotation is needed.
    if (data == null || data.Count == 0 || amount == 0)
        return;

    // Step 1: Normalize the rotation amount.
    // If amount is greater than the list count, we reduce it using modulo.
    amount = amount % data.Count;

    // If after normalization the amount is 0, the list remains unchanged.
    if (amount == 0)
        return;

    // Step 2: Determine the index at which the list should be split.
    // To rotate right, move the last 'amount' elements to the front, then calculate the starting index of these elements.
    int splitIndex = data.Count - amount;

    // Step 3: Create two sublists using GetRange.
    // part1 will contain the elements to move to the front (from splitIndex to the end).
    // part2 will contain the remaining elements (from start to splitIndex).
    List<int> part1 = data.GetRange(splitIndex, amount);
    List<int> part2 = data.GetRange(0, splitIndex);

    // Step 4: Clear the original list, then rebuild it with the rotated content.
    data.Clear();

    // Step 5: Add the rotated parts back to the list. Now first, add the elements that were moved to the front, then, add the rest of the original list after them.
    data.AddRange(part1); // Adds the tail part first.
    data.AddRange(part2); // Then adds the head part after it.
}


    public static void PrintMultiples()
    {
        double[] result = MultiplesOf(3, 5);

        // Printing the result
        Console.WriteLine("Multiples of 3 (5 times):");
        foreach (double multiple in result)
        {
            Console.WriteLine(multiple);
        }
    }

    public static void ListRotation(string[] args)
    {
        // Call PrintMultiples
        PrintMultiples();

        // Call RotateListRight and display results
        Console.WriteLine("\nRotated List:");
        List<int> data = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(data, 3);
        foreach (var num in data)
        {
            Console.WriteLine(num);
        }
    }

}

