﻿namespace aoc._2023
{
    internal static class Day11
    {
        private static readonly string TestInput = "...#......\r\n.......#..\r\n#.........\r\n..........\r\n......#...\r\n.#........\r\n.........#\r\n..........\r\n.......#..\r\n#...#.....";
        private static readonly string Input = ".....................................................................................#......#...............................................\r\n..#.....#.................................................................#........................#........................................\r\n...............................#...............................................................................#.....#......................\r\n.................................................#.............#...............................#...................................#........\r\n..............#......#.................#...............#............#.............#..........................................#..............\r\n.........................................................................................#.................#...............................#\r\n.#..........................................................................................................................................\r\n..........................#......#............................................#......#.................................#....................\r\n.................................................................................................#..........................................\r\n.........................................#..........#..........#............................................................#...............\r\n......#.....#......#..........................#........................#....................................................................\r\n....................................#.........................................................................#..........................#..\r\n..................................................................................#.........................................................\r\n...................................................................................................................#........................\r\n.................................................................#........................................#.................................\r\n.............................#..............................#..........................#.......#............................................\r\n..........................................#.....#.............................#.............................................................\r\n#..................#..................................................................................................................#.....\r\n....................................#...................#..........................#...........................#..............#.............\r\n........#................#...................#.............................................................................................#\r\n...............................#....................#...........................................#...........................................\r\n.......................................#..............................................#.....................................................\r\n........................................................................#........#...........................#..............................\r\n..................................#........#...................#........................................#.........#.................#.......\r\n#................#........................................................................................................#.................\r\n.........#.......................................#...............................................#.............................#........#...\r\n...............................................................................................................#............................\r\n.........................................................................................#..................................................\r\n...........................................................#..................................#..........#...........................#......\r\n......#.........................#..........................................................................................#................\r\n....................#.....................#.......#...............................#.................................#.......................\r\n..........................#..............................................#..................................................................\r\n..........#..........................#.......................#...................................#..............#..............#...........#\r\n......................................................#.....................................................................................\r\n............................................................................................................................................\r\n#...............................................#................#............................#.............................................\r\n..................#......................#............................#................................#................................#...\r\n............................................................................................................................................\r\n....................................................#....................................#.............................#....................\r\n..............#...................#................................#..........#..............................#.............................#\r\n............................#...............................................................................................#...............\r\n....#.................#.....................................#..........#............................................................#.......\r\n......................................................#.....................................................................................\r\n...........#..............................#.................................................#..........#.................#..................\r\n.................................#..............#................#..........#.......#.......................................................\r\n...................................................................................................................#..............#.........\r\n#...........................................................................................................#...............................\r\n........#.......#............................................................................................................#..............\r\n............................#.....................#..........#......................................#.....................................#.\r\n.....................................#.................................................#........................#...........................\r\n.........................................................................................................................#...........#......\r\n.......................#.............................#........................#.............................................................\r\n..............#...............................#.................#..................#........#...............................................\r\n...#......................................................................#.................................#..............................#\r\n...................#..................#.............................................................................#........#..............\r\n............................................................................................................................................\r\n.........................#.........................#........................................................................................\r\n......#......#.............................................#.............................#............#.....................................\r\n.................................#......................................#...................................................................\r\n.........................................#........................#..............................#.................#..............#.........\r\n............................................................................................................................................\r\n......................................................#.................................................#..............#..................#.\r\n......................#......#...............#...................................#............................#.............................\r\n....#...........#.................#............................................................#...............................#............\r\n..........................................................................#..........................#......................................\r\n..........................................#................................................#...............................#............#...\r\n................................................................................................................#...........................\r\n..........#....................................#...................................................................................#........\r\n................................#....................#..............................................................#.......................\r\n......#.......................................................#...............................#.............................................\r\n#.......................#.....................................................................................................#.............\r\n.................#...................#...........................................#..........................#...............................\r\n.....................................................................#....................#.................................................\r\n..............................#.................#.......#.........................................#.........................................\r\n..#........................................................................#....................................#.........#.................\r\n...........#............................#..........................................#.............................................#..........\r\n......#.............................................................................................................#.....................#.\r\n........................................................................................................#...................................\r\n..............#...................#.........#...............................................................................................\r\n........................................................#.............#..........#.....#..........#............................#............\r\n.........#......................................................#...........................#...............................................\r\n.........................................#...................................#.................................#............................\r\n............................................................................................................................................\r\n................#...................................................................#.................#..................#..................\r\n.................................#..........................#.............#....................#................................#..........#\r\n...#........................#.........................................................................................................#.....\r\n.................................................#......................................#.....................#......#......................\r\n...........................................#.........................#........#.............................................................\r\n........#......#...................................................................................................................#.....#..\r\n.#..................#..................................#.........#..........................................................................\r\n..................................#.....#.................................#.................................................................\r\n...................................................#.................................#......................................................\r\n............................................................#...............................................................................\r\n.............................................#......................#..........#............#.........................#......#..............\r\n................................#...................................................................#.......................................\r\n.....................................................#..................#......................................#............................\r\n...#......................#.....................................................................................................#...........\r\n...........#...........................................................................#..............................................#.....\r\n................#..................................................#..............................................#.........................\r\n.......................#......................................................................#.............................................\r\n................................#........#.........#.....................#.....#......................#.....................................\r\n.#..........................................................................................................................................\r\n........................................................#................................#...................#..................#...........\r\n.....................................#........#.................................................#.......................................#...\r\n.........#...........#......................................................................................................................\r\n....................................................#.............................................................#.................#.......\r\n.............#............#........................................#.............#.....................#...................#...............#\r\n..................#....................#.................................#.............#....................................................\r\n................................................#...........................................................................................\r\n.......................#...............................................................................................#....................\r\n....#..........................................................#.....#..............#...........................................#...........\r\n...............................................................................................#..................#.......................#.\r\n.........#...................#............................................#.................................................................\r\n.............................................................................................................#..............#......#........\r\n...........................................................................................#................................................\r\n.#...........................................................#..............................................................................\r\n..............#..............................#........................................#.............#.......................................\r\n....................................#..............#..............#.........#.............................#.............#.............#.....\r\n....................#............................................................................................#..........................\r\n.........................................................................................#..................................................\r\n...........#............................#................#....................................................................#.............\r\n.....#......................................................................................................#...............................\r\n..................................#................................................#........#.............................................#.\r\n.#................#......#...........................................................................#......................................\r\n..............................................#.......................#................#............................................#.......\r\n.........#............................#........................#..........................................#.....#......#....................\r\n..............................................................................................#.............................................\r\n........................................................................................................................................#...\r\n..........................#........................#...............#................................#............................#..........\r\n..#........................................#............#............................................................#......................\r\n...............................#.....#........................................#.......#......................................#..............\r\n.......................................................................................................#....................................\r\n.....................................................#..............................................................................#.......\r\n........#......................................#...........................#.............................................#.................#\r\n...................#.....#......................................#.............................#.............................................\r\n............#.........................#......................................................................#.......#.................#....\r\n..............................#...................................................#.........................................................\r\n............................................#.........................................................#.....................................\r\n.......#..........................#................#.....#.............#....................................................................\r\n..................#.........................................................#.............#.......................................#.........";
        private static List<string> _lines = Utilities.StringToLines(Input);

        internal static long Part1()
        {
            var expanded = ExpandUniverse();
            var galaxies = GetGalaxies(expanded, 1);
            return CalculateDistance(galaxies);
        }

        internal static long Part2()
        {
            var expanded = ExpandUniverse();
            var galaxies = GetGalaxies(expanded, 1000000);
            return CalculateDistance(galaxies);
        }

        internal static List<string> ExpandUniverse()
        {
            var expanded = _lines;

            // Expand rows
            for (int row = _lines.Count - 1; row >= 0; row--)
            {
                var line = _lines[row];
                if (!line.Contains('#'))
                    expanded[row] = Utilities.RepeatString("@", line.Length);
            }

            // Expand columns
            for (int col = _lines[0].Length - 1; col >= 0; col--)
            {
                var column = _lines.Select(line => line[col]).ToList();
                if (!column.Contains('#'))
                {
                    for (int row = 0; row < expanded.Count; row++)
                    {
                        var chars = expanded[row].ToCharArray();
                        chars[col] = '@';
                        expanded[row] = new string(chars);
                    }
                }
            }
            return expanded;
        }

        internal static List<(long x, long y)> GetGalaxies(List<string> expanded, int expansionRate)
        {
            var galaxies = new List<(long x, long y)>();

            var rowPos = 0;
            for (int row = 0; row < expanded.Count; row++)
            {
                // Expansion row
                if (expanded[row].Count(c => c == '@') == expanded[row].Length) 
                {
                    rowPos += expansionRate;
                    continue;
                }
                var colPos = 0;
                for (int col = 0; col < expanded[0].Length; col++)
                {
                    // Expansion col
                    if (expanded[row][col] == '@') 
                    {
                        colPos += expansionRate;
                        continue;
                    }
                    if (expanded[row][col] == '#')
                    {
                        galaxies.Add((colPos, rowPos));
                    }
                    colPos++;
                }
                rowPos++;
            }
            return galaxies;
        }

        internal static long CalculateDistance(List<(long x, long y)> galaxies)
        {
            long sum = 0;
            for (int start = 0; start < galaxies.Count - 1; start++)
            {
                for (int end = start + 1; end < galaxies.Count; end++)
                {
                    sum += Utilities.CalculateManhattanDistance(galaxies[start], galaxies[end]);
                }
            }

            return sum;
        }
    }
}