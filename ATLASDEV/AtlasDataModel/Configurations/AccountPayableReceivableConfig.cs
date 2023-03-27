using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountPayableReceivableConfig : IEntityTypeConfiguration<AtlasModel.AccountPayableReceivable>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountPayableReceivable> builder)
        {
            builder.ToTable("ACCOUNTPAYABLERECEIVABLE");
            builder.HasKey(nameof(AtlasModel.AccountPayableReceivable.ObjectId));
            builder.Property(nameof(AtlasModel.AccountPayableReceivable.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountPayableReceivable.Type)).HasColumnName("TYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountPayableReceivable.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AccountPayableReceivable.Balance)).HasColumnName("BALANCE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountPayableReceivable.PatientRef)).HasColumnName("PATIENT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountPayableReceivable.ResUserRef)).HasColumnName("RESUSER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountPayableReceivable.PayerDefinitionRef)).HasColumnName("PAYERDEFINITION").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.Patient).WithOne().HasForeignKey<AtlasModel.AccountPayableReceivable>(x => x.PatientRef).IsRequired(false);
            builder.HasOne(t => t.ResUser).WithOne().HasForeignKey<AtlasModel.AccountPayableReceivable>(x => x.ResUserRef).IsRequired(false);
            builder.HasOne(t => t.PayerDefinition).WithOne().HasForeignKey<AtlasModel.AccountPayableReceivable>(x => x.PayerDefinitionRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}