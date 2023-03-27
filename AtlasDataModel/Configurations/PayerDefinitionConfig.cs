using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PayerDefinitionConfig : IEntityTypeConfiguration<AtlasModel.PayerDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PayerDefinition> builder)
        {
            builder.ToTable("PAYERDEFINITION");
            builder.HasKey(nameof(AtlasModel.PayerDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.PayerDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PayerDefinition.TaxNumber)).HasColumnName("TAXNUMBER").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PayerDefinition.ZipCode)).HasColumnName("ZIPCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PayerDefinition.TaxOffice)).HasColumnName("TAXOFFICE").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PayerDefinition.Name)).HasColumnName("NAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.PayerDefinition.GetPatientParticipation)).HasColumnName("GETPATIENTPARTICIPATION");
            builder.Property(nameof(AtlasModel.PayerDefinition.Address)).HasColumnName("ADDRESS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PayerDefinition.FaxNumber)).HasColumnName("FAXNUMBER").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PayerDefinition.ID)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.PayerDefinition.PhoneNumber)).HasColumnName("PHONENUMBER").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.PayerDefinition.Code)).HasColumnName("CODE");
            builder.Property(nameof(AtlasModel.PayerDefinition.DayOfSent)).HasColumnName("DAYOFSENT");
            builder.Property(nameof(AtlasModel.PayerDefinition.LimitOfInvoiceSummaryList)).HasColumnName("LIMITOFINVOICESUMMARYLIST");
            builder.Property(nameof(AtlasModel.PayerDefinition.Name_Shadow)).HasColumnName("NAME_SHADOW");
            builder.Property(nameof(AtlasModel.PayerDefinition.IsInternal)).HasColumnName("ISINTERNAL");
            builder.Property(nameof(AtlasModel.PayerDefinition.OnlineInvoice)).HasColumnName("ONLINEINVOICE");
            builder.Property(nameof(AtlasModel.PayerDefinition.CancelPatientShareAccTrx)).HasColumnName("CANCELPATIENTSHAREACCTRX");
            builder.Property(nameof(AtlasModel.PayerDefinition.PaymentDayLimit)).HasColumnName("PAYMENTDAYLIMIT");
            builder.Property(nameof(AtlasModel.PayerDefinition.HealthTourism)).HasColumnName("HEALTHTOURISM");
            builder.Property(nameof(AtlasModel.PayerDefinition.CityRef)).HasColumnName("CITY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PayerDefinition.TypeRef)).HasColumnName("TYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PayerDefinition.ParentPayerRef)).HasColumnName("PARENTPAYER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PayerDefinition.MedulaDevredilenKurumRef)).HasColumnName("MEDULADEVREDILENKURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PayerDefinition.RevenueSubAccountCodeRef)).HasColumnName("REVENUESUBACCOUNTCODE").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.TerminologyManagerDef).WithOne().HasForeignKey<AtlasModel.TerminologyManagerDef>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ParentPayer).WithOne().HasForeignKey<AtlasModel.PayerDefinition>(x => x.ParentPayerRef).IsRequired(false);
            builder.HasOne(t => t.MedulaDevredilenKurum).WithOne().HasForeignKey<AtlasModel.PayerDefinition>(x => x.MedulaDevredilenKurumRef).IsRequired(false);
            builder.HasOne(t => t.RevenueSubAccountCode).WithOne().HasForeignKey<AtlasModel.PayerDefinition>(x => x.RevenueSubAccountCodeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}