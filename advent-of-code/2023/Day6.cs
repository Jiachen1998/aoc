namespace aoc._2023
{
    internal static class Day6
    {
        private static readonly string TestInput = "Time:      7  15   30\r\nDistance:  9  40  200";
        private static readonly string Input = "Time:        46     82     84     79\r\nDistance:   347   1522   1406   1471";
        private static List<string> _lines = Utilities.StringToLines(Input);

        private static List<int> _times = new List<int>();
        private static List<int> _distances = new List<int>();

        private static long _time2 = 0;
        private static long _dist2 = 0;

        internal static int Part1()
        {
            ReadInput();
            var count = 1;
            for (int i = 0; i < _times.Count; i++)
            {
                var target = _distances[i];
                var raceLength = _times[i];

                var localCount = 0;

                for (int j = 0; j < raceLength; j++)
                {
                    var dist = j * (raceLength - j);
                    if (dist > target) localCount++;
                }

                count *= localCount;
            }
            return count;
        }

        internal static int Part2()
        {

            ReadInputPart2();
            var count = 0;
            var target = _dist2;
            var raceLength = _time2;

            for (int j = 0; j < raceLength; j++)
            {
                var dist = j * (raceLength - j);
                if (dist > target) count++;
            }
            return count;
        }

        private static void ReadInput()
        {
            var timeLine = _lines[0].Substring(_lines[0].IndexOf(':') + 1);
            _times = timeLine.Split(' ').Where(s => s != "").Select(i => int.Parse(i)).ToList();

            var distLine = _lines[1].Substring(_lines[1].IndexOf(':') + 1);
            _distances = distLine.Split(' ').Where(s => s != "").Select(i => int.Parse(i)).ToList();
        }

        private static void ReadInputPart2()
        {
            var timeLine = _lines[0].Substring(_lines[0].IndexOf(':') + 1);
            _time2 = long.Parse(timeLine.Replace(" ", ""));

            var distLine = _lines[1].Substring(_lines[1].IndexOf(':') + 1);
            _dist2 = long.Parse(distLine.Replace(" ", ""));
        }
    }
}
