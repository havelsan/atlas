using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountingTermConfig : IEntityTypeConfiguration<AtlasModel.AccountingTerm>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountingTerm> builder)
        {
            builder.ToTable("ACCOUNTINGTERM");
            builder.HasKey(nameof(AtlasModel.AccountingTerm.ObjectId));
            builder.Property(nameof(AtlasModel.AccountingTerm.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountingTerm.Description)).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.AccountingTerm.StartDate)).HasColumnName("STARTDATE");
            builder.Property(nameof(AtlasModel.AccountingTerm.EndDate)).HasColumnName("ENDDATE");
            builder.Property(nameof(AtlasModel.AccountingTerm.Status)).HasColumnName("STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountingTerm.CostingMethod)).HasColumnName("COSTINGMETHOD").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountingTerm.IsFirstTerm)).HasColumnName("ISFIRSTTERM");
            builder.Property(nameof(AtlasModel.AccountingTerm.AccountancyRef)).HasColumnName("ACCOUNTANCY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountingTerm.PrevTermRef)).HasColumnName("PREVTERM").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Accountancy).WithOne().HasForeignKey<AtlasModel.AccountingTerm>(x => x.AccountancyRef).IsRequired(true);
            builder.HasOne(t => t.PrevTerm).WithOne().HasForeignKey<AtlasModel.AccountingTerm>(x => x.PrevTermRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}