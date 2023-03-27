
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReferableResource")] 

    public  partial class ReferableResource : TerminologyManagerDef
    {
        public class ReferableResourceList : TTObjectCollection<ReferableResource> { }
                    
        public class ChildReferableResourceCollection : TTObject.TTChildObjectCollection<ReferableResource>
        {
            public ChildReferableResourceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReferableResourceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByResourceAndReferableHospital_Class : TTReportNqlObject 
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

            public string ResourceObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCEOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCEOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResourceName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ResourceName_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? LastUpdateRealSiteGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LASTUPDATEREALSITEGUID"]);
                }
            }

            public Guid? LastUpdateSiteGuid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LASTUPDATESITEGUID"]);
                }
            }

            public GetByResourceAndReferableHospital_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByResourceAndReferableHospital_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByResourceAndReferableHospital_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReferableResources_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ResourceName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ReferableHospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REFERABLEHOSPITAL"]);
                }
            }

            public Guid? ResOtherHospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOTHERHOSPITAL"]);
                }
            }

            public string Resotherhospitalname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOTHERHOSPITALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetReferableResources_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReferableResources_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReferableResources_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveReferableResources_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ResourceName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].AllPropertyDefs["RESOURCENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ReferableHospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REFERABLEHOSPITAL"]);
                }
            }

            public Guid? ResOtherHospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESOTHERHOSPITAL"]);
                }
            }

            public string Resotherhospitalname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOTHERHOSPITALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOTHERHOSPITAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveReferableResources_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveReferableResources_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveReferableResources_Class() : base() { }
        }

        public static BindingList<ReferableResource.GetByResourceAndReferableHospital_Class> GetByResourceAndReferableHospital(string RESOURCEOBJECTID, string REFERABLEHOSPITAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].QueryDefs["GetByResourceAndReferableHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEOBJECTID", RESOURCEOBJECTID);
            paramList.Add("REFERABLEHOSPITAL", REFERABLEHOSPITAL);

            return TTReportNqlObject.QueryObjects<ReferableResource.GetByResourceAndReferableHospital_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferableResource.GetByResourceAndReferableHospital_Class> GetByResourceAndReferableHospital(TTObjectContext objectContext, string RESOURCEOBJECTID, string REFERABLEHOSPITAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].QueryDefs["GetByResourceAndReferableHospital"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEOBJECTID", RESOURCEOBJECTID);
            paramList.Add("REFERABLEHOSPITAL", REFERABLEHOSPITAL);

            return TTReportNqlObject.QueryObjects<ReferableResource.GetByResourceAndReferableHospital_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferableResource> GetByResourceObjectID(TTObjectContext objectContext, string RESOURCEOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].QueryDefs["GetByResourceObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEOBJECTID", RESOURCEOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ReferableResource>(queryDef, paramList);
        }

        public static BindingList<ReferableResource.GetReferableResources_Class> GetReferableResources(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].QueryDefs["GetReferableResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableResource.GetReferableResources_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReferableResource.GetReferableResources_Class> GetReferableResources(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].QueryDefs["GetReferableResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableResource.GetReferableResources_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReferableResource.GetActiveReferableResources_Class> GetActiveReferableResources(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].QueryDefs["GetActiveReferableResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableResource.GetActiveReferableResources_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ReferableResource.GetActiveReferableResources_Class> GetActiveReferableResources(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERABLERESOURCE"].QueryDefs["GetActiveReferableResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ReferableResource.GetActiveReferableResources_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kaynak ID
    /// </summary>
        public string ResourceObjectID
        {
            get { return (string)this["RESOURCEOBJECTID"]; }
            set { this["RESOURCEOBJECTID"] = value; }
        }

        public string ResourceName
        {
            get { return (string)this["RESOURCENAME"]; }
            set { this["RESOURCENAME"] = value; }
        }

        public string ResourceName_Shadow
        {
            get { return (string)this["RESOURCENAME_SHADOW"]; }
        }

    /// <summary>
    /// En Son Güncelleyen Saha(Merkez hariç)
    /// </summary>
        public Guid? LastUpdateRealSiteGuid
        {
            get { return (Guid?)this["LASTUPDATEREALSITEGUID"]; }
            set { this["LASTUPDATEREALSITEGUID"] = value; }
        }

    /// <summary>
    /// En Son Güncelleyen Saha
    /// </summary>
        public Guid? LastUpdateSiteGuid
        {
            get { return (Guid?)this["LASTUPDATESITEGUID"]; }
            set { this["LASTUPDATESITEGUID"] = value; }
        }

    /// <summary>
    /// Havale Edilebilen Kaynaklar
    /// </summary>
        public ReferableHospital ReferableHospital
        {
            get { return (ReferableHospital)((ITTObject)this).GetParent("REFERABLEHOSPITAL"); }
            set { this["REFERABLEHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ReferableResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReferableResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReferableResource(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReferableResource(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReferableResource(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REFERABLERESOURCE", dataRow) { }
        protected ReferableResource(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REFERABLERESOURCE", dataRow, isImported) { }
        public ReferableResource(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReferableResource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReferableResource() : base() { }

    }
}