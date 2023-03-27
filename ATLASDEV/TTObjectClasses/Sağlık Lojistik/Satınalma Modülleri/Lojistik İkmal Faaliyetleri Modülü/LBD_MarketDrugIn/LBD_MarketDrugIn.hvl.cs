
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBD_MarketDrugIn")] 

    /// <summary>
    /// Lojistik İkmal Faaliyetleri Detay kalemi - Piyasa İlaçları için kullanılan sınıftır. (Lojistik İkmal Faaliyetleri listesi dahili)
    /// </summary>
    public  partial class LBD_MarketDrugIn : LBPurchaseProjectDetailInList
    {
        public class LBD_MarketDrugInList : TTObjectCollection<LBD_MarketDrugIn> { }
                    
        public class ChildLBD_MarketDrugInCollection : TTObject.TTChildObjectCollection<LBD_MarketDrugIn>
        {
            public ChildLBD_MarketDrugInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBD_MarketDrugInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("222ab4a0-5000-455c-9023-3630b0c02766"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fcfa3d5d-5780-4b74-8f6e-7b3188e52e8a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("cccf7119-49f4-4a37-9b44-de0b674ac4ff"); } }
        }

    /// <summary>
    /// Farmakolojik Etkisi
    /// </summary>
        public string PharmacologicalEffect
        {
            get { return (string)this["PHARMACOLOGICALEFFECT"]; }
            set { this["PHARMACOLOGICALEFFECT"] = value; }
        }

    /// <summary>
    /// İstek Miktarı (Kutu)
    /// </summary>
        public Currency? RequestAmountBox
        {
            get { return (Currency?)this["REQUESTAMOUNTBOX"]; }
            set { this["REQUESTAMOUNTBOX"] = value; }
        }

        protected LBD_MarketDrugIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBD_MarketDrugIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBD_MarketDrugIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBD_MarketDrugIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBD_MarketDrugIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBD_MARKETDRUGIN", dataRow) { }
        protected LBD_MarketDrugIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBD_MARKETDRUGIN", dataRow, isImported) { }
        public LBD_MarketDrugIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBD_MarketDrugIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBD_MarketDrugIn() : base() { }

    }
}