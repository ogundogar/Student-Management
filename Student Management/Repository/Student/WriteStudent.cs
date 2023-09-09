using Student_Management.Data;
using Student_Management.IRepository.Student;
using Student_Management.Models;

namespace Student_Management.Repository.Student
{
    public class WriteStudent : WriteRepository<TbStudent>, IWriteStudent
    {
        public WriteStudent(DataContext context) : base(context)
        {
        }
    }
}
