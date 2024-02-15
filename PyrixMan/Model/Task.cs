namespace PyrixMan.Model;

public record Task(string Id, string Title, string Description, TaskStatus Status, string UserId);