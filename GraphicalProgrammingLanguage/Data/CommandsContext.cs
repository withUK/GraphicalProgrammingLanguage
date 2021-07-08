using GraphicalProgrammingLanguage.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphicalProgrammingLanguage.Data
{
    /// <summary>
    /// The access point to the GP_DATABASE which holds the count for each command invoked.
    /// Currently the connection string is hardcoded within the UseSqlServer method however this will be written
    /// and referenced from a appsettings.json file as developemnt continues.
    /// </summary>
    public partial class CommandsContext : DbContext
    {
        public CommandsContext()
        {
        }

        public CommandsContext(DbContextOptions<CommandsContext> options)
            : base(options)
        {
        }

        public DbSet<CommandUsageCount> CommandUsage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\peter\\Documents\\GPL_Database.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CommandUsageCount>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
