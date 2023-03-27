
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BudgetTypeDefinition")] 

    public  partial class BudgetTypeDefinition : TerminologyManagerDef
    {
        public class BudgetTypeDefinitionList : TTObjectCollection<BudgetTypeDefinition> { }
                    
        public class ChildBudgetTypeDefinitionCollection : TTObject.TTChildObjectCollection<BudgetTypeDefinition>
        {
            public ChildBudgetTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBudgetTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBudgetTypeDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBudgetTypeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBudgetTypeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBudgetTypeDefinitionList_Class() : base() { }
        }

        public static BindingList<BudgetTypeDefinition.GetBudgetTypeDefinitionList_Class> GetBudgetTypeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].QueryDefs["GetBudgetTypeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BudgetTypeDefinition.GetBudgetTypeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BudgetTypeDefinition.GetBudgetTypeDefinitionList_Class> GetBudgetTypeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BUDGETTYPEDEFINITION"].QueryDefs["GetBudgetTypeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BudgetTypeDefinition.GetBudgetTypeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// MKYS Bütce Tanımı
    /// </summary>
        public MKYS_EButceTurEnum? MKYS_Butce
        {
            get { return (MKYS_EButceTurEnum?)(int?)this["MKYS_BUTCE"]; }
            set { this["MKYS_BUTCE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Bütce Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected BudgetTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BudgetTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BudgetTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BudgetTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BudgetTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BUDGETTYPEDEFINITION", dataRow) { }
        protected BudgetTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BUDGETTYPEDEFINITION", dataRow, isImported) { }
        public BudgetTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BudgetTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BudgetTypeDefinition() : base() { }

    }
}