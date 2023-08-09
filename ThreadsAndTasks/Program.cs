// See https://aka.ms/new-console-template for more information

Console.WriteLine("Checking out threading and tasks");

Task task1 = new(() => Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId}."));
task1.Start();
task1.Wait()