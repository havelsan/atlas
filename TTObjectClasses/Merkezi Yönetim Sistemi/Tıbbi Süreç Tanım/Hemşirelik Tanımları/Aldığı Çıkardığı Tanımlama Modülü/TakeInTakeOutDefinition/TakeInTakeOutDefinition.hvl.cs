
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakeInTakeOutDefinition")] 

    public  partial class TakeInTakeOutDefinition : TerminologyManagerDef
    {
        public class TakeInTakeOutDefinitionList : TTObjectCollection<TakeInTakeOutDefinition> { }
                    
        public class ChildTakeInTakeOutDefinitionCollection : TTObject.TTChildObjectCollection<TakeInTakeOutDefinition>
        {
            public ChildTakeInTakeOutDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakeInTakeOutDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakeInTakeOut_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TAKEINTAKEOUTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTakeInTakeOut_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakeInTakeOut_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakeInTakeOut_Class() : base() { }
        }

        public static BindingList<TakeInTakeOutDefinition> GetTakeInTakeOutDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKEINTAKEOUTDEFINITION"].QueryDefs["GetTakeInTakeOutDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<TakeInTakeOutDefinition>(queryDef, paramList);
        }

        public static BindingList<TakeInTakeOutDefinition.GetTakeInTakeOut_Class> GetTakeInTakeOut(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKEINTAKEOUTDEFINITION"].QueryDefs["GetTakeInTakeOut"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakeInTakeOutDefinition.GetTakeInTakeOut_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakeInTakeOutDefinition.GetTakeInTakeOut_Class> GetTakeInTakeOut(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKEINTAKEOUTDEFINITION"].QueryDefs["GetTakeInTakeOut"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TakeInTakeOutDefinition.GetTakeInTakeOut_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sıvı
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

        protected TakeInTakeOutDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakeInTakeOutDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakeInTakeOutDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakeInTakeOutDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakeInTakeOutDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKEINTAKEOUTDEFINITION", dataRow) { }
        protected TakeInTakeOutDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKEINTAKEOUTDEFINITION", dataRow, isImported) { }
        public TakeInTakeOutDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakeInTakeOutDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakeInTakeOutDefinition() : base() { }

    }
}