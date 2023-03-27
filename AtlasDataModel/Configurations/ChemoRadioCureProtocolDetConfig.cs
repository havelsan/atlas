using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChemoRadioCureProtocolDetConfig : IEntityTypeConfiguration<AtlasModel.ChemoRadioCureProtocolDet>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChemoRadioCureProtocolDet> builder)
        {
            builder.ToTable("CHEMORADIOCUREPROTOCOLDET");
            builder.HasKey(nameof(AtlasModel.ChemoRadioCureProtocolDet.ObjectId));
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocolDet.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocolDet.Note)).HasColumnName("NOTE");
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocolDet.ChemoRadioCureProtocolRef)).HasColumnName("CHEMORADIOCUREPROTOCOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocolDet.DrugMaterialRef)).HasColumnName("DRUGMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChemoRadioCureProtocolDet.SolutionMaterialRef)).HasColumnName("SOLUTIONMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.SubactionProcedureFlowable).WithOne().HasForeignKey<AtlasModel.SubactionProcedureFlowable>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ChemoRadioCureProtocol).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocolDet>(x => x.ChemoRadioCureProtocolRef).IsRequired(false);
            builder.HasOne(t => t.DrugMaterial).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocolDet>(x => x.DrugMaterialRef).IsRequired(false);
            builder.HasOne(t => t.SolutionMaterial).WithOne().HasForeignKey<AtlasModel.ChemoRadioCureProtocolDet>(x => x.SolutionMaterialRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}