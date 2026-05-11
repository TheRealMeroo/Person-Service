using Microsoft.EntityFrameworkCore;
using PersonService.Domain.Entities;

namespace PersonService.Infrastructure.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options)
                : base(options) { }

        public DbSet<Person> Persons => Set<Person>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(e =>
            {
                e.HasKey(p => p.Id);
            });

            modelBuilder.Entity<Person>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Person>()
                .HasIndex(p => p.IsDeleted);

            modelBuilder.Entity<Person>()
                .HasIndex(p => p.NationalCode).IsUnique();

            modelBuilder.Entity<Person>()
                .OwnsOne(p => p.FirstName);

            modelBuilder.Entity<Person>()
                .OwnsOne(p => p.LastName);

            modelBuilder.Entity<Person>()
                .OwnsOne(p => p.NationalCode);

            modelBuilder.Entity<Person>()
                .OwnsOne(p => p.BirthDate);
        }
    }
}
