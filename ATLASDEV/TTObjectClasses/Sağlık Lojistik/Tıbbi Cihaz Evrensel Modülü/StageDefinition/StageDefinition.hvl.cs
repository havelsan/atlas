
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StageDefinition")] 

    /// <summary>
    /// Kademe Tanım
    /// </summary>
    public  partial class StageDefinition : TTDefinitionSet
    {
        public class StageDefinitionList : TTObjectCollection<StageDefinition> { }
                    
        public class ChildStageDefinitionCollection : TTObject.TTChildObjectCollection<StageDefinition>
        {
            public ChildStageDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStageDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class StageDefFormNQL_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STAGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
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

            public StageDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public StageDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected StageDefFormNQL_Class() : base() { }
        }

        public static BindingList<StageDefinition.StageDefFormNQL_Class> StageDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STAGEDEFINITION"].QueryDefs["StageDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StageDefinition.StageDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<StageDefinition.StageDefFormNQL_Class> StageDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STAGEDEFINITION"].QueryDefs["StageDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<StageDefinition.StageDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kademe Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StageDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STAGEDEFINITION", dataRow) { }
        protected StageDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STAGEDEFINITION", dataRow, isImported) { }
        public StageDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StageDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StageDefinition() : base() { }

    }
}