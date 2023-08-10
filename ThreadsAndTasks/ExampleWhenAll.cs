using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ThreadsAndTasks;

public class ExampleWhenAll
{
    public ExampleWhenAll()
    {
        Task.Run(() => Example1());
        Task.Run(() => Example2());
    }
    
    private async Task Example1()
    {
        Console.WriteLine("Starting Example1, the one by one way...");
        Stopwatch stopWatch = new();
        List<string> names = new() {"Felipe", "Claudia", "Robert", "Rajan"};

        Console.WriteLine("it is inefficient going one by one");
        stopWatch.Start();

        foreach (var name in names)
        {
            await Method1(name);
            await Method2(name);
            await Method3(name);
            await Method4(name);
        }
        
        stopWatch.Stop();
        WriteTime(stopWatch.Elapsed.Seconds, ConsoleColor.Yellow);
    }
    
    private async Task Example2()
    {
        Console.WriteLine("Starting Example2, the better example...");
        Stopwatch stopWatch = new();
        List<string> names = new() {"Felipe", "Claudia", "Robert", "Rajan"};

        Console.WriteLine("GO!");
        stopWatch.Start();

        // validate each name in our list
        var validations = names.Select(name => Validate(name));
        
        // run on each name on our order
        await Task.WhenAll(validations);
        
        stopWatch.Stop();
        WriteTime(stopWatch.Elapsed.Seconds, ConsoleColor.Yellow);
    }
    
    async Task Validate(string name)
    {
        await Method1(name);
        await Method2(name);
        await Method3(name);
        await Method4(name);
    }

    private async Task Method1(string name)
    {
        await Task.Delay(500);
        Console.WriteLine($"Method 1: {name}");
    }
    
    private async Task Method2(string name)
    {
        await Task.Delay(500);
        Console.WriteLine($"Method 2: {name}");
    }
    
    private async Task Method3(string name)
    {
        await Task.Delay(500);
        Console.WriteLine($"Method 3: {name}");
    }
    
    private async Task Method4(string name)
    {
        await Task.Delay(500);
        Console.WriteLine($"Method 4: {name}");
    }
    
    private void WriteTime(int elapsedSeconds, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"Duration: {elapsedSeconds} seconds");
        Console.ForegroundColor = ConsoleColor.White;
    }
}