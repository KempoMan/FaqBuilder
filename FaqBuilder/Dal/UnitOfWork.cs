using FaqBuilder.DbContext;
using FaqBuilder.Interfaces;

namespace FaqBuilder.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FaqBuilderDbContext _context;

        public UnitOfWork(FaqBuilderDbContext context)
        {
            _context = context;
            Platforms = new PlatformRepository(_context);
            Games = new GameRepository(_context);
            Faqs = new FaqRepository(_context);
            Characters = new CharacterRepository(_context);
            MoveTypes = new MoveTypeRepository(_context);
            InputMaps = new InputMapRepository(_context);
            //Moves = new MoveRepository(_context);

        }

        public IPlatformRepository Platforms { get; set; }
        public IGameRepository Games { get; set; }
        public IFaqRepository Faqs { get; set; }
        public ICharacterRepository Characters { get; set; }
        public IMoveTypeRepository MoveTypes { get; set; }
        public IInputMapRepository InputMaps { get; set; }
        //public IMoveRepository Moves { get; set; }


        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}