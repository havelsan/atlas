using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ResDivisionConfig : IEntityTypeConfiguration<AtlasModel.ResDivision>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ResDivision> builder)
        {
            builder.ToTable("RESDIVISION");
            builder.HasKey(nameof(AtlasModel.ResDivision.ObjectId));
            builder.Property(nameof(AtlasModel.ResDivision.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ResDivision.HeaderShipRef)).HasColumnName("HEADERSHIP").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.ResSection).WithOne().HasForeignKey<AtlasModel.ResSection>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.HeaderShip).WithOne().HasForeignKey<AtlasModel.ResDivision>(x => x.HeaderShipRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}