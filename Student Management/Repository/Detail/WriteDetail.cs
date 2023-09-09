using Student_Management.Data;
using Student_Management.IRepository.Detail;
using Student_Management.Models;

namespace Student_Management.Repository.Detail
{
    public class WriteDetail : WriteRepository<TbDetail>, IWriteDetail
    {
        public WriteDetail(DataContext context) : base(context)
        {
        }
    }
}
