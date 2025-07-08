namespace burgershack_dotnet_fullstack.Models;

public class Burger : RepoItem<int>
{
  public string Name { get; set; }
  public decimal Price { get; set; }
}