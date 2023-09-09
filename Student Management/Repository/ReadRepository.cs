using Microsoft.EntityFrameworkCore;
using Student_Management.Data;
using Student_Management.IRepository;
using System.Linq.Expressions;

namespace Student_Management.Repository
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly DataContext _context;
        public ReadRepository(DataContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll() => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);
    }
}
