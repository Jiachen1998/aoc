using System.Diagnostics;

var clock = new Stopwatch();

clock.Start();
Console.WriteLine($"Answer: {aoc._2023.Day7.Part2()}");
clock.Stop();

Console.WriteLine($"Time: {clock.ElapsedMilliseconds}ms");