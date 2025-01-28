namespace WebApplication2.Models.DTO
{
    public class LoginUtenteDTO
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public Guid Guid{ get; set; }
        public string DataUltimoAccesso{ get; set; }
    }
}
