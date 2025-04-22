namespace Agenda_EFMigratios.Models.Notifications;

public abstract class Notifiable {
	public List<Notification> Notifications { get; set; }
	public DateTime dataHoraLancamento { get; set; }

	protected Notifiable()
	{
		Notifications = new List<Notification>();
	}

	public void AddNotification(Notification notification)
	{
		dataHoraLancamento = DateTime.Now;
		Notifications.Add(notification);
	}

	public void AddNotifications(IEnumerable<Notification> notifications)
	{
		foreach (var notify in notifications) {
			dataHoraLancamento = DateTime.Now;
			Notifications.Add(notify);
		}
	}

	public int HasNotifications()
	{
		return Notifications.Count();
	}
}