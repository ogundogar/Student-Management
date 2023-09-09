using Student_Management.Data;
using Student_Management.IRepository.Detail;
using Student_Management.Models;

namespace Student_Management.Repository.Detail
{
    public class ReadDetail : ReadRepository<TbDetail>, IReadDetail
    {
        public ReadDetail(DataContext context) : base(context)
        {
        }
    }
}
