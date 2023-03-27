using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class PeriodicOrderConfig : IEntityTypeConfiguration<AtlasModel.PeriodicOrder>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.PeriodicOrder> builder)
        {
            builder.ToTable("PERIODICORDER");
            builder.HasKey(nameof(AtlasModel.PeriodicOrder.ObjectId));
            builder.Property(nameof(AtlasModel.PeriodicOrder.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.PeriodicOrder.Frequency)).HasColumnName("FREQUENCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.PeriodicOrder.Weight)).HasColumnName("WEIGHT").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PeriodicOrder.RecurrenceDayAmount)).HasColumnName("RECURRENCEDAYAMOUNT");
            builder.Property(nameof(AtlasModel.PeriodicOrder.AmountForPeriod)).HasColumnName("AMOUNTFORPERIOD");
            builder.Property(nameof(AtlasModel.PeriodicOrder.PeriodStartTime)).HasColumnName("PERIODSTARTTIME");
            builder.Property(nameof(AtlasModel.PeriodicOrder.Heigth)).HasColumnName("HEIGTH").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.PeriodicOrder.OrderDate)).HasColumnName("ORDERDATE");
            builder.Property(nameof(AtlasModel.PeriodicOrder.OrderDescription)).HasColumnName("ORDERDESCRIPTION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.PeriodicOrder.ProcedureObjectRef)).HasColumnName("PROCEDUREOBJECT").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.EpisodeAction).WithOne().HasForeignKey<AtlasModel.EpisodeAction>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.ProcedureObject).WithOne().HasForeignKey<AtlasModel.PeriodicOrder>(x => x.ProcedureObjectRef).IsRequired(true);
            #endregion Parent Relations
        }
    }
}