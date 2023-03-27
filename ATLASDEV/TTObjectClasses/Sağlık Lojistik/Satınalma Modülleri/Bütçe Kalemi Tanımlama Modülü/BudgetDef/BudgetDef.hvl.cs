
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BudgetDef")] 

    public  partial class BudgetDef : TTDefinitionSet
    {
        public class BudgetDefList : TTObjectCollection<BudgetDef> { }
                    
        public class ChildBudgetDefCollection : TTObject.TTChildObjectCollection<BudgetDef>
        {
            public ChildBudgetDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBudgetDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBudgetDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public BudgetType? BudgetItemType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETITEMTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].AllPropertyDefs["BUDGETITEMTYPE"].DataType;
                    return (BudgetType?)(int)dataType.ConvertValue(val);
                }
            }

            public BudgetType? Budgettypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].AllPropertyDefs["BUDGETITEMTYPE"].DataType;
                    return (BudgetType?)(int)dataType.ConvertValue(val);
                }
            }

            public string Code1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].AllPropertyDefs["CODE1"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].AllPropertyDefs["CODE2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].AllPropertyDefs["CODE3"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].AllPropertyDefs["CODE4"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Definition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBudgetDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBudgetDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBudgetDef_Class() : base() { }
        }

        public static BindingList<BudgetDef.GetBudgetDef_Class> GetBudgetDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].QueryDefs["GetBudgetDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BudgetDef.GetBudgetDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BudgetDef.GetBudgetDef_Class> GetBudgetDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BUDGETDEF"].QueryDefs["GetBudgetDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BudgetDef.GetBudgetDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

        public string Code1
        {
            get { return (string)this["CODE1"]; }
            set { this["CODE1"] = value; }
        }

        public string Code2
        {
            get { return (string)this["CODE2"]; }
            set { this["CODE2"] = value; }
        }

        public string Code3
        {
            get { return (string)this["CODE3"]; }
            set { this["CODE3"] = value; }
        }

        public string Code4
        {
            get { return (string)this["CODE4"]; }
            set { this["CODE4"] = value; }
        }

        public BudgetType? BudgetItemType
        {
            get { return (BudgetType?)(int?)this["BUDGETITEMTYPE"]; }
            set { this["BUDGETITEMTYPE"] = value; }
        }

        protected BudgetDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BudgetDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BudgetDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BudgetDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BudgetDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BUDGETDEF", dataRow) { }
        protected BudgetDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BUDGETDEF", dataRow, isImported) { }
        public BudgetDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BudgetDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BudgetDef() : base() { }

    }
}