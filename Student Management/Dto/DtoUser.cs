namespace Student_Management.Dto
{
    public class DtoUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int DetailId { get; set; }
    }
}
