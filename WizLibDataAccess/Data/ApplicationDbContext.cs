using Microsoft.EntityFrameworkCore;
using WizLibModel.FluentConfig;
using WizLibModel.Models;

namespace WizLibDataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region DB Sets
        public DbSet<Category> Categories { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        public DbSet<FluentBookDetail> FluentBookDetails { get; set; }

        public DbSet<FluentBook> FluentBooks { get; set; }

        public DbSet<FluentAuthor> FluentAuthors { get; set; }

        public DbSet<FluentPublisher> FluentPublishers { get; set; }

        public DbSet<Test> Test { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure FLUENT API

            //Change tblname and colname through fluent API
            modelBuilder.Entity<Category>().ToTable("tbl_Categories");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("CategoryName");

            //modelBuilder.Entity<BookAuthor>().HasKey(ba => ba.Author_Id);

            //Composite Key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });

            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
        }
    }
}
