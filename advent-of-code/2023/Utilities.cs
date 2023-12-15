namespace aoc._2023
{
    internal static class Utilities
    {
        internal static List<string> StringToLines(string str)
        {
            return str.Split("\r\n").ToList();
        }

        /// <summary>
        /// Iteration to calculate LCM of multiple numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        internal static long CalculateLcmMultiple(long[] nums)
        {
            long lcm = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                lcm = CalculateLcm(lcm, nums[i]);
            }
            return lcm;
        }

        /// <summary>
        /// Formula to calculate LCM of two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static long CalculateLcm(long a, long b)
        {
            return a / CalculateGcd(a, b) * b;
        }

        /// <summary>
        /// Formula to calculate GCD
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static long CalculateGcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Checks if all elements in a list are the same.
        /// Same functionality as List.Distinct().Count() == 1 but faster with early exits
        /// </summary>
        internal static bool CheckSameElements<T>(List<T> list)
        {
            if (list is null || list.Count == 0) return false;
            var first = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (!first.Equals(list[i])) return false;
            }
            return true;
        }


        internal static int CalculateManhattanDistance((int x, int y) start, (int x, int y) end)
        {
            return Math.Abs(start.x - end.x) + Math.Abs(start.y - end.y);
        }

        internal static long CalculateManhattanDistance((long x, long y) start, (long x, long y) end)
        {
            return Math.Abs(start.x - end.x) + Math.Abs(start.y - end.y);
        }

        internal static string RepeatString(string s, int count)
        {
            return string.Concat(Enumerable.Repeat(s, count));
        }

        /// <summary>
        /// Transpose a 2D grid of arbitrary type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="matrix"></param>
        /// <returns></returns>
        internal static T[,] TransposeGrid<T>(T[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            T[,] transposedArray = new T[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transposedArray[j, i] = matrix[i, j];
                }
            }

            return transposedArray;
        }

        /// <summary>
        /// Converts list of strings to char grid. Assumes strings are of even length.
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        internal static char[,] StringsToGrid(List<string> strings)
        {
            int numRows = strings.Count;
            int numCols = strings[0].Length;

            char[,] grid = new char[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    grid[i, j] = strings[i][j];
                }
            }

            return grid;
        }

        internal static T[] GetRow<T>(T[,] grid, int row)
        {
            int numCols = grid.GetLength(1);
            T[] rowArray = new T[numCols];

            for (int i = 0; i < numCols; i++)
            {
                rowArray[i] = grid[row, i];
            }

            return rowArray;
        }

        internal static T[] GetCol<T>(T[,] grid, int col)
        {
            int numRows = grid.GetLength(0);
            T[] colArray = new T[numRows];

            for (int i = 0; i < numRows; i++)
            {
                colArray[i] = grid[i, col];
            }

            return colArray;
        }

        internal static void SetRow<T>(T[,] grid, int row, T[] values)
        {
            int cols = grid.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                grid[row, i] = values[i];
            }
        }

        internal static void SetCol<T>(T[,] grid, int col, T[] values)
        {
            int rows = grid.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                grid[i, col] = values[i];
            }
        }

        /// <summary>
        /// Extracts subset of columns given two indices, inclusive
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        internal static T[,] GetCols<T>(T[,] grid, int startIndex, int endIndex)
        {
            int totalRows = grid.GetLength(0);

            int numColsToExtract = endIndex - startIndex + 1;
            T[,] result = new T[totalRows, numColsToExtract];

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = startIndex, k = 0; j <= endIndex; j++, k++)
                {
                    result[i, k] = grid[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Reflects a 2D grid on the vertical axis
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="grid"></param>
        /// <returns></returns>
        internal static T[,] ReflectCols<T>(T[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            T[,] reflectedGrid = new T[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    reflectedGrid[i, j] = grid[i, cols - j - 1];
                }
            }

            return reflectedGrid;
        }

        /// <summary>
        /// Compares two arrays and returns if they are identical, i.e. same elements and order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        internal static bool CompareArray<T>(T[] a, T[] b)
        {
            return a.SequenceEqual(b);
        }

        internal static bool Compare2DArray<T>(T[,] a, T[,] b)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (!a[i, j].Equals(b[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        internal static T[,] DeepCopy2DArray<T>(T[,] a)
        {
            var copy = new T[a.GetLength(0) , a.GetLength(1)];
            for (int i = 0; i <a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    copy[i, j] = a[i, j];
                }
            }
            return copy;
        }

        internal static void PrintGrid<T>(T[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal static T[,] RotateClockwise<T>(T[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            T[,] rotatedGrid = new T[cols, rows];

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    rotatedGrid[i, j] = grid[rows - j - 1, i];
                }
            }

            return rotatedGrid;
        }
    }
}
