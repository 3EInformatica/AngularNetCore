namespace WebApplication2.Models.DTO
{
    public class UtenteDTO
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Username { get; set; }
        public Guid Guid { get; set; }
        public string DataUltimoAccesso { get; set; }
    }
}
