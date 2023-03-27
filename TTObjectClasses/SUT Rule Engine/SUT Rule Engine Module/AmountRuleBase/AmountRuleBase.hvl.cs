
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AmountRuleBase")] 

    public  abstract  partial class AmountRuleBase : RuleBase
    {
        public class AmountRuleBaseList : TTObjectCollection<AmountRuleBase> { }
                    
        public class ChildAmountRuleBaseCollection : TTObject.TTChildObjectCollection<AmountRuleBase>
        {
            public ChildAmountRuleBaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAmountRuleBaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Adet
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        protected AmountRuleBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AmountRuleBase(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AmountRuleBase(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AmountRuleBase(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AmountRuleBase(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AMOUNTRULEBASE", dataRow) { }
        protected AmountRuleBase(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AMOUNTRULEBASE", dataRow, isImported) { }
        public AmountRuleBase(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AmountRuleBase(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AmountRuleBase() : base() { }

    }
}