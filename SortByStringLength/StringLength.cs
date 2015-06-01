//Problem 5. Sort by string length

//You are given an array of strings. Write a method that sorts the array by the length of its elements (the number of characters composing them).

using System;
using System.Linq;

class StringLength
{
        static void Main()
    {
        string[] input = new string[]
	    {
	        "Joseph",
	        "Catherina",
	        "Maya",
	        "Elizabeth",
	        "Francois",
            "Henri"
	    };
        Console.WriteLine("Original Array.\n");
        foreach (string country in input)
        {
            Console.WriteLine(country);
        }
        Console.WriteLine();
        Console.WriteLine("Sorted Array.\n");
        var sortedArray = from item in input
                   orderby item.Length
                   select item;

        foreach (string item in sortedArray)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }

}


