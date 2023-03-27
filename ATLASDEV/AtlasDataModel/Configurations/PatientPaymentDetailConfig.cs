using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PatientPaymentDetailConfig : IEntityTypeConfiguration<AtlasModel.PatientPaymentDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PatientPaymentDetail> builder)
        {
            builder.ToTable("PATIENTPAYMENTDETAIL");
            builder.HasKey(nameof(AtlasModel.PatientPaymentDetail.ObjectId));
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.IsBack)).HasColumnName("ISBACK");
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.IsCancel)).HasColumnName("ISCANCEL");
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.Date)).HasColumnName("DATE");
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.PaymentPrice)).HasColumnName("PAYMENTPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.PaymentType)).HasColumnName("PAYMENTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.IsParticipationShare)).HasColumnName("ISPARTICIPATIONSHARE");
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.AccountTransactionRef)).HasColumnName("ACCOUNTTRANSACTION").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.PatientPaymentDetail.AccountDocumentRef)).HasColumnName("ACCOUNTDOCUMENT").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.AccountTransaction).WithOne().HasForeignKey<AtlasModel.PatientPaymentDetail>(x => x.AccountTransactionRef).IsRequired(false);
            builder.HasOne(t => t.AccountDocument).WithOne().HasForeignKey<AtlasModel.PatientPaymentDetail>(x => x.AccountDocumentRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}