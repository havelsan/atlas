
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

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Sosyal Hizmetler Hastaya Yapılan İşlemler Formu
    /// </summary>
    public partial class SocialServicesAppliedProceduresForm : TTForm
    {
    /// <summary>
    /// Sosyal Hizmetler Hastaya Yapılan Sosyal Hizmet İşlemleri
    /// </summary>
        protected TTObjectClasses.SocServAppliedProcedures _SocServAppliedProcedures
        {
            get { return (TTObjectClasses.SocServAppliedProcedures)_ttObject; }
        }

        protected ITTLabel labelOther;
        protected ITTTextBox Other;
        protected ITTTextBox OpenEducationHighSchool;
        protected ITTTextBox GuidanceServiceOnPhone;
        protected ITTLabel labelOpenEducationHighSchool;
        protected ITTLabel labelProvidedRightsToWarVeterans;
        protected ITTCheckBox GrantingDealership;
        protected ITTCheckBox UtilityFromRehabilitationCent;
        protected ITTCheckBox WeaponPortageTransportLicense;
        protected ITTCheckBox FreeAccessToPrivateEduInstit;
        protected ITTCheckBox MilitaryServiceNearBrotherHom;
        protected ITTCheckBox BrotherExemptionFromMilitary;
        protected ITTCheckBox OTVandMTVExemption;
        protected ITTCheckBox DomesticVehiclePurchases;
        protected ITTCheckBox ImportingDutyFreeVehicle;
        protected ITTCheckBox ElectricAndWaterDiscount;
        protected ITTCheckBox ResidenceTaxExemption;
        protected ITTCheckBox IncomeTaxDiscount;
        protected ITTCheckBox UsageRightFromTOKIHouses;
        protected ITTCheckBox GivingCorporateHousingCredit;
        protected ITTCheckBox ProvideHouseToDisabledStaff;
        protected ITTCheckBox UtilizationOfPublicHousing;
        protected ITTCheckBox ProvidingWarVeteranCard;
        protected ITTCheckBox GrantingEmploymentRights;
        protected ITTCheckBox EducationAidBySGK;
        protected ITTCheckBox SupplementaryPaymentSGK;
        protected ITTCheckBox RetirementBonusBySGK;
        protected ITTCheckBox SalaryStartBySGK;
        protected ITTCheckBox StatePrideMedal;
        protected ITTCheckBox JobResumeStatus;
        protected ITTCheckBox OYAKAid;
        protected ITTCheckBox SoldierLifeInsurance;
        protected ITTCheckBox SoldierFoundationAid;
        protected ITTCheckBox XXXXXXSolidarityFoundationAid;
        protected ITTCheckBox CashIdemnityTransactions;
        protected ITTLabel labelRightsProvidedInternalSecInj;
        protected ITTCheckBox GivingVeteranRightsBrochure;
        protected ITTCheckBox AllowancePayment;
        protected ITTCheckBox IndemnityCompensation;
        protected ITTCheckBox AdvancePayment;
        protected ITTCheckBox HealthAid;
        protected ITTLabel labelSocialActivities;
        protected ITTCheckBox OrganizingPermitDocuments;
        protected ITTCheckBox IdentificationOfParticipants;
        protected ITTLabel labelGuidanceServiceOnPhone;
        protected ITTLabel labelTransportationProcesses;
        protected ITTCheckBox InterCityTransportProcesses;
        protected ITTCheckBox IntraCityTransportProcesses;
        protected ITTLabel labelProcessAppliedDuringDischarge;
        protected ITTCheckBox ArrangementOfWorkSchoolEnv;
        protected ITTCheckBox ArrangementOfLivingPlaces;
        protected ITTLabel labelWorkCoorWithOtherInstitution;
        protected ITTCheckBox CoordWarVeteranContactUnit;
        protected ITTCheckBox GuidanceToPublicInstitution;
        protected ITTCheckBox LegislativeReviewAndInfo;
        protected ITTCheckBox PhoneCallWitPublicInstitution;
        protected ITTLabel labelInformationAboutSocialRights;
        protected ITTCheckBox GuidanceAboutHomeHealthCare;
        protected ITTCheckBox GuidanceAboutLaw;
        protected ITTCheckBox GuidanceAboutCareSalary;
        protected ITTLabel labelProvidingEconomicSupport;
        protected ITTCheckBox GuidanceToCivilOrganizations;
        protected ITTCheckBox GuidanceToFoundations;
        protected ITTCheckBox BenefitingFromDonations;
        protected ITTLabel labelAppliedProcessesInHospital;
        protected ITTCheckBox GuidanceOnDrugSupplyAbroad;
        protected ITTCheckBox DonatedMedicalSupplyProcure;
        protected ITTCheckBox MedicEqProcRefundInfoProcure;
        protected ITTCheckBox InformAndDirectRetireProc;
        protected ITTCheckBox CalcAndFollowRestProc;
        protected ITTLabel labelMedicalTeamProcedures;
        protected ITTCheckBox WeeklyVisitAttendence;
        protected ITTCheckBox WeeklyTeamMeetings;
        protected ITTLabel labelAppliedProcOnFirstInpatient;
        protected ITTCheckBox ProvisionIssues;
        protected ITTCheckBox ProvideInternalSecInjStatDoc;
        protected ITTCheckBox ProvidingAccomodation;
        override protected void InitializeControls()
        {
            labelOther = (ITTLabel)AddControl(new Guid("5065df8a-c7b2-498e-94f7-1115fd86d73c"));
            Other = (ITTTextBox)AddControl(new Guid("b7cc78fa-3c33-4d19-b04f-0cb5bfc356ae"));
            OpenEducationHighSchool = (ITTTextBox)AddControl(new Guid("efefc0a4-97fc-4d4e-b537-847546a08a21"));
            GuidanceServiceOnPhone = (ITTTextBox)AddControl(new Guid("23b49fb9-f53b-4fd9-9add-eed2d4262264"));
            labelOpenEducationHighSchool = (ITTLabel)AddControl(new Guid("5af2e107-7190-4d37-9ce3-346fe665d16d"));
            labelProvidedRightsToWarVeterans = (ITTLabel)AddControl(new Guid("c5746b25-12b3-4a7e-8155-510986f3314d"));
            GrantingDealership = (ITTCheckBox)AddControl(new Guid("e6718ca3-7be5-49d3-ad6b-73abe27fc9fb"));
            UtilityFromRehabilitationCent = (ITTCheckBox)AddControl(new Guid("4d80f891-4a5a-4145-9bbd-4d71099d9e3f"));
            WeaponPortageTransportLicense = (ITTCheckBox)AddControl(new Guid("e1dc537b-5237-4f3d-ba80-7b3348b4fd8b"));
            FreeAccessToPrivateEduInstit = (ITTCheckBox)AddControl(new Guid("86f2fbb3-cef9-49b4-bb31-ed96ff1d8b9f"));
            MilitaryServiceNearBrotherHom = (ITTCheckBox)AddControl(new Guid("cf47003e-2aa2-487f-a654-d1fcf115d02a"));
            BrotherExemptionFromMilitary = (ITTCheckBox)AddControl(new Guid("109e489d-2119-423b-a1c0-aac689d64aa2"));
            OTVandMTVExemption = (ITTCheckBox)AddControl(new Guid("c2719462-0859-4402-b1a9-1ef90051b403"));
            DomesticVehiclePurchases = (ITTCheckBox)AddControl(new Guid("0eda93ec-af89-4f3d-a199-289f5e61012e"));
            ImportingDutyFreeVehicle = (ITTCheckBox)AddControl(new Guid("0c113472-431b-4f57-b438-f00081638a25"));
            ElectricAndWaterDiscount = (ITTCheckBox)AddControl(new Guid("606453be-af40-4f4b-bd30-d30a6955ca55"));
            ResidenceTaxExemption = (ITTCheckBox)AddControl(new Guid("1a00e678-fda6-4728-b885-9eec1953ebf5"));
            IncomeTaxDiscount = (ITTCheckBox)AddControl(new Guid("19aef70c-8196-4f04-b81c-f216e4848db7"));
            UsageRightFromTOKIHouses = (ITTCheckBox)AddControl(new Guid("02e972fc-1f6e-40f0-95b9-787a7df78394"));
            GivingCorporateHousingCredit = (ITTCheckBox)AddControl(new Guid("7e11b1b8-c9f9-4728-9c1c-96f780228105"));
            ProvideHouseToDisabledStaff = (ITTCheckBox)AddControl(new Guid("bb957200-1f2d-48a4-87bf-b796a5b4ab50"));
            UtilizationOfPublicHousing = (ITTCheckBox)AddControl(new Guid("381e4fcb-aa4a-4006-9797-27429855c01a"));
            ProvidingWarVeteranCard = (ITTCheckBox)AddControl(new Guid("ac9e0867-f39b-42cc-b127-b6c6680565f6"));
            GrantingEmploymentRights = (ITTCheckBox)AddControl(new Guid("860f53df-25cd-41c7-b82f-6d35d9b8b7cc"));
            EducationAidBySGK = (ITTCheckBox)AddControl(new Guid("2ab6095c-8566-428e-8275-23df74756af7"));
            SupplementaryPaymentSGK = (ITTCheckBox)AddControl(new Guid("c6569269-7942-4828-9410-8b64a1e4b61d"));
            RetirementBonusBySGK = (ITTCheckBox)AddControl(new Guid("87ffc288-7966-49af-bdcd-bd6a15971135"));
            SalaryStartBySGK = (ITTCheckBox)AddControl(new Guid("4e100f5d-baa8-4e7c-8d63-1c0428da5a91"));
            StatePrideMedal = (ITTCheckBox)AddControl(new Guid("91f30edf-b38e-419a-b297-c8be6a835924"));
            JobResumeStatus = (ITTCheckBox)AddControl(new Guid("4d849a42-7a79-4ac2-a74d-db977b66a46d"));
            OYAKAid = (ITTCheckBox)AddControl(new Guid("3f88fa3d-5c99-4612-a4e6-e5d5c8e1fa80"));
            SoldierLifeInsurance = (ITTCheckBox)AddControl(new Guid("771b4d34-4db0-412b-a76c-718ce4c38886"));
            SoldierFoundationAid = (ITTCheckBox)AddControl(new Guid("c8089c9b-a4d1-4a4b-8703-6f40f4ec0ebd"));
            XXXXXXSolidarityFoundationAid = (ITTCheckBox)AddControl(new Guid("defc334e-a4bc-4000-a788-4c93d156c66c"));
            CashIdemnityTransactions = (ITTCheckBox)AddControl(new Guid("100923cc-f4b8-42d8-b919-cbcb3003f3a6"));
            labelRightsProvidedInternalSecInj = (ITTLabel)AddControl(new Guid("d5564b45-2741-4768-ac0b-2b5a733b7f57"));
            GivingVeteranRightsBrochure = (ITTCheckBox)AddControl(new Guid("cfa5ba47-2a72-4903-b2e0-b58fdce2eae1"));
            AllowancePayment = (ITTCheckBox)AddControl(new Guid("87872db9-19fe-42b2-8340-856a9921c806"));
            IndemnityCompensation = (ITTCheckBox)AddControl(new Guid("d803fdb8-c252-4a15-ae1d-3669ae395a16"));
            AdvancePayment = (ITTCheckBox)AddControl(new Guid("12bad78e-54f7-407c-adb2-32dac159ad33"));
            HealthAid = (ITTCheckBox)AddControl(new Guid("1bdad684-7da3-4dcf-ab56-dbace463d363"));
            labelSocialActivities = (ITTLabel)AddControl(new Guid("9d7e638b-1cf0-45d0-ae15-1810f2aed0b2"));
            OrganizingPermitDocuments = (ITTCheckBox)AddControl(new Guid("7c5a5572-9917-44e6-bba1-8e54fdd365ca"));
            IdentificationOfParticipants = (ITTCheckBox)AddControl(new Guid("9179d402-0fcd-4a02-83c4-6aa68ecba911"));
            labelGuidanceServiceOnPhone = (ITTLabel)AddControl(new Guid("9c248e2e-5def-40e0-8bca-e85a697b1739"));
            labelTransportationProcesses = (ITTLabel)AddControl(new Guid("3bc9cbc4-21af-4965-becf-709b8c28b89a"));
            InterCityTransportProcesses = (ITTCheckBox)AddControl(new Guid("dad2e4d3-fc05-4903-9134-cfc5ff5d6a9f"));
            IntraCityTransportProcesses = (ITTCheckBox)AddControl(new Guid("98dc14ef-a857-402b-9b36-eac520ede3cc"));
            labelProcessAppliedDuringDischarge = (ITTLabel)AddControl(new Guid("80835015-386a-4b60-af50-00d2bbb3c9b5"));
            ArrangementOfWorkSchoolEnv = (ITTCheckBox)AddControl(new Guid("f87876e9-a10e-487b-b45c-04610d861d1f"));
            ArrangementOfLivingPlaces = (ITTCheckBox)AddControl(new Guid("99316be2-21fe-4e1a-8d1e-b40ee7bbc579"));
            labelWorkCoorWithOtherInstitution = (ITTLabel)AddControl(new Guid("1ce94d1d-b8b6-4e95-893d-e9a90c68cd9c"));
            CoordWarVeteranContactUnit = (ITTCheckBox)AddControl(new Guid("cf23d65d-b96e-4ae5-a45a-243f726e6ef5"));
            GuidanceToPublicInstitution = (ITTCheckBox)AddControl(new Guid("210583d8-ce41-4d94-8312-cea5f1afcc77"));
            LegislativeReviewAndInfo = (ITTCheckBox)AddControl(new Guid("8d5563bc-e53b-4c2d-8a69-0f6f3aab4783"));
            PhoneCallWitPublicInstitution = (ITTCheckBox)AddControl(new Guid("8024880f-744a-4c0c-b706-38bedf44ac10"));
            labelInformationAboutSocialRights = (ITTLabel)AddControl(new Guid("3b720e67-fff4-4cb6-ac6e-4195cc323936"));
            GuidanceAboutHomeHealthCare = (ITTCheckBox)AddControl(new Guid("b5fe1bf1-c823-4500-820b-bd3d303b120e"));
            GuidanceAboutLaw = (ITTCheckBox)AddControl(new Guid("a627c38b-1395-4b91-b012-031279c61084"));
            GuidanceAboutCareSalary = (ITTCheckBox)AddControl(new Guid("b32c580c-b8b6-41fe-bc17-9b22e1478a6c"));
            labelProvidingEconomicSupport = (ITTLabel)AddControl(new Guid("452b3ab1-8eba-467f-946a-5273e8f3b16c"));
            GuidanceToCivilOrganizations = (ITTCheckBox)AddControl(new Guid("d148d203-65b2-49bf-a444-670faa71c588"));
            GuidanceToFoundations = (ITTCheckBox)AddControl(new Guid("4c710a50-fb14-4bfe-b4c2-c11fa1c27925"));
            BenefitingFromDonations = (ITTCheckBox)AddControl(new Guid("422e3983-1915-4f9c-a4cd-b590cefee1ca"));
            labelAppliedProcessesInHospital = (ITTLabel)AddControl(new Guid("e0418947-cc6f-4fbf-8982-628da69e453f"));
            GuidanceOnDrugSupplyAbroad = (ITTCheckBox)AddControl(new Guid("ad053667-b8cf-4e5e-8558-0b9321274cea"));
            DonatedMedicalSupplyProcure = (ITTCheckBox)AddControl(new Guid("06669768-8b0c-4c80-82f3-f90a80a8e8b6"));
            MedicEqProcRefundInfoProcure = (ITTCheckBox)AddControl(new Guid("481e77ba-2163-40f8-853a-6ab6944df71f"));
            InformAndDirectRetireProc = (ITTCheckBox)AddControl(new Guid("5077aeca-2e66-444f-8124-fba3261bec90"));
            CalcAndFollowRestProc = (ITTCheckBox)AddControl(new Guid("f3e18655-6520-4e41-85e5-61c78591a9eb"));
            labelMedicalTeamProcedures = (ITTLabel)AddControl(new Guid("f8d302bb-f5e1-4d5a-ab7b-00f3b7302600"));
            WeeklyVisitAttendence = (ITTCheckBox)AddControl(new Guid("f4159c4c-239f-4e0f-9ad9-a093ccb20714"));
            WeeklyTeamMeetings = (ITTCheckBox)AddControl(new Guid("e492cbf6-a64b-41d9-ac50-59c589819267"));
            labelAppliedProcOnFirstInpatient = (ITTLabel)AddControl(new Guid("be0a9b26-538b-4cdc-8830-017128ef11ce"));
            ProvisionIssues = (ITTCheckBox)AddControl(new Guid("3a5f6af8-d9da-496f-b7fc-fa76a73cbeea"));
            ProvideInternalSecInjStatDoc = (ITTCheckBox)AddControl(new Guid("14df188e-37ee-4f18-b943-d887d9623e3e"));
            ProvidingAccomodation = (ITTCheckBox)AddControl(new Guid("66abcc7f-8e7d-452e-881a-157702fc9203"));
            base.InitializeControls();
        }

        public SocialServicesAppliedProceduresForm() : base("SOCSERVAPPLIEDPROCEDURES", "SocialServicesAppliedProceduresForm")
        {
        }

        protected SocialServicesAppliedProceduresForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}