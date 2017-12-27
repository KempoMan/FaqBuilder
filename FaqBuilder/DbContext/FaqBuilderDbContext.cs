using System.Data.Entity;
using FaqBuilder.EntityConfigurations;
using FaqBuilder.Models;

namespace FaqBuilder.DbContext
{
    public class FaqBuilderDbContext : System.Data.Entity.DbContext
    {
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<MoveType> MoveTypes { get; set; }
        //public DbSet<InputMap> InputMaps { get; set; }
        //public DbSet<Move> Moves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlatformConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new CharacterConfiguration());
            modelBuilder.Configurations.Add(new MoveTypeConfiguration());
            //modelBuilder.Configurations.Add(new InputMapConfiguration());
            //modelBuilder.Configurations.Add(new MoveConfiguration());
        }
    }
}