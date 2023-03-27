using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountDayTermConfig : IEntityTypeConfiguration<AtlasModel.AccountDayTerm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountDayTerm> builder)
        {
            builder.ToTable("ACCOUNTDAYTERM");
            builder.HasKey(nameof(AtlasModel.AccountDayTerm.ObjectId));
            builder.Property(nameof(AtlasModel.AccountDayTerm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountDayTerm.Average)).HasColumnName("AVERAGE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDayTerm.MovableAverage)).HasColumnName("MOVABLEAVERAGE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDayTerm.ProcedureAverage)).HasColumnName("PROCEDUREAVERAGE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountDayTerm.AccountPeriodRef)).HasColumnName("ACCOUNTPERIOD").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountPeriod).WithOne().HasForeignKey<AtlasModel.AccountDayTerm>(x => x.AccountPeriodRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}