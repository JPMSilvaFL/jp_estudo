using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers.Profiles;

public class PersonController : ControllerBase {
	

	private readonly IPersonService _personService;

	public PersonController(IPersonService personService) {
		_personService = personService;
	}

	[HttpPost("api/v1/persons/")]
	public async Task<IActionResult> CreatePerson([FromBody]PersonViewModel model) {
		if (!ModelState.IsValid)
			return BadRequest(new ResultViewModel<Person>("Invalid Data!"));
		var result = await _personService.HandleCreatePerson(model);
		return Ok(new ResultViewModel<Person>(result));
	}
}