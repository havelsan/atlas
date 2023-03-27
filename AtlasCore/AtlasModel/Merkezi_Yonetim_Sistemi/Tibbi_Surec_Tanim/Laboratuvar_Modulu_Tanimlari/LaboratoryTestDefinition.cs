using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class LaboratoryTestDefinition
    {
        public Guid ObjectId { get; set; }
        public bool? IsMicrobiologyTest { get; set; }
        public LaboratoryResultTypeEnum? ResultType { get; set; }
        public bool? IsRestrictedTest { get; set; }
        public bool? IsSexControl { get; set; }
        public bool? IsPanel { get; set; }
        public bool? IsSat { get; set; }
        public bool? IsSubTest { get; set; }
        public bool? IsPrintEveryPage { get; set; }
        public long? RoundValue { get; set; }
        public bool? IsMoleculerTest { get; set; }
        public SexEnum? SexControl { get; set; }
        public LaboratoryResultUnitEnum? ResultUnit { get; set; }
        public bool? IsHeader { get; set; }
        public bool? IsMultiReference { get; set; }
        public bool? IsLoad { get; set; }
        public string ReasonForPassive { get; set; }
        public int? TabOrder { get; set; }
        public bool? IsPassiveNow { get; set; }
        public int? DurationValue { get; set; }
        public bool? IsDurationControl { get; set; }
        public bool? IsBoundedTest { get; set; }
        public bool? Is24HourTest { get; set; }
        public long? PriceCoefficient { get; set; }
        public bool? PrintInOneReport { get; set; }
        public bool? SendByRequestDoctor { get; set; }
        public bool? RequiresDiabetesForm { get; set; }
        public bool? NotLISTest { get; set; }
        public bool? RequiresBinaryScanForm { get; set; }
        public bool? RequiresTripleTestForm { get; set; }
        public bool? RequiresUreaBreathTestReport { get; set; }
        public string TabDescription { get; set; }
        public bool? SendOtherResultsToMedula { get; set; }
        public string FreeLOINCCode { get; set; }
        public bool? IsGroupTest { get; set; }
        public string TestDescription { get; set; }
        public Guid? TestUnitRef { get; set; }
        public Guid? EnvironmentRef { get; set; }
        public Guid? TestTubeRef { get; set; }
        public Guid? TestTypeRef { get; set; }
        public Guid? TestSubTypeRef { get; set; }
        public Guid? RequestFormTabRef { get; set; }
        public Guid? BranchRef { get; set; }
        public Guid? TahlilTipiRef { get; set; }
        public Guid? SexRef { get; set; }

        #region Base Object Navigation Property
        public virtual ProcedureDefinition ProcedureDefinition { get; set; }
        #endregion Base Object Navigation Property
    }
}