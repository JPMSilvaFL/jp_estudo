using AgendaApi.Collections.ViewModels.Profiles;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces;

public interface IUserService{
	Task<IList<User>> HandleListUser();
	Task<User> HandleCreateUser(UserViewModel model);
}