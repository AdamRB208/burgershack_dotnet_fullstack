namespace burgershack_dotnet_fullstack.Models;

public class Side : RepoItem<int>
{
  public string Name { get; set; }
  public decimal Price { get; set; }
  public string ImgUrl { get; set; }
}