
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchasingCommittee")] 

    /// <summary>
    /// Satınalma Komisyonu İçin Kullanılan Sınıftır
    /// </summary>
    public  partial class PurchasingCommittee : Committee
    {
        public class PurchasingCommitteeList : TTObjectCollection<PurchasingCommittee> { }
                    
        public class ChildPurchasingCommitteeCollection : TTObject.TTChildObjectCollection<PurchasingCommittee>
        {
            public ChildPurchasingCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchasingCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        protected PurchasingCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchasingCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchasingCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchasingCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchasingCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASINGCOMMITTEE", dataRow) { }
        protected PurchasingCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASINGCOMMITTEE", dataRow, isImported) { }
        public PurchasingCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchasingCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchasingCommittee() : base() { }

    }
}