//Problem 4. Binary search

//Write a program, that reads from the console an array of N integers and an integer K, sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.


using System;

class Binary
{
    static void Main()
    {
        int[] array = { 3, 5, 7, 9, 11, 13, 15, 17 }; // I am aware that this command does NOT READ a matrix from the console;

        Console.WriteLine("Enter value of K: ");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Array.Sort(array);
        int pos = Array.BinarySearch(array, k);
        if (pos < 0)
        {
            pos = ~pos - 1;
        }
        if (pos < 0)
        {
            Console.WriteLine("There is no number in the array which is smaller or equal to K.\n");
        }
        else
        {
            Console.WriteLine(array[pos]);
        }

    }

}


