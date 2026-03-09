namespace aoc.Shared
{
    internal static class Utilities
    {
        /// <summary>
        /// Reads an input file from the Inputs folder for a given year and day.
        /// </summary>
        /// <param name="year">The year (e.g., 2024, 2025)</param>
        /// <param name="day">The day number (e.g., 1, 2, 3)</param>
        /// <param name="useTest">If true, reads Day{day}Test.txt, otherwise reads Day{day}.txt</param>
        /// <returns>The contents of the input file as a string</returns>
        /// <exception cref="FileNotFoundException">Thrown if the input file cannot be found</exception>
        internal static string ReadInputFile(int year = 0, int day = 0, bool useTest = false)
        {
            string fileName = useTest ? $"Day{day}Test.txt" : $"Day{day}.txt";
            
            // Try multiple possible locations
            var possiblePaths = new List<string>();
            
            // Get the directory where the executable is running from
            var exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            
            // Try relative to executable (for when running from bin/Debug/net6.0)
            possiblePaths.Add(Path.Combine(exeDirectory, "..", "..", "..", year.ToString(), "Inputs", fileName));
            possiblePaths.Add(Path.Combine(exeDirectory, "..", "..", "..", "..", year.ToString(), "Inputs", fileName));
            possiblePaths.Add(Path.Combine(exeDirectory, "..", "..", "..", "..", "..", year.ToString(), "Inputs", fileName));
            
            // Try relative to current working directory (for when running from project root)
            var currentDir = Directory.GetCurrentDirectory();
            possiblePaths.Add(Path.Combine(currentDir, year.ToString(), "Inputs", fileName));
            possiblePaths.Add(Path.Combine(currentDir, "advent-of-code", year.ToString(), "Inputs", fileName));
            
            // Try to find project root by looking for .csproj file
            var searchDir = currentDir;
            for (int i = 0; i < 5; i++)
            {
                var csprojPath = Path.Combine(searchDir, "aoc.csproj");
                if (File.Exists(csprojPath))
                {
                    possiblePaths.Add(Path.Combine(searchDir, "advent-of-code", year.ToString(), "Inputs", fileName));
                    break;
                }
                searchDir = Path.GetDirectoryName(searchDir) ?? searchDir;
                if (string.IsNullOrEmpty(searchDir) || searchDir == Path.GetPathRoot(searchDir))
                    break;
            }
            
            foreach (var path in possiblePaths.Distinct())
            {
                try
                {
                    var normalizedPath = Path.GetFullPath(path);
                    if (File.Exists(normalizedPath))
                    {
                        return File.ReadAllText(normalizedPath).TrimEnd('\r', '\n');
                    }
                }
                catch
                {
                    // Continue to next path if this one is invalid
                }
            }
            
            throw new FileNotFoundException($"Could not find input file: {fileName} for year {year}, day {day}. Searched in: {string.Join(", ", possiblePaths.Distinct().Select(p => Path.GetFullPath(p)))}");
        }

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

        internal static long CalculateManhattanDistance((long x, long y) start, (long x, long y) end)
        {
            return Math.Abs(start.x - end.x) + Math.Abs(start.y - end.y);
        }

        internal static long CalculateEuclideanDistance3D((long x, long y, long z) start, (long x, long y, long z) end)
        {
            return (long)Math.Sqrt(Math.Pow(start.x - end.x, 2) + Math.Pow(start.y - end.y, 2) + Math.Pow(start.z - end.z, 2));
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
            var copy = new T[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
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

        internal static (int, int) SumCoords((int, int) a, (int, int) b)
        {
            return (a.Item1 + b.Item1, a.Item2 + b.Item2);
        }
    }
}
