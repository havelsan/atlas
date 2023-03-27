using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class NursingOrderTemplateDetailConfig : IEntityTypeConfiguration<AtlasModel.NursingOrderTemplateDetail>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.NursingOrderTemplateDetail> builder)
        {
            builder.ToTable("NURSINGORDERTEMPLATEDETAIL");
            builder.HasKey(nameof(AtlasModel.NursingOrderTemplateDetail.ObjectId));
            builder.Property(nameof(AtlasModel.NursingOrderTemplateDetail.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.NursingOrderTemplateDetail.AmountForPeriod)).HasColumnName("AMOUNTFORPERIOD");
            builder.Property(nameof(AtlasModel.NursingOrderTemplateDetail.Frequency)).HasColumnName("FREQUENCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.NursingOrderTemplateDetail.RecurrenceDayAmount)).HasColumnName("RECURRENCEDAYAMOUNT");
            builder.Property(nameof(AtlasModel.NursingOrderTemplateDetail.NursingOrderObjectRef)).HasColumnName("NURSINGORDEROBJECT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.NursingOrderTemplateDetail.NursingOrderTemplateRef)).HasColumnName("NURSINGORDERTEMPLATE").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.NursingOrderObject).WithOne().HasForeignKey<AtlasModel.NursingOrderTemplateDetail>(x => x.NursingOrderObjectRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}