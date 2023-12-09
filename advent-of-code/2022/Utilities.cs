namespace aoc._2022
{
    internal static class Utilities
    {
        public static List<string> ReadInput(int day)
        {
            var path = $@"C:\Users\jiach\Documents\GitRepos\Visual Studio\Playground\aoc-2022\aoc-2022\Inputs\Day{day}.txt";
            var lines = File.ReadAllLines(path).ToList();
            return lines;
        }
    }
}
