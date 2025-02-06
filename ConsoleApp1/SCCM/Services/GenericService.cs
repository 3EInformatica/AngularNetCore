using Microsoft.EntityFrameworkCore;
using SCCM.Models;

namespace SCCM.Services
{
    public class GenericService<T> where T : BaseEntity
    {
        private seiciochemangiContext _context;
        private DbSet<T> _dbSet;

        public GenericService()
        {
            var isDebugMode = true;
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<seiciochemangiContext>()
                .UseSqlServer("Server=54.38.44.7;Database=seiciochemangi;User Id=corsoNetCore;Password=3EInformatica!;Encrypt=False;TrustServerCertificate=False;")

           .LogTo(s => System.Diagnostics.Debug.WriteLine(s))
                          .EnableDetailedErrors(isDebugMode)
                          .EnableSensitiveDataLogging(isDebugMode).Options;
            _context = new seiciochemangiContext(options);
            _dbSet = _context.Set<T>();
        }

        public virtual T New(T entity)
        {
            entity.DataCreazione = DateTime.Now;
            entity.Abilitato = true;

            _dbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public virtual T Edit(T entity)
        {
            T? existingEntity = GetById(entity.Id);
            if (existingEntity == null)
            {
                return New(entity);
            }


            entity.DataAggiornamento = DateTime.Now;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
        public T? GetById(int id)
        {
            T? entity = _dbSet.FirstOrDefault(e => e.Id == id && !e.Abilitato);
            return entity;
        }
        public virtual List<T> GetAll()
        {
            // Chiamata a un metodo predefinito senza parametri
            return _dbSet.ToList();
        }
        public virtual bool Delete(T entity)
        {
            // Imposta la proprietà 'Cancellato' dell'entità su false
            entity.Abilitato = false;
            // Segna l'entità come modificata nel contesto
            _context.Entry(entity).State = EntityState.Modified;
            // Salva le modifiche nel database
            _context.SaveChanges();
            // Ritorna true per indicare che l'operazione è stata completata con successo
            return true;
        }
    }
}
