using LeadManagement.Application.Interfaces;

namespace LeadManagement.Infrastructure.Services
{
	public class EmailService : IEmailService
	{
		public async Task SendEmailAsync(string to, string subject, string body)
		{
			var logPath = "email_logs.txt";
			var message = $"To: {to}\nSubject: {subject}\nBody:\n{body}\n\n";

			await File.AppendAllTextAsync(logPath, message);
			Console.WriteLine("Fake email logged.");
		}
	}
}
