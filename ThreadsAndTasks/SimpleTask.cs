namespace ThreadsAndTasks;

public class SimpleTask
{
    public SimpleTask()
    {
        Console.WriteLine("Creating a task...");
        Task task1 = new(() => Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId}."));
        Console.WriteLine("Starting task now");
        task1.Start();
        task1.Wait();
    }
}