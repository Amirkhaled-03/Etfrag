
using EtfragApp.DAL.Entities;
using EtfragApp.PL.Configuration;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Net;
using System.Net.Mail;

namespace EtfragApp.PL.Helpers
{
	public class EmailSettings
	{
		private static SmtpSettings _smtpSettings;

        // Method to initialize the static settings
        public static void Initialize(IOptions<SmtpSettings> smtpSettings)
		{
			_smtpSettings = smtpSettings.Value;
		}


		public static async Task SendEmailAsync(Email email)
		{
			
			try
			{
				using (var client = new SmtpClient(_smtpSettings.Host ,_smtpSettings.Port))
				{
					client.UseDefaultCredentials = false;
					client.EnableSsl = _smtpSettings.EnableSsl;  // Enable SSL for security
					client.Credentials = new NetworkCredential(_smtpSettings.From, _smtpSettings.Password);

					using (var myMail = new MailMessage(_smtpSettings.From, email.To, email.Subject, email.Body))
					{
						await client.SendMailAsync(myMail);  // Use SendMailAsync for async operation
					}
				}
			}
			catch (SmtpException ex)
			{
				throw new ApplicationException("SmtpException has occurred: " + ex.Message);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
