namespace aoc._2023
{
    internal static class Day14
    {
        private static readonly string TestInput = "O....#....\r\nO.OO#....#\r\n.....##...\r\nOO.#O....O\r\n.O.....O#.\r\nO.#..O.#.#\r\n..O..#O..O\r\n.......O..\r\n#....###..\r\n#OO..#....";
        private static readonly string Input = "...#.#.O....#.#.OO.OOO.O..O.......O#OO#.#..#....O...#.....O.O#..O..OO..O.#...#O..#...O...##O...OO...\r\n#O....O#..O.#.#..O#...#O.O....#O.#.#O#........O...O..#.OOO#O#.......OO##O.#.OO.O.#...##.##....O#..O#\r\n.O.......O.O.O.O..O.O.....#....O#..#.#O.#OO...#O.O#.O#..#O...#...O.O.......#.O....O.#..#.O##O#..O...\r\n...O....#.OO..#..OO#..##....#O.......OOOOOO...OO..#...#.O..O....#O..OO.#O...#O#...O..O#..OO....#....\r\n..O...##OOO....#..OO.OO#O##..#.#........O#.#.....#OO...#............#.###..#.#O...#..O.#O#.O#O.....#\r\n...............O.....##..O...O#.O#........#.O.#..#...#..O..O.#...#......#......O.OO.OOO.#.O.....O##.\r\n......#..#..###.OO.#......O..O.O##O..O.....OO.#.OO....O.....OO#O..O....#.....#.#.O#..O..O.OO.O#O.O.#\r\n##O.....O.#.#O...#.#O###....#.O#.#..#..O.#O........O.OO..#..#O#.O#..OO..#.O.##O....#.##O.O.......##.\r\nO#...###...O..#...#......O#.OO.....#...OOO...#.#O.#...##..OO#.......#OO.....#...O...#.#O.........O.O\r\n..O....O....OO..O.O.O........#.O#..O.#..#..OO#.OO..#.O...O..#...O..##..O........O##..........OOO..OO\r\n....##......#.#.O.O#O##.#....#..O#............#..#...#......#O.OO#....O.......O###....O...........OO\r\n.O.OOO..O#....O...O..#.O#.#O.O...#.O..O#...OO#.#....#OO.#........#O.......O...#O......O...O....#...#\r\n.#....#O...##..#.#..........O..#O........OOO.......O.OO.##...#..........#......#.O##.#O#OO#OO..#..O.\r\n......#O...#.#.......O........#O....#O..##....O......O.#.O..#OO............O##O....#O.OO#..O#..O#...\r\n..OO.....O#O..#OOOO#O.##.........O..#OO#......O.OO.....O......OO..O...O..O....O..O#O.......O..O.O#..\r\n....O...OO....##.....OOO...O#O.#.O...O.....#........#.#O#.....O.O.OO.###.#.OO#OO....O.....O..#.#O...\r\n.OO#..O#O#O...#..O.O....O#.O.#........O.O..O....#O#....#.#.O#.#...O.O..O..#..#...OO#O......#O.O..O.#\r\nOO...O.O.#..#....#...#O.O##O#...#............##.O..OOO....O..OO....#OO....O.#....O#.O........OO..#..\r\n..O#.OO#.#O#..O.......O.##.O.#....OO#.#O#.##.O..O#..####....#..#......#...##.O##...O....O..#.#......\r\n#O.O#.....#....O...O.O..O.O.O#O.O#....#..O...#.O.#O...#..#.#O.....#O..##...O.......O.....O..OO#OO##.\r\n..O.#..#...O....#.##.#.O......#.#.##.......#.O..##O#.#O.OOO..O...#O......#..O.....O.OO...O#.O.#OO#.O\r\n.#..OO#.......OO....O.##...O......O.OO#.O......#O..O#..#..O.O..O.#..OO.O.#O..O..#......O...O....O#..\r\nO....#.#O..O#...#..##..##.O.O.O..O.O#...O#..#O.O......#O.......O..O.O...#.#O..OO#.#.....#O#...O..#.O\r\n...O...O.O.O.OO..O....O..O..O##..O.........O#O..O.#...#.O..O.#........#...O........O#.#.O..O.....#..\r\nOO....O#...........#OO......O.....O...#...OO....OO..O.........O.#......##O....#...O##....O.#...#...#\r\n#OO#....#......OO.O....O...#..O...#.OOOO..OOO.O.O...O#.......O....#O#O.O#O......#...#...OO#.O...#..#\r\n....O#.#...O..#.................#.#...O...O...O.O#.##..O.#.#....####..OO....O.......#.OO.O....#...#.\r\n.....O.#.#O..#O...#OO....OO...O#..O...O..#O..O....#.#O..#.......O...O.O.....#.##.#O.OO..#.#....###..\r\n.#O..#...#...#.#.O.#O.#OO..#.#..#O#.#.#O#.O#O#..##..#...#O#.#..#.OO#..#..#..O...O...O..O...#.O....O.\r\n..O.....#....#O#OO#O.....O.....O...OO.O......OO..O....O...#....O....#...OO....O..O...#...###O.....#.\r\n##..##...#OOO...#.OO...#.#.O#.O.........O.O.#.O..O.OO#.O......#.###...#..#O.#....#...#.O..##...#O...\r\n.O.#...O.O....O.......O...#O.....O......OO..OOO##.#...##OO.O......#....O..#..#.##.OO.......#O...#OO.\r\n...#...O#..O.#.OO.#.OO..O.#O.#.O.#...O#....O#.O#......OO.#....#..#..#..#....O.#....##...............\r\n.O.O#....#.#.....O...#.O#O#.......#.#O..OO.O...#....#.....O.#.#.#..#...#...##..O.O...#O..O.#..#O....\r\n.#......O..O#...O.O.##O..#.OOOO.O#O....O#...#O..OO.#.#O......#..O..O.OO#OOO#O#.O.......OO.....O...#O\r\nO##.O..OOO.#..O......#...#O#.O.O#..O.OO..#......O.O.O..O.O.OO..#....O.#O...O#.#..#..O.#...##O.O.....\r\n.#OO#....#.....#..OO.OO...##.O......OOO.#O..O#.O.O.........O#.O.#.#...#..##...#O.O..OO.O#.#..O..O.O.\r\n.O.....#.O#....O#.....#.O..O..O#..#..OOO#O....#OOOOO.#.#.........O#..O.#....#.#....O.#..##..#.......\r\n..O.#OO....#O.#...#O...#.O#..#.O....O.#..O....O#.....O.OO..OO.OO#.#..#..#O.O.#...O....OO...O.#..O..O\r\n.O.OO#...O#.OO....#.O....O.###...#..O.....O....#.O..O.#O.O.....#....#O#O...#..O...O........O...#....\r\n#...#...#..O..#.##.#.....O#..#O.##.O...O...#....O.O.O..O.O........O.O.O.....O..#.......#...O..O.#.#O\r\n#O...#...O.#....#.O.....OOO..O...OO#OO#.......#O.##...#.O#O#....#.....O#..OO.#.#.O.O..O.#OO.O.#..O..\r\n......O.......O.#.O.#.O...........O.O.OO#....#OO........O#.......OO.O..#O...#....O#..O....OO..O##...\r\n.##..O..#O...O.O....#O#..OO#O.#....#O.OO#O....#.....#...#.#OO#.OO.#.O.O.O.OO.#O.O.#.O....#O.O.O..O..\r\nO#..O#O##.O....O..#......O....#..O##O.O#...O...O...OO#..#OO...O##.#....O#.O..O.......#..#......#O..#\r\nO.OO..O..#.O..O#OO#O.....#O..O..#...#.OO.O..O...........O...O...OO##.#..O..#.#.OO.#.#...O.O......O.O\r\n.O.O##.O....#O.O...O#.#..O....#O.....O..O#OO....OO##.#.O..#O.O...O..O.O...#O.OO.........#.##OO#..#..\r\n..OO....O.....#....O.....O...OOO#...#.O.........O.O..OOO.###O.#.......#.#...O.OO.#..O.....#O.....#..\r\nO...##O...O..##..#.#...#.#O#.O...#.#.O..O....##......#...#.O..O...OO.#...OOO#OO...O.O#O..OO.O##O..O.\r\n..#.OO.#.##..O....#...OO.#O.......O.O#...O..#.#O..O.###O#.#.O.O...O.#O.#..#.O..O#O#..O.........#.#..\r\nO.#.O##.......OO#....O#.......O..O.....#.........O.O.....#O.......#O..#.O...#....O.#....#......O.O.#\r\n.OO.O...O.......#O#....#O#...#.........O..O.#.OO#.OO.O#...#O...O..#..O##O.#...O#..O.OO.O...#OO.##.#.\r\n...O.O...OOO.O......#..O...#.##.O..O..#...O.O...#.O.O..OO..OO..#....O.O#..#...O.OO.#.....#...OO#...#\r\n.#............#O.OO..O#.....O..#O.#O.##O....O.O....O..O#..O..O.#..O.#.O.#.O.#..#O.#.OO.O......##...O\r\n#.....O.#..O.O........O#O#OO..OO.....#.#....OO##......O.O.##..##.#.O...O.#.#O......O..##.#.#.#..#O..\r\n##.#.O..O...O..OO...O....O.O..O#...OO....OO#.#...#.#....OO#..........O..O...O...O........#..O##.#.#.\r\n..OO.#..#.OO..#O..#.O...OO.O...O....#..OO....#OO..#........#...O..........#..O...OO.O.......#.#..##.\r\n.#.#...#O.O.#.O..O.OO.OO#..OO#OOO#O....O..O#..OO.O..##..#.#....OOOOO#....OO..O....#..O..............\r\n...O#.OO......O.#.O.#.#O.OOO...#OO..#....#.O.O.O.......#...##...O...OOO..##...O....O...O.#...O.O...O\r\n..O...O..#.O.....#.#..##.......####...##.......O...O#.##....O.#..OO....#.#.O...##O.#O.###.OO#....O.O\r\n.O#..#....OO...O.O.......O#OO..O#.O.O..#......#..O.#..#O......OO.O...O.....O........O#.#O.#.#.##.O#.\r\n..O....O.#...#..##..O...#.O#..OO...O.......#OOO......#O..OO...O...#..O...##O.#...#.#.##...O...#.OO..\r\nO.#..#...O#OO.O#.O..O.....O.O..#.#.##....O.O..O......OO.O.#.....#....#.##...#...O..O........#......#\r\n.OO.OO.........#...#.#O...#..#..#.###O....#...OO#......#O.O..........#O...#.#.#O#..........#.O#...OO\r\n##.#..#O#OO.#.....O......#....O..#.O#..#.OO.........#.......#.#..#..O.O#OO.###.O.#.#O..##....O.O..O#\r\n#...O...O.......O#.O.#..#O#.O...O...O...O.O.#.O....O###..#.O..O.....O..OO#...O.#...#....O.#O..OO.O..\r\n#O...O...O.##..#.#OO.....#O.#..O....#O.O....O.....#.O.....#.O.O....#.......O.#.O..#.O.##....O..O..O#\r\nO..O.....#O..O...O........O..#.#..........##O#..#..O.#.#OOO..#..O...O..O..#.O....O...O...#...#...O..\r\n#...O.......O#..#.O#.O.....#....O#O......O..O.....#.....O...#...O...#O..#.O..#..#....O....##O#.....#\r\nO...O..#O#.OO..##..#.......O.........#......#...#..O.O..#..#O..O..O.OO......O#OO.#..O#....#.O.#.....\r\n.....#.OOO..OOO....O...#O....O.#.O.#.#O..#O.......O#..O.#O.#.#..#......O#O###..#.#.O..OO.O#.##.OO#.#\r\nO...#..O#.##O..#...#.....O...O.O............O#.....#.O....O#....O#.#O#O..O#.OO..........#.O.#OOO.O..\r\n......#..#...O..O....OO#.O...OO..O....O..##O#..O#..O..##.O..#....##OO.....#..O#.O....#O.#....##.O...\r\n.#..O.O..#..........O...O...O.#..O.#......O.O.....OO#..#...O.....O##..O.O..#.OO.#O.O....O...O..#..#.\r\n.OO.#..O......#........#.#.O...#..........O..O.O.......OO..##O.....#...O...#..#O###..O..O.OOOOO.#.O.\r\n.O..#..O..O...O..#O......OOO.O#..O#.#O...O#O.#...O....O..OO.#....#...O#................O.#O..O.#O..#\r\n......O..O...##..O..##.O.####..OO.O.......#.#O..O#..O#O.......#..O.....##........#..O..O.#...O....OO\r\n.....O.O.O.....O..OO..#O..O#.#OO....#O...#O#.#.OO.#..O...O.#.....#.#O#..O#...OO##.........##...##..#\r\n....O..OOOO..O.O...#.....#.#..OOO...#OO.O#..O..O....#O.......#.O..OOO......OO...#.O#............O#.O\r\n......O....#...#.#..O.O#.#...O..O.OO##.O..O#OO##...#.#..O.OO.........#..##O#...O.#..O.#OO.#O#...##O.\r\nO..##.O...O..#.O.O.O..O.........#..O...#..O.O.##O#.O..#.#.....#..#O#..#.OOO#.O..O...OO#.O...O#......\r\n.O.....O......O.......O#..O.OOOO..O..OO.O#.##.OO#O#.O......#...#.........O..O#...#O..#..#.O...O.#OO.\r\n#O.O...#..OO.#...O.O#....#..#...#OOO##.O.OO#.....#.O#.O..O.#O#O.O.O..........O#.O#.#O###O..#..#.#OO#\r\n#O###.O..O..O......#.O#.#....OO..O.O#....#...#...#.##...OO..O.#OO........O....O..O....OO......O..O.#\r\n.O#O..O...#OOO...O.O...#.O#......#......#O.....O.#.#.O.#....O#.#O..#...#..#...OO#.....OOO....OO.....\r\n..O.#.O....OO......O...O..##.O........#.O.#O.#...O...O.#.##OO.#O......O...O..O.O.O.##..O#.##.#.#O...\r\n.#OO#.#.O#O....O.O....OO#....##.....#.##O..O...OO.....#..O.#....O#.......O....OO.OOO.#...#..O.O.#.OO\r\n.O...O....#.O..O.#..#.........O.#O#.#...O..#O.O.O..O##.....OO..O.O..OO..O..#..#.#.O..#O..O.OO##....O\r\n.##...#O.O..OO..O..#.#O.O.OO.#..#.OOOO.....O...O.O.O#...O#.#.O.............O..O...#.#..........OO#.#\r\n.#....##O....##O..#.O.O..#..O##....#.#.OO........O.O#..#........#OO........O...#.OO..#.........#....\r\n.##OO..#O.#.O..OO.#...#O#.....O....O.#....#O..O#O.#.O..##.O.O.....#.#...#.O..OO....O....#.#.#.......\r\nO.O.O.#....#.OO.#...#...O..#.OO..#..O..#...O.OO.O...##...OO.O#O..O.OO.O##.....#..O#..#O....O.O#OO.#.\r\n.#.O....#.#....#..O.O....OO......O......O.#...O...#.O.O..#.#.....O..#O.O.O..OOO#.O#..O...O#..OO.....\r\n#.#O..#....#.....O.#....#......O.O..O.O.OO.O#...O.#.O.O...#....O...#..#...O.#.O..#.O...OO.#.#O###.OO\r\n..#..O..#O##..#.....O...#..O...OO..#.#.O.#.O.O.....O..O#O#..O......#...#O.O.OO..O............#....#.\r\n....O#....O#O###O.O..#.#..O.#.O.#.O....O........#O.OOO......O.OO....O.O.O.....##.O#....##O.#.OO..O.#\r\n..#.O...OO.#O.#..OO.##..#...O#..O#..#O.O..#......O.....##....O...O.O#OO#O.......O##OOO.OO.O...O.#..#\r\nO......#.O.....OO.OO.O...O.#O..O...O.#.#...#...O...#.OO.O.#.#OO.....#.O.#....OOO........##...##.##O.\r\n#O...#....#...##O.#......O#...#O..........##O..#.O.#O#..#...OO.O....O..##..#...#...#..O..O....O..O#.\r\n...OO....O#..O..#....O.#.#.....OO.#..#O..OO.#.#.#.#......O...O..#.#..##.....#...O.##.....O#.#..O#O..";
        private static List<string> _lines = Utilities.StringToLines(Input);
        private static List<char> _blockers = new List<char> { 'O', '#' };

