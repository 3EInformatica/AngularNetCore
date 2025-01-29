namespace WebApplication2.Models.Requests
{
    public record UtenteEditRequest
    {
        public Guid GuidUtente { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
