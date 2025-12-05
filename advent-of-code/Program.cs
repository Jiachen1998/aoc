using System.Diagnostics;
using System.Reflection;

if (args.Length < 3)
{
    Console.WriteLine("Usage: <year> <day> <part> [--test]");
    Console.WriteLine("Example: 2025 1 1 --test");
    return 1;
}

if (!int.TryParse(args[0], out int year))
{
    Console.WriteLine($"Invalid year: {args[0]}");
    return 1;
}

if (!int.TryParse(args[1], out int day))
{
    Console.WriteLine($"Invalid day: {args[1]}");
    return 1;
}

if (!int.TryParse(args[2], out int part) || (part != 1 && part != 2))
{
    Console.WriteLine($"Invalid part: {args[2]}. Must be 1 or 2.");
    return 1;
}

bool useTest = args.Contains("--test");

var clock = new Stopwatch();
clock.Start();

try
{
    // Dynamically find and call the day's part method using reflection
    string namespaceName = $"aoc._{year}";
    string className = $"Day{day}";
    string methodName = $"Part{part}";
    
    // Get the type for the day class
    Type? dayType = Type.GetType($"{namespaceName}.{className}");
    
    if (dayType == null)
    {
        Console.WriteLine($"Day {day} not found for year {year}. Make sure the class {namespaceName}.{className} exists.");
        return 1;
    }
    
    // Get the Part method
    MethodInfo? method = dayType.GetMethod(methodName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
    
    if (method == null)
    {
        Console.WriteLine($"Method {methodName} not found in {className}.");
        return 1;
    }
    
    // Invoke the method with useTest parameter
    object? result = method.Invoke(null, new object[] { useTest });
    
    if (result == null)
    {
        Console.WriteLine($"Method {methodName} returned null.");
        return 1;
    }
    
    clock.Stop();
    
    Console.WriteLine($"Answer: {result}");
    Console.WriteLine($"Time: {clock.ElapsedMilliseconds}ms");
    return 0;
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    if (ex.InnerException != null)
    {
        Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
    }
    return 1;
}