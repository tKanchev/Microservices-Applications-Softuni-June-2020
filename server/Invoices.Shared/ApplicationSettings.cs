namespace Invoices.Shared
{
    public class ApplicationSettings
    {
        public string Secret { get; set; }

        public int TokenExpireInMinutes { get; set; }
    }
}
