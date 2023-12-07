namespace aoc._2022
{
    internal class Day12
    {
        public void Day12Part1()
        {
            var lines = Utilities.ReadInput(12);
            var heightList = new List<List<int>>();
            var alphabetDict = CreateAlphabetDict();
            Tuple<int, int> start;
            Tuple<int, int> end;

            for (int i = 0; i < lines.Count; i++)
            {
                var row = lines[i].ToCharArray().ToList();
                List<int> rowHeights = new List<int>();
                for (int j = 0; j < row.Count; j++)
                {
                    rowHeights.Add(alphabetDict[row[j]]);
                    if (rowHeights[j] == 'S')
                    {
                        start = Tuple.Create(i, j);
                    }
                    else if (rowHeights[j] == 'E')
                    {
                        end = Tuple.Create(i, j);
                    }
                }
                heightList.Add(rowHeights);
            }

            // var length = HillClimbingAlgo(heightList, start, end);

            int HillClimbingAlgo(List<List<int>> heights, Tuple<int, int> start, Tuple<int, int> end)
            {
                var destReached = false;
                var current = start;
                int[] dx = { -1, 0, 1, 0 };
                int[] dy = { 0, 1, 0, -1 };
                int pathLength = 0;

                while (!destReached)
                {
                    var next = current;
                    var currentHeight = GetHeightValue(current, heights);

                    // Loop through four directions, left, top, right, bot
                    for (int i = 0; i < 4; i++)
                    {
                        // Coords of direction
                        var temp = Tuple.Create(current.Item1 + dx[i], current.Item2 + dy[i]);

                        // Only check if in map
                        if (NumInRange(temp.Item1, 0, heights[0].Count)
                            && NumInRange(temp.Item2, 0, heights.Count))
                        {
                            if (GetHeightValue(temp, heights) > currentHeight)
                            {

                            }
                        }
                    }
                }
                return pathLength;
            }

            int GetHeightValue(Tuple<int, int> coords, List<List<int>> heightMap)
            {
                return heightMap[coords.Item1][coords.Item2];
            }
        }

        private static Dictionary<char, int> CreateAlphabetDict()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (char c = 'a'; c <= 'z'; c++)
            {
                dict.Add(c, c - 96);
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                dict.Add(c, c - 38); // 'A' starts with value of 27
            }
            return dict;
        }

        private static bool NumInRange(int num, int inclusiveLowerBound, int inclusiveUpperBound)
        {
            return num >= inclusiveLowerBound && num <= inclusiveUpperBound;
        }
    }
}
