using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Student_Management.Data;
using Student_Management.IRepository;

namespace Student_Management.Repository
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly DataContext _context;
        public WriteRepository(DataContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public bool Add(T model)
        {
            EntityEntry<T> entityEntry =  Table.Add(model);
            _context.SaveChanges();
            return entityEntry.State == EntityState.Added;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            _context.SaveChanges();
            return entityEntry.State == EntityState.Deleted;
        }
        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            _context.SaveChanges();
            return entityEntry.State == EntityState.Modified;
        }
    }
}
