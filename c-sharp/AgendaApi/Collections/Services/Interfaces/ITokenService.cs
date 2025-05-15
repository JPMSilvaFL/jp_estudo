using AgendaApi.Collections.ViewModels.Result;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Services.Interfaces;

public interface ITokenService {
	Task<ResultViewModel<string>> GenerateToken(User user);
}