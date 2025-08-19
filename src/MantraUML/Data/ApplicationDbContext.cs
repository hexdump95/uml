using MantraUML.Entities;

using Microsoft.EntityFrameworkCore;

namespace MantraUML.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }
    public virtual DbSet<Diagram> Diagrams { get; set; }
    public virtual DbSet<DiagramType> DiagramTypes { get; set; }
    public virtual DbSet<Element> Elements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(project =>
        {
            project.HasKey(p => p.Id);
            project.HasMany(p => p.Diagrams)
                .WithOne()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<Diagram>(diagram =>
        {
            diagram.HasKey(d => d.Id);
            diagram.HasOne(d => d.DiagramType)
                .WithMany()
                .HasForeignKey(d => d.DiagramTypeId);
            diagram.HasMany(d => d.Elements)
                .WithOne()
                .HasForeignKey(e => e.DiagramId)
                .OnDelete(DeleteBehavior.Cascade)
                ;
        });
        modelBuilder.Entity<DiagramType>().HasKey(d => d.Id);

        modelBuilder.Entity<Element>(element =>
        {
            element.HasKey(e => e.Id);
            element.HasDiscriminator<string>("ElementDiscriminator")
                .HasValue<Link>("e_link")
                .HasValue<Class>("e_class");
        });

        modelBuilder.Entity<Link>(link =>
        {
            link.HasKey(l => l.Id);
            link.OwnsOne(l => l.Source);
            link.OwnsOne(l => l.Target);
        });
    }
}
