namespace AgendaApi.Models.Profiles;

public class Role {
	public Guid Id { get; private set; }
	public Guid IdPosition { get; private set; }
	public Position? FromPosition { get; private set; }
	public Guid IdPerson { get; private set; }
	public Person? FromPerson { get; set; }
	public DateTime CreatedAt { get; private set; }

	public Role() { }

	public Role(Guid idPosition, Guid idPerson) {
		Id = Guid.NewGuid();
		IdPosition = idPosition;
		IdPerson = idPerson;
		CreatedAt = DateTime.UtcNow;
	}
}