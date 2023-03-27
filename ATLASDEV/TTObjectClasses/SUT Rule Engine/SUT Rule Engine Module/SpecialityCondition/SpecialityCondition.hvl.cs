
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialityCondition")] 

    public  partial class SpecialityCondition : RuleConditionBase
    {
        public class SpecialityConditionList : TTObjectCollection<SpecialityCondition> { }
                    
        public class ChildSpecialityConditionCollection : TTObject.TTChildObjectCollection<SpecialityCondition>
        {
            public ChildSpecialityConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialityConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Uzmanlık
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SpecialityCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialityCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialityCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialityCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialityCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALITYCONDITION", dataRow) { }
        protected SpecialityCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALITYCONDITION", dataRow, isImported) { }
        public SpecialityCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialityCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialityCondition() : base() { }

    }
}