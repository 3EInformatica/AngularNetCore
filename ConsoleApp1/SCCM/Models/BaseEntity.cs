namespace SCCM.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCreazione { get; set; }
        public DateTime? DataAggiornamento { get; set; }
        public DateTime? DataCancellazione { get; set; }
        public bool Abilitato { get; set; }
    }
}
