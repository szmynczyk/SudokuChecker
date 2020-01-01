using System;
using System.Collections.Generic;

namespace SudokuChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //var sampleTable = new int[,] {
            //    { 4,3,5, 2,6,9, 7,8,1 },
            //    { 6,8,2, 5,7,1, 4,9,3 },
            //    { 1,9,7, 8,3,4, 5,6,2 },

            //    { 8,2,6, 1,9,5, 3,4,7 },
            //    { 3,7,4, 6,8,2, 9,1,5 },
            //    { 9,5,1, 7,4,3, 6,2,8 },

            //    { 5,1,9, 3,2,6, 8,7,4 },
            //    { 2,4,8, 9,5,7, 1,3,6 },
            //    { 7,6,3, 4,1,8, 2,5,9 },
            //};

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

            List<int> badRows = GetRowsWithErrors(sampleTable);

            if (badRows.Count > 0)
            {
                string badRowsToShow = "";
                for (int i = 0; i < badRows.Count; i++)
                {
                    badRowsToShow += badRows[i];
                    if (i < badRows.Count - 1)
                    {
                        badRowsToShow += ", ";
                    }
                }

                Console.WriteLine("Mistakes in rows: " + badRowsToShow);
            }

            List<int> badColumns = GetColumnsWithErrors(sampleTable);

            if (badColumns.Count > 0)
            {
                string badColumnsToShow = "";
                for (int i = 0; i < badColumns.Count; i++)
                {
                    badColumnsToShow += badColumns[i];
                    if (i < badColumns.Count - 1)
                    {
                        badColumnsToShow += ", ";
                    }
                }

                Console.WriteLine("Mistakes in columns: " + badColumnsToShow);
            }

            Console.WriteLine("Squares valid: " + AreSquaresValid(sampleTable));

            List<int> badSquares = GetSquaresWithErrors(sampleTable);

            if (badSquares.Count > 0)
            {
                string badSquaresToShow = "";
                for (int i = 0; i < badSquares.Count; i++)
                {
                    badSquaresToShow += badSquares[i];
                    if (i < badSquares.Count - 1)
                    {
                        badSquaresToShow += ", ";
                    }
                }

                Console.WriteLine("Mistakes in squares: " + badSquaresToShow);
            }
        }

        private static List<int> GetRowsWithErrors(int[,] sampleTable)
        {
            List<int> badRows = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                //check row
                HashSet<int> hashRow = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    hashRow.Add(sampleTable[i, j]);
                }

                if (hashRow.Count < 9)
                {
                    badRows.Add(i+1);
                }
            }

            return badRows;
        }

        private static bool AreRowsValid(int[,] sampleTable)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> hashRow = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    if (!hashRow.Add(sampleTable[i, j]))
                        return false;
                }
            }

            return true;
        }

        private static List<int> GetColumnsWithErrors(int[,] sampleTable)
        {
            List<int> badColumns = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                HashSet<int> hashColumn = new HashSet<int>();
                    
                for (int j = 0; j < 9; j++)
                {
                    hashColumn.Add(sampleTable[j, i]);
                }

                if (hashColumn.Count < 9)
                {
                    badColumns.Add(i+1);
                }
            }

            return badColumns;
        }

        private static bool AreColumnsValid(int[,] sampleTable)
        {
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> hashColumn = new HashSet<int>();

                for (int j = 0; j < 9; j++)
                {
                    if (!hashColumn.Add(sampleTable[j, i]))
                        return false;
                }
            }

            return true;
        }

        private static List<int> GetSquaresWithErrors(int[,] sampleTable)
        {
            List<int> badSquares = new List<int>();

            for(int columnMultipl = 0; columnMultipl < 3; columnMultipl++)
            {
                for (int rowMultipl = 0; rowMultipl < 3; rowMultipl++)
                {
                    HashSet<int> squarehash = new HashSet<int>();

                    for (int i = 0 + 3 * rowMultipl; i < 3 + 3 * rowMultipl; i++)
                    {
                        for (int j = 0 + 3 * columnMultipl; j < 3 + 3 * columnMultipl; j++)
                        {
                            squarehash.Add(sampleTable[i, j]);
                        }
                    }

                    if (squarehash.Count < 9)
                    {
                        badSquares.Add((columnMultipl + 1) * (rowMultipl + 1));
                    }
                }
            }

            return badSquares;
        }

        private static bool AreSquaresValid(int[,] sampleTable)
        {
            for (int columnMultipl = 0; columnMultipl < 3; columnMultipl++)
            {
                for (int rowMultipl = 0; rowMultipl < 3; rowMultipl++)
                {
                    HashSet<int> squarehash = new HashSet<int>();

                    for (int i = 0 + 3 * rowMultipl; i < 3 + 3 * rowMultipl; i++)
                    {
                        for (int j = 0 + 3 * columnMultipl; j < 3 + 3 * columnMultipl; j++)
                        {
                            if (!squarehash.Add(sampleTable[i, j]))
                                return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}