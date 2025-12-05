using aoc.Shared;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace aoc._2024
{
    internal static class Day8
    {
        private static readonly string TestInput = "............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............";
        private static readonly string Input = ".............O.....E...M.................S........\r\n....................................S.........D...\r\n......u......................................V....\r\n................u.E......M..............V.........\r\n...e...............................a..............\r\n.................v..........a6....................\r\n...............ue...............6...............V.\r\n..........e..E..........M......................V..\r\n............................M.............F.a.....\r\n.............................a..........i.........\r\n....................n.............A......F........\r\n.......e............N.........6...........m.......\r\n........v..............D.....i....................\r\n........A.v......D...........................F....\r\n...................v..........S....q.......m......\r\n................n.......2......m..................\r\n.I..................2...C.....i...............f...\r\n.....................2.S.........i................\r\n........k...0.....................................\r\n......I..........k.......................1........\r\n..............D....k..N....1......................\r\n.....A.................n..C.......................\r\n...........................2..1........fm....A....\r\n.....I........k...7............................f..\r\n....I..........n.........N...d...C................\r\n.............z...................W................\r\n...Z.................................W.........y..\r\n............z....w.....................5..........\r\n.................z....d...4......Q.U......5.......\r\n....................d...........F.......fC.U......\r\n...................w........................U.....\r\n.............8......w..N..................U.......\r\n.7.................4...3.............5............\r\n...............3.......s..1.54..........W.........\r\n.........0Z.....w.............................c...\r\n.Z...................................o............\r\n................z....8...........K......Q.9....c..\r\n............P.........4dY...s9...........O..p....u\r\n.....................s..........o...............W.\r\n....................3.......................O.....\r\n........................s..............p......O...\r\n...................c.............P..9..K.....p....\r\n................Y....P3.....7..9..................\r\n..................8.......o...........K...c.......\r\n.......Y........8.................................\r\n....Z7.....................y.q......Q.............\r\n..............................y...................\r\n......0.....................y..................Q..\r\n....................P6............qo......p.......\r\n......................................q...........";
        private static List<string> _lines = Utilities.StringToLines(Input);

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

        internal static long Part1()
        {
            var antinodes = new List<Coords>();
            var lookup = new Dictionary<char, List<Coords>>();

            // Create map of nodes
            for (int row = 0; row < _lines.Count; row++)
            {
                for (int col = 0; col < _lines[row].Length; col++)
                {
                    var thisChar = _lines[row][col];
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
            uniqueAntinodes.RemoveWhere(n => n.Row > _lines.Count - 1 || n.Col > _lines[0].Length - 1 || n.Row < 0 || n.Col < 0);
            return uniqueAntinodes.Count;
        }

        internal static long Part2()
        {
            int result = 0;
            foreach (var line in _lines)
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
