
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Sites")] 

    public  partial class Sites : TerminologyManagerDef, ISites
    {
        public class SitesList : TTObjectCollection<Sites> { }
                    
        public class ChildSitesCollection : TTObject.TTChildObjectCollection<Sites>
        {
            public ChildSitesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSitesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSiteDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Boolean? Isactive1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE1"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? Lastupdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE1"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string IP
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["IP"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DatabaseName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATABASENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["DATABASENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsPatientExist
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPATIENTEXIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["ISPATIENTEXIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? ASyncTCPPort
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASYNCTCPPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["ASYNCTCPPORT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MedulaSiteCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULASITECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["MEDULASITECODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? AsalID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASALID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["ASALID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? HttpPort
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HTTPPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["HTTPPORT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTerminologyManagerSite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTERMINOLOGYMANAGERSITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["ISTERMINOLOGYMANAGERSITE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SiteTypeEnum? SiteType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SITETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["SITETYPE"].DataType;
                    return (SiteTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? SyncTCPPort
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SYNCTCPPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["SYNCTCPPORT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ShortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["SHORTNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SITES"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSiteDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSiteDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSiteDefinition_Class() : base() { }
        }

        public static BindingList<Sites.GetSiteDefinition_Class> GetSiteDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SITES"].QueryDefs["GetSiteDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Sites.GetSiteDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Sites.GetSiteDefinition_Class> GetSiteDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SITES"].QueryDefs["GetSiteDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Sites.GetSiteDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Sites> GetSitesByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SITES"].QueryDefs["GetSitesByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Sites>(queryDef, paramList);
        }

        public string IP
        {
            get { return (string)this["IP"]; }
            set { this["IP"] = value; }
        }

        public string DatabaseName
        {
            get { return (string)this["DATABASENAME"]; }
            set { this["DATABASENAME"] = value; }
        }

        public bool? IsPatientExist
        {
            get { return (bool?)this["ISPATIENTEXIST"]; }
            set { this["ISPATIENTEXIST"] = value; }
        }

        public int? ASyncTCPPort
        {
            get { return (int?)this["ASYNCTCPPORT"]; }
            set { this["ASYNCTCPPORT"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Medula Tesis Kodu
    /// </summary>
        public int? MedulaSiteCode
        {
            get { return (int?)this["MEDULASITECODE"]; }
            set { this["MEDULASITECODE"] = value; }
        }

    /// <summary>
    /// Asal ID
    /// </summary>
        public int? AsalID
        {
            get { return (int?)this["ASALID"]; }
            set { this["ASALID"] = value; }
        }

        public int? HttpPort
        {
            get { return (int?)this["HTTPPORT"]; }
            set { this["HTTPPORT"] = value; }
        }

        public bool? IsTerminologyManagerSite
        {
            get { return (bool?)this["ISTERMINOLOGYMANAGERSITE"]; }
            set { this["ISTERMINOLOGYMANAGERSITE"] = value; }
        }

        public SiteTypeEnum? SiteType
        {
            get { return (SiteTypeEnum?)(int?)this["SITETYPE"]; }
            set { this["SITETYPE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public int? SyncTCPPort
        {
            get { return (int?)this["SYNCTCPPORT"]; }
            set { this["SYNCTCPPORT"] = value; }
        }

        public string ShortName
        {
            get { return (string)this["SHORTNAME"]; }
            set { this["SHORTNAME"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        virtual protected void CreateResOtherHospitalCollection()
        {
            _ResOtherHospital = new ResOtherHospital.ChildResOtherHospitalCollection(this, new Guid("c34f6d2e-8b2a-4d53-8221-d426b3e71164"));
            ((ITTChildObjectCollection)_ResOtherHospital).GetChildren();
        }

        protected ResOtherHospital.ChildResOtherHospitalCollection _ResOtherHospital = null;
        public ResOtherHospital.ChildResOtherHospitalCollection ResOtherHospital
        {
            get
            {
                if (_ResOtherHospital == null)
                    CreateResOtherHospitalCollection();
                return _ResOtherHospital;
            }
        }

        virtual protected void CreateResHospitalCollection()
        {
            _ResHospital = new ResHospital.ChildResHospitalCollection(this, new Guid("6916f416-be8c-44d2-807d-a6ed0ec1337c"));
            ((ITTChildObjectCollection)_ResHospital).GetChildren();
        }

        protected ResHospital.ChildResHospitalCollection _ResHospital = null;
        public ResHospital.ChildResHospitalCollection ResHospital
        {
            get
            {
                if (_ResHospital == null)
                    CreateResHospitalCollection();
                return _ResHospital;
            }
        }

        virtual protected void CreateAnnouncementHospitalsCollection()
        {
            _AnnouncementHospitals = new AnnouncementHospital.ChildAnnouncementHospitalCollection(this, new Guid("5906b7b5-96e3-4f14-9b45-7fd420915c17"));
            ((ITTChildObjectCollection)_AnnouncementHospitals).GetChildren();
        }

        protected AnnouncementHospital.ChildAnnouncementHospitalCollection _AnnouncementHospitals = null;
        public AnnouncementHospital.ChildAnnouncementHospitalCollection AnnouncementHospitals
        {
            get
            {
                if (_AnnouncementHospitals == null)
                    CreateAnnouncementHospitalsCollection();
                return _AnnouncementHospitals;
            }
        }

        protected Sites(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Sites(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Sites(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Sites(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Sites(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SITES", dataRow) { }
        protected Sites(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SITES", dataRow, isImported) { }
        public Sites(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Sites(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Sites() : base() { }

    }
}