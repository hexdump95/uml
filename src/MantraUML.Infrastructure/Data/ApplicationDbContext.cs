using MantraUML.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace MantraUML.Infrastructure.Data;

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
        });
        modelBuilder.Entity<Diagram>(diagram =>
        {
            diagram.HasKey(d => d.Id);
            diagram.HasOne(d => d.Project)
                .WithMany()
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
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
            link.OwnsOne(l => l.Source);
            link.OwnsOne(l => l.Target);
        });


        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = Guid.Parse("e7909ae9-4b5a-4690-9332-0f3f20a282ce"),
                Name = "Project 1",
                UserId = "dbdfbb71-8609-4e95-8aad-223eabe66be5"
            }
        );
        modelBuilder.Entity<DiagramType>().HasData(
            new DiagramType { Id = Guid.Parse("c98385d7-5d1b-407c-8b47-6a0fb3e27690"), Name = "Class Diagram" }
        );
        modelBuilder.Entity<Diagram>().HasData(new Diagram
        {
            Id = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa"),
            Name = "Class Diagram n#1",
            DiagramTypeId = Guid.Parse("c98385d7-5d1b-407c-8b47-6a0fb3e27690"),
            ProjectId = Guid.Parse("e7909ae9-4b5a-4690-9332-0f3f20a282ce")
        });

        // modelBuilder.Entity<PortElement>().HasData(
        //     new PortElement { Id = "f7e19af8-9a64-4289-96d3-6bf67bbcce68", Port = "bottom-4" },
        //     new PortElement { Id = "ce671c08-0877-4bf9-95fb-d97d0ec10309", Port = "top-4" }
        // );
        // modelBuilder.Entity<Link>().HasData(new
        // {
        //     Id = Guid.Parse("99bf50b3-2a57-4dfb-a859-e14418730e7b"),
        //     Type = "mantraUML.ArrowLink",
        //     SourceId = "f7e19af8-9a64-4289-96d3-6bf67bbcce68",
        //     SourcePort = "bottom-4",
        //     TargetId = "ce671c08-0877-4bf9-95fb-d97d0ec10309",
        //     TargetPort = "top-4",
        //     DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        // });
        // modelBuilder.Entity<PortElement>().HasData(
        //     new PortElement { Id = "f7e19af8-9a64-4289-96d3-6bf67bbcce68", Port = "right-4" },
        //     new PortElement { Id = "b9455a64-9cfd-4a3b-a19e-585fcba4998c", Port = "left-5" }
        // );
        // modelBuilder.Entity<Link>().HasData(new
        // {
        //     Id = Guid.Parse("e5932472-426d-4402-ade8-2b193cbe5bfb"),
        //     Type = "mantraUML.CompositionArrowLink",
        //     SourceId = "f7e19af8-9a64-4289-96d3-6bf67bbcce68",
        //     SourcePort = "right-4",
        //     TargetId = "b9455a64-9cfd-4a3b-a19e-585fcba4998c",
        //     TargetPort = "left-5",
        //     DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //
        // });
        //
        // modelBuilder.Entity<PortElement>().HasData(
        //     new PortElement { Id = "b9455a64-9cfd-4a3b-a19e-585fcba4998c", Port = "right-5" },
        //     new PortElement { Id = "ad639876-95c8-48be-856f-5b5f5a8c2710", Port = "left-4" }
        // );
        // modelBuilder.Entity<Link>().HasData(new
        // {
        //     Id = Guid.Parse("e05f7a56-b22d-4c81-9cce-e54df4ddea25"),
        //     Type = "mantraUML.ArrowLink",
        //     SourceId = "b9455a64-9cfd-4a3b-a19e-585fcba4998c",
        //     SourcePort = "right-5",
        //     TargetId = "ad639876-95c8-48be-856f-5b5f5a8c2710",
        //     TargetPort = "left-4",
        //     DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        // });
        //
        // modelBuilder.Entity<PortElement>().HasData(
        //     new PortElement { Id = "ad639876-95c8-48be-856f-5b5f5a8c2710", Port = "right-4" },
        //     new PortElement { Id = "3ac79384-7fde-46cc-9b24-efbb4cc24225", Port = "left-5" }
        // );
        // modelBuilder.Entity<Link>().HasData(new
        // {
        //     Id = Guid.Parse("3be2df91-53c0-41e1-abe6-eddc5b7321af"),
        //     Type = "mantraUML.ArrowLink",
        //     SourceId = "ad639876-95c8-48be-856f-5b5f5a8c2710",
        //     SourcePort = "right-4",
        //     TargetId = "3ac79384-7fde-46cc-9b24-efbb4cc24225",
        //     TargetPort = "left-5",
        //     DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        // });
        //
        //
        // modelBuilder.Entity<PortElement>().HasData(
        //     new PortElement { Id = "3edb6387-a0a6-4493-95fd-60c0d9f84f94", Port = "left-5" },
        //     new PortElement { Id = "809379af-51e4-4a98-b364-1f821aecb175", Port = "right-5" }
        // );
        // modelBuilder.Entity<Link>().HasData(new
        // {
        //     Id = Guid.Parse("e56efc6a-f941-41bb-9299-ab8a97307633"),
        //     Type = "mantraUML.CompositionArrowLink",
        //     SourceId = "3edb6387-a0a6-4493-95fd-60c0d9f84f94",
        //     SourcePort = "left-5",
        //     TargetId = "809379af-51e4-4a98-b364-1f821aecb175",
        //     TargetPort = "right-5",
        //     DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        // });
        //
        //
        // modelBuilder.Entity<PortElement>().HasData(
        //     new PortElement { Id = "809379af-51e4-4a98-b364-1f821aecb175", Port = "top-4" },
        //     new PortElement { Id = "ad639876-95c8-48be-856f-5b5f5a8c2710", Port = "bottom-4" }
        // );
        // modelBuilder.Entity<Link>().HasData(new
        // {
        //     Id = Guid.Parse("6d55a8ec-99eb-43cc-976d-a9e57fd1aaf4"),
        //     Type = "mantraUML.ArrowLink",
        //     SourceId = "809379af-51e4-4a98-b364-1f821aecb175",
        //     SourcePort = "top-4",
        //     TargetId = "ad639876-95c8-48be-856f-5b5f5a8c2710",
        //     TargetPort = "bottom-4",
        //     DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        // });
        //
        // modelBuilder.Entity<Class>().HasData(
        //     new Class
        //     {
        //         Id = Guid.Parse("ad639876-95c8-48be-856f-5b5f5a8c2710"),
        //         Type = "mantraUML.Class",
        //         Label = "Product",
        //         PositionX = 602,
        //         PositionY = 8,
        //         DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //     }
        // );
        // modelBuilder.Entity<Attribute>().HasData(
        //     new Attribute
        //     {
        //         Id = 1,
        //         Name = "id",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ad639876-95c8-48be-856f-5b5f5a8c2710")
        //     },
        //     new Attribute
        //     {
        //         Id = 2,
        //         Name = "name",
        //         Type = "String",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ad639876-95c8-48be-856f-5b5f5a8c2710")
        //     },
        //     new Attribute
        //     {
        //         Id = 3,
        //         Name = "price",
        //         Type = "Double",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ad639876-95c8-48be-856f-5b5f5a8c2710")
        //     },
        //     new Attribute
        //     {
        //         Id = 4,
        //         Name = "stock",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ad639876-95c8-48be-856f-5b5f5a8c2710")
        //     },
        //     new Attribute
        //     {
        //         Id = 5,
        //         Name = "createdAt",
        //         Type = "Instant",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ad639876-95c8-48be-856f-5b5f5a8c2710")
        //     },
        //     new Attribute
        //     {
        //         Id = 6,
        //         Name = "deletedAt",
        //         Type = "Instant",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ad639876-95c8-48be-856f-5b5f5a8c2710")
        //     }
        // );
        //
        // modelBuilder.Entity<Class>().HasData(
        //     new Class
        //     {
        //         Id = Guid.Parse("3ac79384-7fde-46cc-9b24-efbb4cc24225"),
        //         Type = "mantraUML.Class",
        //         Label = "ProductType",
        //         PositionX = 850,
        //         PositionY = 10,
        //         DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //     }
        // );
        // modelBuilder.Entity<Attribute>().HasData(
        //     new Attribute
        //     {
        //         Id = 7,
        //         Name = "id",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("3ac79384-7fde-46cc-9b24-efbb4cc24225")
        //     },
        //     new Attribute
        //     {
        //         Id = 8,
        //         Name = "name",
        //         Type = "String",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("3ac79384-7fde-46cc-9b24-efbb4cc24225")
        //     },
        //     new Attribute
        //     {
        //         Id = 9,
        //         Name = "createdAt",
        //         Type = "Instant",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("3ac79384-7fde-46cc-9b24-efbb4cc24225")
        //     },
        //     new Attribute
        //     {
        //         Id = 10,
        //         Name = "deletedAt",
        //         Type = "Instant",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("3ac79384-7fde-46cc-9b24-efbb4cc24225")
        //     }
        // );
        //
        //
        // modelBuilder.Entity<Class>().HasData(
        //     new Class
        //     {
        //         Id = Guid.Parse("f7e19af8-9a64-4289-96d3-6bf67bbcce68"),
        //         Type = "mantraUML.Class",
        //         Label = "Order",
        //         PositionX = 102,
        //         PositionY = 36,
        //         DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //     }
        // );
        // modelBuilder.Entity<Attribute>().HasData(
        //     new Attribute
        //     {
        //         Id = 11,
        //         Name = "id",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("f7e19af8-9a64-4289-96d3-6bf67bbcce68")
        //     },
        //     new Attribute
        //     {
        //         Id = 12,
        //         Name = "buyerId",
        //         Type = "String",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("f7e19af8-9a64-4289-96d3-6bf67bbcce68")
        //     },
        //     new Attribute
        //     {
        //         Id = 13,
        //         Name = "createdAt",
        //         Type = "Instant",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("f7e19af8-9a64-4289-96d3-6bf67bbcce68")
        //     }
        // );
        //
        // modelBuilder.Entity<Class>().HasData(
        //     new Class
        //     {
        //         Id = Guid.Parse("b9455a64-9cfd-4a3b-a19e-585fcba4998c"),
        //         Type = "mantraUML.Class",
        //         Label = "OrderItem",
        //         PositionX = 357,
        //         PositionY = 46,
        //         DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //     }
        // );
        // modelBuilder.Entity<Attribute>().HasData(
        //     new Attribute
        //     {
        //         Id = 14,
        //         Name = "id",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("b9455a64-9cfd-4a3b-a19e-585fcba4998c")
        //     },
        //     new Attribute
        //     {
        //         Id = 15,
        //         Name = "quantity",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("b9455a64-9cfd-4a3b-a19e-585fcba4998c")
        //     }
        // );
        //
        //
        // modelBuilder.Entity<Class>().HasData(
        //     new Class
        //     {
        //         Id = Guid.Parse("ce671c08-0877-4bf9-95fb-d97d0ec10309"),
        //         Type = "mantraUML.Class",
        //         Label = "OrderStatus",
        //         PositionX = 101,
        //         PositionY = 229,
        //         DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //     }
        // );
        // modelBuilder.Entity<Attribute>().HasData(
        //     new Attribute
        //     {
        //         Id = 16,
        //         Name = "id",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ce671c08-0877-4bf9-95fb-d97d0ec10309")
        //     },
        //     new Attribute
        //     {
        //         Id = 17,
        //         Name = "name",
        //         Type = "String",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ce671c08-0877-4bf9-95fb-d97d0ec10309")
        //     },
        //     new Attribute
        //     {
        //         Id = 18,
        //         Name = "createdAt",
        //         Type = "Instant",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ce671c08-0877-4bf9-95fb-d97d0ec10309")
        //     },
        //     new Attribute
        //     {
        //         Id = 19,
        //         Name = "deletedAt",
        //         Type = "Instant",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("ce671c08-0877-4bf9-95fb-d97d0ec10309")
        //     }
        // );
        //
        //
        // modelBuilder.Entity<Class>().HasData(
        //     new Class
        //     {
        //         Id = Guid.Parse("3edb6387-a0a6-4493-95fd-60c0d9f84f94"),
        //         Type = "mantraUML.Class",
        //         Label = "Cart",
        //         PositionX = 850,
        //         PositionY = 260,
        //         DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //     }
        // );
        // modelBuilder.Entity<Attribute>().HasData(
        //     new Attribute
        //     {
        //         Id = 20,
        //         Name = "buyerId",
        //         Type = "String",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("3edb6387-a0a6-4493-95fd-60c0d9f84f94")
        //     }
        // );
        //
        // modelBuilder.Entity<Class>().HasData(
        //     new Class
        //     {
        //         Id = Guid.Parse("809379af-51e4-4a98-b364-1f821aecb175"),
        //         Type = "mantraUML.Class",
        //         Label = "CartItem",
        //         PositionX = 610,
        //         PositionY = 250,
        //         DiagramId = Guid.Parse("4466ec99-6ea4-461e-9bb8-cd37d426bbaa")
        //     }
        // );
        // modelBuilder.Entity<Attribute>().HasData(
        //     new Attribute
        //     {
        //         Id = 21,
        //         Name = "id",
        //         Type = "String",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("809379af-51e4-4a98-b364-1f821aecb175")
        //     },
        //     new Attribute
        //     {
        //         Id = 22,
        //         Name = "quantity",
        //         Type = "Long",
        //         Visibility = '-',
        //         ClassId = Guid.Parse("809379af-51e4-4a98-b364-1f821aecb175")
        //     }
        // );
    }
}
