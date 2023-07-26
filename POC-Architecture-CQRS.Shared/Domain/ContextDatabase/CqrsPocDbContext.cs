using Microsoft.EntityFrameworkCore;
using POC_Architecture_CQRS.Shared.Domain.Models;

namespace POC_Architecture_CQRS.Shared.Domain.ContextDatabase;

public partial class CqrsPocDbContext : DbContext
{
    public CqrsPocDbContext(DbContextOptions<CqrsPocDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Address> Address { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(u =>
        {
            u.HasKey(k => k.Id);
            u.HasOne(a => a.Address).WithMany(a => a.AddressUsers).HasForeignKey(a => a.AddressId);
        });

        modelBuilder.Entity<Address>(a =>
        {
            a.HasKey(k => k.Id);
            a.HasMany(u => u.AddressUsers);
        });

        base.OnModelCreating(modelBuilder);
    }
}