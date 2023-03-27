using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LaboratoryProcedureTubeInfoConfig : IEntityTypeConfiguration<AtlasModel.LaboratoryProcedureTubeInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LaboratoryProcedureTubeInfo> builder)
        {
            builder.ToTable("LABPROCEDURETUBEINFO");
            builder.HasKey(nameof(AtlasModel.LaboratoryProcedureTubeInfo.ObjectId));
            builder.Property(nameof(AtlasModel.LaboratoryProcedureTubeInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LaboratoryProcedureTubeInfo.RequestAcceptionDate)).HasColumnName("REQUESTACCEPTIONDATE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedureTubeInfo.BarcodeType)).HasColumnName("BARCODETYPE");
            builder.Property(nameof(AtlasModel.LaboratoryProcedureTubeInfo.SpecimenID)).HasColumnName("SPECIMENID");
            builder.Property(nameof(AtlasModel.LaboratoryProcedureTubeInfo.ContainerID)).HasColumnName("CONTAINERID");
            builder.Property(nameof(AtlasModel.LaboratoryProcedureTubeInfo.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LaboratoryProcedureTubeInfo.FromResourceName)).HasColumnName("FROMRESOURCENAME");
        }
    }
}