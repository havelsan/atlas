
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyRequest")] 

    /// <summary>
    /// Patoloji İstek
    /// </summary>
    public  partial class PathologyRequest : EpisodeActionWithDiagnosis, IAllocateSpeciality, IWorkListEpisodeAction
    {
        public class PathologyRequestList : TTObjectCollection<PathologyRequest> { }
                    
        public class ChildPathologyRequestCollection : TTObject.TTChildObjectCollection<PathologyRequest>
        {
            public ChildPathologyRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PathologyReqStateInfoNQL_Class : TTReportNqlObject 
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

            public DateTime? AcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string AcceptionNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public PathologyReqStateInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyReqStateInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyReqStateInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyResultReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AcceptionNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestMaterialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTMATERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTMATERIALNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public PathologyResultReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyResultReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyResultReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyRequestPatientInfoReportQuery_Class : TTReportNqlObject 
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

            public DateTime? Requestdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Requestdoctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PathologyRequestPatientInfoReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyRequestPatientInfoReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyRequestPatientInfoReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyRequestInfoStickerNQL_Class : TTReportNqlObject 
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

            public PathologyRequestInfoStickerNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyRequestInfoStickerNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyRequestInfoStickerNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyResultPatientInfoReportQuery_Class : TTReportNqlObject 
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

            public DateTime? Acceptdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Actdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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

            public PathologyResultPatientInfoReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyResultPatientInfoReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyResultPatientInfoReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class SearchPathologies_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AcceptionNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestMaterialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTMATERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTMATERIALNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ResponsibleDoctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEDOCTOR"]);
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

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public SearchPathologies_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SearchPathologies_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SearchPathologies_Class() : base() { }
        }

        [Serializable] 

        public partial class PathologyRequestBarcodeNQL_Class : TTReportNqlObject 
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

            public PathologyRequestBarcodeNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PathologyRequestBarcodeNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PathologyRequestBarcodeNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyRequestInfo_Class : TTReportNqlObject 
        {
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

            public long? Patienttrid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTTRID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public DateTime? Istemtarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTEMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Requestedresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologyRequestInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyRequestInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyRequestInfo_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyRequestBySubEpisode_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["EMERGENCY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["PATIENTPAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ORDEROBJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["DESCRIPTIONFORWORKLIST"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["IGNOREEPISODESTATEONUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ADMISSIONQUEUENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AcceptionNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? AcceptionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCEPTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["ACCEPTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MaterialResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["MATERIALRESPONSIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestMaterialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTMATERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["REQUESTMATERIALNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyRequestBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyRequestBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyRequestBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPathologyRequestForWL_Class : TTReportNqlObject 
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

            public bool? HasFrozen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFROZEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].AllPropertyDefs["HASFROZEN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPathologyRequestForWL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyRequestForWL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyRequestForWL_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("89a27213-612a-4e91-add4-0c7c034b12ab"); } }
    /// <summary>
    /// Patoloji İşlemi Kabul Edildi
    /// </summary>
            public static Guid Procedure { get { return new Guid("6bae2d43-9638-45de-bfa3-4ad01418bff8"); } }
    /// <summary>
    /// İstek Kabul
    /// </summary>
            public static Guid Accept { get { return new Guid("77068d8e-4d33-425d-a0fb-d58a3e4d18da"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("2f00cba0-57f3-4aa4-88e5-78ee94a19389"); } }
        }

        public static BindingList<PathologyRequest.PathologyReqStateInfoNQL_Class> PathologyReqStateInfoNQL(string PARAMPATHOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyReqStateInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATHOBJID", PARAMPATHOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyReqStateInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyReqStateInfoNQL_Class> PathologyReqStateInfoNQL(TTObjectContext objectContext, string PARAMPATHOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyReqStateInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATHOBJID", PARAMPATHOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyReqStateInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyResultReportQuery_Class> PathologyResultReportQuery(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyResultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyResultReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyResultReportQuery_Class> PathologyResultReportQuery(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyResultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyResultReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class> PathologyRequestPatientInfoReportQuery(string PARAMPATOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyRequestPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATOBJID", PARAMPATOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class> PathologyRequestPatientInfoReportQuery(TTObjectContext objectContext, string PARAMPATOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyRequestPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATOBJID", PARAMPATOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyRequestPatientInfoReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyRequestInfoStickerNQL_Class> PathologyRequestInfoStickerNQL(string PARAMPATHOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyRequestInfoStickerNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATHOBJID", PARAMPATHOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyRequestInfoStickerNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyRequestInfoStickerNQL_Class> PathologyRequestInfoStickerNQL(TTObjectContext objectContext, string PARAMPATHOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyRequestInfoStickerNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATHOBJID", PARAMPATHOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyRequestInfoStickerNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyResultPatientInfoReportQuery_Class> PathologyResultPatientInfoReportQuery(string PARAMPATOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyResultPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATOBJID", PARAMPATOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyResultPatientInfoReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyResultPatientInfoReportQuery_Class> PathologyResultPatientInfoReportQuery(TTObjectContext objectContext, string PARAMPATOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyResultPatientInfoReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMPATOBJID", PARAMPATOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyResultPatientInfoReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.SearchPathologies_Class> SearchPathologies(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["SearchPathologies"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyRequest.SearchPathologies_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyRequest.SearchPathologies_Class> SearchPathologies(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["SearchPathologies"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyRequest.SearchPathologies_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyRequest.PathologyRequestBarcodeNQL_Class> PathologyRequestBarcodeNQL(string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyRequestBarcodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyRequestBarcodeNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.PathologyRequestBarcodeNQL_Class> PathologyRequestBarcodeNQL(TTObjectContext objectContext, string PARAMOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["PathologyRequestBarcodeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJID", PARAMOBJID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.PathologyRequestBarcodeNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.GetPathologyRequestInfo_Class> GetPathologyRequestInfo(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["GetPathologyRequestInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.GetPathologyRequestInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.GetPathologyRequestInfo_Class> GetPathologyRequestInfo(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["GetPathologyRequestInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PathologyRequest.GetPathologyRequestInfo_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.GetPathologyRequestBySubEpisode_Class> GetPathologyRequestBySubEpisode(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["GetPathologyRequestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<PathologyRequest.GetPathologyRequestBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.GetPathologyRequestBySubEpisode_Class> GetPathologyRequestBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["GetPathologyRequestBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<PathologyRequest.GetPathologyRequestBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PathologyRequest.GetPathologyRequestForWL_Class> GetPathologyRequestForWL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["GetPathologyRequestForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyRequest.GetPathologyRequestForWL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyRequest.GetPathologyRequestForWL_Class> GetPathologyRequestForWL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYREQUEST"].QueryDefs["GetPathologyRequestForWL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyRequest.GetPathologyRequestForWL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kabul Notu
    /// </summary>
        public string AcceptionNote
        {
            get { return (string)this["ACCEPTIONNOTE"]; }
            set { this["ACCEPTIONNOTE"] = value; }
        }

    /// <summary>
    /// Kabul Tarihi
    /// </summary>
        public DateTime? AcceptionDate
        {
            get { return (DateTime?)this["ACCEPTIONDATE"]; }
            set { this["ACCEPTIONDATE"] = value; }
        }

    /// <summary>
    /// Malzeme Getiren
    /// </summary>
        public string MaterialResponsible
        {
            get { return (string)this["MATERIALRESPONSIBLE"]; }
            set { this["MATERIALRESPONSIBLE"] = value; }
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
    /// İstek Materyal Numarası
    /// </summary>
        public TTSequence RequestMaterialNumber
        {
            get { return GetSequence("REQUESTMATERIALNUMBER"); }
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
    /// Uzman Doktor
    /// </summary>
        public ResUser SpecialDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("SPECIALDOCTOR"); }
            set { this["SPECIALDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sorumlu Doktor
    /// </summary>
        public ResUser ResponsibleDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESPONSIBLEDOCTOR"); }
            set { this["RESPONSIBLEDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Doktor
    /// </summary>
        public ResUser RequestDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTDOCTOR"); }
            set { this["REQUESTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Yardımcı Doktor
    /// </summary>
        public ResUser AssistantDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("ASSISTANTDOCTOR"); }
            set { this["ASSISTANTDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReasonForPathologyRejection ReasonForPathologyRejection
        {
            get { return (ReasonForPathologyRejection)((ITTObject)this).GetParent("REASONFORPATHOLOGYREJECTION"); }
            set { this["REASONFORPATHOLOGYREJECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan XXXXXX XXXXXX
    /// </summary>
        public ReferableHospital RequesterReferableHospital
        {
            get { return (ReferableHospital)((ITTObject)this).GetParent("REQUESTERREFERABLEHOSPITAL"); }
            set { this["REQUESTERREFERABLEHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePathologyMaterialsCollection()
        {
            _PathologyMaterials = new PathologyMaterial.ChildPathologyMaterialCollection(this, new Guid("e1de5931-5c85-47ac-a5d4-d18389429278"));
            ((ITTChildObjectCollection)_PathologyMaterials).GetChildren();
        }

        protected PathologyMaterial.ChildPathologyMaterialCollection _PathologyMaterials = null;
        public PathologyMaterial.ChildPathologyMaterialCollection PathologyMaterials
        {
            get
            {
                if (_PathologyMaterials == null)
                    CreatePathologyMaterialsCollection();
                return _PathologyMaterials;
            }
        }

        virtual protected void CreatePathologyLabMaterialsCollection()
        {
            _PathologyLabMaterials = new PathologyLabMaterial.ChildPathologyLabMaterialCollection(this, new Guid("3fe0c578-227f-4210-a5c6-54b9c05ec364"));
            ((ITTChildObjectCollection)_PathologyLabMaterials).GetChildren();
        }

        protected PathologyLabMaterial.ChildPathologyLabMaterialCollection _PathologyLabMaterials = null;
    /// <summary>
    /// Child collection for Patoloji Ana İlişkisi
    /// </summary>
        public PathologyLabMaterial.ChildPathologyLabMaterialCollection PathologyLabMaterials
        {
            get
            {
                if (_PathologyLabMaterials == null)
                    CreatePathologyLabMaterialsCollection();
                return _PathologyLabMaterials;
            }
        }

        virtual protected void CreatePathologiesCollection()
        {
            _Pathologies = new Pathology.ChildPathologyCollection(this, new Guid("2d0eb21d-019f-4962-a0e6-e55c7baf0b0d"));
            ((ITTChildObjectCollection)_Pathologies).GetChildren();
        }

        protected Pathology.ChildPathologyCollection _Pathologies = null;
        public Pathology.ChildPathologyCollection Pathologies
        {
            get
            {
                if (_Pathologies == null)
                    CreatePathologiesCollection();
                return _Pathologies;
            }
        }

        virtual protected void CreatePathologyTestProcedureCollection()
        {
            _PathologyTestProcedure = new PathologyTestProcedure.ChildPathologyTestProcedureCollection(this, new Guid("77467504-3eb1-4d82-b738-9b1ceb20b3a4"));
            ((ITTChildObjectCollection)_PathologyTestProcedure).GetChildren();
        }

        protected PathologyTestProcedure.ChildPathologyTestProcedureCollection _PathologyTestProcedure = null;
        public PathologyTestProcedure.ChildPathologyTestProcedureCollection PathologyTestProcedure
        {
            get
            {
                if (_PathologyTestProcedure == null)
                    CreatePathologyTestProcedureCollection();
                return _PathologyTestProcedure;
            }
        }

        virtual protected void CreatePathologyLabProcedures2Collection()
        {
            _PathologyLabProcedures2 = new PathologyLabProcedure.ChildPathologyLabProcedureCollection(this, new Guid("80235a81-b365-44bf-af83-f85a2a1ea366"));
            ((ITTChildObjectCollection)_PathologyLabProcedures2).GetChildren();
        }

        protected PathologyLabProcedure.ChildPathologyLabProcedureCollection _PathologyLabProcedures2 = null;
    /// <summary>
    /// Child collection for Patoloji Ana İlişki
    /// </summary>
        public PathologyLabProcedure.ChildPathologyLabProcedureCollection PathologyLabProcedures2
        {
            get
            {
                if (_PathologyLabProcedures2 == null)
                    CreatePathologyLabProcedures2Collection();
                return _PathologyLabProcedures2;
            }
        }

        protected PathologyRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYREQUEST", dataRow) { }
        protected PathologyRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYREQUEST", dataRow, isImported) { }
        public PathologyRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyRequest() : base() { }

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