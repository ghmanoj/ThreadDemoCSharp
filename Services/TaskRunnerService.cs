
namespace ThreadDemo.Services;



public class TaskRunnerService : ITaskRunnerService
{
    private readonly Dictionary<string, IBackgroundWorker> _workerMap;

    public TaskRunnerService()
    {
        _workerMap = new Dictionary<string, IBackgroundWorker>();
    }

    ~TaskRunnerService()
    {
        Console.WriteLine("Cleaning up the running workers");

        // cleanup all things..
        foreach(KeyValuePair<string, IBackgroundWorker> kvp in _workerMap)
        {
            _workerMap[kvp.Key].Stop();
        }
    }

    public string Start()
    {
        string uid = Guid.NewGuid().ToString();

        Object lk = new Object();

        lock (lk)
        {
            if (_workerMap.ContainsKey(uid))
            {
                Console.WriteLine("Its strange but the map already contains the UID: {0}", uid);
                return uid;
            }

            IBackgroundWorker worker = new BackgroundWorker(uid);
            Thread bgThread = new Thread(new ThreadStart(worker.Start));
            bgThread.Start();

            _workerMap.Add(uid, worker);
        }

        return uid;
    }

    public void Stop(string uid)
    {
        Object lk = new Object();

        lock (lk)
        {
            if (_workerMap.ContainsKey(uid))
            {
                IBackgroundWorker worker = _workerMap[uid];
                _workerMap.Remove(uid);

                worker.Stop();
            }
        }
    }


    public List<string> GetAllTasks()
    {
        return _workerMap.Keys.ToList();
    }
}
