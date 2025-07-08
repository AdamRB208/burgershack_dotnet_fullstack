
namespace burgershack_dotnet_fullstack.Services;

public class BurgersService
{

  public BurgersService(BurgersRepository burgersRepository)
  {
    _burgersRepository = burgersRepository;
  }
  private readonly BurgersRepository _burgersRepository;

  public List<Burger> GetAllBurgers()
  {
    List<Burger> burgers = _burgersRepository.GetAllBurgers();
    return burgers;
  }
}


