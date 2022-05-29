namespace identity_template_example.Services;

using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;

public interface IEmailService
{
    Task SendEmail(string toEmailAddress, string subject, string body);
}

/// <summary>
/// An email service that uses the System.Net.Mail.SmtpClient to send emails. Useful for local development, but should use something like
/// SendGrid, SES, etc for production. https://aka.ms/aspaccountconf
/// </summary>
public class LocalEmailService : IEmailService
{
    private readonly ILogger<LocalEmailService> _logger;
    
    public LocalEmailService(ILogger<LocalEmailService> logger)
    {
        _logger = logger;
    }
    
    public async Task SendEmail(string toEmailAddress, string subject, string body)
    {
        // TODO update to env var
        var fromEmailAddress = "noreply@test.com";
        var message = new MailMessage(fromEmailAddress, toEmailAddress);

        message.Subject = subject;
        message.Body = body;
        message.BodyEncoding = Encoding.UTF8;
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient();
        smtpClient.Host = "localhost";
        smtpClient.Port = 34981;

        _logger.LogInformation(
            "Sending email with Subject: `{Subject}` from address of : `{FromEmail}` and to address of: `{ToEmail}`", subject, fromEmailAddress, toEmailAddress);
        smtpClient.Send(message);
    }
}

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    
    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }
    
    public async Task SendEmail(string toEmailAddress, string subject, string body)
    {
        throw new NotImplementedException();
    }

    private async Task SendEmailWithAwsSes(string toEmailAddress, string subject, string body)
    {
        throw new NotImplementedException();
    }

    private async Task SendEmailWithSendGrid(string subject, string message, string toEmail)
    {
        // see here for an example of sendgrid: https://aka.ms/aspaccountconf
        throw new NotImplementedException();
    }
}