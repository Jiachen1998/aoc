using aoc.Shared;

namespace aoc._2025
{
    internal static class Day9
    {
        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2025, 9, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var points = lines.Select(l => l.Split(','))
            .Select(n => (x: long.Parse(n[0]), y: long.Parse(n[1])))
            .ToList();

            long maxArea = 0;
            foreach (var point in points)
            {
                foreach (var otherPoint in points)
                {
                    long area = CalculateArea(point, otherPoint);
                    if (area > maxArea) maxArea = area;
                }
            }

            return maxArea;
        }

        internal static long Part2(bool useTest = false)
        {
            long maxArea = 0;
            string input = Utilities.ReadInputFile(2025, 9, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var redTiles = lines.Select(l => l.Split(','))
            .Select(n => (x: long.Parse(n[0]), y: long.Parse(n[1])))
            .ToList();

            var perimeterTiles = GetPerimeterTiles(redTiles);
            Console.WriteLine($"Perimeter tiles: {perimeterTiles.Count}");

            // Pre-sort perimeter tiles by x-coordinate for efficient range queries
            var sortedPerimeterTiles = perimeterTiles.OrderBy(t => t.x).ToList();

            // Check each pair of tiles once (avoid checking both (A,B) and (B,A))
            foreach (var first in redTiles)
            {
                foreach (var second in redTiles)
                {
                    // Only process each pair once using coordinate ordering
                    if (first.x > second.x || (first.x == second.x && first.y >= second.y))
                        continue;

                    // Check if rectangle is valid using perimeter checks
                    if (!IsRectangleValid(first, second, sortedPerimeterTiles))
                    {
                        continue;
                    }

                    long area = CalculateArea(first, second);
                    if (area > maxArea) 
                    {
                        Console.WriteLine($"Valid rectangle: ({first.x},{first.y}) to ({second.x},{second.y}) with area {area}");
                        maxArea = area;
                    }
                }
            }

            return maxArea;
        }

        /// <summary>
        /// Get only the perimeter tiles (edges) of the polygon.
        /// </summary>
        private static HashSet<(long x, long y)> GetPerimeterTiles(List<(long x, long y)> redTiles)
        {
            if (redTiles.Count < 3)
                return new HashSet<(long x, long y)>();

            var perimeterTiles = new HashSet<(long x, long y)>();
            
            // Collect all tiles on the edges (perimeter)
            for (int i = 0; i < redTiles.Count; i++)
            {
                var p1 = redTiles[i];
                var p2 = redTiles[(i + 1) % redTiles.Count];
                
                // Add all tiles on the line segment from p1 to p2
                var edgeTiles = GetTilesOnLine(p1, p2);
                foreach (var tile in edgeTiles)
                {
                    perimeterTiles.Add(tile);
                }
            }
            
            return perimeterTiles;
        }
        
        /// <summary>
        /// Get all tiles on a line segment from p1 to p2 (Bresenham-like algorithm)
        /// </summary>
        private static List<(long x, long y)> GetTilesOnLine((long x, long y) p1, (long x, long y) p2)
        {
            var tiles = new List<(long x, long y)>();
            
            long dx = Math.Abs(p2.x - p1.x);
            long dy = Math.Abs(p2.y - p1.y);
            long sx = p1.x < p2.x ? 1 : -1;
            long sy = p1.y < p2.y ? 1 : -1;
            long err = dx - dy;
            
            long x = p1.x;
            long y = p1.y;
            
            while (true)
            {
                tiles.Add((x, y));
                
                if (x == p2.x && y == p2.y)
                    break;
                
                long e2 = 2 * err;
                
                if (e2 > -dy)
                {
                    err -= dy;
                    x += sx;
                }
                
                if (e2 < dx)
                {
                    err += dx;
                    y += sy;
                }
            }
            
            return tiles;
        }

        private static long CalculateArea((long x, long y) point1, (long x, long y) point2)
        {
            return (Math.Abs(point1.x - point2.x) + 1) * (Math.Abs(point1.y - point2.y) + 1);
        }

        /// <summary>
        /// Check if all tiles in the rectangle defined by p1 and p2 are inside the polygon.
        /// A rectangle is invalid if any perimeter tile is strictly inside the rectangle
        /// (not on the rectangle's boundary), as this means the polygon edge crosses through
        /// the rectangle's interior, indicating part of the rectangle is outside the polygon.
        /// Uses binary search on sorted list for efficient range queries.
        /// </summary>
        private static bool IsRectangleValid((long x, long y) p1, (long x, long y) p2, List<(long x, long y)> sortedPerimeterTiles)
        {
            long minX = Math.Min(p1.x, p2.x);
            long maxX = Math.Max(p1.x, p2.x);
            long minY = Math.Min(p1.y, p2.y);
            long maxY = Math.Max(p1.y, p2.y);
            
            // Binary search to find the first tile with x > minX
            int startIdx = FindFirstGreaterThan(sortedPerimeterTiles, minX);
            
            // Only iterate through tiles in the x-range (minX < x < maxX)
            for (int i = startIdx; i < sortedPerimeterTiles.Count; i++)
            {
                var tile = sortedPerimeterTiles[i];
                
                // Stop once we're past the x-range
                if (tile.x >= maxX)
                    break;
                
                // Check if tile is strictly inside the y-range
                if (tile.y > minY && tile.y < maxY)
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Binary search to find the index of the first element with x > target.
        /// </summary>
        private static int FindFirstGreaterThan(List<(long x, long y)> sortedTiles, long target)
        {
            int left = 0;
            int right = sortedTiles.Count;
            
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (sortedTiles[mid].x <= target)
                    left = mid + 1;
                else
                    right = mid;
            }
            
            return left;
        }
    }
}
