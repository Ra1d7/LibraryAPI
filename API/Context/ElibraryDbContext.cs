using System;
using System.Collections.Generic;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context;

public partial class ElibraryDbContext : DbContext
{
    public ElibraryDbContext()
    {
    }

    public ElibraryDbContext(DbContextOptions<ElibraryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActiveBorrowing> ActiveBorrowings { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<AuthorsView> AuthorsViews { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksView> BooksViews { get; set; }

    public virtual DbSet<Borrower> Borrowers { get; set; }

    public virtual DbSet<BorrowersView> BorrowersViews { get; set; }

    public virtual DbSet<Borrowing> Borrowings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ContactDetail> ContactDetails { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CNC;Initial Catalog=ELibraryDB;TrustServerCertificate=true;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveBorrowing>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ActiveBorrowings");

            entity.Property(e => e.BorrowDate)
                .HasColumnType("date")
                .HasColumnName("Borrow Date");
            entity.Property(e => e.DueDate)
                .HasColumnType("date")
                .HasColumnName("Due Date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Fullname).HasMaxLength(101);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReturnDate)
                .HasMaxLength(50)
                .HasColumnName("Return Date");
            entity.Property(e => e.Status)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);

            entity.HasOne(d => d.Contact).WithMany(p => p.Authors)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Authors_ContactDetails");
        });

        modelBuilder.Entity<AuthorsView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AuthorsView");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.TitlesWorkedOn)
                .HasMaxLength(4000)
                .HasColumnName("Titles Worked On");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C20734F0D389");

            entity.HasIndex(e => e.Isbn, "Unique_ISBN").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.PublicationDate)
                .HasColumnType("date")
                .HasColumnName("Publication Date");
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Books_BookCategory");

            entity.HasOne(d => d.PublisherNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.Publisher)
                .HasConstraintName("Publisher_FK");

            entity.HasMany(d => d.Authors).WithMany(p => p.Books)
                .UsingEntity<Dictionary<string, object>>(
                    "BookAuthor",
                    r => r.HasOne<Author>().WithMany()
                        .HasForeignKey("Authorid")
                        .HasConstraintName("FK_BookAuthors_Authors"),
                    l => l.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .HasConstraintName("FK_BookAuthors_Books"),
                    j =>
                    {
                        j.HasKey("BookId", "Authorid");
                        j.ToTable("BookAuthors");
                    });
        });

        modelBuilder.Entity<BooksView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BooksView");

            entity.Property(e => e.Authors).HasMaxLength(4000);
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price)
                .HasMaxLength(41)
                .IsUnicode(false);
            entity.Property(e => e.PriceRange)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Price Range");
            entity.Property(e => e.Size)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.YearReleased).HasColumnName("Year Released");
        });

        modelBuilder.Entity<Borrower>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);

            entity.HasOne(d => d.Contact).WithMany(p => p.Borrowers)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_Borrowers_ContactDetails");
        });

        modelBuilder.Entity<BorrowersView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BorrowersView");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Firstname).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.NumberOfBorrows).HasColumnName("Number of Borrows");
            entity.Property(e => e.NumberOfReviews).HasColumnName("Number of Reviews");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Borrowing>(entity =>
        {
            entity.HasKey(e => e.BorrowId);

            entity.Property(e => e.BorrowDate)
                .HasColumnType("datetime")
                .HasColumnName("Borrow Date");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("Due Date");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("Return Date");

            entity.HasOne(d => d.Borrower).WithMany(p => p.Borrowings)
                .HasForeignKey(d => d.BorrowerId)
                .HasConstraintName("FK_Borrowings_Borrowers");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_BookCategory");

            entity.Property(e => e.Category1)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Category");
        });

        modelBuilder.Entity<ContactDetail>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Website)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.Property(e => e.PublisherName).HasMaxLength(250);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.Property(e => e.Comment).HasMaxLength(150);
            entity.Property(e => e.ReviewDate).HasColumnType("datetime");

            entity.HasOne(d => d.Book).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_Reviews_Books");

            entity.HasOne(d => d.Borrower).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.BorrowerId)
                .HasConstraintName("FK_Reviews_Borrowers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
