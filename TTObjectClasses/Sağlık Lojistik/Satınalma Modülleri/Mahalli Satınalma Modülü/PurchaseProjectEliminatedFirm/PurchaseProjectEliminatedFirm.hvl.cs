
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseProjectEliminatedFirm")] 

    /// <summary>
    /// Mahalli Satınalmada Elenen Firmalar İçin Kullanılan Sınıf. Her Elenen Firma İçin Bir Adet Instance Yaratılır
    /// </summary>
    public  partial class PurchaseProjectEliminatedFirm : TTObject
    {
        public class PurchaseProjectEliminatedFirmList : TTObjectCollection<PurchaseProjectEliminatedFirm> { }
                    
        public class ChildPurchaseProjectEliminatedFirmCollection : TTObject.TTChildObjectCollection<PurchaseProjectEliminatedFirm>
        {
            public ChildPurchaseProjectEliminatedFirmCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseProjectEliminatedFirmCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Eleme Sebebi
    /// </summary>
        public string EliminatingReason
        {
            get { return (string)this["ELIMINATINGREASON"]; }
            set { this["ELIMINATINGREASON"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PurchaseProjectEliminatedFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseProjectEliminatedFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseProjectEliminatedFirm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseProjectEliminatedFirm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseProjectEliminatedFirm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEPROJECTELIMINATEDFIRM", dataRow) { }
        protected PurchaseProjectEliminatedFirm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEPROJECTELIMINATEDFIRM", dataRow, isImported) { }
        public PurchaseProjectEliminatedFirm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseProjectEliminatedFirm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseProjectEliminatedFirm() : base() { }

    }
}