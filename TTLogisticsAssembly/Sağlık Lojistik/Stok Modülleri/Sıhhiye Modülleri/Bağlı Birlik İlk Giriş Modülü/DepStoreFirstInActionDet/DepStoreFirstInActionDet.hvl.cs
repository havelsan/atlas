
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DepStoreFirstInActionDet")] 

    public  partial class DepStoreFirstInActionDet : TTObject
    {
        public class DepStoreFirstInActionDetList : TTObjectCollection<DepStoreFirstInActionDet> { }
                    
        public class ChildDepStoreFirstInActionDetCollection : TTObject.TTChildObjectCollection<DepStoreFirstInActionDet>
        {
            public ChildDepStoreFirstInActionDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDepStoreFirstInActionDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDate
        {
            get { return (DateTime?)this["EXPIRATIONDATE"]; }
            set { this["EXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyatı
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockLevelType StockLevelType
        {
            get { return (StockLevelType)((ITTObject)this).GetParent("STOCKLEVELTYPE"); }
            set { this["STOCKLEVELTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DepStoreFirstInAction DepStoreFirstInAction
        {
            get { return (DepStoreFirstInAction)((ITTObject)this).GetParent("DEPSTOREFIRSTINACTION"); }
            set { this["DEPSTOREFIRSTINACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDepStoreFixedAssetDetailsCollection()
        {
            _DepStoreFixedAssetDetails = new DepStoreFixedAssetDetail.ChildDepStoreFixedAssetDetailCollection(this, new Guid("b00596b5-938e-43f6-97f4-91d779bc1ac4"));
            ((ITTChildObjectCollection)_DepStoreFixedAssetDetails).GetChildren();
        }

        protected DepStoreFixedAssetDetail.ChildDepStoreFixedAssetDetailCollection _DepStoreFixedAssetDetails = null;
        public DepStoreFixedAssetDetail.ChildDepStoreFixedAssetDetailCollection DepStoreFixedAssetDetails
        {
            get
            {
                if (_DepStoreFixedAssetDetails == null)
                    CreateDepStoreFixedAssetDetailsCollection();
                return _DepStoreFixedAssetDetails;
            }
        }

        protected DepStoreFirstInActionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DepStoreFirstInActionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DepStoreFirstInActionDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DepStoreFirstInActionDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DepStoreFirstInActionDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEPSTOREFIRSTINACTIONDET", dataRow) { }
        protected DepStoreFirstInActionDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEPSTOREFIRSTINACTIONDET", dataRow, isImported) { }
        public DepStoreFirstInActionDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DepStoreFirstInActionDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DepStoreFirstInActionDet() : base() { }

    }
}