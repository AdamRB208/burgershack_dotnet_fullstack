

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

  public Side GetSideById(int sideId)
  {
    Side side = _sidesRepository.GetSideById(sideId);
    if (side == null) throw new Exception($"No Side with the id of {sideId}.");
    return side;
  }

  public Side CreateSide(Side sideData)
  {
    Side side = _sidesRepository.CreateSide(sideData);
    return side;
  }
}