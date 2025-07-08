namespace burgershack_dotnet_fullstack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SidesController : ControllerBase
{

  public SidesController(SidesService sidesService)
  {
    _sidesService = sidesService;
  }

  private readonly SidesService _sidesService;

  [HttpGet("test")]
  public ActionResult<string> Test()
  {
    return Ok("Sides Controller is running!");
  }

  [HttpGet]
  public ActionResult<List<Side>> GetAllSides()
  {
    try
    {
      List<Side> sides = _sidesService.GetAllSides();
      return Ok(sides);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpGet("{sideId}")]
  public ActionResult<Side> GetSideById(int sideId)
  {
    try
    {
      Side side = _sidesService.GetSideById(sideId);
      return Ok(side);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
