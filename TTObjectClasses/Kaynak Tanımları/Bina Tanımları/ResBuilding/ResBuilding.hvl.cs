
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResBuilding")] 

    /// <summary>
    /// Bina 
    /// </summary>
    public  partial class ResBuilding : ResSection
    {
        public class ResBuildingList : TTObjectCollection<ResBuilding> { }
                    
        public class ChildResBuildingCollection : TTObject.TTChildObjectCollection<ResBuilding>
        {
            public ChildResBuildingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResBuildingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSpecialitiesByBuilding_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSpecialitiesByBuilding_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSpecialitiesByBuilding_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSpecialitiesByBuilding_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBuildingList_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["NAME"].DataType;
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

            public GetBuildingList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBuildingList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBuildingList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllBuildingList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["LOCATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["DESKPHONENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["APPOINTMENTLIMIT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ACTIONCANCELLEDTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ENABLEDTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["APRILQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["AUGUSTQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["JUNEQUATA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["LASTQUOTADATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["NOVEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["OCTOBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["SEPTEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["WEEKLYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["DONTSHOWHCDEPARTMENTREPORT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["CONTACTPHONE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ISTOBECONSULTATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ISETIQUETTEPRINTED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ETIQUETTECOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["PCSINUSE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["MARCHQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["DAILYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["DECEMBERQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["FEBRUARYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["JANUARYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["JULYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["MAYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["MONTHLYQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["NOTCHARGEHCEXAMINATIONPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["CONTACTADDRESS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["IGNOREQUOTACONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["INPATIENTQUOTA"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["HIMSSREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ISMEDICALWASTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["RESSECTIONTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["RESOURCESTARTTIME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["RESOURCEENDTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? OptionalDelayMinute
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPTIONALDELAYMINUTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["OPTIONALDELAYMINUTE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["SEXEXCEPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["MAXAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["DONTTAKEGSSPROVISION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["MINAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["ACTIONENABLED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? MainBuilding
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINBUILDING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["MAINBUILDING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetAllBuildingList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllBuildingList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllBuildingList_Class() : base() { }
        }

        public static BindingList<ResBuilding.GetSpecialitiesByBuilding_Class> GetSpecialitiesByBuilding(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetSpecialitiesByBuilding"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ResBuilding.GetSpecialitiesByBuilding_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResBuilding.GetSpecialitiesByBuilding_Class> GetSpecialitiesByBuilding(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetSpecialitiesByBuilding"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ResBuilding.GetSpecialitiesByBuilding_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResBuilding.GetBuildingList_Class> GetBuildingList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetBuildingList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBuilding.GetBuildingList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBuilding.GetBuildingList_Class> GetBuildingList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetBuildingList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBuilding.GetBuildingList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBuilding> GetMainBuilding(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetMainBuilding"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResBuilding>(queryDef, paramList);
        }

        public static BindingList<ResBuilding.GetAllBuildingList_Class> GetAllBuildingList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetAllBuildingList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBuilding.GetAllBuildingList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBuilding.GetAllBuildingList_Class> GetAllBuildingList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetAllBuildingList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResBuilding.GetAllBuildingList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResBuilding> GetAllBuildings(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].QueryDefs["GetAllBuildings"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResBuilding>(queryDef, paramList);
        }

        public bool? ActionEnabled
        {
            get { return (bool?)this["ACTIONENABLED"]; }
            set { this["ACTIONENABLED"] = value; }
        }

        public bool? MainBuilding
        {
            get { return (bool?)this["MAINBUILDING"]; }
            set { this["MAINBUILDING"] = value; }
        }

    /// <summary>
    /// Bina
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDepartmentsCollection()
        {
            _Departments = new ResDepartment.ChildResDepartmentCollection(this, new Guid("ff92bd45-e561-4245-9bc8-99d30f1e3101"));
            ((ITTChildObjectCollection)_Departments).GetChildren();
        }

        protected ResDepartment.ChildResDepartmentCollection _Departments = null;
    /// <summary>
    /// Child collection for Bina
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

        virtual protected void CreateResFloorsCollection()
        {
            _ResFloors = new ResFloor.ChildResFloorCollection(this, new Guid("504eca45-465a-4baf-b108-fc4ed198743f"));
            ((ITTChildObjectCollection)_ResFloors).GetChildren();
        }

        protected ResFloor.ChildResFloorCollection _ResFloors = null;
    /// <summary>
    /// Child collection for Bina
    /// </summary>
        public ResFloor.ChildResFloorCollection ResFloors
        {
            get
            {
                if (_ResFloors == null)
                    CreateResFloorsCollection();
                return _ResFloors;
            }
        }

        virtual protected void CreateResBuildingWingCollection()
        {
            _ResBuildingWing = new ResBuildingWing.ChildResBuildingWingCollection(this, new Guid("61890180-5ca0-42e9-b10d-267a15d17661"));
            ((ITTChildObjectCollection)_ResBuildingWing).GetChildren();
        }

        protected ResBuildingWing.ChildResBuildingWingCollection _ResBuildingWing = null;
    /// <summary>
    /// Child collection for Bina
    /// </summary>
        public ResBuildingWing.ChildResBuildingWingCollection ResBuildingWing
        {
            get
            {
                if (_ResBuildingWing == null)
                    CreateResBuildingWingCollection();
                return _ResBuildingWing;
            }
        }

        virtual protected void CreateResSterilizationUnitsCollection()
        {
            _ResSterilizationUnits = new ResSterilizationUnit.ChildResSterilizationUnitCollection(this, new Guid("24f8eb23-97bb-4573-b9d2-d03584d8042a"));
            ((ITTChildObjectCollection)_ResSterilizationUnits).GetChildren();
        }

        protected ResSterilizationUnit.ChildResSterilizationUnitCollection _ResSterilizationUnits = null;
        public ResSterilizationUnit.ChildResSterilizationUnitCollection ResSterilizationUnits
        {
            get
            {
                if (_ResSterilizationUnits == null)
                    CreateResSterilizationUnitsCollection();
                return _ResSterilizationUnits;
            }
        }

        protected ResBuilding(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResBuilding(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResBuilding(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResBuilding(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResBuilding(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESBUILDING", dataRow) { }
        protected ResBuilding(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESBUILDING", dataRow, isImported) { }
        protected ResBuilding(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResBuilding(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResBuilding() : base() { }

    }
}