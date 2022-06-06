using Microsoft.AspNetCore.Mvc;
using ThreadDemo.Services;
using ThreadDemo.Models;

namespace ThreadDemo.Controllers;

[Route("/tasks")]
[ApiController]
public class TaskController : Controller
{

    private readonly ITaskRunnerService _taskRunnerService;
    public TaskController(ITaskRunnerService taskRunnerService)
    {
        _taskRunnerService = taskRunnerService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var map = new Dictionary<string, List<string>>();
        List<string> allTasks = _taskRunnerService.GetAllTasks();

        var taskDTO = new TaskDTO
        {
            Count = allTasks.Count(),
            TaskList = allTasks
        };

        return Ok(taskDTO);
    }

    [HttpPost]
    public IActionResult StartRun()
    {
        _taskRunnerService.Start();
        return Ok("started");
    }

    [HttpDelete("{id}")]
    public IActionResult StopRun(string id)
    {
        Console.WriteLine("Trying to stop {0}", id);

        _taskRunnerService.Stop(id);

        return Ok("stopped");
    }

    [HttpPut("terminate")]
    public IActionResult Terminate()
    {
        var taskUidList = _taskRunnerService.GetAllTasks();
        foreach (string id in taskUidList)
        {
            _taskRunnerService.Stop(id);
        }
        return Ok(taskUidList);
    }
}
