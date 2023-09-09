using Student_Management.Data;
using Student_Management.IRepository.User;
using Student_Management.Models;

namespace Student_Management.Repository.User
{
    public class ReadUser : ReadRepository<TbUser>, IReadUser
    {
        public ReadUser(DataContext context) : base(context)
        {
        }
    }
}
