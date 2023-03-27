
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnnualRequirementItem")] 

    public  partial class AnnualRequirementItem : TerminologyManagerDef
    {
        public class AnnualRequirementItemList : TTObjectCollection<AnnualRequirementItem> { }
                    
        public class ChildAnnualRequirementItemCollection : TTObject.TTChildObjectCollection<AnnualRequirementItem>
        {
            public ChildAnnualRequirementItemCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnnualRequirementItemCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnnualRequirementItemsDefinition AnnualReqItemsDefinition
        {
            get { return (AnnualRequirementItemsDefinition)((ITTObject)this).GetParent("ANNUALREQITEMSDEFINITION"); }
            set { this["ANNUALREQITEMSDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnnualRequirementItem(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnnualRequirementItem(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnnualRequirementItem(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnnualRequirementItem(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnnualRequirementItem(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANNUALREQUIREMENTITEM", dataRow) { }
        protected AnnualRequirementItem(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANNUALREQUIREMENTITEM", dataRow, isImported) { }
        public AnnualRequirementItem(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnnualRequirementItem(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnnualRequirementItem() : base() { }

    }
}