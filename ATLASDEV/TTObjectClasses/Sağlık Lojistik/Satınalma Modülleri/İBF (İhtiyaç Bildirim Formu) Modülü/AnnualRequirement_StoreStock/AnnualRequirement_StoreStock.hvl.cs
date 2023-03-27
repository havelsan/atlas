
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnualRequirement_StoreStock")] 

    public  partial class AnnualRequirement_StoreStock : TTObject
    {
        public class AnnualRequirement_StoreStockList : TTObjectCollection<AnnualRequirement_StoreStock> { }
                    
        public class ChildAnnualRequirement_StoreStockCollection : TTObject.TTChildObjectCollection<AnnualRequirement_StoreStock>
        {
            public ChildAnnualRequirement_StoreStockCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnualRequirement_StoreStockCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public AnnualRequirementDetailInList AnnualRequirementDetailInList
        {
            get { return (AnnualRequirementDetailInList)((ITTObject)this).GetParent("ANNUALREQUIREMENTDETAILINLIST"); }
            set { this["ANNUALREQUIREMENTDETAILINLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnnualRequirementDetailOutOfList AnnualRequirementDetOutOfList
        {
            get { return (AnnualRequirementDetailOutOfList)((ITTObject)this).GetParent("ANNUALREQUIREMENTDETOUTOFLIST"); }
            set { this["ANNUALREQUIREMENTDETOUTOFLIST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnnualRequirement_StoreStock(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnualRequirement_StoreStock(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnualRequirement_StoreStock(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnualRequirement_StoreStock(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnualRequirement_StoreStock(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNUALREQUIREMENT_STORESTOCK", dataRow) { }
        protected AnnualRequirement_StoreStock(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNUALREQUIREMENT_STORESTOCK", dataRow, isImported) { }
        public AnnualRequirement_StoreStock(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnualRequirement_StoreStock(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnualRequirement_StoreStock() : base() { }

    }
}