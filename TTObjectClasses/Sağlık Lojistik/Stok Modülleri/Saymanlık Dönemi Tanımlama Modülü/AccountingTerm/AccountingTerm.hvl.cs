
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountingTerm")] 

    /// <summary>
    /// Saymanlık Dönemi Tanımları
    /// </summary>
    public  partial class AccountingTerm : TTObject, IAccountingTerm
    {
        public class AccountingTermList : TTObjectCollection<AccountingTerm> { }
                    
        public class ChildAccountingTermCollection : TTObject.TTChildObjectCollection<AccountingTerm>
        {
            public ChildAccountingTermCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountingTermCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public AccountingTermStatusEnum? Status
        {
            get { return (AccountingTermStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Maliyetlendirme Yöntemi
    /// </summary>
        public CostingMethodEnum? CostingMethod
        {
            get { return (CostingMethodEnum?)(int?)this["COSTINGMETHOD"]; }
            set { this["COSTINGMETHOD"] = value; }
        }

    /// <summary>
    /// İlk Dönem
    /// </summary>
        public bool? IsFirstTerm
        {
            get { return (bool?)this["ISFIRSTTERM"]; }
            set { this["ISFIRSTTERM"] = value; }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountingTerm PrevTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("PREVTERM"); }
            set { this["PREVTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockCensusDetailsCollection()
        {
            _StockCensusDetails = new StockCensusDetail.ChildStockCensusDetailCollection(this, new Guid("c49a4b3b-cfa3-478c-87df-be5ea8e93bd6"));
            ((ITTChildObjectCollection)_StockCensusDetails).GetChildren();
        }

        protected StockCensusDetail.ChildStockCensusDetailCollection _StockCensusDetails = null;
        public StockCensusDetail.ChildStockCensusDetailCollection StockCensusDetails
        {
            get
            {
                if (_StockCensusDetails == null)
                    CreateStockCensusDetailsCollection();
                return _StockCensusDetails;
            }
        }

        virtual protected void CreateStockCensusesCollection()
        {
            _StockCensuses = new StockCensus.ChildStockCensusCollection(this, new Guid("e35a65bb-fe7b-4e5d-9762-e6073ce16756"));
            ((ITTChildObjectCollection)_StockCensuses).GetChildren();
        }

        protected StockCensus.ChildStockCensusCollection _StockCensuses = null;
        public StockCensus.ChildStockCensusCollection StockCensuses
        {
            get
            {
                if (_StockCensuses == null)
                    CreateStockCensusesCollection();
                return _StockCensuses;
            }
        }

        protected AccountingTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountingTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountingTerm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountingTerm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountingTerm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTINGTERM", dataRow) { }
        protected AccountingTerm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTINGTERM", dataRow, isImported) { }
        public AccountingTerm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountingTerm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountingTerm() : base() { }

    }
}