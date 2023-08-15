using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ThreadsAndTasks;

public static class Logger
{
    public static void Info(MethodBase methodBase, string message)
    {
        //Console.WriteLine($"{new StackFrame(1).GetMethod().Name}.{message}");
        
        // MethodBase m = MethodBase.GetCurrentMethod();
        Console.WriteLine("{0}.{1} : {2}", methodBase.ReflectedType.Name, methodBase.Name, message);
        
        // Class.Method.message
        //Console.WriteLine($"{className}.{methodName}.{message}");
    }
}