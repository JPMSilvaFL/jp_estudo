using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Models.Profiles;

public class Person {
	public Guid Id { get; private set; }
	public bool Status { get; set; } = true;
	[Length(3,100)]
	public string FullName { get; private set; } = string.Empty;
	[Length(10,100)]
	public string Email { get; private set; } = string.Empty;
	[Length(11,14)]
	public string Document { get; private set; } = string.Empty;
	[MaxLength(1)]
	public string Type { get; private set; } = string.Empty;
	[MaxLength(13)]
	public string Phone { get; private set; } = string.Empty;
	[Length(10, 100)]
	public string Address { get; private set; } = string.Empty;
	public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
	public DateTime? UpdatedAt { get; private set; }

	public void UpdateStatus() {
		UpdatedAt = DateTime.UtcNow;
	}

	public Person() { }

	public Person(string fullName, string email, string document, string phone, string address, string type) {
		Id = Guid.NewGuid();
		FullName = fullName;
		Email = email;
		Type = type;
		Document = document;
		Phone = phone;
		Address = address;
	}
}