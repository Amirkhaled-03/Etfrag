﻿namespace EtfragApp.PL.Configuration
{
	public class SmtpSettings
	{
		public string? From { get; set; }
		public string? Password { get; set; }
		public string Host { get; set; }
		public int Port { get; set; }
		public bool EnableSsl { get; set; }
	}

}
