
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SymptomDefinition")] 

    public  partial class SymptomDefinition : TerminologyManagerDef
    {
        public class SymptomDefinitionList : TTObjectCollection<SymptomDefinition> { }
                    
        public class ChildSymptomDefinitionCollection : TTObject.TTChildObjectCollection<SymptomDefinition>
        {
            public ChildSymptomDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSymptomDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSymptomDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYMPTOMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? VademecumID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VADEMECUMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYMPTOMDEFINITION"].AllPropertyDefs["VADEMECUMID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetSymptomDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSymptomDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSymptomDefinitionList_Class() : base() { }
        }

        public static BindingList<SymptomDefinition.GetSymptomDefinitionList_Class> GetSymptomDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYMPTOMDEFINITION"].QueryDefs["GetSymptomDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SymptomDefinition.GetSymptomDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SymptomDefinition.GetSymptomDefinitionList_Class> GetSymptomDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYMPTOMDEFINITION"].QueryDefs["GetSymptomDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SymptomDefinition.GetSymptomDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public long? VademecumID
        {
            get { return (long?)this["VADEMECUMID"]; }
            set { this["VADEMECUMID"] = value; }
        }

        protected SymptomDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SymptomDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SymptomDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SymptomDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SymptomDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYMPTOMDEFINITION", dataRow) { }
        protected SymptomDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYMPTOMDEFINITION", dataRow, isImported) { }
        public SymptomDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SymptomDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SymptomDefinition() : base() { }

    }
}