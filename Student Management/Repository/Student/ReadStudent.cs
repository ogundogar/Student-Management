using Student_Management.Data;
using Student_Management.IRepository.Student;
using Student_Management.Models;

namespace Student_Management.Repository.Student
{
    public class ReadStudent : ReadRepository<TbStudent>, IReadStudent
    {
        public ReadStudent(DataContext context) : base(context)
        {
        }
    }
}
