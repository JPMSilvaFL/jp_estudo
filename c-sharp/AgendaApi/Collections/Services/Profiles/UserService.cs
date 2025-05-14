using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Collections.Services.Interfaces;
using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;
using Microsoft.AspNetCore.Identity;

namespace AgendaApi.Collections.Services.Profiles;

public class UserService : IUserService{
	private readonly IUserRepository _userRepository;
	private readonly IAccessRepository _accessRepository;

	public UserService(IUserRepository userRepository, IAccessRepository accessRepository) {
		_userRepository = userRepository;
		_accessRepository = accessRepository;
	}

	public async Task<IList<User>> HandleListUser() {
		return await _userRepository.GetAllAsync();
	}

	public async Task<User> HandleCreateUser(UserViewModel model) {
		var person = new Person(model.FullName, model.Email, model.Document, model.Phone, model.Address, model.Type);

		var accessDatabase = await _accessRepository.GetByIdAsync(model.IdAccess);
		var access = new Access(accessDatabase.Id , accessDatabase.Name, accessDatabase.CreatedAt);

		var hasher = new PasswordHasher<User>();

		var user = new User(model.Username, model.Password, person, access);
		var passwordHashed = hasher.HashPassword(user, user.PasswordHash);
		user.PasswordHash = passwordHashed;
		await _userRepository.AddAsync(user);
		await _userRepository.SaveChangesAsync();
		return user;
	}
}