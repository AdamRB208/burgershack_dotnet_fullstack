

namespace burgershack_dotnet_fullstack.Repositories;

public class BurgersRepository
{

  public BurgersRepository(IDbConnection db)
  {
    _db = db;
  }

  private readonly IDbConnection _db;

  public List<Burger> GetAllBurgers()
  {
    string sql = "SELECT * FROM burgers;";
    List<Burger> burgers = _db.Query<Burger>(sql).ToList();
    return burgers;
  }

  public Burger GetBurgerById(int burgerId)
  {
    string sql = @"
    SELECT * FROM burgers WHERE id = @burgerId;";

    Burger burger = _db.Query<Burger>(sql, new { burgerId = burgerId }).SingleOrDefault();
    return burger;
  }
}