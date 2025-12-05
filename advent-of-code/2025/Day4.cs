using aoc.Shared;

namespace aoc._2025
{
    internal static class Day4
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 4, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            var grid = Utilities.StringsToGrid(lines);
            return CountValidPositions(grid);
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 4, useTest);
            List<string> lines = Utilities.StringToLines(input);
            
            var grid = Utilities.StringsToGrid(lines);
            var totalRemoved = RemovePositionsContinuously(grid);
            return totalRemoved;
        }

        /// <summary>
        /// Given a grid, remove all '@' positions that are valid, and repeat until no more '@' positions are valid.
        /// Return the total number of '@' positions that were removed.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private static long RemovePositionsContinuously(char[,] grid)
        {
            long removedCount = 0;

            // Create a copy to avoid modifying the original grid
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            char[,] workingGrid = new char[rows, cols];
            Array.Copy(grid, workingGrid, grid.Length);
            
            // Keep removing positions until no more can be removed
            while (true)
            {
                char[,] previousGrid = Utilities.DeepCopy2DArray(workingGrid);
                workingGrid = RemovePositions(workingGrid);
                
                // Count how many positions were removed in this iteration
                long removedInThisIteration = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (previousGrid[row, col] == '@' && workingGrid[row, col] == '.')
                        {
                            removedInThisIteration++;
                        }
                    }
                }
                
                removedCount += removedInThisIteration;
                
                if (removedInThisIteration == 0)
                {
                    // No more positions to remove, we're done
                    break;
                }
            }
            
            return removedCount;
        }

        /// <summary>
        /// Given a grid, remove all '@' positions that are valid by setting them to '.'.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private static char[,] RemovePositions(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            List<(int row, int col)> positionsToRemove = new List<(int, int)>();
            
            // First pass: identify all valid '@' positions to remove
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row, col] == '@' && IsValidPosition(grid, row, col))
                    {
                        positionsToRemove.Add((row, col));
                    }
                }
            }
            
            // Second pass: remove all identified positions
            foreach (var (row, col) in positionsToRemove)
            {
                grid[row, col] = '.'; // Replace '@' with '.'
            }
            
            return grid;
        }

        /// <summary>
        /// Method to count the number of '@' positions that are valid in the grid.
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private static long CountValidPositions(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            long validCount = 0;
            
            // Loop through each '@' in the grid and check if the position is valid.
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (grid[row, col] == '@')
                    {
                        if (IsValidPosition(grid, row, col))
                        {
                            validCount++;
                        }
                    }
                }
            }
            
            return validCount;
        }

        /// <summary>
        /// Method to check if a position is valid in the grid. A position is valid if there are fewer than 4 '@' characters in the surrounding positions.
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private static bool IsValidPosition(char[,] grid, int row, int col)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);
            int atCount = 0;
            
            // Check all 8 surrounding positions (including diagonals)
            // Directions: up, down, left, right, and 4 diagonals
            int[] dRow = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dCol = { -1, 0, 1, -1, 1, -1, 0, 1 };
            
            for (int i = 0; i < 8; i++)
            {
                int newRow = row + dRow[i];
                int newCol = col + dCol[i];
                
                // Check if the position is within grid bounds
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    if (grid[newRow, newCol] == '@')
                    {
                        atCount++;
                    }
                }
            }
            
            // Position is valid if there are fewer than 4 '@' characters in surrounding positions
            return atCount < 4;
        }
    }
}
