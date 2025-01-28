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
    }
}
