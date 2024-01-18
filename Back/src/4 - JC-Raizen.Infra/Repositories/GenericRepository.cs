using JC_Raizen.Infra.Context;
using JC_Raizen.Infra.Interfaces;

namespace JC_Raizen.Infra.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        public readonly Contexto _context;

        public GenericRepository(Contexto context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
