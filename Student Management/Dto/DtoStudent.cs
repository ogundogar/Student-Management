namespace Student_Management.Dto
{
    public class DtoStudent
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public bool Passed { get; set; }
    }
}
