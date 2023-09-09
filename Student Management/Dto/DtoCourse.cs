namespace Student_Management.Dto
{
    public class DtoCourse
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string CourseName { get; set; } = null!;
        public int Fees { get; set; }
        public int Duration { get; set; }
    }
}
