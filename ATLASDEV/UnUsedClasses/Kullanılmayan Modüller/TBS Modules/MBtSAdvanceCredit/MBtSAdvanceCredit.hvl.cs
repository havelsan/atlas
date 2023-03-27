
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSAdvanceCredit")] 

    public  partial class MBtSAdvanceCredit : TTObject
    {
        public class MBtSAdvanceCreditList : TTObjectCollection<MBtSAdvanceCredit> { }
                    
        public class ChildMBtSAdvanceCreditCollection : TTObject.TTChildObjectCollection<MBtSAdvanceCredit>
        {
            public ChildMBtSAdvanceCreditCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSAdvanceCreditCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İşlem fiş no
    /// </summary>
        public string OperationSlipNo
        {
            get { return (string)this["OPERATIONSLIPNO"]; }
            set { this["OPERATIONSLIPNO"] = value; }
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
    /// İşlem fişi tarihi
    /// </summary>
        public DateTime? OperationSlipAdvance
        {
            get { return (DateTime?)this["OPERATIONSLIPADVANCE"]; }
            set { this["OPERATIONSLIPADVANCE"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public int? Type
        {
            get { return (int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Mahsup işlem fişi no
    /// </summary>
        public string DeductionOperationSlipNo
        {
            get { return (string)this["DEDUCTIONOPERATIONSLIPNO"]; }
            set { this["DEDUCTIONOPERATIONSLIPNO"] = value; }
        }

    /// <summary>
    /// Mahsup işlem fişi tarihi
    /// </summary>
        public DateTime? DeductionOperationSlipDate
        {
            get { return (DateTime?)this["DEDUCTIONOPERATIONSLIPDATE"]; }
            set { this["DEDUCTIONOPERATIONSLIPDATE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Comment
        {
            get { return (string)this["COMMENT"]; }
            set { this["COMMENT"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

        virtual protected void CreateFinanceEntriesCollection()
        {
            _FinanceEntries = new MBtSFinanceEntry.ChildMBtSFinanceEntryCollection(this, new Guid("cb67207b-4bcc-47dc-b27b-39f778f9fc3d"));
            ((ITTChildObjectCollection)_FinanceEntries).GetChildren();
        }

        protected MBtSFinanceEntry.ChildMBtSFinanceEntryCollection _FinanceEntries = null;
        public MBtSFinanceEntry.ChildMBtSFinanceEntryCollection FinanceEntries
        {
            get
            {
                if (_FinanceEntries == null)
                    CreateFinanceEntriesCollection();
                return _FinanceEntries;
            }
        }

        virtual protected void CreateAdvanceCreditClosureCollection()
        {
            _AdvanceCreditClosure = new MBtSAdvanceCreditClosure.ChildMBtSAdvanceCreditClosureCollection(this, new Guid("9b5c02fd-505e-4024-b8a5-ab350e0c6a0b"));
            ((ITTChildObjectCollection)_AdvanceCreditClosure).GetChildren();
        }

        protected MBtSAdvanceCreditClosure.ChildMBtSAdvanceCreditClosureCollection _AdvanceCreditClosure = null;
        public MBtSAdvanceCreditClosure.ChildMBtSAdvanceCreditClosureCollection AdvanceCreditClosure
        {
            get
            {
                if (_AdvanceCreditClosure == null)
                    CreateAdvanceCreditClosureCollection();
                return _AdvanceCreditClosure;
            }
        }

        protected MBtSAdvanceCredit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSAdvanceCredit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSAdvanceCredit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSAdvanceCredit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSAdvanceCredit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSADVANCECREDIT", dataRow) { }
        protected MBtSAdvanceCredit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSADVANCECREDIT", dataRow, isImported) { }
        public MBtSAdvanceCredit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSAdvanceCredit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSAdvanceCredit() : base() { }

    }
}