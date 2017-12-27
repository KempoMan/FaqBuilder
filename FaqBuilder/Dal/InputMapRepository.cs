using FaqBuilder.DbContext;
using FaqBuilder.Interfaces;
using FaqBuilder.Models;

namespace FaqBuilder.Dal
{
    public class InputMapRepository : Repository<InputMap>, IInputMapRepository
    {
        public InputMapRepository(System.Data.Entity.DbContext context) : base(context)
        {

        }

        public FaqBuilderDbContext FaqBuilderDbContext => Context as FaqBuilderDbContext;
    }
}