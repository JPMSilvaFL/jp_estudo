using AgendaApi.Collections.Repositories.Interfaces;
using AgendaApi.Data;
using AgendaApi.Models.Profiles;

namespace AgendaApi.Collections.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository {
	public PersonRepository(AgendaDbContext context) : base(context) { }
}