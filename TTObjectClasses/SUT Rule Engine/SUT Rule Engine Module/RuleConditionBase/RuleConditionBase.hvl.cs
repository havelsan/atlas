
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RuleConditionBase")] 

    public  abstract  partial class RuleConditionBase : TTObject
    {
        public class RuleConditionBaseList : TTObjectCollection<RuleConditionBase> { }
                    
        public class ChildRuleConditionBaseCollection : TTObject.TTChildObjectCollection<RuleConditionBase>
        {
            public ChildRuleConditionBaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRuleConditionBaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşleç
    /// </summary>
        public OperatorTypeEnum? OperatorType
        {
            get { return (OperatorTypeEnum?)(int?)this["OPERATORTYPE"]; }
            set { this["OPERATORTYPE"] = value; }
        }

    /// <summary>
    /// Kural-Kural Koşulları
    /// </summary>
        public RuleBase Rule
        {
            get { return (RuleBase)((ITTObject)this).GetParent("RULE"); }
            set { this["RULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RuleConditionBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RuleConditionBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RuleConditionBase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RuleConditionBase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RuleConditionBase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RULECONDITIONBASE", dataRow) { }
        protected RuleConditionBase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RULECONDITIONBASE", dataRow, isImported) { }
        public RuleConditionBase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RuleConditionBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RuleConditionBase() : base() { }

    }
}