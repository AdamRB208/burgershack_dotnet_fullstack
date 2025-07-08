namespace burgershack_dotnet_fullstack.Repositories;

public class SidesRepository
{

  public SidesRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;
}