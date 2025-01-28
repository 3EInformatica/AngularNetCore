namespace WebApplication2.Models.Entities
{
    public record Utenti
    {
        public Guid Guid { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? DataUltimoAccesso { get; set; }
    }
}
