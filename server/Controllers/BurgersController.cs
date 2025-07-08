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

  [HttpGet]
  public ActionResult<List<Burger>> GetAllBurgers()
  {
    try
    {
      List<Burger> burgers = _burgersService.GetAllBurgers();
      return Ok(burgers);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpGet("{burgerId}")]
  public ActionResult<Burger> GetBurgerById(int burgerId)
  {
    try
    {
      Burger burger = _burgersService.GetBurgerById(burgerId);
      return Ok(burger);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPost]
  public ActionResult<Burger> CreateBurger([FromBody] Burger burgerData)
  {
    try
    {
      Burger burger = _burgersService.CreateBurger(burgerData);
      return Ok(burger);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpDelete("{burgerId}")]
  public ActionResult<string> DeleteBurger(int burgerId)
  {
    try
    {
      string message = _burgersService.DeleteBurger(burgerId);
      return Ok(message);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }

  [HttpPut("{Id}")]
  public ActionResult<Burger> UpdateBurger(int Id, [FromBody] Burger burgerData)
  {
    try
    {
      Burger burger = _burgersService.UpdateBurger(Id, burgerData);
      return Ok(burger);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
