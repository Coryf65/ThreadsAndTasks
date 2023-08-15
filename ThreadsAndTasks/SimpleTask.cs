using System.Reflection;

namespace ThreadsAndTasks;

public class SimpleTask
{
    public SimpleTask()
    {
        Logger.Info(MethodBase.GetCurrentMethod(),"Creating a task...");
        Task task1 = new(() => Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId}."));
        Logger.Info(MethodBase.GetCurrentMethod(),"Starting task now");
        task1.Start();
        task1.Wait();
    }
}