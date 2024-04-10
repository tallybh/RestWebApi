using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace RestWebApi.Models;

public class AppDbContext : DbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<UserModel> Users { get; set; }
    //public DbSet<Professor> Professors { get; set; }
    public DbSet<Class> Classes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=EfApi.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    //    modelBuilder
    //.Entity<UserModel>(builder =>
    //{
    //    builder.HasNoKey();
    //    builder.ToTable("UserModel");
    //});

    }
}
