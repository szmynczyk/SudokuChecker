using System;
using System.Collections.Generic;

namespace SudokuChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var sampleTable = new int[,] {
                { 4,3,5, 2,6,9, 7,8,1 },
                { 6,8,2, 5,7,1, 4,9,3 },
                { 1,9,7, 8,3,4, 5,6,2 },

                { 8,2,6, 1,9,5, 3,4,7 },
                { 3,7,4, 6,8,2, 9,1,5 },
                { 9,5,1, 7,4,3, 6,2,8 },

                { 5,1,9, 3,2,6, 8,7,4 },
                { 2,4,8, 9,5,7, 1,3,6 },
                { 7,6,3, 4,1,8, 2,5,9 },
            };

            Console.WriteLine("Squares valid: " + AreSquaresValid(sampleTable));
            Console.WriteLine("Rows and columns valid: " + AreRowsAndColumnsValid(sampleTable));
        }

        private static bool AreRowsAndColumnsValid(int[,] sampleTable)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> hashRow = new HashSet<int>();
                HashSet<int> hashColumn = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    if (!hashRow.Add(sampleTable[i, j]) || !hashColumn.Add(sampleTable[j, i]))
                        return false;
                }
            }

            return true;
        }

        private static bool AreSquaresValid(int[,] sampleTable)
        {
            for (int columnMultipl = 0; columnMultipl < 3; columnMultipl++)
            {
                for (int rowMultipl = 0; rowMultipl < 3; rowMultipl++)
                {
                    HashSet<int> squareHash = new HashSet<int>();

                    for (int i = 0 + 3 * rowMultipl; i < 3 + 3 * rowMultipl; i++)
                    {
                        for (int j = 0 + 3 * columnMultipl; j < 3 + 3 * columnMultipl; j++)
                        {
                            if (!squareHash.Add(sampleTable[i, j]))
                                return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}