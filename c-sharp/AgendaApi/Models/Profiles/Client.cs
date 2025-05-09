namespace AgendaApi.Models.Profiles;

public class Client {
	public Guid Id { get; private set; }
	public Person? FromPerson { get; set; }
	public Guid IdPerson { get; private set; }
	public DateTime CreatedAt { get; private set; }

	public Client() { }

	public Client(Person person) {
		Id = Guid.NewGuid();
		FromPerson = person;
		IdPerson = person.Id;
		CreatedAt = DateTime.UtcNow;
	}
}