using GraphApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphApi.Infraestructure
{
    public class TrainingContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Inspection> Inspections { get; set; }

        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }
    }
}
