using aoc.Shared;

namespace aoc._2025
{
    internal static class Day12
    {
        internal static long Part1(bool useTest = false)
        {
            long result = 0;
            string input = Utilities.ReadInputFile(2025, 12, useTest);
            List<string> lines = Utilities.StringToLines(input);

            // Parse shapes as sets of coordinates
            var shapes = GetShapes(lines);
            
            // Generate all unique orientations for each shape
            var allOrientations = shapes.Select(GetAllOrientations).ToList();
            
            // Parse requirements
            var requirements = ParseRequirements(lines);

            // Check each region
            foreach (var req in requirements)
            {
                if (CanFitAllShapes(req.width, req.height, req.shapeCounts, allOrientations))
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// Parse shapes from input, returning each as a HashSet of (row, col) coordinates
        /// </summary>
        private static List<HashSet<(int row, int col)>> GetShapes(List<string> lines)
        {
            var shapes = new List<HashSet<(int row, int col)>>();
            var currentRows = new List<string>();
            
            foreach (var line in lines)
            {
                // Stop when we hit requirement lines (contain 'x' like "12x5:")
                if (line.Contains('x') && line.Contains(':'))
                    break;
                
                // Empty line marks end of current shape
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (currentRows.Count > 0)
                    {
                        shapes.Add(ConvertToCoordinates(currentRows));
                        currentRows = new List<string>();
                    }
                    continue;
                }
                
                // Skip label lines (e.g., "0:", "1:")
                if (line.EndsWith(':') && !line.Contains('x'))
                    continue;
                
                currentRows.Add(line);
            }
            
            // Don't forget the last shape if no trailing empty line
            if (currentRows.Count > 0)
            {
                shapes.Add(ConvertToCoordinates(currentRows));
            }
            
            return shapes;
        }

        /// <summary>
        /// Convert rows of '#' and '.' to a set of coordinates where '#' exists
        /// </summary>
        private static HashSet<(int row, int col)> ConvertToCoordinates(List<string> rows)
        {
            var coords = new HashSet<(int row, int col)>();
            
            for (int row = 0; row < rows.Count; row++)
            {
                for (int col = 0; col < rows[row].Length; col++)
                {
                    if (rows[row][col] == '#')
                    {
                        coords.Add((row, col));
                    }
                }
            }
            
            return NormalizeShape(coords);
        }

        /// <summary>
        /// Normalize shape so minimum row and col are both 0
        /// </summary>
        private static HashSet<(int row, int col)> NormalizeShape(HashSet<(int row, int col)> shape)
        {
            if (shape.Count == 0) return shape;
            
            int minRow = shape.Min(c => c.row);
            int minCol = shape.Min(c => c.col);
            
            return shape.Select(c => (c.row - minRow, c.col - minCol)).ToHashSet();
        }

        /// <summary>
        /// Generate all unique orientations (rotations and flips) of a shape
        /// </summary>
        private static List<HashSet<(int row, int col)>> GetAllOrientations(HashSet<(int row, int col)> shape)
        {
            var orientations = new List<HashSet<(int row, int col)>>();
            var seen = new HashSet<string>();
            
            var current = shape;
            
            // 4 rotations
            for (int i = 0; i < 4; i++)
            {
                var normalized = NormalizeShape(current);
                var key = GetShapeKey(normalized);
                if (!seen.Contains(key))
                {
                    seen.Add(key);
                    orientations.Add(normalized);
                }
                current = RotateShape90(current);
            }
            
            // Flip horizontally and do 4 more rotations
            current = FlipShapeHorizontal(shape);
            for (int i = 0; i < 4; i++)
            {
                var normalized = NormalizeShape(current);
                var key = GetShapeKey(normalized);
                if (!seen.Contains(key))
                {
                    seen.Add(key);
                    orientations.Add(normalized);
                }
                current = RotateShape90(current);
            }
            
            return orientations;
        }

        /// <summary>
        /// Create a unique string key for a shape (for deduplication)
        /// </summary>
        private static string GetShapeKey(HashSet<(int row, int col)> shape)
        {
            var sorted = shape.OrderBy(c => c.row).ThenBy(c => c.col);
            return string.Join(";", sorted.Select(c => $"{c.row},{c.col}"));
        }

        /// <summary>
        /// Rotate shape 90 degrees clockwise
        /// </summary>
        private static HashSet<(int row, int col)> RotateShape90(HashSet<(int row, int col)> shape)
        {
            // (row, col) -> (col, -row) for 90 degree clockwise rotation
            return shape.Select(c => (c.col, -c.row)).ToHashSet();
        }

        /// <summary>
        /// Flip shape horizontally
        /// </summary>
        private static HashSet<(int row, int col)> FlipShapeHorizontal(HashSet<(int row, int col)> shape)
        {
            return shape.Select(c => (c.row, -c.col)).ToHashSet();
        }

        /// <summary>
        /// Parse requirement lines like "12x5: 1 0 1 0 2 2"
        /// </summary>
        private static List<(int width, int height, int[] shapeCounts)> ParseRequirements(List<string> lines)
        {
            var requirements = new List<(int width, int height, int[] shapeCounts)>();
            
            foreach (var line in lines)
            {
                // Look for lines with format "WxH: counts..."
                if (!line.Contains('x') || !line.Contains(':'))
                    continue;
                
                var parts = line.Split(':');
                if (parts.Length != 2)
                    continue;
                
                var dimensions = parts[0].Split('x');
                if (dimensions.Length != 2)
                    continue;
                
                if (!int.TryParse(dimensions[0], out int width) || !int.TryParse(dimensions[1], out int height))
                    continue;
                
                var counts = parts[1].Trim().Split(' ')
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(int.Parse)
                    .ToArray();
                
                requirements.Add((width, height, counts));
            }
            
            return requirements;
        }

        /// <summary>
        /// Check if all required shapes can fit in the given region
        /// </summary>
        private static bool CanFitAllShapes(int width, int height, int[] shapeCounts, 
            List<List<HashSet<(int row, int col)>>> allOrientations)
        {
            // Build list of shapes to place (with their orientations)
            var shapesToPlace = new List<List<HashSet<(int row, int col)>>>();
            
            int totalCellsNeeded = 0;
            for (int shapeIdx = 0; shapeIdx < shapeCounts.Length; shapeIdx++)
            {
                int cellCount = allOrientations[shapeIdx][0].Count;
                for (int i = 0; i < shapeCounts[shapeIdx]; i++)
                {
                    shapesToPlace.Add(allOrientations[shapeIdx]);
                    totalCellsNeeded += cellCount;
                }
            }
            
            if (shapesToPlace.Count == 0)
                return true;
            
            // Early check: if total cells needed > grid size, impossible
            if (totalCellsNeeded > width * height)
                return false;
            
            // Sort shapes by size (largest first) for better pruning
            shapesToPlace = shapesToPlace.OrderByDescending(s => s[0].Count).ToList();
            
            // Start backtracking with empty grid
            var occupied = new HashSet<(int row, int col)>();
            return Backtrack(0, shapesToPlace, occupied, width, height);
        }

        /// <summary>
        /// Backtracking solver to place all shapes
        /// </summary>
        private static bool Backtrack(int shapeIndex, List<List<HashSet<(int row, int col)>>> shapesToPlace,
            HashSet<(int row, int col)> occupied, int width, int height)
        {
            // Base case: all shapes placed
            if (shapeIndex >= shapesToPlace.Count)
                return true;
            
            var orientations = shapesToPlace[shapeIndex];
            
            // Try each orientation of this shape
            foreach (var orientation in orientations)
            {
                // Get shape bounds
                int shapeMaxRow = orientation.Max(c => c.row);
                int shapeMaxCol = orientation.Max(c => c.col);
                
                // Try each position in the grid
                for (int startRow = 0; startRow <= height - 1 - shapeMaxRow; startRow++)
                {
                    for (int startCol = 0; startCol <= width - 1 - shapeMaxCol; startCol++)
                    {
                        // Check if we can place the shape at this position
                        var placedCells = new List<(int row, int col)>();
                        bool canPlace = true;
                        
                        foreach (var (r, c) in orientation)
                        {
                            int actualRow = startRow + r;
                            int actualCol = startCol + c;
                            
                            if (occupied.Contains((actualRow, actualCol)))
                            {
                                canPlace = false;
                                break;
                            }
                            placedCells.Add((actualRow, actualCol));
                        }
                        
                        if (canPlace)
                        {
                            // Place the shape
                            foreach (var cell in placedCells)
                            {
                                occupied.Add(cell);
                            }
                            
                            // Recurse
                            if (Backtrack(shapeIndex + 1, shapesToPlace, occupied, width, height))
                            {
                                return true;
                            }
                            
                            // Remove the shape (backtrack)
                            foreach (var cell in placedCells)
                            {
                                occupied.Remove(cell);
                            }
                        }
                    }
                }
            }
            
            return false;
        }
    }
}
