using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLibModel.Models;

namespace WizLibModel.FluentConfig
{
    public class FluentPublisherConfig : IEntityTypeConfiguration<FluentPublisher>
    {
        public void Configure(EntityTypeBuilder<FluentPublisher> modelBuilder)
        {
            modelBuilder.HasKey(p => p.Publisher_Id);
            modelBuilder.Property(p => p.Name).IsRequired();
            modelBuilder.Property(p => p.Location).IsRequired();
        }
    }
}
