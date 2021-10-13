using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLibModel.Models;

namespace WizLibModel.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<FluentBookDetail>
    {
        public void Configure(EntityTypeBuilder<FluentBookDetail> modelBuilder)
        {
            modelBuilder.HasKey(b => b.BookDetail_Id);
            modelBuilder.Property(b => b.NumberOfChapters).IsRequired();
            modelBuilder.Property(b => b.NumberOfPages).IsRequired();
        }
    }
}
