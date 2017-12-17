using FaqBuilder.DbContext;
using FaqBuilder.Interfaces;
using FaqBuilder.Models;

namespace FaqBuilder.Dal
{
    public class CharacterRepository : Repository<Character>, ICharacterRepository
    {
        public CharacterRepository(System.Data.Entity.DbContext context) : base(context)
        {
        }

        public FaqBuilderDbContext FaqBuilderDbContext => Context as FaqBuilderDbContext;
    }
}