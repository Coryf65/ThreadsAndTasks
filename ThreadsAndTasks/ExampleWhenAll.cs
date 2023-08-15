using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

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
        Logger.Info(MethodBase.GetCurrentMethod(),"Starting Example1, the one by one way...");
        Stopwatch stopWatch = new();
        List<string> names = new() {"Felipe", "Claudia", "Robert", "Rajan"};

        Logger.Info(MethodBase.GetCurrentMethod(),"it is inefficient going one by one");
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
        Logger.Info(MethodBase.GetCurrentMethod(),"Starting Example2, the better example...");
        Stopwatch stopWatch = new();
        List<string> names = new() {"Felipe", "Claudia", "Robert", "Rajan"};

        Logger.Info(MethodBase.GetCurrentMethod(),"GO!");
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
        Logger.Info(MethodBase.GetCurrentMethod(),$"Method 1: {name}");
    }
    
    private async Task Method2(string name)
    {
        await Task.Delay(500);
        Logger.Info(MethodBase.GetCurrentMethod(),$"Method 2: {name}");
    }
    
    private async Task Method3(string name)
    {
        await Task.Delay(500);
        Logger.Info(MethodBase.GetCurrentMethod(),$"Method 3: {name}");
    }
    
    private async Task Method4(string name)
    {
        await Task.Delay(500);
        Logger.Info(MethodBase.GetCurrentMethod(),$"Method 4: {name}");
    }
    
    private void WriteTime(int elapsedSeconds, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Logger.Info(MethodBase.GetCurrentMethod(),$"Duration: {elapsedSeconds} seconds");
        Console.ForegroundColor = ConsoleColor.White;
    }
}