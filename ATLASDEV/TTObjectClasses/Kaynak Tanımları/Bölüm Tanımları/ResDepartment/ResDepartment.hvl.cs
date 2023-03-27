
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResDepartment")] 

    /// <summary>
    /// Bölüm 
    /// </summary>
    public  partial class ResDepartment : ResSection
    {
        public class ResDepartmentList : TTObjectCollection<ResDepartment> { }
                    
        public class ChildResDepartmentCollection : TTObject.TTChildObjectCollection<ResDepartment>
        {
            public ChildResDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResDepartment_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public OLAP_ResDepartment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResDepartment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResDepartment_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDepartmentDefinition_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
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

            public bool? IsEmergencyDepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ISEMERGENCYDEPARTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDepartmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDepartmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDepartmentDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyDepartment_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
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

            public bool? IsEmergencyDepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ISEMERGENCYDEPARTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyDepartment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyDepartment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyDepartment_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEmergencyClinicAndPoliclinic_Class : TTReportNqlObject 
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

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Location
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["LOCATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeskPhoneNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESKPHONENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["DESKPHONENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? AppointmentLimit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPOINTMENTLIMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["APPOINTMENTLIMIT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? ActionCancelledTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONCANCELLEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ACTIONCANCELLEDTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public ResourceEnableType? EnabledType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENABLEDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ENABLEDTYPE"].DataType;
                    return (ResourceEnableType?)(int)dataType.ConvertValue(val);
                }
            }

            public int? AprilQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APRILQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["APRILQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? AugustQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUGUSTQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["AUGUSTQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? JuneQuata
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JUNEQUATA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["JUNEQUATA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastQuotaDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTQUOTADATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["LASTQUOTADATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? NovemberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOVEMBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NOVEMBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? OctoberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OCTOBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["OCTOBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? SeptemberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEPTEMBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["SEPTEMBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? WeeklyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEEKLYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["WEEKLYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? DontShowHCDepartmentReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONTSHOWHCDEPARTMENTREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["DONTSHOWHCDEPARTMENTREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ContactPhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTACTPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["CONTACTPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsToBeConsultation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTOBECONSULTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsEtiquettePrinted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISETIQUETTEPRINTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ISETIQUETTEPRINTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? EtiquetteCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETIQUETTECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ETIQUETTECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? PCSInUse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PCSINUSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["PCSINUSE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MarchQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARCHQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["MARCHQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? DailyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["DAILYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? DecemberQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECEMBERQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["DECEMBERQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? FebruaryQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FEBRUARYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["FEBRUARYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? JanuaryQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JANUARYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["JANUARYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? JulyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JULYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["JULYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MayQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["MAYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MonthlyQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONTHLYQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["MONTHLYQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? NotChargeHCExaminationPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTCHARGEHCEXAMINATIONPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["NOTCHARGEHCEXAMINATIONPRICE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ContactAddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTACTADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["CONTACTADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IgnoreQuotaControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IGNOREQUOTACONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["IGNOREQUOTACONTROL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? InpatientQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["INPATIENTQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? HimssRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HIMSSREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["HIMSSREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsmedicalWaste
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMEDICALWASTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ISMEDICALWASTE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ResSectionTypeEnum? ResSectionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESSECTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["RESSECTIONTYPE"].DataType;
                    return (ResSectionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResourceStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCESTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["RESOURCESTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResourceEndTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCEENDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["RESOURCEENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? ShownInKiosk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWNINKIOSK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["SHOWNINKIOSK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? OptionalDelayMinute
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPTIONALDELAYMINUTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["OPTIONALDELAYMINUTE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? SexException
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEXEXCEPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["SEXEXCEPTION"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MaxAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["MAXAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? DontTakeGSSProvision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONTTAKEGSSPROVISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["DONTTAKEGSSPROVISION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MinAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["MINAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? ActionEnabled
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONENABLED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ACTIONENABLED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ResourceTypeEnum? ResourceType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["RESOURCETYPE"].DataType;
                    return (ResourceTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsEmergencyDepartment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYDEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].AllPropertyDefs["ISEMERGENCYDEPARTMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyClinicAndPoliclinic_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyClinicAndPoliclinic_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyClinicAndPoliclinic_Class() : base() { }
        }

        public static BindingList<ResDepartment.OLAP_ResDepartment_Class> OLAP_ResDepartment(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["OLAP_ResDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.OLAP_ResDepartment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResDepartment.OLAP_ResDepartment_Class> OLAP_ResDepartment(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["OLAP_ResDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.OLAP_ResDepartment_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResDepartment.GetDepartmentDefinition_Class> GetDepartmentDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["GetDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.GetDepartmentDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResDepartment.GetDepartmentDefinition_Class> GetDepartmentDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["GetDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.GetDepartmentDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResDepartment> GetDepartmentByID(TTObjectContext objectContext, int ID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["GetDepartmentByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ID", ID);

            return ((ITTQuery)objectContext).QueryObjects<ResDepartment>(queryDef, paramList);
        }

    /// <summary>
    /// Acil Bölümü
    /// </summary>
        public static BindingList<ResDepartment.GetEmergencyDepartment_Class> GetEmergencyDepartment(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["GetEmergencyDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.GetEmergencyDepartment_Class>(queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Acil Bölümü
    /// </summary>
        public static BindingList<ResDepartment.GetEmergencyDepartment_Class> GetEmergencyDepartment(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["GetEmergencyDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.GetEmergencyDepartment_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResDepartment.GetEmergencyClinicAndPoliclinic_Class> GetEmergencyClinicAndPoliclinic(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["GetEmergencyClinicAndPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.GetEmergencyClinicAndPoliclinic_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResDepartment.GetEmergencyClinicAndPoliclinic_Class> GetEmergencyClinicAndPoliclinic(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESDEPARTMENT"].QueryDefs["GetEmergencyClinicAndPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResDepartment.GetEmergencyClinicAndPoliclinic_Class>(objectContext, queryDef, paramList, pi);
        }

        public bool? ActionEnabled
        {
            get { return (bool?)this["ACTIONENABLED"]; }
            set { this["ACTIONENABLED"] = value; }
        }

        public ResourceTypeEnum? ResourceType
        {
            get { return (ResourceTypeEnum?)(int?)this["RESOURCETYPE"]; }
            set { this["RESOURCETYPE"] = value; }
        }

        public bool? IsEmergencyDepartment
        {
            get { return (bool?)this["ISEMERGENCYDEPARTMENT"]; }
            set { this["ISEMERGENCYDEPARTMENT"] = value; }
        }

    /// <summary>
    /// Ana Bilim Dalı
    /// </summary>
        public ResDepartment MainDepartment
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("MAINDEPARTMENT"); }
            set { this["MAINDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bina
    /// </summary>
        public ResBuilding Building
        {
            get { return (ResBuilding)((ITTObject)this).GetParent("BUILDING"); }
            set { this["BUILDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDepartmentsCollection()
        {
            _Departments = new ResDepartment.ChildResDepartmentCollection(this, new Guid("5f694900-8e78-4a9a-a148-00f0406b8778"));
            ((ITTChildObjectCollection)_Departments).GetChildren();
        }

        protected ResDepartment.ChildResDepartmentCollection _Departments = null;
    /// <summary>
    /// Child collection for Ana Bilim Dalı
    /// </summary>
        public ResDepartment.ChildResDepartmentCollection Departments
        {
            get
            {
                if (_Departments == null)
                    CreateDepartmentsCollection();
                return _Departments;
            }
        }

        virtual protected void CreateObservationUnitsCollection()
        {
            _ObservationUnits = new ResObservationUnit.ChildResObservationUnitCollection(this, new Guid("92bde789-8bf3-4140-a915-2e217ed3b509"));
            ((ITTChildObjectCollection)_ObservationUnits).GetChildren();
        }

        protected ResObservationUnit.ChildResObservationUnitCollection _ObservationUnits = null;
    /// <summary>
    /// Child collection for Bölüm
    /// </summary>
        public ResObservationUnit.ChildResObservationUnitCollection ObservationUnits
        {
            get
            {
                if (_ObservationUnits == null)
                    CreateObservationUnitsCollection();
                return _ObservationUnits;
            }
        }

        virtual protected void CreateClinicsCollectionViews()
        {
            _IntensiveCares = new ResIntensiveCare.ChildResIntensiveCareCollection(_Clinics, "IntensiveCares");
        }

        virtual protected void CreateClinicsCollection()
        {
            _Clinics = new ResClinic.ChildResClinicCollection(this, new Guid("2f97fa0a-7d60-4482-84ac-6695da6f7f35"));
            CreateClinicsCollectionViews();
            ((ITTChildObjectCollection)_Clinics).GetChildren();
        }

        protected ResClinic.ChildResClinicCollection _Clinics = null;
    /// <summary>
    /// Child collection for Bölüm
    /// </summary>
        public ResClinic.ChildResClinicCollection Clinics
        {
            get
            {
                if (_Clinics == null)
                    CreateClinicsCollection();
                return _Clinics;
            }
        }

        private ResIntensiveCare.ChildResIntensiveCareCollection _IntensiveCares = null;
        public ResIntensiveCare.ChildResIntensiveCareCollection IntensiveCares
        {
            get
            {
                if (_Clinics == null)
                    CreateClinicsCollection();
                return _IntensiveCares;
            }            
        }

        virtual protected void CreateTreatmentDiagnosisUnitsCollection()
        {
            _TreatmentDiagnosisUnits = new ResTreatmentDiagnosisUnit.ChildResTreatmentDiagnosisUnitCollection(this, new Guid("b048b488-d4d5-4738-9d9a-6c88e311d098"));
            ((ITTChildObjectCollection)_TreatmentDiagnosisUnits).GetChildren();
        }

        protected ResTreatmentDiagnosisUnit.ChildResTreatmentDiagnosisUnitCollection _TreatmentDiagnosisUnits = null;
    /// <summary>
    /// Child collection for Bölüm
    /// </summary>
        public ResTreatmentDiagnosisUnit.ChildResTreatmentDiagnosisUnitCollection TreatmentDiagnosisUnits
        {
            get
            {
                if (_TreatmentDiagnosisUnits == null)
                    CreateTreatmentDiagnosisUnitsCollection();
                return _TreatmentDiagnosisUnits;
            }
        }

        virtual protected void CreateSurgeryDepartmentCollection()
        {
            _SurgeryDepartment = new ResSurgeryDepartment.ChildResSurgeryDepartmentCollection(this, new Guid("eed8baf7-1936-4df5-a9e6-fbfef3b55685"));
            ((ITTChildObjectCollection)_SurgeryDepartment).GetChildren();
        }

        protected ResSurgeryDepartment.ChildResSurgeryDepartmentCollection _SurgeryDepartment = null;
    /// <summary>
    /// Child collection for Bölüm
    /// </summary>
        public ResSurgeryDepartment.ChildResSurgeryDepartmentCollection SurgeryDepartment
        {
            get
            {
                if (_SurgeryDepartment == null)
                    CreateSurgeryDepartmentCollection();
                return _SurgeryDepartment;
            }
        }

        virtual protected void CreatePoliclinicsCollection()
        {
            _Policlinics = new ResPoliclinic.ChildResPoliclinicCollection(this, new Guid("180f2312-43fc-4a4b-a083-ef60ace025ce"));
            ((ITTChildObjectCollection)_Policlinics).GetChildren();
        }

        protected ResPoliclinic.ChildResPoliclinicCollection _Policlinics = null;
    /// <summary>
    /// Child collection for Bölüm
    /// </summary>
        public ResPoliclinic.ChildResPoliclinicCollection Policlinics
        {
            get
            {
                if (_Policlinics == null)
                    CreatePoliclinicsCollection();
                return _Policlinics;
            }
        }

        protected ResDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESDEPARTMENT", dataRow) { }
        protected ResDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESDEPARTMENT", dataRow, isImported) { }
        public ResDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResDepartment() : base() { }

    }
}