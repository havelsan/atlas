
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OuttableLot")] 

    public  partial class OuttableLot : TTObject
    {
        public class OuttableLotList : TTObjectCollection<OuttableLot> { }
                    
        public class ChildOuttableLotCollection : TTObject.TTChildObjectCollection<OuttableLot>
        {
            public ChildOuttableLotCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOuttableLotCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kullan
    /// </summary>
        public bool? isUse
        {
            get { return (bool?)this["ISUSE"]; }
            set { this["ISUSE"] = value; }
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
    /// Kalan Miktar
    /// </summary>
        public Currency? RestAmount
        {
            get { return (Currency?)this["RESTAMOUNT"]; }
            set { this["RESTAMOUNT"] = value; }
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
    /// Lot Nu.
    /// </summary>
        public string LotNo
        {
            get { return (string)this["LOTNO"]; }
            set { this["LOTNO"] = value; }
        }

    /// <summary>
    /// Bütçe Tipi
    /// </summary>
        public string BudgetTypeName
        {
            get { return (string)this["BUDGETTYPENAME"]; }
            set { this["BUDGETTYPENAME"] = value; }
        }

        public string SerialNo
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

        public Guid? TrxObjectID
        {
            get { return (Guid?)this["TRXOBJECTID"]; }
            set { this["TRXOBJECTID"] = value; }
        }

        public StockActionDetailOut StockActionDetailOut
        {
            get { return (StockActionDetailOut)((ITTObject)this).GetParent("STOCKACTIONDETAILOUT"); }
            set { this["STOCKACTIONDETAILOUT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateReferableInTransactionsCollection()
        {
            _ReferableInTransactions = new ReferableInTransaction.ChildReferableInTransactionCollection(this, new Guid("36f6e069-9826-490d-ac84-c80a64386048"));
            ((ITTChildObjectCollection)_ReferableInTransactions).GetChildren();
        }

        protected ReferableInTransaction.ChildReferableInTransactionCollection _ReferableInTransactions = null;
        public ReferableInTransaction.ChildReferableInTransactionCollection ReferableInTransactions
        {
            get
            {
                if (_ReferableInTransactions == null)
                    CreateReferableInTransactionsCollection();
                return _ReferableInTransactions;
            }
        }

        protected OuttableLot(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OuttableLot(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OuttableLot(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OuttableLot(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OuttableLot(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OUTTABLELOT", dataRow) { }
        protected OuttableLot(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OUTTABLELOT", dataRow, isImported) { }
        public OuttableLot(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OuttableLot(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OuttableLot() : base() { }

    }
}