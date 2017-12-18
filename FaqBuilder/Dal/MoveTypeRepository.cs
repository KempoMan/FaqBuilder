using FaqBuilder.DbContext;
using FaqBuilder.Interfaces;
using FaqBuilder.Models;

namespace FaqBuilder.Dal
{
    public class MoveTypeRepository: Repository<MoveType>, IMoveTypeRepository
    {
        public MoveTypeRepository(System.Data.Entity.DbContext context) : base(context)
        {
        }

        public FaqBuilderDbContext FaqDbContext => Context as FaqBuilderDbContext;
    }
}