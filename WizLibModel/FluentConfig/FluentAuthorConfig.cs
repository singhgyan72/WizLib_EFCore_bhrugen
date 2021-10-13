using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLibModel.Models;

namespace WizLibModel.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentAuthor> modelBuilder)
        {
            modelBuilder.HasKey(a => a.Author_Id);
            modelBuilder.Property(a => a.FirstName).IsRequired();
            modelBuilder.Property(a => a.LastName).IsRequired();
            modelBuilder.Ignore(a => a.FullName);
        }
    }
}
