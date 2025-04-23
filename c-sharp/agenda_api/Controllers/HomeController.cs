using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;

[ApiController]
public class HomeController : ControllerBase {
	[HttpGet("/")]
	public string Get()
	{
		return "Hello World!!!!";
	}
}