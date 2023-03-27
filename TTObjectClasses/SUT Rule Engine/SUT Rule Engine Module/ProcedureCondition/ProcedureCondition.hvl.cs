
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureCondition")] 

    public  partial class ProcedureCondition : RuleConditionBase
    {
        public class ProcedureConditionList : TTObjectCollection<ProcedureCondition> { }
                    
        public class ChildProcedureConditionCollection : TTObject.TTChildObjectCollection<ProcedureCondition>
        {
            public ChildProcedureConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProcedureCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDURECONDITION", dataRow) { }
        protected ProcedureCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDURECONDITION", dataRow, isImported) { }
        public ProcedureCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureCondition() : base() { }

    }
}