using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class UserController : ControllerBase {

	private readonly IUserRepository _userRepository;

	public UserController(IUserRepository userRepository) {
		_userRepository = userRepository;
	}

	[HttpGet("api/v1/users")]
	public async Task<ActionResult<List<User>>> GetUsers() {
		var users = await _userRepository.GetAllAsync();
		return Ok(users);
	}
	// [HttpPost("api/v1/users/")]
	// public async Task<IActionResult> CreateUser(UserViewModel model) {
	//
	// }
}