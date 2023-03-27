using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChattelDocumentOutputDetailWithAccountancyConfig : IEntityTypeConfiguration<AtlasModel.ChattelDocumentOutputDetailWithAccountancy>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChattelDocumentOutputDetailWithAccountancy> builder)
        {
            builder.ToTable("CHATTELDOCODACCOUNTANCY");
            builder.HasKey(nameof(AtlasModel.ChattelDocumentOutputDetailWithAccountancy.ObjectId));
            builder.Property(nameof(AtlasModel.ChattelDocumentOutputDetailWithAccountancy.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.StockActionDetailOut).WithOne().HasForeignKey<AtlasModel.StockActionDetailOut>(p => p.ObjectId);
        }
    }
}