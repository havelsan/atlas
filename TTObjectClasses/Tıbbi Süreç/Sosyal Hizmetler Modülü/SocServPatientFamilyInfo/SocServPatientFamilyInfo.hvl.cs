
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SocServPatientFamilyInfo")] 

    /// <summary>
    /// Sosyal Hizmetler Hasta-Aile Bilgi Formu
    /// </summary>
    public  partial class SocServPatientFamilyInfo : TTObject
    {
        public class SocServPatientFamilyInfoList : TTObjectCollection<SocServPatientFamilyInfo> { }
                    
        public class ChildSocServPatientFamilyInfoCollection : TTObject.TTChildObjectCollection<SocServPatientFamilyInfo>
        {
            public ChildSocServPatientFamilyInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSocServPatientFamilyInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSocServPatientFamilyInfo_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public string Roomname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["EXAMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Procedurebyusername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaritalStatusEnum? MaritalStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARITALSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["MARITALSTATUS"].DataType;
                    return (MaritalStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PatientAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientPhoneNum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPHONENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTINTERVIEWFORM"].AllPropertyDefs["PATIENTPHONENUM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Educationstatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EDUCATIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSOGRENIMDURUMU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

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

            public string SickOrInjuredPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICKORINJUREDPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SICKORINJUREDPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SickOrInjuryType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICKORINJURYTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SICKORINJURYTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SickOrInjuryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SICKORINJURYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SICKORINJURYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ShortEventStory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTEVENTSTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SHORTEVENTSTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AuxiliaryToolWheelchair
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLWHEELCHAIR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLWHEELCHAIR"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AuxiliaryToolWalker
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLWALKER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLWALKER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AuxiliaryToolAfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLAFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLAFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public LivingHouseTypeEnum? LivingHouseBelonging
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSEBELONGING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSEBELONGING"].DataType;
                    return (LivingHouseTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DoorEntranceTypesEnum? LivingHouseDoorEntrance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSEDOORENTRANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSEDOORENTRANCE"].DataType;
                    return (DoorEntranceTypesEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public WCTypeEnum? LivingHouseWcType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSEWCTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSEWCTYPE"].DataType;
                    return (WCTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LivingHouseBelongingInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSEBELONGINGINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSEBELONGINGINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FamilyIncomings
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYINCOMINGS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["FAMILYINCOMINGS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SocioEconomicInfoEvaluation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOCIOECONOMICINFOEVALUATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SOCIOECONOMICINFOEVALUATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TransportationArrival
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSPORTATIONARRIVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["TRANSPORTATIONARRIVAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TransportationGoing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSPORTATIONGOING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["TRANSPORTATIONGOING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TransportationEvaluation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSPORTATIONEVALUATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["TRANSPORTATIONEVALUATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FamilyInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["FAMILYINFORMATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FamilyInformationEvaluation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYINFORMATIONEVALUATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["FAMILYINFORMATIONEVALUATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhysicalStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["PHYSICALSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientRelatedWorks
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTRELATEDWORKS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["PATIENTRELATEDWORKS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SubHeaders
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBHEADERS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SUBHEADERS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AuxiliaryToolHandSplint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLHANDSPLINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLHANDSPLINT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AuxiliaryToolTripod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLTRIPOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLTRIPOD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AuxiliaryToolArmRest
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLARMREST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLARMREST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AuxiliaryToolOther
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLOTHER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLOTHER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string AuxiliaryToolOtherInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUXILIARYTOOLOTHERINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["AUXILIARYTOOLOTHERINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WrittenMedicalMaterialOrTool
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WRITTENMEDICALMATERIALORTOOL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["WRITTENMEDICALMATERIALORTOOL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RestState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESTSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["RESTSTATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CompanionPhoneNum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANIONPHONENUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["COMPANIONPHONENUM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientLivesWith
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTLIVESWITH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["PATIENTLIVESWITH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EmploymentRecordId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMPLOYMENTRECORDID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PreviousJobBeforeIll
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREVIOUSJOBBEFOREILL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["PREVIOUSJOBBEFOREILL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfStart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFSTART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["DATEOFSTART"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DateOfRetire
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATEOFRETIRE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["DATEOFRETIRE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string JobRightUseStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOBRIGHTUSESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["JOBRIGHTUSESTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string WorkPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["WORKPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LongTermArmBonusInterrupt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LONGTERMARMBONUSINTERRUPT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LONGTERMARMBONUSINTERRUPT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SoldierRank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLDIERRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SOLDIERRANK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SoldierPlaceOfWork
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOLDIERPLACEOFWORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SOLDIERPLACEOFWORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SecondRetirementStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDRETIREMENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["SECONDRETIREMENTSTATUS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Evaluation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVALUATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["EVALUATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? JobMilitaryServStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOBMILITARYSERVSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["JOBMILITARYSERVSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? MilitaryServiceEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYSERVICEENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["MILITARYSERVICEENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RecruitmentOffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECRUITMENTOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["RECRUITMENTOFFICE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApplicationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExactTransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXACTTRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["EXACTTRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Companion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPANION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["COMPANION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LivingHouseType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSETYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? LivingHouseNumOfFloor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSENUMOFFLOOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSENUMOFFLOOR"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public VarYokEnum? LivingHouseElevator
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSEELEVATOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSEELEVATOR"].DataType;
                    return (VarYokEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? LivingHouseBasement
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSEBASEMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSEBASEMENT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LivingHouseEntrance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVINGHOUSEENTRANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["LIVINGHOUSEENTRANCE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PatientDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["PATIENTDIAGNOSIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatientPayerName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["PATIENTPAYERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DegreeOfWarVeteran
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEGREEOFWARVETERAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].AllPropertyDefs["DEGREEOFWARVETERAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSocServPatientFamilyInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSocServPatientFamilyInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSocServPatientFamilyInfo_Class() : base() { }
        }

    /// <summary>
    /// Sosyal Hizmetler Hasta Aile Bilgi Formu
    /// </summary>
        public static BindingList<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class> GetSocServPatientFamilyInfo(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].QueryDefs["GetSocServPatientFamilyInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Sosyal Hizmetler Hasta Aile Bilgi Formu
    /// </summary>
        public static BindingList<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class> GetSocServPatientFamilyInfo(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SOCSERVPATIENTFAMILYINFO"].QueryDefs["GetSocServPatientFamilyInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<SocServPatientFamilyInfo.GetSocServPatientFamilyInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hastalık/Yaralanma Durumu - Hastalandığı/Yaralandığı Yer
    /// </summary>
        public string SickOrInjuredPlace
        {
            get { return (string)this["SICKORINJUREDPLACE"]; }
            set { this["SICKORINJUREDPLACE"] = value; }
        }

    /// <summary>
    /// Hastalık/Yaralanma Durumu - Hastalanma/Yaralanma Şekli
    /// </summary>
        public string SickOrInjuryType
        {
            get { return (string)this["SICKORINJURYTYPE"]; }
            set { this["SICKORINJURYTYPE"] = value; }
        }

    /// <summary>
    /// Hastalık/Yaralanma Durumu - Hastalanma/Yaralanma Tarihi
    /// </summary>
        public DateTime? SickOrInjuryDate
        {
            get { return (DateTime?)this["SICKORINJURYDATE"]; }
            set { this["SICKORINJURYDATE"] = value; }
        }

    /// <summary>
    /// Hastalık/Yaralanma Durumu - Kısaca Olay Hikayesi
    /// </summary>
        public string ShortEventStory
        {
            get { return (string)this["SHORTEVENTSTORY"]; }
            set { this["SHORTEVENTSTORY"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Tekerlekli Sandalye
    /// </summary>
        public bool? AuxiliaryToolWheelchair
        {
            get { return (bool?)this["AUXILIARYTOOLWHEELCHAIR"]; }
            set { this["AUXILIARYTOOLWHEELCHAIR"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Walker
    /// </summary>
        public bool? AuxiliaryToolWalker
        {
            get { return (bool?)this["AUXILIARYTOOLWALKER"]; }
            set { this["AUXILIARYTOOLWALKER"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Afo
    /// </summary>
        public bool? AuxiliaryToolAfo
        {
            get { return (bool?)this["AUXILIARYTOOLAFO"]; }
            set { this["AUXILIARYTOOLAFO"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği Ev Kime ait
    /// </summary>
        public LivingHouseTypeEnum? LivingHouseBelonging
        {
            get { return (LivingHouseTypeEnum?)(int?)this["LIVINGHOUSEBELONGING"]; }
            set { this["LIVINGHOUSEBELONGING"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - Kapı Girişleri
    /// </summary>
        public DoorEntranceTypesEnum? LivingHouseDoorEntrance
        {
            get { return (DoorEntranceTypesEnum?)(int?)this["LIVINGHOUSEDOORENTRANCE"]; }
            set { this["LIVINGHOUSEDOORENTRANCE"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - WC
    /// </summary>
        public WCTypeEnum? LivingHouseWcType
        {
            get { return (WCTypeEnum?)(int?)this["LIVINGHOUSEWCTYPE"]; }
            set { this["LIVINGHOUSEWCTYPE"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - Açıklama
    /// </summary>
        public string LivingHouseBelongingInfo
        {
            get { return (string)this["LIVINGHOUSEBELONGINGINFO"]; }
            set { this["LIVINGHOUSEBELONGINGINFO"] = value; }
        }

    /// <summary>
    /// Sosyo-Ekonomik Bilgiler - Ailenin Gelir Kaynakları
    /// </summary>
        public string FamilyIncomings
        {
            get { return (string)this["FAMILYINCOMINGS"]; }
            set { this["FAMILYINCOMINGS"] = value; }
        }

    /// <summary>
    /// Sosyo Ekonomik Bilgiler - Sosyal Hizmet Uzmanı Değerlendirmesi
    /// </summary>
        public string SocioEconomicInfoEvaluation
        {
            get { return (string)this["SOCIOECONOMICINFOEVALUATION"]; }
            set { this["SOCIOECONOMICINFOEVALUATION"] = value; }
        }

    /// <summary>
    /// Ulaşım Değerlendirme - Geliş
    /// </summary>
        public string TransportationArrival
        {
            get { return (string)this["TRANSPORTATIONARRIVAL"]; }
            set { this["TRANSPORTATIONARRIVAL"] = value; }
        }

    /// <summary>
    /// Ulaşım Değerlendirme - Gidiş
    /// </summary>
        public string TransportationGoing
        {
            get { return (string)this["TRANSPORTATIONGOING"]; }
            set { this["TRANSPORTATIONGOING"] = value; }
        }

    /// <summary>
    /// Ulaşım Değerlendirme - Sosyal Hizmet Uzmanı Değerlendirmesi
    /// </summary>
        public string TransportationEvaluation
        {
            get { return (string)this["TRANSPORTATIONEVALUATION"]; }
            set { this["TRANSPORTATIONEVALUATION"] = value; }
        }

    /// <summary>
    /// Aile Bilgileri
    /// </summary>
        public string FamilyInformation
        {
            get { return (string)this["FAMILYINFORMATION"]; }
            set { this["FAMILYINFORMATION"] = value; }
        }

    /// <summary>
    /// Aile Bilgileri - Sosyal Hizmet Uzmanı Değerlendirmesi
    /// </summary>
        public string FamilyInformationEvaluation
        {
            get { return (string)this["FAMILYINFORMATIONEVALUATION"]; }
            set { this["FAMILYINFORMATIONEVALUATION"] = value; }
        }

    /// <summary>
    /// Fiziksel Durum
    /// </summary>
        public string PhysicalStatus
        {
            get { return (string)this["PHYSICALSTATUS"]; }
            set { this["PHYSICALSTATUS"] = value; }
        }

    /// <summary>
    /// Hastayla İlgili Yapılan İşler - Klinik İzlem
    /// </summary>
        public string PatientRelatedWorks
        {
            get { return (string)this["PATIENTRELATEDWORKS"]; }
            set { this["PATIENTRELATEDWORKS"] = value; }
        }

    /// <summary>
    /// Alt Başlıklar
    /// </summary>
        public string SubHeaders
        {
            get { return (string)this["SUBHEADERS"]; }
            set { this["SUBHEADERS"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - El Splinti
    /// </summary>
        public bool? AuxiliaryToolHandSplint
        {
            get { return (bool?)this["AUXILIARYTOOLHANDSPLINT"]; }
            set { this["AUXILIARYTOOLHANDSPLINT"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Tripot
    /// </summary>
        public bool? AuxiliaryToolTripod
        {
            get { return (bool?)this["AUXILIARYTOOLTRIPOD"]; }
            set { this["AUXILIARYTOOLTRIPOD"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Koltuk Değneği
    /// </summary>
        public bool? AuxiliaryToolArmRest
        {
            get { return (bool?)this["AUXILIARYTOOLARMREST"]; }
            set { this["AUXILIARYTOOLARMREST"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Diğer
    /// </summary>
        public bool? AuxiliaryToolOther
        {
            get { return (bool?)this["AUXILIARYTOOLOTHER"]; }
            set { this["AUXILIARYTOOLOTHER"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Diğer RTF
    /// </summary>
        public string AuxiliaryToolOtherInfo
        {
            get { return (string)this["AUXILIARYTOOLOTHERINFO"]; }
            set { this["AUXILIARYTOOLOTHERINFO"] = value; }
        }

    /// <summary>
    /// Kullanılan Yardımcı Cihazlar - Yazılan Tıbbi Malzeme/Cihaz
    /// </summary>
        public string WrittenMedicalMaterialOrTool
        {
            get { return (string)this["WRITTENMEDICALMATERIALORTOOL"]; }
            set { this["WRITTENMEDICALMATERIALORTOOL"] = value; }
        }

    /// <summary>
    /// Hava Değişimi/İstirahat Durumu
    /// </summary>
        public string RestState
        {
            get { return (string)this["RESTSTATE"]; }
            set { this["RESTSTATE"] = value; }
        }

    /// <summary>
    /// Refakatçi Telefon Numarası
    /// </summary>
        public string CompanionPhoneNum
        {
            get { return (string)this["COMPANIONPHONENUM"]; }
            set { this["COMPANIONPHONENUM"] = value; }
        }

    /// <summary>
    /// Hasta Kiminle Yaşıyor
    /// </summary>
        public string PatientLivesWith
        {
            get { return (string)this["PATIENTLIVESWITH"]; }
            set { this["PATIENTLIVESWITH"] = value; }
        }

    /// <summary>
    /// Emekli Sandığı Sicil No
    /// </summary>
        public string EmploymentRecordId
        {
            get { return (string)this["EMPLOYMENTRECORDID"]; }
            set { this["EMPLOYMENTRECORDID"] = value; }
        }

    /// <summary>
    /// İş/Emeklilik Bilgileri - Hastalanmadan Önce ne İş Yapıyordu?
    /// </summary>
        public string PreviousJobBeforeIll
        {
            get { return (string)this["PREVIOUSJOBBEFOREILL"]; }
            set { this["PREVIOUSJOBBEFOREILL"] = value; }
        }

    /// <summary>
    /// İş/Emeklilik Bilgileri - İşe Başlama Tarihi
    /// </summary>
        public DateTime? DateOfStart
        {
            get { return (DateTime?)this["DATEOFSTART"]; }
            set { this["DATEOFSTART"] = value; }
        }

    /// <summary>
    /// İş/Emeklilik Bilgileri - Emeklilik Tarihi
    /// </summary>
        public DateTime? DateOfRetire
        {
            get { return (DateTime?)this["DATEOFRETIRE"]; }
            set { this["DATEOFRETIRE"] = value; }
        }

    /// <summary>
    /// İş/Emeklilik Bilgileri - İş Hakkı Kullanma Durumu
    /// </summary>
        public string JobRightUseStatus
        {
            get { return (string)this["JOBRIGHTUSESTATUS"]; }
            set { this["JOBRIGHTUSESTATUS"] = value; }
        }

    /// <summary>
    /// İş/Emeklilik Bilgileri - Hastanın Çalıştığı Yer
    /// </summary>
        public string WorkPlace
        {
            get { return (string)this["WORKPLACE"]; }
            set { this["WORKPLACE"] = value; }
        }

    /// <summary>
    /// İş/Emeklilik Bilgileri - Uzun Vadeli Kollar Prim Kesinti Durumu
    /// </summary>
        public string LongTermArmBonusInterrupt
        {
            get { return (string)this["LONGTERMARMBONUSINTERRUPT"]; }
            set { this["LONGTERMARMBONUSINTERRUPT"] = value; }
        }

    /// <summary>
    /// Rütbe
    /// </summary>
        public string SoldierRank
        {
            get { return (string)this["SOLDIERRANK"]; }
            set { this["SOLDIERRANK"] = value; }
        }

    /// <summary>
    /// Görev Yeri
    /// </summary>
        public string SoldierPlaceOfWork
        {
            get { return (string)this["SOLDIERPLACEOFWORK"]; }
            set { this["SOLDIERPLACEOFWORK"] = value; }
        }

    /// <summary>
    /// İş/Emeklilik Bilgileri - 2. Emeklilik Durumu
    /// </summary>
        public string SecondRetirementStatus
        {
            get { return (string)this["SECONDRETIREMENTSTATUS"]; }
            set { this["SECONDRETIREMENTSTATUS"] = value; }
        }

    /// <summary>
    /// Sosyal Hizmet Uzmanı Değerlendirme
    /// </summary>
        public string Evaluation
        {
            get { return (string)this["EVALUATION"]; }
            set { this["EVALUATION"] = value; }
        }

    /// <summary>
    /// Yaralı/Hasta Bilgileri - İş/XXXXXXlik Başlangıç Tarihi
    /// </summary>
        public DateTime? JobMilitaryServStartDate
        {
            get { return (DateTime?)this["JOBMILITARYSERVSTARTDATE"]; }
            set { this["JOBMILITARYSERVSTARTDATE"] = value; }
        }

    /// <summary>
    /// Yaralı/Hasta Bilgileri - XXXXXXlik Bitiş Tarihi
    /// </summary>
        public DateTime? MilitaryServiceEndDate
        {
            get { return (DateTime?)this["MILITARYSERVICEENDDATE"]; }
            set { this["MILITARYSERVICEENDDATE"] = value; }
        }

    /// <summary>
    /// Yaralı/Hasta Bilgileri - XXXXXXlik Şubesi
    /// </summary>
        public string RecruitmentOffice
        {
            get { return (string)this["RECRUITMENTOFFICE"]; }
            set { this["RECRUITMENTOFFICE"] = value; }
        }

    /// <summary>
    /// Uygulama Tarihi
    /// </summary>
        public DateTime? ApplicationDate
        {
            get { return (DateTime?)this["APPLICATIONDATE"]; }
            set { this["APPLICATIONDATE"] = value; }
        }

    /// <summary>
    /// Yaralı/Hasta Bilgileri - Kesin İşlem Tarihi
    /// </summary>
        public DateTime? ExactTransactionDate
        {
            get { return (DateTime?)this["EXACTTRANSACTIONDATE"]; }
            set { this["EXACTTRANSACTIONDATE"] = value; }
        }

    /// <summary>
    /// Yaralı/Hasta Bilgileri - Refakatçisi
    /// </summary>
        public string Companion
        {
            get { return (string)this["COMPANION"]; }
            set { this["COMPANION"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - Ev Tipi
    /// </summary>
        public string LivingHouseType
        {
            get { return (string)this["LIVINGHOUSETYPE"]; }
            set { this["LIVINGHOUSETYPE"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - Kaçıncı Kat
    /// </summary>
        public int? LivingHouseNumOfFloor
        {
            get { return (int?)this["LIVINGHOUSENUMOFFLOOR"]; }
            set { this["LIVINGHOUSENUMOFFLOOR"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - Asansör
    /// </summary>
        public VarYokEnum? LivingHouseElevator
        {
            get { return (VarYokEnum?)(int?)this["LIVINGHOUSEELEVATOR"]; }
            set { this["LIVINGHOUSEELEVATOR"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - Basamak
    /// </summary>
        public int? LivingHouseBasement
        {
            get { return (int?)this["LIVINGHOUSEBASEMENT"]; }
            set { this["LIVINGHOUSEBASEMENT"] = value; }
        }

    /// <summary>
    /// Yaşanılan Ev Niteliği - Giriş
    /// </summary>
        public YesNoEnum? LivingHouseEntrance
        {
            get { return (YesNoEnum?)(int?)this["LIVINGHOUSEENTRANCE"]; }
            set { this["LIVINGHOUSEENTRANCE"] = value; }
        }

    /// <summary>
    /// Hasta-Aile Bilgi Formu Hastanın Tanıları
    /// </summary>
        public string PatientDiagnosis
        {
            get { return (string)this["PATIENTDIAGNOSIS"]; }
            set { this["PATIENTDIAGNOSIS"] = value; }
        }

    /// <summary>
    /// Hasta-Aile Bilgi Formu Hastanın Bağlı Olduğu Sosyal Güvenlik Kuruluşu
    /// </summary>
        public string PatientPayerName
        {
            get { return (string)this["PATIENTPAYERNAME"]; }
            set { this["PATIENTPAYERNAME"] = value; }
        }

    /// <summary>
    /// Kaçıncı Derece Gazi
    /// </summary>
        public string DegreeOfWarVeteran
        {
            get { return (string)this["DEGREEOFWARVETERAN"]; }
            set { this["DEGREEOFWARVETERAN"] = value; }
        }

        virtual protected void CreatePatientInterviewFormCollection()
        {
            _PatientInterviewForm = new PatientInterviewForm.ChildPatientInterviewFormCollection(this, new Guid("1df1ee21-698b-41ca-9f2f-1237208cf5e2"));
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

        protected SocServPatientFamilyInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SocServPatientFamilyInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SocServPatientFamilyInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SocServPatientFamilyInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SocServPatientFamilyInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOCSERVPATIENTFAMILYINFO", dataRow) { }
        protected SocServPatientFamilyInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOCSERVPATIENTFAMILYINFO", dataRow, isImported) { }
        public SocServPatientFamilyInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SocServPatientFamilyInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SocServPatientFamilyInfo() : base() { }

    }
}