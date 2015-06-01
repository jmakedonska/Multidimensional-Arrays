//Problem 2. Maximal sum

//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.


using System;

class MaxSum
{
         private static uint GetSize(string p)
    {
        uint n = 0;
        Console.Write("\nPlease enter the size {0} >= 3: ", p);
        if (uint.TryParse(Console.ReadLine(), out n) && n >= 3)
        {
            return n;
        }
        else
        {
            Console.WriteLine("\nWrong input, the default value of 3 will be assumed.\n");
            return 3;
        }
    }
    private static int[,] GetMatrix(uint rows, uint cols)
    {
        int[,] matrix = new int[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("Please enter Matrix[{0},{1}]: ", row, col);
                int.TryParse(Console.ReadLine(), out matrix[row, col]);
            }
        }
        return matrix;
    }
    private static void GetMaxSumMatrix(int[,] matrix, uint rows, uint cols)
    {
        int maxSum = int.MinValue;
        uint startRow = 0;
        uint startCol = 0;
        for (uint row = 0; row < rows - 2; row++)
        {
            for (uint col = 0; col < cols - 2; col++)
            {
                int currentSum = 0;
                for (uint i = row; i <= row + 2; i++)
                {
                    for (uint j = col; j <= col + 2; j++)
                    {
                        currentSum += matrix[i, j];
                    }
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    startRow = row;
                    startCol = col;
                }
            }
        }
        printMatrix(matrix, startRow, startCol);
    }
    private static void printMatrix(int[,] matrix, uint row, uint col)
    {
        Console.WriteLine("\nThe 3x3 matrix with the maximal sum is:");
        for (uint i = row; i <= row + 2; i++)
        {
            for (uint j = col; j <= col + 2; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        Console.WriteLine("This program reads a rectangular matrix of size N x M\n" +
            "and finds in it the square 3 x 3 that has maximal sum of its elements.");
        uint n = GetSize("N");
        uint m = GetSize("M");
        int[,] matrix = GetMatrix(n, m);
        GetMaxSumMatrix(matrix, n, m);
    }

}


