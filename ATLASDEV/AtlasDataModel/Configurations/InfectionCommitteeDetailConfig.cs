using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class InfectionCommitteeDetailConfig : IEntityTypeConfiguration<AtlasModel.InfectionCommitteeDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.InfectionCommitteeDetail> builder)
        {
            builder.ToTable("INFECTIONCOMMITTEEDETAIL");
            builder.HasKey(nameof(AtlasModel.InfectionCommitteeDetail.ObjectId));
            builder.Property(nameof(AtlasModel.InfectionCommitteeDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.InfectionCommitteeDetail.Description)).HasColumnName("DESCRIPTION");
            builder.Property(nameof(AtlasModel.InfectionCommitteeDetail.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.InfectionCommitteeDetail.InfectionCommitteeRef)).HasColumnName("INFECTIONCOMMITTEE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.InfectionCommitteeDetail.DrugOrderRef)).HasColumnName("DRUGORDER").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.InfectionCommittee).WithOne().HasForeignKey<AtlasModel.InfectionCommitteeDetail>(x => x.InfectionCommitteeRef).IsRequired(false);
            builder.HasOne(t => t.DrugOrder).WithOne().HasForeignKey<AtlasModel.InfectionCommitteeDetail>(x => x.DrugOrderRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}