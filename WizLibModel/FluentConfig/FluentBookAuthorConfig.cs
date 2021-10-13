using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLibModel.Models;

namespace WizLibModel.FluentConfig
{
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<FluentBookAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentBookAuthor> modelBuilder)
        {
            //many to many rel bw book and publisher
            modelBuilder.HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            modelBuilder.HasOne(b => b.Book).WithMany(i => i.BookAuthors)
                                              .HasForeignKey(b => b.Book_Id);
            modelBuilder.HasOne(b => b.Author).WithMany(i => i.BookAuthors)
                                              .HasForeignKey(b => b.Author_Id);
        }
    }
}
