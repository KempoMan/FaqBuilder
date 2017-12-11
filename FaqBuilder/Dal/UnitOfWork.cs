﻿using FaqBuilder.DbContext;
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
        }

        public IPlatformRepository Platforms { get; set; }
        public IGameRepository Games { get; set; }
        public IFaqRepository Faqs { get; set; }

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