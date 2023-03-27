
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    public partial class SocialServicesAppliedProceduresReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public string TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue("");
        }

        public partial class HeaderGroup : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public HeaderGroupHeader Header()
            {
                return (HeaderGroupHeader)_header;
            }

            new public HeaderGroupFooter Footer()
            {
                return (HeaderGroupFooter)_footer;
            }

            public TTReportField XXXXXXBASLIK11 { get {return Header().XXXXXXBASLIK11;} }
            public TTReportField REPORTHEADER111 { get {return Header().REPORTHEADER111;} }
            public TTReportField LOGO { get {return Header().LOGO;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public TTReportField ProcedureByUser { get {return Footer().ProcedureByUser;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public HeaderGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public HeaderGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>("GetSocServAppliedProcedures", SocServAppliedProcedures.GetSocServAppliedProcedures((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new HeaderGroupHeader(this);
                _footer = new HeaderGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class HeaderGroupHeader : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField XXXXXXBASLIK11;
                public TTReportField REPORTHEADER111;
                public TTReportField LOGO; 
                public HeaderGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 52;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    XXXXXXBASLIK11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 40, 4, 205, 39, false);
                    XXXXXXBASLIK11.Name = "XXXXXXBASLIK11";
                    XXXXXXBASLIK11.FieldType = ReportFieldTypeEnum.ftExpression;
                    XXXXXXBASLIK11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    XXXXXXBASLIK11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    XXXXXXBASLIK11.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXBASLIK11.TextFont.Size = 14;
                    XXXXXXBASLIK11.TextFont.Bold = true;
                    XXXXXXBASLIK11.TextFont.CharSet = 162;
                    XXXXXXBASLIK11.Value = @"TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALNAME"", """") + ""\r\n"" + TTObjectClasses.SystemParameter.GetParameterValue(""HOSPITALCITY"", """")";

                    REPORTHEADER111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 40, 189, 46, false);
                    REPORTHEADER111.Name = "REPORTHEADER111";
                    REPORTHEADER111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPORTHEADER111.TextFont.Size = 12;
                    REPORTHEADER111.TextFont.Bold = true;
                    REPORTHEADER111.TextFont.CharSet = 162;
                    REPORTHEADER111.Value = @"Hastaya Yapılan İşlem Listesi";

                    LOGO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 5, 16, 35, 39, false);
                    LOGO.Name = "LOGO";
                    LOGO.FieldType = ReportFieldTypeEnum.ftOLE;
                    LOGO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    LOGO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LOGO.ExpandTabs = EvetHayirEnum.ehEvet;
                    LOGO.ObjectDefName = "HospitalEmblemDefinition";
                    LOGO.DataMember = "EMBLEM";
                    LOGO.TextFont.Name = "Courier New";
                    LOGO.TextFont.CharSet = 162;
                    LOGO.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = ParentGroup.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    REPORTHEADER111.CalcValue = REPORTHEADER111.Value;
                    LOGO.CalcValue = @"";
                    XXXXXXBASLIK11.CalcValue = TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALNAME", "") + "\r\n" + TTObjectClasses.SystemParameter.GetParameterValue("HOSPITALCITY", "");
                    return new TTReportObject[] { REPORTHEADER111,LOGO,XXXXXXBASLIK11};
                }

                public override void RunScript()
                {
#region HEADER HEADER_Script
                    this.LOGO.CalcValue = TTObjectClasses.Common.GetCurrentHospitalLogo();
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);

                    if (dataset_GetSocServAppliedProcedures.ProvidingAccomodation != null && dataset_GetSocServAppliedProcedures.ProvidingAccomodation != false)
                    {
                        MyParentReport.MAIN.chkProvidingAccomodation.Value = "X";
                    }
                    else
                    {
                        MyParentReport.MAIN.chkProvidingAccomodation.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ProvideInternalSecInjStatDoc != null && dataset_GetSocServAppliedProcedures.ProvideInternalSecInjStatDoc != false)
                    {
                        MyParentReport.MAIN.chkProvideInternalSecInjStatDoc.Value = "X";
                    }
                    else
                    {
                        MyParentReport.MAIN.chkProvideInternalSecInjStatDoc.Value = "";
                        MyParentReport.MAIN.PROVIDEINTERSECINJSTATDOCINFO.Visible = EvetHayirEnum.ehHayir;
                    }
                    if (dataset_GetSocServAppliedProcedures.ProvisionIssues != null && dataset_GetSocServAppliedProcedures.ProvisionIssues != false)
                    {
                        MyParentReport.MAIN.chkProvisionIssues.Value = "X";
                    }
                    else
                    {
                        MyParentReport.MAIN.chkProvisionIssues.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.WeeklyTeamMeetings != null && dataset_GetSocServAppliedProcedures.WeeklyTeamMeetings != false)
                    {
                        MyParentReport.group2.chkWeeklyTeamMeetings.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group2.chkWeeklyTeamMeetings.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.WeeklyVisitAttendence != null && dataset_GetSocServAppliedProcedures.WeeklyVisitAttendence != false)
                    {
                        MyParentReport.group2.chkWeeklyVisitAttendence.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group2.chkWeeklyVisitAttendence.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.CalcAndFollowRestProc != null && dataset_GetSocServAppliedProcedures.CalcAndFollowRestProc != false)
                    {
                        MyParentReport.group3.chkCalcAndFollowRestProc.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group3.chkCalcAndFollowRestProc.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.InformAndDirectRetireProc != null && dataset_GetSocServAppliedProcedures.InformAndDirectRetireProc != false)
                    {
                        MyParentReport.group3.chkInformAndDirectRetireProc.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group3.chkInformAndDirectRetireProc.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.MedicEqProcRefundInfoProcure != null && dataset_GetSocServAppliedProcedures.MedicEqProcRefundInfoProcure != false)
                    {
                        MyParentReport.group3.chkMedicEqProcRefundInfoProcure.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group3.chkMedicEqProcRefundInfoProcure.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.DonatedMedicalSupplyProcure != null && dataset_GetSocServAppliedProcedures.DonatedMedicalSupplyProcure != false)
                    {
                        MyParentReport.group3.chkDonatedMedicalSupplyProcure.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group3.chkDonatedMedicalSupplyProcure.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GuidanceOnDrugSupplyAbroad != null && dataset_GetSocServAppliedProcedures.GuidanceOnDrugSupplyAbroad != false)
                    {
                        MyParentReport.group3.chkGuidanceOnDrugSupplyAbroad.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group3.chkGuidanceOnDrugSupplyAbroad.Value = "";
                    }


                    if (dataset_GetSocServAppliedProcedures.BenefitingFromDonations != null && dataset_GetSocServAppliedProcedures.BenefitingFromDonations != false)
                    {
                        MyParentReport.group4.chkBenefitingFromDonations.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group4.chkBenefitingFromDonations.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GuidanceToFoundations != null && dataset_GetSocServAppliedProcedures.GuidanceToFoundations != false)
                    {
                        MyParentReport.group4.chkGuidanceToFoundations.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group4.chkGuidanceToFoundations.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GuidanceToCivilOrganizations != null && dataset_GetSocServAppliedProcedures.GuidanceToCivilOrganizations != false)
                    {
                        MyParentReport.group4.chkGuidanceToCivilOrganizations.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group4.chkGuidanceToCivilOrganizations.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GuidanceAboutCareSalary != null && dataset_GetSocServAppliedProcedures.GuidanceAboutCareSalary != false)
                    {
                        MyParentReport.group5.chkGuidanceAboutCareSalary.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group5.chkGuidanceAboutCareSalary.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GuidanceAboutLaw != null && dataset_GetSocServAppliedProcedures.GuidanceAboutLaw != false)
                    {
                        MyParentReport.group5.chkGuidanceAboutLaw.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group5.chkGuidanceAboutLaw.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GuidanceAboutHomeHealthCare != null && dataset_GetSocServAppliedProcedures.GuidanceAboutHomeHealthCare != false)
                    {
                        MyParentReport.group5.chkGuidanceAboutHomeHealthCare.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group5.chkGuidanceAboutHomeHealthCare.Value = "";
                    }

                    if (dataset_GetSocServAppliedProcedures.PhoneCallWitPublicInstitution != null && dataset_GetSocServAppliedProcedures.PhoneCallWitPublicInstitution != false)
                    {
                        MyParentReport.group6.chkPhoneCallWitPublicInstitution.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group6.chkPhoneCallWitPublicInstitution.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.LegislativeReviewAndInfo != null && dataset_GetSocServAppliedProcedures.LegislativeReviewAndInfo != false)
                    {
                        MyParentReport.group6.chkLegislativeReviewAndInfo.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group6.chkLegislativeReviewAndInfo.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GuidanceToPublicInstitution != null && dataset_GetSocServAppliedProcedures.GuidanceToPublicInstitution != false)
                    {
                        MyParentReport.group6.chkGuidanceToPublicInstitution.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group6.chkGuidanceToPublicInstitution.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.CoordWarVeteranContactUnit != null && dataset_GetSocServAppliedProcedures.CoordWarVeteranContactUnit != false)
                    {
                        MyParentReport.group6.chkCoordWarVeteranContactUnit.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group6.chkCoordWarVeteranContactUnit.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ArrangementOfLivingPlaces != null && dataset_GetSocServAppliedProcedures.ArrangementOfLivingPlaces != false)
                    {
                        MyParentReport.group7.chkArrangementOfLivingPlaces.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group7.chkArrangementOfLivingPlaces.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ArrangementOfWorkSchoolEnv != null && dataset_GetSocServAppliedProcedures.ArrangementOfWorkSchoolEnv != false)
                    {
                        MyParentReport.group7.chkArrangementOfWorkSchoolEnv.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group7.chkArrangementOfWorkSchoolEnv.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.IntraCityTransportProcesses != null && dataset_GetSocServAppliedProcedures.IntraCityTransportProcesses != false)
                    {
                        MyParentReport.group8.chkIntraCityTransportProcesses.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group8.chkIntraCityTransportProcesses.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.InterCityTransportProcesses != null && dataset_GetSocServAppliedProcedures.InterCityTransportProcesses != false)
                    {
                        MyParentReport.group8.chkInterCityTransportProcesses.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group8.chkInterCityTransportProcesses.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.IdentificationOfParticipants != null && dataset_GetSocServAppliedProcedures.IdentificationOfParticipants != false)
                    {
                        MyParentReport.group10.chkIdentificationOfParticipants.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group10.chkIdentificationOfParticipants.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.OrganizingPermitDocuments != null && dataset_GetSocServAppliedProcedures.OrganizingPermitDocuments != false)
                    {
                        MyParentReport.group10.chkOrganizingPermitDocuments.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group10.chkOrganizingPermitDocuments.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.HealthAid != null && dataset_GetSocServAppliedProcedures.HealthAid != false)
                    {
                        MyParentReport.group11.chkHealthAid.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group11.chkHealthAid.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.AdvancePayment != null && dataset_GetSocServAppliedProcedures.AdvancePayment != false)
                    {
                        MyParentReport.group11.chkAdvancePayment.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group11.chkAdvancePayment.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.IndemnityCompensation != null && dataset_GetSocServAppliedProcedures.IndemnityCompensation != false)
                    {
                        MyParentReport.group11.chkIndemnityCompensation.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group11.chkIndemnityCompensation.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.AllowancePayment != null && dataset_GetSocServAppliedProcedures.AllowancePayment != false)
                    {
                        MyParentReport.group11.chkAllowancePayment.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group11.chkAllowancePayment.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GivingVeteranRightsBrochure != null && dataset_GetSocServAppliedProcedures.GivingVeteranRightsBrochure != false)
                    {
                        MyParentReport.group11.chkGivingVeteranRightsBrochure.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group11.chkGivingVeteranRightsBrochure.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.CashIdemnityTransactions != null && dataset_GetSocServAppliedProcedures.CashIdemnityTransactions != false)
                    {
                        MyParentReport.group12.chkCashIdemnityTransactions.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkCashIdemnityTransactions.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.XXXXXXSolidarityFoundationAid != null && dataset_GetSocServAppliedProcedures.XXXXXXSolidarityFoundationAid != false)
                    {
                        MyParentReport.group12.chkXXXXXXSolidarityFoundationAid.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkXXXXXXSolidarityFoundationAid.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.SoldierFoundationAid != null && dataset_GetSocServAppliedProcedures.SoldierFoundationAid != false)
                    {
                        MyParentReport.group12.chkSoldierFoundationAid.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkSoldierFoundationAid.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.SoldierLifeInsurance != null && dataset_GetSocServAppliedProcedures.SoldierLifeInsurance != false)
                    {
                        MyParentReport.group12.chkSoldierLifeInsurance.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkSoldierLifeInsurance.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.OYAKAid != null && dataset_GetSocServAppliedProcedures.OYAKAid != false)
                    {
                        MyParentReport.group12.chkOYAKAid.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkOYAKAid.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.JobResumeStatus != null && dataset_GetSocServAppliedProcedures.JobResumeStatus != false)
                    {
                        MyParentReport.group12.chkJobResumeStatus.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkJobResumeStatus.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.StatePrideMedal != null && dataset_GetSocServAppliedProcedures.StatePrideMedal != false)
                    {
                        MyParentReport.group12.chkStatePrideMedal.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkStatePrideMedal.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.SalaryStartBySGK != null && dataset_GetSocServAppliedProcedures.SalaryStartBySGK != false)
                    {
                        MyParentReport.group12.chkSalaryStartBySGK.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkSalaryStartBySGK.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.RetirementBonusBySGK != null && dataset_GetSocServAppliedProcedures.RetirementBonusBySGK != false)
                    {
                        MyParentReport.group12.chkRetirementBonusBySGK.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkRetirementBonusBySGK.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.SupplementaryPaymentSGK != null && dataset_GetSocServAppliedProcedures.SupplementaryPaymentSGK != false)
                    {
                        MyParentReport.group12.chkSupplementaryPaymentSGK.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkSupplementaryPaymentSGK.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.EducationAidBySGK != null && dataset_GetSocServAppliedProcedures.EducationAidBySGK != false)
                    {
                        MyParentReport.group12.chkEducationAidBySGK.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkEducationAidBySGK.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GrantingEmploymentRights != null && dataset_GetSocServAppliedProcedures.GrantingEmploymentRights != false)
                    {
                        MyParentReport.group12.chkGrantingEmploymentRights.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkGrantingEmploymentRights.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ProvidingWarVeteranCard != null && dataset_GetSocServAppliedProcedures.ProvidingWarVeteranCard != false)
                    {
                        MyParentReport.group12.chkProvidingWarVeteranCard.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkProvidingWarVeteranCard.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.UtilizationOfPublicHousing != null && dataset_GetSocServAppliedProcedures.UtilizationOfPublicHousing != false)
                    {
                        MyParentReport.group12.chkUtilizationOfPublicHousing.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group12.chkUtilizationOfPublicHousing.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ProvideHouseToDisabledStaff != null && dataset_GetSocServAppliedProcedures.ProvideHouseToDisabledStaff != false)
                    {
                        MyParentReport.group13.chkProvideHouseToDisabledStaff.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkProvideHouseToDisabledStaff.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GivingCorporateHousingCredit != null && dataset_GetSocServAppliedProcedures.GivingCorporateHousingCredit != false)
                    {
                        MyParentReport.group13.chkGivingCorporateHousingCredit.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkGivingCorporateHousingCredit.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.UsageRightFromTOKIHouses != null && dataset_GetSocServAppliedProcedures.UsageRightFromTOKIHouses != false)
                    {
                        MyParentReport.group13.chkUsageRightFromTOKIHouses.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkUsageRightFromTOKIHouses.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.IncomeTaxDiscount != null && dataset_GetSocServAppliedProcedures.IncomeTaxDiscount != false)
                    {
                        MyParentReport.group13.chkIncomeTaxDiscount.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkIncomeTaxDiscount.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ResidenceTaxExemption != null && dataset_GetSocServAppliedProcedures.ResidenceTaxExemption != false)
                    {
                        MyParentReport.group13.chkResidenceTaxExemption.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkResidenceTaxExemption.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ElectricAndWaterDiscount != null && dataset_GetSocServAppliedProcedures.ElectricAndWaterDiscount != false)
                    {
                        MyParentReport.group13.chkElectricAndWaterDiscount.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkElectricAndWaterDiscount.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.ImportingDutyFreeVehicle != null && dataset_GetSocServAppliedProcedures.ImportingDutyFreeVehicle != false)
                    {
                        MyParentReport.group13.chkImportingDutyFreeVehicle.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkImportingDutyFreeVehicle.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.DomesticVehiclePurchases != null && dataset_GetSocServAppliedProcedures.DomesticVehiclePurchases != false)
                    {
                        MyParentReport.group13.chkDomesticVehiclePurchases.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkDomesticVehiclePurchases.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.OTVandMTVExemption != null && dataset_GetSocServAppliedProcedures.OTVandMTVExemption != false)
                    {
                        MyParentReport.group13.chkOTVandMTVExemption.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkOTVandMTVExemption.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.BrotherExemptionFromMilitary != null && dataset_GetSocServAppliedProcedures.BrotherExemptionFromMilitary != false)
                    {
                        MyParentReport.group13.chkBrotherExemptionFromMilitary.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkBrotherExemptionFromMilitary.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.MilitaryServiceNearBrotherHom != null && dataset_GetSocServAppliedProcedures.MilitaryServiceNearBrotherHom != false)
                    {
                        MyParentReport.group13.chkMilitaryServiceNearBrotherHom.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkMilitaryServiceNearBrotherHom.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.FreeAccessToPrivateEduInstit != null && dataset_GetSocServAppliedProcedures.FreeAccessToPrivateEduInstit != false)
                    {
                        MyParentReport.group13.chkFreeAccessToPrivateEduInstit.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkFreeAccessToPrivateEduInstit.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.WeaponPortageTransportLicense != null && dataset_GetSocServAppliedProcedures.WeaponPortageTransportLicense != false)
                    {
                        MyParentReport.group13.chkWeaponPortageTransportLicense.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkWeaponPortageTransportLicense.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.UtilityFromRehabilitationCent != null && dataset_GetSocServAppliedProcedures.UtilityFromRehabilitationCent != false)
                    {
                        MyParentReport.group13.chkUtilityFromRehabilitationCent.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkUtilityFromRehabilitationCent.Value = "";
                    }
                    if (dataset_GetSocServAppliedProcedures.GrantingDealership != null && dataset_GetSocServAppliedProcedures.GrantingDealership != false)
                    {
                        MyParentReport.group13.chkGrantingDealership.Value = "X";
                    }
                    else
                    {
                        MyParentReport.group13.chkGrantingDealership.Value = "";
                    }
#endregion HEADER HEADER_Script
                }
            }
            public partial class HeaderGroupFooter : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField ProcedureByUser;
                public TTReportField NewField121; 
                public HeaderGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 29;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 8, 184, 13, false);
                    NewField1.Name = "NewField1";
                    NewField1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1.Value = @"İmza";

                    ProcedureByUser = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 14, 208, 19, false);
                    ProcedureByUser.Name = "ProcedureByUser";
                    ProcedureByUser.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ProcedureByUser.ObjectDefName = "UserTitleEnum";
                    ProcedureByUser.DataMember = "Description";
                    ProcedureByUser.TextFont.Size = 11;
                    ProcedureByUser.TextFont.CharSet = 162;
                    ProcedureByUser.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 157, 20, 187, 25, false);
                    NewField121.Name = "NewField121";
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"Sosyal Hizmet Uzmanı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = ParentGroup.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    ProcedureByUser.CalcValue = ProcedureByUser.Value;
                    NewField121.CalcValue = NewField121.Value;
                    return new TTReportObject[] { NewField1,ProcedureByUser,NewField121};
                }

                public override void RunScript()
                {
#region HEADER FOOTER_Script
                    TTObjectContext objectContext = new TTObjectContext(true);             
            SocServAppliedProcedures appliedProcedures = (SocServAppliedProcedures)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), "SocServAppliedProcedures");
             this.ProcedureByUser.CalcValue = appliedProcedures.PatientInterviewForm[0].ProcedureByUser.Name;
