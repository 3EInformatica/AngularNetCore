using WebApplication2.Models.DTO;
using WebApplication2.Models.Entities;

namespace WebApplication2.Mappings
{
    public class UtentiMapping
    {

        public static LoginUtenteDTO MapUtentiLogin(Utenti u)
        {


            //return new LoginUtenteDTO
            //{
            //    Nome = u.Nome,
            //    Cognome = u.Cognome,
            //    Guid = u.Guid,
            //    DataUltimoAccesso = u.DataUltimoAccesso
            //};


            var result = new LoginUtenteDTO();
            result.Nome = u.Nome;
            result.Cognome = u.Cognome;
            result.DataUltimoAccesso = u.DataUltimoAccesso == null ? "" : ((DateTime)u.DataUltimoAccesso).ToString("dd/MM/yyyy HH:mm");
            result.Guid = u.Guid;
            return result;

        }

        internal static List<UtenteDTO> MapUtente(List<Utenti> utenti)
        {
            List<UtenteDTO> result = new List<UtenteDTO>();
            foreach (var item in utenti)
            {
                var r = new UtenteDTO();
                r.Nome = item.Nome;
                r.Cognome = item.Cognome;
                r.Username = item.Username;
                r.Guid = item.Guid;
                r.DataUltimoAccesso = item.DataUltimoAccesso == null ? "" : ((DateTime)item.DataUltimoAccesso).ToString("dd/MM/yyyy HH:mm");
                result.Add(r);
            }

            return result;
        }

        internal static UtenteDTO MapUtente(Utenti utenti)
        {
            var r = new UtenteDTO();
            r.Nome = utenti.Nome;
            r.Cognome = utenti.Cognome;
            r.Username = utenti.Username;
            r.Guid = utenti.Guid;
            r.DataUltimoAccesso = utenti.DataUltimoAccesso == null ? "" : ((DateTime)utenti.DataUltimoAccesso).ToString("dd/MM/yyyy HH:mm");
            return r;
        }
    }
}
