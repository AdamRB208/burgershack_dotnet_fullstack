namespace burgershack_dotnet_fullstack.Repositories;

public class BurgersRepository
{

  public BurgersRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  
}