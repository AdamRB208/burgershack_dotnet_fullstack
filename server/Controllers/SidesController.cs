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

  
}
