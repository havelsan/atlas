using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LCDNotificationDefinitionConfig : IEntityTypeConfiguration<AtlasModel.LCDNotificationDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LCDNotificationDefinition> builder)
        {
            builder.ToTable("LCDNOTIFICATIONDEFINITION");
            builder.HasKey(nameof(AtlasModel.LCDNotificationDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.LCDNotificationDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LCDNotificationDefinition.Notification)).HasColumnName("NOTIFICATION").HasMaxLength(1000);
        }
    }
}