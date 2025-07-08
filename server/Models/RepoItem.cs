namespace burgershack_dotnet_fullstack.Models;

public abstract class RepoItem<T>
{
  public T Id { get; set; }
  public DateTime CreateAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  }