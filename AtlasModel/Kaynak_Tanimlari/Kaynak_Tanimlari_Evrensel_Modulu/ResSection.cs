using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResSection
    {
        public Guid ObjectId { get; set; }
        public int? AppointmentLimit { get; set; }
        public int? ActionCancelledTime { get; set; }
        public ResourceEnableType? EnabledType { get; set; }
        public int? AprilQuota { get; set; }
        public int? AugustQuota { get; set; }
        public int? JuneQuata { get; set; }
        public DateTime? LastQuotaDate { get; set; }
        public int? NovemberQuota { get; set; }
        public int? OctoberQuota { get; set; }
        public int? SeptemberQuota { get; set; }
        public int? WeeklyQuota { get; set; }
        public bool? DontShowHCDepartmentReport { get; set; }
        public string ContactPhone { get; set; }
        public bool? IsToBeConsultation { get; set; }
        public bool? IsEtiquettePrinted { get; set; }
        public int? EtiquetteCount { get; set; }
        public bool? PCSInUse { get; set; }
        public int? MarchQuota { get; set; }
        public int? DailyQuota { get; set; }
        public int? DecemberQuota { get; set; }
        public int? FebruaryQuota { get; set; }
        public int? JanuaryQuota { get; set; }
        public int? JulyQuota { get; set; }
        public int? MayQuota { get; set; }
        public int? MonthlyQuota { get; set; }
        public bool? NotChargeHCExaminationPrice { get; set; }
        public string ContactAddress { get; set; }
        public bool? IgnoreQuotaControl { get; set; }
        public int? InpatientQuota { get; set; }
        public bool? HimssRequired { get; set; }
        public bool? IsmedicalWaste { get; set; }
        public ResSectionTypeEnum? ResSectionType { get; set; }
        public DateTime? ResourceStartTime { get; set; }
        public DateTime? ResourceEndTime { get; set; }
        public int? OptionalDelayMinute { get; set; }
        public SexEnum? SexException { get; set; }
        public int? MaxAge { get; set; }
        public bool? DontTakeGSSProvision { get; set; }
        public int? MinAge { get; set; }
        public Guid? SaglikNetKlinikleriRef { get; set; }
        public Guid? TedaviTipiRef { get; set; }
        public Guid? TedaviTuruRef { get; set; }
        public Guid? TakipTipiRef { get; set; }

        #region Base Object Navigation Property
        public virtual Resource Resource { get; set; }
        #endregion Base Object Navigation Property
    }
}