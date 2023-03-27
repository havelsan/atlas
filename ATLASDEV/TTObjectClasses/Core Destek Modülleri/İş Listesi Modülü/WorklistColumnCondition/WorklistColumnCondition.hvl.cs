
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WorklistColumnCondition")] 

    public  partial class WorklistColumnCondition : TerminologyManagerDef
    {
        public class WorklistColumnConditionList : TTObjectCollection<WorklistColumnCondition> { }
                    
        public class ChildWorklistColumnConditionCollection : TTObject.TTChildObjectCollection<WorklistColumnCondition>
        {
            public ChildWorklistColumnConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWorklistColumnConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public bool? IsBold
        {
            get { return (bool?)this["ISBOLD"]; }
            set { this["ISBOLD"] = value; }
        }

        public string ConditionColor
        {
            get { return (string)this["CONDITIONCOLOR"]; }
            set { this["CONDITIONCOLOR"] = value; }
        }

        public string ConditionValue
        {
            get { return (string)this["CONDITIONVALUE"]; }
            set { this["CONDITIONVALUE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public WorkListColumnDefinition WorklistColumnDefinition
        {
            get { return (WorkListColumnDefinition)((ITTObject)this).GetParent("WORKLISTCOLUMNDEFINITION"); }
            set { this["WORKLISTCOLUMNDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WorklistColumnCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WorklistColumnCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WorklistColumnCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WorklistColumnCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WorklistColumnCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WORKLISTCOLUMNCONDITION", dataRow) { }
        protected WorklistColumnCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WORKLISTCOLUMNCONDITION", dataRow, isImported) { }
        public WorklistColumnCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WorklistColumnCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WorklistColumnCondition() : base() { }

    }
}