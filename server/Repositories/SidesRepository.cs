
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

  public Side CreateSide(Side sideData)
  {
    string sql = @"
    INSERT INTO
    sides (name, price, imgUrl)
    VALUES (@Name, @Price, @ImgUrl);
    SELECT * FROM sides WHERE id = LAST_INSERT_ID();";

    Side side = _db.Query<Side>(sql, sideData).SingleOrDefault();
    return side;
  }

  public void DeleteSide(int sideId)
  {
    string sql = @"
    DELETE FROM sides WHERE id = @sideId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { sideId });

    if (rowsAffected == 0) throw new Exception("No rows were deleted!");
    if (rowsAffected > 1) throw new Exception("More than one row was deleted!");
  }

  public Side UpdateSide(int Id, Side sideData)
  {
    string sql = @"
    UPDATE sides SET name = @Name, price = @Price, imgUrl = @ImgUrl WHERE id = @Id;
    SELECT * FROM sides WHERE id = @Id;";

    sideData.Id = Id;
    Side side = _db.Query<Side>(sql, sideData).SingleOrDefault();
    return side;
  }
}