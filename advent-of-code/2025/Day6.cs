using aoc.Shared;

namespace aoc._2025
{
    internal static class Day6
    {
        internal static long Part1(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 6, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var grid = ConstructGrid(lines);
            var transposed = TransposeMatrix(grid);

            for (int i = 0; i < transposed.GetLength(0); i++)
            {
                var row = Utilities.GetRow(transposed, i);
                result += Calculate(row);
            }
            
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 6, useTest);
            List<string> lines = Utilities.StringToLines(input);            
            
            var transposed = TransposePart2(lines);
            var groups = SplitIntoGroups(transposed);
            foreach (var group in groups)
            {
                result += CalculateGroup(group);
            }
            return result;
        }

        private static string[,] ConstructGrid(List<string> input)
        {
            if (input == null || input.Count == 0)
            {
                return new string[0, 0];
            }

            // Split each line and store as list of lists
            var parts = new List<List<string>>();
            foreach (var line in input)
            {
                parts.Add(line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList());
            }

            int numRows = parts.Count;
            int numCols = parts[0].Count;

            // Verify all rows have the same length
            for (int i = 1; i < numRows; i++)
            {
                if (parts[i].Count != numCols)
                {
                    throw new ArgumentException($"Row {i} has {parts[i].Count} columns, expected {numCols}");
                }
            }

            string[,] grid = new string[numRows, numCols];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    grid[i, j] = parts[i][j];
                }
            }

            return grid;
        }

        /// <summary>
        /// Given an n x m matrix, return a m x n matrix where the rows and columns are swapped.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static string[,] TransposeMatrix(string[,] matrix)
        {
            if (matrix == null)
            {
                return new string[0, 0];
            }

            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);
            string[,] transposed = new string[numCols, numRows];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    transposed[j, i] = matrix[i, j];
                }
            }

            return transposed;
        }

        /// <summary>
        /// Given a row from the transposed grid, calculate the result by applying the sign to all numbers in the row.
        /// The last element of the row is the operator sign.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static long Calculate(string[] row)
        {
            if (row == null || row.Length == 0)
            {
                return 0;
            }

            // Get all numbers except the last element (which is the sign)
            var numbers = row.Take(row.Length - 1)
                .Select(s => long.Parse(s.Trim()))
                .ToList();

            if (numbers.Count == 0)
            {
                return 0;
            }

            var sign = row[row.Length - 1];

            long result = numbers[0];
            for (int i = 1; i < numbers.Count; i++)
            {
                switch (sign.Trim())
                {
                    case "+":
                        result += numbers[i];
                        break;
                    case "*":
                        result *= numbers[i];
                        break;
                    default:
                        throw new ArgumentException($"Unsupported operator: {sign}");
                }
            }

            return result;
        }

        /// <summary>
        /// Transposes a list of strings (assumed equal length) such that each column becomes a string in the output.
        /// For example: ["abc", "def"] becomes ["ad", "be", "cf"]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<string> TransposePart2(List<string> input)
        {
            if (input == null || input.Count == 0)
            {
                return new List<string>();
            }

            int numRows = input.Count;
            int numCols = input[0].Length;

            // Verify all strings have the same length
            for (int i = 1; i < numRows; i++)
            {
                if (input[i].Length != numCols)
                {
                    throw new ArgumentException($"String at index {i} has length {input[i].Length}, expected {numCols}");
                }
            }

            List<string> transposed = new List<string>();

            for (int col = 0; col < numCols; col++)
            {
                char[] columnChars = new char[numRows];
                for (int row = 0; row < numRows; row++)
                {
                    columnChars[row] = input[row][col];
                }
                transposed.Add(new string(columnChars));
            }

            return transposed;
        }

        /// <summary>
        /// Given a 'row' of strings, split into groups of 'rows' that are separated by an empty divider row.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<List<string>> SplitIntoGroups(List<string> input)
        {
            if (input == null || input.Count == 0)
            {
                return new List<List<string>>();
            }

            List<List<string>> groups = new List<List<string>>();
            List<string> currentGroup = new List<string>();

            foreach (var line in input)
            {
                // Check if line is empty or whitespace (divider row)
                if (string.IsNullOrWhiteSpace(line))
                {
                    // If current group has content, add it to groups and start a new group
                    if (currentGroup.Count > 0)
                    {
                        groups.Add(currentGroup);
                        currentGroup = new List<string>();
                    }
                }
                else
                {
                    // Add line to current group
                    currentGroup.Add(line);
                }
            }

            // Add the last group if it has content
            if (currentGroup.Count > 0)
            {
                groups.Add(currentGroup);
            }

            return groups;
        }

        /// <summary>
        /// Given a 'group', where a group is a collection of number strings where the last element of the first string is the operator.
        /// Each row contains exactly one number (except row 1 which also has the operator).
        /// Calculate the result by applying the operator to all numbers in the group.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        private static long CalculateGroup(List<string> group)
        {
            if (group == null || group.Count == 0)
            {
                return 0;
            }

            // Get the operator from the last character of the first string
            string firstString = group[0];
            if (string.IsNullOrWhiteSpace(firstString) || firstString.Length == 0)
            {
                return 0;
            }

            string operatorSign = firstString[firstString.Length - 1].ToString().Trim();

            // Get the number from the first string (everything except the last character)
            string firstNumberStr = firstString.Substring(0, firstString.Length - 1).Trim();
            if (string.IsNullOrWhiteSpace(firstNumberStr))
            {
                return 0;
            }

            long result = long.Parse(firstNumberStr);

            // Process remaining strings: each contains exactly one number
            for (int i = 1; i < group.Count; i++)
            {
                string numberStr = group[i].Trim();
                if (string.IsNullOrWhiteSpace(numberStr))
                {
                    continue;
                }

                long number = long.Parse(numberStr);

                // Apply the operator
                switch (operatorSign)
                {
                    case "+":
                        result += number;
                        break;
                    case "*":
                        result *= number;
                        break;
                    default:
                        throw new ArgumentException($"Unsupported operator: {operatorSign}");
                }
            }

            return result;
        }
    }
}
