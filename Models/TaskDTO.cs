using System.Text.Json.Serialization;

namespace ThreadDemo.Models;

public class TaskDTO
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("task_list")]
    public List<string>? TaskList { get; set; }
}
