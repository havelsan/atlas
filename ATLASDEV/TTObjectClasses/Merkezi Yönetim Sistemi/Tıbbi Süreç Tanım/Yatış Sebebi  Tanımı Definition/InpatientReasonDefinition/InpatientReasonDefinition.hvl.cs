
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientReasonDefinition")] 

    public  partial class InpatientReasonDefinition : TerminologyManagerDef
    {
        public class InpatientReasonDefinitionList : TTObjectCollection<InpatientReasonDefinition> { }
                    
        public class ChildInpatientReasonDefinitionCollection : TTObject.TTChildObjectCollection<InpatientReasonDefinition>
        {
            public ChildInpatientReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientReasonDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Reason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTREASONDEFINITION"].AllPropertyDefs["REASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientReasonDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientReasonDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientReasonDefinition_Class() : base() { }
        }

        public static BindingList<InpatientReasonDefinition> GetInpatientReasonDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTREASONDEFINITION"].QueryDefs["GetInpatientReasonDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<InpatientReasonDefinition>(queryDef, paramList);
        }

        public static BindingList<InpatientReasonDefinition.GetInpatientReasonDefinition_Class> GetInpatientReasonDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTREASONDEFINITION"].QueryDefs["GetInpatientReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientReasonDefinition.GetInpatientReasonDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InpatientReasonDefinition.GetInpatientReasonDefinition_Class> GetInpatientReasonDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTREASONDEFINITION"].QueryDefs["GetInpatientReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InpatientReasonDefinition.GetInpatientReasonDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Yatış Sebebi
    /// </summary>
        public string Reason
        {
            get { return (string)this["REASON"]; }
            set { this["REASON"] = value; }
        }

        protected InpatientReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTREASONDEFINITION", dataRow) { }
        protected InpatientReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTREASONDEFINITION", dataRow, isImported) { }
        public InpatientReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientReasonDefinition() : base() { }

    }
}