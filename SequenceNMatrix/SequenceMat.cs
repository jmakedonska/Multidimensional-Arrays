//Problem 3. Sequence n matrix

//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.
//Example:

//matrix	result		matrix	result
//ha	fifi	ho	hi
//fo	ha	hi	xx
//xxx	ho	ha	xx
//ha, ha, ha		
//s	qq	s
//pp	pp	s
//pp	qq	s
//s, s, s

using System;


class SequenceMat
{
        static int maxSequence = 1;
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

    private static void printMatrix(string[] finalSequence)
    {
        Console.WriteLine("\nThe longest sequence of equal strings in the matrix is:\n");
        for (int i = 0; i < finalSequence.Length; i++)
        {
            if (i < finalSequence.Length - 1)
            {
                Console.Write("{0}, ", finalSequence[i]);
            }
            else
            {
                Console.WriteLine("{0}", finalSequence[i]);
            }
        }
        Console.WriteLine();
    }
    static string[] GetRightDiagonal(string[,] matrix)
    {
        int currentSequence = 1;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int startRow = 0;
        int startCol = 0;
        int col = 0;
        int row = 0;
        for (int startingRow = rows - 1; startingRow > 0; startingRow--)
        {
            row = startingRow;
            col = 1;
            while (col < cols && row < rows)
            {
                if (matrix[row, col] == matrix[row - 1, col - 1])
                {
                    currentSequence++;
                }
                else
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row - currentSequence;
                        startCol = col - currentSequence;
                    }
                    currentSequence = 1;
                }
                if ((row == rows - 1) || col == cols - 1)
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row - (currentSequence - 1);
                        startCol = col - (currentSequence - 1);
                    }
                }
                row++;
                col++;
            }
        }
        for (int startingCol = 2; startingCol < cols - 1; startingCol++)
        {
            row = 1;
            col = startingCol;
            while (col < cols && row < rows)
            {
                if (matrix[row, col] == matrix[row - 1, col - 1])
                {
                    currentSequence++;
                }
                else
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row - currentSequence;
                        startCol = col - currentSequence;
                    }
                    currentSequence = 1;
                }
                if ((row == rows - 1) || col == cols - 1)
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row - (currentSequence - 1);
                        startCol = col - (currentSequence - 1);
                    }
                }
                row++;
                col++;
            }
        }
        string[] resultDiagonal = new string[maxSequence];
        for (int i = startRow; i < startRow + maxSequence; i++)
        {
            resultDiagonal[i - startRow] = matrix[i, startCol];
            startCol++;
        }
        return resultDiagonal;
    }
    static string[] GetMaxColSequence(string[,] matrix)
    {
        int currentSequence = 1;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int startRow = 0;
        int startCol = 0;
        for (int col = 0; col < cols; col++)
        {
            currentSequence = 1;
            for (int row = 1; row < rows; row++)
            {
                if (matrix[row - 1, col] == matrix[row, col])
                {
                    currentSequence++;
                }
                else
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row - currentSequence;
                        startCol = col;
                    }
                    currentSequence = 1;
                }
                if ((row == rows - 1))
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row - (currentSequence - 1);
                        startCol = col;
                    }
                }
            }
        }
        string[] resultLine = new string[maxSequence];
        for (int i = startRow; i < startRow + maxSequence; i++)
        {
            resultLine[i - startRow] = matrix[i, startCol];
        }
        return resultLine;
    }
    static string[] GetMaxRowSequence(string[,] matrix)
    {
        int currentSequence = 1;
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int startRow = 0;
        int startCol = 0;
        for (int row = 0; row < rows; row++)
        {
            currentSequence = 1;
            for (int col = 1; col < cols; col++)
            {
                if (matrix[row, col - 1] == matrix[row, col])
                {
                    currentSequence++;
                }
                else
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row;
                        startCol = col - currentSequence;
                    }
                    currentSequence = 1;
                }
                if ((col == cols - 1))
                {
                    if (maxSequence < currentSequence)
                    {
                        maxSequence = currentSequence;
                        startRow = row;
                        startCol = col - (currentSequence - 1);
                    }
                }
            }
        }
        string[] resultLine = new string[maxSequence];
        for (int i = startCol; i < startCol + maxSequence; i++)
        {
            resultLine[i - startCol] = matrix[startRow, i];
        }
        return resultLine;
    }
    static void Main()
    {
        Console.WriteLine("This program finds the longest sequence of equal strings in the matrix.");
        string[,] input = 
        {
            {"ha", "fifi", "ho", "hi"},
            {"fo", "ha", "hi", "xx"},
            {"xxx", "ho", "ha", "xx"}   //diagonal ha ha ha is longest sequence of equal strings
        };
        string[] finalSequence;
        int currentSequence = 1;
        string[] rowSequence = GetMaxRowSequence(input);
        currentSequence = maxSequence;
        finalSequence = rowSequence;
        string[] colSequence = GetMaxColSequence(input);
        if (maxSequence > currentSequence)
        {
            currentSequence = maxSequence;
            finalSequence = colSequence;
        }
        string[] rightDiagonal = GetRightDiagonal(input);
        if (maxSequence > currentSequence)
        {
            currentSequence = maxSequence;
            finalSequence = rightDiagonal;
        }

        printMatrix(finalSequence);

    }

}


