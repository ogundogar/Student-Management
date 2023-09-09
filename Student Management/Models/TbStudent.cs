using System.ComponentModel.DataAnnotations;

namespace Student_Management.Models
{
    public class TbStudent
    {
        [Key]
        public int Id { get; set; }
        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public int TeacherId { get; set; }

        public bool Passed { get; set; }

        public TbCourse Course { get; set; }
        public TbUser Teacher { get; set; }
        public TbUser Student { get; set; }
    }
}
