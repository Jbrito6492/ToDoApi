namespace TodoApi;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string? DueDate { get; set; }
    public bool IsComplete { get; set; }
}