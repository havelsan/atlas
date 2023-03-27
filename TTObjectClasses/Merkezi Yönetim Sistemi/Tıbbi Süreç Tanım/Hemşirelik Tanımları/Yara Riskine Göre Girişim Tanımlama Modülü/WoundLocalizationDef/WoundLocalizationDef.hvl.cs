
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WoundLocalizationDef")] 

    /// <summary>
    /// Yara riski lokalizasyon
    /// </summary>
    public  partial class WoundLocalizationDef : TerminologyManagerDef
    {
        public class WoundLocalizationDefList : TTObjectCollection<WoundLocalizationDef> { }
                    
        public class ChildWoundLocalizationDefCollection : TTObject.TTChildObjectCollection<WoundLocalizationDef>
        {
            public ChildWoundLocalizationDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWoundLocalizationDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWoundLocalizationRQ_Class : TTReportNqlObject 
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

            public string Localization
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALIZATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDLOCALIZATIONDEF"].AllPropertyDefs["LOCALIZATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Localization_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALIZATION_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDLOCALIZATIONDEF"].AllPropertyDefs["LOCALIZATION_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWoundLocalizationRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWoundLocalizationRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWoundLocalizationRQ_Class() : base() { }
        }

        public static BindingList<WoundLocalizationDef.GetWoundLocalizationRQ_Class> GetWoundLocalizationRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDLOCALIZATIONDEF"].QueryDefs["GetWoundLocalizationRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundLocalizationDef.GetWoundLocalizationRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WoundLocalizationDef.GetWoundLocalizationRQ_Class> GetWoundLocalizationRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDLOCALIZATIONDEF"].QueryDefs["GetWoundLocalizationRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundLocalizationDef.GetWoundLocalizationRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Lokalizasyon
    /// </summary>
        public string Localization
        {
            get { return (string)this["LOCALIZATION"]; }
            set { this["LOCALIZATION"] = value; }
        }

    /// <summary>
    /// Lokalizasyon
    /// </summary>
        public string Localization_Shadow
        {
            get { return (string)this["LOCALIZATION_SHADOW"]; }
        }

        protected WoundLocalizationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WoundLocalizationDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WoundLocalizationDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WoundLocalizationDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WoundLocalizationDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WOUNDLOCALIZATIONDEF", dataRow) { }
        protected WoundLocalizationDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WOUNDLOCALIZATIONDEF", dataRow, isImported) { }
        public WoundLocalizationDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WoundLocalizationDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WoundLocalizationDef() : base() { }

    }
}