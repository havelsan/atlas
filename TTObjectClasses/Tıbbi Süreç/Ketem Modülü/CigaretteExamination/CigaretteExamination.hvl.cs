
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CigaretteExamination")] 

    public  partial class CigaretteExamination : Ketem
    {
        public class CigaretteExaminationList : TTObjectCollection<CigaretteExamination> { }
                    
        public class ChildCigaretteExaminationCollection : TTObject.TTChildObjectCollection<CigaretteExamination>
        {
            public ChildCigaretteExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCigaretteExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCigaretteExaminationBySubepisodeID_Class : TTReportNqlObject 
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

            public bool? Phlegm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHLEGM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PHLEGM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ShortnessOfBreath
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNESSOFBREATH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SHORTNESSOFBREATH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BloodSpitting
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOODSPITTING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["BLOODSPITTING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ChestPain
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHESTPAIN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CHESTPAIN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Angina
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANGINA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["ANGINA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PND
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PND"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PND"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Ortopne
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORTOPNE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["ORTOPNE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HeadacheAndDizziness
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADACHEANDDIZZINESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["HEADACHEANDDIZZINESS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? RedEye
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REDEYE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["REDEYE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? YellowTeeth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YELLOWTEETH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["YELLOWTEETH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CoatedTongue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COATEDTONGUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["COATEDTONGUE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string EKG
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EKG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["EKG"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SFT
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SFT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SFT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SleepingDisorder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SLEEPINGDISORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SLEEPINGDISORDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Imbalance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IMBALANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["IMBALANCE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ExcessiveSmoking
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXCESSIVESMOKING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["EXCESSIVESMOKING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IncreasedAppetite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCREASEDAPPETITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["INCREASEDAPPETITE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MouthSore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOUTHSORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["MOUTHSORE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NoDifficulty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NODIFFICULTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["NODIFFICULTY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Other
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["OTHER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Challenges
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHALLENGES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CHALLENGES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GastrointestinalSystem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GASTROINTESTINALSYSTEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["GASTROINTESTINALSYSTEM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public QuitSmokingMethodEnum? QuitSmokingMethod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUITSMOKINGMETHOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["QUITSMOKINGMETHOD"].DataType;
                    return (QuitSmokingMethodEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public IncreaseSmokingReasonEnum? IncreaseSmokingReasons
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCREASESMOKINGREASONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["INCREASESMOKINGREASONS"].DataType;
                    return (IncreaseSmokingReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? SmokingAtWorkPlaceAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMOKINGATWORKPLACEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SMOKINGATWORKPLACEAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SmokingAmountChangeEnum? SmokingAtWorkPlaceAmountType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMOKINGATWORKPLACEAMOUNTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SMOKINGATWORKPLACEAMOUNTTYPE"].DataType;
                    return (SmokingAmountChangeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FreeTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["FREETIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UsedAddictiveDrugs
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDADDICTIVEDRUGS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["USEDADDICTIVEDRUGS"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? FirstSmokeAfterWakeUp
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTSMOKEAFTERWAKEUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["FIRSTSMOKEAFTERWAKEUP"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MinuteHourEnum? FirstsmokeAfterWakeUpType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTSMOKEAFTERWAKEUPTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["FIRSTSMOKEAFTERWAKEUPTYPE"].DataType;
                    return (MinuteHourEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? PlacesThatBanSmoking
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLACESTHATBANSMOKING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PLACESTHATBANSMOKING"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GiveUpTimeEnum? GiveUpTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIVEUPTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["GIVEUPTIME"].DataType;
                    return (GiveUpTimeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ContinueSmoking
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTINUESMOKING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CONTINUESMOKING"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? OtherSmokersAtHome
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERSMOKERSATHOME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["OTHERSMOKERSATHOME"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? OtherSmokersAtWorkPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERSMOKERSATWORKPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["OTHERSMOKERSATWORKPLACE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? PassiveSmokersAtHome
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PASSIVESMOKERSATHOME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PASSIVESMOKERSATHOME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ProfessionalSupport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROFESSIONALSUPPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PROFESSIONALSUPPORT"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? BadTaste
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BADTASTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["BADTASTE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NasalBlockage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NASALBLOCKAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["NASALBLOCKAGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Cough
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COUGH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["COUGH"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Palpitation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PALPITATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PALPITATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Convulsion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONVULSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CONVULSION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CerebrovascularSurgery
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CEREBROVASCULARSURGERY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CEREBROVASCULARSURGERY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Epilepsy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPILEPSY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["EPILEPSY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HeadTrauma
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADTRAUMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["HEADTRAUMA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ControlTypeEnum? ControlType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTROLTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CONTROLTYPE"].DataType;
                    return (ControlTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? GetTraining
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GETTRAINING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["GETTRAINING"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? ControlNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTROLNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CONTROLNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? QuitDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUITDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["QUITDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? DidSheHeSmoke
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIDSHEHESMOKE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["DIDSHEHESMOKE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? SmokingAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMOKINGAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SMOKINGAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SmokingReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMOKINGREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SMOKINGREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ControlCO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTROLCO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CONTROLCO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ControlCOHb
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTROLCOHB"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CONTROLCOHB"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MedicationRange
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICATIONRANGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["MEDICATIONRANGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PeriodUnitTypeEnum? MedicineRangeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICINERANGETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["MEDICINERANGETYPE"].DataType;
                    return (PeriodUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? Treatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["TREATMENT"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string AdditionalComplaint
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALCOMPLAINT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["ADDITIONALCOMPLAINT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PhysicalExaminationEnum? PhysicalExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PHYSICALEXAMINATION"].DataType;
                    return (PhysicalExaminationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Nausea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAUSEA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["NAUSEA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Diarrhea
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIARRHEA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["DIARRHEA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Constipation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSTIPATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CONSTIPATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? GastricAcidity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GASTRICACIDITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["GASTRICACIDITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Nocturia
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOCTURIA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["NOCTURIA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Dysuria
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DYSURIA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["DYSURIA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? LibidoLoss
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIBIDOLOSS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["LIBIDOLOSS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? PreviousPsychologicalTrt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREVIOUSPSYCHOLOGICALTRT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PREVIOUSPSYCHOLOGICALTRT"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string HowHeSheFeels
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOWHESHEFEELS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["HOWHESHEFEELS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? HT
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["HT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["DM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Hyperlipidemia
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HYPERLIPIDEMIA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["HYPERLIPIDEMIA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InfarctionAngina
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFARCTIONANGINA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["INFARCTIONANGINA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? KrBronchitis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KRBRONCHITIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["KRBRONCHITIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PUlcus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PULCUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PULCUS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Embolism
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMBOLISM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["EMBOLISM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AKCOtherCancers
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AKCOTHERCANCERS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["AKCOTHERCANCERS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PreviousDiseases
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREVIOUSDISEASES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PREVIOUSDISEASES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MedicineHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICINEHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["MEDICINEHISTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OperationInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["OPERATIONINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TensionArterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENSIONARTERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["TENSIONARTERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Pulse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PULSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["PULSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? RespirationRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPIRATIONRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["RESPIRATIONRATE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SkinMucosa
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SKINMUCOSA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SKINMUCOSA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HeadNeck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADNECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["HEADNECK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RespiratorySystem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPIRATORYSYSTEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["RESPIRATORYSYSTEM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CardiovascularSystem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CARDIOVASCULARSYSTEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CARDIOVASCULARSYSTEM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GenitourinarySystem
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENITOURINARYSYSTEM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["GENITOURINARYSYSTEM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ChestRadiography
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHESTRADIOGRAPHY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CHESTRADIOGRAPHY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string COCarboxyHB
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COCARBOXYHB"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["COCARBOXYHB"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Job
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOB"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["JOB"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SmokingStartAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMOKINGSTARTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SMOKINGSTARTAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? SmokingYearRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMOKINGYEARRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SMOKINGYEARRATE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SmokingStartReasonEnum? StartSmokingReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTSMOKINGREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["STARTSMOKINGREASON"].DataType;
                    return (SmokingStartReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public QuitSmokingMethodEnum? QuitSmokingReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUITSMOKINGREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["QUITSMOKINGREASON"].DataType;
                    return (QuitSmokingMethodEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SmokingAmountChangeEnum? SmokingAmountChange
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMOKINGAMOUNTCHANGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["SMOKINGAMOUNTCHANGE"].DataType;
                    return (SmokingAmountChangeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? DailyCigaretteAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYCIGARETTEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["DAILYCIGARETTEAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public CigaretteTypeEnum? CigaretteType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CIGARETTETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["CIGARETTETYPE"].DataType;
                    return (CigaretteTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ThinkingOfQuitSmoking
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["THINKINGOFQUITSMOKING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["THINKINGOFQUITSMOKING"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? TryingQuitSmoking
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRYINGQUITSMOKING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["TRYINGQUITSMOKING"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? TryingQuitSmokingAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRYINGQUITSMOKINGAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["TRYINGQUITSMOKINGAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? Irritability
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IRRITABILITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["IRRITABILITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? LossOfConcentration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOSSOFCONCENTRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["LOSSOFCONCENTRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HeadAndFacialNumbness
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADANDFACIALNUMBNESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].AllPropertyDefs["HEADANDFACIALNUMBNESS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetCigaretteExaminationBySubepisodeID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCigaretteExaminationBySubepisodeID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCigaretteExaminationBySubepisodeID_Class() : base() { }
        }

        public static BindingList<CigaretteExamination.GetCigaretteExaminationBySubepisodeID_Class> GetCigaretteExaminationBySubepisodeID(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].QueryDefs["GetCigaretteExaminationBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<CigaretteExamination.GetCigaretteExaminationBySubepisodeID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CigaretteExamination.GetCigaretteExaminationBySubepisodeID_Class> GetCigaretteExaminationBySubepisodeID(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CIGARETTEEXAMINATION"].QueryDefs["GetCigaretteExaminationBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<CigaretteExamination.GetCigaretteExaminationBySubepisodeID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Balgam
    /// </summary>
        public bool? Phlegm
        {
            get { return (bool?)this["PHLEGM"]; }
            set { this["PHLEGM"] = value; }
        }

    /// <summary>
    /// Nefes Darlığı
    /// </summary>
        public bool? ShortnessOfBreath
        {
            get { return (bool?)this["SHORTNESSOFBREATH"]; }
            set { this["SHORTNESSOFBREATH"] = value; }
        }

    /// <summary>
    /// Kan Tükürme
    /// </summary>
        public bool? BloodSpitting
        {
            get { return (bool?)this["BLOODSPITTING"]; }
            set { this["BLOODSPITTING"] = value; }
        }

    /// <summary>
    /// Göğüs Ağrısı
    /// </summary>
        public bool? ChestPain
        {
            get { return (bool?)this["CHESTPAIN"]; }
            set { this["CHESTPAIN"] = value; }
        }

    /// <summary>
    /// Angina
    /// </summary>
        public bool? Angina
        {
            get { return (bool?)this["ANGINA"]; }
            set { this["ANGINA"] = value; }
        }

    /// <summary>
    /// PND
    /// </summary>
        public bool? PND
        {
            get { return (bool?)this["PND"]; }
            set { this["PND"] = value; }
        }

    /// <summary>
    /// Ortopne
    /// </summary>
        public bool? Ortopne
        {
            get { return (bool?)this["ORTOPNE"]; }
            set { this["ORTOPNE"] = value; }
        }

    /// <summary>
    /// Baş Ağrısı ve Dönmesi
    /// </summary>
        public bool? HeadacheAndDizziness
        {
            get { return (bool?)this["HEADACHEANDDIZZINESS"]; }
            set { this["HEADACHEANDDIZZINESS"] = value; }
        }

    /// <summary>
    /// Gözlerde Kızarıklık/Kanlanma
    /// </summary>
        public bool? RedEye
        {
            get { return (bool?)this["REDEYE"]; }
            set { this["REDEYE"] = value; }
        }

    /// <summary>
    /// Dişlerde Sararma
    /// </summary>
        public bool? YellowTeeth
        {
            get { return (bool?)this["YELLOWTEETH"]; }
            set { this["YELLOWTEETH"] = value; }
        }

    /// <summary>
    /// Paslı Dil
    /// </summary>
        public bool? CoatedTongue
        {
            get { return (bool?)this["COATEDTONGUE"]; }
            set { this["COATEDTONGUE"] = value; }
        }

    /// <summary>
    /// EKG
    /// </summary>
        public string EKG
        {
            get { return (string)this["EKG"]; }
            set { this["EKG"] = value; }
        }

    /// <summary>
    /// SFT
    /// </summary>
        public string SFT
        {
            get { return (string)this["SFT"]; }
            set { this["SFT"] = value; }
        }

    /// <summary>
    /// Uyku Bozukluğu
    /// </summary>
        public bool? SleepingDisorder
        {
            get { return (bool?)this["SLEEPINGDISORDER"]; }
            set { this["SLEEPINGDISORDER"] = value; }
        }

    /// <summary>
    /// Dengesizlik
    /// </summary>
        public bool? Imbalance
        {
            get { return (bool?)this["IMBALANCE"]; }
            set { this["IMBALANCE"] = value; }
        }

    /// <summary>
    /// Aşırı Sigara İçme
    /// </summary>
        public bool? ExcessiveSmoking
        {
            get { return (bool?)this["EXCESSIVESMOKING"]; }
            set { this["EXCESSIVESMOKING"] = value; }
        }

    /// <summary>
    /// İştah Artması
    /// </summary>
        public bool? IncreasedAppetite
        {
            get { return (bool?)this["INCREASEDAPPETITE"]; }
            set { this["INCREASEDAPPETITE"] = value; }
        }

    /// <summary>
    /// Ağız Yaraları
    /// </summary>
        public bool? MouthSore
        {
            get { return (bool?)this["MOUTHSORE"]; }
            set { this["MOUTHSORE"] = value; }
        }

    /// <summary>
    /// Zorluk Yok
    /// </summary>
        public bool? NoDifficulty
        {
            get { return (bool?)this["NODIFFICULTY"]; }
            set { this["NODIFFICULTY"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public bool? Other
        {
            get { return (bool?)this["OTHER"]; }
            set { this["OTHER"] = value; }
        }

        public string Challenges
        {
            get { return (string)this["CHALLENGES"]; }
            set { this["CHALLENGES"] = value; }
        }

    /// <summary>
    /// Gastrointestinal Sistem
    /// </summary>
        public string GastrointestinalSystem
        {
            get { return (string)this["GASTROINTESTINALSYSTEM"]; }
            set { this["GASTROINTESTINALSYSTEM"] = value; }
        }

    /// <summary>
    /// Sigarayı Bırakma Yöntemi
    /// </summary>
        public QuitSmokingMethodEnum? QuitSmokingMethod
        {
            get { return (QuitSmokingMethodEnum?)(int?)this["QUITSMOKINGMETHOD"]; }
            set { this["QUITSMOKINGMETHOD"] = value; }
        }

    /// <summary>
    /// Sigarayı İçme İsteğini Arttıran Nedenler
    /// </summary>
        public IncreaseSmokingReasonEnum? IncreaseSmokingReasons
        {
            get { return (IncreaseSmokingReasonEnum?)(int?)this["INCREASESMOKINGREASONS"]; }
            set { this["INCREASESMOKINGREASONS"] = value; }
        }

    /// <summary>
    /// İş Yerinde İçilen Sigara Miktarı/Türü
    /// </summary>
        public int? SmokingAtWorkPlaceAmount
        {
            get { return (int?)this["SMOKINGATWORKPLACEAMOUNT"]; }
            set { this["SMOKINGATWORKPLACEAMOUNT"] = value; }
        }

        public SmokingAmountChangeEnum? SmokingAtWorkPlaceAmountType
        {
            get { return (SmokingAmountChangeEnum?)(int?)this["SMOKINGATWORKPLACEAMOUNTTYPE"]; }
            set { this["SMOKINGATWORKPLACEAMOUNTTYPE"] = value; }
        }

    /// <summary>
    /// Boş Zamanlarını Nasıl Değerlendirirsiniz?
    /// </summary>
        public string FreeTime
        {
            get { return (string)this["FREETIME"]; }
            set { this["FREETIME"] = value; }
        }

    /// <summary>
    /// Devamlı Kulandığınız Bağımlılık Yapıcı Madde Var Mı?
    /// </summary>
        public YesNoEnum? UsedAddictiveDrugs
        {
            get { return (YesNoEnum?)(int?)this["USEDADDICTIVEDRUGS"]; }
            set { this["USEDADDICTIVEDRUGS"] = value; }
        }

    /// <summary>
    /// İlk sigarayı Sabah Kalktıktan Ne Kadar Sonra İçiyorsunuz?
    /// </summary>
        public int? FirstSmokeAfterWakeUp
        {
            get { return (int?)this["FIRSTSMOKEAFTERWAKEUP"]; }
            set { this["FIRSTSMOKEAFTERWAKEUP"] = value; }
        }

        public MinuteHourEnum? FirstsmokeAfterWakeUpType
        {
            get { return (MinuteHourEnum?)(int?)this["FIRSTSMOKEAFTERWAKEUPTYPE"]; }
            set { this["FIRSTSMOKEAFTERWAKEUPTYPE"] = value; }
        }

    /// <summary>
    /// Sigara Yasağı Olan Yerlerde İçmediğiniz Zaman Rahat Ediyor Musunuz?
    /// </summary>
        public YesNoEnum? PlacesThatBanSmoking
        {
            get { return (YesNoEnum?)(int?)this["PLACESTHATBANSMOKING"]; }
            set { this["PLACESTHATBANSMOKING"] = value; }
        }

    /// <summary>
    /// Vazgeçmek İstediğiniz Zaman Dilimi
    /// </summary>
        public GiveUpTimeEnum? GiveUpTime
        {
            get { return (GiveUpTimeEnum?)(int?)this["GIVEUPTIME"]; }
            set { this["GIVEUPTIME"] = value; }
        }

    /// <summary>
    /// Yatalak Ağır Hasta Olacağınızı Bilseniz Yine de Sigara İçer Misiniz?
    /// </summary>
        public YesNoEnum? ContinueSmoking
        {
            get { return (YesNoEnum?)(int?)this["CONTINUESMOKING"]; }
            set { this["CONTINUESMOKING"] = value; }
        }

    /// <summary>
    /// Evde Sizden Başka Sigara İçen Var Mı?
    /// </summary>
        public YesNoEnum? OtherSmokersAtHome
        {
            get { return (YesNoEnum?)(int?)this["OTHERSMOKERSATHOME"]; }
            set { this["OTHERSMOKERSATHOME"] = value; }
        }

    /// <summary>
    /// İş Yerinde Aynı Ortamda Sigara İçen Var Mı?
    /// </summary>
        public YesNoEnum? OtherSmokersAtWorkPlace
        {
            get { return (YesNoEnum?)(int?)this["OTHERSMOKERSATWORKPLACE"]; }
            set { this["OTHERSMOKERSATWORKPLACE"] = value; }
        }

    /// <summary>
    /// Evde sigara İçmeyen Ancak Dumana Maruz Kalan Kişi Sayısı
    /// </summary>
        public int? PassiveSmokersAtHome
        {
            get { return (int?)this["PASSIVESMOKERSATHOME"]; }
            set { this["PASSIVESMOKERSATHOME"] = value; }
        }

    /// <summary>
    /// Profosyonel Destek Aldınız Mı?
    /// </summary>
        public YesNoEnum? ProfessionalSupport
        {
            get { return (YesNoEnum?)(int?)this["PROFESSIONALSUPPORT"]; }
            set { this["PROFESSIONALSUPPORT"] = value; }
        }

    /// <summary>
    /// Kötü Tat
    /// </summary>
        public bool? BadTaste
        {
            get { return (bool?)this["BADTASTE"]; }
            set { this["BADTASTE"] = value; }
        }

    /// <summary>
    /// Burun Tıkanıklığı
    /// </summary>
        public bool? NasalBlockage
        {
            get { return (bool?)this["NASALBLOCKAGE"]; }
            set { this["NASALBLOCKAGE"] = value; }
        }

    /// <summary>
    /// Öksürük
    /// </summary>
        public bool? Cough
        {
            get { return (bool?)this["COUGH"]; }
            set { this["COUGH"] = value; }
        }

    /// <summary>
    /// Çarpıntı
    /// </summary>
        public bool? Palpitation
        {
            get { return (bool?)this["PALPITATION"]; }
            set { this["PALPITATION"] = value; }
        }

    /// <summary>
    /// Konvülsiyon
    /// </summary>
        public bool? Convulsion
        {
            get { return (bool?)this["CONVULSION"]; }
            set { this["CONVULSION"] = value; }
        }

    /// <summary>
    /// Serebrovasküler Cerrahi
    /// </summary>
        public bool? CerebrovascularSurgery
        {
            get { return (bool?)this["CEREBROVASCULARSURGERY"]; }
            set { this["CEREBROVASCULARSURGERY"] = value; }
        }

    /// <summary>
    /// Epilepsi
    /// </summary>
        public bool? Epilepsy
        {
            get { return (bool?)this["EPILEPSY"]; }
            set { this["EPILEPSY"] = value; }
        }

    /// <summary>
    /// Kafa Travması
    /// </summary>
        public bool? HeadTrauma
        {
            get { return (bool?)this["HEADTRAUMA"]; }
            set { this["HEADTRAUMA"] = value; }
        }

    /// <summary>
    /// Kontrol Şekli
    /// </summary>
        public ControlTypeEnum? ControlType
        {
            get { return (ControlTypeEnum?)(int?)this["CONTROLTYPE"]; }
            set { this["CONTROLTYPE"] = value; }
        }

    /// <summary>
    /// Eğitim Aldı Mı?
    /// </summary>
        public YesNoEnum? GetTraining
        {
            get { return (YesNoEnum?)(int?)this["GETTRAINING"]; }
            set { this["GETTRAINING"] = value; }
        }

    /// <summary>
    /// Kaçıncı Kontrol
    /// </summary>
        public int? ControlNumber
        {
            get { return (int?)this["CONTROLNUMBER"]; }
            set { this["CONTROLNUMBER"] = value; }
        }

    /// <summary>
    /// Bırakma Tarihi
    /// </summary>
        public DateTime? QuitDate
        {
            get { return (DateTime?)this["QUITDATE"]; }
            set { this["QUITDATE"] = value; }
        }

    /// <summary>
    /// Sigara İçti Mi?
    /// </summary>
        public YesNoEnum? DidSheHeSmoke
        {
            get { return (YesNoEnum?)(int?)this["DIDSHEHESMOKE"]; }
            set { this["DIDSHEHESMOKE"] = value; }
        }

    /// <summary>
    /// Kaç Tane İçti?
    /// </summary>
        public int? SmokingAmount
        {
            get { return (int?)this["SMOKINGAMOUNT"]; }
            set { this["SMOKINGAMOUNT"] = value; }
        }

    /// <summary>
    /// Neden İçti?
    /// </summary>
        public string SmokingReason
        {
            get { return (string)this["SMOKINGREASON"]; }
            set { this["SMOKINGREASON"] = value; }
        }

    /// <summary>
    /// Kontrol CO
    /// </summary>
        public string ControlCO
        {
            get { return (string)this["CONTROLCO"]; }
            set { this["CONTROLCO"] = value; }
        }

    /// <summary>
    /// Kontrol COHb
    /// </summary>
        public string ControlCOHb
        {
            get { return (string)this["CONTROLCOHB"]; }
            set { this["CONTROLCOHB"] = value; }
        }

    /// <summary>
    /// İlaç Kullanım Süresi
    /// </summary>
        public int? MedicationRange
        {
            get { return (int?)this["MEDICATIONRANGE"]; }
            set { this["MEDICATIONRANGE"] = value; }
        }

        public PeriodUnitTypeEnum? MedicineRangeType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["MEDICINERANGETYPE"]; }
            set { this["MEDICINERANGETYPE"] = value; }
        }

    /// <summary>
    /// Tedavi Alıyor Mu?
    /// </summary>
        public YesNoEnum? Treatment
        {
            get { return (YesNoEnum?)(int?)this["TREATMENT"]; }
            set { this["TREATMENT"] = value; }
        }

    /// <summary>
    /// Ek Şikayet
    /// </summary>
        public string AdditionalComplaint
        {
            get { return (string)this["ADDITIONALCOMPLAINT"]; }
            set { this["ADDITIONALCOMPLAINT"] = value; }
        }

    /// <summary>
    /// Fizi Muayene
    /// </summary>
        public PhysicalExaminationEnum? PhysicalExamination
        {
            get { return (PhysicalExaminationEnum?)(int?)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Bulantı
    /// </summary>
        public bool? Nausea
        {
            get { return (bool?)this["NAUSEA"]; }
            set { this["NAUSEA"] = value; }
        }

    /// <summary>
    /// İshal
    /// </summary>
        public bool? Diarrhea
        {
            get { return (bool?)this["DIARRHEA"]; }
            set { this["DIARRHEA"] = value; }
        }

    /// <summary>
    /// Kabız
    /// </summary>
        public bool? Constipation
        {
            get { return (bool?)this["CONSTIPATION"]; }
            set { this["CONSTIPATION"] = value; }
        }

    /// <summary>
    /// Midede Ekşime
    /// </summary>
        public bool? GastricAcidity
        {
            get { return (bool?)this["GASTRICACIDITY"]; }
            set { this["GASTRICACIDITY"] = value; }
        }

    /// <summary>
    /// Noktüri
    /// </summary>
        public bool? Nocturia
        {
            get { return (bool?)this["NOCTURIA"]; }
            set { this["NOCTURIA"] = value; }
        }

    /// <summary>
    /// Dizüri
    /// </summary>
        public bool? Dysuria
        {
            get { return (bool?)this["DYSURIA"]; }
            set { this["DYSURIA"] = value; }
        }

    /// <summary>
    /// Libido Kaybı
    /// </summary>
        public bool? LibidoLoss
        {
            get { return (bool?)this["LIBIDOLOSS"]; }
            set { this["LIBIDOLOSS"] = value; }
        }

    /// <summary>
    /// Daha Önce Psikolojik Tedavi Aldı Mı?
    /// </summary>
        public YesNoEnum? PreviousPsychologicalTrt
        {
            get { return (YesNoEnum?)(int?)this["PREVIOUSPSYCHOLOGICALTRT"]; }
            set { this["PREVIOUSPSYCHOLOGICALTRT"] = value; }
        }

    /// <summary>
    /// Son İki Haftadır Nasıl Hissediyor?
    /// </summary>
        public string HowHeSheFeels
        {
            get { return (string)this["HOWHESHEFEELS"]; }
            set { this["HOWHESHEFEELS"] = value; }
        }

    /// <summary>
    /// HT
    /// </summary>
        public bool? HT
        {
            get { return (bool?)this["HT"]; }
            set { this["HT"] = value; }
        }

    /// <summary>
    /// DM
    /// </summary>
        public bool? DM
        {
            get { return (bool?)this["DM"]; }
            set { this["DM"] = value; }
        }

    /// <summary>
    /// Hiperlipidemi
    /// </summary>
        public bool? Hyperlipidemia
        {
            get { return (bool?)this["HYPERLIPIDEMIA"]; }
            set { this["HYPERLIPIDEMIA"] = value; }
        }

    /// <summary>
    /// Enfarktüs/Angina
    /// </summary>
        public bool? InfarctionAngina
        {
            get { return (bool?)this["INFARCTIONANGINA"]; }
            set { this["INFARCTIONANGINA"] = value; }
        }

    /// <summary>
    /// KR/Bronşit
    /// </summary>
        public bool? KrBronchitis
        {
            get { return (bool?)this["KRBRONCHITIS"]; }
            set { this["KRBRONCHITIS"] = value; }
        }

    /// <summary>
    /// P.Ulcus
    /// </summary>
        public bool? PUlcus
        {
            get { return (bool?)this["PULCUS"]; }
            set { this["PULCUS"] = value; }
        }

    /// <summary>
    /// Damar Tıkanıklığı
    /// </summary>
        public bool? Embolism
        {
            get { return (bool?)this["EMBOLISM"]; }
            set { this["EMBOLISM"] = value; }
        }

    /// <summary>
    /// AKC/Diğer Kanserler
    /// </summary>
        public bool? AKCOtherCancers
        {
            get { return (bool?)this["AKCOTHERCANCERS"]; }
            set { this["AKCOTHERCANCERS"] = value; }
        }

    /// <summary>
    /// Geçirdiği Hastalıklar
    /// </summary>
        public string PreviousDiseases
        {
            get { return (string)this["PREVIOUSDISEASES"]; }
            set { this["PREVIOUSDISEASES"] = value; }
        }

    /// <summary>
    /// İlaç Öyküsü
    /// </summary>
        public string MedicineHistory
        {
            get { return (string)this["MEDICINEHISTORY"]; }
            set { this["MEDICINEHISTORY"] = value; }
        }

    /// <summary>
    /// Kaza/Operasyon Bilgisi
    /// </summary>
        public string OperationInfo
        {
            get { return (string)this["OPERATIONINFO"]; }
            set { this["OPERATIONINFO"] = value; }
        }

    /// <summary>
    /// Tansiyon Arteriyel
    /// </summary>
        public string TensionArterial
        {
            get { return (string)this["TENSIONARTERIAL"]; }
            set { this["TENSIONARTERIAL"] = value; }
        }

    /// <summary>
    /// Nabız
    /// </summary>
        public string Pulse
        {
            get { return (string)this["PULSE"]; }
            set { this["PULSE"] = value; }
        }

    /// <summary>
    /// Solunum Sayısı
    /// </summary>
        public int? RespirationRate
        {
            get { return (int?)this["RESPIRATIONRATE"]; }
            set { this["RESPIRATIONRATE"] = value; }
        }

    /// <summary>
    /// Cilt-Mukoza
    /// </summary>
        public string SkinMucosa
        {
            get { return (string)this["SKINMUCOSA"]; }
            set { this["SKINMUCOSA"] = value; }
        }

    /// <summary>
    /// Baş-Boyun
    /// </summary>
        public string HeadNeck
        {
            get { return (string)this["HEADNECK"]; }
            set { this["HEADNECK"] = value; }
        }

    /// <summary>
    /// Solunum Sistemi
    /// </summary>
        public string RespiratorySystem
        {
            get { return (string)this["RESPIRATORYSYSTEM"]; }
            set { this["RESPIRATORYSYSTEM"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler Sistem
    /// </summary>
        public string CardiovascularSystem
        {
            get { return (string)this["CARDIOVASCULARSYSTEM"]; }
            set { this["CARDIOVASCULARSYSTEM"] = value; }
        }

    /// <summary>
    /// Genitoüriner Sistem
    /// </summary>
        public string GenitourinarySystem
        {
            get { return (string)this["GENITOURINARYSYSTEM"]; }
            set { this["GENITOURINARYSYSTEM"] = value; }
        }

    /// <summary>
    /// Akciğer Grafisi
    /// </summary>
        public string ChestRadiography
        {
            get { return (string)this["CHESTRADIOGRAPHY"]; }
            set { this["CHESTRADIOGRAPHY"] = value; }
        }

    /// <summary>
    /// CO Karboksi HB
    /// </summary>
        public string COCarboxyHB
        {
            get { return (string)this["COCARBOXYHB"]; }
            set { this["COCARBOXYHB"] = value; }
        }

    /// <summary>
    /// Yaptığı İş
    /// </summary>
        public string Job
        {
            get { return (string)this["JOB"]; }
            set { this["JOB"] = value; }
        }

    /// <summary>
    /// Sigara Başlama Yaşı
    /// </summary>
        public int? SmokingStartAge
        {
            get { return (int?)this["SMOKINGSTARTAGE"]; }
            set { this["SMOKINGSTARTAGE"] = value; }
        }

    /// <summary>
    /// Yılda İçilen Sigara Miktarı
    /// </summary>
        public int? SmokingYearRate
        {
            get { return (int?)this["SMOKINGYEARRATE"]; }
            set { this["SMOKINGYEARRATE"] = value; }
        }

    /// <summary>
    /// Sigara Başlama Nedeni
    /// </summary>
        public SmokingStartReasonEnum? StartSmokingReason
        {
            get { return (SmokingStartReasonEnum?)(int?)this["STARTSMOKINGREASON"]; }
            set { this["STARTSMOKINGREASON"] = value; }
        }

    /// <summary>
    /// Sigara Bırakma İstek Nedeni
    /// </summary>
        public QuitSmokingMethodEnum? QuitSmokingReason
        {
            get { return (QuitSmokingMethodEnum?)(int?)this["QUITSMOKINGREASON"]; }
            set { this["QUITSMOKINGREASON"] = value; }
        }

    /// <summary>
    /// Sigara Miktarındaki Değişim
    /// </summary>
        public SmokingAmountChangeEnum? SmokingAmountChange
        {
            get { return (SmokingAmountChangeEnum?)(int?)this["SMOKINGAMOUNTCHANGE"]; }
            set { this["SMOKINGAMOUNTCHANGE"] = value; }
        }

    /// <summary>
    /// Günde İçilen Sigara Miktarı
    /// </summary>
        public int? DailyCigaretteAmount
        {
            get { return (int?)this["DAILYCIGARETTEAMOUNT"]; }
            set { this["DAILYCIGARETTEAMOUNT"] = value; }
        }

    /// <summary>
    /// Sigara Tipi
    /// </summary>
        public CigaretteTypeEnum? CigaretteType
        {
            get { return (CigaretteTypeEnum?)(int?)this["CIGARETTETYPE"]; }
            set { this["CIGARETTETYPE"] = value; }
        }

    /// <summary>
    /// Sigarayı Bırakmayı Düşündünüz Mü?
    /// </summary>
        public YesNoEnum? ThinkingOfQuitSmoking
        {
            get { return (YesNoEnum?)(int?)this["THINKINGOFQUITSMOKING"]; }
            set { this["THINKINGOFQUITSMOKING"] = value; }
        }

    /// <summary>
    /// Sigarayı Bırakmayı Denediniz Mi? Kaç Kere?
    /// </summary>
        public YesNoEnum? TryingQuitSmoking
        {
            get { return (YesNoEnum?)(int?)this["TRYINGQUITSMOKING"]; }
            set { this["TRYINGQUITSMOKING"] = value; }
        }

        public int? TryingQuitSmokingAmount
        {
            get { return (int?)this["TRYINGQUITSMOKINGAMOUNT"]; }
            set { this["TRYINGQUITSMOKINGAMOUNT"] = value; }
        }

    /// <summary>
    /// Sinirlilik
    /// </summary>
        public bool? Irritability
        {
            get { return (bool?)this["IRRITABILITY"]; }
            set { this["IRRITABILITY"] = value; }
        }

    /// <summary>
    /// KonsantrasyonBozukluğu
    /// </summary>
        public bool? LossOfConcentration
        {
            get { return (bool?)this["LOSSOFCONCENTRATION"]; }
            set { this["LOSSOFCONCENTRATION"] = value; }
        }

    /// <summary>
    /// Yüz ve Başta Uyuşma
    /// </summary>
        public bool? HeadAndFacialNumbness
        {
            get { return (bool?)this["HEADANDFACIALNUMBNESS"]; }
            set { this["HEADANDFACIALNUMBNESS"] = value; }
        }

        protected CigaretteExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CigaretteExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CigaretteExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CigaretteExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CigaretteExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CIGARETTEEXAMINATION", dataRow) { }
        protected CigaretteExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CIGARETTEEXAMINATION", dataRow, isImported) { }
        public CigaretteExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CigaretteExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CigaretteExamination() : base() { }

    }
}