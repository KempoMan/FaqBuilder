using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using FaqBuilder.EntityConfigurations;
using FaqBuilder.Models;

namespace FaqBuilder.DbContext
{
    public class FaqBuilderDbContext : System.Data.Entity.DbContext
    {
        public DbSet<ControllerInput> ControllerInputs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ControllerInputConfiguration());
        }
    }


}