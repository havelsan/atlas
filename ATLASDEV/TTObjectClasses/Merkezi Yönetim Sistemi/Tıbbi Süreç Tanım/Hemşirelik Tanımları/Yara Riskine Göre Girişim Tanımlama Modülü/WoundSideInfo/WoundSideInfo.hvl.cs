
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WoundSideInfo")] 

    /// <summary>
    /// Yara Taraf Bilgisi
    /// </summary>
    public  partial class WoundSideInfo : TerminologyManagerDef
    {
        public class WoundSideInfoList : TTObjectCollection<WoundSideInfo> { }
                    
        public class ChildWoundSideInfoCollection : TTObject.TTChildObjectCollection<WoundSideInfo>
        {
            public ChildWoundSideInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWoundSideInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWoundSide_RQ_Class : TTReportNqlObject 
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

            public string SideInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIDEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDSIDEINFO"].AllPropertyDefs["SIDEINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SideInfo_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIDEINFO_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDSIDEINFO"].AllPropertyDefs["SIDEINFO_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWoundSide_RQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWoundSide_RQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWoundSide_RQ_Class() : base() { }
        }

        public static BindingList<WoundSideInfo.GetWoundSide_RQ_Class> GetWoundSide_RQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDSIDEINFO"].QueryDefs["GetWoundSide_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundSideInfo.GetWoundSide_RQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WoundSideInfo.GetWoundSide_RQ_Class> GetWoundSide_RQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDSIDEINFO"].QueryDefs["GetWoundSide_RQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundSideInfo.GetWoundSide_RQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// taraf
    /// </summary>
        public string SideInfo
        {
            get { return (string)this["SIDEINFO"]; }
            set { this["SIDEINFO"] = value; }
        }

    /// <summary>
    /// Taraf
    /// </summary>
        public string SideInfo_Shadow
        {
            get { return (string)this["SIDEINFO_SHADOW"]; }
            set { this["SIDEINFO_SHADOW"] = value; }
        }

        protected WoundSideInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WoundSideInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WoundSideInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WoundSideInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WoundSideInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WOUNDSIDEINFO", dataRow) { }
        protected WoundSideInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WOUNDSIDEINFO", dataRow, isImported) { }
        public WoundSideInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WoundSideInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WoundSideInfo() : base() { }

    }
}