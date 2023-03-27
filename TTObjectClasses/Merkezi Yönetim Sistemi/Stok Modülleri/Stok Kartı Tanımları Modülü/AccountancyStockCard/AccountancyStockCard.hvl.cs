
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountancyStockCard")] 

    /// <summary>
    /// Saymanlık Stok Kartı Detayı
    /// </summary>
    public  partial class AccountancyStockCard : TTObject
    {
        public class AccountancyStockCardList : TTObjectCollection<AccountancyStockCard> { }
                    
        public class ChildAccountancyStockCardCollection : TTObject.TTChildObjectCollection<AccountancyStockCard>
        {
            public ChildAccountancyStockCardCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountancyStockCardCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sıra Nu.
    /// </summary>
        public long? CardOrderNO
        {
            get { return (long?)this["CARDORDERNO"]; }
            set { this["CARDORDERNO"] = value; }
        }

    /// <summary>
    /// Kart Durumu
    /// </summary>
        public StockCardStatusEnum? Status
        {
            get { return (StockCardStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Açılış Tarihi
    /// </summary>
        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kart Adedi
    /// </summary>
        public long? CardAmount
        {
            get { return (long?)this["CARDAMOUNT"]; }
            set { this["CARDAMOUNT"] = value; }
        }

    /// <summary>
    /// Masa-Saymanlık Stok Kartları
    /// </summary>
        public ResCardDrawer CardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("CARDDRAWER"); }
            set { this["CARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Stok Kart - Saymanlık Stok Kartları
    /// </summary>
        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Saymanlık - Saymanlık Stok Kartı
    /// </summary>
        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AccountancyStockCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountancyStockCard(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountancyStockCard(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountancyStockCard(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountancyStockCard(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTANCYSTOCKCARD", dataRow) { }
        protected AccountancyStockCard(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTANCYSTOCKCARD", dataRow, isImported) { }
        public AccountancyStockCard(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountancyStockCard(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountancyStockCard() : base() { }

    }
}