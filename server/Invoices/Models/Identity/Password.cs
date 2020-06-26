namespace Invoices.Identity.Models
{
    public class Password
    {
        public byte[] Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
