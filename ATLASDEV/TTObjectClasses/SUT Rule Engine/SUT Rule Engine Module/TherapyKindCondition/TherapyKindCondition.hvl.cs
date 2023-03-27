
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TherapyKindCondition")] 

    public  partial class TherapyKindCondition : RuleConditionBase
    {
        public class TherapyKindConditionList : TTObjectCollection<TherapyKindCondition> { }
                    
        public class ChildTherapyKindConditionCollection : TTObject.TTChildObjectCollection<TherapyKindCondition>
        {
            public ChildTherapyKindConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTherapyKindConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tedavi Türü
    /// </summary>
        public TedaviTuru TherapyKind
        {
            get { return (TedaviTuru)((ITTObject)this).GetParent("THERAPYKIND"); }
            set { this["THERAPYKIND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TherapyKindCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TherapyKindCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TherapyKindCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TherapyKindCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TherapyKindCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "THERAPYKINDCONDITION", dataRow) { }
        protected TherapyKindCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "THERAPYKINDCONDITION", dataRow, isImported) { }
        public TherapyKindCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TherapyKindCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TherapyKindCondition() : base() { }

    }
}