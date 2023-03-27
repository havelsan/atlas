
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SexCondition")] 

    public  partial class SexCondition : RuleConditionBase
    {
        public class SexConditionList : TTObjectCollection<SexCondition> { }
                    
        public class ChildSexConditionCollection : TTObject.TTChildObjectCollection<SexCondition>
        {
            public ChildSexConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSexConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

        protected SexCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SexCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SexCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SexCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SexCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEXCONDITION", dataRow) { }
        protected SexCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEXCONDITION", dataRow, isImported) { }
        public SexCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SexCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SexCondition() : base() { }

    }
}