#endregion HEADER FOOTER_Script
                }
            }

        }

        public HeaderGroup Header;

        public partial class PatienInfoGroup : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public PatienInfoGroupBody Body()
            {
                return (PatienInfoGroupBody)_body;
            }
            public TTReportField Field1 { get {return Body().Field1;} }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NameSurname { get {return Body().NameSurname;} }
            public TTReportField UniqueRefNo { get {return Body().UniqueRefNo;} }
            public TTReportField NewField1111 { get {return Body().NewField1111;} }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField BirthPlace { get {return Body().BirthPlace;} }
            public TTReportField BirthDate { get {return Body().BirthDate;} }
            public TTReportField NewField11111 { get {return Body().NewField11111;} }
            public TTReportField NewField112 { get {return Body().NewField112;} }
            public TTReportField PhoneNum { get {return Body().PhoneNum;} }
            public TTReportField Address { get {return Body().Address;} }
            public TTReportField NewField11112 { get {return Body().NewField11112;} }
            public PatienInfoGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PatienInfoGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new PatienInfoGroupBody(this);
            }

            public partial class PatienInfoGroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField Field1;
                public TTReportField NewField11;
                public TTReportField NameSurname;
                public TTReportField UniqueRefNo;
                public TTReportField NewField1111;
                public TTReportField NewField111;
                public TTReportField BirthPlace;
                public TTReportField BirthDate;
                public TTReportField NewField11111;
                public TTReportField NewField112;
                public TTReportField PhoneNum;
                public TTReportField Address;
                public TTReportField NewField11112; 
                public PatienInfoGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 36;
                    RepeatCount = 0;
                    
                    Field1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 3, 36, 9, false);
                    Field1.Name = "Field1";
                    Field1.TextFont.Size = 12;
                    Field1.TextFont.Bold = true;
                    Field1.TextFont.Underline = true;
                    Field1.TextFont.CharSet = 162;
                    Field1.Value = @"Hasta Bilgileri:";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 12, 29, 17, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Size = 11;
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"Adı Soyadı  :";

                    NameSurname = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 29, 12, 72, 21, false);
                    NameSurname.Name = "NameSurname";
                    NameSurname.MultiLine = EvetHayirEnum.ehEvet;
                    NameSurname.TextFont.CharSet = 162;
                    NameSurname.Value = @"NewField2";

                    UniqueRefNo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 22, 69, 27, false);
                    UniqueRefNo.Name = "UniqueRefNo";
                    UniqueRefNo.TextFont.CharSet = 162;
                    UniqueRefNo.Value = @"NewField2";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 8, 22, 36, 27, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.TextFont.Size = 11;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.TextFont.CharSet = 162;
                    NewField1111.Value = @"T.C. Kimlik No  :";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 12, 100, 17, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Doğum Yeri  :";

                    BirthPlace = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 12, 129, 17, false);
                    BirthPlace.Name = "BirthPlace";
                    BirthPlace.TextFont.CharSet = 162;
                    BirthPlace.Value = @"NewField2";

                    BirthDate = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 104, 22, 133, 27, false);
                    BirthDate.Name = "BirthDate";
                    BirthDate.TextFont.CharSet = 162;
                    BirthDate.Value = @"NewField2";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 78, 22, 104, 27, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.TextFont.Size = 11;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.TextFont.CharSet = 162;
                    NewField11111.Value = @"Doğum Tarihi  :";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 12, 159, 17, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Size = 11;
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @"Telefon No  :";

                    PhoneNum = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 159, 12, 197, 17, false);
                    PhoneNum.Name = "PhoneNum";
                    PhoneNum.TextFont.CharSet = 162;
                    PhoneNum.Value = @"NewField2";

                    Address = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 151, 22, 205, 34, false);
                    Address.Name = "Address";
                    Address.TextFont.CharSet = 162;
                    Address.Value = @"NewField2";

                    NewField11112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 22, 151, 27, false);
                    NewField11112.Name = "NewField11112";
                    NewField11112.TextFont.Size = 11;
                    NewField11112.TextFont.Bold = true;
                    NewField11112.TextFont.CharSet = 162;
                    NewField11112.Value = @"Adres  :";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    Field1.CalcValue = Field1.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NameSurname.CalcValue = NameSurname.Value;
                    UniqueRefNo.CalcValue = UniqueRefNo.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField111.CalcValue = NewField111.Value;
                    BirthPlace.CalcValue = BirthPlace.Value;
                    BirthDate.CalcValue = BirthDate.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField112.CalcValue = NewField112.Value;
                    PhoneNum.CalcValue = PhoneNum.Value;
                    Address.CalcValue = Address.Value;
                    NewField11112.CalcValue = NewField11112.Value;
                    return new TTReportObject[] { Field1,NewField11,NameSurname,UniqueRefNo,NewField1111,NewField111,BirthPlace,BirthDate,NewField11111,NewField112,PhoneNum,Address,NewField11112};
                }

                public override void RunScript()
                {
#region PATIENINFO BODY_Script
                    TTObjectContext objectContext = new TTObjectContext(true);
                    SocServAppliedProcedures appliedProcedures = (SocServAppliedProcedures)objectContext.GetObject(new Guid(MyParentReport.RuntimeParameters.TTOBJECTID), "SocServAppliedProcedures");
                    this.NameSurname.CalcValue = appliedProcedures.PatientInterviewForm[0].Episode.Patient.Name + " " + appliedProcedures.PatientInterviewForm[0].Episode.Patient.Surname;
                    this.UniqueRefNo.CalcValue = appliedProcedures.PatientInterviewForm[0].Episode.Patient.UniqueRefNo.ToString();
                    this.BirthPlace.CalcValue = appliedProcedures.PatientInterviewForm[0].Episode.Patient.BirthPlace;
                    this.BirthDate.CalcValue = ((DateTime) appliedProcedures.PatientInterviewForm[0].Episode.Patient.BirthDate).ToString("dd.MM.yyyy");
                    this.PhoneNum.CalcValue = appliedProcedures.PatientInterviewForm[0].PatientPhoneNum != null ? appliedProcedures.PatientInterviewForm[0].PatientPhoneNum : appliedProcedures.PatientInterviewForm[0].Episode.Patient.MobilePhone;
                    this.Address.CalcValue = appliedProcedures.PatientInterviewForm[0].PatientAddress != null ? appliedProcedures.PatientInterviewForm[0].PatientAddress : appliedProcedures.PatientInterviewForm[0].Episode.Patient.PatientAddress.HomeAddress;
#endregion PATIENINFO BODY_Script
                }
            }

        }

        public PatienInfoGroup PatienInfo;

        public partial class MAINGroup : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField1 { get {return Body().NewField1;} }
            public TTReportField NewField16 { get {return Body().NewField16;} }
            public TTReportField NewField161 { get {return Body().NewField161;} }
            public TTReportField NewField162 { get {return Body().NewField162;} }
            public TTReportField PROVIDEINTERSECINJSTATDOCINFO { get {return Body().PROVIDEINTERSECINJSTATDOCINFO;} }
            public TTReportField PROVIDINGACCOMODATIONINFO { get {return Body().PROVIDINGACCOMODATIONINFO;} }
            public TTReportField PROVISIONISSUESINFO { get {return Body().PROVISIONISSUESINFO;} }
            public TTReportField chkProvidingAccomodation { get {return Body().chkProvidingAccomodation;} }
            public TTReportField chkProvideInternalSecInjStatDoc { get {return Body().chkProvideInternalSecInjStatDoc;} }
            public TTReportField chkProvisionIssues { get {return Body().chkProvisionIssues;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1;
                public TTReportField NewField16;
                public TTReportField NewField161;
                public TTReportField NewField162;
                public TTReportField PROVIDEINTERSECINJSTATDOCINFO;
                public TTReportField PROVIDINGACCOMODATIONINFO;
                public TTReportField PROVISIONISSUESINFO;
                public TTReportField chkProvidingAccomodation;
                public TTReportField chkProvideInternalSecInjStatDoc;
                public TTReportField chkProvisionIssues; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 55;
                    RepeatCount = 0;
                    
                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 88, 8, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Size = 11;
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @"1. XXXXXXde ilk yatışta yapılan işlemler";

                    NewField16 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 88, 13, false);
                    NewField16.Name = "NewField16";
                    NewField16.TextFont.Name = "Arial";
                    NewField16.TextFont.Italic = true;
                    NewField16.TextFont.CharSet = 162;
                    NewField16.Value = @"a. Hasta ve yakınlarına kalacak yer temini";

                    NewField161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 88, 27, false);
                    NewField161.Name = "NewField161";
                    NewField161.TextFont.Name = "Arial";
                    NewField161.TextFont.Italic = true;
                    NewField161.TextFont.CharSet = 162;
                    NewField161.Value = @"b. İç güvenlik yaralı durum belgesi temini";

                    NewField162 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 36, 88, 41, false);
                    NewField162.Name = "NewField162";
                    NewField162.TextFont.Name = "Arial";
                    NewField162.TextFont.Italic = true;
                    NewField162.TextFont.CharSet = 162;
                    NewField162.Value = @"c. Provizyon sorunları";

                    PROVIDEINTERSECINJSTATDOCINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 27, 207, 36, false);
                    PROVIDEINTERSECINJSTATDOCINFO.Name = "PROVIDEINTERSECINJSTATDOCINFO";
                    PROVIDEINTERSECINJSTATDOCINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIDEINTERSECINJSTATDOCINFO.MultiLine = EvetHayirEnum.ehEvet;
                    PROVIDEINTERSECINJSTATDOCINFO.NoClip = EvetHayirEnum.ehEvet;
                    PROVIDEINTERSECINJSTATDOCINFO.WordBreak = EvetHayirEnum.ehEvet;
                    PROVIDEINTERSECINJSTATDOCINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROVIDEINTERSECINJSTATDOCINFO.TextFont.Size = 8;
                    PROVIDEINTERSECINJSTATDOCINFO.TextFont.CharSet = 162;
                    PROVIDEINTERSECINJSTATDOCINFO.Value = @"{#Header.PROVIDEINTERSECINJSTATDOCINFO#}";

                    PROVIDINGACCOMODATIONINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 207, 22, false);
                    PROVIDINGACCOMODATIONINFO.Name = "PROVIDINGACCOMODATIONINFO";
                    PROVIDINGACCOMODATIONINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIDINGACCOMODATIONINFO.MultiLine = EvetHayirEnum.ehEvet;
                    PROVIDINGACCOMODATIONINFO.NoClip = EvetHayirEnum.ehEvet;
                    PROVIDINGACCOMODATIONINFO.WordBreak = EvetHayirEnum.ehEvet;
                    PROVIDINGACCOMODATIONINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROVIDINGACCOMODATIONINFO.TextFont.Size = 8;
                    PROVIDINGACCOMODATIONINFO.TextFont.CharSet = 162;
                    PROVIDINGACCOMODATIONINFO.Value = @"{#Header.PROVIDINGACCOMODATIONINFO#}";

                    PROVISIONISSUESINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 41, 207, 50, false);
                    PROVISIONISSUESINFO.Name = "PROVISIONISSUESINFO";
                    PROVISIONISSUESINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVISIONISSUESINFO.MultiLine = EvetHayirEnum.ehEvet;
                    PROVISIONISSUESINFO.NoClip = EvetHayirEnum.ehEvet;
                    PROVISIONISSUESINFO.WordBreak = EvetHayirEnum.ehEvet;
                    PROVISIONISSUESINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROVISIONISSUESINFO.TextFont.Size = 8;
                    PROVISIONISSUESINFO.TextFont.CharSet = 162;
                    PROVISIONISSUESINFO.Value = @"{#Header.PROVISIONISSUESINFO#}";

                    chkProvidingAccomodation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 8, 9, 12, false);
                    chkProvidingAccomodation.Name = "chkProvidingAccomodation";
                    chkProvidingAccomodation.DrawStyle = DrawStyleConstants.vbSolid;
                    chkProvidingAccomodation.TextFont.Name = "Arial";
                    chkProvidingAccomodation.TextFont.Bold = true;
                    chkProvidingAccomodation.TextFont.CharSet = 162;
                    chkProvidingAccomodation.Value = @"X";

                    chkProvideInternalSecInjStatDoc = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 22, 9, 26, false);
                    chkProvideInternalSecInjStatDoc.Name = "chkProvideInternalSecInjStatDoc";
                    chkProvideInternalSecInjStatDoc.DrawStyle = DrawStyleConstants.vbSolid;
                    chkProvideInternalSecInjStatDoc.TextFont.Name = "Arial";
                    chkProvideInternalSecInjStatDoc.TextFont.Bold = true;
                    chkProvideInternalSecInjStatDoc.TextFont.CharSet = 162;
                    chkProvideInternalSecInjStatDoc.Value = @"X";

                    chkProvisionIssues = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 36, 9, 40, false);
                    chkProvisionIssues.Name = "chkProvisionIssues";
                    chkProvisionIssues.DrawStyle = DrawStyleConstants.vbSolid;
                    chkProvisionIssues.TextFont.Name = "Arial";
                    chkProvisionIssues.TextFont.Bold = true;
                    chkProvisionIssues.TextFont.CharSet = 162;
                    chkProvisionIssues.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1.CalcValue = NewField1.Value;
                    NewField16.CalcValue = NewField16.Value;
                    NewField161.CalcValue = NewField161.Value;
                    NewField162.CalcValue = NewField162.Value;
                    PROVIDEINTERSECINJSTATDOCINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ProvideInterSecInjStatDocInfo) : "");
                    PROVIDINGACCOMODATIONINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ProvidingAccomodationInfo) : "");
                    PROVISIONISSUESINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ProvisionIssuesInfo) : "");
                    chkProvidingAccomodation.CalcValue = chkProvidingAccomodation.Value;
                    chkProvideInternalSecInjStatDoc.CalcValue = chkProvideInternalSecInjStatDoc.Value;
                    chkProvisionIssues.CalcValue = chkProvisionIssues.Value;
                    return new TTReportObject[] { NewField1,NewField16,NewField161,NewField162,PROVIDEINTERSECINJSTATDOCINFO,PROVIDINGACCOMODATIONINFO,PROVISIONISSUESINFO,chkProvidingAccomodation,chkProvideInternalSecInjStatDoc,chkProvisionIssues};
                }
            }

        }

        public MAINGroup MAIN;

        public partial class group2Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group2GroupBody Body()
            {
                return (group2GroupBody)_body;
            }
            public TTReportField NewField111 { get {return Body().NewField111;} }
            public TTReportField NewField1361 { get {return Body().NewField1361;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField WEEKLYTEAMMEETINGSINFO1 { get {return Body().WEEKLYTEAMMEETINGSINFO1;} }
            public TTReportField WEEKLYVISITATTENDENCEINFO1 { get {return Body().WEEKLYVISITATTENDENCEINFO1;} }
            public TTReportField chkWeeklyTeamMeetings { get {return Body().chkWeeklyTeamMeetings;} }
            public TTReportField chkWeeklyVisitAttendence { get {return Body().chkWeeklyVisitAttendence;} }
            public group2Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group2Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group2GroupBody(this);
            }

            public partial class group2GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1361;
                public TTReportField NewField11611;
                public TTReportField WEEKLYTEAMMEETINGSINFO1;
                public TTReportField WEEKLYVISITATTENDENCEINFO1;
                public TTReportField chkWeeklyTeamMeetings;
                public TTReportField chkWeeklyVisitAttendence; 
                public group2GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 39;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 2, 87, 8, false);
                    NewField111.Name = "NewField111";
                    NewField111.TextFont.Size = 11;
                    NewField111.TextFont.Bold = true;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"2. XXXXXXde tıbbi ekiple birlikte yapılan işlemler";

                    NewField1361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 8, 88, 13, false);
                    NewField1361.Name = "NewField1361";
                    NewField1361.TextFont.Name = "Arial";
                    NewField1361.TextFont.Italic = true;
                    NewField1361.TextFont.CharSet = 162;
                    NewField1361.Value = @"a. Haftalık ekip toplantıları";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 22, 88, 27, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Italic = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @"b. Haftalık vizite katılım";

                    WEEKLYTEAMMEETINGSINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 207, 22, false);
                    WEEKLYTEAMMEETINGSINFO1.Name = "WEEKLYTEAMMEETINGSINFO1";
                    WEEKLYTEAMMEETINGSINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEEKLYTEAMMEETINGSINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    WEEKLYTEAMMEETINGSINFO1.NoClip = EvetHayirEnum.ehEvet;
                    WEEKLYTEAMMEETINGSINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    WEEKLYTEAMMEETINGSINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    WEEKLYTEAMMEETINGSINFO1.TextFont.Size = 8;
                    WEEKLYTEAMMEETINGSINFO1.TextFont.CharSet = 162;
                    WEEKLYTEAMMEETINGSINFO1.Value = @"{#Header.WEEKLYTEAMMEETINGSINFO#}";

                    WEEKLYVISITATTENDENCEINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 27, 207, 36, false);
                    WEEKLYVISITATTENDENCEINFO1.Name = "WEEKLYVISITATTENDENCEINFO1";
                    WEEKLYVISITATTENDENCEINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEEKLYVISITATTENDENCEINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    WEEKLYVISITATTENDENCEINFO1.NoClip = EvetHayirEnum.ehEvet;
                    WEEKLYVISITATTENDENCEINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    WEEKLYVISITATTENDENCEINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    WEEKLYVISITATTENDENCEINFO1.TextFont.Size = 8;
                    WEEKLYVISITATTENDENCEINFO1.TextFont.CharSet = 162;
                    WEEKLYVISITATTENDENCEINFO1.Value = @"{#Header.WEEKLYVISITATTENDENCEINFO#}";

                    chkWeeklyTeamMeetings = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 8, 9, 12, false);
                    chkWeeklyTeamMeetings.Name = "chkWeeklyTeamMeetings";
                    chkWeeklyTeamMeetings.DrawStyle = DrawStyleConstants.vbSolid;
                    chkWeeklyTeamMeetings.TextFont.Name = "Arial";
                    chkWeeklyTeamMeetings.TextFont.Bold = true;
                    chkWeeklyTeamMeetings.TextFont.CharSet = 162;
                    chkWeeklyTeamMeetings.Value = @"X";

                    chkWeeklyVisitAttendence = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 22, 9, 26, false);
                    chkWeeklyVisitAttendence.Name = "chkWeeklyVisitAttendence";
                    chkWeeklyVisitAttendence.DrawStyle = DrawStyleConstants.vbSolid;
                    chkWeeklyVisitAttendence.TextFont.Name = "Arial";
                    chkWeeklyVisitAttendence.TextFont.Bold = true;
                    chkWeeklyVisitAttendence.TextFont.CharSet = 162;
                    chkWeeklyVisitAttendence.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField111.CalcValue = NewField111.Value;
                    NewField1361.CalcValue = NewField1361.Value;
                    NewField11611.CalcValue = NewField11611.Value;
                    WEEKLYTEAMMEETINGSINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.WeeklyTeamMeetingsInfo) : "");
                    WEEKLYVISITATTENDENCEINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.WeeklyVisitAttendenceInfo) : "");
                    chkWeeklyTeamMeetings.CalcValue = chkWeeklyTeamMeetings.Value;
                    chkWeeklyVisitAttendence.CalcValue = chkWeeklyVisitAttendence.Value;
                    return new TTReportObject[] { NewField111,NewField1361,NewField11611,WEEKLYTEAMMEETINGSINFO1,WEEKLYVISITATTENDENCEINFO1,chkWeeklyTeamMeetings,chkWeeklyVisitAttendence};
                }
            }

        }

        public group2Group group2;

        public partial class group3Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group3GroupBody Body()
            {
                return (group3GroupBody)_body;
            }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1461 { get {return Body().NewField1461;} }
            public TTReportField NewField12611 { get {return Body().NewField12611;} }
            public TTReportField NewField11621 { get {return Body().NewField11621;} }
            public TTReportField NewField111621 { get {return Body().NewField111621;} }
            public TTReportField NewField112611 { get {return Body().NewField112611;} }
            public TTReportField CALCANDFOLLOWRESTPROCINFO1 { get {return Body().CALCANDFOLLOWRESTPROCINFO1;} }
            public TTReportField DONATEDMEDICALSUPPLYPROCINFO1 { get {return Body().DONATEDMEDICALSUPPLYPROCINFO1;} }
            public TTReportField GUIDANCEDRUGSUPPLYABROADINFO1 { get {return Body().GUIDANCEDRUGSUPPLYABROADINFO1;} }
            public TTReportField INFORMANDDIRECTRETIREPROCINFO1 { get {return Body().INFORMANDDIRECTRETIREPROCINFO1;} }
            public TTReportField MEDICEQPROCREFUNDINFOPROCINFO1 { get {return Body().MEDICEQPROCREFUNDINFOPROCINFO1;} }
            public TTReportField chkCalcAndFollowRestProc { get {return Body().chkCalcAndFollowRestProc;} }
            public TTReportField chkInformAndDirectRetireProc { get {return Body().chkInformAndDirectRetireProc;} }
            public TTReportField chkMedicEqProcRefundInfoProcure { get {return Body().chkMedicEqProcRefundInfoProcure;} }
            public TTReportField chkDonatedMedicalSupplyProcure { get {return Body().chkDonatedMedicalSupplyProcure;} }
            public TTReportField chkGuidanceOnDrugSupplyAbroad { get {return Body().chkGuidanceOnDrugSupplyAbroad;} }
            public group3Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group3Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group3GroupBody(this);
            }

            public partial class group3GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField121;
                public TTReportField NewField1461;
                public TTReportField NewField12611;
                public TTReportField NewField11621;
                public TTReportField NewField111621;
                public TTReportField NewField112611;
                public TTReportField CALCANDFOLLOWRESTPROCINFO1;
                public TTReportField DONATEDMEDICALSUPPLYPROCINFO1;
                public TTReportField GUIDANCEDRUGSUPPLYABROADINFO1;
                public TTReportField INFORMANDDIRECTRETIREPROCINFO1;
                public TTReportField MEDICEQPROCREFUNDINFOPROCINFO1;
                public TTReportField chkCalcAndFollowRestProc;
                public TTReportField chkInformAndDirectRetireProc;
                public TTReportField chkMedicEqProcRefundInfoProcure;
                public TTReportField chkDonatedMedicalSupplyProcure;
                public TTReportField chkGuidanceOnDrugSupplyAbroad; 
                public group3GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 84;
                    RepeatCount = 0;
                    
                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 87, 10, false);
                    NewField121.Name = "NewField121";
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"3. XXXXXXde süreç içinde yapılan işlemler";

                    NewField1461 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 88, 15, false);
                    NewField1461.Name = "NewField1461";
                    NewField1461.TextFont.Name = "Arial";
                    NewField1461.TextFont.Italic = true;
                    NewField1461.TextFont.CharSet = 162;
                    NewField1461.Value = @"a. İstirahat süreçlerinin hesaplanması ve takibi";

                    NewField12611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 97, 29, false);
                    NewField12611.Name = "NewField12611";
                    NewField12611.TextFont.Name = "Arial";
                    NewField12611.TextFont.Italic = true;
                    NewField12611.TextFont.CharSet = 162;
                    NewField12611.Value = @"b. Emeklilik süreciyle ilgili bilgilendirme ve yönlendirme";

                    NewField11621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 109, 43, false);
                    NewField11621.Name = "NewField11621";
                    NewField11621.TextFont.Name = "Arial";
                    NewField11621.TextFont.Italic = true;
                    NewField11621.TextFont.CharSet = 162;
                    NewField11621.Value = @"c. Tıbbi malzeme prosedürü-geri ödemesi, bilgilendirme, temini";

                    NewField111621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 88, 57, false);
                    NewField111621.Name = "NewField111621";
                    NewField111621.TextFont.Name = "Arial";
                    NewField111621.TextFont.Italic = true;
                    NewField111621.TextFont.CharSet = 162;
                    NewField111621.Value = @"ç. Bağış tıbbi malzeme temini";

                    NewField112611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 66, 88, 71, false);
                    NewField112611.Name = "NewField112611";
                    NewField112611.TextFont.Name = "Arial";
                    NewField112611.TextFont.Italic = true;
                    NewField112611.TextFont.CharSet = 162;
                    NewField112611.Value = @"d. Yurtdışı ilaç temini ile ilgili yönlendirme";

                    CALCANDFOLLOWRESTPROCINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 15, 207, 24, false);
                    CALCANDFOLLOWRESTPROCINFO1.Name = "CALCANDFOLLOWRESTPROCINFO1";
                    CALCANDFOLLOWRESTPROCINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CALCANDFOLLOWRESTPROCINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    CALCANDFOLLOWRESTPROCINFO1.NoClip = EvetHayirEnum.ehEvet;
                    CALCANDFOLLOWRESTPROCINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    CALCANDFOLLOWRESTPROCINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    CALCANDFOLLOWRESTPROCINFO1.TextFont.Size = 8;
                    CALCANDFOLLOWRESTPROCINFO1.TextFont.CharSet = 162;
                    CALCANDFOLLOWRESTPROCINFO1.Value = @"{#Header.CALCANDFOLLOWRESTPROCINFO#}";

                    DONATEDMEDICALSUPPLYPROCINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 57, 207, 66, false);
                    DONATEDMEDICALSUPPLYPROCINFO1.Name = "DONATEDMEDICALSUPPLYPROCINFO1";
                    DONATEDMEDICALSUPPLYPROCINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DONATEDMEDICALSUPPLYPROCINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    DONATEDMEDICALSUPPLYPROCINFO1.NoClip = EvetHayirEnum.ehEvet;
                    DONATEDMEDICALSUPPLYPROCINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    DONATEDMEDICALSUPPLYPROCINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DONATEDMEDICALSUPPLYPROCINFO1.TextFont.Size = 8;
                    DONATEDMEDICALSUPPLYPROCINFO1.TextFont.CharSet = 162;
                    DONATEDMEDICALSUPPLYPROCINFO1.Value = @"{#Header.DONATEDMEDICALSUPPLYPROCINFO#}";

                    GUIDANCEDRUGSUPPLYABROADINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 71, 207, 80, false);
                    GUIDANCEDRUGSUPPLYABROADINFO1.Name = "GUIDANCEDRUGSUPPLYABROADINFO1";
                    GUIDANCEDRUGSUPPLYABROADINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCEDRUGSUPPLYABROADINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCEDRUGSUPPLYABROADINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCEDRUGSUPPLYABROADINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCEDRUGSUPPLYABROADINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCEDRUGSUPPLYABROADINFO1.TextFont.Size = 8;
                    GUIDANCEDRUGSUPPLYABROADINFO1.TextFont.CharSet = 162;
                    GUIDANCEDRUGSUPPLYABROADINFO1.Value = @"{#Header.GUIDANCEDRUGSUPPLYABROADINFO#}";

                    INFORMANDDIRECTRETIREPROCINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 29, 207, 38, false);
                    INFORMANDDIRECTRETIREPROCINFO1.Name = "INFORMANDDIRECTRETIREPROCINFO1";
                    INFORMANDDIRECTRETIREPROCINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    INFORMANDDIRECTRETIREPROCINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    INFORMANDDIRECTRETIREPROCINFO1.NoClip = EvetHayirEnum.ehEvet;
                    INFORMANDDIRECTRETIREPROCINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    INFORMANDDIRECTRETIREPROCINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    INFORMANDDIRECTRETIREPROCINFO1.TextFont.Size = 8;
                    INFORMANDDIRECTRETIREPROCINFO1.TextFont.CharSet = 162;
                    INFORMANDDIRECTRETIREPROCINFO1.Value = @"{#Header.INFORMANDDIRECTRETIREPROCINFO#}";

                    MEDICEQPROCREFUNDINFOPROCINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 207, 52, false);
                    MEDICEQPROCREFUNDINFOPROCINFO1.Name = "MEDICEQPROCREFUNDINFOPROCINFO1";
                    MEDICEQPROCREFUNDINFOPROCINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MEDICEQPROCREFUNDINFOPROCINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    MEDICEQPROCREFUNDINFOPROCINFO1.NoClip = EvetHayirEnum.ehEvet;
                    MEDICEQPROCREFUNDINFOPROCINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    MEDICEQPROCREFUNDINFOPROCINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    MEDICEQPROCREFUNDINFOPROCINFO1.TextFont.Size = 8;
                    MEDICEQPROCREFUNDINFOPROCINFO1.TextFont.CharSet = 162;
                    MEDICEQPROCREFUNDINFOPROCINFO1.Value = @"{#Header.MEDICEQPROCREFUNDINFOPROCINFO#}";

                    chkCalcAndFollowRestProc = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 10, 9, 14, false);
                    chkCalcAndFollowRestProc.Name = "chkCalcAndFollowRestProc";
                    chkCalcAndFollowRestProc.DrawStyle = DrawStyleConstants.vbSolid;
                    chkCalcAndFollowRestProc.TextFont.Name = "Arial";
                    chkCalcAndFollowRestProc.TextFont.Bold = true;
                    chkCalcAndFollowRestProc.TextFont.CharSet = 162;
                    chkCalcAndFollowRestProc.Value = @"X";

                    chkInformAndDirectRetireProc = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 24, 9, 28, false);
                    chkInformAndDirectRetireProc.Name = "chkInformAndDirectRetireProc";
                    chkInformAndDirectRetireProc.DrawStyle = DrawStyleConstants.vbSolid;
                    chkInformAndDirectRetireProc.TextFont.Name = "Arial";
                    chkInformAndDirectRetireProc.TextFont.Bold = true;
                    chkInformAndDirectRetireProc.TextFont.CharSet = 162;
                    chkInformAndDirectRetireProc.Value = @"X";

                    chkMedicEqProcRefundInfoProcure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 38, 9, 42, false);
                    chkMedicEqProcRefundInfoProcure.Name = "chkMedicEqProcRefundInfoProcure";
                    chkMedicEqProcRefundInfoProcure.DrawStyle = DrawStyleConstants.vbSolid;
                    chkMedicEqProcRefundInfoProcure.TextFont.Name = "Arial";
                    chkMedicEqProcRefundInfoProcure.TextFont.Bold = true;
                    chkMedicEqProcRefundInfoProcure.TextFont.CharSet = 162;
                    chkMedicEqProcRefundInfoProcure.Value = @"X";

                    chkDonatedMedicalSupplyProcure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 52, 9, 56, false);
                    chkDonatedMedicalSupplyProcure.Name = "chkDonatedMedicalSupplyProcure";
                    chkDonatedMedicalSupplyProcure.DrawStyle = DrawStyleConstants.vbSolid;
                    chkDonatedMedicalSupplyProcure.TextFont.Name = "Arial";
                    chkDonatedMedicalSupplyProcure.TextFont.Bold = true;
                    chkDonatedMedicalSupplyProcure.TextFont.CharSet = 162;
                    chkDonatedMedicalSupplyProcure.Value = @"X";

                    chkGuidanceOnDrugSupplyAbroad = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 66, 9, 70, false);
                    chkGuidanceOnDrugSupplyAbroad.Name = "chkGuidanceOnDrugSupplyAbroad";
                    chkGuidanceOnDrugSupplyAbroad.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGuidanceOnDrugSupplyAbroad.TextFont.Name = "Arial";
                    chkGuidanceOnDrugSupplyAbroad.TextFont.Bold = true;
                    chkGuidanceOnDrugSupplyAbroad.TextFont.CharSet = 162;
                    chkGuidanceOnDrugSupplyAbroad.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField121.CalcValue = NewField121.Value;
                    NewField1461.CalcValue = NewField1461.Value;
                    NewField12611.CalcValue = NewField12611.Value;
                    NewField11621.CalcValue = NewField11621.Value;
                    NewField111621.CalcValue = NewField111621.Value;
                    NewField112611.CalcValue = NewField112611.Value;
                    CALCANDFOLLOWRESTPROCINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.CalcAndFollowRestProcInfo) : "");
                    DONATEDMEDICALSUPPLYPROCINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.DonatedMedicalSupplyProcInfo) : "");
                    GUIDANCEDRUGSUPPLYABROADINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceDrugSupplyAbroadInfo) : "");
                    INFORMANDDIRECTRETIREPROCINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.InformAndDirectRetireProcInfo) : "");
                    MEDICEQPROCREFUNDINFOPROCINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.MedicEqProcRefundInfoProcInfo) : "");
                    chkCalcAndFollowRestProc.CalcValue = chkCalcAndFollowRestProc.Value;
                    chkInformAndDirectRetireProc.CalcValue = chkInformAndDirectRetireProc.Value;
                    chkMedicEqProcRefundInfoProcure.CalcValue = chkMedicEqProcRefundInfoProcure.Value;
                    chkDonatedMedicalSupplyProcure.CalcValue = chkDonatedMedicalSupplyProcure.Value;
                    chkGuidanceOnDrugSupplyAbroad.CalcValue = chkGuidanceOnDrugSupplyAbroad.Value;
                    return new TTReportObject[] { NewField121,NewField1461,NewField12611,NewField11621,NewField111621,NewField112611,CALCANDFOLLOWRESTPROCINFO1,DONATEDMEDICALSUPPLYPROCINFO1,GUIDANCEDRUGSUPPLYABROADINFO1,INFORMANDDIRECTRETIREPROCINFO1,MEDICEQPROCREFUNDINFOPROCINFO1,chkCalcAndFollowRestProc,chkInformAndDirectRetireProc,chkMedicEqProcRefundInfoProcure,chkDonatedMedicalSupplyProcure,chkGuidanceOnDrugSupplyAbroad};
                }
            }

        }

        public group3Group group3;

        public partial class group4Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group4GroupBody Body()
            {
                return (group4GroupBody)_body;
            }
            public TTReportField NewField131 { get {return Body().NewField131;} }
            public TTReportField NewField11641 { get {return Body().NewField11641;} }
            public TTReportField NewField121621 { get {return Body().NewField121621;} }
            public TTReportField NewField122611 { get {return Body().NewField122611;} }
            public TTReportField BENEFITINGFROMDONATIONSINFO1 { get {return Body().BENEFITINGFROMDONATIONSINFO1;} }
            public TTReportField GUIDANCETOCIVILORGANIZATINFO1 { get {return Body().GUIDANCETOCIVILORGANIZATINFO1;} }
            public TTReportField GUIDANCETOFOUNDATIONSINFO1 { get {return Body().GUIDANCETOFOUNDATIONSINFO1;} }
            public TTReportField chkBenefitingFromDonations { get {return Body().chkBenefitingFromDonations;} }
            public TTReportField chkGuidanceToFoundations { get {return Body().chkGuidanceToFoundations;} }
            public TTReportField chkGuidanceToCivilOrganizations { get {return Body().chkGuidanceToCivilOrganizations;} }
            public group4Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group4Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group4GroupBody(this);
            }

            public partial class group4GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField131;
                public TTReportField NewField11641;
                public TTReportField NewField121621;
                public TTReportField NewField122611;
                public TTReportField BENEFITINGFROMDONATIONSINFO1;
                public TTReportField GUIDANCETOCIVILORGANIZATINFO1;
                public TTReportField GUIDANCETOFOUNDATIONSINFO1;
                public TTReportField chkBenefitingFromDonations;
                public TTReportField chkGuidanceToFoundations;
                public TTReportField chkGuidanceToCivilOrganizations; 
                public group4GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 57;
                    RepeatCount = 0;
                    
                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 87, 11, false);
                    NewField131.Name = "NewField131";
                    NewField131.TextFont.Size = 11;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"4. XXXXXXde süreç içinde yapılan işlemler";

                    NewField11641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 88, 16, false);
                    NewField11641.Name = "NewField11641";
                    NewField11641.TextFont.Name = "Arial";
                    NewField11641.TextFont.Italic = true;
                    NewField11641.TextFont.CharSet = 162;
                    NewField11641.Value = @"a. Bağışlardan yararlandırma";

                    NewField121621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 151, 30, false);
                    NewField121621.Name = "NewField121621";
                    NewField121621.TextFont.Name = "Arial";
                    NewField121621.TextFont.Italic = true;
                    NewField121621.TextFont.CharSet = 162;
                    NewField121621.Value = @"b. Sosyal Yardımlaşma ve Dayanışma Vakıflarına Yönlendirme";

                    NewField122611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 88, 44, false);
                    NewField122611.Name = "NewField122611";
                    NewField122611.TextFont.Name = "Arial";
                    NewField122611.TextFont.Italic = true;
                    NewField122611.TextFont.CharSet = 162;
                    NewField122611.Value = @"c. Sivil Toplum Örgütlerine Yönlendirme";

                    BENEFITINGFROMDONATIONSINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 16, 207, 25, false);
                    BENEFITINGFROMDONATIONSINFO1.Name = "BENEFITINGFROMDONATIONSINFO1";
                    BENEFITINGFROMDONATIONSINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BENEFITINGFROMDONATIONSINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    BENEFITINGFROMDONATIONSINFO1.NoClip = EvetHayirEnum.ehEvet;
                    BENEFITINGFROMDONATIONSINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    BENEFITINGFROMDONATIONSINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BENEFITINGFROMDONATIONSINFO1.TextFont.Size = 8;
                    BENEFITINGFROMDONATIONSINFO1.TextFont.CharSet = 162;
                    BENEFITINGFROMDONATIONSINFO1.Value = @"{#Header.BENEFITINGFROMDONATIONSINFO#}";

                    GUIDANCETOCIVILORGANIZATINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 44, 207, 53, false);
                    GUIDANCETOCIVILORGANIZATINFO1.Name = "GUIDANCETOCIVILORGANIZATINFO1";
                    GUIDANCETOCIVILORGANIZATINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCETOCIVILORGANIZATINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCETOCIVILORGANIZATINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCETOCIVILORGANIZATINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCETOCIVILORGANIZATINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCETOCIVILORGANIZATINFO1.TextFont.Size = 8;
                    GUIDANCETOCIVILORGANIZATINFO1.TextFont.CharSet = 162;
                    GUIDANCETOCIVILORGANIZATINFO1.Value = @"{#Header.GUIDANCETOCIVILORGANIZATINFO#}";

                    GUIDANCETOFOUNDATIONSINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 207, 39, false);
                    GUIDANCETOFOUNDATIONSINFO1.Name = "GUIDANCETOFOUNDATIONSINFO1";
                    GUIDANCETOFOUNDATIONSINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCETOFOUNDATIONSINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCETOFOUNDATIONSINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCETOFOUNDATIONSINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCETOFOUNDATIONSINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCETOFOUNDATIONSINFO1.TextFont.Size = 8;
                    GUIDANCETOFOUNDATIONSINFO1.TextFont.CharSet = 162;
                    GUIDANCETOFOUNDATIONSINFO1.Value = @"{#Header.GUIDANCETOFOUNDATIONSINFO#}";

                    chkBenefitingFromDonations = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 11, 9, 15, false);
                    chkBenefitingFromDonations.Name = "chkBenefitingFromDonations";
                    chkBenefitingFromDonations.DrawStyle = DrawStyleConstants.vbSolid;
                    chkBenefitingFromDonations.TextFont.Name = "Arial";
                    chkBenefitingFromDonations.TextFont.Bold = true;
                    chkBenefitingFromDonations.TextFont.CharSet = 162;
                    chkBenefitingFromDonations.Value = @"X";

                    chkGuidanceToFoundations = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 25, 9, 29, false);
                    chkGuidanceToFoundations.Name = "chkGuidanceToFoundations";
                    chkGuidanceToFoundations.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGuidanceToFoundations.TextFont.Name = "Arial";
                    chkGuidanceToFoundations.TextFont.Bold = true;
                    chkGuidanceToFoundations.TextFont.CharSet = 162;
                    chkGuidanceToFoundations.Value = @"X";

                    chkGuidanceToCivilOrganizations = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 39, 9, 43, false);
                    chkGuidanceToCivilOrganizations.Name = "chkGuidanceToCivilOrganizations";
                    chkGuidanceToCivilOrganizations.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGuidanceToCivilOrganizations.TextFont.Name = "Arial";
                    chkGuidanceToCivilOrganizations.TextFont.Bold = true;
                    chkGuidanceToCivilOrganizations.TextFont.CharSet = 162;
                    chkGuidanceToCivilOrganizations.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField131.CalcValue = NewField131.Value;
                    NewField11641.CalcValue = NewField11641.Value;
                    NewField121621.CalcValue = NewField121621.Value;
                    NewField122611.CalcValue = NewField122611.Value;
                    BENEFITINGFROMDONATIONSINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.BenefitingFromDonationsInfo) : "");
                    GUIDANCETOCIVILORGANIZATINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceToCivilOrganizatInfo) : "");
                    GUIDANCETOFOUNDATIONSINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceToFoundationsInfo) : "");
                    chkBenefitingFromDonations.CalcValue = chkBenefitingFromDonations.Value;
                    chkGuidanceToFoundations.CalcValue = chkGuidanceToFoundations.Value;
                    chkGuidanceToCivilOrganizations.CalcValue = chkGuidanceToCivilOrganizations.Value;
                    return new TTReportObject[] { NewField131,NewField11641,NewField121621,NewField122611,BENEFITINGFROMDONATIONSINFO1,GUIDANCETOCIVILORGANIZATINFO1,GUIDANCETOFOUNDATIONSINFO1,chkBenefitingFromDonations,chkGuidanceToFoundations,chkGuidanceToCivilOrganizations};
                }
            }

        }

        public group4Group group4;

        public partial class group5Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group5GroupBody Body()
            {
                return (group5GroupBody)_body;
            }
            public TTReportField NewField141 { get {return Body().NewField141;} }
            public TTReportField NewField114611 { get {return Body().NewField114611;} }
            public TTReportField NewField1126121 { get {return Body().NewField1126121;} }
            public TTReportField NewField1116221 { get {return Body().NewField1116221;} }
            public TTReportField GUIDANCEABOUTCARESALARYINFO1 { get {return Body().GUIDANCEABOUTCARESALARYINFO1;} }
            public TTReportField GUIDANCEABOUTHOMEHEALTHCRINFO1 { get {return Body().GUIDANCEABOUTHOMEHEALTHCRINFO1;} }
            public TTReportField GUIDANCEABOUTLAWINFO1 { get {return Body().GUIDANCEABOUTLAWINFO1;} }
            public TTReportField chkGuidanceAboutLaw { get {return Body().chkGuidanceAboutLaw;} }
            public TTReportField chkGuidanceAboutHomeHealthCare { get {return Body().chkGuidanceAboutHomeHealthCare;} }
            public TTReportField chkGuidanceAboutCareSalary { get {return Body().chkGuidanceAboutCareSalary;} }
            public group5Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group5Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group5GroupBody(this);
            }

            public partial class group5GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField141;
                public TTReportField NewField114611;
                public TTReportField NewField1126121;
                public TTReportField NewField1116221;
                public TTReportField GUIDANCEABOUTCARESALARYINFO1;
                public TTReportField GUIDANCEABOUTHOMEHEALTHCRINFO1;
                public TTReportField GUIDANCEABOUTLAWINFO1;
                public TTReportField chkGuidanceAboutLaw;
                public TTReportField chkGuidanceAboutHomeHealthCare;
                public TTReportField chkGuidanceAboutCareSalary; 
                public group5GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 53;
                    RepeatCount = 0;
                    
                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 4, 106, 10, false);
                    NewField141.Name = "NewField141";
                    NewField141.TextFont.Size = 11;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"5. XXXXXX sürecinde Sosyal hakları hakkında bilgilendirme";

                    NewField114611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 10, 88, 15, false);
                    NewField114611.Name = "NewField114611";
                    NewField114611.TextFont.Name = "Arial";
                    NewField114611.TextFont.Italic = true;
                    NewField114611.TextFont.CharSet = 162;
                    NewField114611.Value = @"a. Bakım Maaşı ile ilgili yönlendirme";

                    NewField1126121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 24, 107, 29, false);
                    NewField1126121.Name = "NewField1126121";
                    NewField1126121.TextFont.Name = "Arial";
                    NewField1126121.TextFont.Italic = true;
                    NewField1126121.TextFont.CharSet = 162;
                    NewField1126121.Value = @"b. 2022 sayılı yasa ile ilgili yönlendirme";

                    NewField1116221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 38, 88, 43, false);
                    NewField1116221.Name = "NewField1116221";
                    NewField1116221.TextFont.Name = "Arial";
                    NewField1116221.TextFont.Italic = true;
                    NewField1116221.TextFont.CharSet = 162;
                    NewField1116221.Value = @"c. Evde sağlık hizmetleri ile ilgili yönlendirme";

                    GUIDANCEABOUTCARESALARYINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 15, 207, 24, false);
                    GUIDANCEABOUTCARESALARYINFO1.Name = "GUIDANCEABOUTCARESALARYINFO1";
                    GUIDANCEABOUTCARESALARYINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCEABOUTCARESALARYINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTCARESALARYINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTCARESALARYINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTCARESALARYINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTCARESALARYINFO1.TextFont.Size = 8;
                    GUIDANCEABOUTCARESALARYINFO1.TextFont.CharSet = 162;
                    GUIDANCEABOUTCARESALARYINFO1.Value = @"{#Header.GUIDANCEABOUTCARESALARYINFO#}";

                    GUIDANCEABOUTHOMEHEALTHCRINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 207, 52, false);
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.Name = "GUIDANCEABOUTHOMEHEALTHCRINFO1";
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.TextFont.Size = 8;
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.TextFont.CharSet = 162;
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.Value = @"{#Header.GUIDANCEABOUTHOMEHEALTHCRINFO#}";

                    GUIDANCEABOUTLAWINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 29, 207, 38, false);
                    GUIDANCEABOUTLAWINFO1.Name = "GUIDANCEABOUTLAWINFO1";
                    GUIDANCEABOUTLAWINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCEABOUTLAWINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTLAWINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTLAWINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTLAWINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCEABOUTLAWINFO1.TextFont.Size = 8;
                    GUIDANCEABOUTLAWINFO1.TextFont.CharSet = 162;
                    GUIDANCEABOUTLAWINFO1.Value = @"{#Header.GUIDANCEABOUTLAWINFO#}";

                    chkGuidanceAboutLaw = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 24, 9, 28, false);
                    chkGuidanceAboutLaw.Name = "chkGuidanceAboutLaw";
                    chkGuidanceAboutLaw.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGuidanceAboutLaw.TextFont.Name = "Arial";
                    chkGuidanceAboutLaw.TextFont.Bold = true;
                    chkGuidanceAboutLaw.TextFont.CharSet = 162;
                    chkGuidanceAboutLaw.Value = @"X";

                    chkGuidanceAboutHomeHealthCare = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 38, 9, 42, false);
                    chkGuidanceAboutHomeHealthCare.Name = "chkGuidanceAboutHomeHealthCare";
                    chkGuidanceAboutHomeHealthCare.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGuidanceAboutHomeHealthCare.TextFont.Name = "Arial";
                    chkGuidanceAboutHomeHealthCare.TextFont.Bold = true;
                    chkGuidanceAboutHomeHealthCare.TextFont.CharSet = 162;
                    chkGuidanceAboutHomeHealthCare.Value = @"X";

                    chkGuidanceAboutCareSalary = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 10, 9, 14, false);
                    chkGuidanceAboutCareSalary.Name = "chkGuidanceAboutCareSalary";
                    chkGuidanceAboutCareSalary.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGuidanceAboutCareSalary.TextFont.Name = "Arial";
                    chkGuidanceAboutCareSalary.TextFont.Bold = true;
                    chkGuidanceAboutCareSalary.TextFont.CharSet = 162;
                    chkGuidanceAboutCareSalary.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField141.CalcValue = NewField141.Value;
                    NewField114611.CalcValue = NewField114611.Value;
                    NewField1126121.CalcValue = NewField1126121.Value;
                    NewField1116221.CalcValue = NewField1116221.Value;
                    GUIDANCEABOUTCARESALARYINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceAboutCareSalaryInfo) : "");
                    GUIDANCEABOUTHOMEHEALTHCRINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceAboutHomeHealthCrInfo) : "");
                    GUIDANCEABOUTLAWINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceAboutLawInfo) : "");
                    chkGuidanceAboutLaw.CalcValue = chkGuidanceAboutLaw.Value;
                    chkGuidanceAboutHomeHealthCare.CalcValue = chkGuidanceAboutHomeHealthCare.Value;
                    chkGuidanceAboutCareSalary.CalcValue = chkGuidanceAboutCareSalary.Value;
                    return new TTReportObject[] { NewField141,NewField114611,NewField1126121,NewField1116221,GUIDANCEABOUTCARESALARYINFO1,GUIDANCEABOUTHOMEHEALTHCRINFO1,GUIDANCEABOUTLAWINFO1,chkGuidanceAboutLaw,chkGuidanceAboutHomeHealthCare,chkGuidanceAboutCareSalary};
                }
            }

        }

        public group5Group group5;

        public partial class group6Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group6GroupBody Body()
            {
                return (group6GroupBody)_body;
            }
            public TTReportField NewField151 { get {return Body().NewField151;} }
            public TTReportField NewField12641 { get {return Body().NewField12641;} }
            public TTReportField NewField131621 { get {return Body().NewField131621;} }
            public TTReportField NewField132611 { get {return Body().NewField132611;} }
            public TTReportField NewField1126111 { get {return Body().NewField1126111;} }
            public TTReportField COORDWARVETERANCONTACTUNIINFO1 { get {return Body().COORDWARVETERANCONTACTUNIINFO1;} }
            public TTReportField GUIDANCETOPUBLICINSTITINFO1 { get {return Body().GUIDANCETOPUBLICINSTITINFO1;} }
            public TTReportField LEGISLATIVEREVIEWANDINFOINFO1 { get {return Body().LEGISLATIVEREVIEWANDINFOINFO1;} }
            public TTReportField PHONECALLWITPUBLICINSTITINFO1 { get {return Body().PHONECALLWITPUBLICINSTITINFO1;} }
            public TTReportField chkLegislativeReviewAndInfo { get {return Body().chkLegislativeReviewAndInfo;} }
            public TTReportField chkGuidanceToPublicInstitution { get {return Body().chkGuidanceToPublicInstitution;} }
            public TTReportField chkPhoneCallWitPublicInstitution { get {return Body().chkPhoneCallWitPublicInstitution;} }
            public TTReportField chkCoordWarVeteranContactUnit { get {return Body().chkCoordWarVeteranContactUnit;} }
            public group6Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group6Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group6GroupBody(this);
            }

            public partial class group6GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField151;
                public TTReportField NewField12641;
                public TTReportField NewField131621;
                public TTReportField NewField132611;
                public TTReportField NewField1126111;
                public TTReportField COORDWARVETERANCONTACTUNIINFO1;
                public TTReportField GUIDANCETOPUBLICINSTITINFO1;
                public TTReportField LEGISLATIVEREVIEWANDINFOINFO1;
                public TTReportField PHONECALLWITPUBLICINSTITINFO1;
                public TTReportField chkLegislativeReviewAndInfo;
                public TTReportField chkGuidanceToPublicInstitution;
                public TTReportField chkPhoneCallWitPublicInstitution;
                public TTReportField chkCoordWarVeteranContactUnit; 
                public group6GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 73;
                    RepeatCount = 0;
                    
                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 6, 134, 12, false);
                    NewField151.Name = "NewField151";
                    NewField151.TextFont.Size = 11;
                    NewField151.TextFont.Bold = true;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"6. XXXXXX sürecinde Diğer kamu Kurum/Kuruluşlarıyla eş güdümlü çalışma";

                    NewField12641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 12, 145, 17, false);
                    NewField12641.Name = "NewField12641";
                    NewField12641.TextFont.Name = "Arial";
                    NewField12641.TextFont.Italic = true;
                    NewField12641.TextFont.CharSet = 162;
                    NewField12641.Value = @"a. Kamu kurum/kuruluşlarıyla yapılan telefon görüşmesi";

                    NewField131621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 26, 124, 31, false);
                    NewField131621.Name = "NewField131621";
                    NewField131621.TextFont.Name = "Arial";
                    NewField131621.TextFont.Italic = true;
                    NewField131621.TextFont.CharSet = 162;
                    NewField131621.Value = @"b.Kamu kurum/kuruluşları ile ilgili mevzuatın incelenmesi ve bilgilendirme";

                    NewField132611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 39, 109, 44, false);
                    NewField132611.Name = "NewField132611";
                    NewField132611.TextFont.Name = "Arial";
                    NewField132611.TextFont.Italic = true;
                    NewField132611.TextFont.CharSet = 162;
                    NewField132611.Value = @"c. Kamu kurum/kuruluşlarına yönlendirme";

                    NewField1126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 52, 110, 57, false);
                    NewField1126111.Name = "NewField1126111";
                    NewField1126111.TextFont.Name = "Arial";
                    NewField1126111.TextFont.Italic = true;
                    NewField1126111.TextFont.CharSet = 162;
                    NewField1126111.Value = @"ç. XXXXXXdeki Gazi İrtibat Birimleri ile koordinasyon kurulması";

                    COORDWARVETERANCONTACTUNIINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 57, 207, 66, false);
                    COORDWARVETERANCONTACTUNIINFO1.Name = "COORDWARVETERANCONTACTUNIINFO1";
                    COORDWARVETERANCONTACTUNIINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    COORDWARVETERANCONTACTUNIINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    COORDWARVETERANCONTACTUNIINFO1.NoClip = EvetHayirEnum.ehEvet;
                    COORDWARVETERANCONTACTUNIINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    COORDWARVETERANCONTACTUNIINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    COORDWARVETERANCONTACTUNIINFO1.TextFont.Size = 8;
                    COORDWARVETERANCONTACTUNIINFO1.TextFont.CharSet = 162;
                    COORDWARVETERANCONTACTUNIINFO1.Value = @"{#Header.COORDWARVETERANCONTACTUNIINFO#}";

                    GUIDANCETOPUBLICINSTITINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 43, 207, 52, false);
                    GUIDANCETOPUBLICINSTITINFO1.Name = "GUIDANCETOPUBLICINSTITINFO1";
                    GUIDANCETOPUBLICINSTITINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCETOPUBLICINSTITINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCETOPUBLICINSTITINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCETOPUBLICINSTITINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCETOPUBLICINSTITINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCETOPUBLICINSTITINFO1.TextFont.Size = 8;
                    GUIDANCETOPUBLICINSTITINFO1.TextFont.CharSet = 162;
                    GUIDANCETOPUBLICINSTITINFO1.Value = @"{#Header.GUIDANCETOPUBLICINSTITINFO#}";

                    LEGISLATIVEREVIEWANDINFOINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 207, 39, false);
                    LEGISLATIVEREVIEWANDINFOINFO1.Name = "LEGISLATIVEREVIEWANDINFOINFO1";
                    LEGISLATIVEREVIEWANDINFOINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    LEGISLATIVEREVIEWANDINFOINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    LEGISLATIVEREVIEWANDINFOINFO1.NoClip = EvetHayirEnum.ehEvet;
                    LEGISLATIVEREVIEWANDINFOINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    LEGISLATIVEREVIEWANDINFOINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    LEGISLATIVEREVIEWANDINFOINFO1.TextFont.Size = 8;
                    LEGISLATIVEREVIEWANDINFOINFO1.TextFont.CharSet = 162;
                    LEGISLATIVEREVIEWANDINFOINFO1.Value = @"{#Header.LEGISLATIVEREVIEWANDINFOINFO#}";

                    PHONECALLWITPUBLICINSTITINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 17, 207, 26, false);
                    PHONECALLWITPUBLICINSTITINFO1.Name = "PHONECALLWITPUBLICINSTITINFO1";
                    PHONECALLWITPUBLICINSTITINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PHONECALLWITPUBLICINSTITINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    PHONECALLWITPUBLICINSTITINFO1.NoClip = EvetHayirEnum.ehEvet;
                    PHONECALLWITPUBLICINSTITINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    PHONECALLWITPUBLICINSTITINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    PHONECALLWITPUBLICINSTITINFO1.TextFont.Size = 8;
                    PHONECALLWITPUBLICINSTITINFO1.TextFont.CharSet = 162;
                    PHONECALLWITPUBLICINSTITINFO1.Value = @"{#Header.PHONECALLWITPUBLICINSTITINFO#}";

                    chkLegislativeReviewAndInfo = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 26, 9, 30, false);
                    chkLegislativeReviewAndInfo.Name = "chkLegislativeReviewAndInfo";
                    chkLegislativeReviewAndInfo.DrawStyle = DrawStyleConstants.vbSolid;
                    chkLegislativeReviewAndInfo.TextFont.Name = "Arial";
                    chkLegislativeReviewAndInfo.TextFont.Bold = true;
                    chkLegislativeReviewAndInfo.TextFont.CharSet = 162;
                    chkLegislativeReviewAndInfo.Value = @"X";

                    chkGuidanceToPublicInstitution = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 40, 9, 44, false);
                    chkGuidanceToPublicInstitution.Name = "chkGuidanceToPublicInstitution";
                    chkGuidanceToPublicInstitution.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGuidanceToPublicInstitution.TextFont.Name = "Arial";
                    chkGuidanceToPublicInstitution.TextFont.Bold = true;
                    chkGuidanceToPublicInstitution.TextFont.CharSet = 162;
                    chkGuidanceToPublicInstitution.Value = @"X";

                    chkPhoneCallWitPublicInstitution = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 12, 9, 16, false);
                    chkPhoneCallWitPublicInstitution.Name = "chkPhoneCallWitPublicInstitution";
                    chkPhoneCallWitPublicInstitution.DrawStyle = DrawStyleConstants.vbSolid;
                    chkPhoneCallWitPublicInstitution.TextFont.Name = "Arial";
                    chkPhoneCallWitPublicInstitution.TextFont.Bold = true;
                    chkPhoneCallWitPublicInstitution.TextFont.CharSet = 162;
                    chkPhoneCallWitPublicInstitution.Value = @"X";

                    chkCoordWarVeteranContactUnit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 53, 9, 57, false);
                    chkCoordWarVeteranContactUnit.Name = "chkCoordWarVeteranContactUnit";
                    chkCoordWarVeteranContactUnit.DrawStyle = DrawStyleConstants.vbSolid;
                    chkCoordWarVeteranContactUnit.TextFont.Name = "Arial";
                    chkCoordWarVeteranContactUnit.TextFont.Bold = true;
                    chkCoordWarVeteranContactUnit.TextFont.CharSet = 162;
                    chkCoordWarVeteranContactUnit.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField151.CalcValue = NewField151.Value;
                    NewField12641.CalcValue = NewField12641.Value;
                    NewField131621.CalcValue = NewField131621.Value;
                    NewField132611.CalcValue = NewField132611.Value;
                    NewField1126111.CalcValue = NewField1126111.Value;
                    COORDWARVETERANCONTACTUNIINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.CoordWarVeteranContactUniInfo) : "");
                    GUIDANCETOPUBLICINSTITINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceToPublicInstitInfo) : "");
                    LEGISLATIVEREVIEWANDINFOINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.LegislativeReviewAndInfoInfo) : "");
                    PHONECALLWITPUBLICINSTITINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.PhoneCallWitPublicInstitInfo) : "");
                    chkLegislativeReviewAndInfo.CalcValue = chkLegislativeReviewAndInfo.Value;
                    chkGuidanceToPublicInstitution.CalcValue = chkGuidanceToPublicInstitution.Value;
                    chkPhoneCallWitPublicInstitution.CalcValue = chkPhoneCallWitPublicInstitution.Value;
                    chkCoordWarVeteranContactUnit.CalcValue = chkCoordWarVeteranContactUnit.Value;
                    return new TTReportObject[] { NewField151,NewField12641,NewField131621,NewField132611,NewField1126111,COORDWARVETERANCONTACTUNIINFO1,GUIDANCETOPUBLICINSTITINFO1,LEGISLATIVEREVIEWANDINFOINFO1,PHONECALLWITPUBLICINSTITINFO1,chkLegislativeReviewAndInfo,chkGuidanceToPublicInstitution,chkPhoneCallWitPublicInstitution,chkCoordWarVeteranContactUnit};
                }
            }

        }

        public group6Group group6;

        public partial class group7Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group7GroupBody Body()
            {
                return (group7GroupBody)_body;
            }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField114621 { get {return Body().NewField114621;} }
            public TTReportField NewField1126131 { get {return Body().NewField1126131;} }
            public TTReportField ARRANGEMENTOFLIVINGPLACESINFO { get {return Body().ARRANGEMENTOFLIVINGPLACESINFO;} }
            public TTReportField ARRANGEMENTOFWORKSCHOOLENINFO { get {return Body().ARRANGEMENTOFWORKSCHOOLENINFO;} }
            public TTReportField chkArrangementOfLivingPlaces { get {return Body().chkArrangementOfLivingPlaces;} }
            public TTReportField chkArrangementOfWorkSchoolEnv { get {return Body().chkArrangementOfWorkSchoolEnv;} }
            public group7Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group7Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group7GroupBody(this);
            }

            public partial class group7GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField NewField114621;
                public TTReportField NewField1126131;
                public TTReportField ARRANGEMENTOFLIVINGPLACESINFO;
                public TTReportField ARRANGEMENTOFWORKSCHOOLENINFO;
                public TTReportField chkArrangementOfLivingPlaces;
                public TTReportField chkArrangementOfWorkSchoolEnv; 
                public group7GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 45;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 134, 11, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 11;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"7. Taburculuk sürecinde yapılan işlemler";

                    NewField114621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 96, 16, false);
                    NewField114621.Name = "NewField114621";
                    NewField114621.TextFont.Name = "Arial";
                    NewField114621.TextFont.Italic = true;
                    NewField114621.TextFont.CharSet = 162;
                    NewField114621.Value = @"a. Yaşam alanlarının düzenlenmesi";

                    NewField1126131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 88, 30, false);
                    NewField1126131.Name = "NewField1126131";
                    NewField1126131.TextFont.Name = "Arial";
                    NewField1126131.TextFont.Italic = true;
                    NewField1126131.TextFont.CharSet = 162;
                    NewField1126131.Value = @"b.İş ortamının, okul ortamının düzenlenmesi";

                    ARRANGEMENTOFLIVINGPLACESINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 16, 206, 25, false);
                    ARRANGEMENTOFLIVINGPLACESINFO.Name = "ARRANGEMENTOFLIVINGPLACESINFO";
                    ARRANGEMENTOFLIVINGPLACESINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRANGEMENTOFLIVINGPLACESINFO.MultiLine = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFLIVINGPLACESINFO.NoClip = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFLIVINGPLACESINFO.WordBreak = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFLIVINGPLACESINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFLIVINGPLACESINFO.TextFont.Size = 8;
                    ARRANGEMENTOFLIVINGPLACESINFO.TextFont.CharSet = 162;
                    ARRANGEMENTOFLIVINGPLACESINFO.Value = @"{#Header.ARRANGEMENTOFLIVINGPLACESINFO#}";

                    ARRANGEMENTOFWORKSCHOOLENINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 206, 39, false);
                    ARRANGEMENTOFWORKSCHOOLENINFO.Name = "ARRANGEMENTOFWORKSCHOOLENINFO";
                    ARRANGEMENTOFWORKSCHOOLENINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRANGEMENTOFWORKSCHOOLENINFO.MultiLine = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFWORKSCHOOLENINFO.NoClip = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFWORKSCHOOLENINFO.WordBreak = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFWORKSCHOOLENINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ARRANGEMENTOFWORKSCHOOLENINFO.TextFont.Size = 8;
                    ARRANGEMENTOFWORKSCHOOLENINFO.TextFont.CharSet = 162;
                    ARRANGEMENTOFWORKSCHOOLENINFO.Value = @"{#Header.ARRANGEMENTOFWORKSCHOOLENINFO#}";

                    chkArrangementOfLivingPlaces = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 11, 9, 15, false);
                    chkArrangementOfLivingPlaces.Name = "chkArrangementOfLivingPlaces";
                    chkArrangementOfLivingPlaces.DrawStyle = DrawStyleConstants.vbSolid;
                    chkArrangementOfLivingPlaces.TextFont.Name = "Arial";
                    chkArrangementOfLivingPlaces.TextFont.Bold = true;
                    chkArrangementOfLivingPlaces.TextFont.CharSet = 162;
                    chkArrangementOfLivingPlaces.Value = @"X";

                    chkArrangementOfWorkSchoolEnv = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 25, 9, 29, false);
                    chkArrangementOfWorkSchoolEnv.Name = "chkArrangementOfWorkSchoolEnv";
                    chkArrangementOfWorkSchoolEnv.DrawStyle = DrawStyleConstants.vbSolid;
                    chkArrangementOfWorkSchoolEnv.TextFont.Name = "Arial";
                    chkArrangementOfWorkSchoolEnv.TextFont.Bold = true;
                    chkArrangementOfWorkSchoolEnv.TextFont.CharSet = 162;
                    chkArrangementOfWorkSchoolEnv.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField114621.CalcValue = NewField114621.Value;
                    NewField1126131.CalcValue = NewField1126131.Value;
                    ARRANGEMENTOFLIVINGPLACESINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ArrangementOfLivingPlacesInfo) : "");
                    ARRANGEMENTOFWORKSCHOOLENINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ArrangementOfWorkSchoolEnInfo) : "");
                    chkArrangementOfLivingPlaces.CalcValue = chkArrangementOfLivingPlaces.Value;
                    chkArrangementOfWorkSchoolEnv.CalcValue = chkArrangementOfWorkSchoolEnv.Value;
                    return new TTReportObject[] { NewField1151,NewField114621,NewField1126131,ARRANGEMENTOFLIVINGPLACESINFO,ARRANGEMENTOFWORKSCHOOLENINFO,chkArrangementOfLivingPlaces,chkArrangementOfWorkSchoolEnv};
                }
            }

        }

        public group7Group group7;

        public partial class group8Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group8GroupBody Body()
            {
                return (group8GroupBody)_body;
            }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField114621 { get {return Body().NewField114621;} }
            public TTReportField NewField1126131 { get {return Body().NewField1126131;} }
            public TTReportField INTERCITYTRANSPORTPROCESSINFO { get {return Body().INTERCITYTRANSPORTPROCESSINFO;} }
            public TTReportField INTRACITYTRANSPORTPROCESSINFO { get {return Body().INTRACITYTRANSPORTPROCESSINFO;} }
            public TTReportField chkIntraCityTransportProcesses { get {return Body().chkIntraCityTransportProcesses;} }
            public TTReportField chkInterCityTransportProcesses { get {return Body().chkInterCityTransportProcesses;} }
            public group8Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group8Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group8GroupBody(this);
            }

            public partial class group8GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField NewField114621;
                public TTReportField NewField1126131;
                public TTReportField INTERCITYTRANSPORTPROCESSINFO;
                public TTReportField INTRACITYTRANSPORTPROCESSINFO;
                public TTReportField chkIntraCityTransportProcesses;
                public TTReportField chkInterCityTransportProcesses; 
                public group8GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 45;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 134, 11, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 11;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"8. Ulaşım işlemleri";

                    NewField114621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 11, 96, 16, false);
                    NewField114621.Name = "NewField114621";
                    NewField114621.TextFont.Name = "Arial";
                    NewField114621.TextFont.Italic = true;
                    NewField114621.TextFont.CharSet = 162;
                    NewField114621.Value = @"a. Tedavi süresince il içi ulaşım işlemler";

                    NewField1126131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 25, 124, 30, false);
                    NewField1126131.Name = "NewField1126131";
                    NewField1126131.TextFont.Name = "Arial";
                    NewField1126131.TextFont.Italic = true;
                    NewField1126131.TextFont.CharSet = 162;
                    NewField1126131.Value = @"b.Taburculuk sırasında il dışı 112 ambulans, uçak, tren v.b.";

                    INTERCITYTRANSPORTPROCESSINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 30, 206, 39, false);
                    INTERCITYTRANSPORTPROCESSINFO.Name = "INTERCITYTRANSPORTPROCESSINFO";
                    INTERCITYTRANSPORTPROCESSINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    INTERCITYTRANSPORTPROCESSINFO.MultiLine = EvetHayirEnum.ehEvet;
                    INTERCITYTRANSPORTPROCESSINFO.NoClip = EvetHayirEnum.ehEvet;
                    INTERCITYTRANSPORTPROCESSINFO.WordBreak = EvetHayirEnum.ehEvet;
                    INTERCITYTRANSPORTPROCESSINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    INTERCITYTRANSPORTPROCESSINFO.TextFont.Size = 8;
                    INTERCITYTRANSPORTPROCESSINFO.TextFont.CharSet = 162;
                    INTERCITYTRANSPORTPROCESSINFO.Value = @"{#Header.INTERCITYTRANSPORTPROCESSINFO#}";

                    INTRACITYTRANSPORTPROCESSINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 16, 206, 25, false);
                    INTRACITYTRANSPORTPROCESSINFO.Name = "INTRACITYTRANSPORTPROCESSINFO";
                    INTRACITYTRANSPORTPROCESSINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    INTRACITYTRANSPORTPROCESSINFO.MultiLine = EvetHayirEnum.ehEvet;
                    INTRACITYTRANSPORTPROCESSINFO.NoClip = EvetHayirEnum.ehEvet;
                    INTRACITYTRANSPORTPROCESSINFO.WordBreak = EvetHayirEnum.ehEvet;
                    INTRACITYTRANSPORTPROCESSINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    INTRACITYTRANSPORTPROCESSINFO.TextFont.Size = 8;
                    INTRACITYTRANSPORTPROCESSINFO.TextFont.CharSet = 162;
                    INTRACITYTRANSPORTPROCESSINFO.Value = @"{#Header.INTRACITYTRANSPORTPROCESSINFO#}";

                    chkIntraCityTransportProcesses = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 11, 9, 15, false);
                    chkIntraCityTransportProcesses.Name = "chkIntraCityTransportProcesses";
                    chkIntraCityTransportProcesses.DrawStyle = DrawStyleConstants.vbSolid;
                    chkIntraCityTransportProcesses.TextFont.Name = "Arial";
                    chkIntraCityTransportProcesses.TextFont.Bold = true;
                    chkIntraCityTransportProcesses.TextFont.CharSet = 162;
                    chkIntraCityTransportProcesses.Value = @"X";

                    chkInterCityTransportProcesses = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 25, 9, 29, false);
                    chkInterCityTransportProcesses.Name = "chkInterCityTransportProcesses";
                    chkInterCityTransportProcesses.DrawStyle = DrawStyleConstants.vbSolid;
                    chkInterCityTransportProcesses.TextFont.Name = "Arial";
                    chkInterCityTransportProcesses.TextFont.Bold = true;
                    chkInterCityTransportProcesses.TextFont.CharSet = 162;
                    chkInterCityTransportProcesses.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField114621.CalcValue = NewField114621.Value;
                    NewField1126131.CalcValue = NewField1126131.Value;
                    INTERCITYTRANSPORTPROCESSINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.InterCityTransportProcessInfo) : "");
                    INTRACITYTRANSPORTPROCESSINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.IntraCityTransportProcessInfo) : "");
                    chkIntraCityTransportProcesses.CalcValue = chkIntraCityTransportProcesses.Value;
                    chkInterCityTransportProcesses.CalcValue = chkInterCityTransportProcesses.Value;
                    return new TTReportObject[] { NewField1151,NewField114621,NewField1126131,INTERCITYTRANSPORTPROCESSINFO,INTRACITYTRANSPORTPROCESSINFO,chkIntraCityTransportProcesses,chkInterCityTransportProcesses};
                }
            }

        }

        public group8Group group8;

        public partial class group9Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group9GroupBody Body()
            {
                return (group9GroupBody)_body;
            }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField GUIDANCESERVICEONPHONE { get {return Body().GUIDANCESERVICEONPHONE;} }
            public group9Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group9Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group9GroupBody(this);
            }

            public partial class group9GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField GUIDANCESERVICEONPHONE; 
                public group9GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 23;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 134, 11, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 11;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"9. Telefonda danışmanlık hizmeti";

                    GUIDANCESERVICEONPHONE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 206, 20, false);
                    GUIDANCESERVICEONPHONE.Name = "GUIDANCESERVICEONPHONE";
                    GUIDANCESERVICEONPHONE.FieldType = ReportFieldTypeEnum.ftVariable;
                    GUIDANCESERVICEONPHONE.MultiLine = EvetHayirEnum.ehEvet;
                    GUIDANCESERVICEONPHONE.NoClip = EvetHayirEnum.ehEvet;
                    GUIDANCESERVICEONPHONE.WordBreak = EvetHayirEnum.ehEvet;
                    GUIDANCESERVICEONPHONE.ExpandTabs = EvetHayirEnum.ehEvet;
                    GUIDANCESERVICEONPHONE.TextFont.Size = 8;
                    GUIDANCESERVICEONPHONE.TextFont.CharSet = 162;
                    GUIDANCESERVICEONPHONE.Value = @"{#Header.GUIDANCESERVICEONPHONE#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    GUIDANCESERVICEONPHONE.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GuidanceServiceOnPhone) : "");
                    return new TTReportObject[] { NewField1151,GUIDANCESERVICEONPHONE};
                }
            }

        }

        public group9Group group9;

        public partial class group10Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group10GroupBody Body()
            {
                return (group10GroupBody)_body;
            }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField1126411 { get {return Body().NewField1126411;} }
            public TTReportField NewField11316211 { get {return Body().NewField11316211;} }
            public TTReportField IDENTIFICATIONOFPARTICIPINFO { get {return Body().IDENTIFICATIONOFPARTICIPINFO;} }
            public TTReportField ORGANIZINGPERMITDOCUMENTSINFO { get {return Body().ORGANIZINGPERMITDOCUMENTSINFO;} }
            public TTReportField chkIdentificationOfParticipants { get {return Body().chkIdentificationOfParticipants;} }
            public TTReportField chkOrganizingPermitDocuments { get {return Body().chkOrganizingPermitDocuments;} }
            public group10Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group10Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group10GroupBody(this);
            }

            public partial class group10GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField NewField1126411;
                public TTReportField NewField11316211;
                public TTReportField IDENTIFICATIONOFPARTICIPINFO;
                public TTReportField ORGANIZINGPERMITDOCUMENTSINFO;
                public TTReportField chkIdentificationOfParticipants;
                public TTReportField chkOrganizingPermitDocuments; 
                public group10GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 47;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 9, 134, 15, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 11;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"10. Sosyal Faaliyetler";

                    NewField1126411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 15, 96, 20, false);
                    NewField1126411.Name = "NewField1126411";
                    NewField1126411.TextFont.Name = "Arial";
                    NewField1126411.TextFont.Italic = true;
                    NewField1126411.TextFont.CharSet = 162;
                    NewField1126411.Value = @"a. Faaliyetlerde katılımcıların belirlenmesi";

                    NewField11316211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 29, 124, 34, false);
                    NewField11316211.Name = "NewField11316211";
                    NewField11316211.TextFont.Name = "Arial";
                    NewField11316211.TextFont.Italic = true;
                    NewField11316211.TextFont.CharSet = 162;
                    NewField11316211.Value = @"b.İzin belgelerinin düzenlenmesi";

                    IDENTIFICATIONOFPARTICIPINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 20, 206, 29, false);
                    IDENTIFICATIONOFPARTICIPINFO.Name = "IDENTIFICATIONOFPARTICIPINFO";
                    IDENTIFICATIONOFPARTICIPINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    IDENTIFICATIONOFPARTICIPINFO.MultiLine = EvetHayirEnum.ehEvet;
                    IDENTIFICATIONOFPARTICIPINFO.NoClip = EvetHayirEnum.ehEvet;
                    IDENTIFICATIONOFPARTICIPINFO.WordBreak = EvetHayirEnum.ehEvet;
                    IDENTIFICATIONOFPARTICIPINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    IDENTIFICATIONOFPARTICIPINFO.TextFont.Size = 8;
                    IDENTIFICATIONOFPARTICIPINFO.TextFont.CharSet = 162;
                    IDENTIFICATIONOFPARTICIPINFO.Value = @"{#Header.IDENTIFICATIONOFPARTICIPINFO#}";

                    ORGANIZINGPERMITDOCUMENTSINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 34, 206, 43, false);
                    ORGANIZINGPERMITDOCUMENTSINFO.Name = "ORGANIZINGPERMITDOCUMENTSINFO";
                    ORGANIZINGPERMITDOCUMENTSINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORGANIZINGPERMITDOCUMENTSINFO.MultiLine = EvetHayirEnum.ehEvet;
                    ORGANIZINGPERMITDOCUMENTSINFO.NoClip = EvetHayirEnum.ehEvet;
                    ORGANIZINGPERMITDOCUMENTSINFO.WordBreak = EvetHayirEnum.ehEvet;
                    ORGANIZINGPERMITDOCUMENTSINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ORGANIZINGPERMITDOCUMENTSINFO.TextFont.Size = 8;
                    ORGANIZINGPERMITDOCUMENTSINFO.TextFont.CharSet = 162;
                    ORGANIZINGPERMITDOCUMENTSINFO.Value = @"{#Header.ORGANIZINGPERMITDOCUMENTSINFO#}";

                    chkIdentificationOfParticipants = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 15, 9, 19, false);
                    chkIdentificationOfParticipants.Name = "chkIdentificationOfParticipants";
                    chkIdentificationOfParticipants.DrawStyle = DrawStyleConstants.vbSolid;
                    chkIdentificationOfParticipants.TextFont.Name = "Arial";
                    chkIdentificationOfParticipants.TextFont.Bold = true;
                    chkIdentificationOfParticipants.TextFont.CharSet = 162;
                    chkIdentificationOfParticipants.Value = @"X";

                    chkOrganizingPermitDocuments = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 29, 9, 33, false);
                    chkOrganizingPermitDocuments.Name = "chkOrganizingPermitDocuments";
                    chkOrganizingPermitDocuments.DrawStyle = DrawStyleConstants.vbSolid;
                    chkOrganizingPermitDocuments.TextFont.Name = "Arial";
                    chkOrganizingPermitDocuments.TextFont.Bold = true;
                    chkOrganizingPermitDocuments.TextFont.CharSet = 162;
                    chkOrganizingPermitDocuments.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1126411.CalcValue = NewField1126411.Value;
                    NewField11316211.CalcValue = NewField11316211.Value;
                    IDENTIFICATIONOFPARTICIPINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.IdentificationOfParticipInfo) : "");
                    ORGANIZINGPERMITDOCUMENTSINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.OrganizingPermitDocumentsInfo) : "");
                    chkIdentificationOfParticipants.CalcValue = chkIdentificationOfParticipants.Value;
                    chkOrganizingPermitDocuments.CalcValue = chkOrganizingPermitDocuments.Value;
                    return new TTReportObject[] { NewField1151,NewField1126411,NewField11316211,IDENTIFICATIONOFPARTICIPINFO,ORGANIZINGPERMITDOCUMENTSINFO,chkIdentificationOfParticipants,chkOrganizingPermitDocuments};
                }
            }

        }

        public group10Group group10;

        public partial class group11Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group11GroupBody Body()
            {
                return (group11GroupBody)_body;
            }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField11641 { get {return Body().NewField11641;} }
            public TTReportField NewField111621 { get {return Body().NewField111621;} }
            public TTReportField NewField112611 { get {return Body().NewField112611;} }
            public TTReportField NewField1126111 { get {return Body().NewField1126111;} }
            public TTReportField NewField1116211 { get {return Body().NewField1116211;} }
            public TTReportField ADVANCEPAYMENTINFO { get {return Body().ADVANCEPAYMENTINFO;} }
            public TTReportField ALLOWANCEPAYMENTINFO { get {return Body().ALLOWANCEPAYMENTINFO;} }
            public TTReportField GIVINGVETERANRIGHTSBROCINFO { get {return Body().GIVINGVETERANRIGHTSBROCINFO;} }
            public TTReportField HEALTHAIDINFO { get {return Body().HEALTHAIDINFO;} }
            public TTReportField INDEMNITYCOMPENSATIONINFO { get {return Body().INDEMNITYCOMPENSATIONINFO;} }
            public TTReportField chkHealthAid { get {return Body().chkHealthAid;} }
            public TTReportField chkAdvancePayment { get {return Body().chkAdvancePayment;} }
            public TTReportField chkIndemnityCompensation { get {return Body().chkIndemnityCompensation;} }
            public TTReportField chkAllowancePayment { get {return Body().chkAllowancePayment;} }
            public TTReportField chkGivingVeteranRightsBrochure { get {return Body().chkGivingVeteranRightsBrochure;} }
            public group11Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group11Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group11GroupBody(this);
            }

            public partial class group11GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField NewField11641;
                public TTReportField NewField111621;
                public TTReportField NewField112611;
                public TTReportField NewField1126111;
                public TTReportField NewField1116211;
                public TTReportField ADVANCEPAYMENTINFO;
                public TTReportField ALLOWANCEPAYMENTINFO;
                public TTReportField GIVINGVETERANRIGHTSBROCINFO;
                public TTReportField HEALTHAIDINFO;
                public TTReportField INDEMNITYCOMPENSATIONINFO;
                public TTReportField chkHealthAid;
                public TTReportField chkAdvancePayment;
                public TTReportField chkIndemnityCompensation;
                public TTReportField chkAllowancePayment;
                public TTReportField chkGivingVeteranRightsBrochure; 
                public group11GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 85;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 134, 13, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 11;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"11. XXXXXXde Yatan İç Güvenlik Yaralılarına Sağlanan Haklar";

                    NewField11641 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 13, 88, 18, false);
                    NewField11641.Name = "NewField11641";
                    NewField11641.TextFont.Name = "Arial";
                    NewField11641.TextFont.Italic = true;
                    NewField11641.TextFont.CharSet = 162;
                    NewField11641.Value = @"a. Sağlık Yardımı";

                    NewField111621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 27, 97, 32, false);
                    NewField111621.Name = "NewField111621";
                    NewField111621.TextFont.Name = "Arial";
                    NewField111621.TextFont.Italic = true;
                    NewField111621.TextFont.CharSet = 162;
                    NewField111621.Value = @"b. Avans Ödemesi";

                    NewField112611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 40, 109, 45, false);
                    NewField112611.Name = "NewField112611";
                    NewField112611.TextFont.Name = "Arial";
                    NewField112611.TextFont.Italic = true;
                    NewField112611.TextFont.CharSet = 162;
                    NewField112611.Value = @"c. Özel Harekat ve operasyon tazminatı";

                    NewField1126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 54, 88, 59, false);
                    NewField1126111.Name = "NewField1126111";
                    NewField1126111.TextFont.Name = "Arial";
                    NewField1126111.TextFont.Italic = true;
                    NewField1126111.TextFont.CharSet = 162;
                    NewField1126111.Value = @"ç. Harçlık Ödemesi";

                    NewField1116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 68, 88, 73, false);
                    NewField1116211.Name = "NewField1116211";
                    NewField1116211.TextFont.Name = "Arial";
                    NewField1116211.TextFont.Italic = true;
                    NewField1116211.TextFont.CharSet = 162;
                    NewField1116211.Value = @"d. Gazilere sağlanan haklar broşürünün verilmesi";

                    ADVANCEPAYMENTINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 31, 206, 40, false);
                    ADVANCEPAYMENTINFO.Name = "ADVANCEPAYMENTINFO";
                    ADVANCEPAYMENTINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ADVANCEPAYMENTINFO.MultiLine = EvetHayirEnum.ehEvet;
                    ADVANCEPAYMENTINFO.NoClip = EvetHayirEnum.ehEvet;
                    ADVANCEPAYMENTINFO.WordBreak = EvetHayirEnum.ehEvet;
                    ADVANCEPAYMENTINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ADVANCEPAYMENTINFO.TextFont.Size = 8;
                    ADVANCEPAYMENTINFO.TextFont.CharSet = 162;
                    ADVANCEPAYMENTINFO.Value = @"{#Header.ADVANCEPAYMENTINFO#}";

                    ALLOWANCEPAYMENTINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 59, 206, 68, false);
                    ALLOWANCEPAYMENTINFO.Name = "ALLOWANCEPAYMENTINFO";
                    ALLOWANCEPAYMENTINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ALLOWANCEPAYMENTINFO.MultiLine = EvetHayirEnum.ehEvet;
                    ALLOWANCEPAYMENTINFO.NoClip = EvetHayirEnum.ehEvet;
                    ALLOWANCEPAYMENTINFO.WordBreak = EvetHayirEnum.ehEvet;
                    ALLOWANCEPAYMENTINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    ALLOWANCEPAYMENTINFO.TextFont.Size = 8;
                    ALLOWANCEPAYMENTINFO.TextFont.CharSet = 162;
                    ALLOWANCEPAYMENTINFO.Value = @"{#Header.ALLOWANCEPAYMENTINFO#}";

                    GIVINGVETERANRIGHTSBROCINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 73, 206, 82, false);
                    GIVINGVETERANRIGHTSBROCINFO.Name = "GIVINGVETERANRIGHTSBROCINFO";
                    GIVINGVETERANRIGHTSBROCINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIVINGVETERANRIGHTSBROCINFO.MultiLine = EvetHayirEnum.ehEvet;
                    GIVINGVETERANRIGHTSBROCINFO.NoClip = EvetHayirEnum.ehEvet;
                    GIVINGVETERANRIGHTSBROCINFO.WordBreak = EvetHayirEnum.ehEvet;
                    GIVINGVETERANRIGHTSBROCINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    GIVINGVETERANRIGHTSBROCINFO.TextFont.Size = 8;
                    GIVINGVETERANRIGHTSBROCINFO.TextFont.CharSet = 162;
                    GIVINGVETERANRIGHTSBROCINFO.Value = @"{#Header.GIVINGVETERANRIGHTSBROCINFO#}";

                    HEALTHAIDINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 18, 206, 27, false);
                    HEALTHAIDINFO.Name = "HEALTHAIDINFO";
                    HEALTHAIDINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEALTHAIDINFO.MultiLine = EvetHayirEnum.ehEvet;
                    HEALTHAIDINFO.NoClip = EvetHayirEnum.ehEvet;
                    HEALTHAIDINFO.WordBreak = EvetHayirEnum.ehEvet;
                    HEALTHAIDINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    HEALTHAIDINFO.TextFont.Size = 8;
                    HEALTHAIDINFO.TextFont.CharSet = 162;
                    HEALTHAIDINFO.Value = @"{#Header.HEALTHAIDINFO#}";

                    INDEMNITYCOMPENSATIONINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 45, 206, 54, false);
                    INDEMNITYCOMPENSATIONINFO.Name = "INDEMNITYCOMPENSATIONINFO";
                    INDEMNITYCOMPENSATIONINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    INDEMNITYCOMPENSATIONINFO.MultiLine = EvetHayirEnum.ehEvet;
                    INDEMNITYCOMPENSATIONINFO.NoClip = EvetHayirEnum.ehEvet;
                    INDEMNITYCOMPENSATIONINFO.WordBreak = EvetHayirEnum.ehEvet;
                    INDEMNITYCOMPENSATIONINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    INDEMNITYCOMPENSATIONINFO.TextFont.Size = 8;
                    INDEMNITYCOMPENSATIONINFO.TextFont.CharSet = 162;
                    INDEMNITYCOMPENSATIONINFO.Value = @"{#Header.INDEMNITYCOMPENSATIONINFO#}";

                    chkHealthAid = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 13, 9, 17, false);
                    chkHealthAid.Name = "chkHealthAid";
                    chkHealthAid.DrawStyle = DrawStyleConstants.vbSolid;
                    chkHealthAid.TextFont.Name = "Arial";
                    chkHealthAid.TextFont.Bold = true;
                    chkHealthAid.TextFont.CharSet = 162;
                    chkHealthAid.Value = @"X";

                    chkAdvancePayment = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 27, 9, 31, false);
                    chkAdvancePayment.Name = "chkAdvancePayment";
                    chkAdvancePayment.DrawStyle = DrawStyleConstants.vbSolid;
                    chkAdvancePayment.TextFont.Name = "Arial";
                    chkAdvancePayment.TextFont.Bold = true;
                    chkAdvancePayment.TextFont.CharSet = 162;
                    chkAdvancePayment.Value = @"X";

                    chkIndemnityCompensation = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 41, 9, 45, false);
                    chkIndemnityCompensation.Name = "chkIndemnityCompensation";
                    chkIndemnityCompensation.DrawStyle = DrawStyleConstants.vbSolid;
                    chkIndemnityCompensation.TextFont.Name = "Arial";
                    chkIndemnityCompensation.TextFont.Bold = true;
                    chkIndemnityCompensation.TextFont.CharSet = 162;
                    chkIndemnityCompensation.Value = @"X";

                    chkAllowancePayment = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 55, 9, 59, false);
                    chkAllowancePayment.Name = "chkAllowancePayment";
                    chkAllowancePayment.DrawStyle = DrawStyleConstants.vbSolid;
                    chkAllowancePayment.TextFont.Name = "Arial";
                    chkAllowancePayment.TextFont.Bold = true;
                    chkAllowancePayment.TextFont.CharSet = 162;
                    chkAllowancePayment.Value = @"X";

                    chkGivingVeteranRightsBrochure = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 69, 9, 73, false);
                    chkGivingVeteranRightsBrochure.Name = "chkGivingVeteranRightsBrochure";
                    chkGivingVeteranRightsBrochure.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGivingVeteranRightsBrochure.TextFont.Name = "Arial";
                    chkGivingVeteranRightsBrochure.TextFont.Bold = true;
                    chkGivingVeteranRightsBrochure.TextFont.CharSet = 162;
                    chkGivingVeteranRightsBrochure.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField11641.CalcValue = NewField11641.Value;
                    NewField111621.CalcValue = NewField111621.Value;
                    NewField112611.CalcValue = NewField112611.Value;
                    NewField1126111.CalcValue = NewField1126111.Value;
                    NewField1116211.CalcValue = NewField1116211.Value;
                    ADVANCEPAYMENTINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.AdvancePaymentInfo) : "");
                    ALLOWANCEPAYMENTINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.AllowancePaymentInfo) : "");
                    GIVINGVETERANRIGHTSBROCINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GivingVeteranRightsBrocInfo) : "");
                    HEALTHAIDINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.HealthAidInfo) : "");
                    INDEMNITYCOMPENSATIONINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.IndemnityCompensationInfo) : "");
                    chkHealthAid.CalcValue = chkHealthAid.Value;
                    chkAdvancePayment.CalcValue = chkAdvancePayment.Value;
                    chkIndemnityCompensation.CalcValue = chkIndemnityCompensation.Value;
                    chkAllowancePayment.CalcValue = chkAllowancePayment.Value;
                    chkGivingVeteranRightsBrochure.CalcValue = chkGivingVeteranRightsBrochure.Value;
                    return new TTReportObject[] { NewField1151,NewField11641,NewField111621,NewField112611,NewField1126111,NewField1116211,ADVANCEPAYMENTINFO,ALLOWANCEPAYMENTINFO,GIVINGVETERANRIGHTSBROCINFO,HEALTHAIDINFO,INDEMNITYCOMPENSATIONINFO,chkHealthAid,chkAdvancePayment,chkIndemnityCompensation,chkAllowancePayment,chkGivingVeteranRightsBrochure};
                }
            }

        }

        public group11Group group11;

        public partial class group12Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group12GroupBody Body()
            {
                return (group12GroupBody)_body;
            }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField NewField114611 { get {return Body().NewField114611;} }
            public TTReportField NewField1126111 { get {return Body().NewField1126111;} }
            public TTReportField NewField1116211 { get {return Body().NewField1116211;} }
            public TTReportField NewField11116211 { get {return Body().NewField11116211;} }
            public TTReportField NewField11126111 { get {return Body().NewField11126111;} }
            public TTReportField NewField114612 { get {return Body().NewField114612;} }
            public TTReportField NewField1126112 { get {return Body().NewField1126112;} }
            public TTReportField NewField1116212 { get {return Body().NewField1116212;} }
            public TTReportField NewField11116212 { get {return Body().NewField11116212;} }
            public TTReportField NewField11126112 { get {return Body().NewField11126112;} }
            public TTReportField NewField114613 { get {return Body().NewField114613;} }
            public TTReportField NewField1126113 { get {return Body().NewField1126113;} }
            public TTReportField NewField1116213 { get {return Body().NewField1116213;} }
            public TTReportField CASHIDEMNITYTRANSACTIONSINFO { get {return Body().CASHIDEMNITYTRANSACTIONSINFO;} }
            public TTReportField OYAKAIDINFO { get {return Body().OYAKAIDINFO;} }
            public TTReportField SOLDIERFOUNDATIONAIDINFO { get {return Body().SOLDIERFOUNDATIONAIDINFO;} }
            public TTReportField SOLDIERLIFEINSURANCEINFO { get {return Body().SOLDIERLIFEINSURANCEINFO;} }
            public TTReportField XXXXXXSOLIDARITYFOUNDATIOAIDINFO { get {return Body().XXXXXXSOLIDARITYFOUNDATIOAIDINFO;} }
            public TTReportField JOBRESUMESTATUSINFO { get {return Body().JOBRESUMESTATUSINFO;} }
            public TTReportField RETIREMENTBONUSBYSGKINFO { get {return Body().RETIREMENTBONUSBYSGKINFO;} }
            public TTReportField SALARYSTARTBYSGKINFO { get {return Body().SALARYSTARTBYSGKINFO;} }
            public TTReportField STATEPRIDEMEDALINFO { get {return Body().STATEPRIDEMEDALINFO;} }
            public TTReportField SUPPLEMENTARYPAYMENTSGKINFO { get {return Body().SUPPLEMENTARYPAYMENTSGKINFO;} }
            public TTReportField NewField12126111 { get {return Body().NewField12126111;} }
            public TTReportField EDUCATIONAIDBYSGKINFO { get {return Body().EDUCATIONAIDBYSGKINFO;} }
            public TTReportField GRANTINGEMPLOYMENTRIGHTSINFO { get {return Body().GRANTINGEMPLOYMENTRIGHTSINFO;} }
            public TTReportField PROVIDINGWARVETERANCARDINFO { get {return Body().PROVIDINGWARVETERANCARDINFO;} }
            public TTReportField UTILIZATIONOFPUBLICHOUSININFO { get {return Body().UTILIZATIONOFPUBLICHOUSININFO;} }
            public TTReportField chkCashIdemnityTransactions { get {return Body().chkCashIdemnityTransactions;} }
            public TTReportField chkXXXXXXSolidarityFoundationAid { get {return Body().chkXXXXXXSolidarityFoundationAid;} }
            public TTReportField chkSoldierFoundationAid { get {return Body().chkSoldierFoundationAid;} }
            public TTReportField chkSoldierLifeInsurance { get {return Body().chkSoldierLifeInsurance;} }
            public TTReportField chkOYAKAid { get {return Body().chkOYAKAid;} }
            public TTReportField chkJobResumeStatus { get {return Body().chkJobResumeStatus;} }
            public TTReportField chkStatePrideMedal { get {return Body().chkStatePrideMedal;} }
            public TTReportField chkSalaryStartBySGK { get {return Body().chkSalaryStartBySGK;} }
            public TTReportField chkRetirementBonusBySGK { get {return Body().chkRetirementBonusBySGK;} }
            public TTReportField chkSupplementaryPaymentSGK { get {return Body().chkSupplementaryPaymentSGK;} }
            public TTReportField chkEducationAidBySGK { get {return Body().chkEducationAidBySGK;} }
            public TTReportField chkGrantingEmploymentRights { get {return Body().chkGrantingEmploymentRights;} }
            public TTReportField chkProvidingWarVeteranCard { get {return Body().chkProvidingWarVeteranCard;} }
            public TTReportField chkUtilizationOfPublicHousing { get {return Body().chkUtilizationOfPublicHousing;} }
            public group12Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group12Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group12GroupBody(this);
            }

            public partial class group12GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField1151;
                public TTReportField NewField114611;
                public TTReportField NewField1126111;
                public TTReportField NewField1116211;
                public TTReportField NewField11116211;
                public TTReportField NewField11126111;
                public TTReportField NewField114612;
                public TTReportField NewField1126112;
                public TTReportField NewField1116212;
                public TTReportField NewField11116212;
                public TTReportField NewField11126112;
                public TTReportField NewField114613;
                public TTReportField NewField1126113;
                public TTReportField NewField1116213;
                public TTReportField CASHIDEMNITYTRANSACTIONSINFO;
                public TTReportField OYAKAIDINFO;
                public TTReportField SOLDIERFOUNDATIONAIDINFO;
                public TTReportField SOLDIERLIFEINSURANCEINFO;
                public TTReportField XXXXXXSOLIDARITYFOUNDATIOAIDINFO;
                public TTReportField JOBRESUMESTATUSINFO;
                public TTReportField RETIREMENTBONUSBYSGKINFO;
                public TTReportField SALARYSTARTBYSGKINFO;
                public TTReportField STATEPRIDEMEDALINFO;
                public TTReportField SUPPLEMENTARYPAYMENTSGKINFO;
                public TTReportField NewField12126111;
                public TTReportField EDUCATIONAIDBYSGKINFO;
                public TTReportField GRANTINGEMPLOYMENTRIGHTSINFO;
                public TTReportField PROVIDINGWARVETERANCARDINFO;
                public TTReportField UTILIZATIONOFPUBLICHOUSININFO;
                public TTReportField chkCashIdemnityTransactions;
                public TTReportField chkXXXXXXSolidarityFoundationAid;
                public TTReportField chkSoldierFoundationAid;
                public TTReportField chkSoldierLifeInsurance;
                public TTReportField chkOYAKAid;
                public TTReportField chkJobResumeStatus;
                public TTReportField chkStatePrideMedal;
                public TTReportField chkSalaryStartBySGK;
                public TTReportField chkRetirementBonusBySGK;
                public TTReportField chkSupplementaryPaymentSGK;
                public TTReportField chkEducationAidBySGK;
                public TTReportField chkGrantingEmploymentRights;
                public TTReportField chkProvidingWarVeteranCard;
                public TTReportField chkUtilizationOfPublicHousing; 
                public group12GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 218;
                    ForceNewPage = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 8, 134, 14, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.TextFont.Size = 11;
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"12. Gazilere Sağlanan Haklar";

                    NewField114611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 14, 88, 19, false);
                    NewField114611.Name = "NewField114611";
                    NewField114611.TextFont.Name = "Arial";
                    NewField114611.TextFont.Italic = true;
                    NewField114611.TextFont.CharSet = 162;
                    NewField114611.Value = @"a. Nakdi Tazminat İşlemleri";

                    NewField1126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 28, 97, 33, false);
                    NewField1126111.Name = "NewField1126111";
                    NewField1126111.TextFont.Name = "Arial";
                    NewField1126111.TextFont.Italic = true;
                    NewField1126111.TextFont.CharSet = 162;
                    NewField1126111.Value = @"b. XXXXXX Dayanışma Vakfı Yardımı";

                    NewField1116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 42, 109, 47, false);
                    NewField1116211.Name = "NewField1116211";
                    NewField1116211.TextFont.Name = "Arial";
                    NewField1116211.TextFont.Italic = true;
                    NewField1116211.TextFont.CharSet = 162;
                    NewField1116211.Value = @"c. Mehmetçik Vakfı Yardımları";

                    NewField11116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 56, 88, 61, false);
                    NewField11116211.Name = "NewField11116211";
                    NewField11116211.TextFont.Name = "Arial";
                    NewField11116211.TextFont.Italic = true;
                    NewField11116211.TextFont.CharSet = 162;
                    NewField11116211.Value = @"ç. Mehmetçik Yaşam Sigortası";

                    NewField11126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 70, 88, 75, false);
                    NewField11126111.Name = "NewField11126111";
                    NewField11126111.TextFont.Name = "Arial";
                    NewField11126111.TextFont.Italic = true;
                    NewField11126111.TextFont.CharSet = 162;
                    NewField11126111.Value = @"d. OYAK Yardımı";

                    NewField114612 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 84, 88, 89, false);
                    NewField114612.Name = "NewField114612";
                    NewField114612.TextFont.Name = "Arial";
                    NewField114612.TextFont.Italic = true;
                    NewField114612.TextFont.CharSet = 162;
                    NewField114612.Value = @"e. Göreve devam etme durumu";

                    NewField1126112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 98, 97, 103, false);
                    NewField1126112.Name = "NewField1126112";
                    NewField1126112.TextFont.Name = "Arial";
                    NewField1126112.TextFont.Italic = true;
                    NewField1126112.TextFont.CharSet = 162;
                    NewField1126112.Value = @"f. Devlet Övünç Madalyası, malul gazi rozeti";

                    NewField1116212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 126, 109, 131, false);
                    NewField1116212.Name = "NewField1116212";
                    NewField1116212.TextFont.Name = "Arial";
                    NewField1116212.TextFont.Italic = true;
                    NewField1116212.TextFont.CharSet = 162;
                    NewField1116212.Value = @"ğ. SGK tarafından emekli ikramiyesi verilmesi";

                    NewField11116212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 140, 88, 145, false);
                    NewField11116212.Name = "NewField11116212";
                    NewField11116212.TextFont.Name = "Arial";
                    NewField11116212.TextFont.Italic = true;
                    NewField11116212.TextFont.CharSet = 162;
                    NewField11116212.Value = @"h. SGK Ek ödeme";

                    NewField11126112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 154, 88, 159, false);
                    NewField11126112.Name = "NewField11126112";
                    NewField11126112.TextFont.Name = "Arial";
                    NewField11126112.TextFont.Italic = true;
                    NewField11126112.TextFont.CharSet = 162;
                    NewField11126112.Value = @"ı. SGK öğrenim yardımı";

                    NewField114613 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 168, 88, 173, false);
                    NewField114613.Name = "NewField114613";
                    NewField114613.TextFont.Name = "Arial";
                    NewField114613.TextFont.Italic = true;
                    NewField114613.TextFont.CharSet = 162;
                    NewField114613.Value = @"i. ASBP tarafından iş hakkı verilmesi";

                    NewField1126113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 182, 97, 187, false);
                    NewField1126113.Name = "NewField1126113";
                    NewField1126113.TextFont.Name = "Arial";
                    NewField1126113.TextFont.Italic = true;
                    NewField1126113.TextFont.CharSet = 162;
                    NewField1126113.Value = @"j. ASBP gazi kartı verilmesi";

                    NewField1116213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 196, 109, 201, false);
                    NewField1116213.Name = "NewField1116213";
                    NewField1116213.TextFont.Name = "Arial";
                    NewField1116213.TextFont.Italic = true;
                    NewField1116213.TextFont.CharSet = 162;
                    NewField1116213.Value = @"k. Kamu konutlarından yararlanma ve kira yardımı";

                    CASHIDEMNITYTRANSACTIONSINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 19, 206, 28, false);
                    CASHIDEMNITYTRANSACTIONSINFO.Name = "CASHIDEMNITYTRANSACTIONSINFO";
                    CASHIDEMNITYTRANSACTIONSINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    CASHIDEMNITYTRANSACTIONSINFO.MultiLine = EvetHayirEnum.ehEvet;
                    CASHIDEMNITYTRANSACTIONSINFO.NoClip = EvetHayirEnum.ehEvet;
                    CASHIDEMNITYTRANSACTIONSINFO.WordBreak = EvetHayirEnum.ehEvet;
                    CASHIDEMNITYTRANSACTIONSINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    CASHIDEMNITYTRANSACTIONSINFO.TextFont.Size = 8;
                    CASHIDEMNITYTRANSACTIONSINFO.TextFont.CharSet = 162;
                    CASHIDEMNITYTRANSACTIONSINFO.Value = @"{#Header.CASHIDEMNITYTRANSACTIONSINFO#}";

                    OYAKAIDINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 75, 206, 84, false);
                    OYAKAIDINFO.Name = "OYAKAIDINFO";
                    OYAKAIDINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    OYAKAIDINFO.MultiLine = EvetHayirEnum.ehEvet;
                    OYAKAIDINFO.NoClip = EvetHayirEnum.ehEvet;
                    OYAKAIDINFO.WordBreak = EvetHayirEnum.ehEvet;
                    OYAKAIDINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    OYAKAIDINFO.TextFont.Size = 8;
                    OYAKAIDINFO.TextFont.CharSet = 162;
                    OYAKAIDINFO.Value = @"{#Header.OYAKAIDINFO#}";

                    SOLDIERFOUNDATIONAIDINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 47, 206, 56, false);
                    SOLDIERFOUNDATIONAIDINFO.Name = "SOLDIERFOUNDATIONAIDINFO";
                    SOLDIERFOUNDATIONAIDINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOLDIERFOUNDATIONAIDINFO.MultiLine = EvetHayirEnum.ehEvet;
                    SOLDIERFOUNDATIONAIDINFO.NoClip = EvetHayirEnum.ehEvet;
                    SOLDIERFOUNDATIONAIDINFO.WordBreak = EvetHayirEnum.ehEvet;
                    SOLDIERFOUNDATIONAIDINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SOLDIERFOUNDATIONAIDINFO.TextFont.Size = 8;
                    SOLDIERFOUNDATIONAIDINFO.TextFont.CharSet = 162;
                    SOLDIERFOUNDATIONAIDINFO.Value = @"{#Header.SOLDIERFOUNDATIONAIDINFO#}";

                    SOLDIERLIFEINSURANCEINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 61, 206, 70, false);
                    SOLDIERLIFEINSURANCEINFO.Name = "SOLDIERLIFEINSURANCEINFO";
                    SOLDIERLIFEINSURANCEINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SOLDIERLIFEINSURANCEINFO.MultiLine = EvetHayirEnum.ehEvet;
                    SOLDIERLIFEINSURANCEINFO.NoClip = EvetHayirEnum.ehEvet;
                    SOLDIERLIFEINSURANCEINFO.WordBreak = EvetHayirEnum.ehEvet;
                    SOLDIERLIFEINSURANCEINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SOLDIERLIFEINSURANCEINFO.TextFont.Size = 8;
                    SOLDIERLIFEINSURANCEINFO.TextFont.CharSet = 162;
                    SOLDIERLIFEINSURANCEINFO.Value = @"{#Header.SOLDIERLIFEINSURANCEINFO#}";

                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 33, 206, 42, false);
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.Name = "XXXXXXSOLIDARITYFOUNDATIOAIDINFO";
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.MultiLine = EvetHayirEnum.ehEvet;
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.NoClip = EvetHayirEnum.ehEvet;
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.WordBreak = EvetHayirEnum.ehEvet;
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.TextFont.Size = 8;
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.TextFont.CharSet = 162;
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.Value = @"{#Header.XXXXXXSOLIDARITYFOUNDATIOAIDINFO#}";

                    JOBRESUMESTATUSINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 89, 206, 98, false);
                    JOBRESUMESTATUSINFO.Name = "JOBRESUMESTATUSINFO";
                    JOBRESUMESTATUSINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    JOBRESUMESTATUSINFO.MultiLine = EvetHayirEnum.ehEvet;
                    JOBRESUMESTATUSINFO.NoClip = EvetHayirEnum.ehEvet;
                    JOBRESUMESTATUSINFO.WordBreak = EvetHayirEnum.ehEvet;
                    JOBRESUMESTATUSINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    JOBRESUMESTATUSINFO.TextFont.Size = 8;
                    JOBRESUMESTATUSINFO.TextFont.CharSet = 162;
                    JOBRESUMESTATUSINFO.Value = @"{#Header.JOBRESUMESTATUSINFO#}";

                    RETIREMENTBONUSBYSGKINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 131, 206, 140, false);
                    RETIREMENTBONUSBYSGKINFO.Name = "RETIREMENTBONUSBYSGKINFO";
                    RETIREMENTBONUSBYSGKINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    RETIREMENTBONUSBYSGKINFO.MultiLine = EvetHayirEnum.ehEvet;
                    RETIREMENTBONUSBYSGKINFO.NoClip = EvetHayirEnum.ehEvet;
                    RETIREMENTBONUSBYSGKINFO.WordBreak = EvetHayirEnum.ehEvet;
                    RETIREMENTBONUSBYSGKINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    RETIREMENTBONUSBYSGKINFO.TextFont.Size = 8;
                    RETIREMENTBONUSBYSGKINFO.TextFont.CharSet = 162;
                    RETIREMENTBONUSBYSGKINFO.Value = @"{#Header.RETIREMENTBONUSBYSGKINFO#}";

                    SALARYSTARTBYSGKINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 117, 206, 126, false);
                    SALARYSTARTBYSGKINFO.Name = "SALARYSTARTBYSGKINFO";
                    SALARYSTARTBYSGKINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SALARYSTARTBYSGKINFO.MultiLine = EvetHayirEnum.ehEvet;
                    SALARYSTARTBYSGKINFO.NoClip = EvetHayirEnum.ehEvet;
                    SALARYSTARTBYSGKINFO.WordBreak = EvetHayirEnum.ehEvet;
                    SALARYSTARTBYSGKINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SALARYSTARTBYSGKINFO.TextFont.Size = 8;
                    SALARYSTARTBYSGKINFO.TextFont.CharSet = 162;
                    SALARYSTARTBYSGKINFO.Value = @"{#Header.SALARYSTARTBYSGKINFO#}";

                    STATEPRIDEMEDALINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 103, 206, 112, false);
                    STATEPRIDEMEDALINFO.Name = "STATEPRIDEMEDALINFO";
                    STATEPRIDEMEDALINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    STATEPRIDEMEDALINFO.MultiLine = EvetHayirEnum.ehEvet;
                    STATEPRIDEMEDALINFO.NoClip = EvetHayirEnum.ehEvet;
                    STATEPRIDEMEDALINFO.WordBreak = EvetHayirEnum.ehEvet;
                    STATEPRIDEMEDALINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    STATEPRIDEMEDALINFO.TextFont.Size = 8;
                    STATEPRIDEMEDALINFO.TextFont.CharSet = 162;
                    STATEPRIDEMEDALINFO.Value = @"{#Header.STATEPRIDEMEDALINFO#}";

                    SUPPLEMENTARYPAYMENTSGKINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 145, 206, 154, false);
                    SUPPLEMENTARYPAYMENTSGKINFO.Name = "SUPPLEMENTARYPAYMENTSGKINFO";
                    SUPPLEMENTARYPAYMENTSGKINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SUPPLEMENTARYPAYMENTSGKINFO.MultiLine = EvetHayirEnum.ehEvet;
                    SUPPLEMENTARYPAYMENTSGKINFO.NoClip = EvetHayirEnum.ehEvet;
                    SUPPLEMENTARYPAYMENTSGKINFO.WordBreak = EvetHayirEnum.ehEvet;
                    SUPPLEMENTARYPAYMENTSGKINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    SUPPLEMENTARYPAYMENTSGKINFO.TextFont.Size = 8;
                    SUPPLEMENTARYPAYMENTSGKINFO.TextFont.CharSet = 162;
                    SUPPLEMENTARYPAYMENTSGKINFO.Value = @"{#Header.SUPPLEMENTARYPAYMENTSGKINFO#}";

                    NewField12126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 112, 109, 117, false);
                    NewField12126111.Name = "NewField12126111";
                    NewField12126111.TextFont.Name = "Arial";
                    NewField12126111.TextFont.Italic = true;
                    NewField12126111.TextFont.CharSet = 162;
                    NewField12126111.Value = @"g. SGK tarafından maaş bağlanması";

                    EDUCATIONAIDBYSGKINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 159, 206, 168, false);
                    EDUCATIONAIDBYSGKINFO.Name = "EDUCATIONAIDBYSGKINFO";
                    EDUCATIONAIDBYSGKINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    EDUCATIONAIDBYSGKINFO.MultiLine = EvetHayirEnum.ehEvet;
                    EDUCATIONAIDBYSGKINFO.NoClip = EvetHayirEnum.ehEvet;
                    EDUCATIONAIDBYSGKINFO.WordBreak = EvetHayirEnum.ehEvet;
                    EDUCATIONAIDBYSGKINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    EDUCATIONAIDBYSGKINFO.TextFont.Size = 8;
                    EDUCATIONAIDBYSGKINFO.TextFont.CharSet = 162;
                    EDUCATIONAIDBYSGKINFO.Value = @"{#Header.EDUCATIONAIDBYSGKINFO#}";

                    GRANTINGEMPLOYMENTRIGHTSINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 173, 206, 182, false);
                    GRANTINGEMPLOYMENTRIGHTSINFO.Name = "GRANTINGEMPLOYMENTRIGHTSINFO";
                    GRANTINGEMPLOYMENTRIGHTSINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANTINGEMPLOYMENTRIGHTSINFO.MultiLine = EvetHayirEnum.ehEvet;
                    GRANTINGEMPLOYMENTRIGHTSINFO.NoClip = EvetHayirEnum.ehEvet;
                    GRANTINGEMPLOYMENTRIGHTSINFO.WordBreak = EvetHayirEnum.ehEvet;
                    GRANTINGEMPLOYMENTRIGHTSINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    GRANTINGEMPLOYMENTRIGHTSINFO.TextFont.Size = 8;
                    GRANTINGEMPLOYMENTRIGHTSINFO.TextFont.CharSet = 162;
                    GRANTINGEMPLOYMENTRIGHTSINFO.Value = @"{#Header.GRANTINGEMPLOYMENTRIGHTSINFO#}";

                    PROVIDINGWARVETERANCARDINFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 187, 206, 196, false);
                    PROVIDINGWARVETERANCARDINFO.Name = "PROVIDINGWARVETERANCARDINFO";
                    PROVIDINGWARVETERANCARDINFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIDINGWARVETERANCARDINFO.MultiLine = EvetHayirEnum.ehEvet;
                    PROVIDINGWARVETERANCARDINFO.NoClip = EvetHayirEnum.ehEvet;
                    PROVIDINGWARVETERANCARDINFO.WordBreak = EvetHayirEnum.ehEvet;
                    PROVIDINGWARVETERANCARDINFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROVIDINGWARVETERANCARDINFO.TextFont.Size = 8;
                    PROVIDINGWARVETERANCARDINFO.TextFont.CharSet = 162;
                    PROVIDINGWARVETERANCARDINFO.Value = @"{#Header.PROVIDINGWARVETERANCARDINFO#}";

                    UTILIZATIONOFPUBLICHOUSININFO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 201, 206, 210, false);
                    UTILIZATIONOFPUBLICHOUSININFO.Name = "UTILIZATIONOFPUBLICHOUSININFO";
                    UTILIZATIONOFPUBLICHOUSININFO.FieldType = ReportFieldTypeEnum.ftVariable;
                    UTILIZATIONOFPUBLICHOUSININFO.MultiLine = EvetHayirEnum.ehEvet;
                    UTILIZATIONOFPUBLICHOUSININFO.NoClip = EvetHayirEnum.ehEvet;
                    UTILIZATIONOFPUBLICHOUSININFO.WordBreak = EvetHayirEnum.ehEvet;
                    UTILIZATIONOFPUBLICHOUSININFO.ExpandTabs = EvetHayirEnum.ehEvet;
                    UTILIZATIONOFPUBLICHOUSININFO.TextFont.Size = 8;
                    UTILIZATIONOFPUBLICHOUSININFO.TextFont.CharSet = 162;
                    UTILIZATIONOFPUBLICHOUSININFO.Value = @"{#Header.UTILIZATIONOFPUBLICHOUSININFO#}";

                    chkCashIdemnityTransactions = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 14, 9, 18, false);
                    chkCashIdemnityTransactions.Name = "chkCashIdemnityTransactions";
                    chkCashIdemnityTransactions.DrawStyle = DrawStyleConstants.vbSolid;
                    chkCashIdemnityTransactions.TextFont.Name = "Arial";
                    chkCashIdemnityTransactions.TextFont.Bold = true;
                    chkCashIdemnityTransactions.TextFont.CharSet = 162;
                    chkCashIdemnityTransactions.Value = @"X";

                    chkXXXXXXSolidarityFoundationAid = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 28, 9, 32, false);
                    chkXXXXXXSolidarityFoundationAid.Name = "chkXXXXXXSolidarityFoundationAid";
                    chkXXXXXXSolidarityFoundationAid.DrawStyle = DrawStyleConstants.vbSolid;
                    chkXXXXXXSolidarityFoundationAid.TextFont.Name = "Arial";
                    chkXXXXXXSolidarityFoundationAid.TextFont.Bold = true;
                    chkXXXXXXSolidarityFoundationAid.TextFont.CharSet = 162;
                    chkXXXXXXSolidarityFoundationAid.Value = @"X";

                    chkSoldierFoundationAid = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 42, 9, 46, false);
                    chkSoldierFoundationAid.Name = "chkSoldierFoundationAid";
                    chkSoldierFoundationAid.DrawStyle = DrawStyleConstants.vbSolid;
                    chkSoldierFoundationAid.TextFont.Name = "Arial";
                    chkSoldierFoundationAid.TextFont.Bold = true;
                    chkSoldierFoundationAid.TextFont.CharSet = 162;
                    chkSoldierFoundationAid.Value = @"X";

                    chkSoldierLifeInsurance = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 56, 9, 60, false);
                    chkSoldierLifeInsurance.Name = "chkSoldierLifeInsurance";
                    chkSoldierLifeInsurance.DrawStyle = DrawStyleConstants.vbSolid;
                    chkSoldierLifeInsurance.TextFont.Name = "Arial";
                    chkSoldierLifeInsurance.TextFont.Bold = true;
                    chkSoldierLifeInsurance.TextFont.CharSet = 162;
                    chkSoldierLifeInsurance.Value = @"X";

                    chkOYAKAid = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 70, 9, 74, false);
                    chkOYAKAid.Name = "chkOYAKAid";
                    chkOYAKAid.DrawStyle = DrawStyleConstants.vbSolid;
                    chkOYAKAid.TextFont.Name = "Arial";
                    chkOYAKAid.TextFont.Bold = true;
                    chkOYAKAid.TextFont.CharSet = 162;
                    chkOYAKAid.Value = @"X";

                    chkJobResumeStatus = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 84, 9, 88, false);
                    chkJobResumeStatus.Name = "chkJobResumeStatus";
                    chkJobResumeStatus.DrawStyle = DrawStyleConstants.vbSolid;
                    chkJobResumeStatus.TextFont.Name = "Arial";
                    chkJobResumeStatus.TextFont.Bold = true;
                    chkJobResumeStatus.TextFont.CharSet = 162;
                    chkJobResumeStatus.Value = @"X";

                    chkStatePrideMedal = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 98, 9, 102, false);
                    chkStatePrideMedal.Name = "chkStatePrideMedal";
                    chkStatePrideMedal.DrawStyle = DrawStyleConstants.vbSolid;
                    chkStatePrideMedal.TextFont.Name = "Arial";
                    chkStatePrideMedal.TextFont.Bold = true;
                    chkStatePrideMedal.TextFont.CharSet = 162;
                    chkStatePrideMedal.Value = @"X";

                    chkSalaryStartBySGK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 112, 9, 116, false);
                    chkSalaryStartBySGK.Name = "chkSalaryStartBySGK";
                    chkSalaryStartBySGK.DrawStyle = DrawStyleConstants.vbSolid;
                    chkSalaryStartBySGK.TextFont.Name = "Arial";
                    chkSalaryStartBySGK.TextFont.Bold = true;
                    chkSalaryStartBySGK.TextFont.CharSet = 162;
                    chkSalaryStartBySGK.Value = @"X";

                    chkRetirementBonusBySGK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 126, 9, 130, false);
                    chkRetirementBonusBySGK.Name = "chkRetirementBonusBySGK";
                    chkRetirementBonusBySGK.DrawStyle = DrawStyleConstants.vbSolid;
                    chkRetirementBonusBySGK.TextFont.Name = "Arial";
                    chkRetirementBonusBySGK.TextFont.Bold = true;
                    chkRetirementBonusBySGK.TextFont.CharSet = 162;
                    chkRetirementBonusBySGK.Value = @"X";

                    chkSupplementaryPaymentSGK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 140, 9, 144, false);
                    chkSupplementaryPaymentSGK.Name = "chkSupplementaryPaymentSGK";
                    chkSupplementaryPaymentSGK.DrawStyle = DrawStyleConstants.vbSolid;
                    chkSupplementaryPaymentSGK.TextFont.Name = "Arial";
                    chkSupplementaryPaymentSGK.TextFont.Bold = true;
                    chkSupplementaryPaymentSGK.TextFont.CharSet = 162;
                    chkSupplementaryPaymentSGK.Value = @"X";

                    chkEducationAidBySGK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 154, 9, 158, false);
                    chkEducationAidBySGK.Name = "chkEducationAidBySGK";
                    chkEducationAidBySGK.DrawStyle = DrawStyleConstants.vbSolid;
                    chkEducationAidBySGK.TextFont.Name = "Arial";
                    chkEducationAidBySGK.TextFont.Bold = true;
                    chkEducationAidBySGK.TextFont.CharSet = 162;
                    chkEducationAidBySGK.Value = @"X";

                    chkGrantingEmploymentRights = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 168, 9, 172, false);
                    chkGrantingEmploymentRights.Name = "chkGrantingEmploymentRights";
                    chkGrantingEmploymentRights.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGrantingEmploymentRights.TextFont.Name = "Arial";
                    chkGrantingEmploymentRights.TextFont.Bold = true;
                    chkGrantingEmploymentRights.TextFont.CharSet = 162;
                    chkGrantingEmploymentRights.Value = @"X";

                    chkProvidingWarVeteranCard = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 182, 9, 186, false);
                    chkProvidingWarVeteranCard.Name = "chkProvidingWarVeteranCard";
                    chkProvidingWarVeteranCard.DrawStyle = DrawStyleConstants.vbSolid;
                    chkProvidingWarVeteranCard.TextFont.Name = "Arial";
                    chkProvidingWarVeteranCard.TextFont.Bold = true;
                    chkProvidingWarVeteranCard.TextFont.CharSet = 162;
                    chkProvidingWarVeteranCard.Value = @"X";

                    chkUtilizationOfPublicHousing = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 196, 9, 200, false);
                    chkUtilizationOfPublicHousing.Name = "chkUtilizationOfPublicHousing";
                    chkUtilizationOfPublicHousing.DrawStyle = DrawStyleConstants.vbSolid;
                    chkUtilizationOfPublicHousing.TextFont.Name = "Arial";
                    chkUtilizationOfPublicHousing.TextFont.Bold = true;
                    chkUtilizationOfPublicHousing.TextFont.CharSet = 162;
                    chkUtilizationOfPublicHousing.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField114611.CalcValue = NewField114611.Value;
                    NewField1126111.CalcValue = NewField1126111.Value;
                    NewField1116211.CalcValue = NewField1116211.Value;
                    NewField11116211.CalcValue = NewField11116211.Value;
                    NewField11126111.CalcValue = NewField11126111.Value;
                    NewField114612.CalcValue = NewField114612.Value;
                    NewField1126112.CalcValue = NewField1126112.Value;
                    NewField1116212.CalcValue = NewField1116212.Value;
                    NewField11116212.CalcValue = NewField11116212.Value;
                    NewField11126112.CalcValue = NewField11126112.Value;
                    NewField114613.CalcValue = NewField114613.Value;
                    NewField1126113.CalcValue = NewField1126113.Value;
                    NewField1116213.CalcValue = NewField1116213.Value;
                    CASHIDEMNITYTRANSACTIONSINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.CashIdemnityTransactionsInfo) : "");
                    OYAKAIDINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.OYAKAidInfo) : "");
                    SOLDIERFOUNDATIONAIDINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.SoldierFoundationAidInfo) : "");
                    SOLDIERLIFEINSURANCEINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.SoldierLifeInsuranceInfo) : "");
                    XXXXXXSOLIDARITYFOUNDATIOAIDINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.XXXXXXSolidarityFoundatioAidInfo) : "");
                    JOBRESUMESTATUSINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.JobResumeStatusInfo) : "");
                    RETIREMENTBONUSBYSGKINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.RetirementBonusBySGKInfo) : "");
                    SALARYSTARTBYSGKINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.SalaryStartBySGKInfo) : "");
                    STATEPRIDEMEDALINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.StatePrideMedalInfo) : "");
                    SUPPLEMENTARYPAYMENTSGKINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.SupplementaryPaymentSGKInfo) : "");
                    NewField12126111.CalcValue = NewField12126111.Value;
                    EDUCATIONAIDBYSGKINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.EducationAidBySGKInfo) : "");
                    GRANTINGEMPLOYMENTRIGHTSINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GrantingEmploymentRightsInfo) : "");
                    PROVIDINGWARVETERANCARDINFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ProvidingWarVeteranCardInfo) : "");
                    UTILIZATIONOFPUBLICHOUSININFO.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.UtilizationOfPublicHousinInfo) : "");
                    chkCashIdemnityTransactions.CalcValue = chkCashIdemnityTransactions.Value;
                    chkXXXXXXSolidarityFoundationAid.CalcValue = chkXXXXXXSolidarityFoundationAid.Value;
                    chkSoldierFoundationAid.CalcValue = chkSoldierFoundationAid.Value;
                    chkSoldierLifeInsurance.CalcValue = chkSoldierLifeInsurance.Value;
                    chkOYAKAid.CalcValue = chkOYAKAid.Value;
                    chkJobResumeStatus.CalcValue = chkJobResumeStatus.Value;
                    chkStatePrideMedal.CalcValue = chkStatePrideMedal.Value;
                    chkSalaryStartBySGK.CalcValue = chkSalaryStartBySGK.Value;
                    chkRetirementBonusBySGK.CalcValue = chkRetirementBonusBySGK.Value;
                    chkSupplementaryPaymentSGK.CalcValue = chkSupplementaryPaymentSGK.Value;
                    chkEducationAidBySGK.CalcValue = chkEducationAidBySGK.Value;
                    chkGrantingEmploymentRights.CalcValue = chkGrantingEmploymentRights.Value;
                    chkProvidingWarVeteranCard.CalcValue = chkProvidingWarVeteranCard.Value;
                    chkUtilizationOfPublicHousing.CalcValue = chkUtilizationOfPublicHousing.Value;
                    return new TTReportObject[] { NewField1151,NewField114611,NewField1126111,NewField1116211,NewField11116211,NewField11126111,NewField114612,NewField1126112,NewField1116212,NewField11116212,NewField11126112,NewField114613,NewField1126113,NewField1116213,CASHIDEMNITYTRANSACTIONSINFO,OYAKAIDINFO,SOLDIERFOUNDATIONAIDINFO,SOLDIERLIFEINSURANCEINFO,XXXXXXSOLIDARITYFOUNDATIOAIDINFO,JOBRESUMESTATUSINFO,RETIREMENTBONUSBYSGKINFO,SALARYSTARTBYSGKINFO,STATEPRIDEMEDALINFO,SUPPLEMENTARYPAYMENTSGKINFO,NewField12126111,EDUCATIONAIDBYSGKINFO,GRANTINGEMPLOYMENTRIGHTSINFO,PROVIDINGWARVETERANCARDINFO,UTILIZATIONOFPUBLICHOUSININFO,chkCashIdemnityTransactions,chkXXXXXXSolidarityFoundationAid,chkSoldierFoundationAid,chkSoldierLifeInsurance,chkOYAKAid,chkJobResumeStatus,chkStatePrideMedal,chkSalaryStartBySGK,chkRetirementBonusBySGK,chkSupplementaryPaymentSGK,chkEducationAidBySGK,chkGrantingEmploymentRights,chkProvidingWarVeteranCard,chkUtilizationOfPublicHousing};
                }
            }

        }

        public group12Group group12;

        public partial class group13Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group13GroupBody Body()
            {
                return (group13GroupBody)_body;
            }
            public TTReportField NewField131261111 { get {return Body().NewField131261111;} }
            public TTReportField NewField131162111 { get {return Body().NewField131162111;} }
            public TTReportField NewField1416411 { get {return Body().NewField1416411;} }
            public TTReportField NewField14116211 { get {return Body().NewField14116211;} }
            public TTReportField NewField14126111 { get {return Body().NewField14126111;} }
            public TTReportField NewField141261111 { get {return Body().NewField141261111;} }
            public TTReportField NewField141162111 { get {return Body().NewField141162111;} }
            public TTReportField NewField1516411 { get {return Body().NewField1516411;} }
            public TTReportField NewField15116211 { get {return Body().NewField15116211;} }
            public TTReportField NewField15126111 { get {return Body().NewField15126111;} }
            public TTReportField NewField151261111 { get {return Body().NewField151261111;} }
            public TTReportField NewField151162111 { get {return Body().NewField151162111;} }
            public TTReportField NewField111162151 { get {return Body().NewField111162151;} }
            public TTReportField NewField1111162151 { get {return Body().NewField1111162151;} }
            public TTReportField NewField1111261151 { get {return Body().NewField1111261151;} }
            public TTReportField PROVIDEHOUSETODISABLSTAFFINFO1 { get {return Body().PROVIDEHOUSETODISABLSTAFFINFO1;} }
            public TTReportField ELECTRICANDWATERDISCOUNTINFO1 { get {return Body().ELECTRICANDWATERDISCOUNTINFO1;} }
            public TTReportField GIVINGCORPORATEHOUSCREDITINFO1 { get {return Body().GIVINGCORPORATEHOUSCREDITINFO1;} }
            public TTReportField INCOMETAXDISCOUNTINFO1 { get {return Body().INCOMETAXDISCOUNTINFO1;} }
            public TTReportField RESIDENCETAXEXEMPTIONINFO1 { get {return Body().RESIDENCETAXEXEMPTIONINFO1;} }
            public TTReportField USAGERIGHTFROMTOKIHOUSESINFO1 { get {return Body().USAGERIGHTFROMTOKIHOUSESINFO1;} }
            public TTReportField BROTHEREXEMPTIONFROMMILITINFO1 { get {return Body().BROTHEREXEMPTIONFROMMILITINFO1;} }
            public TTReportField DOMESTICVEHICLEPURCHASESINFO1 { get {return Body().DOMESTICVEHICLEPURCHASESINFO1;} }
            public TTReportField IMPORTINGDUTYFREEVEHICLEINFO1 { get {return Body().IMPORTINGDUTYFREEVEHICLEINFO1;} }
            public TTReportField MILITARSERVNEARBROTHERHOMINFO1 { get {return Body().MILITARSERVNEARBROTHERHOMINFO1;} }
            public TTReportField OTVANDMTVEXEMPTIONINFO1 { get {return Body().OTVANDMTVEXEMPTIONINFO1;} }
            public TTReportField FREEACCESSTOPRIVEDUINSTITINFO1 { get {return Body().FREEACCESSTOPRIVEDUINSTITINFO1;} }
            public TTReportField GRANTINGDEALERSHIPINFO1 { get {return Body().GRANTINGDEALERSHIPINFO1;} }
            public TTReportField UTILITYFROMREHABILITCENTINFO1 { get {return Body().UTILITYFROMREHABILITCENTINFO1;} }
            public TTReportField WEAPONPORTAGETRANSPORTLICINFO1 { get {return Body().WEAPONPORTAGETRANSPORTLICINFO1;} }
            public TTReportField chkProvideHouseToDisabledStaff { get {return Body().chkProvideHouseToDisabledStaff;} }
            public TTReportField chkGivingCorporateHousingCredit { get {return Body().chkGivingCorporateHousingCredit;} }
            public TTReportField chkUsageRightFromTOKIHouses { get {return Body().chkUsageRightFromTOKIHouses;} }
            public TTReportField chkIncomeTaxDiscount { get {return Body().chkIncomeTaxDiscount;} }
            public TTReportField chkResidenceTaxExemption { get {return Body().chkResidenceTaxExemption;} }
            public TTReportField chkElectricAndWaterDiscount { get {return Body().chkElectricAndWaterDiscount;} }
            public TTReportField chkImportingDutyFreeVehicle { get {return Body().chkImportingDutyFreeVehicle;} }
            public TTReportField chkDomesticVehiclePurchases { get {return Body().chkDomesticVehiclePurchases;} }
            public TTReportField chkOTVandMTVExemption { get {return Body().chkOTVandMTVExemption;} }
            public TTReportField chkBrotherExemptionFromMilitary { get {return Body().chkBrotherExemptionFromMilitary;} }
            public TTReportField chkMilitaryServiceNearBrotherHom { get {return Body().chkMilitaryServiceNearBrotherHom;} }
            public TTReportField chkFreeAccessToPrivateEduInstit { get {return Body().chkFreeAccessToPrivateEduInstit;} }
            public TTReportField chkWeaponPortageTransportLicense { get {return Body().chkWeaponPortageTransportLicense;} }
            public TTReportField chkUtilityFromRehabilitationCent { get {return Body().chkUtilityFromRehabilitationCent;} }
            public TTReportField chkGrantingDealership { get {return Body().chkGrantingDealership;} }
            public group13Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group13Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group13GroupBody(this);
            }

            public partial class group13GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField131261111;
                public TTReportField NewField131162111;
                public TTReportField NewField1416411;
                public TTReportField NewField14116211;
                public TTReportField NewField14126111;
                public TTReportField NewField141261111;
                public TTReportField NewField141162111;
                public TTReportField NewField1516411;
                public TTReportField NewField15116211;
                public TTReportField NewField15126111;
                public TTReportField NewField151261111;
                public TTReportField NewField151162111;
                public TTReportField NewField111162151;
                public TTReportField NewField1111162151;
                public TTReportField NewField1111261151;
                public TTReportField PROVIDEHOUSETODISABLSTAFFINFO1;
                public TTReportField ELECTRICANDWATERDISCOUNTINFO1;
                public TTReportField GIVINGCORPORATEHOUSCREDITINFO1;
                public TTReportField INCOMETAXDISCOUNTINFO1;
                public TTReportField RESIDENCETAXEXEMPTIONINFO1;
                public TTReportField USAGERIGHTFROMTOKIHOUSESINFO1;
                public TTReportField BROTHEREXEMPTIONFROMMILITINFO1;
                public TTReportField DOMESTICVEHICLEPURCHASESINFO1;
                public TTReportField IMPORTINGDUTYFREEVEHICLEINFO1;
                public TTReportField MILITARSERVNEARBROTHERHOMINFO1;
                public TTReportField OTVANDMTVEXEMPTIONINFO1;
                public TTReportField FREEACCESSTOPRIVEDUINSTITINFO1;
                public TTReportField GRANTINGDEALERSHIPINFO1;
                public TTReportField UTILITYFROMREHABILITCENTINFO1;
                public TTReportField WEAPONPORTAGETRANSPORTLICINFO1;
                public TTReportField chkProvideHouseToDisabledStaff;
                public TTReportField chkGivingCorporateHousingCredit;
                public TTReportField chkUsageRightFromTOKIHouses;
                public TTReportField chkIncomeTaxDiscount;
                public TTReportField chkResidenceTaxExemption;
                public TTReportField chkElectricAndWaterDiscount;
                public TTReportField chkImportingDutyFreeVehicle;
                public TTReportField chkDomesticVehiclePurchases;
                public TTReportField chkOTVandMTVExemption;
                public TTReportField chkBrotherExemptionFromMilitary;
                public TTReportField chkMilitaryServiceNearBrotherHom;
                public TTReportField chkFreeAccessToPrivateEduInstit;
                public TTReportField chkWeaponPortageTransportLicense;
                public TTReportField chkUtilityFromRehabilitationCent;
                public TTReportField chkGrantingDealership; 
                public group13GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 226;
                    RepeatCount = 0;
                    
                    NewField131261111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 7, 112, 12, false);
                    NewField131261111.Name = "NewField131261111";
                    NewField131261111.TextFont.Name = "Arial";
                    NewField131261111.TextFont.Italic = true;
                    NewField131261111.TextFont.CharSet = 162;
                    NewField131261111.Value = @"l. Göreve devam eden malul personele konut tahsis edilmesi";

                    NewField131162111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 21, 88, 26, false);
                    NewField131162111.Name = "NewField131162111";
                    NewField131162111.TextFont.Name = "Arial";
                    NewField131162111.TextFont.Italic = true;
                    NewField131162111.TextFont.CharSet = 162;
                    NewField131162111.Value = @"m. Toplu konut kredisi verilmesi";

                    NewField1416411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 35, 88, 40, false);
                    NewField1416411.Name = "NewField1416411";
                    NewField1416411.TextFont.Name = "Arial";
                    NewField1416411.TextFont.Italic = true;
                    NewField1416411.TextFont.CharSet = 162;
                    NewField1416411.Value = @"n. TOKİ konutlarından faydalanma hakkı";

                    NewField14116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 49, 97, 54, false);
                    NewField14116211.Name = "NewField14116211";
                    NewField14116211.TextFont.Name = "Arial";
                    NewField14116211.TextFont.Italic = true;
                    NewField14116211.TextFont.CharSet = 162;
                    NewField14116211.Value = @"o. Gelir Vergisi indirimi";

                    NewField14126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 63, 109, 68, false);
                    NewField14126111.Name = "NewField14126111";
                    NewField14126111.TextFont.Name = "Arial";
                    NewField14126111.TextFont.Italic = true;
                    NewField14126111.TextFont.CharSet = 162;
                    NewField14126111.Value = @"ö. Mesken vergisi muafiyeti";

                    NewField141261111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 77, 88, 82, false);
                    NewField141261111.Name = "NewField141261111";
                    NewField141261111.TextFont.Name = "Arial";
                    NewField141261111.TextFont.Italic = true;
                    NewField141261111.TextFont.CharSet = 162;
                    NewField141261111.Value = @"p. Elektrik ve su indirimi";

                    NewField141162111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 91, 88, 96, false);
                    NewField141162111.Name = "NewField141162111";
                    NewField141162111.TextFont.Name = "Arial";
                    NewField141162111.TextFont.Italic = true;
                    NewField141162111.TextFont.CharSet = 162;
                    NewField141162111.Value = @"r. Gümrüksüz araç ithal edilmesi";

                    NewField1516411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 105, 88, 110, false);
                    NewField1516411.Name = "NewField1516411";
                    NewField1516411.TextFont.Name = "Arial";
                    NewField1516411.TextFont.Italic = true;
                    NewField1516411.TextFont.CharSet = 162;
                    NewField1516411.Value = @"s. Yurt içi araç alımları";

                    NewField15116211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 119, 97, 124, false);
                    NewField15116211.Name = "NewField15116211";
                    NewField15116211.TextFont.Name = "Arial";
                    NewField15116211.TextFont.Italic = true;
                    NewField15116211.TextFont.CharSet = 162;
                    NewField15116211.Value = @"ş. ÖTV ve MTV muafiyeti";

                    NewField15126111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 133, 120, 138, false);
                    NewField15126111.Name = "NewField15126111";
                    NewField15126111.TextFont.Name = "Arial";
                    NewField15126111.TextFont.Italic = true;
                    NewField15126111.TextFont.CharSet = 162;
                    NewField15126111.Value = @"t. Malulün kendisinden sonraki kardeşinin XXXXXXlikten muaf tutulması";

                    NewField151261111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 147, 161, 152, false);
                    NewField151261111.Name = "NewField151261111";
                    NewField151261111.TextFont.Name = "Arial";
                    NewField151261111.TextFont.Italic = true;
                    NewField151261111.TextFont.CharSet = 162;
                    NewField151261111.Value = @"u. Malul kardeşlerinin ikametgahlarına yakın bir yerde XXXXXXlik hizmetini yapması";

                    NewField151162111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 161, 119, 166, false);
                    NewField151162111.Name = "NewField151162111";
                    NewField151162111.TextFont.Name = "Arial";
                    NewField151162111.TextFont.Italic = true;
                    NewField151162111.TextFont.CharSet = 162;
                    NewField151162111.Value = @"ü. Özel öğretim kurumlarından ücretsiz yararlanma";

                    NewField111162151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 175, 120, 180, false);
                    NewField111162151.Name = "NewField111162151";
                    NewField111162151.TextFont.Name = "Arial";
                    NewField111162151.TextFont.Italic = true;
                    NewField111162151.TextFont.CharSet = 162;
                    NewField111162151.Value = @"v. Silah bulundurma taşıma ruhsatı";

                    NewField1111162151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 189, 135, 194, false);
                    NewField1111162151.Name = "NewField1111162151";
                    NewField1111162151.TextFont.Name = "Arial";
                    NewField1111162151.TextFont.Italic = true;
                    NewField1111162151.TextFont.CharSet = 162;
                    NewField1111162151.Value = @"y. XXXXXX Ali Çetinkaya İlk Kurşun Rehabilitasyon Merkezi'nden yararlanma";

                    NewField1111261151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 10, 203, 131, 208, false);
                    NewField1111261151.Name = "NewField1111261151";
                    NewField1111261151.TextFont.Name = "Arial";
                    NewField1111261151.TextFont.Italic = true;
                    NewField1111261151.TextFont.CharSet = 162;
                    NewField1111261151.Value = @"z. Milli Piyango İdaresi Genel Müdürlüğü'nce bayilik verilmesi";

                    PROVIDEHOUSETODISABLSTAFFINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 12, 206, 21, false);
                    PROVIDEHOUSETODISABLSTAFFINFO1.Name = "PROVIDEHOUSETODISABLSTAFFINFO1";
                    PROVIDEHOUSETODISABLSTAFFINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PROVIDEHOUSETODISABLSTAFFINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    PROVIDEHOUSETODISABLSTAFFINFO1.NoClip = EvetHayirEnum.ehEvet;
                    PROVIDEHOUSETODISABLSTAFFINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    PROVIDEHOUSETODISABLSTAFFINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    PROVIDEHOUSETODISABLSTAFFINFO1.TextFont.Size = 8;
                    PROVIDEHOUSETODISABLSTAFFINFO1.TextFont.CharSet = 162;
                    PROVIDEHOUSETODISABLSTAFFINFO1.Value = @"{#Header.PROVIDEHOUSETODISABLSTAFFINFO#}";

                    ELECTRICANDWATERDISCOUNTINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 82, 206, 91, false);
                    ELECTRICANDWATERDISCOUNTINFO1.Name = "ELECTRICANDWATERDISCOUNTINFO1";
                    ELECTRICANDWATERDISCOUNTINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ELECTRICANDWATERDISCOUNTINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    ELECTRICANDWATERDISCOUNTINFO1.NoClip = EvetHayirEnum.ehEvet;
                    ELECTRICANDWATERDISCOUNTINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    ELECTRICANDWATERDISCOUNTINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    ELECTRICANDWATERDISCOUNTINFO1.TextFont.Size = 8;
                    ELECTRICANDWATERDISCOUNTINFO1.TextFont.CharSet = 162;
                    ELECTRICANDWATERDISCOUNTINFO1.Value = @"{#Header.ELECTRICANDWATERDISCOUNTINFO#}";

                    GIVINGCORPORATEHOUSCREDITINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 26, 206, 35, false);
                    GIVINGCORPORATEHOUSCREDITINFO1.Name = "GIVINGCORPORATEHOUSCREDITINFO1";
                    GIVINGCORPORATEHOUSCREDITINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GIVINGCORPORATEHOUSCREDITINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GIVINGCORPORATEHOUSCREDITINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GIVINGCORPORATEHOUSCREDITINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GIVINGCORPORATEHOUSCREDITINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GIVINGCORPORATEHOUSCREDITINFO1.TextFont.Size = 8;
                    GIVINGCORPORATEHOUSCREDITINFO1.TextFont.CharSet = 162;
                    GIVINGCORPORATEHOUSCREDITINFO1.Value = @"{#Header.GIVINGCORPORATEHOUSCREDITINFO#}";

                    INCOMETAXDISCOUNTINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 54, 206, 63, false);
                    INCOMETAXDISCOUNTINFO1.Name = "INCOMETAXDISCOUNTINFO1";
                    INCOMETAXDISCOUNTINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    INCOMETAXDISCOUNTINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    INCOMETAXDISCOUNTINFO1.NoClip = EvetHayirEnum.ehEvet;
                    INCOMETAXDISCOUNTINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    INCOMETAXDISCOUNTINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    INCOMETAXDISCOUNTINFO1.TextFont.Size = 8;
                    INCOMETAXDISCOUNTINFO1.TextFont.CharSet = 162;
                    INCOMETAXDISCOUNTINFO1.Value = @"{#Header.INCOMETAXDISCOUNTINFO#}";

                    RESIDENCETAXEXEMPTIONINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 68, 206, 77, false);
                    RESIDENCETAXEXEMPTIONINFO1.Name = "RESIDENCETAXEXEMPTIONINFO1";
                    RESIDENCETAXEXEMPTIONINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESIDENCETAXEXEMPTIONINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    RESIDENCETAXEXEMPTIONINFO1.NoClip = EvetHayirEnum.ehEvet;
                    RESIDENCETAXEXEMPTIONINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    RESIDENCETAXEXEMPTIONINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    RESIDENCETAXEXEMPTIONINFO1.TextFont.Size = 8;
                    RESIDENCETAXEXEMPTIONINFO1.TextFont.CharSet = 162;
                    RESIDENCETAXEXEMPTIONINFO1.Value = @"{#Header.RESIDENCETAXEXEMPTIONINFO#}";

                    USAGERIGHTFROMTOKIHOUSESINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 40, 206, 49, false);
                    USAGERIGHTFROMTOKIHOUSESINFO1.Name = "USAGERIGHTFROMTOKIHOUSESINFO1";
                    USAGERIGHTFROMTOKIHOUSESINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    USAGERIGHTFROMTOKIHOUSESINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    USAGERIGHTFROMTOKIHOUSESINFO1.NoClip = EvetHayirEnum.ehEvet;
                    USAGERIGHTFROMTOKIHOUSESINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    USAGERIGHTFROMTOKIHOUSESINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    USAGERIGHTFROMTOKIHOUSESINFO1.TextFont.Size = 8;
                    USAGERIGHTFROMTOKIHOUSESINFO1.TextFont.CharSet = 162;
                    USAGERIGHTFROMTOKIHOUSESINFO1.Value = @"{#Header.USAGERIGHTFROMTOKIHOUSESINFO#}";

                    BROTHEREXEMPTIONFROMMILITINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 138, 206, 147, false);
                    BROTHEREXEMPTIONFROMMILITINFO1.Name = "BROTHEREXEMPTIONFROMMILITINFO1";
                    BROTHEREXEMPTIONFROMMILITINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    BROTHEREXEMPTIONFROMMILITINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    BROTHEREXEMPTIONFROMMILITINFO1.NoClip = EvetHayirEnum.ehEvet;
                    BROTHEREXEMPTIONFROMMILITINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    BROTHEREXEMPTIONFROMMILITINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    BROTHEREXEMPTIONFROMMILITINFO1.TextFont.Size = 8;
                    BROTHEREXEMPTIONFROMMILITINFO1.TextFont.CharSet = 162;
                    BROTHEREXEMPTIONFROMMILITINFO1.Value = @"{#Header.BROTHEREXEMPTIONFROMMILITINFO#}";

                    DOMESTICVEHICLEPURCHASESINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 110, 206, 119, false);
                    DOMESTICVEHICLEPURCHASESINFO1.Name = "DOMESTICVEHICLEPURCHASESINFO1";
                    DOMESTICVEHICLEPURCHASESINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    DOMESTICVEHICLEPURCHASESINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    DOMESTICVEHICLEPURCHASESINFO1.NoClip = EvetHayirEnum.ehEvet;
                    DOMESTICVEHICLEPURCHASESINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    DOMESTICVEHICLEPURCHASESINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    DOMESTICVEHICLEPURCHASESINFO1.TextFont.Size = 8;
                    DOMESTICVEHICLEPURCHASESINFO1.TextFont.CharSet = 162;
                    DOMESTICVEHICLEPURCHASESINFO1.Value = @"{#Header.DOMESTICVEHICLEPURCHASESINFO#}";

                    IMPORTINGDUTYFREEVEHICLEINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 96, 206, 105, false);
                    IMPORTINGDUTYFREEVEHICLEINFO1.Name = "IMPORTINGDUTYFREEVEHICLEINFO1";
                    IMPORTINGDUTYFREEVEHICLEINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    IMPORTINGDUTYFREEVEHICLEINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    IMPORTINGDUTYFREEVEHICLEINFO1.NoClip = EvetHayirEnum.ehEvet;
                    IMPORTINGDUTYFREEVEHICLEINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    IMPORTINGDUTYFREEVEHICLEINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    IMPORTINGDUTYFREEVEHICLEINFO1.TextFont.Size = 8;
                    IMPORTINGDUTYFREEVEHICLEINFO1.TextFont.CharSet = 162;
                    IMPORTINGDUTYFREEVEHICLEINFO1.Value = @"{#Header.IMPORTINGDUTYFREEVEHICLEINFO#}";

                    MILITARSERVNEARBROTHERHOMINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 152, 206, 161, false);
                    MILITARSERVNEARBROTHERHOMINFO1.Name = "MILITARSERVNEARBROTHERHOMINFO1";
                    MILITARSERVNEARBROTHERHOMINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    MILITARSERVNEARBROTHERHOMINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    MILITARSERVNEARBROTHERHOMINFO1.NoClip = EvetHayirEnum.ehEvet;
                    MILITARSERVNEARBROTHERHOMINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    MILITARSERVNEARBROTHERHOMINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    MILITARSERVNEARBROTHERHOMINFO1.TextFont.Size = 8;
                    MILITARSERVNEARBROTHERHOMINFO1.TextFont.CharSet = 162;
                    MILITARSERVNEARBROTHERHOMINFO1.Value = @"{#Header.MILITARSERVNEARBROTHERHOMINFO#}";

                    OTVANDMTVEXEMPTIONINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 124, 206, 133, false);
                    OTVANDMTVEXEMPTIONINFO1.Name = "OTVANDMTVEXEMPTIONINFO1";
                    OTVANDMTVEXEMPTIONINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OTVANDMTVEXEMPTIONINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    OTVANDMTVEXEMPTIONINFO1.NoClip = EvetHayirEnum.ehEvet;
                    OTVANDMTVEXEMPTIONINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    OTVANDMTVEXEMPTIONINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    OTVANDMTVEXEMPTIONINFO1.TextFont.Size = 8;
                    OTVANDMTVEXEMPTIONINFO1.TextFont.CharSet = 162;
                    OTVANDMTVEXEMPTIONINFO1.Value = @"{#Header.OTVANDMTVEXEMPTIONINFO#}";

                    FREEACCESSTOPRIVEDUINSTITINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 166, 206, 175, false);
                    FREEACCESSTOPRIVEDUINSTITINFO1.Name = "FREEACCESSTOPRIVEDUINSTITINFO1";
                    FREEACCESSTOPRIVEDUINSTITINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    FREEACCESSTOPRIVEDUINSTITINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    FREEACCESSTOPRIVEDUINSTITINFO1.NoClip = EvetHayirEnum.ehEvet;
                    FREEACCESSTOPRIVEDUINSTITINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    FREEACCESSTOPRIVEDUINSTITINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    FREEACCESSTOPRIVEDUINSTITINFO1.TextFont.Size = 8;
                    FREEACCESSTOPRIVEDUINSTITINFO1.TextFont.CharSet = 162;
                    FREEACCESSTOPRIVEDUINSTITINFO1.Value = @"{#Header.FREEACCESSTOPRIVEDUINSTITINFO#}";

                    GRANTINGDEALERSHIPINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 208, 206, 217, false);
                    GRANTINGDEALERSHIPINFO1.Name = "GRANTINGDEALERSHIPINFO1";
                    GRANTINGDEALERSHIPINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANTINGDEALERSHIPINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    GRANTINGDEALERSHIPINFO1.NoClip = EvetHayirEnum.ehEvet;
                    GRANTINGDEALERSHIPINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    GRANTINGDEALERSHIPINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    GRANTINGDEALERSHIPINFO1.TextFont.Size = 8;
                    GRANTINGDEALERSHIPINFO1.TextFont.CharSet = 162;
                    GRANTINGDEALERSHIPINFO1.Value = @"{#Header.GRANTINGDEALERSHIPINFO#}";

                    UTILITYFROMREHABILITCENTINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 194, 206, 203, false);
                    UTILITYFROMREHABILITCENTINFO1.Name = "UTILITYFROMREHABILITCENTINFO1";
                    UTILITYFROMREHABILITCENTINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    UTILITYFROMREHABILITCENTINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    UTILITYFROMREHABILITCENTINFO1.NoClip = EvetHayirEnum.ehEvet;
                    UTILITYFROMREHABILITCENTINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    UTILITYFROMREHABILITCENTINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    UTILITYFROMREHABILITCENTINFO1.TextFont.Size = 8;
                    UTILITYFROMREHABILITCENTINFO1.TextFont.CharSet = 162;
                    UTILITYFROMREHABILITCENTINFO1.Value = @"{#Header.UTILITYFROMREHABILITCENTINFO#}";

                    WEAPONPORTAGETRANSPORTLICINFO1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 180, 206, 189, false);
                    WEAPONPORTAGETRANSPORTLICINFO1.Name = "WEAPONPORTAGETRANSPORTLICINFO1";
                    WEAPONPORTAGETRANSPORTLICINFO1.FieldType = ReportFieldTypeEnum.ftVariable;
                    WEAPONPORTAGETRANSPORTLICINFO1.MultiLine = EvetHayirEnum.ehEvet;
                    WEAPONPORTAGETRANSPORTLICINFO1.NoClip = EvetHayirEnum.ehEvet;
                    WEAPONPORTAGETRANSPORTLICINFO1.WordBreak = EvetHayirEnum.ehEvet;
                    WEAPONPORTAGETRANSPORTLICINFO1.ExpandTabs = EvetHayirEnum.ehEvet;
                    WEAPONPORTAGETRANSPORTLICINFO1.TextFont.Size = 8;
                    WEAPONPORTAGETRANSPORTLICINFO1.TextFont.CharSet = 162;
                    WEAPONPORTAGETRANSPORTLICINFO1.Value = @"{#Header.WEAPONPORTAGETRANSPORTLICINFO#}";

                    chkProvideHouseToDisabledStaff = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 7, 9, 11, false);
                    chkProvideHouseToDisabledStaff.Name = "chkProvideHouseToDisabledStaff";
                    chkProvideHouseToDisabledStaff.DrawStyle = DrawStyleConstants.vbSolid;
                    chkProvideHouseToDisabledStaff.TextFont.Name = "Arial";
                    chkProvideHouseToDisabledStaff.TextFont.Bold = true;
                    chkProvideHouseToDisabledStaff.TextFont.CharSet = 162;
                    chkProvideHouseToDisabledStaff.Value = @"X";

                    chkGivingCorporateHousingCredit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 21, 9, 25, false);
                    chkGivingCorporateHousingCredit.Name = "chkGivingCorporateHousingCredit";
                    chkGivingCorporateHousingCredit.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGivingCorporateHousingCredit.TextFont.Name = "Arial";
                    chkGivingCorporateHousingCredit.TextFont.Bold = true;
                    chkGivingCorporateHousingCredit.TextFont.CharSet = 162;
                    chkGivingCorporateHousingCredit.Value = @"X";

                    chkUsageRightFromTOKIHouses = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 35, 9, 39, false);
                    chkUsageRightFromTOKIHouses.Name = "chkUsageRightFromTOKIHouses";
                    chkUsageRightFromTOKIHouses.DrawStyle = DrawStyleConstants.vbSolid;
                    chkUsageRightFromTOKIHouses.TextFont.Name = "Arial";
                    chkUsageRightFromTOKIHouses.TextFont.Bold = true;
                    chkUsageRightFromTOKIHouses.TextFont.CharSet = 162;
                    chkUsageRightFromTOKIHouses.Value = @"X";

                    chkIncomeTaxDiscount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 49, 9, 53, false);
                    chkIncomeTaxDiscount.Name = "chkIncomeTaxDiscount";
                    chkIncomeTaxDiscount.DrawStyle = DrawStyleConstants.vbSolid;
                    chkIncomeTaxDiscount.TextFont.Name = "Arial";
                    chkIncomeTaxDiscount.TextFont.Bold = true;
                    chkIncomeTaxDiscount.TextFont.CharSet = 162;
                    chkIncomeTaxDiscount.Value = @"X";

                    chkResidenceTaxExemption = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 63, 9, 67, false);
                    chkResidenceTaxExemption.Name = "chkResidenceTaxExemption";
                    chkResidenceTaxExemption.DrawStyle = DrawStyleConstants.vbSolid;
                    chkResidenceTaxExemption.TextFont.Name = "Arial";
                    chkResidenceTaxExemption.TextFont.Bold = true;
                    chkResidenceTaxExemption.TextFont.CharSet = 162;
                    chkResidenceTaxExemption.Value = @"X";

                    chkElectricAndWaterDiscount = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 77, 9, 81, false);
                    chkElectricAndWaterDiscount.Name = "chkElectricAndWaterDiscount";
                    chkElectricAndWaterDiscount.DrawStyle = DrawStyleConstants.vbSolid;
                    chkElectricAndWaterDiscount.TextFont.Name = "Arial";
                    chkElectricAndWaterDiscount.TextFont.Bold = true;
                    chkElectricAndWaterDiscount.TextFont.CharSet = 162;
                    chkElectricAndWaterDiscount.Value = @"X";

                    chkImportingDutyFreeVehicle = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 91, 9, 95, false);
                    chkImportingDutyFreeVehicle.Name = "chkImportingDutyFreeVehicle";
                    chkImportingDutyFreeVehicle.DrawStyle = DrawStyleConstants.vbSolid;
                    chkImportingDutyFreeVehicle.TextFont.Name = "Arial";
                    chkImportingDutyFreeVehicle.TextFont.Bold = true;
                    chkImportingDutyFreeVehicle.TextFont.CharSet = 162;
                    chkImportingDutyFreeVehicle.Value = @"X";

                    chkDomesticVehiclePurchases = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 105, 9, 109, false);
                    chkDomesticVehiclePurchases.Name = "chkDomesticVehiclePurchases";
                    chkDomesticVehiclePurchases.DrawStyle = DrawStyleConstants.vbSolid;
                    chkDomesticVehiclePurchases.TextFont.Name = "Arial";
                    chkDomesticVehiclePurchases.TextFont.Bold = true;
                    chkDomesticVehiclePurchases.TextFont.CharSet = 162;
                    chkDomesticVehiclePurchases.Value = @"X";

                    chkOTVandMTVExemption = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 119, 9, 123, false);
                    chkOTVandMTVExemption.Name = "chkOTVandMTVExemption";
                    chkOTVandMTVExemption.DrawStyle = DrawStyleConstants.vbSolid;
                    chkOTVandMTVExemption.TextFont.Name = "Arial";
                    chkOTVandMTVExemption.TextFont.Bold = true;
                    chkOTVandMTVExemption.TextFont.CharSet = 162;
                    chkOTVandMTVExemption.Value = @"X";

                    chkBrotherExemptionFromMilitary = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 133, 9, 137, false);
                    chkBrotherExemptionFromMilitary.Name = "chkBrotherExemptionFromMilitary";
                    chkBrotherExemptionFromMilitary.DrawStyle = DrawStyleConstants.vbSolid;
                    chkBrotherExemptionFromMilitary.TextFont.Name = "Arial";
                    chkBrotherExemptionFromMilitary.TextFont.Bold = true;
                    chkBrotherExemptionFromMilitary.TextFont.CharSet = 162;
                    chkBrotherExemptionFromMilitary.Value = @"X";

                    chkMilitaryServiceNearBrotherHom = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 147, 9, 151, false);
                    chkMilitaryServiceNearBrotherHom.Name = "chkMilitaryServiceNearBrotherHom";
                    chkMilitaryServiceNearBrotherHom.DrawStyle = DrawStyleConstants.vbSolid;
                    chkMilitaryServiceNearBrotherHom.TextFont.Name = "Arial";
                    chkMilitaryServiceNearBrotherHom.TextFont.Bold = true;
                    chkMilitaryServiceNearBrotherHom.TextFont.CharSet = 162;
                    chkMilitaryServiceNearBrotherHom.Value = @"X";

                    chkFreeAccessToPrivateEduInstit = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 161, 9, 165, false);
                    chkFreeAccessToPrivateEduInstit.Name = "chkFreeAccessToPrivateEduInstit";
                    chkFreeAccessToPrivateEduInstit.DrawStyle = DrawStyleConstants.vbSolid;
                    chkFreeAccessToPrivateEduInstit.TextFont.Name = "Arial";
                    chkFreeAccessToPrivateEduInstit.TextFont.Bold = true;
                    chkFreeAccessToPrivateEduInstit.TextFont.CharSet = 162;
                    chkFreeAccessToPrivateEduInstit.Value = @"X";

                    chkWeaponPortageTransportLicense = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 175, 9, 179, false);
                    chkWeaponPortageTransportLicense.Name = "chkWeaponPortageTransportLicense";
                    chkWeaponPortageTransportLicense.DrawStyle = DrawStyleConstants.vbSolid;
                    chkWeaponPortageTransportLicense.TextFont.Name = "Arial";
                    chkWeaponPortageTransportLicense.TextFont.Bold = true;
                    chkWeaponPortageTransportLicense.TextFont.CharSet = 162;
                    chkWeaponPortageTransportLicense.Value = @"X";

                    chkUtilityFromRehabilitationCent = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 189, 9, 193, false);
                    chkUtilityFromRehabilitationCent.Name = "chkUtilityFromRehabilitationCent";
                    chkUtilityFromRehabilitationCent.DrawStyle = DrawStyleConstants.vbSolid;
                    chkUtilityFromRehabilitationCent.TextFont.Name = "Arial";
                    chkUtilityFromRehabilitationCent.TextFont.Bold = true;
                    chkUtilityFromRehabilitationCent.TextFont.CharSet = 162;
                    chkUtilityFromRehabilitationCent.Value = @"X";

                    chkGrantingDealership = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 6, 203, 9, 207, false);
                    chkGrantingDealership.Name = "chkGrantingDealership";
                    chkGrantingDealership.DrawStyle = DrawStyleConstants.vbSolid;
                    chkGrantingDealership.TextFont.Name = "Arial";
                    chkGrantingDealership.TextFont.Bold = true;
                    chkGrantingDealership.TextFont.CharSet = 162;
                    chkGrantingDealership.Value = @"X";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField131261111.CalcValue = NewField131261111.Value;
                    NewField131162111.CalcValue = NewField131162111.Value;
                    NewField1416411.CalcValue = NewField1416411.Value;
                    NewField14116211.CalcValue = NewField14116211.Value;
                    NewField14126111.CalcValue = NewField14126111.Value;
                    NewField141261111.CalcValue = NewField141261111.Value;
                    NewField141162111.CalcValue = NewField141162111.Value;
                    NewField1516411.CalcValue = NewField1516411.Value;
                    NewField15116211.CalcValue = NewField15116211.Value;
                    NewField15126111.CalcValue = NewField15126111.Value;
                    NewField151261111.CalcValue = NewField151261111.Value;
                    NewField151162111.CalcValue = NewField151162111.Value;
                    NewField111162151.CalcValue = NewField111162151.Value;
                    NewField1111162151.CalcValue = NewField1111162151.Value;
                    NewField1111261151.CalcValue = NewField1111261151.Value;
                    PROVIDEHOUSETODISABLSTAFFINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ProvideHouseToDisablStaffInfo) : "");
                    ELECTRICANDWATERDISCOUNTINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ElectricAndWaterDiscountInfo) : "");
                    GIVINGCORPORATEHOUSCREDITINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GivingCorporateHousCreditInfo) : "");
                    INCOMETAXDISCOUNTINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.IncomeTaxDiscountInfo) : "");
                    RESIDENCETAXEXEMPTIONINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ResidenceTaxExemptionInfo) : "");
                    USAGERIGHTFROMTOKIHOUSESINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.UsageRightFromTOKIHousesInfo) : "");
                    BROTHEREXEMPTIONFROMMILITINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.BrotherExemptionFromMilitInfo) : "");
                    DOMESTICVEHICLEPURCHASESINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.DomesticVehiclePurchasesInfo) : "");
                    IMPORTINGDUTYFREEVEHICLEINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.ImportingDutyFreeVehicleInfo) : "");
                    MILITARSERVNEARBROTHERHOMINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.MilitarServNearBrotherHomInfo) : "");
                    OTVANDMTVEXEMPTIONINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.OTVandMTVExemptionInfo) : "");
                    FREEACCESSTOPRIVEDUINSTITINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.FreeAccessToPrivEduInstitInfo) : "");
                    GRANTINGDEALERSHIPINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.GrantingDealershipInfo) : "");
                    UTILITYFROMREHABILITCENTINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.UtilityFromRehabilitCentInfo) : "");
                    WEAPONPORTAGETRANSPORTLICINFO1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.WeaponPortageTransportLicInfo) : "");
                    chkProvideHouseToDisabledStaff.CalcValue = chkProvideHouseToDisabledStaff.Value;
                    chkGivingCorporateHousingCredit.CalcValue = chkGivingCorporateHousingCredit.Value;
                    chkUsageRightFromTOKIHouses.CalcValue = chkUsageRightFromTOKIHouses.Value;
                    chkIncomeTaxDiscount.CalcValue = chkIncomeTaxDiscount.Value;
                    chkResidenceTaxExemption.CalcValue = chkResidenceTaxExemption.Value;
                    chkElectricAndWaterDiscount.CalcValue = chkElectricAndWaterDiscount.Value;
                    chkImportingDutyFreeVehicle.CalcValue = chkImportingDutyFreeVehicle.Value;
                    chkDomesticVehiclePurchases.CalcValue = chkDomesticVehiclePurchases.Value;
                    chkOTVandMTVExemption.CalcValue = chkOTVandMTVExemption.Value;
                    chkBrotherExemptionFromMilitary.CalcValue = chkBrotherExemptionFromMilitary.Value;
                    chkMilitaryServiceNearBrotherHom.CalcValue = chkMilitaryServiceNearBrotherHom.Value;
                    chkFreeAccessToPrivateEduInstit.CalcValue = chkFreeAccessToPrivateEduInstit.Value;
                    chkWeaponPortageTransportLicense.CalcValue = chkWeaponPortageTransportLicense.Value;
                    chkUtilityFromRehabilitationCent.CalcValue = chkUtilityFromRehabilitationCent.Value;
                    chkGrantingDealership.CalcValue = chkGrantingDealership.Value;
                    return new TTReportObject[] { NewField131261111,NewField131162111,NewField1416411,NewField14116211,NewField14126111,NewField141261111,NewField141162111,NewField1516411,NewField15116211,NewField15126111,NewField151261111,NewField151162111,NewField111162151,NewField1111162151,NewField1111261151,PROVIDEHOUSETODISABLSTAFFINFO1,ELECTRICANDWATERDISCOUNTINFO1,GIVINGCORPORATEHOUSCREDITINFO1,INCOMETAXDISCOUNTINFO1,RESIDENCETAXEXEMPTIONINFO1,USAGERIGHTFROMTOKIHOUSESINFO1,BROTHEREXEMPTIONFROMMILITINFO1,DOMESTICVEHICLEPURCHASESINFO1,IMPORTINGDUTYFREEVEHICLEINFO1,MILITARSERVNEARBROTHERHOMINFO1,OTVANDMTVEXEMPTIONINFO1,FREEACCESSTOPRIVEDUINSTITINFO1,GRANTINGDEALERSHIPINFO1,UTILITYFROMREHABILITCENTINFO1,WEAPONPORTAGETRANSPORTLICINFO1,chkProvideHouseToDisabledStaff,chkGivingCorporateHousingCredit,chkUsageRightFromTOKIHouses,chkIncomeTaxDiscount,chkResidenceTaxExemption,chkElectricAndWaterDiscount,chkImportingDutyFreeVehicle,chkDomesticVehiclePurchases,chkOTVandMTVExemption,chkBrotherExemptionFromMilitary,chkMilitaryServiceNearBrotherHom,chkFreeAccessToPrivateEduInstit,chkWeaponPortageTransportLicense,chkUtilityFromRehabilitationCent,chkGrantingDealership};
                }
            }

        }

        public group13Group group13;

        public partial class group14Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group14GroupBody Body()
            {
                return (group14GroupBody)_body;
            }
            public TTReportField NewField111511 { get {return Body().NewField111511;} }
            public TTReportField OPENEDUCATIONHIGHSCHOOL11 { get {return Body().OPENEDUCATIONHIGHSCHOOL11;} }
            public group14Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group14Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group14GroupBody(this);
            }

            public partial class group14GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField111511;
                public TTReportField OPENEDUCATIONHIGHSCHOOL11; 
                public group14GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 26;
                    RepeatCount = 0;
                    
                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 7, 134, 13, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.TextFont.Size = 11;
                    NewField111511.TextFont.Bold = true;
                    NewField111511.TextFont.CharSet = 162;
                    NewField111511.Value = @"13. Açık Lise";

                    OPENEDUCATIONHIGHSCHOOL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 13, 206, 22, false);
                    OPENEDUCATIONHIGHSCHOOL11.Name = "OPENEDUCATIONHIGHSCHOOL11";
                    OPENEDUCATIONHIGHSCHOOL11.FieldType = ReportFieldTypeEnum.ftVariable;
                    OPENEDUCATIONHIGHSCHOOL11.MultiLine = EvetHayirEnum.ehEvet;
                    OPENEDUCATIONHIGHSCHOOL11.NoClip = EvetHayirEnum.ehEvet;
                    OPENEDUCATIONHIGHSCHOOL11.WordBreak = EvetHayirEnum.ehEvet;
                    OPENEDUCATIONHIGHSCHOOL11.ExpandTabs = EvetHayirEnum.ehEvet;
                    OPENEDUCATIONHIGHSCHOOL11.TextFont.Size = 8;
                    OPENEDUCATIONHIGHSCHOOL11.TextFont.CharSet = 162;
                    OPENEDUCATIONHIGHSCHOOL11.Value = @"{#Header.OPENEDUCATIONHIGHSCHOOL#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField111511.CalcValue = NewField111511.Value;
                    OPENEDUCATIONHIGHSCHOOL11.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.OpenEducationHighSchool) : "");
                    return new TTReportObject[] { NewField111511,OPENEDUCATIONHIGHSCHOOL11};
                }
            }

        }

        public group14Group group14;

        public partial class group121Group : TTReportGroup
        {
            public SocialServicesAppliedProceduresReport MyParentReport
            {
                get { return (SocialServicesAppliedProceduresReport)ParentReport; }
            }

            new public group121GroupBody Body()
            {
                return (group121GroupBody)_body;
            }
            public TTReportField NewField11511 { get {return Body().NewField11511;} }
            public TTReportField OTHER1 { get {return Body().OTHER1;} }
            public group121Group(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public group121Group(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new group121GroupBody(this);
            }

            public partial class group121GroupBody : TTReportSection
            {
                public SocialServicesAppliedProceduresReport MyParentReport
                {
                    get { return (SocialServicesAppliedProceduresReport)ParentReport; }
                }
                
                public TTReportField NewField11511;
                public TTReportField OTHER1; 
                public group121GroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    RepeatCount = 0;
                    
                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 9, 5, 134, 11, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.TextFont.Size = 11;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"14. Diğer";

                    OTHER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 11, 11, 206, 20, false);
                    OTHER1.Name = "OTHER1";
                    OTHER1.FieldType = ReportFieldTypeEnum.ftVariable;
                    OTHER1.MultiLine = EvetHayirEnum.ehEvet;
                    OTHER1.NoClip = EvetHayirEnum.ehEvet;
                    OTHER1.WordBreak = EvetHayirEnum.ehEvet;
                    OTHER1.ExpandTabs = EvetHayirEnum.ehEvet;
                    OTHER1.TextFont.Size = 8;
                    OTHER1.TextFont.CharSet = 162;
                    OTHER1.Value = @"{#Header.OTHER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    SocServAppliedProcedures.GetSocServAppliedProcedures_Class dataset_GetSocServAppliedProcedures = MyParentReport.Header.rsGroup.GetCurrentRecord<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(0);
                    NewField11511.CalcValue = NewField11511.Value;
                    OTHER1.CalcValue = (dataset_GetSocServAppliedProcedures != null ? Globals.ToStringCore(dataset_GetSocServAppliedProcedures.Other) : "");
                    return new TTReportObject[] { NewField11511,OTHER1};
                }
            }

        }

        public group121Group group121;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public SocialServicesAppliedProceduresReport()
        {
            Header = new HeaderGroup(this,"Header");
            PatienInfo = new PatienInfoGroup(Header,"PatienInfo");
            MAIN = new MAINGroup(Header,"MAIN");
            group2 = new group2Group(Header,"group2");
            group3 = new group3Group(Header,"group3");
            group4 = new group4Group(Header,"group4");
            group5 = new group5Group(Header,"group5");
            group6 = new group6Group(Header,"group6");
            group7 = new group7Group(Header,"group7");
            group8 = new group8Group(Header,"group8");
            group9 = new group9Group(Header,"group9");
            group10 = new group10Group(Header,"group10");
            group11 = new group11Group(Header,"group11");
            group12 = new group12Group(Header,"group12");
            group13 = new group13Group(Header,"group13");
            group14 = new group14Group(Header,"group14");
            group121 = new group121Group(Header,"group121");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "", "", @"", true, true, false, new Guid("8c070a29-bd8b-41e9-a888-1108a97d2419"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (string)TTObjectDefManager.Instance.DataTypes["StringGuid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "SOCIALSERVICESAPPLIEDPROCEDURESREPORT";
            Caption = "Sosyal Hizmetler Hastaya Yapılan İşlemler";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}