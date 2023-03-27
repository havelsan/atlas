
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSAccountancyReceipt")] 

    public  partial class MBtSAccountancyReceipt : TTObject
    {
        public class MBtSAccountancyReceiptList : TTObjectCollection<MBtSAccountancyReceipt> { }
                    
        public class ChildMBtSAccountancyReceiptCollection : TTObject.TTChildObjectCollection<MBtSAccountancyReceipt>
        {
            public ChildMBtSAccountancyReceiptCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSAccountancyReceiptCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
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
    /// Fiş No
    /// </summary>
        public string SlipNo
        {
            get { return (string)this["SLIPNO"]; }
            set { this["SLIPNO"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

        public MBtSPaymaster Paymaster
        {
            get { return (MBtSPaymaster)((ITTObject)this).GetParent("PAYMASTER"); }
            set { this["PAYMASTER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBudgetYearCollection()
        {
            _BudgetYear = new MBtSBudgetYear.ChildMBtSBudgetYearCollection(this, new Guid("be70085a-ef1b-46ee-b49d-9fc84e9035cf"));
            ((ITTChildObjectCollection)_BudgetYear).GetChildren();
        }

        protected MBtSBudgetYear.ChildMBtSBudgetYearCollection _BudgetYear = null;
        public MBtSBudgetYear.ChildMBtSBudgetYearCollection BudgetYear
        {
            get
            {
                if (_BudgetYear == null)
                    CreateBudgetYearCollection();
                return _BudgetYear;
            }
        }

        protected MBtSAccountancyReceipt(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSAccountancyReceipt(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSAccountancyReceipt(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSAccountancyReceipt(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSAccountancyReceipt(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSACCOUNTANCYRECEIPT", dataRow) { }
        protected MBtSAccountancyReceipt(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSACCOUNTANCYRECEIPT", dataRow, isImported) { }
        public MBtSAccountancyReceipt(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSAccountancyReceipt(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSAccountancyReceipt() : base() { }

    }
}