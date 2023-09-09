namespace Student_Management.IRepository
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        bool Add(T model);
        bool Remove(T model);
        bool Update(T model);
    }
}
