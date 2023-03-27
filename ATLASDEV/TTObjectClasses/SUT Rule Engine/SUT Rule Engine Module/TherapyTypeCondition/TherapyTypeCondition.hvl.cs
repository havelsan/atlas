
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TherapyTypeCondition")] 

    public  partial class TherapyTypeCondition : RuleConditionBase
    {
        public class TherapyTypeConditionList : TTObjectCollection<TherapyTypeCondition> { }
                    
        public class ChildTherapyTypeConditionCollection : TTObject.TTChildObjectCollection<TherapyTypeCondition>
        {
            public ChildTherapyTypeConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTherapyTypeConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tedavi Tipi
    /// </summary>
        public TedaviTipi TherapyType
        {
            get { return (TedaviTipi)((ITTObject)this).GetParent("THERAPYTYPE"); }
            set { this["THERAPYTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TherapyTypeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TherapyTypeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TherapyTypeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TherapyTypeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TherapyTypeCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "THERAPYTYPECONDITION", dataRow) { }
        protected TherapyTypeCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "THERAPYTYPECONDITION", dataRow, isImported) { }
        public TherapyTypeCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TherapyTypeCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TherapyTypeCondition() : base() { }

    }
}