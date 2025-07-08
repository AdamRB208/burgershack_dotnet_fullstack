namespace burgershack_dotnet_fullstack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BurgersController : ControllerBase
{
  public BurgersController(BurgersService burgersService)
  {
    _burgersService = burgersService;
  }

  private readonly BurgersService _burgersService;

  [HttpGet("test")]
  public ActionResult<string> Test()
  {
    return Ok("Burgers Controller is running!");
  }

}
