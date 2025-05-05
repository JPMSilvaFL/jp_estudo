using agenda_api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace agenda_api.Controllers;

[ApiController]
public class HomeController : ControllerBase {
	[HttpGet("/home")]
	[Authorize(Roles = "Admin")]
	public IActionResult Index() {
		return Ok("Funcionando!");
	}
}