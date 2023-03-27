using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtlasDataModel.Configurations
{
    public partial class LowerExtremityConfig : IEntityTypeConfiguration<AtlasModel.LowerExtremity>
    {
        public void Configure(EntityTypeBuilder<AtlasModel.LowerExtremity> builder)
        {
            builder.ToTable("LOWEREXTREMITY");
            builder.HasKey(nameof(AtlasModel.LowerExtremity.ObjectId));
            builder.Property(nameof(AtlasModel.LowerExtremity.ObjectId)).HasColumnName("OBJECTID").HasMaxLength(36).IsRequired().IsFixedLength().ValueGeneratedNever();
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Myoelectric_Desc)).HasColumnName("UE_HD_MYOELECTRIC_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_CauseOfInjury)).HasColumnName("LE_CAUSEOFINJURY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_AmputationDate)).HasColumnName("LE_AMPUTATIONDATE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_ProsthesisNumber)).HasColumnName("LE_PROSTHESISNUMBER").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_ConstructionDate)).HasColumnName("LE_CONSTRUCTIONDATE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_ProstheticType)).HasColumnName("LE_PROSTHETICTYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_AmputationDate)).HasColumnName("UE_AMPUTATIONDATE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_CauseOfInjury)).HasColumnName("UE_CAUSEOFINJURY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_ConstructionDate)).HasColumnName("UE_CONSTRUCTIONDATE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_ProsthesisNumber)).HasColumnName("UE_PROSTHESISNUMBER").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_ProstheticType)).HasColumnName("UE_PROSTHETICTYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_FunctionalMovement_Desc)).HasColumnName("UE_HD_FUNCTIONALMOVEMENT_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_StumpZone)).HasColumnName("UE_HD_STUMPZONE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_StumpZone_Desc)).HasColumnName("UE_HD_STUMPZONE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Contracture)).HasColumnName("UE_HD_CONTRACTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Contracture_Desc)).HasColumnName("UE_HD_CONTRACTURE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Musculoskeletal)).HasColumnName("UE_HD_MUSCULOSKELETAL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Musculoskeletal_Desc)).HasColumnName("UE_HD_MUSCULOSKELETAL_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Neurological)).HasColumnName("UE_HD_NEUROLOGICAL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Neurological_Desc)).HasColumnName("UE_HD_NEUROLOGICAL_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Cardiovascular)).HasColumnName("UE_HD_CARDIOVASCULAR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Cardiovascular_Desc)).HasColumnName("UE_HD_CARDIOVASCULAR_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Pulmonary)).HasColumnName("UE_HD_PULMONARY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Pulmonary_Desc)).HasColumnName("UE_HD_PULMONARY_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_OrganFailure)).HasColumnName("UE_HD_ORGANFAILURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_OrganFailure_Desc)).HasColumnName("UE_HD_ORGANFAILURE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_SystemicDisease)).HasColumnName("UE_HD_SYSTEMICDISEASE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_SystemicDisease_Desc)).HasColumnName("UE_HD_SYSTEMICDISEASE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_Myoelectric)).HasColumnName("UE_HD_MYOELECTRIC").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_ProstheticType)).HasColumnName("UE_SK_PROSTHETICTYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_SK_ProstheticType)).HasColumnName("LE_SK_PROSTHETICTYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_PreferencePetition_Desc)).HasColumnName("UE_HD_PREFERENCEPETITION_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_SufficientStump_Desc)).HasColumnName("UE_HD_SUFFICIENTSTUMP_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_MedicalReason)).HasColumnName("LE_MEDICALREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_ThirdStepHealthInst)).HasColumnName("LE_THIRDSTEPHEALTHINST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_FTRExpertApprove)).HasColumnName("LE_FTREXPERTAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_OrthopedicExpertApprove)).HasColumnName("LE_ORTHOPEDICEXPERTAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_PsychiatricExpertApprove)).HasColumnName("LE_PSYCHIATRICEXPERTAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HeadDoctorApprove)).HasColumnName("LE_HEADDOCTORAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_PatientNameSurname)).HasColumnName("LE_PATIENTNAMESURNAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_MedulaInsCode)).HasColumnName("LE_MEDULAINSCODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_Date)).HasColumnName("LE_DATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_MedulaOrProtocolNo)).HasColumnName("LE_MEDULAORPROTOCOLNO").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_DiagnosAndICD10Code)).HasColumnName("LE_DIAGNOSANDICD10CODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_MachineName)).HasColumnName("LE_MACHINENAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_MachineNameIsCorrect)).HasColumnName("LE_MACHINENAMEISCORRECT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_WetSignature)).HasColumnName("LE_WETSIGNATURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_AktivityLevel)).HasColumnName("LE_HD_AKTIVITYLEVEL").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_PreferencePetition)).HasColumnName("LE_HD_PREFERENCEPETITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_StumpZone)).HasColumnName("LE_HD_STUMPZONE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_WeightTolerance)).HasColumnName("LE_HD_WEIGHTTOLERANCE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Contracture)).HasColumnName("LE_HD_CONTRACTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_SingleSideAmputate)).HasColumnName("LE_HD_SINGLESIDEAMPUTATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Ambulation)).HasColumnName("LE_HD_AMBULATION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Musculoskeletal)).HasColumnName("LE_HD_MUSCULOSKELETAL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Neurological)).HasColumnName("LE_HD_NEUROLOGICAL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Cardiovascular)).HasColumnName("LE_HD_CARDIOVASCULAR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Pulmonary)).HasColumnName("LE_HD_PULMONARY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_OrganFailure)).HasColumnName("LE_HD_ORGANFAILURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_SystemicDisease)).HasColumnName("LE_HD_SYSTEMICDISEASE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_WhichLevel)).HasColumnName("LE_TEM_WHICHLEVEL").HasColumnType("VARCHAR2(4000)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_OscillationandPosture)).HasColumnName("LE_TEM_OSCILLATIONANDPOSTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_WalkingSpeed)).HasColumnName("LE_TEM_WALKINGSPEED").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_StrideLength)).HasColumnName("LE_TEM_STRIDELENGTH").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_StepClimbing)).HasColumnName("LE_TEM_STEPCLIMBING").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_WalkBackwards)).HasColumnName("LE_TEM_WALKBACKWARDS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_Waterproof)).HasColumnName("LE_TEM_WATERPROOF").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Ambulation_Desc)).HasColumnName("LE_HD_AMBULATION_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Cardiovascular_Desc)).HasColumnName("LE_HD_CARDIOVASCULAR_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Contracture_Desc)).HasColumnName("LE_HD_CONTRACTURE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Musculoskeletal_Desc)).HasColumnName("LE_HD_MUSCULOSKELETAL_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Neurological_Desc)).HasColumnName("LE_HD_NEUROLOGICAL_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_OrganFailure_Desc)).HasColumnName("LE_HD_ORGANFAILURE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_PreferencePetition_Desc)).HasColumnName("LE_HD_PREFERENCEPETITION_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_Pulmonary_Desc)).HasColumnName("LE_HD_PULMONARY_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_SingleSideAmputate_Desc)).HasColumnName("LE_HD_SINGLESIDEAMPUTATE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_StumpZone_Desc)).HasColumnName("LE_HD_STUMPZONE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_SystemicDisease_Desc)).HasColumnName("LE_HD_SYSTEMICDISEASE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_HD_WeightTolerance_desc)).HasColumnName("LE_HD_WEIGHTTOLERANCE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_Oscillationand_Desc)).HasColumnName("LE_TEM_OSCILLATIONAND_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_StepClimbing_Desc)).HasColumnName("LE_TEM_STEPCLIMBING_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_StrideLength_Desc)).HasColumnName("LE_TEM_STRIDELENGTH_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_WalkBackwards_Desc)).HasColumnName("LE_TEM_WALKBACKWARDS_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_WalkingSpeed_Desc)).HasColumnName("LE_TEM_WALKINGSPEED_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.LE_TEM_Waterproof_Desc)).HasColumnName("LE_TEM_WATERPROOF_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_MedicalReason)).HasColumnName("UE_SK_MEDICALREASON").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_FTRExpertApprove)).HasColumnName("UE_SK_FTREXPERTAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_HeadDoctorApprove)).HasColumnName("UE_SK_HEADDOCTORAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_OrthopedicExpApprove)).HasColumnName("UE_SK_ORTHOPEDICEXPAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_PsychiatricExpApprove)).HasColumnName("UE_SK_PSYCHIATRICEXPAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_sEMG)).HasColumnName("UE_SK_SEMG").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_SK_ThirdStepHealthInst)).HasColumnName("UE_SK_THIRDSTEPHEALTHINST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_PatientNameSurname)).HasColumnName("UE_RI_PATIENTNAMESURNAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_MedulaInsCode)).HasColumnName("UE_RI_MEDULAINSCODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_Date)).HasColumnName("UE_RI_DATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_MedulaOrProtocolNo)).HasColumnName("UE_RI_MEDULAORPROTOCOLNO").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_MachineName)).HasColumnName("UE_RI_MACHINENAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_DiagnosAndICD10Code)).HasColumnName("UE_RI_DIAGNOSANDICD10CODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_MachineNameIsCorrect)).HasColumnName("UE_RI_MACHINENAMEISCORRECT").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_RI_WetSignature)).HasColumnName("UE_RI_WETSIGNATURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_AmputationLevel)).HasColumnName("UE_HD_AMPUTATIONLEVEL").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_StumpLength)).HasColumnName("UE_HD_STUMPLENGTH");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_PreferencePetition)).HasColumnName("UE_HD_PREFERENCEPETITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_SufficientStumpLength)).HasColumnName("UE_HD_SUFFICIENTSTUMPLENGTH").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_SingleSideAmputate)).HasColumnName("UE_HD_SINGLESIDEAMPUTATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_SingleSideAmputate_Desc)).HasColumnName("UE_HD_SINGLESIDEAMPUTATE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.UE_HD_FunctionalMovements)).HasColumnName("UE_HD_FUNCTIONALMOVEMENTS").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_CauseOfInjury)).HasColumnName("ATS_CAUSEOFINJURY").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_ChairNumber)).HasColumnName("ATS_CHAIRNUMBER").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_DeliveryDate)).HasColumnName("ATS_DELIVERYDATE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_ChairType)).HasColumnName("ATS_CHAIRTYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_SK_ChairType)).HasColumnName("ATS_SK_CHAIRTYPE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_SK_MedicalReason)).HasColumnName("ATS_SK_MEDICALREASON").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_SK_ThirdStepHealthInst)).HasColumnName("ATS_SK_THIRDSTEPHEALTHINST").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_SK_FTRExpertApprove)).HasColumnName("ATS_SK_FTREXPERTAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_SK_OrthopedicExpApprove)).HasColumnName("ATS_SK_ORTHOPEDICEXPAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_SK_HeadDoctorApprove)).HasColumnName("ATS_SK_HEADDOCTORAPPROVE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_RI_Date)).HasColumnName("ATS_RI_DATE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_RI_DiagnosAndICD10Code)).HasColumnName("ATS_RI_DIAGNOSANDICD10CODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_RI_MachineName)).HasColumnName("ATS_RI_MACHINENAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_RI_MedulaInsCode)).HasColumnName("ATS_RI_MEDULAINSCODE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_RI_MedulaOrProtocolNo)).HasColumnName("ATS_RI_MEDULAORPROTOCOLNO").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_RI_PatientNameSurname)).HasColumnName("ATS_RI_PATIENTNAMESURNAME").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_RI_WetSignature)).HasColumnName("ATS_RI_WETSIGNATURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_ChairDistance)).HasColumnName("ATS_HD_CHAIRDISTANCE").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_INTRACOMMUNITY)).HasColumnName("ATS_HD_INTRACOMMUNITY");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Therapeutic)).HasColumnName("ATS_HD_THERAPEUTIC");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_NOAMBULATION)).HasColumnName("ATS_HD_NOAMBULATION");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_USELOWEREXTREMITIES)).HasColumnName("ATS_HD_USELOWEREXTREMITIES").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_UseLowerExtremity_Desc)).HasColumnName("ATS_HD_USELOWEREXTREMITY_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_ConstantCondition)).HasColumnName("ATS_HD_CONSTANTCONDITION").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_ChairModel)).HasColumnName("ATS_HD_CHAIRMODEL").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_UseHimself)).HasColumnName("ATS_HD_USEHIMSELF").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Deformity)).HasColumnName("ATS_HD_DEFORMITY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Contracture)).HasColumnName("ATS_HD_CONTRACTURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Cardiovascular)).HasColumnName("ATS_HD_CARDIOVASCULAR").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Pulmonary)).HasColumnName("ATS_HD_PULMONARY").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_OrganFailure)).HasColumnName("ATS_HD_ORGANFAILURE").HasColumnType("NUMBER(10)");
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_ConstantCondition_Desc)).HasColumnName("ATS_HD_CONSTANTCONDITION_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_ChairModel_Desc)).HasColumnName("ATS_HD_CHAIRMODEL_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_UseHimself_Desc)).HasColumnName("ATS_HD_USEHIMSELF_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Deformity_Desc)).HasColumnName("ATS_HD_DEFORMITY_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Contracture_Desc)).HasColumnName("ATS_HD_CONTRACTURE_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Cardiovascular_Desc)).HasColumnName("ATS_HD_CARDIOVASCULAR_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_Pulmonary_Desc)).HasColumnName("ATS_HD_PULMONARY_DESC").HasMaxLength(1000);
            builder.Property(nameof(AtlasModel.LowerExtremity.ATS_HD_OrganFailure_Desc)).HasColumnName("ATS_HD_ORGANFAILURE_DESC").HasMaxLength(1000);
            builder.HasOne(t => t.BaseHCExaminationDynamicObject).WithOne().HasForeignKey<AtlasModel.BaseHCExaminationDynamicObject>(p => p.ObjectId);
        }
    }
}