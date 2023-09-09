using Microsoft.EntityFrameworkCore;

namespace Student_Management.IRepository
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}
