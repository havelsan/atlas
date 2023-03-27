
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
namespace TTObjectClasses
{
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SocServAppliedProcedures")] 

    /// <summary>
    /// Sosyal Hizmetler Hastaya Yapılan Sosyal Hizmet İşlemleri
    /// </summary>
    public  partial class SocServAppliedProcedures : TTObject
    {
        public class SocServAppliedProceduresList : TTObjectCollection<SocServAppliedProcedures> { }
                    
        public class ChildSocServAppliedProceduresCollection : TTObject.TTChildObjectCollection<SocServAppliedProcedures>
        {
            public ChildSocServAppliedProceduresCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSocServAppliedProceduresCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSocServAppliedProcedures_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public bool? ProvidingAccomodation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDINGACCOMODATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDINGACCOMODATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ProvideInternalSecInjStatDoc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDEINTERNALSECINJSTATDOC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDEINTERNALSECINJSTATDOC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ProvisionIssues
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVISIONISSUES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVISIONISSUES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WeeklyTeamMeetings
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYTEAMMEETINGS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["WEEKLYTEAMMEETINGS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WeeklyVisitAttendence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYVISITATTENDENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["WEEKLYVISITATTENDENCE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CalcAndFollowRestProc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALCANDFOLLOWRESTPROC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["CALCANDFOLLOWRESTPROC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InformAndDirectRetireProc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFORMANDDIRECTRETIREPROC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INFORMANDDIRECTRETIREPROC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MedicEqProcRefundInfoProcure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICEQPROCREFUNDINFOPROCURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["MEDICEQPROCREFUNDINFOPROCURE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DonatedMedicalSupplyProcure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONATEDMEDICALSUPPLYPROCURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["DONATEDMEDICALSUPPLYPROCURE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GuidanceOnDrugSupplyAbroad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEONDRUGSUPPLYABROAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEONDRUGSUPPLYABROAD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BenefitingFromDonations
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFITINGFROMDONATIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["BENEFITINGFROMDONATIONS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GuidanceToFoundations
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCETOFOUNDATIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCETOFOUNDATIONS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GuidanceToCivilOrganizations
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCETOCIVILORGANIZATIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCETOCIVILORGANIZATIONS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GuidanceAboutCareSalary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEABOUTCARESALARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEABOUTCARESALARY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GuidanceAboutLaw
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEABOUTLAW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEABOUTLAW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GuidanceAboutHomeHealthCare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEABOUTHOMEHEALTHCARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEABOUTHOMEHEALTHCARE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PhoneCallWitPublicInstitution
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONECALLWITPUBLICINSTITUTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PHONECALLWITPUBLICINSTITUTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? LegislativeReviewAndInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LEGISLATIVEREVIEWANDINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["LEGISLATIVEREVIEWANDINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GuidanceToPublicInstitution
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCETOPUBLICINSTITUTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCETOPUBLICINSTITUTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CoordWarVeteranContactUnit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COORDWARVETERANCONTACTUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["COORDWARVETERANCONTACTUNIT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ArrangementOfLivingPlaces
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRANGEMENTOFLIVINGPLACES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ARRANGEMENTOFLIVINGPLACES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ArrangementOfWorkSchoolEnv
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRANGEMENTOFWORKSCHOOLENV"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ARRANGEMENTOFWORKSCHOOLENV"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IntraCityTransportProcesses
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTRACITYTRANSPORTPROCESSES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INTRACITYTRANSPORTPROCESSES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InterCityTransportProcesses
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERCITYTRANSPORTPROCESSES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INTERCITYTRANSPORTPROCESSES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IdentificationOfParticipants
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONOFPARTICIPANTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["IDENTIFICATIONOFPARTICIPANTS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OrganizingPermitDocuments
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORGANIZINGPERMITDOCUMENTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ORGANIZINGPERMITDOCUMENTS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HealthAid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHAID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["HEALTHAID"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AdvancePayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADVANCEPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ADVANCEPAYMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IndemnityCompensation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INDEMNITYCOMPENSATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INDEMNITYCOMPENSATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AllowancePayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWANCEPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ALLOWANCEPAYMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GivingVeteranRightsBrochure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGVETERANRIGHTSBROCHURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GIVINGVETERANRIGHTSBROCHURE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CashIdemnityTransactions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIDEMNITYTRANSACTIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["CASHIDEMNITYTRANSACTIONS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? XXXXXXSolidarityFoundationAid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXSOLIDARITYFOUNDATIONAID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["XXXXXXSOLIDARITYFOUNDATIONAID"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SoldierFoundationAid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLDIERFOUNDATIONAID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SOLDIERFOUNDATIONAID"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SoldierLifeInsurance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLDIERLIFEINSURANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SOLDIERLIFEINSURANCE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OYAKAid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OYAKAID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["OYAKAID"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? JobResumeStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOBRESUMESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["JOBRESUMESTATUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? StatePrideMedal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEPRIDEMEDAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["STATEPRIDEMEDAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SalaryStartBySGK
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SALARYSTARTBYSGK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SALARYSTARTBYSGK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? RetirementBonusBySGK
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETIREMENTBONUSBYSGK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["RETIREMENTBONUSBYSGK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SupplementaryPaymentSGK
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLEMENTARYPAYMENTSGK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SUPPLEMENTARYPAYMENTSGK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? EducationAidBySGK
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EDUCATIONAIDBYSGK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["EDUCATIONAIDBYSGK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GrantingEmploymentRights
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRANTINGEMPLOYMENTRIGHTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GRANTINGEMPLOYMENTRIGHTS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ProvidingWarVeteranCard
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDINGWARVETERANCARD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDINGWARVETERANCARD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UtilizationOfPublicHousing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UTILIZATIONOFPUBLICHOUSING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["UTILIZATIONOFPUBLICHOUSING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ProvideHouseToDisabledStaff
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDEHOUSETODISABLEDSTAFF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDEHOUSETODISABLEDSTAFF"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GivingCorporateHousingCredit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGCORPORATEHOUSINGCREDIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GIVINGCORPORATEHOUSINGCREDIT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? UsageRightFromTOKIHouses
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGERIGHTFROMTOKIHOUSES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["USAGERIGHTFROMTOKIHOUSES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncomeTaxDiscount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCOMETAXDISCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INCOMETAXDISCOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ResidenceTaxExemption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESIDENCETAXEXEMPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["RESIDENCETAXEXEMPTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ElectricAndWaterDiscount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELECTRICANDWATERDISCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ELECTRICANDWATERDISCOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ImportingDutyFreeVehicle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMPORTINGDUTYFREEVEHICLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["IMPORTINGDUTYFREEVEHICLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DomesticVehiclePurchases
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOMESTICVEHICLEPURCHASES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["DOMESTICVEHICLEPURCHASES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OTVandMTVExemption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTVANDMTVEXEMPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["OTVANDMTVEXEMPTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BrotherExemptionFromMilitary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BROTHEREXEMPTIONFROMMILITARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["BROTHEREXEMPTIONFROMMILITARY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MilitaryServiceNearBrotherHom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYSERVICENEARBROTHERHOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["MILITARYSERVICENEARBROTHERHOM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? FreeAccessToPrivateEduInstit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEACCESSTOPRIVATEEDUINSTIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["FREEACCESSTOPRIVATEEDUINSTIT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WeaponPortageTransportLicense
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEAPONPORTAGETRANSPORTLICENSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["WEAPONPORTAGETRANSPORTLICENSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ProvidingAccomodationInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDINGACCOMODATIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDINGACCOMODATIONINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProvideInterSecInjStatDocInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDEINTERSECINJSTATDOCINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDEINTERSECINJSTATDOCINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProvisionIssuesInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVISIONISSUESINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVISIONISSUESINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WeeklyTeamMeetingsInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYTEAMMEETINGSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["WEEKLYTEAMMEETINGSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WeeklyVisitAttendenceInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYVISITATTENDENCEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["WEEKLYVISITATTENDENCEINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CalcAndFollowRestProcInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALCANDFOLLOWRESTPROCINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["CALCANDFOLLOWRESTPROCINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InformAndDirectRetireProcInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFORMANDDIRECTRETIREPROCINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INFORMANDDIRECTRETIREPROCINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedicEqProcRefundInfoProcInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICEQPROCREFUNDINFOPROCINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["MEDICEQPROCREFUNDINFOPROCINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DonatedMedicalSupplyProcInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONATEDMEDICALSUPPLYPROCINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["DONATEDMEDICALSUPPLYPROCINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceDrugSupplyAbroadInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEDRUGSUPPLYABROADINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEDRUGSUPPLYABROADINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceToCivilOrganizatInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCETOCIVILORGANIZATINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCETOCIVILORGANIZATINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceToFoundationsInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCETOFOUNDATIONSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCETOFOUNDATIONSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BenefitingFromDonationsInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENEFITINGFROMDONATIONSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["BENEFITINGFROMDONATIONSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceAboutCareSalaryInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEABOUTCARESALARYINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEABOUTCARESALARYINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceAboutLawInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEABOUTLAWINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEABOUTLAWINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceAboutHomeHealthCrInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCEABOUTHOMEHEALTHCRINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCEABOUTHOMEHEALTHCRINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhoneCallWitPublicInstitInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHONECALLWITPUBLICINSTITINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PHONECALLWITPUBLICINSTITINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LegislativeReviewAndInfoInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LEGISLATIVEREVIEWANDINFOINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["LEGISLATIVEREVIEWANDINFOINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceToPublicInstitInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCETOPUBLICINSTITINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCETOPUBLICINSTITINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CoordWarVeteranContactUniInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COORDWARVETERANCONTACTUNIINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["COORDWARVETERANCONTACTUNIINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ArrangementOfLivingPlacesInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRANGEMENTOFLIVINGPLACESINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ARRANGEMENTOFLIVINGPLACESINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ArrangementOfWorkSchoolEnInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRANGEMENTOFWORKSCHOOLENINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ARRANGEMENTOFWORKSCHOOLENINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntraCityTransportProcessInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTRACITYTRANSPORTPROCESSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INTRACITYTRANSPORTPROCESSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string InterCityTransportProcessInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERCITYTRANSPORTPROCESSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INTERCITYTRANSPORTPROCESSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IdentificationOfParticipInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IDENTIFICATIONOFPARTICIPINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["IDENTIFICATIONOFPARTICIPINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? UtilityFromRehabilitationCent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UTILITYFROMREHABILITATIONCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["UTILITYFROMREHABILITATIONCENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GrantingDealership
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRANTINGDEALERSHIP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GRANTINGDEALERSHIP"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OpenEducationHighSchool
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENEDUCATIONHIGHSCHOOL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["OPENEDUCATIONHIGHSCHOOL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Other
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["OTHER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GuidanceServiceOnPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUIDANCESERVICEONPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GUIDANCESERVICEONPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AdvancePaymentInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADVANCEPAYMENTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ADVANCEPAYMENTINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IndemnityCompensationInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INDEMNITYCOMPENSATIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INDEMNITYCOMPENSATIONINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrganizingPermitDocumentsInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORGANIZINGPERMITDOCUMENTSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ORGANIZINGPERMITDOCUMENTSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HealthAidInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEALTHAIDINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["HEALTHAIDINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AllowancePaymentInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWANCEPAYMENTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ALLOWANCEPAYMENTINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GivingVeteranRightsBrocInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGVETERANRIGHTSBROCINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GIVINGVETERANRIGHTSBROCINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CashIdemnityTransactionsInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIDEMNITYTRANSACTIONSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["CASHIDEMNITYTRANSACTIONSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string XXXXXXSolidarityFoundatioAidInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["XXXXXXSOLIDARITYFOUNDATIOAIDINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["XXXXXXSOLIDARITYFOUNDATIOAIDINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SoldierFoundationAidInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLDIERFOUNDATIONAIDINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SOLDIERFOUNDATIONAIDINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SoldierLifeInsuranceInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLDIERLIFEINSURANCEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SOLDIERLIFEINSURANCEINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OYAKAidInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OYAKAIDINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["OYAKAIDINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string JobResumeStatusInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOBRESUMESTATUSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["JOBRESUMESTATUSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string StatePrideMedalInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEPRIDEMEDALINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["STATEPRIDEMEDALINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SalaryStartBySGKInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SALARYSTARTBYSGKINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SALARYSTARTBYSGKINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RetirementBonusBySGKInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETIREMENTBONUSBYSGKINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["RETIREMENTBONUSBYSGKINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SupplementaryPaymentSGKInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLEMENTARYPAYMENTSGKINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["SUPPLEMENTARYPAYMENTSGKINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EducationAidBySGKInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EDUCATIONAIDBYSGKINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["EDUCATIONAIDBYSGKINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GrantingEmploymentRightsInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRANTINGEMPLOYMENTRIGHTSINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GRANTINGEMPLOYMENTRIGHTSINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProvidingWarVeteranCardInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDINGWARVETERANCARDINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDINGWARVETERANCARDINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UtilizationOfPublicHousinInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UTILIZATIONOFPUBLICHOUSININFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["UTILIZATIONOFPUBLICHOUSININFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProvideHouseToDisablStaffInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROVIDEHOUSETODISABLSTAFFINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["PROVIDEHOUSETODISABLSTAFFINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GivingCorporateHousCreditInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVINGCORPORATEHOUSCREDITINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GIVINGCORPORATEHOUSCREDITINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UsageRightFromTOKIHousesInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGERIGHTFROMTOKIHOUSESINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["USAGERIGHTFROMTOKIHOUSESINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IncomeTaxDiscountInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCOMETAXDISCOUNTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["INCOMETAXDISCOUNTINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResidenceTaxExemptionInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESIDENCETAXEXEMPTIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["RESIDENCETAXEXEMPTIONINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ElectricAndWaterDiscountInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELECTRICANDWATERDISCOUNTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["ELECTRICANDWATERDISCOUNTINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ImportingDutyFreeVehicleInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMPORTINGDUTYFREEVEHICLEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["IMPORTINGDUTYFREEVEHICLEINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DomesticVehiclePurchasesInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOMESTICVEHICLEPURCHASESINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["DOMESTICVEHICLEPURCHASESINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OTVandMTVExemptionInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTVANDMTVEXEMPTIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["OTVANDMTVEXEMPTIONINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BrotherExemptionFromMilitInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BROTHEREXEMPTIONFROMMILITINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["BROTHEREXEMPTIONFROMMILITINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MilitarServNearBrotherHomInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARSERVNEARBROTHERHOMINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["MILITARSERVNEARBROTHERHOMINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreeAccessToPrivEduInstitInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEACCESSTOPRIVEDUINSTITINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["FREEACCESSTOPRIVEDUINSTITINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WeaponPortageTransportLicInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEAPONPORTAGETRANSPORTLICINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["WEAPONPORTAGETRANSPORTLICINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UtilityFromRehabilitCentInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UTILITYFROMREHABILITCENTINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["UTILITYFROMREHABILITCENTINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GrantingDealershipInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRANTINGDEALERSHIPINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["GRANTINGDEALERSHIPINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string VocationalRehabilitationInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOCATIONALREHABILITATIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["VOCATIONALREHABILITATIONINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? VocationalRehabilitation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOCATIONALREHABILITATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].AllPropertyDefs["VOCATIONALREHABILITATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetSocServAppliedProcedures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSocServAppliedProcedures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSocServAppliedProcedures_Class() : base() { }
        }

        public static BindingList<SocServAppliedProcedures.GetSocServAppliedProcedures_Class> GetSocServAppliedProcedures(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].QueryDefs["GetSocServAppliedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SocServAppliedProcedures.GetSocServAppliedProcedures_Class> GetSocServAppliedProcedures(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOCSERVAPPLIEDPROCEDURES"].QueryDefs["GetSocServAppliedProcedures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SocServAppliedProcedures.GetSocServAppliedProcedures_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta ve Yakınlarına Kalacak Yer Temini
    /// </summary>
        public bool? ProvidingAccomodation
        {
            get { return (bool?)this["PROVIDINGACCOMODATION"]; }
            set { this["PROVIDINGACCOMODATION"] = value; }
        }

    /// <summary>
    /// İç Güvenlik Yaralı Durum Belgesi Temini
    /// </summary>
        public bool? ProvideInternalSecInjStatDoc
        {
            get { return (bool?)this["PROVIDEINTERNALSECINJSTATDOC"]; }
            set { this["PROVIDEINTERNALSECINJSTATDOC"] = value; }
        }

    /// <summary>
    /// Provizyon Sorunları
    /// </summary>
        public bool? ProvisionIssues
        {
            get { return (bool?)this["PROVISIONISSUES"]; }
            set { this["PROVISIONISSUES"] = value; }
        }

    /// <summary>
    /// Haftalık Ekip Toplantıları
    /// </summary>
        public bool? WeeklyTeamMeetings
        {
            get { return (bool?)this["WEEKLYTEAMMEETINGS"]; }
            set { this["WEEKLYTEAMMEETINGS"] = value; }
        }

    /// <summary>
    /// Haftalık Vizite Katılım
    /// </summary>
        public bool? WeeklyVisitAttendence
        {
            get { return (bool?)this["WEEKLYVISITATTENDENCE"]; }
            set { this["WEEKLYVISITATTENDENCE"] = value; }
        }

    /// <summary>
    /// İstirahat Süreçlerinin Hesaplanması ve Takibi
    /// </summary>
        public bool? CalcAndFollowRestProc
        {
            get { return (bool?)this["CALCANDFOLLOWRESTPROC"]; }
            set { this["CALCANDFOLLOWRESTPROC"] = value; }
        }

    /// <summary>
    /// Emeklilik Süreci Bilgilendirme ve Yönlendirme
    /// </summary>
        public bool? InformAndDirectRetireProc
        {
            get { return (bool?)this["INFORMANDDIRECTRETIREPROC"]; }
            set { this["INFORMANDDIRECTRETIREPROC"] = value; }
        }

    /// <summary>
    /// Malzeme Prosedürü-Geri Ödeme,Bilgilendirme,Temini
    /// </summary>
        public bool? MedicEqProcRefundInfoProcure
        {
            get { return (bool?)this["MEDICEQPROCREFUNDINFOPROCURE"]; }
            set { this["MEDICEQPROCREFUNDINFOPROCURE"] = value; }
        }

    /// <summary>
    /// Bağış Tıbbi Malzeme Temini
    /// </summary>
        public bool? DonatedMedicalSupplyProcure
        {
            get { return (bool?)this["DONATEDMEDICALSUPPLYPROCURE"]; }
            set { this["DONATEDMEDICALSUPPLYPROCURE"] = value; }
        }

    /// <summary>
    /// Yurtdışı İlaç Teminiyle İlgili Yönlendirme
    /// </summary>
        public bool? GuidanceOnDrugSupplyAbroad
        {
            get { return (bool?)this["GUIDANCEONDRUGSUPPLYABROAD"]; }
            set { this["GUIDANCEONDRUGSUPPLYABROAD"] = value; }
        }

    /// <summary>
    /// Bağışlardan Yararlandırma
    /// </summary>
        public bool? BenefitingFromDonations
        {
            get { return (bool?)this["BENEFITINGFROMDONATIONS"]; }
            set { this["BENEFITINGFROMDONATIONS"] = value; }
        }

    /// <summary>
    /// Sosyal Yardımlaşma ve Dayanışma Vakfı Yönlendirme
    /// </summary>
        public bool? GuidanceToFoundations
        {
            get { return (bool?)this["GUIDANCETOFOUNDATIONS"]; }
            set { this["GUIDANCETOFOUNDATIONS"] = value; }
        }

    /// <summary>
    /// Sivil Toplum Örgütlerine Yönlendirme
    /// </summary>
        public bool? GuidanceToCivilOrganizations
        {
            get { return (bool?)this["GUIDANCETOCIVILORGANIZATIONS"]; }
            set { this["GUIDANCETOCIVILORGANIZATIONS"] = value; }
        }

    /// <summary>
    /// Bakım Maaşı ile İlgili Yönlendirme
    /// </summary>
        public bool? GuidanceAboutCareSalary
        {
            get { return (bool?)this["GUIDANCEABOUTCARESALARY"]; }
            set { this["GUIDANCEABOUTCARESALARY"] = value; }
        }

    /// <summary>
    /// 2022 Sayılı Yasa ile İlgili Yönlendirme
    /// </summary>
        public bool? GuidanceAboutLaw
        {
            get { return (bool?)this["GUIDANCEABOUTLAW"]; }
            set { this["GUIDANCEABOUTLAW"] = value; }
        }

    /// <summary>
    /// Evde Sağlık Hizmetleri ile İlgili Yönlendirme
    /// </summary>
        public bool? GuidanceAboutHomeHealthCare
        {
            get { return (bool?)this["GUIDANCEABOUTHOMEHEALTHCARE"]; }
            set { this["GUIDANCEABOUTHOMEHEALTHCARE"] = value; }
        }

    /// <summary>
    /// Kamu Kurum/Kuruluşlarına Yapılan Telefon Görüşmesi
    /// </summary>
        public bool? PhoneCallWitPublicInstitution
        {
            get { return (bool?)this["PHONECALLWITPUBLICINSTITUTION"]; }
            set { this["PHONECALLWITPUBLICINSTITUTION"] = value; }
        }

    /// <summary>
    /// İlgili Mevzuatın İncelenmesi ve Bilgilendirme
    /// </summary>
        public bool? LegislativeReviewAndInfo
        {
            get { return (bool?)this["LEGISLATIVEREVIEWANDINFO"]; }
            set { this["LEGISLATIVEREVIEWANDINFO"] = value; }
        }

    /// <summary>
    /// Kamu Kurum/Kuruluşlarına Yönlendirme
    /// </summary>
        public bool? GuidanceToPublicInstitution
        {
            get { return (bool?)this["GUIDANCETOPUBLICINSTITUTION"]; }
            set { this["GUIDANCETOPUBLICINSTITUTION"] = value; }
        }

    /// <summary>
    /// XXXXXXdeki Gazi İrtibat Birimi ile Koordinasyon
    /// </summary>
        public bool? CoordWarVeteranContactUnit
        {
            get { return (bool?)this["COORDWARVETERANCONTACTUNIT"]; }
            set { this["COORDWARVETERANCONTACTUNIT"] = value; }
        }

    /// <summary>
    /// Yaşam Alanlarının Düzenlenmesi
    /// </summary>
        public bool? ArrangementOfLivingPlaces
        {
            get { return (bool?)this["ARRANGEMENTOFLIVINGPLACES"]; }
            set { this["ARRANGEMENTOFLIVINGPLACES"] = value; }
        }

    /// <summary>
    /// İş Ortamının, Okul Ortamının Düzenlenmesi
    /// </summary>
        public bool? ArrangementOfWorkSchoolEnv
        {
            get { return (bool?)this["ARRANGEMENTOFWORKSCHOOLENV"]; }
            set { this["ARRANGEMENTOFWORKSCHOOLENV"] = value; }
        }

    /// <summary>
    /// Tedavi Sürecinde İl İçi Ulaşım İşlemleri
    /// </summary>
        public bool? IntraCityTransportProcesses
        {
            get { return (bool?)this["INTRACITYTRANSPORTPROCESSES"]; }
            set { this["INTRACITYTRANSPORTPROCESSES"] = value; }
        }

    /// <summary>
    /// Taburculuk Sırasında İl Dışı 112 Ambulans,uçak vb.
    /// </summary>
        public bool? InterCityTransportProcesses
        {
            get { return (bool?)this["INTERCITYTRANSPORTPROCESSES"]; }
            set { this["INTERCITYTRANSPORTPROCESSES"] = value; }
        }

    /// <summary>
    /// Faaliyetlerde Katılımcıların Belirlenmesi
    /// </summary>
        public bool? IdentificationOfParticipants
        {
            get { return (bool?)this["IDENTIFICATIONOFPARTICIPANTS"]; }
            set { this["IDENTIFICATIONOFPARTICIPANTS"] = value; }
        }

    /// <summary>
    /// İzin Belgelerinin Düzenlenmesi
    /// </summary>
        public bool? OrganizingPermitDocuments
        {
            get { return (bool?)this["ORGANIZINGPERMITDOCUMENTS"]; }
            set { this["ORGANIZINGPERMITDOCUMENTS"] = value; }
        }

    /// <summary>
    /// Sağlık Yardımı
    /// </summary>
        public bool? HealthAid
        {
            get { return (bool?)this["HEALTHAID"]; }
            set { this["HEALTHAID"] = value; }
        }

    /// <summary>
    /// Avans Ödemesi
    /// </summary>
        public bool? AdvancePayment
        {
            get { return (bool?)this["ADVANCEPAYMENT"]; }
            set { this["ADVANCEPAYMENT"] = value; }
        }

    /// <summary>
    /// Özel Harekat ve Operasyon Tazminatı
    /// </summary>
        public bool? IndemnityCompensation
        {
            get { return (bool?)this["INDEMNITYCOMPENSATION"]; }
            set { this["INDEMNITYCOMPENSATION"] = value; }
        }

    /// <summary>
    /// Harçlık Ödemesi
    /// </summary>
        public bool? AllowancePayment
        {
            get { return (bool?)this["ALLOWANCEPAYMENT"]; }
            set { this["ALLOWANCEPAYMENT"] = value; }
        }

    /// <summary>
    /// Gazilere Sağlanan Haklar Broşürünün Verilmesi
    /// </summary>
        public bool? GivingVeteranRightsBrochure
        {
            get { return (bool?)this["GIVINGVETERANRIGHTSBROCHURE"]; }
            set { this["GIVINGVETERANRIGHTSBROCHURE"] = value; }
        }

    /// <summary>
    /// Nakdi Tazminat İşlemleri
    /// </summary>
        public bool? CashIdemnityTransactions
        {
            get { return (bool?)this["CASHIDEMNITYTRANSACTIONS"]; }
            set { this["CASHIDEMNITYTRANSACTIONS"] = value; }
        }

    /// <summary>
    /// XXXXXX Dayanışma Vakfı Yardımı
    /// </summary>
        public bool? XXXXXXSolidarityFoundationAid
        {
            get { return (bool?)this["XXXXXXSOLIDARITYFOUNDATIONAID"]; }
            set { this["XXXXXXSOLIDARITYFOUNDATIONAID"] = value; }
        }

    /// <summary>
    /// Mehmetçik Vakfı Yardımları
    /// </summary>
        public bool? SoldierFoundationAid
        {
            get { return (bool?)this["SOLDIERFOUNDATIONAID"]; }
            set { this["SOLDIERFOUNDATIONAID"] = value; }
        }

    /// <summary>
    /// Mehmetçik Yaşam Sigortası
    /// </summary>
        public bool? SoldierLifeInsurance
        {
            get { return (bool?)this["SOLDIERLIFEINSURANCE"]; }
            set { this["SOLDIERLIFEINSURANCE"] = value; }
        }

    /// <summary>
    /// OYAK Yardımı
    /// </summary>
        public bool? OYAKAid
        {
            get { return (bool?)this["OYAKAID"]; }
            set { this["OYAKAID"] = value; }
        }

    /// <summary>
    /// Göreve Devam Etme Durumu
    /// </summary>
        public bool? JobResumeStatus
        {
            get { return (bool?)this["JOBRESUMESTATUS"]; }
            set { this["JOBRESUMESTATUS"] = value; }
        }

    /// <summary>
    /// Devlet Ödünç Madalyası, Malul Gazi Rozeti
    /// </summary>
        public bool? StatePrideMedal
        {
            get { return (bool?)this["STATEPRIDEMEDAL"]; }
            set { this["STATEPRIDEMEDAL"] = value; }
        }

    /// <summary>
    /// SGK Tarafından Maaş Bağlanması
    /// </summary>
        public bool? SalaryStartBySGK
        {
            get { return (bool?)this["SALARYSTARTBYSGK"]; }
            set { this["SALARYSTARTBYSGK"] = value; }
        }

    /// <summary>
    /// SGK Tarafından Emekli İkramiyesi Verilmesi
    /// </summary>
        public bool? RetirementBonusBySGK
        {
            get { return (bool?)this["RETIREMENTBONUSBYSGK"]; }
            set { this["RETIREMENTBONUSBYSGK"] = value; }
        }

    /// <summary>
    /// SGK Ek Ödeme
    /// </summary>
        public bool? SupplementaryPaymentSGK
        {
            get { return (bool?)this["SUPPLEMENTARYPAYMENTSGK"]; }
            set { this["SUPPLEMENTARYPAYMENTSGK"] = value; }
        }

    /// <summary>
    /// SGK Öğrenim Yardımı
    /// </summary>
        public bool? EducationAidBySGK
        {
            get { return (bool?)this["EDUCATIONAIDBYSGK"]; }
            set { this["EDUCATIONAIDBYSGK"] = value; }
        }

    /// <summary>
    /// ASPB Tarafından İş Hakkı Verilmesi
    /// </summary>
        public bool? GrantingEmploymentRights
        {
            get { return (bool?)this["GRANTINGEMPLOYMENTRIGHTS"]; }
            set { this["GRANTINGEMPLOYMENTRIGHTS"] = value; }
        }

    /// <summary>
    /// ASPB Gazi Kartı Verilmesi
    /// </summary>
        public bool? ProvidingWarVeteranCard
        {
            get { return (bool?)this["PROVIDINGWARVETERANCARD"]; }
            set { this["PROVIDINGWARVETERANCARD"] = value; }
        }

    /// <summary>
    /// Kamu Konutlarından Yararlanma ve Kira Yardımı
    /// </summary>
        public bool? UtilizationOfPublicHousing
        {
            get { return (bool?)this["UTILIZATIONOFPUBLICHOUSING"]; }
            set { this["UTILIZATIONOFPUBLICHOUSING"] = value; }
        }

    /// <summary>
    /// Görevdeki Malul Personele Konut Tahsis Edilmesi
    /// </summary>
        public bool? ProvideHouseToDisabledStaff
        {
            get { return (bool?)this["PROVIDEHOUSETODISABLEDSTAFF"]; }
            set { this["PROVIDEHOUSETODISABLEDSTAFF"] = value; }
        }

    /// <summary>
    /// Toplu Konut Kredisi Verilmesi
    /// </summary>
        public bool? GivingCorporateHousingCredit
        {
            get { return (bool?)this["GIVINGCORPORATEHOUSINGCREDIT"]; }
            set { this["GIVINGCORPORATEHOUSINGCREDIT"] = value; }
        }

    /// <summary>
    /// TOKİ Konutlarından Faydalanma Hakkı
    /// </summary>
        public bool? UsageRightFromTOKIHouses
        {
            get { return (bool?)this["USAGERIGHTFROMTOKIHOUSES"]; }
            set { this["USAGERIGHTFROMTOKIHOUSES"] = value; }
        }

    /// <summary>
    /// Gelir Vergisi İndirimi
    /// </summary>
        public bool? IncomeTaxDiscount
        {
            get { return (bool?)this["INCOMETAXDISCOUNT"]; }
            set { this["INCOMETAXDISCOUNT"] = value; }
        }

    /// <summary>
    /// Mesken Vergisi Muafiyeti
    /// </summary>
        public bool? ResidenceTaxExemption
        {
            get { return (bool?)this["RESIDENCETAXEXEMPTION"]; }
            set { this["RESIDENCETAXEXEMPTION"] = value; }
        }

    /// <summary>
    /// Elektrik ve Su İndirimi
    /// </summary>
        public bool? ElectricAndWaterDiscount
        {
            get { return (bool?)this["ELECTRICANDWATERDISCOUNT"]; }
            set { this["ELECTRICANDWATERDISCOUNT"] = value; }
        }

    /// <summary>
    /// Gümrüksüz Araç İthal Edilmesi
    /// </summary>
        public bool? ImportingDutyFreeVehicle
        {
            get { return (bool?)this["IMPORTINGDUTYFREEVEHICLE"]; }
            set { this["IMPORTINGDUTYFREEVEHICLE"] = value; }
        }

    /// <summary>
    /// Yurtiçi Araç Alımları
    /// </summary>
        public bool? DomesticVehiclePurchases
        {
            get { return (bool?)this["DOMESTICVEHICLEPURCHASES"]; }
            set { this["DOMESTICVEHICLEPURCHASES"] = value; }
        }

    /// <summary>
    /// ÖTV ve MTV Muafiyeti
    /// </summary>
        public bool? OTVandMTVExemption
        {
            get { return (bool?)this["OTVANDMTVEXEMPTION"]; }
            set { this["OTVANDMTVEXEMPTION"] = value; }
        }

    /// <summary>
    /// Malulün Sonraki Kardeşinin XXXXXXlikten Muafiyeti
    /// </summary>
        public bool? BrotherExemptionFromMilitary
        {
            get { return (bool?)this["BROTHEREXEMPTIONFROMMILITARY"]; }
            set { this["BROTHEREXEMPTIONFROMMILITARY"] = value; }
        }

    /// <summary>
    /// Malul Kardeşlerin İkametine Yakın XXXXXXlik Yapması
    /// </summary>
        public bool? MilitaryServiceNearBrotherHom
        {
            get { return (bool?)this["MILITARYSERVICENEARBROTHERHOM"]; }
            set { this["MILITARYSERVICENEARBROTHERHOM"] = value; }
        }

    /// <summary>
    /// Özel Eğitim Kurumlarından Ücretsiz Yararlanma
    /// </summary>
        public bool? FreeAccessToPrivateEduInstit
        {
            get { return (bool?)this["FREEACCESSTOPRIVATEEDUINSTIT"]; }
            set { this["FREEACCESSTOPRIVATEEDUINSTIT"] = value; }
        }

    /// <summary>
    /// Silah Bulundurma Taşıma Ruhsatı
    /// </summary>
        public bool? WeaponPortageTransportLicense
        {
            get { return (bool?)this["WEAPONPORTAGETRANSPORTLICENSE"]; }
            set { this["WEAPONPORTAGETRANSPORTLICENSE"] = value; }
        }

    /// <summary>
    /// Hasta ve Yakınlarına Kalacak Yer Temini
    /// </summary>
        public string ProvidingAccomodationInfo
        {
            get { return (string)this["PROVIDINGACCOMODATIONINFO"]; }
            set { this["PROVIDINGACCOMODATIONINFO"] = value; }
        }

    /// <summary>
    /// İç Güvenlik Yaralı Durum Belgesi Temini
    /// </summary>
        public string ProvideInterSecInjStatDocInfo
        {
            get { return (string)this["PROVIDEINTERSECINJSTATDOCINFO"]; }
            set { this["PROVIDEINTERSECINJSTATDOCINFO"] = value; }
        }

    /// <summary>
    /// Provizyon Sorunları
    /// </summary>
        public string ProvisionIssuesInfo
        {
            get { return (string)this["PROVISIONISSUESINFO"]; }
            set { this["PROVISIONISSUESINFO"] = value; }
        }

    /// <summary>
    /// Haftalık Ekip Toplantıları
    /// </summary>
        public string WeeklyTeamMeetingsInfo
        {
            get { return (string)this["WEEKLYTEAMMEETINGSINFO"]; }
            set { this["WEEKLYTEAMMEETINGSINFO"] = value; }
        }

    /// <summary>
    /// Haftalık Vizite Katılım
    /// </summary>
        public string WeeklyVisitAttendenceInfo
        {
            get { return (string)this["WEEKLYVISITATTENDENCEINFO"]; }
            set { this["WEEKLYVISITATTENDENCEINFO"] = value; }
        }

    /// <summary>
    /// İstirahat Süreçlerinin Hesaplanması ve Takibi
    /// </summary>
        public string CalcAndFollowRestProcInfo
        {
            get { return (string)this["CALCANDFOLLOWRESTPROCINFO"]; }
            set { this["CALCANDFOLLOWRESTPROCINFO"] = value; }
        }

    /// <summary>
    /// Emeklilik Süreci Bilgilendirme ve Yönlendirme
    /// </summary>
        public string InformAndDirectRetireProcInfo
        {
            get { return (string)this["INFORMANDDIRECTRETIREPROCINFO"]; }
            set { this["INFORMANDDIRECTRETIREPROCINFO"] = value; }
        }

    /// <summary>
    /// Malzeme Prosedürü-Geri Ödeme,Bilgilendirme,Temini
    /// </summary>
        public string MedicEqProcRefundInfoProcInfo
        {
            get { return (string)this["MEDICEQPROCREFUNDINFOPROCINFO"]; }
            set { this["MEDICEQPROCREFUNDINFOPROCINFO"] = value; }
        }

    /// <summary>
    /// Bağış Tıbbi Malzeme Temini
    /// </summary>
        public string DonatedMedicalSupplyProcInfo
        {
            get { return (string)this["DONATEDMEDICALSUPPLYPROCINFO"]; }
            set { this["DONATEDMEDICALSUPPLYPROCINFO"] = value; }
        }

    /// <summary>
    /// Yurtdışı İlaç Teminiyle İlgili Yönlendirme
    /// </summary>
        public string GuidanceDrugSupplyAbroadInfo
        {
            get { return (string)this["GUIDANCEDRUGSUPPLYABROADINFO"]; }
            set { this["GUIDANCEDRUGSUPPLYABROADINFO"] = value; }
        }

    /// <summary>
    /// Sivil Toplum Örgütlerine Yönlendirme
    /// </summary>
        public string GuidanceToCivilOrganizatInfo
        {
            get { return (string)this["GUIDANCETOCIVILORGANIZATINFO"]; }
            set { this["GUIDANCETOCIVILORGANIZATINFO"] = value; }
        }

    /// <summary>
    /// Sosyal Yardımlaşma ve Dayanışma Vakfı Yönlendirme
    /// </summary>
        public string GuidanceToFoundationsInfo
        {
            get { return (string)this["GUIDANCETOFOUNDATIONSINFO"]; }
            set { this["GUIDANCETOFOUNDATIONSINFO"] = value; }
        }

    /// <summary>
    /// Bağışlardan Yararlandırma
    /// </summary>
        public string BenefitingFromDonationsInfo
        {
            get { return (string)this["BENEFITINGFROMDONATIONSINFO"]; }
            set { this["BENEFITINGFROMDONATIONSINFO"] = value; }
        }

    /// <summary>
    /// Bakım Maaşı ile İlgili Yönlendirme
    /// </summary>
        public string GuidanceAboutCareSalaryInfo
        {
            get { return (string)this["GUIDANCEABOUTCARESALARYINFO"]; }
            set { this["GUIDANCEABOUTCARESALARYINFO"] = value; }
        }

    /// <summary>
    /// 2022 Sayılı Yasa ile İlgili Yönlendirme
    /// </summary>
        public string GuidanceAboutLawInfo
        {
            get { return (string)this["GUIDANCEABOUTLAWINFO"]; }
            set { this["GUIDANCEABOUTLAWINFO"] = value; }
        }

    /// <summary>
    /// Evde Sağlık Hizmetleri ile İlgili Yönlendirme
    /// </summary>
        public string GuidanceAboutHomeHealthCrInfo
        {
            get { return (string)this["GUIDANCEABOUTHOMEHEALTHCRINFO"]; }
            set { this["GUIDANCEABOUTHOMEHEALTHCRINFO"] = value; }
        }

    /// <summary>
    /// Kamu Kurum/Kuruluşlarına Yapılan Telefon Görüşmesi
    /// </summary>
        public string PhoneCallWitPublicInstitInfo
        {
            get { return (string)this["PHONECALLWITPUBLICINSTITINFO"]; }
            set { this["PHONECALLWITPUBLICINSTITINFO"] = value; }
        }

    /// <summary>
    /// İlgili Mevzuatın İncelenmesi ve Bilgilendirme
    /// </summary>
        public string LegislativeReviewAndInfoInfo
        {
            get { return (string)this["LEGISLATIVEREVIEWANDINFOINFO"]; }
            set { this["LEGISLATIVEREVIEWANDINFOINFO"] = value; }
        }

    /// <summary>
    /// Kamu Kurum/Kuruluşlarına Yönlendirme
    /// </summary>
        public string GuidanceToPublicInstitInfo
        {
            get { return (string)this["GUIDANCETOPUBLICINSTITINFO"]; }
            set { this["GUIDANCETOPUBLICINSTITINFO"] = value; }
        }

    /// <summary>
    /// XXXXXXdeki Gazi İrtibat Birimi ile Koordinasyon
    /// </summary>
        public string CoordWarVeteranContactUniInfo
        {
            get { return (string)this["COORDWARVETERANCONTACTUNIINFO"]; }
            set { this["COORDWARVETERANCONTACTUNIINFO"] = value; }
        }

    /// <summary>
    /// Yaşam Alanlarının Düzenlenmesi
    /// </summary>
        public string ArrangementOfLivingPlacesInfo
        {
            get { return (string)this["ARRANGEMENTOFLIVINGPLACESINFO"]; }
            set { this["ARRANGEMENTOFLIVINGPLACESINFO"] = value; }
        }

    /// <summary>
    /// İş Ortamının, Okul Ortamının Düzenlenmesi
    /// </summary>
        public string ArrangementOfWorkSchoolEnInfo
        {
            get { return (string)this["ARRANGEMENTOFWORKSCHOOLENINFO"]; }
            set { this["ARRANGEMENTOFWORKSCHOOLENINFO"] = value; }
        }

    /// <summary>
    /// Tedavi Sürecinde İl İçi Ulaşım İşlemleri
    /// </summary>
        public string IntraCityTransportProcessInfo
        {
            get { return (string)this["INTRACITYTRANSPORTPROCESSINFO"]; }
            set { this["INTRACITYTRANSPORTPROCESSINFO"] = value; }
        }

    /// <summary>
    /// Taburculuk Sırasında İl Dışı 112 Ambulans,uçak vb.
    /// </summary>
        public string InterCityTransportProcessInfo
        {
            get { return (string)this["INTERCITYTRANSPORTPROCESSINFO"]; }
            set { this["INTERCITYTRANSPORTPROCESSINFO"] = value; }
        }

    /// <summary>
    /// Faaliyetlerde Katılımcıların Belirlenmesi
    /// </summary>
        public string IdentificationOfParticipInfo
        {
            get { return (string)this["IDENTIFICATIONOFPARTICIPINFO"]; }
            set { this["IDENTIFICATIONOFPARTICIPINFO"] = value; }
        }

    /// <summary>
    /// XXXXXX Ali Çetinkaya İlk Kurşun Rehabilitasyon Merkezi'nden Yararlanma
    /// </summary>
        public bool? UtilityFromRehabilitationCent
        {
            get { return (bool?)this["UTILITYFROMREHABILITATIONCENT"]; }
            set { this["UTILITYFROMREHABILITATIONCENT"] = value; }
        }

    /// <summary>
    /// Milli Piyango İdaresi Genel Müdürlüğü'nce Bayilik Verilmesi
    /// </summary>
        public bool? GrantingDealership
        {
            get { return (bool?)this["GRANTINGDEALERSHIP"]; }
            set { this["GRANTINGDEALERSHIP"] = value; }
        }

    /// <summary>
    /// Açık Lise
    /// </summary>
        public string OpenEducationHighSchool
        {
            get { return (string)this["OPENEDUCATIONHIGHSCHOOL"]; }
            set { this["OPENEDUCATIONHIGHSCHOOL"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public string Other
        {
            get { return (string)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

    /// <summary>
    /// Telefonda Danışmanlık Hizmeti
    /// </summary>
        public string GuidanceServiceOnPhone
        {
            get { return (string)this["GUIDANCESERVICEONPHONE"]; }
            set { this["GUIDANCESERVICEONPHONE"] = value; }
        }

    /// <summary>
    /// Avans Ödemesi
    /// </summary>
        public string AdvancePaymentInfo
        {
            get { return (string)this["ADVANCEPAYMENTINFO"]; }
            set { this["ADVANCEPAYMENTINFO"] = value; }
        }

    /// <summary>
    /// Özel Harekat ve Operasyon Tazminatı
    /// </summary>
        public string IndemnityCompensationInfo
        {
            get { return (string)this["INDEMNITYCOMPENSATIONINFO"]; }
            set { this["INDEMNITYCOMPENSATIONINFO"] = value; }
        }

    /// <summary>
    /// İzin Belgelerinin Düzenlenmesi
    /// </summary>
        public string OrganizingPermitDocumentsInfo
        {
            get { return (string)this["ORGANIZINGPERMITDOCUMENTSINFO"]; }
            set { this["ORGANIZINGPERMITDOCUMENTSINFO"] = value; }
        }

    /// <summary>
    /// Sağlık Yardımı
    /// </summary>
        public string HealthAidInfo
        {
            get { return (string)this["HEALTHAIDINFO"]; }
            set { this["HEALTHAIDINFO"] = value; }
        }

    /// <summary>
    /// Harçlık Ödemesi
    /// </summary>
        public string AllowancePaymentInfo
        {
            get { return (string)this["ALLOWANCEPAYMENTINFO"]; }
            set { this["ALLOWANCEPAYMENTINFO"] = value; }
        }

    /// <summary>
    /// Gazilere Sağlanan Haklar Broşürünün Verilmesi
    /// </summary>
        public string GivingVeteranRightsBrocInfo
        {
            get { return (string)this["GIVINGVETERANRIGHTSBROCINFO"]; }
            set { this["GIVINGVETERANRIGHTSBROCINFO"] = value; }
        }

    /// <summary>
    /// Nakdi Tazminat İşlemleri
    /// </summary>
        public string CashIdemnityTransactionsInfo
        {
            get { return (string)this["CASHIDEMNITYTRANSACTIONSINFO"]; }
            set { this["CASHIDEMNITYTRANSACTIONSINFO"] = value; }
        }

    /// <summary>
    /// XXXXXX Dayanışma Vakfı Yardımı
    /// </summary>
        public string XXXXXXSolidarityFoundatioAidInfo
        {
            get { return (string)this["XXXXXXSOLIDARITYFOUNDATIOAIDINFO"]; }
            set { this["XXXXXXSOLIDARITYFOUNDATIOAIDINFO"] = value; }
        }

    /// <summary>
    /// Mehmetçik Vakfı Yardımları
    /// </summary>
        public string SoldierFoundationAidInfo
        {
            get { return (string)this["SOLDIERFOUNDATIONAIDINFO"]; }
            set { this["SOLDIERFOUNDATIONAIDINFO"] = value; }
        }

    /// <summary>
    /// Mehmetçik Yaşam Sigortası
    /// </summary>
        public string SoldierLifeInsuranceInfo
        {
            get { return (string)this["SOLDIERLIFEINSURANCEINFO"]; }
            set { this["SOLDIERLIFEINSURANCEINFO"] = value; }
        }

    /// <summary>
    /// OYAK Yardımı
    /// </summary>
        public string OYAKAidInfo
        {
            get { return (string)this["OYAKAIDINFO"]; }
            set { this["OYAKAIDINFO"] = value; }
        }

    /// <summary>
    /// Göreve Devam Etme Durumu
    /// </summary>
        public string JobResumeStatusInfo
        {
            get { return (string)this["JOBRESUMESTATUSINFO"]; }
            set { this["JOBRESUMESTATUSINFO"] = value; }
        }

    /// <summary>
    /// Devlet Ödünç Madalyası, Malul Gazi Rozeti
    /// </summary>
        public string StatePrideMedalInfo
        {
            get { return (string)this["STATEPRIDEMEDALINFO"]; }
            set { this["STATEPRIDEMEDALINFO"] = value; }
        }

    /// <summary>
    /// SGK Tarafından Maaş Bağlanması
    /// </summary>
        public string SalaryStartBySGKInfo
        {
            get { return (string)this["SALARYSTARTBYSGKINFO"]; }
            set { this["SALARYSTARTBYSGKINFO"] = value; }
        }

    /// <summary>
    /// SGK Tarafından Emekli İkramiyesi Verilmesi
    /// </summary>
        public string RetirementBonusBySGKInfo
        {
            get { return (string)this["RETIREMENTBONUSBYSGKINFO"]; }
            set { this["RETIREMENTBONUSBYSGKINFO"] = value; }
        }

    /// <summary>
    /// SGK Ek Ödeme
    /// </summary>
        public string SupplementaryPaymentSGKInfo
        {
            get { return (string)this["SUPPLEMENTARYPAYMENTSGKINFO"]; }
            set { this["SUPPLEMENTARYPAYMENTSGKINFO"] = value; }
        }

    /// <summary>
    /// SGK Öğrenim Yardımı
    /// </summary>
        public string EducationAidBySGKInfo
        {
            get { return (string)this["EDUCATIONAIDBYSGKINFO"]; }
            set { this["EDUCATIONAIDBYSGKINFO"] = value; }
        }

    /// <summary>
    /// ASPB Tarafından İş Hakkı Verilmesi
    /// </summary>
        public string GrantingEmploymentRightsInfo
        {
            get { return (string)this["GRANTINGEMPLOYMENTRIGHTSINFO"]; }
            set { this["GRANTINGEMPLOYMENTRIGHTSINFO"] = value; }
        }

    /// <summary>
    /// ASPB Gazi Kartı Verilmesi
    /// </summary>
        public string ProvidingWarVeteranCardInfo
        {
            get { return (string)this["PROVIDINGWARVETERANCARDINFO"]; }
            set { this["PROVIDINGWARVETERANCARDINFO"] = value; }
        }

    /// <summary>
    /// Kamu Konutlarından Yararlanma ve Kira Yardımı
    /// </summary>
        public string UtilizationOfPublicHousinInfo
        {
            get { return (string)this["UTILIZATIONOFPUBLICHOUSININFO"]; }
            set { this["UTILIZATIONOFPUBLICHOUSININFO"] = value; }
        }

    /// <summary>
    /// Görevdeki Malul Personele Konut Tahsis Edilmesi
    /// </summary>
        public string ProvideHouseToDisablStaffInfo
        {
            get { return (string)this["PROVIDEHOUSETODISABLSTAFFINFO"]; }
            set { this["PROVIDEHOUSETODISABLSTAFFINFO"] = value; }
        }

    /// <summary>
    /// Toplu Konut Kredisi Verilmesi
    /// </summary>
        public string GivingCorporateHousCreditInfo
        {
            get { return (string)this["GIVINGCORPORATEHOUSCREDITINFO"]; }
            set { this["GIVINGCORPORATEHOUSCREDITINFO"] = value; }
        }

    /// <summary>
    /// TOKİ Konutlarından Faydalanma Hakkı
    /// </summary>
        public string UsageRightFromTOKIHousesInfo
        {
            get { return (string)this["USAGERIGHTFROMTOKIHOUSESINFO"]; }
            set { this["USAGERIGHTFROMTOKIHOUSESINFO"] = value; }
        }

    /// <summary>
    /// Gelir Vergisi İndirimi
    /// </summary>
        public string IncomeTaxDiscountInfo
        {
            get { return (string)this["INCOMETAXDISCOUNTINFO"]; }
            set { this["INCOMETAXDISCOUNTINFO"] = value; }
        }

    /// <summary>
    /// Mesken Vergisi Muafiyeti
    /// </summary>
        public string ResidenceTaxExemptionInfo
        {
            get { return (string)this["RESIDENCETAXEXEMPTIONINFO"]; }
            set { this["RESIDENCETAXEXEMPTIONINFO"] = value; }
        }

    /// <summary>
    /// Elektrik ve Su İndirimi
    /// </summary>
        public string ElectricAndWaterDiscountInfo
        {
            get { return (string)this["ELECTRICANDWATERDISCOUNTINFO"]; }
            set { this["ELECTRICANDWATERDISCOUNTINFO"] = value; }
        }

    /// <summary>
    /// Gümrüksüz Araç İthal Edilmesi
    /// </summary>
        public string ImportingDutyFreeVehicleInfo
        {
            get { return (string)this["IMPORTINGDUTYFREEVEHICLEINFO"]; }
            set { this["IMPORTINGDUTYFREEVEHICLEINFO"] = value; }
        }

    /// <summary>
    /// Yurtiçi Araç Alımları
    /// </summary>
        public string DomesticVehiclePurchasesInfo
        {
            get { return (string)this["DOMESTICVEHICLEPURCHASESINFO"]; }
            set { this["DOMESTICVEHICLEPURCHASESINFO"] = value; }
        }

    /// <summary>
    /// ÖTV ve MTV Muafiyeti
    /// </summary>
        public string OTVandMTVExemptionInfo
        {
            get { return (string)this["OTVANDMTVEXEMPTIONINFO"]; }
            set { this["OTVANDMTVEXEMPTIONINFO"] = value; }
        }

    /// <summary>
    /// Malulün Sonraki Kardeşinin XXXXXXlikten Muafiyeti
    /// </summary>
        public string BrotherExemptionFromMilitInfo
        {
            get { return (string)this["BROTHEREXEMPTIONFROMMILITINFO"]; }
            set { this["BROTHEREXEMPTIONFROMMILITINFO"] = value; }
        }

    /// <summary>
    /// Malul Kardeşlerin İkametine Yakın XXXXXXlik Yapması
    /// </summary>
        public string MilitarServNearBrotherHomInfo
        {
            get { return (string)this["MILITARSERVNEARBROTHERHOMINFO"]; }
            set { this["MILITARSERVNEARBROTHERHOMINFO"] = value; }
        }

    /// <summary>
    /// Özel Eğitim Kurumlarından Ücretsiz Yararlanma
    /// </summary>
        public string FreeAccessToPrivEduInstitInfo
        {
            get { return (string)this["FREEACCESSTOPRIVEDUINSTITINFO"]; }
            set { this["FREEACCESSTOPRIVEDUINSTITINFO"] = value; }
        }

    /// <summary>
    /// Silah Bulundurma Taşıma Ruhsatı
    /// </summary>
        public string WeaponPortageTransportLicInfo
        {
            get { return (string)this["WEAPONPORTAGETRANSPORTLICINFO"]; }
            set { this["WEAPONPORTAGETRANSPORTLICINFO"] = value; }
        }

    /// <summary>
    /// XXXXXX Ali Çetinkaya İlk Kurşun Rehabilitasyon Merkezi'nden Yararlanma
    /// </summary>
        public string UtilityFromRehabilitCentInfo
        {
            get { return (string)this["UTILITYFROMREHABILITCENTINFO"]; }
            set { this["UTILITYFROMREHABILITCENTINFO"] = value; }
        }

    /// <summary>
    /// Milli Piyango İdaresi Genel Müdürlüğü'nce Bayilik Verilmesi
    /// </summary>
        public string GrantingDealershipInfo
        {
            get { return (string)this["GRANTINGDEALERSHIPINFO"]; }
            set { this["GRANTINGDEALERSHIPINFO"] = value; }
        }

    /// <summary>
    /// Mesleki Rehabilitasyona Yönlendirme
    /// </summary>
        public string VocationalRehabilitationInfo
        {
            get { return (string)this["VOCATIONALREHABILITATIONINFO"]; }
            set { this["VOCATIONALREHABILITATIONINFO"] = value; }
        }

    /// <summary>
    /// Mesleki Rehabilitasyona Yönlendirme
    /// </summary>
        public bool? VocationalRehabilitation
        {
            get { return (bool?)this["VOCATIONALREHABILITATION"]; }
            set { this["VOCATIONALREHABILITATION"] = value; }
        }

        virtual protected void CreatePatientInterviewFormCollection()
        {
            _PatientInterviewForm = new PatientInterviewForm.ChildPatientInterviewFormCollection(this, new Guid("f2e270bc-3b13-4f2f-8a35-45dc3a3979c9"));
            ((ITTChildObjectCollection)_PatientInterviewForm).GetChildren();
        }

        protected PatientInterviewForm.ChildPatientInterviewFormCollection _PatientInterviewForm = null;
        public PatientInterviewForm.ChildPatientInterviewFormCollection PatientInterviewForm
        {
            get
            {
                if (_PatientInterviewForm == null)
                    CreatePatientInterviewFormCollection();
                return _PatientInterviewForm;
            }
        }

        protected SocServAppliedProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SocServAppliedProcedures(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SocServAppliedProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SocServAppliedProcedures(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SocServAppliedProcedures(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOCSERVAPPLIEDPROCEDURES", dataRow) { }
        protected SocServAppliedProcedures(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOCSERVAPPLIEDPROCEDURES", dataRow, isImported) { }
        public SocServAppliedProcedures(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SocServAppliedProcedures(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SocServAppliedProcedures() : base() { }

    }
}