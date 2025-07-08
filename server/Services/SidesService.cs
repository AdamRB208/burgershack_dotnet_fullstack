
namespace burgershack_dotnet_fullstack.Services;

public class SidesService
{

  public SidesService(SidesRepository sidesRepository)
  {
    _sidesRepository = sidesRepository;
  }

  private readonly SidesRepository _sidesRepository;

  public List<Side> GetAllSides()
  {
    List<Side> sides = _sidesRepository.GetAllSides();
    return sides;
  }
}