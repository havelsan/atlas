
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugDeliveryActionDetail")] 

    public  partial class DrugDeliveryActionDetail : TTObject
    {
        public class DrugDeliveryActionDetailList : TTObjectCollection<DrugDeliveryActionDetail> { }
                    
        public class ChildDrugDeliveryActionDetailCollection : TTObject.TTChildObjectCollection<DrugDeliveryActionDetail>
        {
            public ChildDrugDeliveryActionDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugDeliveryActionDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlaç
    /// </summary>
        public string DrugName
        {
            get { return (string)this["DRUGNAME"]; }
            set { this["DRUGNAME"] = value; }
        }

    /// <summary>
    /// Kalan Miktar
    /// </summary>
        public double? ResDose
        {
            get { return (double?)this["RESDOSE"]; }
            set { this["RESDOSE"] = value; }
        }

        public DrugDeliveryAction DrugDeliveryAction
        {
            get { return (DrugDeliveryAction)((ITTObject)this).GetParent("DRUGDELIVERYACTION"); }
            set { this["DRUGDELIVERYACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderTransaction DrugOrderTransaction
        {
            get { return (DrugOrderTransaction)((ITTObject)this).GetParent("DRUGORDERTRANSACTION"); }
            set { this["DRUGORDERTRANSACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugOrderDetailsCollection()
        {
            _DrugOrderDetails = new DrugOrderDetail.ChildDrugOrderDetailCollection(this, new Guid("f6d5a2fe-135b-4d9d-8f31-599023393c29"));
            ((ITTChildObjectCollection)_DrugOrderDetails).GetChildren();
        }

        protected DrugOrderDetail.ChildDrugOrderDetailCollection _DrugOrderDetails = null;
        public DrugOrderDetail.ChildDrugOrderDetailCollection DrugOrderDetails
        {
            get
            {
                if (_DrugOrderDetails == null)
                    CreateDrugOrderDetailsCollection();
                return _DrugOrderDetails;
            }
        }

        protected DrugDeliveryActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugDeliveryActionDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugDeliveryActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugDeliveryActionDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugDeliveryActionDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGDELIVERYACTIONDETAIL", dataRow) { }
        protected DrugDeliveryActionDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGDELIVERYACTIONDETAIL", dataRow, isImported) { }
        public DrugDeliveryActionDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugDeliveryActionDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugDeliveryActionDetail() : base() { }

    }
}