using System;
using System.Collections.Generic;
using TTObjectClasses;

namespace AtlasModel
{
    public partial class SocServPatientFamilyInfo
    {
        public Guid ObjectId { get; set; }
        public string SickOrInjuredPlace { get; set; }
        public string SickOrInjuryType { get; set; }
        public DateTime? SickOrInjuryDate { get; set; }
        public string ShortEventStory { get; set; }
        public bool? AuxiliaryToolWheelchair { get; set; }
        public bool? AuxiliaryToolWalker { get; set; }
        public bool? AuxiliaryToolAfo { get; set; }
        public LivingHouseTypeEnum? LivingHouseBelonging { get; set; }
        public DoorEntranceTypesEnum? LivingHouseDoorEntrance { get; set; }
        public WCTypeEnum? LivingHouseWcType { get; set; }
        public string LivingHouseBelongingInfo { get; set; }
        public string FamilyIncomings { get; set; }
        public string SocioEconomicInfoEvaluation { get; set; }
        public string TransportationArrival { get; set; }
        public string TransportationGoing { get; set; }
        public string TransportationEvaluation { get; set; }
        public string FamilyInformation { get; set; }
        public string FamilyInformationEvaluation { get; set; }
        public string PhysicalStatus { get; set; }
        public string PatientRelatedWorks { get; set; }
        public string SubHeaders { get; set; }
        public bool? AuxiliaryToolHandSplint { get; set; }
        public bool? AuxiliaryToolTripod { get; set; }
        public bool? AuxiliaryToolArmRest { get; set; }
        public bool? AuxiliaryToolOther { get; set; }
        public string AuxiliaryToolOtherInfo { get; set; }
        public string WrittenMedicalMaterialOrTool { get; set; }
        public string RestState { get; set; }
        public string CompanionPhoneNum { get; set; }
        public string PatientLivesWith { get; set; }
        public string EmploymentRecordId { get; set; }
        public string PreviousJobBeforeIll { get; set; }
        public DateTime? DateOfStart { get; set; }
        public DateTime? DateOfRetire { get; set; }
        public string JobRightUseStatus { get; set; }
        public string WorkPlace { get; set; }
        public string LongTermArmBonusInterrupt { get; set; }
        public string SoldierRank { get; set; }
        public string SoldierPlaceOfWork { get; set; }
        public string SecondRetirementStatus { get; set; }
        public string Evaluation { get; set; }
        public DateTime? JobMilitaryServStartDate { get; set; }
        public DateTime? MilitaryServiceEndDate { get; set; }
        public string RecruitmentOffice { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public DateTime? ExactTransactionDate { get; set; }
        public string Companion { get; set; }
        public string LivingHouseType { get; set; }
        public int? LivingHouseNumOfFloor { get; set; }
        public VarYokEnum? LivingHouseElevator { get; set; }
        public int? LivingHouseBasement { get; set; }
        public YesNoEnum? LivingHouseEntrance { get; set; }
        public string PatientDiagnosis { get; set; }
        public string PatientPayerName { get; set; }
        public string DegreeOfWarVeteran { get; set; }
    }
}