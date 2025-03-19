using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class UserAccount
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    private string _email;
    public string Email { get => _email; set { _email = value?.ToLower(); } }
    public string _phoneNumber;
    public string PhoneNumber { get => _phoneNumber; set { _phoneNumber = value.Replace(" ", "").Replace("-", ""); } }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime BirthDate { get; set; }
    public bool Active { get; set; } = true;
    public List<TaskItem> UserTasks { get; set; } = new();

    public UserAccount() { }

}