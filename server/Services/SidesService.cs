
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

  public string DeleteSide(int sideId)
  {
    Side side = GetSideById(sideId);
    _sidesRepository.DeleteSide(sideId);
    return $"{side.Name} was deleted!";
  }

  public Side UpdateSide(int Id, Side sideData)
  {
    Side side = _sidesRepository.UpdateSide(Id, sideData);
    return side;
  }
}