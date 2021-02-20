namespace GenericAPI
{
    public class Settings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public AuthenticationOptions AuthenticationOptions { get; set; }
        public LinksOptions LinksOptions { get; set; }
        public CorsOptions CorsOptions { get; set; }
        public EmailSettings EmailSettings { get; set; }
    }

    public class LinksOptions
    {
        public string ResetPasswordLink { get; set; }
    }

    public class AuthenticationOptions
    {
        public string Secret { get; set; }
        public int Lifetime { get; set; }
    }

    public class ConnectionStrings
    {
        public string GenericApiContext { get; set; }
        public string Elmah { get; set; }
    }

    public class EmailSettings
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
    }

    public class CorsOptions
    {
        public string AllowedHosts { get; set; }
        public string AllowedPorts { get; set; }
        public string AllowedProtocols { get; set; }
    }
}
