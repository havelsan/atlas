
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommittee_ExplanationOfRejectionGrid")] 

    public  partial class HealthCommittee_ExplanationOfRejectionGrid : ExplanationOfRejectionGrid
    {
        public class HealthCommittee_ExplanationOfRejectionGridList : TTObjectCollection<HealthCommittee_ExplanationOfRejectionGrid> { }
                    
        public class ChildHealthCommittee_ExplanationOfRejectionGridCollection : TTObject.TTChildObjectCollection<HealthCommittee_ExplanationOfRejectionGrid>
        {
            public ChildHealthCommittee_ExplanationOfRejectionGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommittee_ExplanationOfRejectionGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExplanationOfRejectionByParentObjectID_Class : TTReportNqlObject 
        {
            public Guid? Doctor
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DOCTOR"]);
                }
            }

            public object ExplanationOfRejection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPLANATIONOFREJECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_EXPLANATIONOFREJECTIONGRID"].AllPropertyDefs["EXPLANATIONOFREJECTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public GetExplanationOfRejectionByParentObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExplanationOfRejectionByParentObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExplanationOfRejectionByParentObjectID_Class() : base() { }
        }

    /// <summary>
    /// Parent OnjectId ile HealthCommittee_ExplanationOfRejectionGrid i get eder
    /// </summary>
        public static BindingList<HealthCommittee_ExplanationOfRejectionGrid.GetExplanationOfRejectionByParentObjectID_Class> GetExplanationOfRejectionByParentObjectID(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_EXPLANATIONOFREJECTIONGRID"].QueryDefs["GetExplanationOfRejectionByParentObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommittee_ExplanationOfRejectionGrid.GetExplanationOfRejectionByParentObjectID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Parent OnjectId ile HealthCommittee_ExplanationOfRejectionGrid i get eder
    /// </summary>
        public static BindingList<HealthCommittee_ExplanationOfRejectionGrid.GetExplanationOfRejectionByParentObjectID_Class> GetExplanationOfRejectionByParentObjectID(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEALTHCOMMITTEE_EXPLANATIONOFREJECTIONGRID"].QueryDefs["GetExplanationOfRejectionByParentObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HealthCommittee_ExplanationOfRejectionGrid.GetExplanationOfRejectionByParentObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        protected HealthCommittee_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommittee_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommittee_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommittee_ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommittee_ExplanationOfRejectionGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEE_EXPLANATIONOFREJECTIONGRID", dataRow) { }
        protected HealthCommittee_ExplanationOfRejectionGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEE_EXPLANATIONOFREJECTIONGRID", dataRow, isImported) { }
        public HealthCommittee_ExplanationOfRejectionGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommittee_ExplanationOfRejectionGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommittee_ExplanationOfRejectionGrid() : base() { }

    }
}