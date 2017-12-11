using FaqBuilder.DbContext;
using FaqBuilder.Interfaces;
using FaqBuilder.Models;

namespace FaqBuilder.Dal
{
    public class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        public PlatformRepository(FaqBuilderDbContext context) : base(context)
        {
        }

        public FaqBuilderDbContext FaqBuilderDbContext => Context as FaqBuilderDbContext;
    }
}