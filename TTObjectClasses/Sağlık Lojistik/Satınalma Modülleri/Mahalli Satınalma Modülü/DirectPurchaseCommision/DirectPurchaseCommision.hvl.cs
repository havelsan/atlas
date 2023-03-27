
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DirectPurchaseCommision")] 

    /// <summary>
    /// Doğrudan Temin Komisyonu Üyelerinin Tutulduğu Sınıftır. Her Üye İçin Yeni Br Instance Yaratılır
    /// </summary>
    public  partial class DirectPurchaseCommision : CommisionMember
    {
        public class DirectPurchaseCommisionList : TTObjectCollection<DirectPurchaseCommision> { }
                    
        public class ChildDirectPurchaseCommisionCollection : TTObject.TTChildObjectCollection<DirectPurchaseCommision>
        {
            public ChildDirectPurchaseCommisionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDirectPurchaseCommisionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DirectPurchaseCommision(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DirectPurchaseCommision(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DirectPurchaseCommision(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DirectPurchaseCommision(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DirectPurchaseCommision(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIRECTPURCHASECOMMISION", dataRow) { }
        protected DirectPurchaseCommision(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIRECTPURCHASECOMMISION", dataRow, isImported) { }
        public DirectPurchaseCommision(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DirectPurchaseCommision(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DirectPurchaseCommision() : base() { }

    }
}