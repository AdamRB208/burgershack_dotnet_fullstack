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

  [HttpPost]
  public ActionResult<Side> CreateSide([FromBody] Side sideData)
  {
    try
    {
      Side side = _sidesService.CreateSide(sideData);
      return Ok(side);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpDelete("{sideId}")]
  public ActionResult<string> DeleteSide(int sideId)
  {
    try
    {
      string message = _sidesService.DeleteSide(sideId);
      return Ok(message);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPut("{Id}")]
  public ActionResult<Side> UpdateSide(int Id, [FromBody] Side sideData)
  {
    try
    {
      Side side = _sidesService.UpdateSide(Id, sideData);
      return Ok(side);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
