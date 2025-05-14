using System.ComponentModel.DataAnnotations;

namespace AgendaApi.Collections.ViewModels.Profiles;

public class UserViewModel {
	[Required(ErrorMessage = "Username is required")]
	[Length(6,50, ErrorMessage = "Username must be between 6 and 50 characters")]
	[RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Only letters, numbers and underscores are allowed")]
	public string Username { get; set; } = null!;

	[Required(ErrorMessage = "Password is required")]
	[Length(9,99, ErrorMessage = "Password must be between 6 and 50 characters")]
	[RegularExpression("^(?=(?:.*\\d){2,})(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W_]).{9,}$\n",
		ErrorMessage = "One letter upercase, One downcase, One symbol and 2 number, with the minimum characters 9")]
	public string Password { get; set; } = null!;

	[Required(ErrorMessage = "Access is required")]
	public Guid IdAccess { get; set; }

	[Required(ErrorMessage = "Full name is required")]
	[Length(3,100, ErrorMessage = "Full name must be between 3 and 100 characters")]
	public string FullName { get; set; } = null!;

	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email")]
	public string Email { get; set; } = null!;


	[Required(ErrorMessage = "Phone is required")]
	public string Phone { get; set; } = null!;

	[Required (ErrorMessage = "Document is required")]
	[RegularExpression(@"^[0-9]{14}$", ErrorMessage = "Invalid document")]
	public string Document { get; set; } = null!;

	[Required(ErrorMessage = "Type is required")]
	[MaxLength(1, ErrorMessage = "Type has a max length of 1 character")]
	public string Type { get; set; } = null!;

	[Required(ErrorMessage = "Address is required")]
	[MaxLength(100, ErrorMessage = "Address has a max length of 13 characters")]
	public string Address { get; set; } = null!;
}