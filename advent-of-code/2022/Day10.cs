namespace aoc._2022
{
    internal class Day10
    {
        public void Day10Part1()
        {
            var lines = Utilities.ReadInput(10);
            int signal = 1;
            int cycles = 0;
            var checks = new List<int>() { 20, 60, 100, 140, 180, 220 };
            var strengths = new List<int>();

            foreach (var line in lines)
            {
                var input = line.Split();
                if (input[0] == "noop")
                {
                    cycles += 1;
                    CheckSignal();
                }
                else if (input[0] == "addx")
                {
                    cycles += 1;
                    CheckSignal();

                    cycles += 1;
                    CheckSignal();
                    signal += int.Parse(input[1]);

                }
                Console.WriteLine("Cycles: {cycles}\t Signal: {signal}\t Strengths: {strengths}", cycles, signal, strengths);
            }

            Console.WriteLine($"Day 10 Part 1: {strengths.Sum()}");

            void CheckSignal()
            {
                if (checks.Contains(cycles))
                {
                    strengths.Add(checks.First() * signal);
                    checks.RemoveAt(0);
                }
            }
        }

        public void Day10Part2()
        {
            var lines = Utilities.ReadInput(10);
            int signal = 1;
            int cycles = 0;
            char[] array = new char[240];

            // For each line, if the cycles is within 1 of the signal, than that cycle is lit, otherwise not
            foreach (var line in lines)
            {
                var input = line.Split();
                if (input[0] == "noop")
                {
                    CheckImage();
                    cycles += 1;
                }
                else if (input[0] == "addx")
                {
                    CheckImage();
                    cycles += 1;

                    CheckImage();
                    cycles += 1;

                    signal += int.Parse(input[1]);
                }
                Console.WriteLine("Cycles: {cycles}\t Signal: {signal}", cycles, signal);
            }
            Console.WriteLine(new string(array));

            Console.WriteLine($"Day 10 Part 2:");
            for (int i = 0; i < (array.Length / 40); i++)
            {
                var row = new char[40];
                Array.Copy(array, i * 40, row, 0, 40);
                Console.WriteLine(new string(row));
            }

            void CheckImage()
            {
                var spritePos = cycles % 40;
                if (Math.Abs(spritePos - signal) <= 1)
                {
                    array[cycles] = '@';
                }
                else
                {
                    array[cycles] = '.';
                }
            }
        }
    }
}
