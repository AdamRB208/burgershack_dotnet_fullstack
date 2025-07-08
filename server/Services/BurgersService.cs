namespace burgershack_dotnet_fullstack.Services;

public class BurgersService
{

  public BurgersService(BurgersRepository burgersRepository)
  {
    _burgersRepository = burgersRepository;
  }
  private readonly BurgersRepository _burgersRepository;

}


