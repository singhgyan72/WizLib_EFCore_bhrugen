using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLibModel.Models;

namespace WizLibModel.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
    {
        public void Configure(EntityTypeBuilder<FluentBook> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Book_Id);
            modelBuilder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Property(b => b.Title).IsRequired();
            modelBuilder.Property(b => b.Price).IsRequired();

            //one to one rel bw book and bookdetail
            modelBuilder.HasOne(b => b.BookDetail).WithOne(i => i.Book).HasForeignKey<FluentBook>("BookDetail_Id");

            //one to many rel bw book and publisher
            modelBuilder.HasOne(b => b.Publisher).WithMany(i => i.Books).HasForeignKey(b => b.Publisher_Id);
        }
    }
}
