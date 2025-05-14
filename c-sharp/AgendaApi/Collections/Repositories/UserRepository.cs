using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories;

public class UserRepository : Repository<User>, IUserRepository{
	public UserRepository(AgendaDbContext context) : base(context) { }
}