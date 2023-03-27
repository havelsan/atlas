
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RuleSetRule")] 

    public  partial class RuleSetRule : TTObject
    {
        public class RuleSetRuleList : TTObjectCollection<RuleSetRule> { }
                    
        public class ChildRuleSetRuleCollection : TTObject.TTChildObjectCollection<RuleSetRule>
        {
            public ChildRuleSetRuleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRuleSetRuleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kural
    /// </summary>
        public RuleBase Rule
        {
            get { return (RuleBase)((ITTObject)this).GetParent("RULE"); }
            set { this["RULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Seti-Kural Seti Kuralları
    /// </summary>
        public RuleSet RuleSet
        {
            get { return (RuleSet)((ITTObject)this).GetParent("RULESET"); }
            set { this["RULESET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RuleSetRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RuleSetRule(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RuleSetRule(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RuleSetRule(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RuleSetRule(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RULESETRULE", dataRow) { }
        protected RuleSetRule(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RULESETRULE", dataRow, isImported) { }
        public RuleSetRule(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RuleSetRule(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RuleSetRule() : base() { }

    }
}