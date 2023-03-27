using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DeleteRecordDocumentDestroyableMaterialOutConfig : IEntityTypeConfiguration<AtlasModel.DeleteRecordDocumentDestroyableMaterialOut>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DeleteRecordDocumentDestroyableMaterialOut> builder)
        {
            builder.ToTable("DELETERECDOCDESTROYMATOUT");
            builder.HasKey(nameof(AtlasModel.DeleteRecordDocumentDestroyableMaterialOut.ObjectId));
            builder.Property(nameof(AtlasModel.DeleteRecordDocumentDestroyableMaterialOut.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.HasOne(t => t.BaseDeleteRecordDocumentDetail).WithOne().HasForeignKey<AtlasModel.BaseDeleteRecordDocumentDetail>(p => p.ObjectId);
        }
    }
}