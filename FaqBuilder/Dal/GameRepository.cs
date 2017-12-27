﻿using FaqBuilder.DbContext;
using FaqBuilder.Interfaces;
using FaqBuilder.Models;

namespace FaqBuilder.Dal
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(System.Data.Entity.DbContext context) : base(context)
        {
        }

        public FaqBuilderDbContext FaqBuilderDbContext => Context as FaqBuilderDbContext;
    }
}