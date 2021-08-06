#nullable enable
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Test
{
    public class MyDbContext : DbContext
    {
        public DbSet<Assessment> Assessments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseInMemoryDatabase("TestDb");
    }

    public class Assessment
    {
        public int Id { get; set; }
        public Contract Contract { get; set; } = null!;
    }

    public class Contract
    {
        public int Id { get; set; }
        public ICollection<Company> Companies { get; set; } = null!;
    }

    public class Company
    {
        public int Id { get; set; }
        public ICollection<Signatory> Signatories { get; set; } = null!;
    }

    public class Signatory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
