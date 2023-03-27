using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class SocServPatientFamilyInfoConfig : IEntityTypeConfiguration<AtlasModel.SocServPatientFamilyInfo>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.SocServPatientFamilyInfo> builder)
        {
            builder.ToTable("SOCSERVPATIENTFAMILYINFO");
            builder.HasKey(nameof(AtlasModel.SocServPatientFamilyInfo.ObjectId));
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SickOrInjuredPlace)).HasColumnName("SICKORINJUREDPLACE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SickOrInjuryType)).HasColumnName("SICKORINJURYTYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SickOrInjuryDate)).HasColumnName("SICKORINJURYDATE");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.ShortEventStory)).HasColumnName("SHORTEVENTSTORY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolWheelchair)).HasColumnName("AUXILIARYTOOLWHEELCHAIR");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolWalker)).HasColumnName("AUXILIARYTOOLWALKER");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolAfo)).HasColumnName("AUXILIARYTOOLAFO");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseBelonging)).HasColumnName("LIVINGHOUSEBELONGING").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseDoorEntrance)).HasColumnName("LIVINGHOUSEDOORENTRANCE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseWcType)).HasColumnName("LIVINGHOUSEWCTYPE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseBelongingInfo)).HasColumnName("LIVINGHOUSEBELONGINGINFO").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.FamilyIncomings)).HasColumnName("FAMILYINCOMINGS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SocioEconomicInfoEvaluation)).HasColumnName("SOCIOECONOMICINFOEVALUATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.TransportationArrival)).HasColumnName("TRANSPORTATIONARRIVAL").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.TransportationGoing)).HasColumnName("TRANSPORTATIONGOING").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.TransportationEvaluation)).HasColumnName("TRANSPORTATIONEVALUATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.FamilyInformation)).HasColumnName("FAMILYINFORMATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.FamilyInformationEvaluation)).HasColumnName("FAMILYINFORMATIONEVALUATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.PhysicalStatus)).HasColumnName("PHYSICALSTATUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.PatientRelatedWorks)).HasColumnName("PATIENTRELATEDWORKS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SubHeaders)).HasColumnName("SUBHEADERS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolHandSplint)).HasColumnName("AUXILIARYTOOLHANDSPLINT");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolTripod)).HasColumnName("AUXILIARYTOOLTRIPOD");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolArmRest)).HasColumnName("AUXILIARYTOOLARMREST");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolOther)).HasColumnName("AUXILIARYTOOLOTHER");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.AuxiliaryToolOtherInfo)).HasColumnName("AUXILIARYTOOLOTHERINFO").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.WrittenMedicalMaterialOrTool)).HasColumnName("WRITTENMEDICALMATERIALORTOOL").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.RestState)).HasColumnName("RESTSTATE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.CompanionPhoneNum)).HasColumnName("COMPANIONPHONENUM").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.PatientLivesWith)).HasColumnName("PATIENTLIVESWITH").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.EmploymentRecordId)).HasColumnName("EMPLOYMENTRECORDID").HasMaxLength(100);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.PreviousJobBeforeIll)).HasColumnName("PREVIOUSJOBBEFOREILL").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.DateOfStart)).HasColumnName("DATEOFSTART");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.DateOfRetire)).HasColumnName("DATEOFRETIRE");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.JobRightUseStatus)).HasColumnName("JOBRIGHTUSESTATUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.WorkPlace)).HasColumnName("WORKPLACE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LongTermArmBonusInterrupt)).HasColumnName("LONGTERMARMBONUSINTERRUPT").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SoldierRank)).HasColumnName("SOLDIERRANK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SoldierPlaceOfWork)).HasColumnName("SOLDIERPLACEOFWORK").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.SecondRetirementStatus)).HasColumnName("SECONDRETIREMENTSTATUS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.Evaluation)).HasColumnName("EVALUATION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.JobMilitaryServStartDate)).HasColumnName("JOBMILITARYSERVSTARTDATE");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.MilitaryServiceEndDate)).HasColumnName("MILITARYSERVICEENDDATE");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.RecruitmentOffice)).HasColumnName("RECRUITMENTOFFICE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.ApplicationDate)).HasColumnName("APPLICATIONDATE");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.ExactTransactionDate)).HasColumnName("EXACTTRANSACTIONDATE");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.Companion)).HasColumnName("COMPANION").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseType)).HasColumnName("LIVINGHOUSETYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseNumOfFloor)).HasColumnName("LIVINGHOUSENUMOFFLOOR");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseElevator)).HasColumnName("LIVINGHOUSEELEVATOR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseBasement)).HasColumnName("LIVINGHOUSEBASEMENT");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.LivingHouseEntrance)).HasColumnName("LIVINGHOUSEENTRANCE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.PatientDiagnosis)).HasColumnName("PATIENTDIAGNOSIS").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.PatientPayerName)).HasColumnName("PATIENTPAYERNAME").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.SocServPatientFamilyInfo.DegreeOfWarVeteran)).HasColumnName("DEGREEOFWARVETERAN").HasMaxLength(1000);
        }
    }
}