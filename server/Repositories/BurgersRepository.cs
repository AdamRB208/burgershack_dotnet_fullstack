



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

  public Burger CreateBurger(Burger burgerData)
  {
    string sql = @"
    INSERT INTO
    burgers (name, price, imgUrl)
    VALUES (@Name, @Price, @ImgUrl);
    SELECT * FROM burgers WHERE id = LAST_INSERT_ID();";

    Burger burger = _db.Query<Burger>(sql, burgerData).SingleOrDefault();
    return burger;
  }

  public void DeleteBurger(int burgerId)
  {
    string sql = @"
    DELETE FROM burgers WHERE id = @burgerId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { burgerId });

    if (rowsAffected == 0) throw new Exception("No rows were deleted!");
    if (rowsAffected > 1) throw new Exception("More than one row was deleted!");
  }

  public Burger UpdateBurger(int Id, Burger burgerData)
  {
    string sql = @"
    UPDATE burgers SET name = @Name, price = @Price WHERE id = @Id;
    SELECT * FROM burgers WHERE id = @Id;";

    burgerData.Id = Id;
    Burger burger = _db.Query<Burger>(sql, burgerData).SingleOrDefault();
    return burger;
  }
}