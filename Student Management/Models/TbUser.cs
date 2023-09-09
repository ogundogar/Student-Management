using System.ComponentModel.DataAnnotations;

namespace Student_Management.Models
{
    public class TbUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int DetailId { get; set; }
        public TbDetail Detail { get; set; } = null!;

        public ICollection<TbCourse> TbCourses { get; set; }

        public ICollection<TbStudent> TbStudents { get; set; }

        public ICollection<TbStudent> TbTeachers { get; set; }
    }
}
