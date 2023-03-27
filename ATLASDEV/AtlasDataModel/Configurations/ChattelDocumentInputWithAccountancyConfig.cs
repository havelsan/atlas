using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ChattelDocumentInputWithAccountancyConfig : IEntityTypeConfiguration<AtlasModel.ChattelDocumentInputWithAccountancy>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ChattelDocumentInputWithAccountancy> builder)
        {
            builder.ToTable("CHATTELDOCIWITHACCOUNTANCY");
            builder.HasKey(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.ObjectId));
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.ChattelOutDocumentGuid)).HasColumnName("CHATTELOUTDOCUMENTGUID").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.ActionRecordNo)).HasColumnName("ACTIONRECORDNO");
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.Waybill)).HasColumnName("WAYBILL").HasMaxLength(30);
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.WaybillDate)).HasColumnName("WAYBILLDATE");
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.inputWithAccountancyType)).HasColumnName("INPUTWITHACCOUNTANCYTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.AccountancyRef)).HasColumnName("ACCOUNTANCY").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.SupplierRef)).HasColumnName("SUPPLIER").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.ChattelDocumentInputWithAccountancy.InPatientPhysicianApplicationRef)).HasColumnName("INPATIENTPHYSICIANAPPLICATION").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.BaseChattelDocument).WithOne().HasForeignKey<AtlasModel.BaseChattelDocument>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.Accountancy).WithOne().HasForeignKey<AtlasModel.ChattelDocumentInputWithAccountancy>(x => x.AccountancyRef).IsRequired(true);
            builder.HasOne(t => t.Supplier).WithOne().HasForeignKey<AtlasModel.ChattelDocumentInputWithAccountancy>(x => x.SupplierRef).IsRequired(false);
            builder.HasOne(t => t.InPatientPhysicianApplication).WithOne().HasForeignKey<AtlasModel.ChattelDocumentInputWithAccountancy>(x => x.InPatientPhysicianApplicationRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}