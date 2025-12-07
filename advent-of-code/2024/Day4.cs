using aoc.Shared;

namespace aoc._2024
{
    internal static class Day4
    {
        private static List<string> ValidXmasWords = new() { "MAS", "SAM" };

        internal static Dictionary<string, List<(int Row, int Col)>> Transforms = new()
        {
            { "Left", new List<(int Row, int Col)> { (0, 0), (0, -1), (0, -2), (0, -3) } },
            { "Right", new List<(int Row, int Col)> { (0, 0), (0, 1), (0, 2), (0, 3) } },
            { "Up", new List<(int Row, int Col)> { (0, 0), (-1, 0), (-2, 0), (-3, 0) } },
            { "Down", new List<(int Row, int Col)> { (0, 0), (1, 0), (2, 0), (3, 0) } },
            { "UL", new List<(int Row, int Col)> { (0, 0), (-1, -1), (-2, -2), (-3, -3) } },
            { "UR", new List<(int Row, int Col)> { (0, 0), (-1, 1), (-2, 2), (-3, 3) } },
            { "DL", new List<(int Row, int Col)> { (0, 0), (1, -1), (2, -2), (3, -3) } },
            { "DR", new List<(int Row, int Col)> { (0, 0), (1, 1), (2, 2), (3, 3) } }
        };

        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 4, useTest);
            List<string> lines = Utilities.StringToLines(input);

            int result = 0;
            List<string> grid = new();            
            foreach (var line in lines)
            {
                grid.Add(line);
            }

            // Get positions of 'X'
            var xCoords = new List<(int Row, int Col)>();
            for (int col = 0; col < grid[0].Length; col++)
            {
                for (int row = 0; row < grid.Count; row++)
                {
                    if (grid[row][col] == 'X')
                    {
                        xCoords.Add((row, col));
                    }
                }
            }

            // Iterate through 'X', get chars in all 8 directions
            foreach (var x in xCoords)
            {
                foreach (var transform in Transforms.Values)
                {
                    if (ConstructWord(grid, x, transform))
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 4, useTest);
            List<string> lines = Utilities.StringToLines(input);

            int result = 0;
            List<string> grid = new();
            foreach (var line in lines)
            {
                grid.Add(line);
            }

            for (int col = 0; col < grid[0].Length - 2; col++)
            {
                for (int row = 0; row < grid.Count - 2; row++)
                {
                    var subGrid = GetSubGrid(grid, (row, col));
                    if (ValidateSubGrid(subGrid))
                        result++;
                }
            }

            return result;
        }

        internal static List<(int, int)> ApplyTransforms((int, int) startCoords, List<(int, int)> transforms)
        {
            var transformed = new List<(int, int)>();
            foreach (var transform in transforms)
            {
                transformed.Add(new (startCoords.Item1 + transform.Item1, startCoords.Item2 + transform.Item2));
            }
            return transformed;
        }

        internal static bool ConstructWord(List<string> grid, (int, int) startCoords, List<(int, int)> transforms)
        {
            var word = "";
            var coords = ApplyTransforms(startCoords, transforms);
            foreach (var coord in coords)
            {
                // Out of bounds check
                if (coord.Item1 < 0 || coord.Item1 > grid.Count - 1
                    || coord.Item2 < 0 || coord.Item2 > grid.Count - 1)
                {
                    return false;
                }
                word += grid[coord.Item1][coord.Item2];
            }
            return word == "XMAS";
        }

        internal static List<string> GetSubGrid(List<string> grid, (int Row, int Col) topLeftCoords)
        {
            var newGrid = new List<string>();
            for (int row = topLeftCoords.Row; row < topLeftCoords.Row + 3; row++)
            {
                var substring = grid[row].Substring(topLeftCoords.Col, 3);
                newGrid.Add(substring);
            }

            return newGrid;
        }

        internal static bool ValidateSubGrid(List<string> subGrid)
        {
            // (0, 0) (1, 1) (2, 2)
            var diag1 = $"{subGrid[0][0]}{subGrid[1][1]}{subGrid[2][2]}";

            // (2, 0) (1, 1) (0, 2)
            var diag2 = $"{subGrid[2][0]}{subGrid[1][1]}{subGrid[0][2]}";
            //Console.WriteLine(diag1);
            //Console.WriteLine(diag2);

            // Validate if 'MAS' or 'SAM'
            if (ValidXmasWords.Contains(diag1) && ValidXmasWords.Contains(diag2))
                return true;
            return false;
        }
    }
}
