namespace agenda_api;

public static class Configuration {
	public static string JwtKey { get; set; } = "ue7oJSnGwrg3J1ImDB5V+5w6MvBwZ5jZQwceqKAD0+Y=";
	public static string ApiKey { get; set; } = "api_key";
	public static string ApiKeyName { get; set; } = "agenda_API_MDLAKMDLKML12K3MN1NDKADAEQE1231DAE131DA";

	public static SmtpConfiguration Smtp { get; set; } = new();

	public class SmtpConfiguration {
		public string Host { get; set; }
		public int Port { get; set; } = 25;
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}