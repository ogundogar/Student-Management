using System.ComponentModel.DataAnnotations;

namespace Student_Management.Models
{
    public class TbCourse
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string CourseName { get; set; } = null!;
        public int Fees { get; set; }
        public int Duration { get; set; }
        public ICollection<TbStudent> TbStudents { get; set; }
        public TbUser Teacher { get; set; }

    }
}
