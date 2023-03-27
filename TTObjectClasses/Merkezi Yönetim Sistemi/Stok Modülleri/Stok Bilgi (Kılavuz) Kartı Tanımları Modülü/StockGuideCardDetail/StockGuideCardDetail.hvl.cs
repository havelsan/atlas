
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StockGuideCardDetail")] 

    /// <summary>
    /// Klavuz Kart Muhteviyatı
    /// </summary>
    public  partial class StockGuideCardDetail : TTObject
    {
        public class StockGuideCardDetailList : TTObjectCollection<StockGuideCardDetail> { }
                    
        public class ChildStockGuideCardDetailCollection : TTObject.TTChildObjectCollection<StockGuideCardDetail>
        {
            public ChildStockGuideCardDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStockGuideCardDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockGuideCard StockGuideCard
        {
            get { return (StockGuideCard)((ITTObject)this).GetParent("STOCKGUIDECARD"); }
            set { this["STOCKGUIDECARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected StockGuideCardDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StockGuideCardDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StockGuideCardDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StockGuideCardDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StockGuideCardDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STOCKGUIDECARDDETAIL", dataRow) { }
        protected StockGuideCardDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STOCKGUIDECARDDETAIL", dataRow, isImported) { }
        public StockGuideCardDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StockGuideCardDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StockGuideCardDetail() : base() { }

    }
}