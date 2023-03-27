
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorkLoadPriceDefinition")] 

    public  partial class WorkLoadPriceDefinition : TerminologyManagerDef
    {
        public class WorkLoadPriceDefinitionList : TTObjectCollection<WorkLoadPriceDefinition> { }
                    
        public class ChildWorkLoadPriceDefinitionCollection : TTObject.TTChildObjectCollection<WorkLoadPriceDefinition>
        {
            public ChildWorkLoadPriceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorkLoadPriceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWorkLoadPriceDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Currency? EngineerWorkLoadPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGINEERWORKLOADPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKLOADPRICEDEFINITION"].AllPropertyDefs["ENGINEERWORKLOADPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TechnicianWorkLoadPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANWORKLOADPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WORKLOADPRICEDEFINITION"].AllPropertyDefs["TECHNICIANWORKLOADPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetWorkLoadPriceDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkLoadPriceDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkLoadPriceDefinitionList_Class() : base() { }
        }

        public static BindingList<WorkLoadPriceDefinition.GetWorkLoadPriceDefinitionList_Class> GetWorkLoadPriceDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKLOADPRICEDEFINITION"].QueryDefs["GetWorkLoadPriceDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkLoadPriceDefinition.GetWorkLoadPriceDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<WorkLoadPriceDefinition.GetWorkLoadPriceDefinitionList_Class> GetWorkLoadPriceDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WORKLOADPRICEDEFINITION"].QueryDefs["GetWorkLoadPriceDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<WorkLoadPriceDefinition.GetWorkLoadPriceDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Mühendis Saat Ücreti
    /// </summary>
        public Currency? EngineerWorkLoadPrice
        {
            get { return (Currency?)this["ENGINEERWORKLOADPRICE"]; }
            set { this["ENGINEERWORKLOADPRICE"] = value; }
        }

    /// <summary>
    /// Teknisyen Saat Ücreti
    /// </summary>
        public Currency? TechnicianWorkLoadPrice
        {
            get { return (Currency?)this["TECHNICIANWORKLOADPRICE"]; }
            set { this["TECHNICIANWORKLOADPRICE"] = value; }
        }

        protected WorkLoadPriceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorkLoadPriceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorkLoadPriceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorkLoadPriceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorkLoadPriceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKLOADPRICEDEFINITION", dataRow) { }
        protected WorkLoadPriceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKLOADPRICEDEFINITION", dataRow, isImported) { }
        public WorkLoadPriceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorkLoadPriceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorkLoadPriceDefinition() : base() { }

    }
}