
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSAdditionalFund")] 

    public  partial class MBtSAdditionalFund : TTObject
    {
        public class MBtSAdditionalFundList : TTObjectCollection<MBtSAdditionalFund> { }
                    
        public class ChildMBtSAdditionalFundCollection : TTObject.TTChildObjectCollection<MBtSAdditionalFund>
        {
            public ChildMBtSAdditionalFundCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSAdditionalFundCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Teklif tarih
    /// </summary>
        public DateTime? OfferDate
        {
            get { return (DateTime?)this["OFFERDATE"]; }
            set { this["OFFERDATE"] = value; }
        }

    /// <summary>
    /// Onay tarih
    /// </summary>
        public DateTime? ApprovalDate
        {
            get { return (DateTime?)this["APPROVALDATE"]; }
            set { this["APPROVALDATE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public bool? Status
        {
            get { return (bool?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

        virtual protected void CreateFinanceEntryCollection()
        {
            _FinanceEntry = new MBtSFinanceEntry.ChildMBtSFinanceEntryCollection(this, new Guid("fc23b0f6-9586-432f-9993-1a41fee061bc"));
            ((ITTChildObjectCollection)_FinanceEntry).GetChildren();
        }

        protected MBtSFinanceEntry.ChildMBtSFinanceEntryCollection _FinanceEntry = null;
    /// <summary>
    /// Child collection for ????????????????????????
    /// </summary>
        public MBtSFinanceEntry.ChildMBtSFinanceEntryCollection FinanceEntry
        {
            get
            {
                if (_FinanceEntry == null)
                    CreateFinanceEntryCollection();
                return _FinanceEntry;
            }
        }

        virtual protected void CreateFinanceCenterCollection()
        {
            _FinanceCenter = new MBtSFinanceCenter.ChildMBtSFinanceCenterCollection(this, new Guid("cf36924d-9992-4c39-9cc2-d5e3c4c896bd"));
            ((ITTChildObjectCollection)_FinanceCenter).GetChildren();
        }

        protected MBtSFinanceCenter.ChildMBtSFinanceCenterCollection _FinanceCenter = null;
        public MBtSFinanceCenter.ChildMBtSFinanceCenterCollection FinanceCenter
        {
            get
            {
                if (_FinanceCenter == null)
                    CreateFinanceCenterCollection();
                return _FinanceCenter;
            }
        }

        protected MBtSAdditionalFund(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSAdditionalFund(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSAdditionalFund(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSAdditionalFund(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSAdditionalFund(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSADDITIONALFUND", dataRow) { }
        protected MBtSAdditionalFund(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSADDITIONALFUND", dataRow, isImported) { }
        public MBtSAdditionalFund(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSAdditionalFund(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSAdditionalFund() : base() { }

    }
}