        internal static int Part1()
        {
            var sum = 0;
            var grid = Utilities.StringsToGrid(_lines);
            var length = grid.GetLength(0);
            RollNorthOptimised(grid);
            
            for (int r = 0; r < length; r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r, c] == 'O')
                    {
                        var thisVal = length - r;
                        sum += thisVal;
                    }
                }
            }
            return sum;
        }
        
        internal static int Part2()
        {
            var sum = 0;
            var grid = Utilities.StringsToGrid(_lines);

            var snapshots = new List<char[,]> { };
            char[,] finalGrid = new char[grid.GetLength(0), grid.GetLength(1)];

            var numberofTimes = 1000000000;

            for (int i = 0; i < numberofTimes; i++)
            {
                RunOneCycle(grid);
                var found = false;
                // Find identical grids to determine cycle
                for (int j = 0; j < snapshots.Count; j++)
                {
                    if (Utilities.Compare2DArray(grid, snapshots[j]))
                    {
                        var cycleStart = j;
                        var cycleEnd = i;
                        var cycleLength = cycleEnd - cycleStart;
                        var remainder = (numberofTimes - cycleStart) % cycleLength;
                        finalGrid = snapshots[remainder + cycleStart - 1];
                        found = true;
                        break;
                    }
                }
                if (found) break;

                // Add to snapshots
                snapshots.Add(Utilities.DeepCopy2DArray(grid));
            }
            sum = Calculate(finalGrid);
            return sum;
        }

        private static int Calculate(char[,] grid)
        {
            var sum = 0;
            var length = grid.GetLength(0);
            for (int r = 0; r < grid.GetLength(0); r++)
            {
                for (int c = 0; c < grid.GetLength(1); c++)
                {
                    if (grid[r, c] == 'O')
                    {
                        var thisVal = length - r;
                        sum += thisVal;
                    }
                }
            }

            return sum;
        }

        internal static void RunOneCycle(char[,] grid)
        {
            RollNorthOptimised(grid);
            RollWestOptimised(grid);
            RollSouthOptimised(grid);
            RollEastOptimised(grid);
        }

        internal static void RollNorthOptimised(char[,] grid)
        {
            var numCols = grid.GetLength(1);
            for (int i = 0; i < numCols; i++)
            {
                var thisCol = new string(Utilities.GetCol(grid, i));
                var sorted = SortNorthOrWest(thisCol!).ToCharArray();
                Utilities.SetCol(grid, i, sorted);
            }
        }
        internal static void RollWestOptimised(char[,] grid)
        {
            var numRows = grid.GetLength(0);
            for (int i = 0; i < numRows; i++)
            {
                var thisRow = new string(Utilities.GetRow(grid, i));
                var sorted = SortNorthOrWest(thisRow!).ToCharArray();
                Utilities.SetRow(grid, i, sorted);
            }
        }

        internal static void RollSouthOptimised(char[,] grid)
        {
            var numCols = grid.GetLength(1);
            for (int i = 0; i < numCols; i++)
            {
                var thisCol = new string(Utilities.GetCol(grid, i));
                var sorted = SortSouthOrEast(thisCol!).ToCharArray();
                Utilities.SetCol(grid, i, sorted);
            }
        }
        internal static void RollEastOptimised(char[,] grid)
        {
            var numRows = grid.GetLength(0);
            for (int i = 0; i < numRows; i++)
            {
                var thisRow = new string(Utilities.GetRow(grid, i));
                var sorted = SortSouthOrEast(thisRow!).ToCharArray();
                Utilities.SetRow(grid, i, sorted);
            }
        }

        internal static string SortNorthOrWest(string line)
        {
            // Split into substrings
            var substrings = line.Split('#').ToList();

            // Sort
            for (int j = 0; j < substrings.Count(); j++)
            {
                var substring = substrings[j];
                substrings[j] = SortBoulders(substring, 'L');
            }
            return string.Join('#', substrings);
        }

        internal static string SortSouthOrEast(string line)
        {
            // Split into substrings
            var substrings = line.Split('#').ToList();

            // Sort
            for (int j = 0; j < substrings.Count(); j++)
            {
                var substring = substrings[j];
                substrings[j] = SortBoulders(substring, 'R');
            }
            return string.Join('#', substrings);
        }

        // Given a substring comprising of only 'O' and '.', sort these by given direction
        internal static string SortBoulders(string s, char dir)
        {
            if (dir == 'L')
            {
                return new string(s.OrderBy(c => c == 'O' ? 0 : 1).ToArray());
            }

            return new string(s.OrderBy(c => c == '.' ? 0 : 1).ToArray());
        }
    }
}
