using System.ComponentModel.DataAnnotations;

namespace Student_Management.Models
{
    public class TbDetail
    {
        [Key]
        public int Id { get; set; }
        public string Detail { get; set; } = null!;

        public ICollection<TbUser> TbUsers { get; set; }
    }
}
