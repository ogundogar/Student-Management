using Student_Management.Data;
using Student_Management.IRepository.Course;
using Student_Management.Models;

namespace Student_Management.Repository.Course
{
    public class WriteCourse : WriteRepository<TbCourse>, IWriteCourse
    {
        public WriteCourse(DataContext context) : base(context)
        {
        }
    }
}
