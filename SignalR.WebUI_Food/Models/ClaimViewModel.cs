namespace SignalR.WEB_Food.Models
{
    public class ClaimViewModel
    {
        public string Issuer { get; set; } = null!;//dağıtan
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
