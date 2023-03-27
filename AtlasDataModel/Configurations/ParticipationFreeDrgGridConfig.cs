using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ParticipationFreeDrgGridConfig : IEntityTypeConfiguration<AtlasModel.ParticipationFreeDrgGrid>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ParticipationFreeDrgGrid> builder)
        {
            builder.ToTable("PARTICIPATIONFREEDRGGRID");
            builder.HasKey(nameof(AtlasModel.ParticipationFreeDrgGrid.ObjectId));
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.DrugName)).HasColumnName("DRUGNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.PeriodUnitType)).HasColumnName("PERIODUNITTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.Day)).HasColumnName("DAY");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.Frequency)).HasColumnName("FREQUENCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.MedulaDose)).HasColumnName("MEDULADOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.UsageDoseUnitType)).HasColumnName("USAGEDOSEUNITTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.Dose)).HasColumnName("DOSE");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.Count)).HasColumnName("COUNT");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.MedulaDoseInteger)).HasColumnName("MEDULADOSEINTEGER");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.MedulaUsageDose2)).HasColumnName("MEDULAUSAGEDOSE2").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.ParticipatnFreeDrugReportRef)).HasColumnName("PARTICIPATNFREEDRUGREPORT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ParticipationFreeDrgGrid.EtkinMaddeRef)).HasColumnName("ETKINMADDE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ParticipatnFreeDrugReport).WithOne().HasForeignKey<AtlasModel.ParticipationFreeDrgGrid>(x => x.ParticipatnFreeDrugReportRef).IsRequired(false);
            builder.HasOne(t => t.EtkinMadde).WithOne().HasForeignKey<AtlasModel.ParticipationFreeDrgGrid>(x => x.EtkinMaddeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}