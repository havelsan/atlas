
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Pathology")] 

    /// <summary>
    /// Patoloji
    /// </summary>
    public  partial class Pathology : EpisodeActionWithDiagnosis, IAllocateSpeciality, IWorkListPathology, ITreatmentMaterialCollection, ICheckPaid
    {
        public class PathologyList : TTObjectCollection<Pathology> { }
                    
        public class ChildPathologyCollection : TTObject.TTChildObjectCollection<Pathology>
        {
            public ChildPathologyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologyTestReqStateInfoNQL_Class : TTReportNqlObject 
        {
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Matprtno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reqdocphonenumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQDOCPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Reqdocname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQDOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public UserTitleEnum? Reqdoctitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQDOCTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Reqdocspeciality
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQDOCSPECIALITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Respdocname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPDOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Respdoctel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPDOCTEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Assistantdocname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSISTANTDOCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Assistantdoctel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSISTANTDOCTEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["PHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologyTestReqStateInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestReqStateInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestReqStateInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyTestRequestInfoStickerNQL_Class : TTReportNqlObject 
        {
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

            public string Matprtno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologyTestRequestInfoStickerNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestRequestInfoStickerNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestRequestInfoStickerNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyTestReportQuery_Class : TTReportNqlObject 
        {
            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologyTestReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyTestResultPatientInfoReportQuery_Class : TTReportNqlObject 
        {
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

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public Object Cityname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CITYNAME"]);
                }
            }

            public string Townname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOWNNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sorumludoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SORUMLUDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public PathologyTestResultPatientInfoReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestResultPatientInfoReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestResultPatientInfoReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyTestResultReportQuery_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object MacroscopyInspection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MACROSCOPYINSPECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MACROSCOPYINSPECTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPrefix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPREFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPREFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultEntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RESULTENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADDITIONALINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? BlockCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BLOCKCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IntraoperativeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTRAOPERATIVECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["INTRAOPERATIVECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? LamCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LAMCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LAMCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnoseEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSEENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["FREEDIAGNOSEENTRY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonForRepeatation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORREPEATATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONFORREPEATATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPostFix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPOSTFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPOSTFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? SeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Liquid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIQUID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LIQUID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object RemoteSpecialDoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMOTESPECIALDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REMOTESPECIALDOCTOR"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? HasSpecialProcedures
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASSPECIALPROCEDURES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASSPECIALPROCEDURES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIRIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SubMatPrtNoSuffixNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SubMatPrtNoSuffixString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SendedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDEDMATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["NUMBEROFMATERIALS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SendToApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDTOAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDTOAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsBiopsy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISBIOPSY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISBIOPSY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCytology
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCYTOLOGY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISCYTOLOGY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PathologyArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATHOLOGYARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BiopsySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIOPSYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIOPSYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CytologySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYTOLOGYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["CYTOLOGYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public PathologyTestResultReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestResultReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestResultReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyStatisticsByInjection_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object MacroscopyInspection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MACROSCOPYINSPECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MACROSCOPYINSPECTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPrefix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPREFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPREFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultEntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RESULTENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADDITIONALINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? BlockCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BLOCKCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IntraoperativeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTRAOPERATIVECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["INTRAOPERATIVECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? LamCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LAMCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LAMCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnoseEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSEENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["FREEDIAGNOSEENTRY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonForRepeatation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORREPEATATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONFORREPEATATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPostFix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPOSTFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPOSTFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? SeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Liquid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIQUID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LIQUID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object RemoteSpecialDoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMOTESPECIALDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REMOTESPECIALDOCTOR"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? HasSpecialProcedures
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASSPECIALPROCEDURES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASSPECIALPROCEDURES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIRIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SubMatPrtNoSuffixNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SubMatPrtNoSuffixString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SendedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDEDMATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["NUMBEROFMATERIALS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SendToApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDTOAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDTOAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsBiopsy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISBIOPSY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISBIOPSY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCytology
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCYTOLOGY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISCYTOLOGY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PathologyArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATHOLOGYARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BiopsySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIOPSYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIOPSYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CytologySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYTOLOGYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["CYTOLOGYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyStatisticsByInjection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyStatisticsByInjection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyStatisticsByInjection_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyTestByEpisode_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object MacroscopyInspection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MACROSCOPYINSPECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MACROSCOPYINSPECTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPrefix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPREFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPREFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultEntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RESULTENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADDITIONALINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? BlockCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BLOCKCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IntraoperativeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTRAOPERATIVECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["INTRAOPERATIVECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? LamCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LAMCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LAMCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnoseEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSEENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["FREEDIAGNOSEENTRY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonForRepeatation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORREPEATATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONFORREPEATATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPostFix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPOSTFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPOSTFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? SeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Liquid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIQUID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LIQUID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object RemoteSpecialDoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMOTESPECIALDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REMOTESPECIALDOCTOR"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? HasSpecialProcedures
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASSPECIALPROCEDURES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASSPECIALPROCEDURES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIRIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SubMatPrtNoSuffixNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SubMatPrtNoSuffixString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SendedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDEDMATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["NUMBEROFMATERIALS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SendToApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDTOAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDTOAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsBiopsy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISBIOPSY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISBIOPSY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCytology
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCYTOLOGY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISCYTOLOGY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PathologyArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATHOLOGYARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BiopsySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIOPSYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIOPSYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CytologySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYTOLOGYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["CYTOLOGYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyTestByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyTestByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyTestByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByPatTestFilterExpressionReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Assistantdoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSISTANTDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetByPatTestFilterExpressionReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByPatTestFilterExpressionReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByPatTestFilterExpressionReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByPatTestWorklistDateReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public string Fromresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public Object Patientgroup
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Assistantdoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSISTANTDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetByPatTestWorklistDateReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByPatTestWorklistDateReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByPatTestWorklistDateReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyTestBySubEpisode_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object MacroscopyInspection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MACROSCOPYINSPECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MACROSCOPYINSPECTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPrefix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPREFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPREFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultEntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RESULTENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADDITIONALINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? BlockCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BLOCKCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IntraoperativeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTRAOPERATIVECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["INTRAOPERATIVECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? LamCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LAMCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LAMCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnoseEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSEENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["FREEDIAGNOSEENTRY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonForRepeatation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORREPEATATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONFORREPEATATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPostFix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPOSTFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPOSTFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? SeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Liquid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIQUID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LIQUID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object RemoteSpecialDoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMOTESPECIALDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REMOTESPECIALDOCTOR"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? HasSpecialProcedures
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASSPECIALPROCEDURES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASSPECIALPROCEDURES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIRIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SubMatPrtNoSuffixNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SubMatPrtNoSuffixString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SendedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDEDMATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["NUMBEROFMATERIALS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SendToApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDTOAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDTOAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsBiopsy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISBIOPSY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISBIOPSY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCytology
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCYTOLOGY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISCYTOLOGY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PathologyArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATHOLOGYARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BiopsySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIOPSYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIOPSYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CytologySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYTOLOGYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["CYTOLOGYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyTestBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyTestBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyTestBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyStatisticsNewNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? AssistantDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ASSISTANTDOCTOR"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SNOMEDDIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SNOMEDDIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnose_code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSE_CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Diagnose_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIAGNOSE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologyStatisticsNewNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyStatisticsNewNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyStatisticsNewNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetPathologyTest_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? RequestDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTDOCTOR"]);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
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

            public Guid? Mastres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTRES"]);
                }
            }

            public Guid? Fromres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["FROMRES"]);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public OLAP_GetPathologyTest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPathologyTest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPathologyTest_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCancelledPathologyTest_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCancelledPathologyTest_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCancelledPathologyTest_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCancelledPathologyTest_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyStatisticsNQL_Class : TTReportNqlObject 
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

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string OrderObject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDEROBJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ORDEROBJECT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionForWorkList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONFORWORKLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreEpisodeStateOnUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREEPISODESTATEONUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? AdmissionQueueNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONQUEUENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object MacroscopyInspection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MACROSCOPYINSPECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MACROSCOPYINSPECTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPrefix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPREFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPREFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultEntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RESULTENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AdditionalInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ADDITIONALINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? BlockCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOCKCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BLOCKCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IntraoperativeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTRAOPERATIVECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["INTRAOPERATIVECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? LamCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LAMCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LAMCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string FreeDiagnoseEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEDIAGNOSEENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["FREEDIAGNOSEENTRY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReasonForRepeatation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORREPEATATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REASONFORREPEATATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaterialPrtNoPostFix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRTNOPOSTFIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALPRTNOPOSTFIX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? SeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? Liquid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIQUID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["LIQUID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object RemoteSpecialDoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REMOTESPECIALDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REMOTESPECIALDOCTOR"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? HasSpecialProcedures
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASSPECIALPROCEDURES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASSPECIALPROCEDURES"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIRIM"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string raporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SubMatPrtNoSuffixNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SubMatPrtNoSuffixString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBMATPRTNOSUFFIXSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SUBMATPRTNOSUFFIXSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SendedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDEDMATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TechnicianNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["NUMBEROFMATERIALS"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SendToApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDTOAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["SENDTOAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsBiopsy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISBIOPSY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISBIOPSY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsCytology
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCYTOLOGY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ISCYTOLOGY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PathologyArchiveNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGYARCHIVENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["PATHOLOGYARCHIVENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? BiopsySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIOPSYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["BIOPSYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? CytologySeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CYTOLOGYSEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["CYTOLOGYSEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyStatisticsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyStatisticsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyStatisticsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyTestRequestBarcodeNQL_Class : TTReportNqlObject 
        {
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

            public string Matprtno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologyTestRequestBarcodeNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyTestRequestBarcodeNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyTestRequestBarcodeNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyTestStatisticsByFilter_Class : TTReportNqlObject 
        {
            public Guid? Pathologytestobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATHOLOGYTESTOBJECTID"]);
                }
            }

            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
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

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public Object Diagnosecomment
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIAGNOSECOMMENT"]);
                }
            }

            public Object Macroscopi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MACROSCOPI"]);
                }
            }

            public Object Microscopi
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MICROSCOPI"]);
                }
            }

            public string Responsibledoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Specialdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Snomeddiagnose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SNOMEDDIAGNOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SNOMEDDIAGNOSISDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Panicnotification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PANICNOTIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SNOMEDDIAGNOSISGRID"].AllPropertyDefs["PANICDIAGNOSISNOTIFICATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Consultantdoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONSULTANTDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyTestStatisticsByFilter_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyTestStatisticsByFilter_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyTestStatisticsByFilter_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoForPathology_Class : TTReportNqlObject 
        {
            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Requestedclinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDCLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object Macroscopy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MACROSCOPY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MACROSCOPY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Microscopy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MICROSCOPY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["MICROSCOPY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PathologicDiagnosis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGICDIAGNOSIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["PATHOLOGICDIAGNOSIS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYMATERIAL"].AllPropertyDefs["NOTE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetOldInfoForPathology_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForPathology_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForPathology_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldInfoCountPathology_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetOldInfoCountPathology_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoCountPathology_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoCountPathology_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyStatesForTIG_Class : TTReportNqlObject 
        {
            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public GetPathologyStatesForTIG_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyStatesForTIG_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyStatesForTIG_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologiesBySubepisodeID_Class : TTReportNqlObject 
        {
            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReportDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Pathologyid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATHOLOGYID"]);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string Patdoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologiesBySubepisodeID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologiesBySubepisodeID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologiesBySubepisodeID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologySubepisodesByPatientID_Class : TTReportNqlObject 
        {
            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Ressectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Subepisodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEOBJECTID"]);
                }
            }

            public GetPathologySubepisodesByPatientID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologySubepisodesByPatientID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologySubepisodesByPatientID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyForWL_Class : TTReportNqlObject 
        {
            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Fromresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Subepisodeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SUBEPISODEID"]);
                }
            }

            public SubEpisodeStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (SubEpisodeStatusEnum?)(int)dataType.ConvertValue(val);
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

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Admissionprotocolno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Admissionresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMISSIONRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyForWL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyByObjectID_Class : TTReportNqlObject 
        {
            public Guid? Pathologyobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATHOLOGYOBJECTID"]);
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

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cinsiyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Islemiyapandoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMIYAPANDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Protokolnumarasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOKOLNUMARASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Istektarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEKTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Materyalkabultarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERYALKABULTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Onaytarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ONAYTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Raportarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["REPORTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Istekyapandoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEKYAPANDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Uzmandoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMANDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Asistandoktor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASISTANDOKTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materyalkabulnotu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERYALKABULNOTU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Teknisyennotu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEKNISYENNOTU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["TECHNICIANNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fromres
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FROMRES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPathologyByObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyByObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyByObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnapprovedPathologyReports_Class : TTReportNqlObject 
        {
            public string MatPrtNoString
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATPRTNOSTRING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].AllPropertyDefs["MATPRTNOSTRING"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Pathologyid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATHOLOGYID"]);
                }
            }

            public GetUnapprovedPathologyReports_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnapprovedPathologyReports_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnapprovedPathologyReports_Class() : base() { }
        }

        public static class States
        {
            public static Guid Procedure { get { return new Guid("61ba736a-0a59-44bd-9e6d-261256f0f372"); } }
            public static Guid SentToApprovement { get { return new Guid("aaf6555b-a875-45bf-af50-e82d10a9cfb3"); } }
            public static Guid Approvement { get { return new Guid("2548a4ff-174f-4957-9551-8dcbfb6e0545"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("0353e400-c663-4c21-8d30-7e50f2befc0b"); } }
            public static Guid Report { get { return new Guid("e8a45f00-814f-4194-b719-e0d5889f47c7"); } }
        }

        public static BindingList<Pathology.PathologyTestReqStateInfoNQL_Class> PathologyTestReqStateInfoNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestReqStateInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestReqStateInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestReqStateInfoNQL_Class> PathologyTestReqStateInfoNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestReqStateInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestReqStateInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestRequestInfoStickerNQL_Class> PathologyTestRequestInfoStickerNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestRequestInfoStickerNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestRequestInfoStickerNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestRequestInfoStickerNQL_Class> PathologyTestRequestInfoStickerNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestRequestInfoStickerNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestRequestInfoStickerNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestReportQuery_Class> PathologyTestReportQuery(string PARAMPATOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATOBJID", PARAMPATOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestReportQuery_Class> PathologyTestReportQuery(TTObjectContext objectContext, string PARAMPATOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATOBJID", PARAMPATOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestResultPatientInfoReportQuery_Class> PathologyTestResultPatientInfoReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestResultPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestResultPatientInfoReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestResultPatientInfoReportQuery_Class> PathologyTestResultPatientInfoReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestResultPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestResultPatientInfoReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Pathology>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Pathology.PathologyTestResultReportQuery_Class> PathologyTestResultReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestResultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestResultReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestResultReportQuery_Class> PathologyTestResultReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestResultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestResultReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology> GetPatTestByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPatTestByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<Pathology>(queryDef, paramList);
        }

        public static BindingList<Pathology.GetPathologyStatisticsByInjection_Class> GetPathologyStatisticsByInjection(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatisticsByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatisticsByInjection_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetPathologyStatisticsByInjection_Class> GetPathologyStatisticsByInjection(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatisticsByInjection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatisticsByInjection_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetPathologyTestByEpisode_Class> GetPathologyTestByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyTestByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyTestByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyTestByEpisode_Class> GetPathologyTestByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyTestByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyTestByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology> GetByWLFilterExpression(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetByWLFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Pathology>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Pathology.GetByPatTestFilterExpressionReport_Class> GetByPatTestFilterExpressionReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetByPatTestFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetByPatTestFilterExpressionReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetByPatTestFilterExpressionReport_Class> GetByPatTestFilterExpressionReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetByPatTestFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetByPatTestFilterExpressionReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetByPatTestWorklistDateReport_Class> GetByPatTestWorklistDateReport(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetByPatTestWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Pathology.GetByPatTestWorklistDateReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetByPatTestWorklistDateReport_Class> GetByPatTestWorklistDateReport(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetByPatTestWorklistDateReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Pathology.GetByPatTestWorklistDateReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetPathologyTestBySubEpisode_Class> GetPathologyTestBySubEpisode(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyTestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyTestBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyTestBySubEpisode_Class> GetPathologyTestBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyTestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyTestBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology> GetPatTestBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPatTestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<Pathology>(queryDef, paramList);
        }

        public static BindingList<Pathology.GetPathologyStatisticsNewNQL_Class> GetPathologyStatisticsNewNQL(string ASSISTANTDOCTOR, int ASSISTANTDOCTOR_FLG, string MATPRTNO, int MATPRTNO_FLG, string RESPONSIBLEDOCTOR, int RESPONSIBLEDOCTOR_FLG, string SPECIALDOCTOR, int SPECIALDOCTOR_FLG, DateTime ENDDATE, DateTime STARTDATE, int TESTCATEGORY_FLG, string UNIQUEREFNO, int UNIQUEREFNO_FLG, int TEST_FLG, string SNOMEDDIAGNOSIS, int SNOMEDDIAGNOSIS_FLG, string DIAGNOSIS, int DIAGNOSIS_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatisticsNewNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ASSISTANTDOCTOR", ASSISTANTDOCTOR);
            paramList.Add("ASSISTANTDOCTOR_FLG", ASSISTANTDOCTOR_FLG);
            paramList.Add("MATPRTNO", MATPRTNO);
            paramList.Add("MATPRTNO_FLG", MATPRTNO_FLG);
            paramList.Add("RESPONSIBLEDOCTOR", RESPONSIBLEDOCTOR);
            paramList.Add("RESPONSIBLEDOCTOR_FLG", RESPONSIBLEDOCTOR_FLG);
            paramList.Add("SPECIALDOCTOR", SPECIALDOCTOR);
            paramList.Add("SPECIALDOCTOR_FLG", SPECIALDOCTOR_FLG);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("TESTCATEGORY_FLG", TESTCATEGORY_FLG);
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);
            paramList.Add("UNIQUEREFNO_FLG", UNIQUEREFNO_FLG);
            paramList.Add("TEST_FLG", TEST_FLG);
            paramList.Add("SNOMEDDIAGNOSIS", SNOMEDDIAGNOSIS);
            paramList.Add("SNOMEDDIAGNOSIS_FLG", SNOMEDDIAGNOSIS_FLG);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);
            paramList.Add("DIAGNOSIS_FLG", DIAGNOSIS_FLG);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatisticsNewNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyStatisticsNewNQL_Class> GetPathologyStatisticsNewNQL(TTObjectContext objectContext, string ASSISTANTDOCTOR, int ASSISTANTDOCTOR_FLG, string MATPRTNO, int MATPRTNO_FLG, string RESPONSIBLEDOCTOR, int RESPONSIBLEDOCTOR_FLG, string SPECIALDOCTOR, int SPECIALDOCTOR_FLG, DateTime ENDDATE, DateTime STARTDATE, int TESTCATEGORY_FLG, string UNIQUEREFNO, int UNIQUEREFNO_FLG, int TEST_FLG, string SNOMEDDIAGNOSIS, int SNOMEDDIAGNOSIS_FLG, string DIAGNOSIS, int DIAGNOSIS_FLG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatisticsNewNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ASSISTANTDOCTOR", ASSISTANTDOCTOR);
            paramList.Add("ASSISTANTDOCTOR_FLG", ASSISTANTDOCTOR_FLG);
            paramList.Add("MATPRTNO", MATPRTNO);
            paramList.Add("MATPRTNO_FLG", MATPRTNO_FLG);
            paramList.Add("RESPONSIBLEDOCTOR", RESPONSIBLEDOCTOR);
            paramList.Add("RESPONSIBLEDOCTOR_FLG", RESPONSIBLEDOCTOR_FLG);
            paramList.Add("SPECIALDOCTOR", SPECIALDOCTOR);
            paramList.Add("SPECIALDOCTOR_FLG", SPECIALDOCTOR_FLG);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("TESTCATEGORY_FLG", TESTCATEGORY_FLG);
            paramList.Add("UNIQUEREFNO", UNIQUEREFNO);
            paramList.Add("UNIQUEREFNO_FLG", UNIQUEREFNO_FLG);
            paramList.Add("TEST_FLG", TEST_FLG);
            paramList.Add("SNOMEDDIAGNOSIS", SNOMEDDIAGNOSIS);
            paramList.Add("SNOMEDDIAGNOSIS_FLG", SNOMEDDIAGNOSIS_FLG);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);
            paramList.Add("DIAGNOSIS_FLG", DIAGNOSIS_FLG);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatisticsNewNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.OLAP_GetPathologyTest_Class> OLAP_GetPathologyTest(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["OLAP_GetPathologyTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Pathology.OLAP_GetPathologyTest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.OLAP_GetPathologyTest_Class> OLAP_GetPathologyTest(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["OLAP_GetPathologyTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Pathology.OLAP_GetPathologyTest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.OLAP_GetCancelledPathologyTest_Class> OLAP_GetCancelledPathologyTest(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["OLAP_GetCancelledPathologyTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Pathology.OLAP_GetCancelledPathologyTest_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.OLAP_GetCancelledPathologyTest_Class> OLAP_GetCancelledPathologyTest(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["OLAP_GetCancelledPathologyTest"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<Pathology.OLAP_GetCancelledPathologyTest_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology> GetByFilterExpression(TTObjectContext objectContext, DateTime BIRTHDAYMIN, DateTime BIRTHDAYMAX, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetByFilterExpression"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("BIRTHDAYMIN", BIRTHDAYMIN);
            paramList.Add("BIRTHDAYMAX", BIRTHDAYMAX);

            return ((ITTQuery)objectContext).QueryObjects<Pathology>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Pathology.GetPathologyStatisticsNQL_Class> GetPathologyStatisticsNQL(string CARDNO, string MATPRTNO, string DIAGNOSIS, string SNOMEDDIAGNOSIS, DateTime STARTDATE, DateTime ENDDATE, string RESPONSIBLEDOCTOR, string SPECIALDOCTOR, string ASSISTANTDOCTOR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatisticsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDNO", CARDNO);
            paramList.Add("MATPRTNO", MATPRTNO);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);
            paramList.Add("SNOMEDDIAGNOSIS", SNOMEDDIAGNOSIS);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESPONSIBLEDOCTOR", RESPONSIBLEDOCTOR);
            paramList.Add("SPECIALDOCTOR", SPECIALDOCTOR);
            paramList.Add("ASSISTANTDOCTOR", ASSISTANTDOCTOR);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatisticsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyStatisticsNQL_Class> GetPathologyStatisticsNQL(TTObjectContext objectContext, string CARDNO, string MATPRTNO, string DIAGNOSIS, string SNOMEDDIAGNOSIS, DateTime STARTDATE, DateTime ENDDATE, string RESPONSIBLEDOCTOR, string SPECIALDOCTOR, string ASSISTANTDOCTOR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatisticsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CARDNO", CARDNO);
            paramList.Add("MATPRTNO", MATPRTNO);
            paramList.Add("DIAGNOSIS", DIAGNOSIS);
            paramList.Add("SNOMEDDIAGNOSIS", SNOMEDDIAGNOSIS);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESPONSIBLEDOCTOR", RESPONSIBLEDOCTOR);
            paramList.Add("SPECIALDOCTOR", SPECIALDOCTOR);
            paramList.Add("ASSISTANTDOCTOR", ASSISTANTDOCTOR);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatisticsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestRequestBarcodeNQL_Class> PathologyTestRequestBarcodeNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestRequestBarcodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestRequestBarcodeNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.PathologyTestRequestBarcodeNQL_Class> PathologyTestRequestBarcodeNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["PathologyTestRequestBarcodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<Pathology.PathologyTestRequestBarcodeNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyTestStatisticsByFilter_Class> GetPathologyTestStatisticsByFilter(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyTestStatisticsByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyTestStatisticsByFilter_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetPathologyTestStatisticsByFilter_Class> GetPathologyTestStatisticsByFilter(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyTestStatisticsByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyTestStatisticsByFilter_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Patoloji Geçmişi
    /// </summary>
        public static BindingList<Pathology.GetOldInfoForPathology_Class> GetOldInfoForPathology(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetOldInfoForPathology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pathology.GetOldInfoForPathology_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Patoloji Geçmişi
    /// </summary>
        public static BindingList<Pathology.GetOldInfoForPathology_Class> GetOldInfoForPathology(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetOldInfoForPathology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pathology.GetOldInfoForPathology_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Patloji Geçmiş Sayısı
    /// </summary>
        public static BindingList<Pathology.GetOldInfoCountPathology_Class> GetOldInfoCountPathology(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetOldInfoCountPathology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pathology.GetOldInfoCountPathology_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Patloji Geçmiş Sayısı
    /// </summary>
        public static BindingList<Pathology.GetOldInfoCountPathology_Class> GetOldInfoCountPathology(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetOldInfoCountPathology"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Pathology.GetOldInfoCountPathology_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetPathologyStatesForTIG_Class> GetPathologyStatesForTIG(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatesForTIG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatesForTIG_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyStatesForTIG_Class> GetPathologyStatesForTIG(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyStatesForTIG"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyStatesForTIG_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologiesBySubepisodeID_Class> GetPathologiesBySubepisodeID(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologiesBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologiesBySubepisodeID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologiesBySubepisodeID_Class> GetPathologiesBySubepisodeID(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologiesBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologiesBySubepisodeID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologySubepisodesByPatientID_Class> GetPathologySubepisodesByPatientID(Guid PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologySubepisodesByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologySubepisodesByPatientID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologySubepisodesByPatientID_Class> GetPathologySubepisodesByPatientID(TTObjectContext objectContext, Guid PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologySubepisodesByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologySubepisodesByPatientID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyForWL_Class> GetPathologyForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetPathologyForWL_Class> GetPathologyForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Pathology.GetPathologyByObjectID_Class> GetPathologyByObjectID(Guid PATHOLOGYOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYOBJECTID", PATHOLOGYOBJECTID);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyByObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetPathologyByObjectID_Class> GetPathologyByObjectID(TTObjectContext objectContext, Guid PATHOLOGYOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetPathologyByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATHOLOGYOBJECTID", PATHOLOGYOBJECTID);

            return TTReportNqlObject.QueryObjects<Pathology.GetPathologyByObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetUnapprovedPathologyReports_Class> GetUnapprovedPathologyReports(Guid PATIENTID, Guid PATHOLOGYID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetUnapprovedPathologyReports"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("PATHOLOGYID", PATHOLOGYID);

            return TTReportNqlObject.QueryObjects<Pathology.GetUnapprovedPathologyReports_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Pathology.GetUnapprovedPathologyReports_Class> GetUnapprovedPathologyReports(TTObjectContext objectContext, Guid PATIENTID, Guid PATHOLOGYID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGY"].QueryDefs["GetUnapprovedPathologyReports"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);
            paramList.Add("PATHOLOGYID", PATHOLOGYID);

            return TTReportNqlObject.QueryObjects<Pathology.GetUnapprovedPathologyReports_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Makroskopik İnceleme
    /// </summary>
        public object MacroscopyInspection
        {
            get { return (object)this["MACROSCOPYINSPECTION"]; }
            set { this["MACROSCOPYINSPECTION"] = value; }
        }

    /// <summary>
    /// Materyal Protokol Numarası Ön Eki
    /// </summary>
        public string MaterialPrtNoPrefix
        {
            get { return (string)this["MATERIALPRTNOPREFIX"]; }
            set { this["MATERIALPRTNOPREFIX"] = value; }
        }

    /// <summary>
    /// Sonuç Giriş Tarihi
    /// </summary>
        public DateTime? ResultEntryDate
        {
            get { return (DateTime?)this["RESULTENTRYDATE"]; }
            set { this["RESULTENTRYDATE"] = value; }
        }

    /// <summary>
    /// Ek Bilgi
    /// </summary>
        public string AdditionalInfo
        {
            get { return (string)this["ADDITIONALINFO"]; }
            set { this["ADDITIONALINFO"] = value; }
        }

    /// <summary>
    /// Blok Sayısı
    /// </summary>
        public int? BlockCount
        {
            get { return (int?)this["BLOCKCOUNT"]; }
            set { this["BLOCKCOUNT"] = value; }
        }

    /// <summary>
    /// Intraoperatif Konsültasyon
    /// </summary>
        public bool? IntraoperativeConsultation
        {
            get { return (bool?)this["INTRAOPERATIVECONSULTATION"]; }
            set { this["INTRAOPERATIVECONSULTATION"] = value; }
        }

    /// <summary>
    /// Lam Sayısı
    /// </summary>
        public int? LamCount
        {
            get { return (int?)this["LAMCOUNT"]; }
            set { this["LAMCOUNT"] = value; }
        }

    /// <summary>
    /// Serbest Tanı Girişi
    /// </summary>
        public string FreeDiagnoseEntry
        {
            get { return (string)this["FREEDIAGNOSEENTRY"]; }
            set { this["FREEDIAGNOSEENTRY"] = value; }
        }

    /// <summary>
    /// Tekrar Nedeni
    /// </summary>
        public string ReasonForRepeatation
        {
            get { return (string)this["REASONFORREPEATATION"]; }
            set { this["REASONFORREPEATATION"] = value; }
        }

    /// <summary>
    /// Materyal Protokol Numarası Eki
    /// </summary>
        public string MaterialPrtNoPostFix
        {
            get { return (string)this["MATERIALPRTNOPOSTFIX"]; }
            set { this["MATERIALPRTNOPOSTFIX"] = value; }
        }

    /// <summary>
    /// Prosedür Tarihi
    /// </summary>
        public DateTime? ProcedureDate
        {
            get { return (DateTime?)this["PROCEDUREDATE"]; }
            set { this["PROCEDUREDATE"] = value; }
        }

    /// <summary>
    /// Materyal Protokol Numarası
    /// </summary>
        public string MatPrtNoString
        {
            get { return (string)this["MATPRTNOSTRING"]; }
            set { this["MATPRTNOSTRING"] = value; }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Patoloji Materyal Protokol Sıra Numarası
    /// </summary>
        public TTSequence SeqNo
        {
            get { return GetSequence("SEQNO"); }
        }

    /// <summary>
    /// Onay Tarihi
    /// </summary>
        public DateTime? ApproveDate
        {
            get { return (DateTime?)this["APPROVEDATE"]; }
            set { this["APPROVEDATE"] = value; }
        }

    /// <summary>
    /// Sıvı (cc)
    /// </summary>
        public int? Liquid
        {
            get { return (int?)this["LIQUID"]; }
            set { this["LIQUID"] = value; }
        }

    /// <summary>
    /// Getiren Sorumlu
    /// </summary>
        public string MaterialResponsible
        {
            get { return (string)this["MATERIALRESPONSIBLE"]; }
            set { this["MATERIALRESPONSIBLE"] = value; }
        }

    /// <summary>
    /// Diğer XXXXXXden Gelen Uzman Tabip
    /// </summary>
        public object RemoteSpecialDoctor
        {
            get { return (object)this["REMOTESPECIALDOCTOR"]; }
            set { this["REMOTESPECIALDOCTOR"] = value; }
        }

        public bool? HasSpecialProcedures
        {
            get { return (bool?)this["HASSPECIALPROCEDURES"]; }
            set { this["HASSPECIALPROCEDURES"] = value; }
        }

    /// <summary>
    /// Birim
    /// </summary>
        public string birim
        {
            get { return (string)this["BIRIM"]; }
            set { this["BIRIM"] = value; }
        }

    /// <summary>
    /// Medula Kayıt Numarası
    /// </summary>
        public string raporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

    /// <summary>
    /// Alt Materyal Protokol Numarası Ek Numarası
    /// </summary>
        public int? SubMatPrtNoSuffixNo
        {
            get { return (int?)this["SUBMATPRTNOSUFFIXNO"]; }
            set { this["SUBMATPRTNOSUFFIXNO"] = value; }
        }

    /// <summary>
    /// SubMatPrtNoSuffixString
    /// </summary>
        public string SubMatPrtNoSuffixString
        {
            get { return (string)this["SUBMATPRTNOSUFFIXSTRING"]; }
            set { this["SUBMATPRTNOSUFFIXSTRING"] = value; }
        }

    /// <summary>
    /// Anestezi yapan doktorun diploma tescil numarası
    /// </summary>
        public string drAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Gönderilen Materyal
    /// </summary>
        public string SendedMaterial
        {
            get { return (string)this["SENDEDMATERIAL"]; }
            set { this["SENDEDMATERIAL"] = value; }
        }

    /// <summary>
    /// Teknisyen Notu
    /// </summary>
        public string TechnicianNote
        {
            get { return (string)this["TECHNICIANNOTE"]; }
            set { this["TECHNICIANNOTE"] = value; }
        }

    /// <summary>
    /// Materyal Sayısı
    /// </summary>
        public int? NumberOfMaterials
        {
            get { return (int?)this["NUMBEROFMATERIALS"]; }
            set { this["NUMBEROFMATERIALS"] = value; }
        }

    /// <summary>
    /// Onaya Gönderilme Tarihi
    /// </summary>
        public DateTime? SendToApproveDate
        {
            get { return (DateTime?)this["SENDTOAPPROVEDATE"]; }
            set { this["SENDTOAPPROVEDATE"] = value; }
        }

    /// <summary>
    /// Sayaş için eklendi 
    /// </summary>
        public bool? IsBiopsy
        {
            get { return (bool?)this["ISBIOPSY"]; }
            set { this["ISBIOPSY"] = value; }
        }

    /// <summary>
    /// Sayaş için eklendi
    /// </summary>
        public bool? IsCytology
        {
            get { return (bool?)this["ISCYTOLOGY"]; }
            set { this["ISCYTOLOGY"] = value; }
        }

    /// <summary>
    /// Frozen Materyali Bulundurur
    /// </summary>
        public bool? HasFrozen
        {
            get { return (bool?)this["HASFROZEN"]; }
            set { this["HASFROZEN"] = value; }
        }

    /// <summary>
    /// Patoloji Defter Numarası
    /// </summary>
        public string PathologyArchiveNo
        {
            get { return (string)this["PATHOLOGYARCHIVENO"]; }
            set { this["PATHOLOGYARCHIVENO"] = value; }
        }

    /// <summary>
    /// Biyopsi Sıra Numarası
    /// </summary>
        public TTSequence BiopsySeqNo
        {
            get { return GetSequence("BIOPSYSEQNO"); }
        }

    /// <summary>
    /// Sitoloji Sıra Numarası
    /// </summary>
        public TTSequence CytologySeqNo
        {
            get { return GetSequence("CYTOLOGYSEQNO"); }
        }

    /// <summary>
    /// Uzman Tabip İlişkisi
    /// </summary>
        public ResUser SpecialDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SPECIALDOCTOR"); }
            set { this["SPECIALDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Asistan Tabip İlişkisi
    /// </summary>
        public ResUser AssistantDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ASSISTANTDOCTOR"); }
            set { this["ASSISTANTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PathologyRequest PathologyRequest
        {
            get { return (PathologyRequest)((ITTObject)this).GetParent("PATHOLOGYREQUEST"); }
            set { this["PATHOLOGYREQUEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu Tabip
    /// </summary>
        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji OzelDurum
    /// </summary>
        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PathologyTest AyniFarkliKesi
    /// </summary>
        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji SagSol
    /// </summary>
        public SagSol SagSol
        {
            get { return (SagSol)((ITTObject)this).GetParent("SAGSOL"); }
            set { this["SAGSOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PathologyAdditionalReport PathologyAdditionalReport
        {
            get { return (PathologyAdditionalReport)((ITTObject)this).GetParent("PATHOLOGYADDITIONALREPORT"); }
            set { this["PATHOLOGYADDITIONALREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PathologyPanicAlert PathologyPanicAlert
        {
            get { return (PathologyPanicAlert)((ITTObject)this).GetParent("PATHOLOGYPANICALERT"); }
            set { this["PATHOLOGYPANICALERT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePathologyMaterialCollection()
        {
            _PathologyMaterial = new PathologyMaterial.ChildPathologyMaterialCollection(this, new Guid("873c1759-cf47-4989-9380-c1d52ad19c7d"));
            ((ITTChildObjectCollection)_PathologyMaterial).GetChildren();
        }

        protected PathologyMaterial.ChildPathologyMaterialCollection _PathologyMaterial = null;
        public PathologyMaterial.ChildPathologyMaterialCollection PathologyMaterial
        {
            get
            {
                if (_PathologyMaterial == null)
                    CreatePathologyMaterialCollection();
                return _PathologyMaterial;
            }
        }

        virtual protected void CreateSnomedDiagnosisCollection()
        {
            _SnomedDiagnosis = new SnomedDiagnosisGrid.ChildSnomedDiagnosisGridCollection(this, new Guid("84a4639e-d2a0-4397-aa42-c1164697ba85"));
            ((ITTChildObjectCollection)_SnomedDiagnosis).GetChildren();
        }

        protected SnomedDiagnosisGrid.ChildSnomedDiagnosisGridCollection _SnomedDiagnosis = null;
        public SnomedDiagnosisGrid.ChildSnomedDiagnosisGridCollection SnomedDiagnosis
        {
            get
            {
                if (_SnomedDiagnosis == null)
                    CreateSnomedDiagnosisCollection();
                return _SnomedDiagnosis;
            }
        }

        virtual protected void CreatePathologyConsultantDoctorsCollection()
        {
            _PathologyConsultantDoctors = new PathologyConsultantDoctor.ChildPathologyConsultantDoctorCollection(this, new Guid("e05def26-57b5-466e-bcf2-f3a81a9d04ff"));
            ((ITTChildObjectCollection)_PathologyConsultantDoctors).GetChildren();
        }

        protected PathologyConsultantDoctor.ChildPathologyConsultantDoctorCollection _PathologyConsultantDoctors = null;
    /// <summary>
    /// Child collection for Patoloji Testi İlişkisi
    /// </summary>
        public PathologyConsultantDoctor.ChildPathologyConsultantDoctorCollection PathologyConsultantDoctors
        {
            get
            {
                if (_PathologyConsultantDoctors == null)
                    CreatePathologyConsultantDoctorsCollection();
                return _PathologyConsultantDoctors;
            }
        }

        virtual protected void CreatePathologyImagesCollection()
        {
            _PathologyImages = new PathologyImage.ChildPathologyImageCollection(this, new Guid("7d6b4105-0104-4104-8a29-d4055f5caffc"));
            ((ITTChildObjectCollection)_PathologyImages).GetChildren();
        }

        protected PathologyImage.ChildPathologyImageCollection _PathologyImages = null;
    /// <summary>
    /// Child collection for Patoloji Testi İlişkisi
    /// </summary>
        public PathologyImage.ChildPathologyImageCollection PathologyImages
        {
            get
            {
                if (_PathologyImages == null)
                    CreatePathologyImagesCollection();
                return _PathologyImages;
            }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("9a9c944d-5dfd-4263-8ef3-234fa6f1a269"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
    /// <summary>
    /// Child collection for PathologyTest Çoklu Özel Durum
    /// </summary>
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        override protected void CreateSubactionProceduresCollectionViews()
        {
            base.CreateSubactionProceduresCollectionViews();
            _PathologyTestProcedures = new PathologyTestProcedure.ChildPathologyTestProcedureCollection(_SubactionProcedures, "PathologyTestProcedures");
            _PathologyAdditionalTests = new PathologyAdditionalTest.ChildPathologyAdditionalTestCollection(_SubactionProcedures, "PathologyAdditionalTests");
            _PathologySpecialProcedures = new PathologySpecialProcedure.ChildPathologySpecialProcedureCollection(_SubactionProcedures, "PathologySpecialProcedures");
        }

        private PathologyTestProcedure.ChildPathologyTestProcedureCollection _PathologyTestProcedures = null;
        public PathologyTestProcedure.ChildPathologyTestProcedureCollection PathologyTestProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PathologyTestProcedures;
            }            
        }

        private PathologyAdditionalTest.ChildPathologyAdditionalTestCollection _PathologyAdditionalTests = null;
        public PathologyAdditionalTest.ChildPathologyAdditionalTestCollection PathologyAdditionalTests
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PathologyAdditionalTests;
            }            
        }

        private PathologySpecialProcedure.ChildPathologySpecialProcedureCollection _PathologySpecialProcedures = null;
        public PathologySpecialProcedure.ChildPathologySpecialProcedureCollection PathologySpecialProcedures
        {
            get
            {
                if (_SubactionProcedures == null)
                    CreateSubactionProceduresCollection();
                return _PathologySpecialProcedures;
            }            
        }

        override protected void CreateTreatmentMaterialsCollectionViews()
        {
            base.CreateTreatmentMaterialsCollectionViews();
            _PathologyTreatmentMaterials = new PathologyLabMaterial.ChildPathologyLabMaterialCollection(_TreatmentMaterials, "PathologyTreatmentMaterials");
        }

        private PathologyLabMaterial.ChildPathologyLabMaterialCollection _PathologyTreatmentMaterials = null;
        public PathologyLabMaterial.ChildPathologyLabMaterialCollection PathologyTreatmentMaterials
        {
            get
            {
                if (_TreatmentMaterials == null)
                    CreateTreatmentMaterialsCollection();
                return _PathologyTreatmentMaterials;
            }            
        }

        protected Pathology(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Pathology(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Pathology(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Pathology(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Pathology(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGY", dataRow) { }
        protected Pathology(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGY", dataRow, isImported) { }
        public Pathology(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Pathology(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Pathology() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}