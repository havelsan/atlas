
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LowerExtremity")] 

    /// <summary>
    /// Alt Ekstremite Protez Raporu
    /// </summary>
    public  partial class LowerExtremity : BaseHCExaminationDynamicObject
    {
        public class LowerExtremityList : TTObjectCollection<LowerExtremity> { }
                    
        public class ChildLowerExtremityCollection : TTObject.TTChildObjectCollection<LowerExtremity>
        {
            public ChildLowerExtremityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLowerExtremityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExtremityReportInfoByObjId_Class : TTReportNqlObject 
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

            public string UE_HD_Myoelectric_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_MYOELECTRIC_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_MYOELECTRIC_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_CauseOfInjury
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_CAUSEOFINJURY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_CAUSEOFINJURY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_AmputationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_AMPUTATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_AMPUTATIONDATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_ProsthesisNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_PROSTHESISNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_PROSTHESISNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_ConstructionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_CONSTRUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_CONSTRUCTIONDATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_ProstheticType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_PROSTHETICTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_PROSTHETICTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_AmputationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_AMPUTATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_AMPUTATIONDATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_CauseOfInjury
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_CAUSEOFINJURY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_CAUSEOFINJURY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_ConstructionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_CONSTRUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_CONSTRUCTIONDATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_ProsthesisNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_PROSTHESISNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_PROSTHESISNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_ProstheticType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_PROSTHETICTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_PROSTHETICTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_FunctionalMovement_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_FUNCTIONALMOVEMENT_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_FUNCTIONALMOVEMENT_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_StumpZone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_STUMPZONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_STUMPZONE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_StumpZone_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_STUMPZONE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_STUMPZONE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_Contracture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_CONTRACTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_CONTRACTURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_Contracture_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_CONTRACTURE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_CONTRACTURE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_Musculoskeletal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_MUSCULOSKELETAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_MUSCULOSKELETAL"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_Musculoskeletal_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_MUSCULOSKELETAL_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_MUSCULOSKELETAL_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_Neurological
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_NEUROLOGICAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_NEUROLOGICAL"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_Neurological_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_NEUROLOGICAL_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_NEUROLOGICAL_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_Cardiovascular
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_CARDIOVASCULAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_CARDIOVASCULAR"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_Cardiovascular_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_CARDIOVASCULAR_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_CARDIOVASCULAR_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_Pulmonary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_PULMONARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_PULMONARY"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_Pulmonary_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_PULMONARY_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_PULMONARY_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_OrganFailure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_ORGANFAILURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_ORGANFAILURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_OrganFailure_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_ORGANFAILURE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_ORGANFAILURE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_SystemicDisease
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_SYSTEMICDISEASE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_SYSTEMICDISEASE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_SystemicDisease_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_SYSTEMICDISEASE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_SYSTEMICDISEASE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_Myoelectric
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_MYOELECTRIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_MYOELECTRIC"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_SK_ProstheticType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_PROSTHETICTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_PROSTHETICTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_SK_ProstheticType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_SK_PROSTHETICTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_SK_PROSTHETICTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_PreferencePetition_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_PREFERENCEPETITION_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_PREFERENCEPETITION_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_SufficientStump_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_SUFFICIENTSTUMP_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_SUFFICIENTSTUMP_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_MedicalReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_MEDICALREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_MEDICALREASON"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_ThirdStepHealthInst
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_THIRDSTEPHEALTHINST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_THIRDSTEPHEALTHINST"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_FTRExpertApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_FTREXPERTAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_FTREXPERTAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_OrthopedicExpertApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_ORTHOPEDICEXPERTAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_ORTHOPEDICEXPERTAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_PsychiatricExpertApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_PSYCHIATRICEXPERTAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_PSYCHIATRICEXPERTAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HeadDoctorApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HEADDOCTORAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HEADDOCTORAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_PatientNameSurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_PATIENTNAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_PATIENTNAMESURNAME"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_MedulaInsCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_MEDULAINSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_MEDULAINSCODE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_DATE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_MedulaOrProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_MEDULAORPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_MEDULAORPROTOCOLNO"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_DiagnosAndICD10Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_DIAGNOSANDICD10CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_DIAGNOSANDICD10CODE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_MachineName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_MACHINENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_MACHINENAME"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_MachineNameIsCorrect
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_MACHINENAMEISCORRECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_MACHINENAMEISCORRECT"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_WetSignature
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_WETSIGNATURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_WETSIGNATURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_AktivityLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_AKTIVITYLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_AKTIVITYLEVEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_PreferencePetition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_PREFERENCEPETITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_PREFERENCEPETITION"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_StumpZone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_STUMPZONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_STUMPZONE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_WeightTolerance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_WEIGHTTOLERANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_WEIGHTTOLERANCE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_Contracture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_CONTRACTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_CONTRACTURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_SingleSideAmputate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_SINGLESIDEAMPUTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_SINGLESIDEAMPUTATE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_Ambulation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_AMBULATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_AMBULATION"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_Musculoskeletal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_MUSCULOSKELETAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_MUSCULOSKELETAL"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_Neurological
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_NEUROLOGICAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_NEUROLOGICAL"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_Cardiovascular
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_CARDIOVASCULAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_CARDIOVASCULAR"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_Pulmonary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_PULMONARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_PULMONARY"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_OrganFailure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_ORGANFAILURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_ORGANFAILURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_HD_SystemicDisease
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_SYSTEMICDISEASE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_SYSTEMICDISEASE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LE_TEM_WhichLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_WHICHLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_WHICHLEVEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_TEM_OscillationandPosture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_OSCILLATIONANDPOSTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_OSCILLATIONANDPOSTURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_TEM_WalkingSpeed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_WALKINGSPEED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_WALKINGSPEED"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_TEM_StrideLength
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_STRIDELENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_STRIDELENGTH"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_TEM_StepClimbing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_STEPCLIMBING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_STEPCLIMBING"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_TEM_WalkBackwards
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_WALKBACKWARDS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_WALKBACKWARDS"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? LE_TEM_Waterproof
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_WATERPROOF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_WATERPROOF"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_Ambulation_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_AMBULATION_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_AMBULATION_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_Cardiovascular_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_CARDIOVASCULAR_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_CARDIOVASCULAR_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_Contracture_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_CONTRACTURE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_CONTRACTURE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_Musculoskeletal_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_MUSCULOSKELETAL_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_MUSCULOSKELETAL_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_Neurological_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_NEUROLOGICAL_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_NEUROLOGICAL_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_OrganFailure_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_ORGANFAILURE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_ORGANFAILURE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_PreferencePetition_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_PREFERENCEPETITION_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_PREFERENCEPETITION_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_Pulmonary_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_PULMONARY_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_PULMONARY_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_SingleSideAmputate_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_SINGLESIDEAMPUTATE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_SINGLESIDEAMPUTATE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_StumpZone_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_STUMPZONE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_STUMPZONE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_SystemicDisease_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_SYSTEMICDISEASE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_SYSTEMICDISEASE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_HD_WeightTolerance_desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_HD_WEIGHTTOLERANCE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_HD_WEIGHTTOLERANCE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_TEM_Oscillationand_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_OSCILLATIONAND_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_OSCILLATIONAND_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_TEM_StepClimbing_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_STEPCLIMBING_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_STEPCLIMBING_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_TEM_StrideLength_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_STRIDELENGTH_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_STRIDELENGTH_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_TEM_WalkBackwards_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_WALKBACKWARDS_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_WALKBACKWARDS_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_TEM_WalkingSpeed_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_WALKINGSPEED_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_WALKINGSPEED_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LE_TEM_Waterproof_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LE_TEM_WATERPROOF_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["LE_TEM_WATERPROOF_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_SK_MedicalReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_MEDICALREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_MEDICALREASON"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_SK_FTRExpertApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_FTREXPERTAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_FTREXPERTAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_SK_HeadDoctorApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_HEADDOCTORAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_HEADDOCTORAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_SK_OrthopedicExpApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_ORTHOPEDICEXPAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_ORTHOPEDICEXPAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_SK_PsychiatricExpApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_PSYCHIATRICEXPAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_PSYCHIATRICEXPAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_SK_sEMG
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_SEMG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_SEMG"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_SK_ThirdStepHealthInst
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_SK_THIRDSTEPHEALTHINST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_SK_THIRDSTEPHEALTHINST"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_PatientNameSurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_PATIENTNAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_PATIENTNAMESURNAME"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_MedulaInsCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_MEDULAINSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_MEDULAINSCODE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_DATE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_MedulaOrProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_MEDULAORPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_MEDULAORPROTOCOLNO"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_MachineName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_MACHINENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_MACHINENAME"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_DiagnosAndICD10Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_DIAGNOSANDICD10CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_DIAGNOSANDICD10CODE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_MachineNameIsCorrect
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_MACHINENAMEISCORRECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_MACHINENAMEISCORRECT"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_RI_WetSignature
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_RI_WETSIGNATURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_RI_WETSIGNATURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_AmputationLevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_AMPUTATIONLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_AMPUTATIONLEVEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? UE_HD_StumpLength
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_STUMPLENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_STUMPLENGTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_PreferencePetition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_PREFERENCEPETITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_PREFERENCEPETITION"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_SufficientStumpLength
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_SUFFICIENTSTUMPLENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_SUFFICIENTSTUMPLENGTH"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_SingleSideAmputate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_SINGLESIDEAMPUTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_SINGLESIDEAMPUTATE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UE_HD_SingleSideAmputate_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_SINGLESIDEAMPUTATE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_SINGLESIDEAMPUTATE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? UE_HD_FunctionalMovements
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UE_HD_FUNCTIONALMOVEMENTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["UE_HD_FUNCTIONALMOVEMENTS"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ATS_CauseOfInjury
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_CAUSEOFINJURY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_CAUSEOFINJURY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_ChairNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_CHAIRNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_CHAIRNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_DELIVERYDATE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_ChairType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_CHAIRTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_CHAIRTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_SK_ChairType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_SK_CHAIRTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_SK_CHAIRTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_SK_MedicalReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_SK_MEDICALREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_SK_MEDICALREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_SK_ThirdStepHealthInst
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_SK_THIRDSTEPHEALTHINST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_SK_THIRDSTEPHEALTHINST"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_SK_FTRExpertApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_SK_FTREXPERTAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_SK_FTREXPERTAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_SK_OrthopedicExpApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_SK_ORTHOPEDICEXPAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_SK_ORTHOPEDICEXPAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_SK_HeadDoctorApprove
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_SK_HEADDOCTORAPPROVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_SK_HEADDOCTORAPPROVE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_RI_Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_RI_DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_RI_DATE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_RI_DiagnosAndICD10Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_RI_DIAGNOSANDICD10CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_RI_DIAGNOSANDICD10CODE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_RI_MachineName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_RI_MACHINENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_RI_MACHINENAME"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_RI_MedulaInsCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_RI_MEDULAINSCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_RI_MEDULAINSCODE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_RI_MedulaOrProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_RI_MEDULAORPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_RI_MEDULAORPROTOCOLNO"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_RI_PatientNameSurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_RI_PATIENTNAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_RI_PATIENTNAMESURNAME"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_RI_WetSignature
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_RI_WETSIGNATURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_RI_WETSIGNATURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_ChairDistance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CHAIRDISTANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CHAIRDISTANCE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ATS_HD_INTRACOMMUNITY
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_INTRACOMMUNITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_INTRACOMMUNITY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ATS_HD_Therapeutic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_THERAPEUTIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_THERAPEUTIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ATS_HD_NOAMBULATION
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_NOAMBULATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_NOAMBULATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_USELOWEREXTREMITIES
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_USELOWEREXTREMITIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_USELOWEREXTREMITIES"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_UseLowerExtremity_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_USELOWEREXTREMITY_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_USELOWEREXTREMITY_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_ConstantCondition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CONSTANTCONDITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CONSTANTCONDITION"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_ChairModel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CHAIRMODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CHAIRMODEL"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_UseHimself
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_USEHIMSELF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_USEHIMSELF"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_Deformity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_DEFORMITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_DEFORMITY"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_Contracture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CONTRACTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CONTRACTURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_Cardiovascular
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CARDIOVASCULAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CARDIOVASCULAR"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_Pulmonary
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_PULMONARY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_PULMONARY"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? ATS_HD_OrganFailure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_ORGANFAILURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_ORGANFAILURE"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_ConstantCondition_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CONSTANTCONDITION_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CONSTANTCONDITION_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_ChairModel_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CHAIRMODEL_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CHAIRMODEL_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_UseHimself_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_USEHIMSELF_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_USEHIMSELF_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_Deformity_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_DEFORMITY_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_DEFORMITY_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_Contracture_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CONTRACTURE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CONTRACTURE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_Cardiovascular_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_CARDIOVASCULAR_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_CARDIOVASCULAR_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_Pulmonary_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_PULMONARY_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_PULMONARY_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ATS_HD_OrganFailure_Desc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATS_HD_ORGANFAILURE_DESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].AllPropertyDefs["ATS_HD_ORGANFAILURE_DESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMINATION"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string BirthPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Heigth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["HEIGTH"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetExtremityReportInfoByObjId_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExtremityReportInfoByObjId_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExtremityReportInfoByObjId_Class() : base() { }
        }

        public static BindingList<LowerExtremity.GetExtremityReportInfoByObjId_Class> GetExtremityReportInfoByObjId(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].QueryDefs["GetExtremityReportInfoByObjId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<LowerExtremity.GetExtremityReportInfoByObjId_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LowerExtremity.GetExtremityReportInfoByObjId_Class> GetExtremityReportInfoByObjId(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LOWEREXTREMITY"].QueryDefs["GetExtremityReportInfoByObjId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<LowerExtremity.GetExtremityReportInfoByObjId_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Hasta myoelektrik kontrollü kol protezi temin edildikten sonra yüksek gerilim altında ve manyetik alanlarda çalışmayacağını belgelemiş mi veya taahhüt ediyor mu?
    /// </summary>
        public string UE_HD_Myoelectric_Desc
        {
            get { return (string)this["UE_HD_MYOELECTRIC_DESC"]; }
            set { this["UE_HD_MYOELECTRIC_DESC"] = value; }
        }

    /// <summary>
    /// Yaralanma nedeni ve tarihi
    /// </summary>
        public string LE_CauseOfInjury
        {
            get { return (string)this["LE_CAUSEOFINJURY"]; }
            set { this["LE_CAUSEOFINJURY"] = value; }
        }

    /// <summary>
    /// Amputasyon tarihi
    /// </summary>
        public string LE_AmputationDate
        {
            get { return (string)this["LE_AMPUTATIONDATE"]; }
            set { this["LE_AMPUTATIONDATE"] = value; }
        }

    /// <summary>
    /// Kaçıncı protezi olduğu 
    /// </summary>
        public string LE_ProsthesisNumber
        {
            get { return (string)this["LE_PROSTHESISNUMBER"]; }
            set { this["LE_PROSTHESISNUMBER"] = value; }
        }

    /// <summary>
    /// Yapım tarihi
    /// </summary>
        public string LE_ConstructionDate
        {
            get { return (string)this["LE_CONSTRUCTIONDATE"]; }
            set { this["LE_CONSTRUCTIONDATE"] = value; }
        }

    /// <summary>
    /// Protez tipi
    /// </summary>
        public string LE_ProstheticType
        {
            get { return (string)this["LE_PROSTHETICTYPE"]; }
            set { this["LE_PROSTHETICTYPE"] = value; }
        }

    /// <summary>
    /// Amputasyon tarihi
    /// </summary>
        public string UE_AmputationDate
        {
            get { return (string)this["UE_AMPUTATIONDATE"]; }
            set { this["UE_AMPUTATIONDATE"] = value; }
        }

    /// <summary>
    /// Yaralanma nedeni ve tarihi
    /// </summary>
        public string UE_CauseOfInjury
        {
            get { return (string)this["UE_CAUSEOFINJURY"]; }
            set { this["UE_CAUSEOFINJURY"] = value; }
        }

    /// <summary>
    /// Yapım tarihi
    /// </summary>
        public string UE_ConstructionDate
        {
            get { return (string)this["UE_CONSTRUCTIONDATE"]; }
            set { this["UE_CONSTRUCTIONDATE"] = value; }
        }

    /// <summary>
    /// Kaçıncı protezi olduğu 
    /// </summary>
        public string UE_ProsthesisNumber
        {
            get { return (string)this["UE_PROSTHESISNUMBER"]; }
            set { this["UE_PROSTHESISNUMBER"] = value; }
        }

    /// <summary>
    /// Protez tipi
    /// </summary>
        public string UE_ProstheticType
        {
            get { return (string)this["UE_PROSTHETICTYPE"]; }
            set { this["UE_PROSTHETICTYPE"] = value; }
        }

    /// <summary>
    /// Protezin teknik özelliklerine uygun fonksiyonel hareketleri yerine getirebilecek mi?
    /// </summary>
        public string UE_HD_FunctionalMovement_Desc
        {
            get { return (string)this["UE_HD_FUNCTIONALMOVEMENT_DESC"]; }
            set { this["UE_HD_FUNCTIONALMOVEMENT_DESC"] = value; }
        }

    /// <summary>
    /// Güdük bölgesinde soket uygulanmasına engel olabilecek yara, akıntı, dirençli ağrı vb. tıbbi sorun var mı?
    /// </summary>
        public YesNoEnum? UE_HD_StumpZone
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_STUMPZONE"]; }
            set { this["UE_HD_STUMPZONE"] = value; }
        }

    /// <summary>
    /// Güdük bölgesinde soket uygulanmasına engel olabilecek yara, akıntı, dirençli ağrı vb. tıbbi sorun var mı?
    /// </summary>
        public string UE_HD_StumpZone_Desc
        {
            get { return (string)this["UE_HD_STUMPZONE_DESC"]; }
            set { this["UE_HD_STUMPZONE_DESC"] = value; }
        }

    /// <summary>
    /// Ampute ekstremitede kontraktür var mı?
    /// </summary>
        public YesNoEnum? UE_HD_Contracture
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_CONTRACTURE"]; }
            set { this["UE_HD_CONTRACTURE"] = value; }
        }

    /// <summary>
    /// Ampute ekstremitede kontraktür var mı?
    /// </summary>
        public string UE_HD_Contracture_Desc
        {
            get { return (string)this["UE_HD_CONTRACTURE_DESC"]; }
            set { this["UE_HD_CONTRACTURE_DESC"] = value; }
        }

    /// <summary>
    /// Kas-iskelet sistemi hastalığı var mı?
    /// </summary>
        public YesNoEnum? UE_HD_Musculoskeletal
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_MUSCULOSKELETAL"]; }
            set { this["UE_HD_MUSCULOSKELETAL"] = value; }
        }

    /// <summary>
    /// Kas-iskelet sistemi hastalığı var mı?
    /// </summary>
        public string UE_HD_Musculoskeletal_Desc
        {
            get { return (string)this["UE_HD_MUSCULOSKELETAL_DESC"]; }
            set { this["UE_HD_MUSCULOSKELETAL_DESC"] = value; }
        }

    /// <summary>
    /// Nörolojik /nöromusküler hastalık var mı?
    /// </summary>
        public YesNoEnum? UE_HD_Neurological
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_NEUROLOGICAL"]; }
            set { this["UE_HD_NEUROLOGICAL"] = value; }
        }

    /// <summary>
    /// Nörolojik /nöromusküler hastalık var mı?
    /// </summary>
        public string UE_HD_Neurological_Desc
        {
            get { return (string)this["UE_HD_NEUROLOGICAL_DESC"]; }
            set { this["UE_HD_NEUROLOGICAL_DESC"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler hastalık var mı?
    /// </summary>
        public YesNoEnum? UE_HD_Cardiovascular
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_CARDIOVASCULAR"]; }
            set { this["UE_HD_CARDIOVASCULAR"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler hastalık var mı?
    /// </summary>
        public string UE_HD_Cardiovascular_Desc
        {
            get { return (string)this["UE_HD_CARDIOVASCULAR_DESC"]; }
            set { this["UE_HD_CARDIOVASCULAR_DESC"] = value; }
        }

    /// <summary>
    /// Pulmoner hastalık var mı?
    /// </summary>
        public YesNoEnum? UE_HD_Pulmonary
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_PULMONARY"]; }
            set { this["UE_HD_PULMONARY"] = value; }
        }

    /// <summary>
    /// Pulmoner hastalık var mı?
    /// </summary>
        public string UE_HD_Pulmonary_Desc
        {
            get { return (string)this["UE_HD_PULMONARY_DESC"]; }
            set { this["UE_HD_PULMONARY_DESC"] = value; }
        }

    /// <summary>
    /// Organ yetmezliği var mı?
    /// </summary>
        public YesNoEnum? UE_HD_OrganFailure
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_ORGANFAILURE"]; }
            set { this["UE_HD_ORGANFAILURE"] = value; }
        }

    /// <summary>
    /// Organ yetmezliği var mı?
    /// </summary>
        public string UE_HD_OrganFailure_Desc
        {
            get { return (string)this["UE_HD_ORGANFAILURE_DESC"]; }
            set { this["UE_HD_ORGANFAILURE_DESC"] = value; }
        }

    /// <summary>
    /// Sistemik (HT,DM, Romatolojik, Endokrinolojik, vb.) hastalıklar var mı?
    /// </summary>
        public YesNoEnum? UE_HD_SystemicDisease
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_SYSTEMICDISEASE"]; }
            set { this["UE_HD_SYSTEMICDISEASE"] = value; }
        }

    /// <summary>
    /// Sistemik (HT,DM, Romatolojik, Endokrinolojik, vb.) hastalıklar var mı?
    /// </summary>
        public string UE_HD_SystemicDisease_Desc
        {
            get { return (string)this["UE_HD_SYSTEMICDISEASE_DESC"]; }
            set { this["UE_HD_SYSTEMICDISEASE_DESC"] = value; }
        }

    /// <summary>
    /// Hasta myoelektrik kontrollü kol protezi temin edildikten sonra yüksek gerilim altında ve manyetik alanlarda çalışmayacağını belgelemiş mi veya taahhüt ediyor mu?
    /// </summary>
        public YesNoEnum? UE_HD_Myoelectric
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_MYOELECTRIC"]; }
            set { this["UE_HD_MYOELECTRIC"] = value; }
        }

    /// <summary>
    /// Raporda yazılan protez tipi:
    /// </summary>
        public string UE_SK_ProstheticType
        {
            get { return (string)this["UE_SK_PROSTHETICTYPE"]; }
            set { this["UE_SK_PROSTHETICTYPE"] = value; }
        }

    /// <summary>
    /// Raporda yazılan protez tipi:
    /// </summary>
        public string LE_SK_ProstheticType
        {
            get { return (string)this["LE_SK_PROSTHETICTYPE"]; }
            set { this["LE_SK_PROSTHETICTYPE"] = value; }
        }

    /// <summary>
    /// Hastanın protez marka/model tercih dilekçesi var mı?
    /// </summary>
        public string UE_HD_PreferencePetition_Desc
        {
            get { return (string)this["UE_HD_PREFERENCEPETITION_DESC"]; }
            set { this["UE_HD_PREFERENCEPETITION_DESC"] = value; }
        }

    /// <summary>
    /// Protez uygulanabilmesi için yeterli güdük uzunluğuna sahip mi?
    /// </summary>
        public string UE_HD_SufficientStump_Desc
        {
            get { return (string)this["UE_HD_SUFFICIENTSTUMP_DESC"]; }
            set { this["UE_HD_SUFFICIENTSTUMP_DESC"] = value; }
        }

    /// <summary>
    /// Tıbbi Gerekçe Yazılmış mı?
    /// </summary>
        public YesNoEnum? LE_MedicalReason
        {
            get { return (YesNoEnum?)(int?)this["LE_MEDICALREASON"]; }
            set { this["LE_MEDICALREASON"] = value; }
        }

    /// <summary>
    /// 3. basamak sağlık kurumu
    /// </summary>
        public YesNoEnum? LE_ThirdStepHealthInst
        {
            get { return (YesNoEnum?)(int?)this["LE_THIRDSTEPHEALTHINST"]; }
            set { this["LE_THIRDSTEPHEALTHINST"] = value; }
        }

    /// <summary>
    /// FTR Uzman Onayı
    /// </summary>
        public YesNoEnum? LE_FTRExpertApprove
        {
            get { return (YesNoEnum?)(int?)this["LE_FTREXPERTAPPROVE"]; }
            set { this["LE_FTREXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Ortopedi Uzman Onayı
    /// </summary>
        public YesNoEnum? LE_OrthopedicExpertApprove
        {
            get { return (YesNoEnum?)(int?)this["LE_ORTHOPEDICEXPERTAPPROVE"]; }
            set { this["LE_ORTHOPEDICEXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Psikiyatri Uzman Onayı
    /// </summary>
        public YesNoEnum? LE_PsychiatricExpertApprove
        {
            get { return (YesNoEnum?)(int?)this["LE_PSYCHIATRICEXPERTAPPROVE"]; }
            set { this["LE_PSYCHIATRICEXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Başhekim Onayı
    /// </summary>
        public YesNoEnum? LE_HeadDoctorApprove
        {
            get { return (YesNoEnum?)(int?)this["LE_HEADDOCTORAPPROVE"]; }
            set { this["LE_HEADDOCTORAPPROVE"] = value; }
        }

    /// <summary>
    /// Hasta Adı Soyadı Var mı?
    /// </summary>
        public YesNoEnum? LE_PatientNameSurname
        {
            get { return (YesNoEnum?)(int?)this["LE_PATIENTNAMESURNAME"]; }
            set { this["LE_PATIENTNAMESURNAME"] = value; }
        }

    /// <summary>
    /// Reçeteyi düzenleyen sağlık hizmet sunucusu adı veya MEDULA tesis kodu var mı?
    /// </summary>
        public YesNoEnum? LE_MedulaInsCode
        {
            get { return (YesNoEnum?)(int?)this["LE_MEDULAINSCODE"]; }
            set { this["LE_MEDULAINSCODE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public YesNoEnum? LE_Date
        {
            get { return (YesNoEnum?)(int?)this["LE_DATE"]; }
            set { this["LE_DATE"] = value; }
        }

    /// <summary>
    /// Medula veya Protokol Numarası
    /// </summary>
        public YesNoEnum? LE_MedulaOrProtocolNo
        {
            get { return (YesNoEnum?)(int?)this["LE_MEDULAORPROTOCOLNO"]; }
            set { this["LE_MEDULAORPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Tanı ve ICD-10 Kodu
    /// </summary>
        public YesNoEnum? LE_DiagnosAndICD10Code
        {
            get { return (YesNoEnum?)(int?)this["LE_DIAGNOSANDICD10CODE"]; }
            set { this["LE_DIAGNOSANDICD10CODE"] = value; }
        }

    /// <summary>
    /// Cihaz Adı/Taraf/Adet
    /// </summary>
        public YesNoEnum? LE_MachineName
        {
            get { return (YesNoEnum?)(int?)this["LE_MACHINENAME"]; }
            set { this["LE_MACHINENAME"] = value; }
        }

    /// <summary>
    /// Cihaz Adı Doğru mu
    /// </summary>
        public YesNoEnum? LE_MachineNameIsCorrect
        {
            get { return (YesNoEnum?)(int?)this["LE_MACHINENAMEISCORRECT"]; }
            set { this["LE_MACHINENAMEISCORRECT"] = value; }
        }

    /// <summary>
    /// Islak İmza
    /// </summary>
        public YesNoEnum? LE_WetSignature
        {
            get { return (YesNoEnum?)(int?)this["LE_WETSIGNATURE"]; }
            set { this["LE_WETSIGNATURE"] = value; }
        }

    /// <summary>
    /// Aktivite düzeyi (Ampute Mobilite Belirleme Skoru ? K seviyesi) 
    /// </summary>
        public string LE_HD_AktivityLevel
        {
            get { return (string)this["LE_HD_AKTIVITYLEVEL"]; }
            set { this["LE_HD_AKTIVITYLEVEL"] = value; }
        }

    /// <summary>
    /// Hastanın protez marka/model tercih dilekçesi var mı?
    /// </summary>
        public YesNoEnum? LE_HD_PreferencePetition
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_PREFERENCEPETITION"]; }
            set { this["LE_HD_PREFERENCEPETITION"] = value; }
        }

    /// <summary>
    /// Güdük bölgesinde soket uygulanmasına engel olabilecek yara, akıntı, dirençli ağrı vb. tıbbi sorun var mı?
    /// </summary>
        public YesNoEnum? LE_HD_StumpZone
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_STUMPZONE"]; }
            set { this["LE_HD_STUMPZONE"] = value; }
        }

    /// <summary>
    /// Protezin ağırlığı hasta tarafından tolere edilebilecek mi?
    /// </summary>
        public YesNoEnum? LE_HD_WeightTolerance
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_WEIGHTTOLERANCE"]; }
            set { this["LE_HD_WEIGHTTOLERANCE"] = value; }
        }

    /// <summary>
    /// Ampute ekstremitede kontraktür var mı?
    /// </summary>
        public YesNoEnum? LE_HD_Contracture
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_CONTRACTURE"]; }
            set { this["LE_HD_CONTRACTURE"] = value; }
        }

    /// <summary>
    /// Tek taraflı amputelerde diğer ekstremitede yürümeyi bozan veya engelleyen tıbbi sorun var mı?
    /// </summary>
        public YesNoEnum? LE_HD_SingleSideAmputate
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_SINGLESIDEAMPUTATE"]; }
            set { this["LE_HD_SINGLESIDEAMPUTATE"] = value; }
        }

    /// <summary>
    /// Ambulasyonu engelleyebilecek denge bozukluğu veya ataksi var mı?
    /// </summary>
        public YesNoEnum? LE_HD_Ambulation
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_AMBULATION"]; }
            set { this["LE_HD_AMBULATION"] = value; }
        }

    /// <summary>
    /// Kas-iskelet sistemi hastalığı var mı?
    /// </summary>
        public YesNoEnum? LE_HD_Musculoskeletal
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_MUSCULOSKELETAL"]; }
            set { this["LE_HD_MUSCULOSKELETAL"] = value; }
        }

    /// <summary>
    /// Nörolojik /nöromusküler hastalık var mı?
    /// </summary>
        public YesNoEnum? LE_HD_Neurological
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_NEUROLOGICAL"]; }
            set { this["LE_HD_NEUROLOGICAL"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler hastalık var mı?
    /// </summary>
        public YesNoEnum? LE_HD_Cardiovascular
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_CARDIOVASCULAR"]; }
            set { this["LE_HD_CARDIOVASCULAR"] = value; }
        }

    /// <summary>
    /// Pulmoner hastalık var mı?
    /// </summary>
        public YesNoEnum? LE_HD_Pulmonary
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_PULMONARY"]; }
            set { this["LE_HD_PULMONARY"] = value; }
        }

    /// <summary>
    /// Organ yetmezliği var mı?
    /// </summary>
        public YesNoEnum? LE_HD_OrganFailure
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_ORGANFAILURE"]; }
            set { this["LE_HD_ORGANFAILURE"] = value; }
        }

    /// <summary>
    /// Sistemik (HT,DM, Romatolojik, Endokrinolojik, vb.) hastalıklar var mı?
    /// </summary>
        public YesNoEnum? LE_HD_SystemicDisease
        {
            get { return (YesNoEnum?)(int?)this["LE_HD_SYSTEMICDISEASE"]; }
            set { this["LE_HD_SYSTEMICDISEASE"] = value; }
        }

    /// <summary>
    /// Hangi aktivite düzeyindeki hastalar için uygun?
    /// </summary>
        public string LE_TEM_WhichLevel
        {
            get { return (string)this["LE_TEM_WHICHLEVEL"]; }
            set { this["LE_TEM_WHICHLEVEL"] = value; }
        }

    /// <summary>
    /// Yürüyüşün salınım ve duruş faz özelliklerini kontrol edebilir mi?
    /// </summary>
        public YesNoEnum? LE_TEM_OscillationandPosture
        {
            get { return (YesNoEnum?)(int?)this["LE_TEM_OSCILLATIONANDPOSTURE"]; }
            set { this["LE_TEM_OSCILLATIONANDPOSTURE"] = value; }
        }

    /// <summary>
    /// Değişken yürüme hızlarına uyum sağlayabilir mi?
    /// </summary>
        public YesNoEnum? LE_TEM_WalkingSpeed
        {
            get { return (YesNoEnum?)(int?)this["LE_TEM_WALKINGSPEED"]; }
            set { this["LE_TEM_WALKINGSPEED"] = value; }
        }

    /// <summary>
    /// Değişken adım uzunluklarında yürümeye uyum sağlayabilir mi?
    /// </summary>
        public YesNoEnum? LE_TEM_StrideLength
        {
            get { return (YesNoEnum?)(int?)this["LE_TEM_STRIDELENGTH"]; }
            set { this["LE_TEM_STRIDELENGTH"] = value; }
        }

    /// <summary>
    /// Basamak çıkma özelliği var mı?
    /// </summary>
        public YesNoEnum? LE_TEM_StepClimbing
        {
            get { return (YesNoEnum?)(int?)this["LE_TEM_STEPCLIMBING"]; }
            set { this["LE_TEM_STEPCLIMBING"] = value; }
        }

    /// <summary>
    /// Geri geri yürüme özelliği var mı?
    /// </summary>
        public YesNoEnum? LE_TEM_WalkBackwards
        {
            get { return (YesNoEnum?)(int?)this["LE_TEM_WALKBACKWARDS"]; }
            set { this["LE_TEM_WALKBACKWARDS"] = value; }
        }

    /// <summary>
    /// Suya dayanıklı mı?
    /// </summary>
        public YesNoEnum? LE_TEM_Waterproof
        {
            get { return (YesNoEnum?)(int?)this["LE_TEM_WATERPROOF"]; }
            set { this["LE_TEM_WATERPROOF"] = value; }
        }

    /// <summary>
    /// Ambulasyonu engelleyebilecek denge bozukluğu veya ataksi var mı?
    /// </summary>
        public string LE_HD_Ambulation_Desc
        {
            get { return (string)this["LE_HD_AMBULATION_DESC"]; }
            set { this["LE_HD_AMBULATION_DESC"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler hastalık var mı?
    /// </summary>
        public string LE_HD_Cardiovascular_Desc
        {
            get { return (string)this["LE_HD_CARDIOVASCULAR_DESC"]; }
            set { this["LE_HD_CARDIOVASCULAR_DESC"] = value; }
        }

    /// <summary>
    /// Ampute ekstremitede kontraktür var mı?
    /// </summary>
        public string LE_HD_Contracture_Desc
        {
            get { return (string)this["LE_HD_CONTRACTURE_DESC"]; }
            set { this["LE_HD_CONTRACTURE_DESC"] = value; }
        }

    /// <summary>
    /// Kas-iskelet sistemi hastalığı var mı?
    /// </summary>
        public string LE_HD_Musculoskeletal_Desc
        {
            get { return (string)this["LE_HD_MUSCULOSKELETAL_DESC"]; }
            set { this["LE_HD_MUSCULOSKELETAL_DESC"] = value; }
        }

    /// <summary>
    /// Nörolojik /nöromusküler hastalık var mı?
    /// </summary>
        public string LE_HD_Neurological_Desc
        {
            get { return (string)this["LE_HD_NEUROLOGICAL_DESC"]; }
            set { this["LE_HD_NEUROLOGICAL_DESC"] = value; }
        }

    /// <summary>
    /// Organ yetmezliği var mı?
    /// </summary>
        public string LE_HD_OrganFailure_Desc
        {
            get { return (string)this["LE_HD_ORGANFAILURE_DESC"]; }
            set { this["LE_HD_ORGANFAILURE_DESC"] = value; }
        }

    /// <summary>
    /// Hastanın protez marka/model tercih dilekçesi var mı?
    /// </summary>
        public string LE_HD_PreferencePetition_Desc
        {
            get { return (string)this["LE_HD_PREFERENCEPETITION_DESC"]; }
            set { this["LE_HD_PREFERENCEPETITION_DESC"] = value; }
        }

    /// <summary>
    /// Pulmoner hastalık var mı?
    /// </summary>
        public string LE_HD_Pulmonary_Desc
        {
            get { return (string)this["LE_HD_PULMONARY_DESC"]; }
            set { this["LE_HD_PULMONARY_DESC"] = value; }
        }

    /// <summary>
    /// Tek taraflı amputelerde diğer ekstremitede yürümeyi bozan veya engelleyen tıbbi sorun var mı?
    /// </summary>
        public string LE_HD_SingleSideAmputate_Desc
        {
            get { return (string)this["LE_HD_SINGLESIDEAMPUTATE_DESC"]; }
            set { this["LE_HD_SINGLESIDEAMPUTATE_DESC"] = value; }
        }

    /// <summary>
    /// Güdük bölgesinde soket uygulanmasına engel olabilecek yara, akıntı, dirençli ağrı vb. tıbbi sorun var mı?
    /// </summary>
        public string LE_HD_StumpZone_Desc
        {
            get { return (string)this["LE_HD_STUMPZONE_DESC"]; }
            set { this["LE_HD_STUMPZONE_DESC"] = value; }
        }

    /// <summary>
    /// Sistemik (HT,DM, Romatolojik, Endokrinolojik, vb.) hastalıklar var mı?
    /// </summary>
        public string LE_HD_SystemicDisease_Desc
        {
            get { return (string)this["LE_HD_SYSTEMICDISEASE_DESC"]; }
            set { this["LE_HD_SYSTEMICDISEASE_DESC"] = value; }
        }

    /// <summary>
    /// Protezin ağırlığı hasta tarafından tolere edilebilecek mi?
    /// </summary>
        public string LE_HD_WeightTolerance_desc
        {
            get { return (string)this["LE_HD_WEIGHTTOLERANCE_DESC"]; }
            set { this["LE_HD_WEIGHTTOLERANCE_DESC"] = value; }
        }

    /// <summary>
    /// Yürüyüşün salınım ve duruş faz özelliklerini kontrol edebilir mi?
    /// </summary>
        public string LE_TEM_Oscillationand_Desc
        {
            get { return (string)this["LE_TEM_OSCILLATIONAND_DESC"]; }
            set { this["LE_TEM_OSCILLATIONAND_DESC"] = value; }
        }

    /// <summary>
    /// Basamak çıkma özelliği var mı?
    /// </summary>
        public string LE_TEM_StepClimbing_Desc
        {
            get { return (string)this["LE_TEM_STEPCLIMBING_DESC"]; }
            set { this["LE_TEM_STEPCLIMBING_DESC"] = value; }
        }

    /// <summary>
    /// Değişken adım uzunluklarında yürümeye uyum sağlayabilir mi?
    /// </summary>
        public string LE_TEM_StrideLength_Desc
        {
            get { return (string)this["LE_TEM_STRIDELENGTH_DESC"]; }
            set { this["LE_TEM_STRIDELENGTH_DESC"] = value; }
        }

    /// <summary>
    /// Geri geri yürüme özelliği var mı?
    /// </summary>
        public string LE_TEM_WalkBackwards_Desc
        {
            get { return (string)this["LE_TEM_WALKBACKWARDS_DESC"]; }
            set { this["LE_TEM_WALKBACKWARDS_DESC"] = value; }
        }

    /// <summary>
    /// Değişken yürüme hızlarına uyum sağlayabilir mi?
    /// </summary>
        public string LE_TEM_WalkingSpeed_Desc
        {
            get { return (string)this["LE_TEM_WALKINGSPEED_DESC"]; }
            set { this["LE_TEM_WALKINGSPEED_DESC"] = value; }
        }

    /// <summary>
    /// Suya dayanıklı mı?
    /// </summary>
        public string LE_TEM_Waterproof_Desc
        {
            get { return (string)this["LE_TEM_WATERPROOF_DESC"]; }
            set { this["LE_TEM_WATERPROOF_DESC"] = value; }
        }

    /// <summary>
    /// Tıbbi gerekçe (hastanın myoelektrik kontrollü kol protezi kullanımına ilişkin eğitim aldığı ve kullanabileceğinin yanında ayrıntılı değerlendirmeleri içeren ilgili uzman hekimlerin görüşü) yazılmış mı? 
    /// </summary>
        public YesNoEnum? UE_SK_MedicalReason
        {
            get { return (YesNoEnum?)(int?)this["UE_SK_MEDICALREASON"]; }
            set { this["UE_SK_MEDICALREASON"] = value; }
        }

    /// <summary>
    /// FTR uzman onayı var mı?           
    /// </summary>
        public YesNoEnum? UE_SK_FTRExpertApprove
        {
            get { return (YesNoEnum?)(int?)this["UE_SK_FTREXPERTAPPROVE"]; }
            set { this["UE_SK_FTREXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Başhekim  onayı var mı?
    /// </summary>
        public YesNoEnum? UE_SK_HeadDoctorApprove
        {
            get { return (YesNoEnum?)(int?)this["UE_SK_HEADDOCTORAPPROVE"]; }
            set { this["UE_SK_HEADDOCTORAPPROVE"] = value; }
        }

    /// <summary>
    /// Ortopedi Uzman Onayı
    /// </summary>
        public YesNoEnum? UE_SK_OrthopedicExpApprove
        {
            get { return (YesNoEnum?)(int?)this["UE_SK_ORTHOPEDICEXPAPPROVE"]; }
            set { this["UE_SK_ORTHOPEDICEXPAPPROVE"] = value; }
        }

    /// <summary>
    /// Psikiyatri Uzman Onayı
    /// </summary>
        public YesNoEnum? UE_SK_PsychiatricExpApprove
        {
            get { return (YesNoEnum?)(int?)this["UE_SK_PSYCHIATRICEXPAPPROVE"]; }
            set { this["UE_SK_PSYCHIATRICEXPAPPROVE"] = value; }
        }

    /// <summary>
    /// sEMG Belgelendirilmiş mi?
    /// </summary>
        public YesNoEnum? UE_SK_sEMG
        {
            get { return (YesNoEnum?)(int?)this["UE_SK_SEMG"]; }
            set { this["UE_SK_SEMG"] = value; }
        }

    /// <summary>
    /// 3. basamak sağlık kurumu
    /// </summary>
        public YesNoEnum? UE_SK_ThirdStepHealthInst
        {
            get { return (YesNoEnum?)(int?)this["UE_SK_THIRDSTEPHEALTHINST"]; }
            set { this["UE_SK_THIRDSTEPHEALTHINST"] = value; }
        }

    /// <summary>
    /// Hasta Adı Soyadı Var mı?
    /// </summary>
        public YesNoEnum? UE_RI_PatientNameSurname
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_PATIENTNAMESURNAME"]; }
            set { this["UE_RI_PATIENTNAMESURNAME"] = value; }
        }

    /// <summary>
    /// Medula Tesis Kodu
    /// </summary>
        public YesNoEnum? UE_RI_MedulaInsCode
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_MEDULAINSCODE"]; }
            set { this["UE_RI_MEDULAINSCODE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public YesNoEnum? UE_RI_Date
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_DATE"]; }
            set { this["UE_RI_DATE"] = value; }
        }

    /// <summary>
    /// Medula veya Protokol Numarası
    /// </summary>
        public YesNoEnum? UE_RI_MedulaOrProtocolNo
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_MEDULAORPROTOCOLNO"]; }
            set { this["UE_RI_MEDULAORPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Cihaz Adı/Taraf/Adet
    /// </summary>
        public YesNoEnum? UE_RI_MachineName
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_MACHINENAME"]; }
            set { this["UE_RI_MACHINENAME"] = value; }
        }

    /// <summary>
    /// Tanı ve ICD-10 Kodu
    /// </summary>
        public YesNoEnum? UE_RI_DiagnosAndICD10Code
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_DIAGNOSANDICD10CODE"]; }
            set { this["UE_RI_DIAGNOSANDICD10CODE"] = value; }
        }

    /// <summary>
    /// Cihaz Adı Doğru mu
    /// </summary>
        public YesNoEnum? UE_RI_MachineNameIsCorrect
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_MACHINENAMEISCORRECT"]; }
            set { this["UE_RI_MACHINENAMEISCORRECT"] = value; }
        }

    /// <summary>
    /// Islak İmza
    /// </summary>
        public YesNoEnum? UE_RI_WetSignature
        {
            get { return (YesNoEnum?)(int?)this["UE_RI_WETSIGNATURE"]; }
            set { this["UE_RI_WETSIGNATURE"] = value; }
        }

    /// <summary>
    /// Amputasyon seviyesi
    /// </summary>
        public string UE_HD_AmputationLevel
        {
            get { return (string)this["UE_HD_AMPUTATIONLEVEL"]; }
            set { this["UE_HD_AMPUTATIONLEVEL"] = value; }
        }

    /// <summary>
    /// Güdük uzunluğu (cm)
    /// </summary>
        public int? UE_HD_StumpLength
        {
            get { return (int?)this["UE_HD_STUMPLENGTH"]; }
            set { this["UE_HD_STUMPLENGTH"] = value; }
        }

    /// <summary>
    /// Hastanın protez marka/model tercih dilekçesi var mı?
    /// </summary>
        public YesNoEnum? UE_HD_PreferencePetition
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_PREFERENCEPETITION"]; }
            set { this["UE_HD_PREFERENCEPETITION"] = value; }
        }

    /// <summary>
    /// Protez uygulanabilmesi için yeterli güdük uzunluğuna sahip mi?
    /// </summary>
        public YesNoEnum? UE_HD_SufficientStumpLength
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_SUFFICIENTSTUMPLENGTH"]; }
            set { this["UE_HD_SUFFICIENTSTUMPLENGTH"] = value; }
        }

    /// <summary>
    /// Tek taraflı ampute  hastalar için; Ampute edilen taraf dominant ekstremite mi? veya non-dominant üst ekstremite amputasyon ile birlikte karşı ekstremiteyi kullanmasına engel tıbbi bir durum var mı?
    /// </summary>
        public YesNoEnum? UE_HD_SingleSideAmputate
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_SINGLESIDEAMPUTATE"]; }
            set { this["UE_HD_SINGLESIDEAMPUTATE"] = value; }
        }

    /// <summary>
    /// Tek taraflı amputelerde diğer ekstremitede yürümeyi bozan veya engelleyen tıbbi sorun var mı?
    /// </summary>
        public string UE_HD_SingleSideAmputate_Desc
        {
            get { return (string)this["UE_HD_SINGLESIDEAMPUTATE_DESC"]; }
            set { this["UE_HD_SINGLESIDEAMPUTATE_DESC"] = value; }
        }

    /// <summary>
    /// Protezin teknik özelliklerine uygun fonksiyonel hareketleri yerine getirebilecek mi?
    /// </summary>
        public YesNoEnum? UE_HD_FunctionalMovements
        {
            get { return (YesNoEnum?)(int?)this["UE_HD_FUNCTIONALMOVEMENTS"]; }
            set { this["UE_HD_FUNCTIONALMOVEMENTS"] = value; }
        }

    /// <summary>
    /// Yaralanma nedeni ve tarihi
    /// </summary>
        public string ATS_CauseOfInjury
        {
            get { return (string)this["ATS_CAUSEOFINJURY"]; }
            set { this["ATS_CAUSEOFINJURY"] = value; }
        }

    /// <summary>
    /// Kaçıncı Sandalyesi olduğu 
    /// </summary>
        public string ATS_ChairNumber
        {
            get { return (string)this["ATS_CHAIRNUMBER"]; }
            set { this["ATS_CHAIRNUMBER"] = value; }
        }

    /// <summary>
    /// Teslim alma tarihi
    /// </summary>
        public string ATS_DeliveryDate
        {
            get { return (string)this["ATS_DELIVERYDATE"]; }
            set { this["ATS_DELIVERYDATE"] = value; }
        }

    /// <summary>
    /// Protez tipi
    /// </summary>
        public string ATS_ChairType
        {
            get { return (string)this["ATS_CHAIRTYPE"]; }
            set { this["ATS_CHAIRTYPE"] = value; }
        }

    /// <summary>
    /// Raporda yazılan tekerlekli sandalye tipi:
    /// </summary>
        public string ATS_SK_ChairType
        {
            get { return (string)this["ATS_SK_CHAIRTYPE"]; }
            set { this["ATS_SK_CHAIRTYPE"] = value; }
        }

    /// <summary>
    /// Aktif TS yazılmasındaki 
    /// </summary>
        public string ATS_SK_MedicalReason
        {
            get { return (string)this["ATS_SK_MEDICALREASON"]; }
            set { this["ATS_SK_MEDICALREASON"] = value; }
        }

    /// <summary>
    /// 3. basamak sağlık kurumu
    /// </summary>
        public YesNoEnum? ATS_SK_ThirdStepHealthInst
        {
            get { return (YesNoEnum?)(int?)this["ATS_SK_THIRDSTEPHEALTHINST"]; }
            set { this["ATS_SK_THIRDSTEPHEALTHINST"] = value; }
        }

    /// <summary>
    /// FTR uzman onayı var mı?           
    /// </summary>
        public YesNoEnum? ATS_SK_FTRExpertApprove
        {
            get { return (YesNoEnum?)(int?)this["ATS_SK_FTREXPERTAPPROVE"]; }
            set { this["ATS_SK_FTREXPERTAPPROVE"] = value; }
        }

    /// <summary>
    /// Ortopedi Uzman Onayı
    /// </summary>
        public YesNoEnum? ATS_SK_OrthopedicExpApprove
        {
            get { return (YesNoEnum?)(int?)this["ATS_SK_ORTHOPEDICEXPAPPROVE"]; }
            set { this["ATS_SK_ORTHOPEDICEXPAPPROVE"] = value; }
        }

    /// <summary>
    /// Başhekim  onayı var mı?
    /// </summary>
        public YesNoEnum? ATS_SK_HeadDoctorApprove
        {
            get { return (YesNoEnum?)(int?)this["ATS_SK_HEADDOCTORAPPROVE"]; }
            set { this["ATS_SK_HEADDOCTORAPPROVE"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public YesNoEnum? ATS_RI_Date
        {
            get { return (YesNoEnum?)(int?)this["ATS_RI_DATE"]; }
            set { this["ATS_RI_DATE"] = value; }
        }

    /// <summary>
    /// Tanı ve ICD-10 Kodu
    /// </summary>
        public YesNoEnum? ATS_RI_DiagnosAndICD10Code
        {
            get { return (YesNoEnum?)(int?)this["ATS_RI_DIAGNOSANDICD10CODE"]; }
            set { this["ATS_RI_DIAGNOSANDICD10CODE"] = value; }
        }

    /// <summary>
    /// Cihaz Adı/Taraf/Adet
    /// </summary>
        public YesNoEnum? ATS_RI_MachineName
        {
            get { return (YesNoEnum?)(int?)this["ATS_RI_MACHINENAME"]; }
            set { this["ATS_RI_MACHINENAME"] = value; }
        }

    /// <summary>
    /// Medula Tesis Kodu
    /// </summary>
        public YesNoEnum? ATS_RI_MedulaInsCode
        {
            get { return (YesNoEnum?)(int?)this["ATS_RI_MEDULAINSCODE"]; }
            set { this["ATS_RI_MEDULAINSCODE"] = value; }
        }

    /// <summary>
    /// Medula veya Protokol Numarası
    /// </summary>
        public YesNoEnum? ATS_RI_MedulaOrProtocolNo
        {
            get { return (YesNoEnum?)(int?)this["ATS_RI_MEDULAORPROTOCOLNO"]; }
            set { this["ATS_RI_MEDULAORPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Hasta Adı Soyadı Var mı?
    /// </summary>
        public YesNoEnum? ATS_RI_PatientNameSurname
        {
            get { return (YesNoEnum?)(int?)this["ATS_RI_PATIENTNAMESURNAME"]; }
            set { this["ATS_RI_PATIENTNAMESURNAME"] = value; }
        }

    /// <summary>
    /// Islak İmza
    /// </summary>
        public YesNoEnum? ATS_RI_WetSignature
        {
            get { return (YesNoEnum?)(int?)this["ATS_RI_WETSIGNATURE"]; }
            set { this["ATS_RI_WETSIGNATURE"] = value; }
        }

    /// <summary>
    /// ne kadar mesafe sürebiliyor?
    /// </summary>
        public string ATS_HD_ChairDistance
        {
            get { return (string)this["ATS_HD_CHAIRDISTANCE"]; }
            set { this["ATS_HD_CHAIRDISTANCE"] = value; }
        }

    /// <summary>
    /// Toplum içi ambulasyon 
    /// </summary>
        public bool? ATS_HD_INTRACOMMUNITY
        {
            get { return (bool?)this["ATS_HD_INTRACOMMUNITY"]; }
            set { this["ATS_HD_INTRACOMMUNITY"] = value; }
        }

    /// <summary>
    /// Terapötik ambulasyon  
    /// </summary>
        public bool? ATS_HD_Therapeutic
        {
            get { return (bool?)this["ATS_HD_THERAPEUTIC"]; }
            set { this["ATS_HD_THERAPEUTIC"] = value; }
        }

    /// <summary>
    /// Ambulasyonu yok 
    /// </summary>
        public bool? ATS_HD_NOAMBULATION
        {
            get { return (bool?)this["ATS_HD_NOAMBULATION"]; }
            set { this["ATS_HD_NOAMBULATION"] = value; }
        }

    /// <summary>
    /// alt ekstremitelerini kullanabiliyor mu
    /// </summary>
        public YesNoEnum? ATS_HD_USELOWEREXTREMITIES
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_USELOWEREXTREMITIES"]; }
            set { this["ATS_HD_USELOWEREXTREMITIES"] = value; }
        }

    /// <summary>
    /// Güdük bölgesinde soket uygulanmasına engel olabilecek yara, akıntı, dirençli ağrı vb. tıbbi sorun var mı?
    /// </summary>
        public string ATS_HD_UseLowerExtremity_Desc
        {
            get { return (string)this["ATS_HD_USELOWEREXTREMITY_DESC"]; }
            set { this["ATS_HD_USELOWEREXTREMITY_DESC"] = value; }
        }

    /// <summary>
    /// Hastalığı sürekli mi?
    /// </summary>
        public YesNoEnum? ATS_HD_ConstantCondition
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_CONSTANTCONDITION"]; }
            set { this["ATS_HD_CONSTANTCONDITION"] = value; }
        }

    /// <summary>
    /// Hastanın tekerlekli sandalye marka/model 
    /// </summary>
        public YesNoEnum? ATS_HD_ChairModel
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_CHAIRMODEL"]; }
            set { this["ATS_HD_CHAIRMODEL"] = value; }
        }

    /// <summary>
    /// Tekerlekli Sandalyeyi Kendisi Kullanabiliyor mu?  
    /// </summary>
        public YesNoEnum? ATS_HD_UseHimself
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_USEHIMSELF"]; }
            set { this["ATS_HD_USEHIMSELF"] = value; }
        }

    /// <summary>
    /// deformitesi var mı
    /// </summary>
        public YesNoEnum? ATS_HD_Deformity
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_DEFORMITY"]; }
            set { this["ATS_HD_DEFORMITY"] = value; }
        }

    /// <summary>
    /// Eklem kontraktürü var mı?
    /// </summary>
        public YesNoEnum? ATS_HD_Contracture
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_CONTRACTURE"]; }
            set { this["ATS_HD_CONTRACTURE"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler hastalık var mı?
    /// </summary>
        public YesNoEnum? ATS_HD_Cardiovascular
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_CARDIOVASCULAR"]; }
            set { this["ATS_HD_CARDIOVASCULAR"] = value; }
        }

    /// <summary>
    /// Pulmoner hastalık var mı?
    /// </summary>
        public YesNoEnum? ATS_HD_Pulmonary
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_PULMONARY"]; }
            set { this["ATS_HD_PULMONARY"] = value; }
        }

    /// <summary>
    /// Organ yetmezliği var mı?
    /// </summary>
        public YesNoEnum? ATS_HD_OrganFailure
        {
            get { return (YesNoEnum?)(int?)this["ATS_HD_ORGANFAILURE"]; }
            set { this["ATS_HD_ORGANFAILURE"] = value; }
        }

    /// <summary>
    /// Hastalığı sürekli mi?
    /// </summary>
        public string ATS_HD_ConstantCondition_Desc
        {
            get { return (string)this["ATS_HD_CONSTANTCONDITION_DESC"]; }
            set { this["ATS_HD_CONSTANTCONDITION_DESC"] = value; }
        }

    /// <summary>
    /// marka/model tercih dilekçesi var mı?
    /// </summary>
        public string ATS_HD_ChairModel_Desc
        {
            get { return (string)this["ATS_HD_CHAIRMODEL_DESC"]; }
            set { this["ATS_HD_CHAIRMODEL_DESC"] = value; }
        }

    /// <summary>
    /// Kendisi Kullanabiliyor mu?  
    /// </summary>
        public string ATS_HD_UseHimself_Desc
        {
            get { return (string)this["ATS_HD_USEHIMSELF_DESC"]; }
            set { this["ATS_HD_USEHIMSELF_DESC"] = value; }
        }

    /// <summary>
    /// deformitesi 
    /// </summary>
        public string ATS_HD_Deformity_Desc
        {
            get { return (string)this["ATS_HD_DEFORMITY_DESC"]; }
            set { this["ATS_HD_DEFORMITY_DESC"] = value; }
        }

    /// <summary>
    /// Eklem kontraktürü var mı?
    /// </summary>
        public string ATS_HD_Contracture_Desc
        {
            get { return (string)this["ATS_HD_CONTRACTURE_DESC"]; }
            set { this["ATS_HD_CONTRACTURE_DESC"] = value; }
        }

    /// <summary>
    /// Kardiyovasküler hastalık var mı?
    /// </summary>
        public string ATS_HD_Cardiovascular_Desc
        {
            get { return (string)this["ATS_HD_CARDIOVASCULAR_DESC"]; }
            set { this["ATS_HD_CARDIOVASCULAR_DESC"] = value; }
        }

    /// <summary>
    /// Pulmoner hastalık var mı?
    /// </summary>
        public string ATS_HD_Pulmonary_Desc
        {
            get { return (string)this["ATS_HD_PULMONARY_DESC"]; }
            set { this["ATS_HD_PULMONARY_DESC"] = value; }
        }

    /// <summary>
    /// Organ yetmezliği var mı?
    /// </summary>
        public string ATS_HD_OrganFailure_Desc
        {
            get { return (string)this["ATS_HD_ORGANFAILURE_DESC"]; }
            set { this["ATS_HD_ORGANFAILURE_DESC"] = value; }
        }

        protected LowerExtremity(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LowerExtremity(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LowerExtremity(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LowerExtremity(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LowerExtremity(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LOWEREXTREMITY", dataRow) { }
        protected LowerExtremity(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LOWEREXTREMITY", dataRow, isImported) { }
        public LowerExtremity(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LowerExtremity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LowerExtremity() : base() { }

    }
}