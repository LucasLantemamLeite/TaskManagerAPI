using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TaskManager.Models;

public class TaskItem
{
    [Key]
    public int TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } = "";
    public bool Done { get; set; } = false;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? DeadLine { get; set; }
    public DateTime? CompletionDate { get; set; }
    public int UserId { get; set; }

    [JsonIgnore]
    public UserAccount? UserAccount { get; set; }

    public TaskItem() { }

}