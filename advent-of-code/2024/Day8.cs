using aoc.Shared;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace aoc._2024
{
    internal static class Day8
    {

        public struct Coords
        {
            public int Row { get; set; }
            public int Col { get; set; }

            public Coords(int row, int col)
            {
                Row = row;
                Col = col;
            }
        }

        internal static long Part1(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 8, useTest);
            List<string> lines = Utilities.StringToLines(input);

            var antinodes = new List<Coords>();
            var lookup = new Dictionary<char, List<Coords>>();

            // Create map of nodes
            for (int row = 0; row < lines.Count; row++)
            {
                for (int col = 0; col < lines[row].Length; col++)
                {
                    var thisChar = lines[row][col];
                    if (thisChar != '.')
                    {
                        if (lookup.Keys.Contains(thisChar))
                        {
                            lookup[thisChar].Add(new Coords(row, col));
                        }
                        else
                        {
                            lookup[thisChar] = new List<Coords> { new Coords(row, col) };
                        }
                    }
                }
            }

            // Calculate antinodes for each letter
            foreach (var key in lookup.Keys)
            {
                var thisAntinodes = CalculateAllAntinodes(lookup[key]);
                antinodes.AddRange(thisAntinodes);
            }

            // Create unique set
            var uniqueAntinodes = antinodes.ToHashSet();

            // Apply map boundaries
            uniqueAntinodes.RemoveWhere(n => n.Row > lines.Count - 1 || n.Col > lines[0].Length - 1 || n.Row < 0 || n.Col < 0);
            return uniqueAntinodes.Count;
        }

        internal static long Part2(bool useTest = false)
        {
            string input = Utilities.ReadInputFile(2024, 8, useTest);
            List<string> lines = Utilities.StringToLines(input);

            int result = 0;
            foreach (var line in lines)
            {
                // TODO
            }
            return result;
        }

        /// <summary>
        ///  Given a list of nodes, calculates all antinodes.
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        internal static List<Coords> CalculateAllAntinodes(List<Coords> nodes)
        {
            var antinodes = new List<Coords>();
            foreach (var firstNode in nodes)
            {
                var otherNodes = nodes.Except(new [] { firstNode });
                foreach (var secondNode in otherNodes)
                {
                    antinodes.AddRange(CalculateAntinodePair(firstNode, secondNode));
                }
            }
            return antinodes;
        }

        internal static List<Coords> CalculateAntinodePair(Coords first, Coords second)
        {
            // Calculate delta from first to second
            var rowDelta = first.Row - second.Row;
            var colDelta = first.Col - second.Col;

            var firstAnti = new Coords(first.Row + rowDelta, first.Col + colDelta);
            var secondAnti = new Coords(second.Row - rowDelta, second.Col - colDelta);

            return new List<Coords> { firstAnti, secondAnti };
        }
    }
}
