using Microsoft.EntityFrameworkCore;
using Storage.Entities;

namespace Storage.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<University> Universities { get; set; }

    public DbSet<Subject> Subjects { get; set; }

    public DbSet<HeadTeacher> HeadTeachers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Subject>()
            .HasOne(s => s.University)
            .WithMany(u => u.Subjects)
            .HasForeignKey(s => s.UniversityId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<HeadTeacher>()
            .HasOne(ht => ht.Subject)
            .WithOne(s => s.HeadTeacher)
            .HasForeignKey<HeadTeacher>(ht => ht.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
