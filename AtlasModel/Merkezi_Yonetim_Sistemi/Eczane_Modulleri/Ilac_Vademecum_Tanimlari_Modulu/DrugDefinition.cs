using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class DrugDefinition
    {
        public Guid ObjectId { get; set; }
        public string SPTSGroupName { get; set; }
        public double? RoutineDay { get; set; }
        public long? SPTSGroupID { get; set; }
        public FrequencyEnum? Frequency { get; set; }
        public PrescriptionTypeEnum? PrescriptionType { get; set; }
        public string EquivalentCRC { get; set; }
        public double? MaxDoseDay { get; set; }
        public bool? NoDoseCounting { get; set; }
        public double? MaxDose { get; set; }
        public double? Volume { get; set; }
        public double? Dose { get; set; }
        public bool? OldIsArmyDrug { get; set; }
        public double? RoutineDose { get; set; }
        public bool? PatientSafetyFrom { get; set; }
        public bool? WithOutStockInheld { get; set; }
        public bool? InfectionApproval { get; set; }
        public bool? ReimbursementUnder { get; set; }
        public bool? ShowZeroOnDrugOrder { get; set; }
        public int? MaxPatientAge { get; set; }
        public int? MinPatientAge { get; set; }
        public DrugShapeTypeEnum? DrugShapeType { get; set; }
        public bool? IsPsychotropic { get; set; }
        public bool? IsNarcotic { get; set; }
        public bool? SgkReturnPay { get; set; }
        public ColorEnum? Color { get; set; }
        public string DrugNutrientInteraction { get; set; }
        public long? VademecumProductID { get; set; }
        public bool? Exportation { get; set; }
        public bool? AbroadProduct { get; set; }
        public decimal? FactoryPrice { get; set; }
        public decimal? StoragePrice { get; set; }
        public DrugReportType? InpatientReportType { get; set; }
        public DrugReportType? OutpatientReportType { get; set; }
        public double? OrderRPTDay { get; set; }
        public SexEnum? SEX { get; set; }
        public AntibioticTypeEnum? AntibioticType { get; set; }
        public decimal? InstitutionDiscountRate { get; set; }
        public decimal? PharmacistDiscountRate { get; set; }
        public bool? IsITSDrug { get; set; }
        public bool? DivisibleDrug { get; set; }
        public bool? DoNotLeaveTheBarcode { get; set; }
        public bool? NotAppearInEpicrisis { get; set; }
        public bool? PaidPayment { get; set; }
        public Guid? SpecificationFile { get; set; }
        public string SpecificationFileName { get; set; }
        public DateTime? SpecificationUploadDate { get; set; }
        public Guid? GenericDrugRef { get; set; }
        public Guid? UnitRef { get; set; }
        public Guid? NFCRef { get; set; }
        public Guid? RouteOfAdminRef { get; set; }
        public Guid? DrugTypeRef { get; set; }
        public Guid? PharmaceuticalFormDefRef { get; set; }
        public Guid? EtkinMaddeRef { get; set; }
        public Guid? BaseDrugRef { get; set; }

        #region Base Object Navigation Property
        public virtual Material Material { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual EtkinMadde EtkinMadde { get; set; }
        #endregion Parent Relations
    }
}