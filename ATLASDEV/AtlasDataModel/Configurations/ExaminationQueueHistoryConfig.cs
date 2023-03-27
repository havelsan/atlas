using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class ExaminationQueueHistoryConfig : IEntityTypeConfiguration<AtlasModel.ExaminationQueueHistory>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.ExaminationQueueHistory> builder)
        {
            builder.ToTable("EXAMINATIONQUEUEHISTORY");
            builder.HasKey(nameof(AtlasModel.ExaminationQueueHistory.ObjectId));
            builder.Property(nameof(AtlasModel.ExaminationQueueHistory.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.ExaminationQueueHistory.HistoryDate)).HasColumnName("HISTORYDATE");
            builder.Property(nameof(AtlasModel.ExaminationQueueHistory.ExaminationQueueItemRef)).HasColumnName("EXAMINATIONQUEUEITEM").HasMaxLength(36).IsFixedLength();

            #region Parent Relations
            builder.HasOne(t => t.ExaminationQueueItem).WithOne().HasForeignKey<AtlasModel.ExaminationQueueHistory>(x => x.ExaminationQueueItemRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}