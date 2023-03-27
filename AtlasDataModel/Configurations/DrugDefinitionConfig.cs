using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class DrugDefinitionConfig : IEntityTypeConfiguration<AtlasModel.DrugDefinition>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.DrugDefinition> builder)
        {
            builder.ToTable("DRUGDEFINITION");
            builder.HasKey(nameof(AtlasModel.DrugDefinition.ObjectId));
            builder.Property(nameof(AtlasModel.DrugDefinition.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.DrugDefinition.SPTSGroupName)).HasColumnName("SPTSGROUPNAME").HasMaxLength(255);
            builder.Property(nameof(AtlasModel.DrugDefinition.RoutineDay)).HasColumnName("ROUTINEDAY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDefinition.SPTSGroupID)).HasColumnName("SPTSGROUPID");
            builder.Property(nameof(AtlasModel.DrugDefinition.Frequency)).HasColumnName("FREQUENCY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.PrescriptionType)).HasColumnName("PRESCRIPTIONTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.EquivalentCRC)).HasColumnName("EQUIVALENTCRC").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DrugDefinition.MaxDoseDay)).HasColumnName("MAXDOSEDAY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDefinition.NoDoseCounting)).HasColumnName("NODOSECOUNTING");
            builder.Property(nameof(AtlasModel.DrugDefinition.MaxDose)).HasColumnName("MAXDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDefinition.Volume)).HasColumnName("VOLUME").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDefinition.Dose)).HasColumnName("DOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDefinition.OldIsArmyDrug)).HasColumnName("OLDISARMYDRUG");
            builder.Property(nameof(AtlasModel.DrugDefinition.RoutineDose)).HasColumnName("ROUTINEDOSE").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDefinition.PatientSafetyFrom)).HasColumnName("PATIENTSAFETYFROM");
            builder.Property(nameof(AtlasModel.DrugDefinition.WithOutStockInheld)).HasColumnName("WITHOUTSTOCKINHELD");
            builder.Property(nameof(AtlasModel.DrugDefinition.InfectionApproval)).HasColumnName("INFECTIONAPPROVAL");
            builder.Property(nameof(AtlasModel.DrugDefinition.ReimbursementUnder)).HasColumnName("REIMBURSEMENTUNDER");
            builder.Property(nameof(AtlasModel.DrugDefinition.ShowZeroOnDrugOrder)).HasColumnName("SHOWZEROONDRUGORDER");
            builder.Property(nameof(AtlasModel.DrugDefinition.MaxPatientAge)).HasColumnName("MAXPATIENTAGE");
            builder.Property(nameof(AtlasModel.DrugDefinition.MinPatientAge)).HasColumnName("MINPATIENTAGE");
            builder.Property(nameof(AtlasModel.DrugDefinition.DrugShapeType)).HasColumnName("DRUGSHAPETYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.IsPsychotropic)).HasColumnName("ISPSYCHOTROPIC");
            builder.Property(nameof(AtlasModel.DrugDefinition.IsNarcotic)).HasColumnName("ISNARCOTIC");
            builder.Property(nameof(AtlasModel.DrugDefinition.SgkReturnPay)).HasColumnName("SGKRETURNPAY");
            builder.Property(nameof(AtlasModel.DrugDefinition.Color)).HasColumnName("COLOR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.DrugNutrientInteraction)).HasColumnName("DRUGNUTRIENTINTERACTION").HasMaxLength(250);
            builder.Property(nameof(AtlasModel.DrugDefinition.VademecumProductID)).HasColumnName("VADEMECUMPRODUCTID");
            builder.Property(nameof(AtlasModel.DrugDefinition.Exportation)).HasColumnName("EXPORTATION");
            builder.Property(nameof(AtlasModel.DrugDefinition.AbroadProduct)).HasColumnName("ABROADPRODUCT");
            builder.Property(nameof(AtlasModel.DrugDefinition.FactoryPrice)).HasColumnName("FACTORYPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.DrugDefinition.StoragePrice)).HasColumnName("STORAGEPRICE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.DrugDefinition.InpatientReportType)).HasColumnName("INPATIENTREPORTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.OutpatientReportType)).HasColumnName("OUTPATIENTREPORTTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.OrderRPTDay)).HasColumnName("ORDERRPTDAY").HasColumnType("FLOAT");
            builder.Property(nameof(AtlasModel.DrugDefinition.SEX)).HasColumnName("SEX").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.AntibioticType)).HasColumnName("ANTIBIOTICTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.DrugDefinition.InstitutionDiscountRate)).HasColumnName("INSTITUTIONDISCOUNTRATE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.DrugDefinition.PharmacistDiscountRate)).HasColumnName("PHARMACISTDISCOUNTRATE").HasColumnType("NUMBER(15,2)");
            builder.Property(nameof(AtlasModel.DrugDefinition.IsITSDrug)).HasColumnName("ISITSDRUG");
            builder.Property(nameof(AtlasModel.DrugDefinition.DivisibleDrug)).HasColumnName("DIVISIBLEDRUG");
            builder.Property(nameof(AtlasModel.DrugDefinition.DoNotLeaveTheBarcode)).HasColumnName("DONOTLEAVETHEBARCODE");
            builder.Property(nameof(AtlasModel.DrugDefinition.NotAppearInEpicrisis)).HasColumnName("NOTAPPEARINEPICRISIS");
            builder.Property(nameof(AtlasModel.DrugDefinition.PaidPayment)).HasColumnName("PAIDPAYMENT");
            builder.Property(nameof(AtlasModel.DrugDefinition.SpecificationFile)).HasColumnName("SPECIFICATIONFILE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.SpecificationFileName)).HasColumnName("SPECIFICATIONFILENAME").HasMaxLength(50);
            builder.Property(nameof(AtlasModel.DrugDefinition.SpecificationUploadDate)).HasColumnName("SPECIFICATIONUPLOADDATE");
            builder.Property(nameof(AtlasModel.DrugDefinition.GenericDrugRef)).HasColumnName("GENERICDRUG").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.UnitRef)).HasColumnName("UNIT").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.NFCRef)).HasColumnName("NFC").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.RouteOfAdminRef)).HasColumnName("ROUTEOFADMIN").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.DrugTypeRef)).HasColumnName("DRUGTYPE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.PharmaceuticalFormDefRef)).HasColumnName("PHARMACEUTICALFORMDEF").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.EtkinMaddeRef)).HasColumnName("ETKINMADDE").HasMaxLength(36).IsFixedLength();
            builder.Property(nameof(AtlasModel.DrugDefinition.BaseDrugRef)).HasColumnName("BASEDRUG").HasMaxLength(36).IsFixedLength();
            builder.HasOne(t => t.Material).WithOne().HasForeignKey<AtlasModel.Material>(p => p.ObjectId);

            #region Parent Relations
            builder.HasOne(t => t.EtkinMadde).WithOne().HasForeignKey<AtlasModel.DrugDefinition>(x => x.EtkinMaddeRef).IsRequired(false);
            #endregion Parent Relations
        }
    }
}