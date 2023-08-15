using System.Reflection;

namespace ThreadsAndTasks;

public class ThreadsExample
{
    public ThreadsExample()
    {
        Logger.Info(MethodBase.GetCurrentMethod(),"Before the first Thread");
        
        new Thread(() =>
        {
            Thread.Sleep(500);
            Logger.Info(MethodBase.GetCurrentMethod(),"Inside first thread");
        }).Start();

        Logger.Info(MethodBase.GetCurrentMethod(),"after the thread");

        Logger.Info(MethodBase.GetCurrentMethod(),"sleep for 1 second");
        Thread.Sleep(1000);
    }
}