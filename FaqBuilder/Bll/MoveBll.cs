using FaqBuilder.Dal;
using FaqBuilder.DbContext;

namespace FaqBuilder.Bll
{
    public class MoveBll
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork(new FaqBuilderDbContext());


    }
}