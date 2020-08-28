using HotelsApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelsApp.Data.Mappings
{
    /// <summary>
    /// Property Map
    /// </summary>
    public class PropertyMap : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.HasKey(c => c.PropertyId);
            builder.Property(c => c.PropertyId).HasColumnType("varchar(50)").HasColumnName("PropertyId");

            builder.Property(c => c.PropertyName).HasColumnType("nvarchar(250)").HasMaxLength(250).IsRequired();

        }
    }
}
