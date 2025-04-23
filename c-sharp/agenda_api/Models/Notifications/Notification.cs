namespace Agenda_EFMigratios.Models.Notifications;

public sealed class Notification {
	public string propriedade { get; set; }
	public string message { get; set; }

	public Notification(string propriedade, string message)
	{
		this.propriedade = propriedade;
		this.message = message;
	}
}