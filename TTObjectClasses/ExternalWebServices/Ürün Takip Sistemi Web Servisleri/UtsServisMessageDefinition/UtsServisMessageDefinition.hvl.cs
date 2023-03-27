
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UtsServisMessageDefinition")] 

    public  partial class UtsServisMessageDefinition : TerminologyManagerDef
    {
        public class UtsServisMessageDefinitionList : TTObjectCollection<UtsServisMessageDefinition> { }
                    
        public class ChildUtsServisMessageDefinitionCollection : TTObject.TTChildObjectCollection<UtsServisMessageDefinition>
        {
            public ChildUtsServisMessageDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUtsServisMessageDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUtsServisMessageDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UTSSERVISMESSAGEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UTSSERVISMESSAGEDEFINITION"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUtsServisMessageDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUtsServisMessageDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUtsServisMessageDefinitionList_Class() : base() { }
        }

        public static BindingList<UtsServisMessageDefinition.GetUtsServisMessageDefinitionList_Class> GetUtsServisMessageDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UTSSERVISMESSAGEDEFINITION"].QueryDefs["GetUtsServisMessageDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UtsServisMessageDefinition.GetUtsServisMessageDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UtsServisMessageDefinition.GetUtsServisMessageDefinitionList_Class> GetUtsServisMessageDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UTSSERVISMESSAGEDEFINITION"].QueryDefs["GetUtsServisMessageDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UtsServisMessageDefinition.GetUtsServisMessageDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

        protected UtsServisMessageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UtsServisMessageDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UtsServisMessageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UtsServisMessageDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UtsServisMessageDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UTSSERVISMESSAGEDEFINITION", dataRow) { }
        protected UtsServisMessageDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UTSSERVISMESSAGEDEFINITION", dataRow, isImported) { }
        public UtsServisMessageDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UtsServisMessageDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UtsServisMessageDefinition() : base() { }

    }
}