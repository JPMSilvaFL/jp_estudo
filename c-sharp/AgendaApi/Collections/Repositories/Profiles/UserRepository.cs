using AgendaApi.Collections.Repositories.Interfaces.Profiles;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories.Profiles;

public class UserRepository : Repository<User>, IUserRepository{
	public UserRepository(AgendaDbContext context) : base(context) { }
}