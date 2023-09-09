using Student_Management.Data;
using Student_Management.IRepository.User;
using Student_Management.Models;

namespace Student_Management.Repository.User
{
    public class WriteUser : WriteRepository<TbUser>, IWriteUser
    {
        public WriteUser(DataContext context) : base(context)
        {
        }
    }
}
