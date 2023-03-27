
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProvisionTypeCondition")] 

    public  partial class ProvisionTypeCondition : RuleConditionBase
    {
        public class ProvisionTypeConditionList : TTObjectCollection<ProvisionTypeCondition> { }
                    
        public class ChildProvisionTypeConditionCollection : TTObject.TTChildObjectCollection<ProvisionTypeCondition>
        {
            public ChildProvisionTypeConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProvisionTypeConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Provizyon Tipi
    /// </summary>
        public ProvizyonTipi ProvisionType
        {
            get { return (ProvizyonTipi)((ITTObject)this).GetParent("PROVISIONTYPE"); }
            set { this["PROVISIONTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProvisionTypeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProvisionTypeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProvisionTypeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProvisionTypeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProvisionTypeCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROVISIONTYPECONDITION", dataRow) { }
        protected ProvisionTypeCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROVISIONTYPECONDITION", dataRow, isImported) { }
        public ProvisionTypeCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProvisionTypeCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProvisionTypeCondition() : base() { }

    }
}