//Problem 1. Fill the matrix

//Write a program that fills and prints a matrix of size (n, n) as shown below:
//Example for n=4:

//a)	b)	c)	d)*
//1	5	9	13
//2	6	10	14
//3	7	11	15
//4	8	12	16
//1	8	9	16
//2	7	10	15
//3	6	11	14
//4	5	12	13
//7	11	14	16
//4	8	12	15
//2	5	9	13
//1	3	6	10
//1	12	11	10
//2	13	16	9
//3	14	15	8
//4	5	6	7


using System;

class FillMatrix
{
    static void PrintA(int[,] matrix, byte n, int counter)
    {
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = counter++;
            }
        }
        Print(matrix, n);
    }
    static void PrintB(int[,] matrix, byte n, int counter)
    {
        for (int col = 0; col < n; col++)
        {
            if ((col & 1) == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = counter++;
                }
            }
        }
        Print(matrix, n);
    }
    static void PrintC(int[,] matrix, byte n, int counter)
    {
        for (int row = n - 1; row >= 0; row--)
        {
            for (int col = 0; col < n - row; col++)
            {
                matrix[row + col, col] = counter++;
            }
        }
        for (int col = 1; col < n; col++)
        {
            for (int row = 0; row < n - col; row++)
            {
                matrix[row, col + row] = counter++;
            }
        }
        Print(matrix, n);
    }
    static void PrintD(int[,] matrix, byte n, int counter)
    {
        for (int index = 0; index <= n / 2; index++)
        {
            for (int row = index; row < n - index; row++)
            {
                matrix[row, index] = counter++;
            }
            for (int col = index; col < n - index; col++)
            {
                matrix[n - index, col] = counter++;
            }
            for (int row = n - index; row > index; row--)
            {
                matrix[row, n - index] = counter++;
            }
            for (int col = n - index; col > index; col--)
            {
                matrix[index, col] = counter++;
            }
        }
        if ((n & 1) == 0)
        {
            matrix[n / 2, n / 2] = counter;
        }
        Print(matrix, (byte)(n + 1));
    }
    static void Print(int[,] matrix, byte n)
    {
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0,4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    static void Main()
    {
        Console.WriteLine("This program that fills and prints a matrix of size (n, n)");
        Console.Write("Please enter N valid interval: ");
        byte n;
        if (byte.TryParse(Console.ReadLine(), out n) && n < 20)
        {
            int[,] matrix = new int[n, n];
            Console.WriteLine();
            PrintA(matrix, n, 1);
            PrintB(matrix, n, 1);
            PrintC(matrix, n, 1);
            PrintD(matrix, (byte)(n - 1), 1);
        }
        else
        {
            Console.WriteLine("\nWrong Input.\n");
        }
    }
}

