using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class AccountTransactionConfig : IEntityTypeConfiguration<AtlasModel.AccountTransaction>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.AccountTransaction> builder)
        {
            builder.ToTable("ACCOUNTTRANSACTION");
            builder.HasKey(nameof(AtlasModel.AccountTransaction.ObjectId));
            builder.Property(nameof(AtlasModel.AccountTransaction.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.AccountTransaction.TotalDiscountPrice)).HasColumnName("TOTALDISCOUNTPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.AccountTransaction.UnitPrice)).HasColumnName("UNITPRICE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.AccountTransaction.ExternalCode)).HasColumnName("EXTERNALCODE").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.AccountTransaction.Amount)).HasColumnName("AMOUNT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.AccountTransaction.PackageOutReason)).HasColumnName("PACKAGEOUTREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountTransaction.Description)).HasColumnName("DESCRIPTION").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.AccountTransaction.TransactionDate)).HasColumnName("TRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.AccountTransaction.InvoiceInclusion)).HasColumnName("INVOICEINCLUSION");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaInfoChangedByUser)).HasColumnName("MEDULAINFOCHANGEDBYUSER");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaInfoUpdated)).HasColumnName("MEDULAINFOUPDATED");
            builder.Property(nameof(AtlasModel.AccountTransaction.UserNote)).HasColumnName("USERNOTE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaProcessNo)).HasColumnName("MEDULAPROCESSNO");
            builder.Property(nameof(AtlasModel.AccountTransaction.Id)).HasColumnName("ID");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaResultCode)).HasColumnName("MEDULARESULTCODE");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaResultMessage)).HasColumnName("MEDULARESULTMESSAGE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaPrice)).HasColumnName("MEDULAPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.AccountTransaction.UnitPriceOrg)).HasColumnName("UNITPRICEORG").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaDescription)).HasColumnName("MEDULADESCRIPTION").HasMaxLength(2000);
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaBedNo)).HasColumnName("MEDULABEDNO");
            builder.Property(nameof(AtlasModel.AccountTransaction.PurchaseDate)).HasColumnName("PURCHASEDATE");
            builder.Property(nameof(AtlasModel.AccountTransaction.Barcode)).HasColumnName("BARCODE");
            builder.Property(nameof(AtlasModel.AccountTransaction.ProducerCode)).HasColumnName("PRODUCERCODE");
            builder.Property(nameof(AtlasModel.AccountTransaction.Nabiz700Status)).HasColumnName("NABIZ700STATUS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountTransaction.NabizResultCode)).HasColumnName("NABIZRESULTCODE");
            builder.Property(nameof(AtlasModel.AccountTransaction.NabizResultMessage)).HasColumnName("NABIZRESULTMESSAGE").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.AccountTransaction.UTSUsageCommitment)).HasColumnName("UTSUSAGECOMMITMENT");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaAccessionNo)).HasColumnName("MEDULAACCESSIONNO");
            builder.Property(nameof(AtlasModel.AccountTransaction.MedulaDealerNo)).HasColumnName("MEDULADEALERNO");
            builder.Property(nameof(AtlasModel.AccountTransaction.Position)).HasColumnName("POSITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.AccountTransaction.ReceiptMaterialRef)).HasColumnName("RECEIPTMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.SubEpisodeProtocolRef)).HasColumnName("SUBEPISODEPROTOCOL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.SubActionMaterialRef)).HasColumnName("SUBACTIONMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.PatientInvoiceMaterialRef)).HasColumnName("PATIENTINVOICEMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.CollectedPatientListRef)).HasColumnName("COLLECTEDPATIENTLIST").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.PayerInvoicePackageRef)).HasColumnName("PAYERINVOICEPACKAGE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.PricingDetailRef)).HasColumnName("PRICINGDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.SubActionProcedureRef)).HasColumnName("SUBACTIONPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.ReceiptBackDetailRef)).HasColumnName("RECEIPTBACKDETAIL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.PayerInvoiceMaterialRef)).HasColumnName("PAYERINVOICEMATERIAL").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.PackageDefinitionRef)).HasColumnName("PACKAGEDEFINITION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.PatientInvoiceProcedureRef)).HasColumnName("PATIENTINVOICEPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.ReceiptProcedureRef)).HasColumnName("RECEIPTPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.AccountPayableReceivableRef)).HasColumnName("ACCOUNTPAYABLERECEIVABLE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.InpatientAdmissionRef)).HasColumnName("INPATIENTADMISSION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.PayerInvoiceProcedureRef)).HasColumnName("PAYERINVOICEPROCEDURE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.OzelDurumRef)).HasColumnName("OZELDURUM").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.AyniFarkliKesiRef)).HasColumnName("AYNIFARKLIKESI").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.DoctorRef)).HasColumnName("DOCTOR").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.StockOutTransactionRef)).HasColumnName("STOCKOUTTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.AccountTransaction.UTSNotificationDetailRef)).HasColumnName("UTSNOTIFICATIONDETAIL").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.SubEpisodeProtocol).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.SubEpisodeProtocolRef).IsRequired(true);
            builder.HasOne(t => t.SubActionMaterial).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.SubActionMaterialRef).IsRequired(false);
            builder.HasOne(t => t.PricingDetail).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.PricingDetailRef).IsRequired(false);
            builder.HasOne(t => t.SubActionProcedure).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.SubActionProcedureRef).IsRequired(false);
            builder.HasOne(t => t.ReceiptProcedure).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.ReceiptProcedureRef).IsRequired(false);
            builder.HasOne(t => t.AccountPayableReceivable).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.AccountPayableReceivableRef).IsRequired(true);
            builder.HasOne(t => t.InpatientAdmission).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.InpatientAdmissionRef).IsRequired(false);
            builder.HasOne(t => t.OzelDurum).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.OzelDurumRef).IsRequired(false);
            builder.HasOne(t => t.Doctor).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.DoctorRef).IsRequired(false);
            builder.HasOne(t => t.StockOutTransaction).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.StockOutTransactionRef).IsRequired(false);
            builder.HasOne(t => t.UTSNotificationDetail).WithOne().HasForeignKey<AtlasModel.AccountTransaction>(x => x.UTSNotificationDetailRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}