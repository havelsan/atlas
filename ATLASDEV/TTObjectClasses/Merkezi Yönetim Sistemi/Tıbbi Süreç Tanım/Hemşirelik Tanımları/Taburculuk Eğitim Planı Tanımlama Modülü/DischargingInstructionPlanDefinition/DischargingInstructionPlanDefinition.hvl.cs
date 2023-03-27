
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DischargingInstructionPlanDefinition")] 

    public  partial class DischargingInstructionPlanDefinition : TerminologyManagerDef
    {
        public class DischargingInstructionPlanDefinitionList : TTObjectCollection<DischargingInstructionPlanDefinition> { }
                    
        public class ChildDischargingInstructionPlanDefinitionCollection : TTObject.TTChildObjectCollection<DischargingInstructionPlanDefinition>
        {
            public ChildDischargingInstructionPlanDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDischargingInstructionPlanDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDischargingInstructionPlan_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISCHARGINGINSTRUCTIONPLANDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDischargingInstructionPlan_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDischargingInstructionPlan_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDischargingInstructionPlan_Class() : base() { }
        }

        public static BindingList<DischargingInstructionPlanDefinition.GetDischargingInstructionPlan_Class> GetDischargingInstructionPlan(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGINGINSTRUCTIONPLANDEFINITION"].QueryDefs["GetDischargingInstructionPlan"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DischargingInstructionPlanDefinition.GetDischargingInstructionPlan_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DischargingInstructionPlanDefinition.GetDischargingInstructionPlan_Class> GetDischargingInstructionPlan(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGINGINSTRUCTIONPLANDEFINITION"].QueryDefs["GetDischargingInstructionPlan"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DischargingInstructionPlanDefinition.GetDischargingInstructionPlan_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DischargingInstructionPlanDefinition> GetDischargingInstrctPlanDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGINGINSTRUCTIONPLANDEFINITION"].QueryDefs["GetDischargingInstrctPlanDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DischargingInstructionPlanDefinition>(queryDef, paramList);
        }

        public static BindingList<DischargingInstructionPlanDefinition> GetAllDischargingInstructionPlanDefinitionList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCHARGINGINSTRUCTIONPLANDEFINITION"].QueryDefs["GetAllDischargingInstructionPlanDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DischargingInstructionPlanDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Taburculuk Eğitim Planı
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

        protected DischargingInstructionPlanDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DischargingInstructionPlanDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DischargingInstructionPlanDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DischargingInstructionPlanDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DischargingInstructionPlanDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISCHARGINGINSTRUCTIONPLANDEFINITION", dataRow) { }
        protected DischargingInstructionPlanDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISCHARGINGINSTRUCTIONPLANDEFINITION", dataRow, isImported) { }
        public DischargingInstructionPlanDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DischargingInstructionPlanDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DischargingInstructionPlanDefinition() : base() { }

    }
}