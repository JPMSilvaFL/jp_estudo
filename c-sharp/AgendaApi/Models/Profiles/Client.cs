namespace AgendaApi.Models.Profiles;

public class Client {
	public Guid Id { get; private set; }
	public Person? FromPerson { get; set; }
	public Guid IdPerson { get; private set; }
	public DateTime CreatedAt { get; private set; }

	public Client() { }

	public Client(Guid idPerson) {
		Id = Guid.NewGuid();
		IdPerson = idPerson;
		CreatedAt = DateTime.UtcNow;
	}
}