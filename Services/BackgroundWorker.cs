


namespace ThreadDemo.Services;

public class BackgroundWorker : IBackgroundWorker
{
    private volatile bool IsWorkerRunning = false;

    private readonly string _name;

    public BackgroundWorker(string uid)
    {
        _name = uid;
        Console.WriteLine("Task {0} created", uid);
    }

    public void Start()
    {
        IsWorkerRunning = true;

        int count = 0;
        while (IsWorkerRunning)
        {
            Console.WriteLine("Task {0} says Hello World {1}", _name, count);
            count++;

            Thread.Sleep(500);
        }

        Console.WriteLine("Completed task {0}", _name);
    }

    public void Stop()
    {
        IsWorkerRunning = false;
    }
}
