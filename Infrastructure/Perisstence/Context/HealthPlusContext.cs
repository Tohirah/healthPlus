using HealthPlus.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Numerics;

namespace HealthPlus.Infrastructure.Persistence.Context
{
    public class HealthPlusContext : DbContext

    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user=root;database=ArtisanMVC;port=3306;password=Labiib");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}
