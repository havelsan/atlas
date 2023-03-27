
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AgeCondition")] 

    public  partial class AgeCondition : RuleConditionBase
    {
        public class AgeConditionList : TTObjectCollection<AgeCondition> { }
                    
        public class ChildAgeConditionCollection : TTObject.TTChildObjectCollection<AgeCondition>
        {
            public ChildAgeConditionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAgeConditionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlk Değer
    /// </summary>
        public int? FirstValue
        {
            get { return (int?)this["FIRSTVALUE"]; }
            set { this["FIRSTVALUE"] = value; }
        }

    /// <summary>
    /// Son Değer
    /// </summary>
        public int? LastValue
        {
            get { return (int?)this["LASTVALUE"]; }
            set { this["LASTVALUE"] = value; }
        }

    /// <summary>
    /// Yaş Tipi
    /// </summary>
        public AgeTypeEnum? AgeType
        {
            get { return (AgeTypeEnum?)(int?)this["AGETYPE"]; }
            set { this["AGETYPE"] = value; }
        }

        protected AgeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AgeCondition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AgeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AgeCondition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AgeCondition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AGECONDITION", dataRow) { }
        protected AgeCondition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AGECONDITION", dataRow, isImported) { }
        public AgeCondition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AgeCondition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AgeCondition() : base() { }

    }
}