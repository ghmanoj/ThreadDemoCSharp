
namespace ThreadDemo.Services;


public interface ITaskRunnerService
{
    string Start();

    void Stop(string uid);

    List<string> GetAllTasks();
}
