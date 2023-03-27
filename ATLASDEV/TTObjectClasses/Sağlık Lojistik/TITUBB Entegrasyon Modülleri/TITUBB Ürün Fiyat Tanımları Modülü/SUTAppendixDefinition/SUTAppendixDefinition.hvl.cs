
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SUTAppendixDefinition")] 

    /// <summary>
    /// TITUBB SUT Ek Liste Tanımı
    /// </summary>
    public  partial class SUTAppendixDefinition : TerminologyManagerDef
    {
        public class SUTAppendixDefinitionList : TTObjectCollection<SUTAppendixDefinition> { }
                    
        public class ChildSUTAppendixDefinitionCollection : TTObject.TTChildObjectCollection<SUTAppendixDefinition>
        {
            public ChildSUTAppendixDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSUTAppendixDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSUTAppendixDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUTAPPENDIXDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSUTAppendixDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSUTAppendixDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSUTAppendixDefinition_Class() : base() { }
        }

        public static BindingList<SUTAppendixDefinition.GetSUTAppendixDefinition_Class> GetSUTAppendixDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUTAPPENDIXDEFINITION"].QueryDefs["GetSUTAppendixDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SUTAppendixDefinition.GetSUTAppendixDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SUTAppendixDefinition.GetSUTAppendixDefinition_Class> GetSUTAppendixDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUTAPPENDIXDEFINITION"].QueryDefs["GetSUTAppendixDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SUTAppendixDefinition.GetSUTAppendixDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// TITUBBSUTAppendixID
    /// </summary>
        public string TITUBBSUTAppendixID
        {
            get { return (string)this["TITUBBSUTAPPENDIXID"]; }
            set { this["TITUBBSUTAPPENDIXID"] = value; }
        }

        protected SUTAppendixDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SUTAppendixDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SUTAppendixDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SUTAppendixDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SUTAppendixDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUTAPPENDIXDEFINITION", dataRow) { }
        protected SUTAppendixDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUTAPPENDIXDEFINITION", dataRow, isImported) { }
        public SUTAppendixDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SUTAppendixDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SUTAppendixDefinition() : base() { }

    }
}