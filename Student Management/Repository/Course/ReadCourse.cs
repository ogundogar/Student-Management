using Student_Management.Data;
using Student_Management.IRepository.Course;
using Student_Management.Models;

namespace Student_Management.Repository.Course
{
    public class ReadCourse : ReadRepository<TbCourse>, IReadCourse
    {
        public ReadCourse(DataContext context) : base(context) { }
    }
}
