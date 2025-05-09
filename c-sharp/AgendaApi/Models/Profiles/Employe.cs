namespace AgendaApi.Models.Profiles;

public class Employe {
	public Guid Id { get; private set; }
	public Guid IdPosition { get; private set; }
	public Position? FromPosition { get; private set; }
	public Guid IdPerson { get; private set; }
	public Person? FromPerson { get; set; }
	public DateTime CreatedAt { get; private set; }

	public Employe() { }

	public Employe(Position position, Person person) {
		Id = Guid.NewGuid();
		IdPosition = position.Id;
		IdPerson = person.Id;
		FromPosition = position;
		FromPerson = person;
		CreatedAt = DateTime.UtcNow;
	}
}