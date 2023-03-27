using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class ResUser
    {
        public Guid ObjectId { get; set; }
        public string WorkPlace { get; set; }
        public string Work { get; set; }
        public string EmploymentRecordID { get; set; }
        public string LogonName { get; set; }
        public DateTime? DateOfPromotion { get; set; }
        public UserTitleEnum? Title { get; set; }
        public string PhoneNumber { get; set; }
        public string SpecialityRegistryNo { get; set; }
        public DateTime? DateOfLeave { get; set; }
        public UserTypeEnum? UserType { get; set; }
        public bool? Status { get; set; }
        public string DiplomaRegisterNo { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public string ExternalID { get; set; }
        public string DiplomaNo { get; set; }
        public bool? SentToMHRS { get; set; }
        public bool? StaffOfficer { get; set; }
        public bool? UsesESignature { get; set; }
        public string ErecetePassword { get; set; }
        public bool? TakesPerformanceScore { get; set; }
        public string MkysUserName { get; set; }
        public string MkysPassword { get; set; }
        public int? PreDischargeLimit { get; set; }
        public string TitleCode { get; set; }
        public string StatusDefinition { get; set; }
        public string EMail { get; set; }
        public string RecordType { get; set; }
        public string RecordCompany { get; set; }
        public string RecordCompanyCode { get; set; }
        public string RecordDefinition { get; set; }
        public string IntegrationId { get; set; }
        public string IntegrationVersion { get; set; }
        public string KPSUserName { get; set; }
        public string KPSPassword { get; set; }
        public bool? IsClinician { get; set; }
        public Guid? PersonRef { get; set; }
        public Guid? RankRef { get; set; }
        public Guid? MilitaryClassRef { get; set; }
        public Guid? UserDigitalSignatureRef { get; set; }
        public Guid? ForcesCommandRef { get; set; }
        public Guid? CKYSUserTypeRef { get; set; }
        public Guid? PACountRef { get; set; }
        public Guid? DoctorQuotaRef { get; set; }

        #region Base Object Navigation Property
        public virtual Resource Resource { get; set; }
        #endregion Base Object Navigation Property

        #region Parent Relations
        public virtual Person Person { get; set; }
        public virtual PatientAdmissionCount PACount { get; set; }
        public virtual DoctorQuotaDefinition DoctorQuota { get; set; }
        #endregion Parent Relations
    }
}