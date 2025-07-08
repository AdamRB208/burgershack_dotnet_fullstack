

namespace burgershack_dotnet_fullstack.Repositories;

public class SidesRepository
{

  public SidesRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  public List<Side> GetAllSides()
  {
    string sql = "SELECT * FROM sides;";
    List<Side> sides = _db.Query<Side>(sql).ToList();
    return sides;
  }

  public Side GetSideById(int sideId)
  {
    string sql = @"
    SELECT * FROM sides WHERE id = @sideId;";

    Side side = _db.Query<Side>(sql, new { sideId = sideId }).SingleOrDefault();
    return side;
  }
}