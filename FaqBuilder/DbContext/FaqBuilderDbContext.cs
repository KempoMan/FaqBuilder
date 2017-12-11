using System.Data.Entity;
using FaqBuilder.EntityConfigurations;
using FaqBuilder.Models;

namespace FaqBuilder.DbContext
{
    public class FaqBuilderDbContext : System.Data.Entity.DbContext
    {
        //public DbSet<ControllerInput> ControllerInputs { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        //public DbSet<Faq> Faqs { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new FaqConfiguration());
            //modelBuilder.Configurations.Add(new ControllerInputConfiguration());
            modelBuilder.Configurations.Add(new PlatformConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new CharacterConfiguration());
        }
    }
}