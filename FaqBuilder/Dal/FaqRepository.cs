using FaqBuilder.DbContext;
using FaqBuilder.Interfaces;
using FaqBuilder.Models;

namespace FaqBuilder.Dal
{
    public class FaqRepository : Repository<Faq>, IFaqRepository
    {
        public FaqRepository(FaqBuilderDbContext context) : base(context)
        {
        }

        public FaqBuilderDbContext FaqBuilderDbContext => Context as FaqBuilderDbContext;
    }
}