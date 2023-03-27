
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ToothDefinition")] 

    public  partial class ToothDefinition : TerminologyManagerDef
    {
        public class ToothDefinitionList : TTObjectCollection<ToothDefinition> { }
                    
        public class ChildToothDefinitionCollection : TTObject.TTChildObjectCollection<ToothDefinition>
        {
            public ChildToothDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildToothDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetToothList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOOTHDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetToothList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetToothList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetToothList_Class() : base() { }
        }

        public static BindingList<ToothDefinition.GetToothList_Class> GetToothList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOOTHDEFINITION"].QueryDefs["GetToothList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ToothDefinition.GetToothList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ToothDefinition.GetToothList_Class> GetToothList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOOTHDEFINITION"].QueryDefs["GetToothList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ToothDefinition.GetToothList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

        protected ToothDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ToothDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ToothDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ToothDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ToothDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TOOTHDEFINITION", dataRow) { }
        protected ToothDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TOOTHDEFINITION", dataRow, isImported) { }
        public ToothDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ToothDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ToothDefinition() : base() { }

    }
}