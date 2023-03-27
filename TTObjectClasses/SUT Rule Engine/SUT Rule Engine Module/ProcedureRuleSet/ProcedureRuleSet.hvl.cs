
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureRuleSet")] 

    public  partial class ProcedureRuleSet : TTObject
    {
        public class ProcedureRuleSetList : TTObjectCollection<ProcedureRuleSet> { }
                    
        public class ChildProcedureRuleSetCollection : TTObject.TTChildObjectCollection<ProcedureRuleSet>
        {
            public ChildProcedureRuleSetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureRuleSetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hizmet-Hizmet Kural Setleri
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kural Seti-Hizmet Kural Setleri
    /// </summary>
        public RuleSet RuleSet
        {
            get { return (RuleSet)((ITTObject)this).GetParent("RULESET"); }
            set { this["RULESET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcedureRuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureRuleSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureRuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureRuleSet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureRuleSet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDURERULESET", dataRow) { }
        protected ProcedureRuleSet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDURERULESET", dataRow, isImported) { }
        public ProcedureRuleSet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureRuleSet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureRuleSet() : base() { }

    }
}