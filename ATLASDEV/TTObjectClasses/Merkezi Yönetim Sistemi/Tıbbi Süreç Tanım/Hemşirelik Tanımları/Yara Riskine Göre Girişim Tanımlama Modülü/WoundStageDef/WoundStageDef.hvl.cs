
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WoundStageDef")] 

    public  partial class WoundStageDef : TerminologyManagerDef
    {
        public class WoundStageDefList : TTObjectCollection<WoundStageDef> { }
                    
        public class ChildWoundStageDefCollection : TTObject.TTChildObjectCollection<WoundStageDef>
        {
            public ChildWoundStageDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWoundStageDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWoundStagesRQ_Class : TTReportNqlObject 
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDSTAGEDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsDepthNeeded
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDEPTHNEEDED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WOUNDSTAGEDEF"].AllPropertyDefs["ISDEPTHNEEDED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetWoundStagesRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWoundStagesRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWoundStagesRQ_Class() : base() { }
        }

        public static BindingList<WoundStageDef> GetWoundStage(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDSTAGEDEF"].QueryDefs["GetWoundStage"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<WoundStageDef>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<WoundStageDef.GetWoundStagesRQ_Class> GetWoundStagesRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDSTAGEDEF"].QueryDefs["GetWoundStagesRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundStageDef.GetWoundStagesRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WoundStageDef.GetWoundStagesRQ_Class> GetWoundStagesRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WOUNDSTAGEDEF"].QueryDefs["GetWoundStagesRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WoundStageDef.GetWoundStagesRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Derinlik Bilgisi Gerekli mi?
    /// </summary>
        public bool? IsDepthNeeded
        {
            get { return (bool?)this["ISDEPTHNEEDED"]; }
            set { this["ISDEPTHNEEDED"] = value; }
        }

        protected WoundStageDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WoundStageDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WoundStageDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WoundStageDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WoundStageDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WOUNDSTAGEDEF", dataRow) { }
        protected WoundStageDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WOUNDSTAGEDEF", dataRow, isImported) { }
        public WoundStageDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WoundStageDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WoundStageDef() : base() { }

    }
}